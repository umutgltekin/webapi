using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using WebApplication1.Data;
using WebApplication1.Interfaces;

namespace WebApplication1.Repositories
{
    public class CustomerRepository : ICusotmerRepository
    {
        private readonly ProductContext _context;
        public CustomerRepository(ProductContext context)
        {
            _context = context;
        }

        public async Task<Customer> CreatecustomerAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

      
        public async Task DeleteAsync(int id)
        {
            var remove=await _context.Customers.FindAsync(id);
            _context.Customers.Remove(remove);
            _context.SaveChanges();
            
        }

        public async Task<List<Customer>> GetAllcustomerAsync()
        {
          return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _context.Customers.AsNoTracking().SingleOrDefaultAsync(x=> x.Id == id);
        }

        public async Task<Customer> GetByNameAsync(string name)
        {
           return await _context.Customers.AsNoTracking().SingleOrDefaultAsync(x=> x.Name == name);
        }

        public async Task UpdateAsync(Customer customer)
        {
            var unchangeCustomer=await _context.Customers.FindAsync(customer.Id);
            _context.Entry(unchangeCustomer).CurrentValues.SetValues(customer);
            _context.SaveChanges();
        }
    }
}
