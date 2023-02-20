using Meeting_Manager.Pages.DataClasses;
using Meeting_Manager.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Meeting_Manager.Pages.Login
{
    public class DBLoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }


        [BindProperty]
        public int StudentID { get; set; }
        [BindProperty]
        public int FacultyID { get; set; }


        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            string typeQuery = "SELECT * FROM CREDENTIALS where Username = '";
            typeQuery += Username + "' and Password='" + Password + "'";

            SqlDataReader UserType = DBClass.UserType(typeQuery);

            while (UserType.Read()) 
            {
                if (UserType["StudentID"] != DBNull.Value)
                {
                    StudentID = (int)UserType["StudentID"];
                }
                if (UserType["FacultyID"] != DBNull.Value)
                {
                    FacultyID = (int)UserType["FacultyID"];
                }
            };

            DBClass.MeetingManagerDBConnection.Close();



            string loginQuery = "SELECT COUNT(*) FROM Credentials where Username = '";
            loginQuery += Username + "' and Password='" + Password + "'";

            if (DBClass.LoginQuery(loginQuery) > 0)
            {
                if (StudentID != 0)
                {

                    HttpContext.Session.SetString("username", Username);
                    ViewData["LoginMessage"] = "Login Successful!";
                    DBClass.MeetingManagerDBConnection.Close();
                    HttpContext.Session.SetInt32("studentID", StudentID);
                    return RedirectToPage("/Profile/Student_Profile");

                }

                if (FacultyID != 0)
                {
                    HttpContext.Session.SetString("username", Username);
                    ViewData["LoginMessage"] = "Login Successful!";
                    DBClass.MeetingManagerDBConnection.Close();
                    HttpContext.Session.SetInt32("facultyID", FacultyID);
                    return RedirectToPage("/Profile/Faculty_Profile");
                }

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