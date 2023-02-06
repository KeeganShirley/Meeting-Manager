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

        public void OnGet()
        {
            SqlDataReader studentReader = DB.DBClass.Reader();

            while (studentReader.Read())
            {
                StudentList.Add(new StudentProfile
                {
                StudentID = Int32.Parse(studentReader["StudentID"].ToString()),
                StudentFName = studentReader["StudentFName"].ToString(),
                StudentLName = studentReader["StudentLName"].ToString(),
                GroupPartnerFirstName = studentReader["GroupPartnerFirstName"].ToString(),
                GroupPartnerLastName = studentReader["GroupPartnerLastName"].ToString()

            });            
            }

            DBClass.MeetingManagerDBConnection.Close();
        }




    }
}
