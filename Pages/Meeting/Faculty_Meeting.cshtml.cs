using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Meeting_Manager.Pages.DataClasses;
using Meeting_Manager.Pages.DB;
using System.Data.SqlClient;

namespace Meeting_Manager.Pages.Meeting
{
    public class Faculty_MeetingModel : PageModel
    {
        public List<MeetingProfile> MeetingList { get; set; }

        public Faculty_MeetingModel() 
        { 
            MeetingList = new List<MeetingProfile>();
        }

        public void OnGet()
        {
            SqlDataReader meetingReader = DBClass.MeetingReader();

            while (meetingReader.Read())
            {
                MeetingList.Add(new MeetingProfile
                {
                    MeetingID = Int32.Parse(meetingReader["MeetingID"].ToString()),
                    MeetingTime = meetingReader["MeetingTime"].ToString(),
                    MeetingDate = meetingReader["MeetingDate"].ToString(),
                    FacultyID = Int32.Parse(meetingReader["FacultyID"].ToString()),
                    StudentID = Int32.Parse(meetingReader["StudentID"].ToString()),
                    StudentFName = meetingReader["StudentFName"].ToString(),
                    StudentLName = meetingReader["StudentLName"].ToString()

                });
            }


        }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }
    }
}
