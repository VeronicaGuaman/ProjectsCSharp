using ClassLibrary.Data;

namespace ClassLibrary
{
    public interface IProductService
    {
        Task<Product> CreateProductAsync(Product product);
        Task<bool> DeleteProductAsync(Product product);
        Product GetProductById(int id);
        IEnumerable<Product> GetProducts();
        Task<bool> UpdateProductAsync(Product product);
    }
}
