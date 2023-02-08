using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using Meeting_Manager.Pages.DataClasses;
using Meeting_Manager.Pages.DB;

namespace Meeting_Manager.Pages.Profile
{

    public class Student_ProfileModel : PageModel
    {

        [BindProperty]
        public StudentProfile studentToUpdate { get; set; }


        public List<StudentProfile> StudentList { get; set; }

        // Constructor
        public Student_ProfileModel()
        {
            StudentList = new List<StudentProfile>();
            studentToUpdate = new StudentProfile();
        }

        public void OnGet()
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
                GroupPartnerLastName = studentReader["GroupPartnerLastName"].ToString()

            });            
            }

            DBClass.MeetingManagerDBConnection.Close();
        }

        public IActionResult OnPost()
        {
            DBClass.UpdateStudent(studentToUpdate);
            return RedirectToPage("Student_Profile");
        }


    }
}
