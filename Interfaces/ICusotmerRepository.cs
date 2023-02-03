using WebApplication1.Data;

namespace WebApplication1.Interfaces
{
    public interface ICusotmerRepository
    {
        public Task<List<Customer>> GetAllcustomerAsync();
        public Task<Customer> GetByIdAsync(int id);
        public Task<Customer> GetByNameAsync(string name);
        public Task<Customer> CreatecustomerAsync(Customer customer);
        public Task DeleteAsync(int id);
        public Task UpdateAsync(Customer customer);
    }
}
