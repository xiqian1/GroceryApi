namespace GroceryApi.Models
{
    public class Response
    {
        public int statusCode { get; set; }
        public string statusDescription { get; set; } = null!;
        public List<Grocery>? groceries { get; set; }
        public Grocery? grocery { get; set; }
    }
}
