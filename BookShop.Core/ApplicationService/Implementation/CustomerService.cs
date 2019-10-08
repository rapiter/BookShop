using System.Collections.Generic;
using BookShop.Core.DomainService;
using BookShop.Core.Entities;

namespace BookShop.Core.ApplicationService.Implementation
{
    
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        
        public Customer CreateCustomer(Customer customer)
        {
            return _customerRepository.CreateCustomer(customer);
        }

        public Customer CreateNewCustomer(string firstName, string lastName)
        {
            var c = new Customer()
            {
                FirstName = firstName,
                SurnameName = lastName
            };
            return c;
        }

        public Customer Delete(Customer customer)
        {
            return _customerRepository.Delete(customer);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _customerRepository.GetCustomers();
        }

        public Customer GetCustomerByID(int id)
        {
            return _customerRepository.GetCustomerByID(id);
        }

        public Customer Update(Customer customerUpdate)
        {
            return _customerRepository.Update(customerUpdate);
        }
    }
}