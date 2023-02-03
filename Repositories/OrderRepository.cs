using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Interfaces;

namespace WebApplication1.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ProductContext _context;
        public OrderRepository (ProductContext context)
        {
            _context = context;
        }
        
        public async Task<Order> CreateAsync(Order order)
        {
           await _context.Orders.AddAsync(order);
           _context.SaveChanges();
           return order;
        }

        public async Task DeleteAsync(int id)
        {
            var remove =await _context.Orders.FindAsync(id);
            _context.Orders.Remove(remove);
            _context.SaveChanges();           
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Orders.AsNoTracking().ToListAsync();
        }

    

        public async Task UpdateAsync(Order order)
        {
            var uncahged = await _context.Orders.FindAsync(order.Id);
            _context.Entry(uncahged).CurrentValues.SetValues(order);
            _context.SaveChanges();
        }

        public  IQueryable<Object> GetAsync(int id)
        {
            return from o in _context.Orders
                            join p in _context.Products on o.ProductId equals p.Id
                            join cs in _context.Customers on o.CustomerId equals cs.Id
                            where p.Id == id
                            select new
                            {
                                productName = p.Name,
                                CustomerNAme = cs.Name,
                            };
        }
        public async Task<Order> GetByIdAsync(int id)
        {
            return await _context.Orders.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
