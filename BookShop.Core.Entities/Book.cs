using System;

namespace BookShop.Core.Entities
{
    public class Book
    {
        public String Title { get; set; }
        public Genre Genre { get; set; }
        public Author Author { get; set; }
        public String Description { get; set; }
        public String Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int BookID { get; set; }
        public int Pages { get; set; }
        public String Language { get; set; }
        public double Rating { get; set; }
        public String AgeRange { get; set; }
        
    }
}

