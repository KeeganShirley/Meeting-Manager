
using Meeting_Manager.Pages.DataClasses;
using Meeting_Manager.Pages.DB;
using Meeting_Manager.Pages.Profile;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Meeting_Manager.Pages.Login
{
    public class HashedLoginModel : PageModel
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

        private readonly IHttpContextAccessor _httpContextAccessor;
        public HashedLoginModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }




        //public IActionResult OnPost(int? studentID = null)
        //{
        //    int? facultyID = null;

        //    if (studentID.HasValue)
        //    {
        //        if (DBClass.HashedStudentParameterLogin(Username, Password, out int id))
        //        {
        //            studentID = id;
        //        }
        //    }
        //    else
        //    {
        //        if (DBClass.HashedFacultyParameterLogin(Username, Password, out int id))
        //        {
        //            facultyID = id;
        //        }
        //    }

        //    if (studentID.HasValue)
        //    {
        //        _httpContextAccessor.HttpContext.Session.SetInt32("studentID", studentID.Value);
        //        _httpContextAccessor.HttpContext.Session.SetString("username", Username);
        //        ViewData["LoginMessage"] = "Login Successful!";
        //        DBClass.MeetingManagerDBConnection.Close();
        //        return RedirectToPage("/Profile/Student_Profile");
        //    }
        //    else if (facultyID.HasValue)
        //    {
        //        _httpContextAccessor.HttpContext.Session.SetInt32("facultyID", facultyID.Value);
        //        _httpContextAccessor.HttpContext.Session.SetString("username", Username);
        //        ViewData["LoginMessage"] = "Login Successful!";
        //        DBClass.MeetingManagerDBConnection.Close();
        //        return RedirectToPage("/Profile/Faculty_Profile");
        //    }
        //    else
        //    {
        //        ViewData["LoginMessage"] = "Username and/or Password Incorrect";
        //        DBClass.MeetingManagerDBConnection.Close();
        //        return Page();
        //    }
        //}

        public IActionResult OnPost()
        {
            //if (int.TryParse(HttpContext.Session.GetString("studentID"), out int studentID) && studentID != 0)
            //{
            //    return RedirectToPage("/Profile/Student_Profile");
            //}
            if(DBClass.HashedParameterLogin(Username, Password, out int studentID, out int facultyID))
            {
                if(studentID != 0)
                {
                    _httpContextAccessor.HttpContext.Session.SetInt32("studentID", studentID);
                    _httpContextAccessor.HttpContext.Session.SetString("username", Username);
                    ViewData["LoginMessage"] = "Login Successful!";
                    DBClass.MeetingManagerDBConnection.Close();
                    return RedirectToPage("/Profile/Student_Profile");
                }
                else { 
                _httpContextAccessor.HttpContext.Session.SetInt32("facultyID", facultyID);
                _httpContextAccessor.HttpContext.Session.SetString("username", Username);
                ViewData["LoginMessage"] = "Login Successful!";
                DBClass.MeetingManagerDBConnection.Close();
                return RedirectToPage("/Profile/Faculty_Profile");
                }
            }

            //else if (DBClass.HashedFacultyParameterLogin(Username, Password, out int facultyID))
            //{
            //    _httpContextAccessor.HttpContext.Session.SetInt32("facultyID", facultyID);
            //    _httpContextAccessor.HttpContext.Session.SetString("username", Username);
            //    ViewData["LoginMessage"] = "Login Successful!";
            //    DBClass.MeetingManagerDBConnection.Close();
            //    return RedirectToPage("/Profile/Faculty_Profile");
            //}
            //else if (DBClass.HashedStudentParameterLogin(Username, Password, out studentID))
            //{
            //    _httpContextAccessor.HttpContext.Session.SetInt32("studentID", studentID);
            //    _httpContextAccessor.HttpContext.Session.SetString("username", Username);
            //    ViewData["LoginMessage"] = "Login Successful!";
            //    DBClass.MeetingManagerDBConnection.Close();
            //    return RedirectToPage("/Profile/Student_Profile");
            //}
            else
            {
                ViewData["LoginMessage"] = "Username and/or Password Incorrect";
                DBClass.MeetingManagerDBConnection.Close();
                return Page();
            }
        }




    }
}