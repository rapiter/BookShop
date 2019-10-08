using BookShop.Core.DomainService;
using BookShop.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookShop.Infrastructure.SQLData.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        readonly BookShopAppContext context;

        public CustomerRepository(BookShopAppContext ctx)
        {
            context = ctx;
        }
        public Customer CreateCustomer(Customer customer)
        {
            context.Attach(customer).State = EntityState.Added;
            context.SaveChanges();
            return customer;
        }

       

        public Customer Delete(Customer customer)
        {
            context.Customers.Remove(customer);
            context.SaveChanges();
            return null;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return context.Customers;
        }

        public Customer GetCustomerByID(int Id)
        {
            return context.Customers.FirstOrDefault(c => c.ID == Id);
        }

        public Customer Update(Customer customerUpdate)
        {
            context.Attach(customerUpdate).State = EntityState.Modified;
            context.SaveChanges();
            return customerUpdate;
        }
    }
}