using BookShop.Core.Entities;
using System.Collections.Generic;

namespace BookShop.Core.DomainService
{
    public interface IOrderRepository
    {
         Order CreateOrder(Order Order);
        Order Delete(Order Order);
        Order Update(Order OrderUpdate);
        IEnumerable<Order> GetOrders(Filter filter = null);
        Order GetOrderByID(int Id);
    }
}