using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using OrderAPI.Models;
using OrderAPI.Repositories;
using System;
using System.Threading.Tasks;

namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class OrdersController : ControllerBase
    {
        private IRepository<Order> repository;
        public OrdersController(IRepository<Order> repo)
        {
            this.repository = repo;
        }
        public string Get()
        {
            return "Order API is ready";
        }

        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [HttpPost("", Name = "PlaceOrder")]
        public async Task<ActionResult<Order>> PlaceOrder(Order order)
        {
            if (order == null)
            {
                return BadRequest();
            }
            order.OrderDate = DateTime.Now;
            var result = await this.repository.AddAsync(order);
            return result;
        }

        //PUT /api/orders/{id}
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [HttpPut("{id:int?}", Name = "UpdateOrder")]
        public async Task<ActionResult<Order>> UpdateOrder(int? id, Order order)
        {
            if (id == null) return BadRequest();
            if (id.Value != order.Id) return NotFound();
            var item = await this.repository.UpdateAsync(id.Value, order);
            return item;
        }

        //DELETE  /api/orders/{id}
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]        
        [HttpDelete("{id:int?}", Name = "DeleteOrder")]
        public async Task<ActionResult<Order>> DeleteOrder(int? id)
        {
            if (id == null) return BadRequest();
            var result = await this.repository.DeleteAsync(id.Value);
            if (result == null)
                return NotFound();
            return result;
        }
    }
}