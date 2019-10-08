using System.Collections.Generic;
using System.Linq;
using BookShop.Core.DomainService;
using BookShop.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Infrastructure.SQLData.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        readonly BookShopAppContext context;

        public OrderRepository(BookShopAppContext ctx)
        {
            context = ctx;
        }

        public Order CreateOrder(Order Order)
        {
            context.Attach(Order).State = EntityState.Added;
            context.SaveChanges();
            return Order;
        }

        public Order Delete(Order Order)
        {
            context.Orders.Remove(Order);
            context.SaveChanges();
            return null;
        }

        public IEnumerable<Order> GetOrders()
        {
            return context.Orders;
        }

        public Order GetOrderByID(int Id)
        {
            return context.Orders.FirstOrDefault(o => o.OrderId == Id);
        }

        public Order Update(Order OrderUpdate)
        {
            context.Attach(OrderUpdate).State = EntityState.Modified;
            context.SaveChanges();
            return OrderUpdate;
        }

    
    }
}