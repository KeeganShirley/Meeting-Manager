using Meeting_Manager.Pages.DataClasses;
using Meeting_Manager.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Meeting_Manager.Pages.Profile
{
    public class EditStudentProfileModel : PageModel
    {
        [BindProperty]
        public StudentProfile studentToUpdate { get; set; }

        public EditStudentProfileModel()
        {
            studentToUpdate = new StudentProfile();
        }
    
        //Gets the student data and displays it
        public void OnGet(int studentID)
        {
            SqlDataReader singleStudent = DBClass.SingleStudentReader(studentID);
        
            while (singleStudent.Read())
            {
                studentToUpdate.StudentID = studentID;
                studentToUpdate.StudentFName = singleStudent["StudentFName"].ToString();
                studentToUpdate.StudentLName = singleStudent["StudentLName"].ToString();
                studentToUpdate.StuEmail = singleStudent["StuEmail"].ToString();
                studentToUpdate.StuPhoneNum = singleStudent["StuPhoneNum"].ToString();
                studentToUpdate.GroupPartnerFirstName = singleStudent["GroupPartnerFirstName"].ToString();
                studentToUpdate.GroupPartnerLastName = singleStudent["GroupPartnerLastName"].ToString();
                studentToUpdate.GroupPartnerID = (int)singleStudent["GroupPartnerID"];
            }
        }

        //Allows for edit of student data
        public IActionResult OnPost()
        {
            DBClass.UpdateStudent(studentToUpdate);
            return RedirectToPage("Student_Profile");
        }

    }
}
