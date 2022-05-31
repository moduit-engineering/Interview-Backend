using System;
using System.Collections.Generic;

namespace Moduit.Interview.Responses
{
    public class ResponseQ3
    {
        public int id { get; set; }
        public int category { get; set; }
        public List<Item> items { get; set; }
        public DateTime createdAt { get; set; }
        public List<string> tags { get; set; }

        public class Item
        {
            public string title { get; set; }
            public string description { get; set; }
            public string footer { get; set; }
        }
    }

    public class FlatList
    {
        public int id { get; set; }
        public int category { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string footer { get; set; }
        public DateTime createdAt { get; set; }
        public List<string> tags { get; set; }
    }
}