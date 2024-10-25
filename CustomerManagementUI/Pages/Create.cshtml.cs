using CustomerManagementUI.Models;
using CustomerManagementUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CustomerManagementUI.Pages
{
    public class CreateModel : PageModel
    {
        private readonly CustomerService _customerService;
        private readonly ILogger<CreateModel> _logger;

        [BindProperty]
        public Customer Customer { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ErrorMessage { get; set; }

        public CreateModel(CustomerService customerService, ILogger<CreateModel> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                await _customerService.AddCustomerAsync(Customer);
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error while creating a customer.");
                ErrorMessage = $"{ex.Message}";
                return Page();
            }
        }
    }
}
