using Meeting_Manager.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Meeting_Manager.Pages.Meeting
{
    public class Student_MeetingModel : PageModel
    {
        //Putting the faculty name into a class for info used later
        public class FacultyName
        {
            public string FacultyFName { get; set; }
            public string FacultyLName { get; set; }
            public string FacultyID { get; set; }
        }

        //Creating a list of the faculty names to be displayed in the dropdown menu
        public List<FacultyName> FacultyList { get; set; }

        public string SelectedFacultyID { get; set; }

        public FacultyName SelectedFacutly { get; set; }


        //Constructor
        public Student_MeetingModel()
        {
            FacultyList = new List<FacultyName>();
        }

        //OnGet is used to read the SQL data 
        public void OnGet()
        {
            SqlDataReader reader = DBClass.facultyReader();

            while (reader.Read())
            {
                FacultyName faculty = new FacultyName();
                faculty.FacultyFName = reader["FacultyFName"].ToString();
                faculty.FacultyLName = reader["FacultyLName"].ToString();
                FacultyList.Add(faculty);
            }
            reader.Close();
        }
    }

}
