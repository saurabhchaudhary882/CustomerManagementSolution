using CustomerManagementUI.Models;
using CustomerManagementUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CustomerManagementUI.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly CustomerService _customerService;
        private readonly ILogger<DetailsModel> _logger;

        public Customer Customer { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ErrorMessage { get; set; }

        public DetailsModel(CustomerService customerService, ILogger<DetailsModel> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            try
            {
                if (id <= 0)
                {
                    ErrorMessage = "Invalid customer ID.";
                    return Page();
                }

                Customer = await _customerService.GetCustomerByIdAsync(id);

                if (Customer == null)
                {
                    ErrorMessage = "Customer not found.";
                    return Page();
                }

                return Page();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching customer details.");
                ErrorMessage = $"{ex.Message}";
                return Page();
            }
        }
    }
}