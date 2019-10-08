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
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            return _customerService.GetCustomers().ToList();
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            return _customerService.GetCustomerByID(id);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Customer> Post([FromBody] Customer customer)
        {
            return _customerService.CreateCustomer(customer);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Customer> Put(int id, [FromBody] Customer customer)
        {
            if (id < 1 || id != customer.ID)
            {
                return BadRequest("Parameter ID and customer ID must be the same.");
            }
            Ok("Customer was successfully updated.");
            return _customerService.Update(customer);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<Customer> Delete(int id)
        {
            Customer c = _customerService.GetCustomerByID(id);

            if (null == c)
                return BadRequest("There is no customer with this ID.");
            else
            {
                _customerService.Delete(c);
                return Ok("Customer deleted");
            }
        }
    }

}