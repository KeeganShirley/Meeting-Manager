using Meeting_Manager.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Meeting_Manager.Pages.Queue
{
    public class Student_QueueModel : PageModel
    {
        [BindProperty]
        public int QueuePos { get; set; }
        [BindProperty]
        public int StudentID { get; set; }
        [BindProperty]
        public int FacultyID { get; set; }
        [BindProperty]
        public String? FacultyFName { get; set; }
        [BindProperty]
        public String? FacultyLName { get; set; }
        [BindProperty]
        public String? OfficeLoc { get; set; }
        public void OnGet()
        {
            //int StudentID = HttpContext.Session.GetInt32("studentID");
            SqlDataReader queueReader = DBClass.QueueReader(1, 1);

            while (queueReader.Read())
            {
                QueuePos = Int32.Parse(queueReader["QueuePos"].ToString());
                StudentID = Int32.Parse(queueReader["FacultyID"].ToString());
                FacultyID = Int32.Parse(queueReader["FacultyID"].ToString());
                FacultyFName = queueReader["FacultyFName"].ToString();
                FacultyLName = queueReader["FacultyLName"].ToString();
                OfficeLoc = queueReader["OfficeLoc"].ToString();

            }

            DBClass.MeetingManagerDBConnection.Close(); 
        }
        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }
    }
}
