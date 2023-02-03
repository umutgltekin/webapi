using WebApplication1.Data;

namespace WebApplication1.Interfaces
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetAllAsync();
        public Task<Product> GetByIdAsync(int id);
        public Task<Product> GetByNameAsync(string name);
        public Task<Product> CreateAsync(Product product);
        public Task DeleteAsync(int id);   
        public Task UpdateAsync(Product product);
        
    }
}
