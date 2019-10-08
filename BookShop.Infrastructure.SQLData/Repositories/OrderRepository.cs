using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BookShop.Core.DomainService;
using BookShop.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Infrastructure.SQLData.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        readonly BookShopAppContext _context;

        public OrderRepository(BookShopAppContext ctx)
        {
            _context = ctx;
        }

        public Order CreateOrder(Order order)
        {
            _context.Attach(order).State = EntityState.Added;
            _context.SaveChanges();
            return order;
        }

        public Order Delete(Order order)
        {
            _context.Orders.Remove(order);
            _context.SaveChanges();
            return null;
        }

        public IEnumerable<Order> GetOrders(Filter filter)
        {
            var orderBy = filter.OrderBy;
            var sortBy = filter.SortBy;

            if (filter.ItemsPrPage <= 0 || filter.CurrentPage <= 0) return _context.Orders;
            
            if (sortBy != null)
            {
                var propertyInfo = typeof(Book).GetProperty(filter.SortBy, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                if(orderBy == "asc" || orderBy == null)
                {
                    return _context.Orders.OrderBy(x => propertyInfo.GetValue(x,
                            null))
                        .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                        .Take(filter.ItemsPrPage);
                }
                if(orderBy == "desc"){
                    return _context.Orders.OrderByDescending(x => propertyInfo.GetValue(x,
                            null))
                        .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                        .Take(filter.ItemsPrPage);
                }
            }
            
            if(orderBy == "asc" || orderBy == null)
            {
                return _context.Orders.OrderBy(o => o.OrderId).Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                    .Take(filter.ItemsPrPage);
            }
            
            if(orderBy == "desc"){
                return _context.Orders.OrderByDescending(o => o.OrderId).Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                    .Take(filter.ItemsPrPage);
            }

            return _context.Orders;
        }

        public Order GetOrderByID(int id)
        {
            return _context.Orders.FirstOrDefault(o => o.OrderId == id);
        }

        public Order Update(Order orderUpdate)
        {
            _context.Attach(orderUpdate).State = EntityState.Modified;
            _context.SaveChanges();
            return orderUpdate;
        }

    
    }
}