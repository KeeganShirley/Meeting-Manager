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


        public void OnGet()
        {
            SqlDataReader facultyReader = DBClass.facultyReader();

            while (facultyReader.Read())
            {
                FacultyList.Add(new FacultyProfile
                {
                    FacultyID = Int32.Parse(facultyReader["FacultyID"].ToString()),
                    FacultyFName = facultyReader["FacultyFName"].ToString(),
                    FacultyLName = facultyReader["FacultyLName"].ToString(),
                    FacultyEmail = facultyReader["FacultyEmail"].ToString(),
                    OfficePhoneNum = facultyReader["OfficePhoneNum"].ToString(),
                    OfficeLoc = facultyReader["OfficeLoc"].ToString(),
                    FacultyClass1 = facultyReader["FacultyClass1"].ToString(),
                    FacultyClass2 = facultyReader["FacultyClass2"].ToString(),
                    FacultyClass3 = facultyReader["FacultyClass3"].ToString(),
                    FacultyClass4 = facultyReader["FacultyClass4"].ToString(),
                    FacultyClass5 = facultyReader["FacultyClass5"].ToString()
                });

                }

            DBClass.MeetingManagerDBConnection.Close();
        }
        
        
        
        
        }
    }

