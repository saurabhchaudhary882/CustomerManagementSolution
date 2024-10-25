using CustomerManagementAPI.Models;

namespace CustomerManagementAPI.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetCustomersAsync(); // Get all Customers
        Task<Customer> GetCustomerByIdAsync(int id); // Fetch customer by id
        Task<Customer> AddCustomerAsync(Customer customer); // Add new customer
        Task<Customer> UpdateCustomerAsync(Customer customer); // Update existing customer
        Task<bool> DeleteCustomerAsync(int id); // Delete customer by id, returns true if successful
    }
}
