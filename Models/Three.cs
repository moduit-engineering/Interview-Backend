using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlsAPI.Models
{
    public class Three
    {
        public long id { get; set; }
        public string category { get; set; }
        public string items { get; set; }
        public DateTime createdAt { get; set; }
    }

    public partial class itemsData
    {
        public string title { get; set; }
        public string description { get; set; }
        public string footer { get; set; }
    }

    public partial class itemsOut
    {
        public long id { get; set; }
        public int category { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string footer { get; set; }
        public DateTime createdAt { get; set; }
    }
}
