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
        
        //Associaton to Book(s)
        public virtual ICollection<BookAuthor> AuthorBooks { get; set; }
    }
}