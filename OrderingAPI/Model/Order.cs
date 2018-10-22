using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderingAPI.Model
{
    /// <summary>
    /// When checked out the ordered item will move to DB
    /// </summary>
    public class Order
    {
        [Key]
        public int OrderId { get; set; }


        [ForeignKey("Basket")]
        public int BasketId { get; set; }

        
        public string UserId { get; set; }

        public string ReceiverName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Zip { get; set; }

        public string State { get; set; }

        public string TypeOfShipping { get; set; }

        public DateTime DateOfPurchase { get; set; }
    }
}
