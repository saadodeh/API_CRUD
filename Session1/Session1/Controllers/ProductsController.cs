using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Session1.Models;

namespace Session1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class ProductsController : ControllerBase
    {
        //وظيفة الكنترولار يجيب الداتا من المودل ويرجعها 
        List<Product> products = new List<Product>()
        {
            new Product{ Id=1,Name="Shambo",Description="this is head shampo"},
            new Product{ Id=2,Name="suger",Description="this is suger" },
            new Product{ Id=3,Name="salt",Description="this iss salt"}
        };
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(products);
        }
        [HttpGet("{id}")]//get by id /Product/1..2...3
        public IActionResult GetBYId(int id)
        {
            var product = products.First(prod => prod.Id == id);
            if (product is null)
            {
                NotFound();
            }
            return Ok(products);

        }
        [HttpPost]
        public IActionResult Add(Product request)
        {
            if (request is null)
            {
                return BadRequest();
            }
            var product = new Product
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description
            };
            products.Add(product);
            return Ok(product);

        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Product request)
        {
            var currentProduct = products.FirstOrDefault(prod => prod.Id == id);
            if (currentProduct is null)
            { return NotFound(); }
            currentProduct.Name=request.Name;
            currentProduct.Description=request.Description;
            
            return Ok(currentProduct);
        }
        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(prod => prod.Id == id);
            if (product is null)
            {
                return NotFound();
            }
            products.Remove(product);
            return Ok(); 
        }
    }
}
