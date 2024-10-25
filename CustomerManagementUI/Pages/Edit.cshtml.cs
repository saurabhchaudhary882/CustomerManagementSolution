using CustomerManagementUI.Models;
using CustomerManagementUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CustomerManagementUI.Pages
{
    public class EditModel : PageModel
    {
        private readonly CustomerService _customerService;

        [BindProperty]
        public Customer Customer { get; set; }

        public EditModel(CustomerService customerService)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _customerService.UpdateCustomerAsync(Customer.Id, Customer);
            return RedirectToPage("./Index");
        }
    }
}
