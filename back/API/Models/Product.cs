namespace API.Models
{
    public class Product
    {
        public int pid { get; set; }
        public string? pname { get; set; }
       // public Category? category { get; set; }
        public string? descriptions { get; set; }
        public decimal oprice { get; set; }
        public decimal cprice { get; set; }
        public string? proimg { get; set; }

        //public List<Feature>? features { get; set; }

    }
}
