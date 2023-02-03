using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;

namespace WebApplication1.Interfaces
{
    public interface IOrderRepository
    {
        public Task<List<Order>> GetAllAsync();
        public Task<Order> GetByIdAsync(int id);
        public IQueryable<Object> GetAsync(int id);
        public Task<Order> CreateAsync(Order order);
        public Task DeleteAsync(int id);
        public Task UpdateAsync(Order order);

    }
}
