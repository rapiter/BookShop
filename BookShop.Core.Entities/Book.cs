using System;
using System.Collections.Generic;

namespace BookShop.Core.Entities
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public string Description { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Pages { get; set; }
        public double Price { get; set; }
        public string Language { get; set; }
        public double Rating { get; set; }
        public string AgeRange { get; set; }
        
        public List<Author> authors { get; set; }

    }
}

