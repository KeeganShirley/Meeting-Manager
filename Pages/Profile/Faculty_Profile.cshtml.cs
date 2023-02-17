using Meeting_Manager.Pages.DataClasses;
using Meeting_Manager.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Meeting_Manager.Pages.Profile
{
    public class Faculty_ProfileModel : PageModel
    {
        public List<FacultyProfile> FacultyList { get; set; }

        // Constructor
        public Faculty_ProfileModel() 
        {
            FacultyList = new List<FacultyProfile>();
        }

        //Gets the faculty data and displays it
        public void OnGet()
        {
            SqlDataReader facultyReader = DBClass.SingleFacultyReader(1);

            while (facultyReader.Read())
            {
                FacultyList.Add(new FacultyProfile
                {
                    FacultyID = Int32.Parse(facultyReader["FacultyID"].ToString()),
                    FacultyFName = facultyReader["FacultyFName"].ToString(),
                    FacultyLName = facultyReader["FacultyLName"].ToString(),
                    FacultyEmail = facultyReader["FacultyEmail"].ToString(),
                    OfficePhoneNum = facultyReader["OfficePhoneNum"].ToString(),
                    OfficeLocation = facultyReader["OfficeLoc"].ToString(),
                    Availability = facultyReader["Availability"].ToString(),
                    Class1 = facultyReader["Class1"].ToString(),
                    Class2 = facultyReader["Class2"].ToString(),
                    Class3 = facultyReader["Class3"].ToString(),
                    Class4 = facultyReader["Class4"].ToString(),
                    Class5 = facultyReader["Class5"].ToString()

                }) ;

                }
            DBClass.MeetingManagerDBConnection.Close();
        }
        
        
        
        
        }
    }

