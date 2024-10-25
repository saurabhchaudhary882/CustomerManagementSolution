using CustomerManagementUI.Models;
using CustomerManagementUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CustomerManagementUI.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly CustomerService _customerService;

        [BindProperty]
        public Customer Customer { get; set; }

        public DeleteModel(CustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Customer = await _customerService.GetCustomerByIdAsync(id);

            if (Customer == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _customerService.DeleteCustomerAsync(id);
            return RedirectToPage("./Index");
        }
    }
}
