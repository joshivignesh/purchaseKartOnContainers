using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Basket.API.Models;
using Basket.API.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors(PolicyName = "HexPolicy")]
    public class BasketController : ControllerBase
    {
        IBasketRepository repository;

        public BasketController(IBasketRepository basketRepository)
        {
            repository = basketRepository;
        }

        //GET /api/basket
        /// <summary>
        /// To Get all basket items
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [HttpGet("", Name = "ListItems")]
        public Task<List<Customer>> GetBasketItems()
        {
            try
            {
                return repository.GetAllItems();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        //GET /api/basket/{id}
        /// <summary>
        /// To Get specific basket item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetBasket")]
        public async Task<Customer> GetBasket(int id)
        {
            return await repository.GetBasketAsync(id.ToString());
        }

        //POST /api/basket
        /// <summary>
        /// Add item into basket
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [HttpPost("", Name = "AddBasket")]
        public async Task<Customer> AddBasket(Customer customer)
        {
            return await repository.AddBasketAsync(customer);
        }

        //DELETE /api/basket/{id}
        /// <summary>
        /// Delete item frombasket
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpDelete("{id}", Name = "DeleteBasket")]
        public async Task<List<Customer>> DeleteBasket(string id)
        {
            return await repository.DeleteBasketAsync(id);
        }


    }
}