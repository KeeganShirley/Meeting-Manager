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
                int studentID, groupPartnerID;

                if (!int.TryParse(studentReader["StudentID"]?.ToString(), out studentID))
                {
                    // Handle the error, e.g. log it or skip the student
                    continue;
                }

                if (!int.TryParse(studentReader["GroupPartnerID"]?.ToString(), out groupPartnerID))
                {
                    // Handle the error, e.g. log it or set groupPartnerID to a default value
                    groupPartnerID = -1;
                }

                StudentList.Add(new StudentProfile
                {
                    StudentID = studentID,
                    StudentFName = studentReader["StudentFName"].ToString(),
                    StudentLName = studentReader["StudentLName"].ToString(),
                    StuEmail = studentReader["StuEmail"].ToString(),
                    StuPhoneNum = studentReader["StuPhoneNum"].ToString(),
                    GroupPartnerFirstName = studentReader["GroupPartnerFirstName"].ToString(),
                    GroupPartnerLastName = studentReader["GroupPartnerLastName"].ToString(),
                    GroupPartnerID = groupPartnerID
                });
            }

            DBClass.MeetingManagerDBConnection.Close();

            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToPage("/Login/HashedLogin");
            }
            return Page();
        }
        
        //Redirect to the edit student page
        public IActionResult OnPost()
        {
            return RedirectToPage("EditStudentProfile");
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }

    }
}
