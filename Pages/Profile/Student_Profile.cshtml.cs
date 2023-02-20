using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using Meeting_Manager.Pages.DataClasses;
using Meeting_Manager.Pages.DB;

namespace Meeting_Manager.Pages.Profile
{

    public class Student_ProfileModel : PageModel
    {



        public List<StudentProfile> StudentList { get; set; }

        // Constructor
        public Student_ProfileModel()
        {
            StudentList = new List<StudentProfile>();

        }

        //Gets the student data and displays it
        public IActionResult OnGet()
        {
            SqlDataReader studentReader = DBClass.Reader();

            while (studentReader.Read())
            {
                StudentList.Add(new StudentProfile
                {
                StudentID = Int32.Parse(studentReader["StudentID"].ToString()),
                StudentFName = studentReader["StudentFName"].ToString(),
                StudentLName = studentReader["StudentLName"].ToString(),
                StuEmail = studentReader["StuEmail"].ToString(),
                StuPhoneNum = studentReader["StuPhoneNum"].ToString(),
                GroupPartnerFirstName = studentReader["GroupPartnerFirstName"].ToString(),
                GroupPartnerLastName = studentReader["GroupPartnerLastName"].ToString(),
                GroupPartnerID = Int32.Parse(studentReader["GroupPartnerID"].ToString())
            });            
            }

            DBClass.MeetingManagerDBConnection.Close();

            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToPage("/Login/DBLogin");
            }
            return Page();
        }
        
        //Redirect to the edit student page
        public IActionResult OnPost()
        {
            return RedirectToPage("EditStudentProfile");
        }



    }
}
