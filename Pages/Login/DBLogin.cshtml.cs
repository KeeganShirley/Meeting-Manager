using Meeting_Manager.Pages.DataClasses;
using Meeting_Manager.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Meeting_Manager.Pages.Login
{
    public class DBLoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            string loginQuery = "SELECT COUNT(*) FROM Credentials where Username = '";
            loginQuery += Username + "' and Password='" + Password + "'";

            if (DBClass.LoginQuery(loginQuery) > 0)
            {
                HttpContext.Session.SetString("username", Username);
                ViewData["LoginMessage"] = "Login Successful!";
                DBClass.MeetingManagerDBConnection.Close();
                return RedirectToPage("/Profile/Student_Profile");


            }
            else
            {
                ViewData["LoginMessage"] = "Username and/or Password Incorrect";

            }

            DBClass.MeetingManagerDBConnection.Close();

            return Page();

        }
    }
}