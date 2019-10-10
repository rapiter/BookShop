using System.Collections.Generic;
using BookShop.Core.DomainService;
using BookShop.Core.Entities;

namespace BookShop.Core.ApplicationService.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
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
            return _orderRepository.CreateOrder(order);
        }

        public Order Delete(Order order)
        {
            return _orderRepository.Delete(order);
        }

        public IEnumerable<Order> GetOrders()
        {
            return _orderRepository.GetOrders();
        }

        public Order GetOrderByID(int id)
        {
            return _orderRepository.GetOrderByID(id);
        }

        public IEnumerable<Order> GetFilteredOrders(Filter filter)
        {
            return _orderRepository.GetOrders(filter);
        }

        public Order Update(Order orderUpdate)
        {
            return _orderRepository.Update(orderUpdate);
        }
    }
}