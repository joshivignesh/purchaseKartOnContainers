using Basket.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Repositories
{
    public interface IBasketRepository
    {
        Task<Customer> GetBasketAsync(string customerId);
        Task<Customer> AddBasketAsync(Customer customer);
        bool ClearBasket(Customer customer);
        Task<List<Customer>> GetAllItems();
        Task<List<Customer>> DeleteBasketAsync(string id);
    }
}
