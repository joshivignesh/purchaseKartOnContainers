using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Models
{
    public class Customer
    {
        public string CustomerId { get; set; }
        public Product Products { get; set; }

        public Customer(string customerId)
        {
            CustomerId = customerId;
            Products = new Product();
        }
    }
}
