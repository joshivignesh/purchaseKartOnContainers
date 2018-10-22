using System;
using System.ComponentModel.DataAnnotations;

namespace CatalogAPI.Model
{
    /// <summary>
    /// Stores details of all products for the application
    /// </summary>
    public class Catalog
    {
        [Key]
        public int CatalogId { get; set; }

        public int UserId { get; set; }

        //public int InventoryId { get; set; }

        //public int ProductId { get; set; }

        public decimal Price { get; set; }

        public string Name { get; set; }

        public DateTime ShoppingDate { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public string ImageUrl { get; set; }

        public int AvailableStock { get; set; }
        
    }
}
