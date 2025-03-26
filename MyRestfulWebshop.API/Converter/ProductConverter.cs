using MyRestfulWebshop.API.Dtos;
using MyRestfulWebshop.EF.Models;

namespace MyRestfulWebshop.API.Converter
{
    public class ProductConverter
    {

        public static Product FromEditDto(ProductEditDto dto)
        {
            return new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                Stock = dto.Stock
            };
        }

    }
}
