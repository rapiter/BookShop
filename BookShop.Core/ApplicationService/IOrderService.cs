using System;
   using System.Collections.Generic;
   using BookShop.Core.Entities;
   
   namespace BookShop.Core.ApplicationService
   {
       public interface IOrderService
       {
           Order CreateNewOrder(int CustomerId,List<Book> Books);
           Order CreateOrder(Order Order);
           Order Delete(Order Order);
           Order Update(Order OrderUpdate);
        IEnumerable<Order> GetOrders();
           Order GetOrderByID(int Id);
           
           IEnumerable<Order> GetFilteredOrders(Filter filter);

       }
   }