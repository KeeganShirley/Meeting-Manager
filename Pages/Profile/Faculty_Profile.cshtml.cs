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
        public IActionResult OnGet()
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
                    Availability = facultyReader["Availability"].ToString()

                }) ;

                }
            DBClass.MeetingManagerDBConnection.Close();

            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToPage("/Login/HashedLogin");
            }
            return Page();
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }




    }
    }

