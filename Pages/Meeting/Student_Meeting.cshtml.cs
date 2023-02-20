using Meeting_Manager.Pages.DataClasses;
using Meeting_Manager.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;

namespace Meeting_Manager.Pages.Meeting
{
    public class Student_MeetingModel : PageModel
    {

    //Build a Faculty list to put in the drop down menu from the FACULTY table
    public List<FacultyProfile> FacultyList { get; set; }

    //Constructor 
    public Student_MeetingModel()
    {
        FacultyList = new List<FacultyProfile>();
    }

    //Get the data for the dropdown menu and display it
    public IActionResult OnGet()
    {
        SqlDataReader FacultyReader = DBClass.facultyReader();

        while (FacultyReader.Read())
        {
            FacultyList.Add(new FacultyProfile
            {
                FacultyFName = FacultyReader["FacultyFName"].ToString(),
                FacultyLName = FacultyReader["FacultyLName"].ToString(),
                FacultyID = Int32.Parse(FacultyReader["FacultyID"].ToString())
            });

        }
        DBClass.MeetingManagerDBConnection.Close();

            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToPage("/Login/DBLogin");
            }
            return Page();
    }

        public IActionResult OnPostSingleSelect(string meetingType)
        {
            string selectedFac = Request.Form["FacultySearch"].ToString();

            string FacultyID = selectedFac.Split(new char[] { ' ' }, 3)[2];

            if (meetingType == "Meeting")
            {
                return RedirectToPage("./Meeting_SignUp", new { FacultyID = FacultyID });
            }
            else if (meetingType == "OfficeHour")
            {
                return RedirectToPage("./OfficeHour_SignUp", new { FacultyID = FacultyID});
            }
            else
            {
                return (Page());
            }

        }


    }

}
