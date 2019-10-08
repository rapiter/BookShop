using System.Collections.Generic;
using System.Linq;
using BookShop.Core.ApplicationService;
using BookShop.Core.ApplicationService.Implementation;
using BookShop.Core.Entities;
using BookShop.Infrastructure.SQLData.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookShopRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Order>> Get()
        {
            return _orderService.GetOrders().ToList();
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            return _orderService.GetOrderByID(id);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Order> Post([FromBody] Order order)
        {
            return _orderService.CreateOrder(order);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Order> Put(int id, [FromBody] Order order)
        {
            if (id < 1 || id != order.OrderId)
            {
                return BadRequest("Parameter ID and Order ID must be the same.");
            }
            Ok("Order was successfully updated.");
            return _orderService.Update(order);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<Order> Delete(int id)
        {
            Order o = _orderService.GetOrderByID(id);

            if (null == o)
                return BadRequest("There is no Order with this ID.");
            else
            {
                _orderService.Delete(o);
                return Ok("Order deleted");
            }
        }
    }

}