using System.Collections.Generic;
using BookShop.Core.Entities;

namespace BookShop.Core.ApplicationService.Implementation
{
    public class OrderService : IOrderService
    {
        public Order CreateNewOrder(int CustomerId, List<Book> Books)
        {
            throw new System.NotImplementedException();
        }

        public Order CreateOrder(Order Order)
        {
            throw new System.NotImplementedException();
        }

        public Order Delete(Order Order)
        {
            throw new System.NotImplementedException();
        }

        public List<Order> GetOrders()
        {
            throw new System.NotImplementedException();
        }

        public Order ReadById(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Order Update(Order OrderUpdate)
        {
            throw new System.NotImplementedException();
        }
    }
}