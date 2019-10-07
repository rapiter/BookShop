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
        List<Customer> GetAuthors();
        Customer ReadById(int Id);
    }
}