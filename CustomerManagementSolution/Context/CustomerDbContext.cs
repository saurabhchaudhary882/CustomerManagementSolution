using CustomerManagementAPI.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagementAPI.Context
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
