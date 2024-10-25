using CustomerManagementUI.Models;
using CustomerManagementUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CustomerManagementUI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly CustomerService _customerService;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(CustomerService customerService, ILogger<IndexModel> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }

        public IEnumerable<Customer> Customers { get; set; } = new List<Customer>();

        [BindProperty(SupportsGet = true)]
        public string ErrorMessage { get; set; }

        public async Task OnGetAsync()
        {
            try
            {
                Customers = await _customerService.GetCustomersAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error.");
                ErrorMessage = $"{ex.Message}";
            }
        }
    }
}