using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogAPI.Models
{
    public class Product: EntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public override int Id { get; set; }
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public int Cost { get; set; }
    }
}
