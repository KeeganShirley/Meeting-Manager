
using Meeting_Manager.Pages.DataClasses;
using Meeting_Manager.Pages.DB;
using Meeting_Manager.Pages.Profile;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Meeting_Manager.Pages.Login
{
    public class HashedLoginModel : PageModel
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
            if (DBClass.HashedParameterLogin(Username, Password))
            {
                HttpContext.Session.SetString("username", Username);
                ViewData["LoginMessage"] = "Login Successful!";
                DBClass.MeetingManagerDBConnection.Close();
                return RedirectToPage("/Profile/Student_Profile");



              
       
            }
            else
            {
                ViewData["LoginMessage"] = "Username and/or Password Incorrect";
                DBClass.MeetingManagerDBConnection.Close();
                return Page();
            }

        }
    }
}

//if (StudentID != 0)
//{
//    return RedirectToPage("/Profile/Student_Profile");


//}

//if (FacultyID != 0)
//{
//    return RedirectToPage("/Profile/Faculty_Profile");

//}

//DBClass.MeetingManagerDBConnection.Close();
