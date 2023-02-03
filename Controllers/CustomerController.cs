using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using WebApplication1.Data;
using WebApplication1.Interfaces;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/customer/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICusotmerRepository _cusotmerRepository;

        public CustomerController(ICusotmerRepository cusotmerRepository)
        {
            _cusotmerRepository = cusotmerRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result =await _cusotmerRepository.GetAllcustomerAsync();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Created(Customer customer)
        {
           var addedcustomer= await _cusotmerRepository.CreatecustomerAsync(customer);
            return Ok(addedcustomer);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleted(int id)
        {
            var result=await _cusotmerRepository.GetByIdAsync(id);
            if (id == null)
            {
                return NotFound(id);
            }
            await _cusotmerRepository.DeleteAsync(id);
            return NoContent();
          
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(Customer customer)
        {
            var result = await _cusotmerRepository.GetByIdAsync(customer.Id);
            if (result == null)
            {
                return NotFound();
            }
            await _cusotmerRepository.UpdateAsync(customer);
            return NoContent();


        }
    }
}
