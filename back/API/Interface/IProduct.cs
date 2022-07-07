using API.Models;
using System.Data;

namespace API.Interface
{
    public interface IProduct
    {
        public List<Product> GetProductsRecord();
        public Product GetProductRecord(int id);

        public string GetProductDelete(int id);

        public string GetproductUpdate(Product product);
        //public string GetproductUpdate(string id, string pname, string category, string description, string oprice, string cprice, string proimg);

        public string GetproductInsert(Product product);
        //public string GetproductInsert(string pname, string category, string description, string oprice, string cprice, string proimg);
    }
}
