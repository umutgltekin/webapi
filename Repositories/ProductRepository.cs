using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Interfaces;

namespace WebApplication1.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateAsync(Product product)
        {
          await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync(); 
            return product;
        }

        public async Task DeleteAsync(int id)
        {
            var remove = await _context.Products.FindAsync(id);
            _context.Products.Remove(remove);
            _context.SaveChanges();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.AsNoTracking().ToListAsync();
            
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Product> GetByNameAsync(string name)
        {
            return await _context.Products.AsNoTracking().SingleOrDefaultAsync(x => x.Name == name);
        }

        public async Task UpdateAsync(Product product)
        {
            var unchangedEntity=await _context.Products.FindAsync(product.Id);
            _context.Entry(unchangedEntity).CurrentValues.SetValues(product);
            _context.SaveChangesAsync();
          
        }
    }
}
