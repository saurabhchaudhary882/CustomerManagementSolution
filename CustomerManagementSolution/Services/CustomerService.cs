using CustomerManagementAPI.Context;
using CustomerManagementAPI.Interfaces;
using CustomerManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CustomerManagementAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerDbContext _context;
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(CustomerDbContext context, ILogger<CustomerService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            try
            {
                return await _context.Customers.ToListAsync();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error fetching customers from the database");
                throw new Exception("An error occurred while retrieving customers. Please try again later.");
            }
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            try
            {
                var customer = await _context.Customers.FindAsync(id);
                if (customer == null)
                {
                    throw new KeyNotFoundException($"Customer with ID {id} not found.");
                }
                return customer;
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "Customer not found");
                throw;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error fetching customer from the database");
                throw new Exception("An error occurred while retrieving the customer. Please try again.");
            }
        }

        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            try
            {
                customer.CreatedAt = DateTime.UtcNow;
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
                return customer;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error adding customer to the database");
                throw new Exception("An error occurred while adding the customer. Please try again.");
            }
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            try
            {
                customer.UpdatedAt = DateTime.UtcNow;
                _context.Entry(customer).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return customer;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError(ex, "Concurrency error updating customer");
                throw new Exception("Another user has modified this customer. Please refresh and try again.");
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error updating customer in the database");
                throw new Exception("An error occurred while updating the customer. Please try again.");
            }
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            try
            {
                var customer = await _context.Customers.FindAsync(id);
                if (customer == null) return false;

                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Error deleting customer from the database");
                throw new Exception("An error occurred while deleting the customer. Please try again.");
            }
        }
    }
}
