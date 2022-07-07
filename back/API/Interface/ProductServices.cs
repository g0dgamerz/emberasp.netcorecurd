using API.Interface;
using API.Models;
using System.Data;
using System.Data.SqlClient;

namespace API.services
{
    public class ProductServices: IProduct
    {
        public string Constr { get; set; }
        public IConfiguration _configuration;
        public SqlConnection con;
        public IFeature _feature;

        public ProductServices(IConfiguration configuration ,  IFeature feature )
        {
            _configuration = configuration;
            Constr = _configuration.GetConnectionString("DBConnection");
            _feature = feature;
        }

        public List<Product> GetProductsRecord()
        //public DataTable GetProductsRecord()
        {
            List<Product> productsList = new List<Product>();
            DataTable dt = new DataTable();

            try
            {
                //SqlDataReader dr;

                using (con=new SqlConnection(Constr))
                {
                    //using (SqlCommand cmd = new SqlCommand("proselect",con))
                    //{
                    //    cmd.CommandType = CommandType.StoredProcedure;
                    //    con.Open();
                    //    dr = cmd.ExecuteReader();
                    //    dt.Load(dr);    
                    //    con.Close();    
                    //}
                    con.Open();
                    var cmd = new SqlCommand("proselect", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Product pro = new Product();
                        pro.pid = Convert.ToInt32(rdr["id"]);
                        pro.pname = rdr["pname"].ToString();
                        pro.descriptions = rdr["descriptions"].ToString();
                        pro.oprice = Convert.ToDecimal(rdr["oprice"]);
                        pro.cprice = Convert.ToDecimal(rdr["cprice"]);
                        pro.proimg = rdr["proimg"].ToString();

                        //pro.features =  _feature.GetFeature(pro.pid);

                        productsList.Add(pro);
                    }
                    con.Close();

                }
                return productsList.ToList();
            }
            catch (Exception)
            {

                throw;
            }
            //return dt;
        }
        public Product GetProductRecord(int id)
        {
         //   DataTable dt= new DataTable();
            try
            {
                SqlDataReader dr;
                using (SqlConnection con=new SqlConnection(Constr))
                {
                    Product pro = new Product();
                    var cmd = new SqlCommand("progetselect", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    pro.pid = Convert.ToInt32(dr["id"]);
                    pro.pname = dr["pname"].ToString();
                    pro.descriptions = dr["descriptions"].ToString();
                    pro.oprice = Convert.ToDecimal(dr["oprice"]);
                    pro.cprice = Convert.ToDecimal(dr["cprice"]);
                    pro.proimg = dr["proimg"].ToString();
                    //pro.features = _feature.GetFeature(pro.pid);



                    return pro;
                    
                
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public string GetProductDelete(int id)
        {
            string msg = "";
            try
            {
                using (SqlConnection con=new SqlConnection(Constr))
                {
                    var cmd = new SqlCommand("proDelete", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    msg = "Succesfully deleted";
                    con.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return msg;
        }
        public string GetproductUpdate(Product pro)
        {
            string msg = "";
            try
            {
                using (SqlConnection con = new SqlConnection(Constr))
                {
                    var cmd = new SqlCommand("proUpdate", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", pro.pid);
                    cmd.Parameters.AddWithValue("@pname", pro.pname);
                    cmd.Parameters.AddWithValue("@description", pro.descriptions);
                    cmd.Parameters.AddWithValue("@oprice", pro.oprice);
                    cmd.Parameters.AddWithValue("@cprice", pro.cprice);
                    cmd.Parameters.AddWithValue("@proimg", pro.proimg);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    msg = "updated sucessful";
                    con.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return msg;

        }
        public string GetproductInsert(Product pro)
        {
            string msg = "";
            try
            {
                using (SqlConnection con = new SqlConnection(Constr))
                {
                    var cmd = new SqlCommand("proInsert", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pname", pro.pname);
                    cmd.Parameters.AddWithValue("@description", pro.descriptions);
                    cmd.Parameters.AddWithValue("@oprice", pro.oprice);
                    cmd.Parameters.AddWithValue("@cprice", pro.cprice);
                    cmd.Parameters.AddWithValue("@proimg", pro.proimg);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    //var cmd2 = new SqlCommand("Select id from Product where pname=@pname",con);
                    //cmd2.CommandType = CommandType.Text;


                    
                    msg = "Inserted Sucessfully";
                    con.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return msg;

        }
    }

    
    }

