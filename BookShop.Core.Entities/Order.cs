using System.Collections.Generic;

namespace BookShop.Core.Entities
{
    public class Order
    {
        public int OrderId  { get; set; }
        public int CustomerId { get; set; }
        public List<Book> Products { get; set; }
        
    }
}