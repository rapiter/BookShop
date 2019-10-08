using System.Collections.Generic;
using BookShop.Core.Entities;

namespace BookShop.Core.ApplicationService.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderService _orderService;

        public OrderService(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public Order CreateNewOrder(int customerId, List<Book> books)
        {
            var o = new Order()
            {
                CustomerId = customerId,
                Products = books
            };
            return o;
        }

        public Order CreateOrder(Order order)
        {
            return _orderService.CreateOrder(order);
        }

        public Order Delete(Order order)
        {
            return _orderService.Delete(order);
        }

        public IEnumerable<Order> GetOrders()
        {
            return _orderService.GetOrders();
        }

        public Order GetOrderByID(int id)
        {
            return _orderService.GetOrderByID(id);
        }

        public IEnumerable<Order> GetFilteredOrders(Filter filter)
        {
            return _orderService.GetFilteredOrders(filter);
        }

        public Order Update(Order orderUpdate)
        {
            return _orderService.Update(orderUpdate);
        }
    }
}