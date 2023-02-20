using Meeting_Manager.Pages.DataClasses;
using Meeting_Manager.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Meeting_Manager.Pages.Meeting
{
    public class OfficeHour_SignUpModel : PageModel
    {
        [BindProperty]
        public int FacultyID { get; set; }

        [BindProperty]
        public MeetingProfile MeetingUpdate { get; set; }

        [BindProperty]
        public int StudentID { get; set; }
                
        //Constructor
        public OfficeHour_SignUpModel()
        {
            MeetingUpdate = new MeetingProfile();
        }


        //On Get method to take facultyID from the drop down and begin a signup sheet
        public IActionResult OnGet(int MeetingID, int FacultyID, int StudentID)
        {
            //Grab the FacultyID from the drop down menu
            this.FacultyID = FacultyID;
            //this.StudentID = StudentID;

            SqlDataReader singleMeeting = DBClass.SingleMeetingReader(MeetingID);

            while (singleMeeting.Read())
            {
                MeetingUpdate.MeetingID = MeetingID;
                MeetingUpdate.MeetingTime = singleMeeting["MeetingTime"].ToString();
                MeetingUpdate.MeetingDate = singleMeeting["MeetingDate"].ToString();
                //MeetingUpdate.StudentID = (int)singleMeeting["StudentID"];
                
            }
            DBClass.MeetingManagerDBConnection.Close();

            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToPage("/Login/DBLogin");
            }
            return Page();

        }

        //Once the signup page is filled out and the "submit" button has been pressed then this will redirect the student to the Student Meeting page
        public IActionResult OnPost(int FacultyID, int StudentID)
        {
            //Same functionality as this expression up above
            this.FacultyID = FacultyID;

            //This will actually send the data into the DB
            DBClass.QueueUpdate(StudentID, FacultyID);

            DBClass.MeetingManagerDBConnection.Close();

            return RedirectToPage("Student_Meeting");
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }


    }
}
