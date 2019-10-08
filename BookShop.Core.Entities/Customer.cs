using System;
using System.Collections.Generic;

namespace BookShop.Core.Entities
{
    public class Customer
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string SurnameName { get; set; }
        
        public List<Order> Orders { get; set; }
    }
}