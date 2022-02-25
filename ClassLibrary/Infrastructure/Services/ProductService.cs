using ClassLibrary.Data;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary
{
    public class ProductService : IProductService
    {
        protected readonly DemoContext _context;
        public ProductService(DemoContext context) => _context = context;

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.Find(id);
        }
        public async Task<Product> CreateProductAsync(Product product)
        {
            await _context.Set<Product>().AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProductAsync(Product product)
        {
            //var entity = await GetByIdAsync(id);
            if (product is null)
            {
                return false;
            }

            _context.Set<Product>().Remove(product);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
