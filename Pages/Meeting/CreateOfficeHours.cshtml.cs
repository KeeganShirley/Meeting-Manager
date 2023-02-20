using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Meeting_Manager.Pages.Meeting
{
    public class CreateOfficeHoursModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }
    }
}
