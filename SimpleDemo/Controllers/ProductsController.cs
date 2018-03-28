using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleDemo.Data.Repository;
using SimpleDemo.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleDemo.Controllers
{
	[Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
		private readonly IGenericRepository<Product> repository;

        public ProductsController(IGenericRepository<Product> repository)
        {
			this.repository = repository;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
			var products = await repository.GetAll().ToListAsync();
			return Ok(products);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

			var product = await repository.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.Id)
            {
                return BadRequest();
            }

            try
            {
				await repository.Update(id, product);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

			await repository.Create(product);

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

			var product = await repository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

			await repository.Delete(id);

            return Ok(product);
        }

        private bool ProductExists(int id)
        {
            return repository.GetAll().Any(p => p.Id == id);
        }
    }
}