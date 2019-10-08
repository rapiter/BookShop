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
        readonly BookShopAppContext _context;

        public CustomerRepository(BookShopAppContext ctx)
        {
            _context = ctx;
        }
        public Customer CreateCustomer(Customer customer)
        {
            _context.Attach(customer).State = EntityState.Added;
            _context.SaveChanges();
            return customer;
        }

        public Customer Delete(Customer customer)
        {
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return null;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers;
        }

        public Customer GetCustomerByID(int Id)
        {
            return _context.Customers.FirstOrDefault(c => c.ID == Id);
        }

        public Customer Update(Customer customerUpdate)
        {
            _context.Attach(customerUpdate).State = EntityState.Modified;
            _context.SaveChanges();
            return customerUpdate;
        }
    }
}