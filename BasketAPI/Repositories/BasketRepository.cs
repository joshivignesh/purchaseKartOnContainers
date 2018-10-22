using Basket.API.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StackExchange.Redis;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Repositories
{
    public class BasketRepository : IBasketRepository
    {

        private readonly ILogger<BasketRepository> _logger;

        private readonly ConnectionMultiplexer _redis;
        IDatabase db;

        
        public BasketRepository(ILoggerFactory loggerFactory, ConnectionMultiplexer redis)
        {
            _logger = loggerFactory.CreateLogger<BasketRepository>();
            _redis = redis;
            db = redis.GetDatabase();
        }

        public async Task<Customer> AddBasketAsync(Customer customer)
        {

            var created = await db.StringSetAsync(customer.CustomerId, JsonConvert.SerializeObject(customer));
            if (!created)
            {
                _logger.LogInformation("Problem occur persisting the item.");
                return null;
            }

            _logger.LogInformation("Basket item persisted succesfully.");

            return await GetBasketAsync(customer.CustomerId);
        }

        public bool ClearBasket(Customer customer)
        {
            var server = GetServer();
            server.FlushDatabase();

            return true;

        }

        public async Task<List<Customer>> DeleteBasketAsync(string id)
        {
           

            var result = await db.KeyDeleteAsync(id);

            var server = GetServer();
            var data = server.Keys();
            IEnumerable<string> keys = data?.Select(k => k.ToString());
            var lst = new List<Customer>();

            foreach (var item in keys)
            {
                var getItem = await db.StringGetAsync(item);

                if (!getItem.IsNullOrEmpty)
                {
                    lst.Add(JsonConvert.DeserializeObject<Customer>(getItem));
                }
            }
            return lst;
        }

        public async Task<Customer> GetBasketAsync(string customerId)
        {
            var data = await db.StringGetAsync(customerId);
            if (data.IsNullOrEmpty)
                return null;
            else
                return JsonConvert.DeserializeObject<Customer>(data);
        }
               
        public async Task<List<Customer>> GetAllItems()
        {
            var server = GetServer();
            var data = server.Keys();
            IEnumerable<string> keys = data?.Select(k => k.ToString());
            var lst = new List<Customer>();

            foreach (var item in keys)
            {
                var getItem = await db.StringGetAsync(item);

                if (!getItem.IsNullOrEmpty)
                {
                    lst.Add(JsonConvert.DeserializeObject<Customer>(getItem));
                }


            }

            return lst;
        }

        private IServer GetServer()
        {
            var endpoint = _redis.GetEndPoints();
            return _redis.GetServer(endpoint.First());
        }

    }
}
