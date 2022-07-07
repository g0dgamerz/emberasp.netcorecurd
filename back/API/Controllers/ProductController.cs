using API.Interface;
using API.Models;
using API.services;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _productService;
        public ProductController(IProduct productService)
        {
            _productService=productService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<string>> ProductList()
        {
            //List<Product> ProductList = new List<Product>();
            //var list = _productService.GetProductsRecord().ToList();
            var list = _productService.GetProductsRecord();
            var result = new ObjectResult(list);
            return result;
        }
        [HttpGet("Getproduct/{id:int}")]
        public IActionResult Get1Product(int id)
        {
            Product product = new Product();
             product = _productService.GetProductRecord(id);
            return  new ObjectResult(product);
        }
        [HttpDelete]
        public string Delete(int id)
        {
            return _productService.GetProductDelete(id);
           
        }
        [HttpPost("Getproductinsert")]
        public string Insert(Product pro)
        {
            return _productService.GetproductInsert(pro);
         
        }
        [HttpPut("getproductupdate")]
        public string Update(Product pro)
        {
            return _productService.GetproductUpdate(pro);
           
        }
    }
}
