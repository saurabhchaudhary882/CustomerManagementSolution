using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using CustomerManagementUI.Models;

namespace CustomerManagementUI.Services
{
    public class CustomerService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(HttpClient httpClient, ILogger<CustomerService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<IEnumerable<Customer>>("api/customer");
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Error occurred while fetching customers from the API.");
                throw new Exception("An error occurred while fetching customers. Please try again later.");
            }
            catch (NotSupportedException ex)
            {
                _logger.LogError(ex, "Unsupported content type received from the API.");
                throw new Exception("The server returned data in an unsupported format.");
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "Error parsing JSON response from the API.");
                throw new Exception("An error occurred while processing server response.");
            }
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Customer>($"api/customer/{id}");
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, $"Error fetching customer with ID {id} from the API.");
                throw new Exception($"Unable to retrieve customer with ID {id}. Please try again later.");
            }
            catch (NotSupportedException ex)
            {
                _logger.LogError(ex, $"Unsupported content type received while fetching customer with ID {id}.");
                throw new Exception("The server returned data in an unsupported format.");
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, $"Error parsing JSON response while fetching customer with ID {id}.");
                throw new Exception("An error occurred while processing server response.");
            }
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/customer", customer);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Error adding customer to the API.");
                throw new Exception("There was an error adding the customer. Please try again.");
            }
            catch (NotSupportedException ex)
            {
                _logger.LogError(ex, "Unsupported content type received while adding customer.");
                throw new Exception("The server returned data in an unsupported format.");
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "Error parsing JSON response after adding customer.");
                throw new Exception("An error occurred while processing server response.");
            }
        }

        public async Task UpdateCustomerAsync(int id, Customer customer)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/customer/{id}", customer);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, $"Error updating customer with ID {id} in the API.");
                throw new Exception($"Unable to update customer with ID {id}. Please try again.");
            }
            catch (NotSupportedException ex)
            {
                _logger.LogError(ex, $"Unsupported content type received while updating customer with ID {id}.");
                throw new Exception("The server returned data in an unsupported format.");
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, $"Error parsing JSON response while updating customer with ID {id}.");
                throw new Exception("An error occurred while processing server response.");
            }
        }

        public async Task DeleteCustomerAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/customer/{id}");
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, $"Error deleting customer with ID {id} from the API.");
                throw new Exception($"Unable to delete customer with ID {id}. Please try again.");
            }
            catch (NotSupportedException ex)
            {
                _logger.LogError(ex, $"Unsupported content type received while deleting customer with ID {id}.");
                throw new Exception("The server returned data in an unsupported format.");
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, $"Error parsing JSON response while deleting customer with ID {id}.");
                throw new Exception("An error occurred while processing server response.");
            }
        }
    }
}