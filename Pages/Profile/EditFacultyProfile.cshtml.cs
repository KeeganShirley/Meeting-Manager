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

        [BindProperty]
        public FacultyProfile facultyToUpdate { get; set; }

        public EditFacultyProfileModel() 
        {
            facultyToUpdate= new FacultyProfile();
        }


        public void OnGet(int facultyID)
        {
            SqlDataReader singleFaculty = DBClass.SingleFacultyReader(facultyID);

            while (singleFaculty.Read())
            {
                facultyToUpdate.FacultyID = facultyID;
                facultyToUpdate.FacultyFName = singleFaculty["FacultyFName"].ToString();
                facultyToUpdate.FacultyLName = singleFaculty["FacultyLName"].ToString();
                facultyToUpdate.FacultyEmail = singleFaculty["FacultyEmail"].ToString();
                facultyToUpdate.OfficePhoneNum = singleFaculty["OfficePhoneNum"].ToString();
                facultyToUpdate.OfficeLocation = singleFaculty["OfficeLoc"].ToString();
                facultyToUpdate.FacultyDescription = singleFaculty["FacultyDescription"].ToString();
                facultyToUpdate.FacultyClass1 = singleFaculty["FacultyClass1"].ToString();
                facultyToUpdate.FacultyClass2 = singleFaculty["FacultyClass2"].ToString();
                facultyToUpdate.FacultyClass3 = singleFaculty["FacultyClass3"].ToString();
                facultyToUpdate.FacultyClass4 = singleFaculty["FacultyClass4"].ToString();
                facultyToUpdate.FacultyClass5 = singleFaculty["FacultyClass5"].ToString();

            }
        }

        public IActionResult OnPost()
        {
            DBClass.UpdateFaculty(facultyToUpdate);
            return RedirectToPage("Faculty_Profile");
                    
        }
    }
}
