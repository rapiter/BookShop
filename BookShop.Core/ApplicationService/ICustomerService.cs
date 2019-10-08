using System;
using System.Collections.Generic;
using BookShop.Core.Entities;

namespace BookShop.Core.ApplicationService
{
    public interface ICustomerService
    {
        Customer CreateNewCustomer(String firstName, String lastName);
        Customer CreateCustomer(Customer customer);
        Customer Delete(Customer customer);
        Customer Update(Customer customerUpdate);
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomerByID(int Id);
    }
}