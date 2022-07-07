using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductController : ControllerBase
    {
        DataLayer db = new DataLayer();
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            DataTable dt = db.GetProductsRecord();
            var result = new ObjectResult(dt);
            return result;
        }

        [HttpGet("GetProduct")]
        public ActionResult<IEnumerable<string>> Getset(string ID)
        {
            DataTable dt = db.GetProductRecord(ID.ToString());
            var result = new ObjectResult(dt);
            return result;
        }

        [HttpDelete]
        public ActionResult<IEnumerable<string>> Delete(string ID)
        {
            DataTable dt = db.GetProductDelete(ID.ToString());
            var result = new ObjectResult(dt);
            return result;
        }
        [HttpPut("GetProductUpdate")]
        public ActionResult<IEnumerable<string>> Update(string id, string pname, string category, string descriptions, string oprice, string cprice, string proimg)
        {
            DataTable dt = db.GetproductUpdate(id.ToString(), pname.ToString(), category.ToString(), descriptions.ToString(), oprice.ToString(),cprice.ToString(), proimg.ToString());
            var result = new ObjectResult(dt);
            return result;
        }
        [HttpPost("GetProductInsert")]
        public ActionResult<IEnumerable<string>> Insert(string pname, string category, string descriptions, string oprice, string cprice, string proimg)
        {
            DataTable dt = db.GetproductInsert(pname.ToString(),category.ToString(),descriptions.ToString(),oprice.ToString(), cprice.ToString(), proimg.ToString());
            var result = new ObjectResult(dt);
            return result;
        }

    }
}
