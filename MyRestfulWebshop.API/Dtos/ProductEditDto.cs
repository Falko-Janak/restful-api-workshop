using System.ComponentModel.DataAnnotations;

namespace MyRestfulWebshop.API.Dtos
{
    public class ProductEditDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Stock { get; set; }
    }
}
