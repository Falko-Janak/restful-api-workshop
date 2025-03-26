using Microsoft.AspNetCore.Mvc;
using MyRestfulWebshop.API.Converter;
using MyRestfulWebshop.API.Dtos;
using MyRestfulWebshop.EF.Models;
using MyRestfulWebshop.Service;

namespace MyRestfulWebshop.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string orderField = "")
        {
            var products = await _productService.GetProductsAsync(orderField);
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductEditDto dto)
        {
            var product = ProductConverter.FromEditDto(dto);
            await _productService.AddProductAsync(product);
            return Created();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productService.GetProductAsync(id);

            if (product == null)
                return NotFound("Produkt nicht gefunden");

            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductEditDto dto)
        {
            var product = ProductConverter.FromEditDto(dto);
            await _productService.UpdateProductAsync(id, product);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProductAsync(id);
            return Ok();
        }

    }
}
