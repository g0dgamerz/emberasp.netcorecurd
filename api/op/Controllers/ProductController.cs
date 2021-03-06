using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using op.Data;
using op.Entities;

namespace op.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Productontroller: ControllerBase
    {
        private readonly StoreContext _context;

        public Productontroller(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _context.Products.FindAsync(id);
        }
    }
}
