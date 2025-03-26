using Microsoft.EntityFrameworkCore;
using MyRestfulWebshop.EF;
using MyRestfulWebshop.EF.Models;

namespace MyRestfulWebshop.Service
{
    public class ProductService
    {
        private readonly MyRestfulWebshopContext _context;

        public ProductService(MyRestfulWebshopContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(string orderField)
        {
            var query = _context.Products.AsQueryable();

            if (orderField == "price")
            {
                query = query.OrderBy(p => p.Price);
            }

            if (orderField == "name")
            {
                query = query.OrderBy(p => p.Name);
            }

            return await query.ToListAsync();
        }

        public async Task<Product> GetProductAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task AddProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(int id, Product product)
        {
            var dbProduct = await GetProductAsync(id);

            if (dbProduct != null)
            {
                dbProduct.Name = product.Name;
                dbProduct.Price = product.Price;
                dbProduct.Stock = product.Stock;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteProductAsync(int id)
        {
            var dbProduct = await GetProductAsync(id);

            if (dbProduct != null)
            {
                _context.Products.Remove(dbProduct);
                await _context.SaveChangesAsync();
            }
        }

    }
}
