using System;
using System.Collections.Generic;

namespace BookShop.Core.Entities
{
    public class Author
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int ID { get; set; }
        public string Description { get; set; }
        public DateTime Birthdate { get; set; }
        
    }
}