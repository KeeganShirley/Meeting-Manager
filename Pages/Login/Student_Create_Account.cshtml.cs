using Meeting_Manager.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Meeting_Manager.Pages.Login
{
    public class Student_Create_AccountModel : PageModel
    {
		[BindProperty]
		public string Username { get; set; }
		[BindProperty]
		public string Password { get; set; }
		[BindProperty]
		public int StudentID { get; set; }


		public void OnGet()
        {


        }

		public IActionResult OnPost()
		{
            DBClass.CreateStudentAccount(StudentID, Username, Password);

            return RedirectToPage("DBLogin");
        }

		
		
	}
}
