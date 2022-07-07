using System.Data;
using System.Data.SqlClient;
namespace WebApplication1.Model
{
    public class DataLayer
    {
        public static string sqlDataSource = "Data Source=DESKTOP-UOESOKN\\SQLEXPRESS;Initial Catalog=demo;Trusted_Connection=true";
        public DataTable GetProductsRecord()
        {
            DataTable dt = new DataTable();

            try
            {
                SqlDataReader dr;

                using (SqlConnection con = new SqlConnection(sqlDataSource))
                {
                    using (SqlCommand cmd = new SqlCommand("proselect", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        dr = cmd.ExecuteReader();
                        dt.Load(dr);
                        con.Close();
                    }
                  

                }
            }
            catch (Exception ex)
            {

                ex.ToString();
            }
            return dt;
        }
        public DataTable GetProductRecord(string id)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataReader dr;
                using (SqlConnection con = new SqlConnection(sqlDataSource))
                {
                    var cmd = new SqlCommand("progetselect", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id.ToString());
                    con.Open();
                    dr = cmd.ExecuteReader();
                    dt.Load(dr);
                    con.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }
        public DataTable GetProductDelete(string id)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(sqlDataSource))
                {
                    var cmd = new SqlCommand("proDelete", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id.ToString());
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }
        public DataTable GetproductUpdate(string id, string pname, string category, string description, string oprice, string cprice, string proimg)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(sqlDataSource))
                {
                    var cmd = new SqlCommand("proUpdate", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id.ToString());
                    cmd.Parameters.AddWithValue("@panme", pname.ToString());
                    cmd.Parameters.AddWithValue("@category", category.ToString());
                    cmd.Parameters.AddWithValue("@description", description.ToString());
                    cmd.Parameters.AddWithValue("@oprice", oprice.ToString());
                    cmd.Parameters.AddWithValue("@cprice", cprice.ToString());
                    cmd.Parameters.AddWithValue("@proimg", proimg.ToString());
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return dt;

        }
        public DataTable GetproductInsert(string pname, string category, string description, string oprice, string cprice, string proimg)
        {
            DataTable dt = new DataTable();
            try

            { 
             using (SqlConnection con = new SqlConnection(sqlDataSource))
            {
                var cmd = new SqlCommand("proInsert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@panme", pname.ToString());
                cmd.Parameters.AddWithValue("@category", category.ToString());
                cmd.Parameters.AddWithValue("@description", description.ToString());
                cmd.Parameters.AddWithValue("@oprice", oprice.ToString());
                cmd.Parameters.AddWithValue("@cprice", cprice.ToString());
                cmd.Parameters.AddWithValue("@proimg", proimg.ToString());
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            }
            catch (Exception)
            {

                throw;
            }
            return dt;

        }

    }
}
