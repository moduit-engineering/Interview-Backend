namespace MyWebAPI.Models
{
    public class response3
    {
        public int id { get; set; }
        public int category { get; set; }
        public List<item> items { get; set; }
        public List<string> tags { get; set; }
        public DateTime createdAt { get; set; }      
    }

    public class item
    {
        public int id { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public string? footer { get; set; }
    }

    public class flatten
    {
        public int id { get; set; }
        public int category { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public string? footer { get; set; }
        public DateTime createdAt { get; set; }
    }
}
