using Meeting_Manager.Pages.DataClasses;
using Meeting_Manager.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Meeting_Manager.Pages.Meeting
{
    public class SignUp_SheetModel : PageModel
    {
        public int FacultyID { get; set; }

        [BindProperty]
        public MeetingProfile MeetingUpdate { get; set; }
                
        public SignUp_SheetModel()
        {
            MeetingUpdate = new MeetingProfile();
        }


        public void OnGet(int MeetingID, int FacultyID)
        {
            this.FacultyID = FacultyID;

            SqlDataReader singleMeeting = DBClass.SingleMeetingReader(MeetingID);

            while (singleMeeting.Read())
            {
                MeetingUpdate.MeetingID = MeetingID;
                MeetingUpdate.MeetingTime = singleMeeting["MeetingTime"].ToString();
                MeetingUpdate.MeetingDate = singleMeeting["MeetingDate"].ToString();
                MeetingUpdate.StudentID = (int)singleMeeting["StudentID"];
                
            }
            DBClass.MeetingManagerDBConnection.Close();

            

        }


        public IActionResult OnPost(int FacultyID)
        {
            this.FacultyID = FacultyID;
            DBClass.UpdateMeeting(MeetingUpdate, FacultyID);

            DBClass.MeetingManagerDBConnection.Close();

            return RedirectToPage("Student_Meeting");
        }




    }
}
