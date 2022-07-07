using API.Models;
using System.Data;
using System.Data.SqlClient;

namespace API.Interface
{
    public class FeatureRepo : IFeature
    {
        public IConfiguration _configuration;
      
        public SqlConnection con;
        public string Constr { get; set; }

        public FeatureRepo(IConfiguration configuration  )
        {
            _configuration = configuration;
            Constr = _configuration.GetConnectionString("DBConnection");
          
        }

        public List<Feature> GetFeature(int PId)

        {
            List<Feature> featureList = new List<Feature>();


            try
            {

                using (con = new SqlConnection(Constr))
                {

                    con.Open();
                    var cmd = new SqlCommand("getFeature", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pid", PId);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Feature fea = new Feature();
                   
                        fea.Id = Convert.ToInt32(rdr["id"]);
                        fea.Pid = Convert.ToInt32(rdr["pid"]);
                        fea.FeatureName = rdr["features"].ToString();
                        featureList.Add(fea);
                    }
                }
                return featureList.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string FeatureInsert(List<Feature> features , SqlConnection con, int Pid )
        {
            string msg = "";
            try
            {
                foreach (Feature fea in features)
                {
                       var cmd = new SqlCommand("featureInsert", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pid", Pid);
                        cmd.Parameters.AddWithValue("@features", fea.FeatureName);
                        cmd.ExecuteNonQuery();
                        msg = "Inserted Sucessfully";
                    
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
