using Meeting_Manager.Pages.DataClasses;
using Meeting_Manager.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace Meeting_Manager.Pages.Profile
{
    public class EditFacultyProfileModel : PageModel
    {
        public List<Class> ClassList { get; set; }

        [BindProperty]
        public FacultyProfile facultyToUpdate { get; set; }

        [BindProperty]
        public Class classToAdd { get; set; }

        public EditFacultyProfileModel() 
        {
            facultyToUpdate= new FacultyProfile();
            ClassList = new List<Class>();
        }

        //Gets the faculty data and displays it
        public IActionResult OnGet(int facultyID)
        {
            SqlDataReader singleFaculty = DBClass.facultyClassReader(facultyID);

            while (singleFaculty.Read())
            {
                facultyToUpdate.FacultyID = facultyID;
                facultyToUpdate.FacultyFName = singleFaculty["FacultyFName"].ToString();
                facultyToUpdate.FacultyLName = singleFaculty["FacultyLName"].ToString();
                facultyToUpdate.FacultyEmail = singleFaculty["FacultyEmail"].ToString();
                facultyToUpdate.OfficePhoneNum = singleFaculty["OfficePhoneNum"].ToString();
                facultyToUpdate.OfficeLocation = singleFaculty["OfficeLoc"].ToString();
                facultyToUpdate.Availability = singleFaculty["Availability"].ToString();
                facultyToUpdate.Class1 = singleFaculty["Class1"].ToString();
                facultyToUpdate.Class2 = singleFaculty["Class2"].ToString();
                facultyToUpdate.Class3 = singleFaculty["Class3"].ToString();
                facultyToUpdate.Class4 = singleFaculty["Class4"].ToString();
                facultyToUpdate.Class5 = singleFaculty["Class5"].ToString();

            }

            DBClass.MeetingManagerDBConnection.Close();

            SqlDataReader classes = DBClass.ClassReader();

            while (classes.Read())
            {
                ClassList.Add(new Class
                { ClassID = classes["CLASSID"].ToString() });
            }
            DBClass.MeetingManagerDBConnection.Close();

            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToPage("/Login/DBLogin");
            }
            return Page();


        }

        //Allows for edit of faculty data
        public IActionResult OnPost()
        {
            DBClass.UpdateFaculty(facultyToUpdate);
            return RedirectToPage("Faculty_Profile");
                    
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }
    }
}
