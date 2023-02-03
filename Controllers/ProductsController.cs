using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using WebApplication1.Data;
using WebApplication1.Interfaces;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var result= await _productRepository.GetAllAsync();
            return Ok(result);  
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result= await _productRepository.GetByIdAsync(id);
            if(id==null)
            {
                return NotFound(id);
            }
            return Ok(result);
        }
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetByNameAsync(string name)
        {
           var result= await _productRepository.GetByNameAsync(name);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreatedProduct(Product product)
        {
            var addedProduct = _productRepository.CreateAsync(product);
            return Created(string.Empty, addedProduct);


        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            var result = await _productRepository.GetByIdAsync(product.Id);
            if (product.Id == null)
            {
                return NotFound(product.Id);
            }
            await _productRepository.UpdateAsync(product);
            return NoContent();


           }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
             await _productRepository.GetByIdAsync(id);
            if (id == null)
            {
                return NotFound(id);
            }
            await _productRepository.DeleteAsync(id);
            return NoContent();
           
        }




        //[HttpGet]
        //public IActionResult GetProducts()
        //{
        //    return Ok(new[] { new { name = "laptop",price=555, }, new { name = "araba", price = 140000, },new  { name = "telefon", price = 7899, } }) ;
        //}
        //[HttpGet("{id}")]
        //public IActionResult GetProduct(int id)
        //{
        //    return Ok(new[] { new { name = "araba", price = 140000, }, new { name = "telefon", price = 7899, } });
        //}
    }
}
