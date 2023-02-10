using Meeting_Manager.Pages.DataClasses;
using Meeting_Manager.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Meeting_Manager.Pages.Meeting
{
    public class SignUp_SheetModel : PageModel
    {
        [BindProperty]
        public MeetingProfile MeetingUpdate { get; set; }



        public SignUp_SheetModel()
        {
            MeetingUpdate = new MeetingProfile();
        }


        public void OnGet(int MeetingID)
        {
            SqlDataReader singleMeeting = DBClass.SingleMeetingReader(MeetingID);

            while (singleMeeting.Read())
            {
                MeetingUpdate.MeetingID = MeetingID;
                MeetingUpdate.MeetingTime = singleMeeting["MeetingTime"].ToString();
                MeetingUpdate.MeetingDate = singleMeeting["MeetingDate"].ToString();
                MeetingUpdate.FacultyID = (int)singleMeeting["Faculty"];
                MeetingUpdate.StudentID = (int)singleMeeting["StudentID"];
                
            
                
            }
            DBClass.MeetingManagerDBConnection.Close();

            

        }


        public IActionResult OnPost()
        {
            DBClass.UpdateMeeting(MeetingUpdate);
            return RedirectToPage("SignUp_Sheet");
        }



    }
}
