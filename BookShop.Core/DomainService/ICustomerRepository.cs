using BookShop.Core.Entities;
using System;
using System.Collections.Generic;

namespace BookShop.Core.DomainService
{
    public interface ICustomerRepository
    {
        Customer CreateCustomer(Customer customer);
        Customer Delete(Customer customer);
        Customer Update(Customer customerUpdate);
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomerByID(int Id);
    }
}