using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Interfaces;


namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/order/[controller]")]
    public class OrderController : ControllerBase 
    { 
        private readonly IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(int id)
        //{
        //    var result= await _orderRepository.GetByIdAsync(id);

        //    return Ok(result);
        //}
        [HttpGet("{id}")]
        public async Task<IActionResult> Getproduct(int id)
        {
            var result =  _orderRepository.GetAsync(id);

            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> delete(int id)
        {
             await _orderRepository.GetByIdAsync(id);
            if (id == null)
            {
                return NotFound();
            }
            await _orderRepository.DeleteAsync(id);
            return NoContent();      
        }
        [HttpPost]
        public async Task<IActionResult> Crate(Order order)
        {
            var result = await _orderRepository.CreateAsync(order);
            return Ok(result);  

        }
        [HttpPut]
        public async Task<IActionResult> Update(Order order)
        {
            var unchange =  await _orderRepository.GetByIdAsync(order.Id);
            if (order.Id == null)
            {
                return NotFound();
            }
            await _orderRepository.UpdateAsync(order);
            return NoContent();
        }
       
    }
}
