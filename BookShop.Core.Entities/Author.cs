using System;
using System.Collections.Generic;

namespace BookShop.Core.Entities
{
    public class Author
    {
        public String Firstname { get; set; }
        public String Lastname { get; set; }
        public int AuthorID { get; set; }
        public String Description { get; set; }
        public DateTime Birthdate { get; set; }
        public List<Book> Books { get; set; }
    }
}