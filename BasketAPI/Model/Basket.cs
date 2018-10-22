using CatalogAPI.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasketAPI.Model
{
    /// <summary>
    /// Basket Item stored to Cart and stored into DB
    /// </summary>
    public class Basket
    {
        [Key]
        public int BasketId { get; set; }

        public string BasketName { get; set; }

        [ForeignKey("Catalog")]
        public int CatalogId { get; set; }

        public ICollection<Catalog> Posts { get; set; } = new List<Catalog>();

        //public int OrderId { get; set; }

        //public string OrderName { get; set; }

        public int UserId { get; set; }
    }
}
