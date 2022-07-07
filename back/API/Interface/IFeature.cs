using API.Models;
using System.Data.SqlClient;

namespace API.Interface
{
    public interface IFeature
    {
        public List<Feature> GetFeature(int PId);
        public string FeatureInsert(List<Feature> fea, SqlConnection con, int Pid);
    }
}
