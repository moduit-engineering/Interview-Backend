using System;

namespace Moduit.Api.Models
{
    public class ResponseOne
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Footer { get; set; }
        public DateTime CreatedAt { get; set; }
        // public string[] Tags { get; set; }
    }
}