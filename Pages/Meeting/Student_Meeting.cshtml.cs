using Meeting_Manager.Pages.DataClasses;
using Meeting_Manager.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Meeting_Manager.Pages.Meeting
{
    public class Student_MeetingModel : PageModel
    {
        public List<FacultyProfile> FacultyList { get; set; }

        [BindProperty]
        public int SelectedID { get; set; }

        public Student_MeetingModel()
        {
            FacultyList = new List<FacultyProfile>();
        }

        public void OnGet()
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

            //int SelectedAccount = Convert.ToInt32(RouteData.Values["FacultyID"]);
            //SqlDataReader 
        }

        public IActionResult OnPostSingleSelect()
        {
            string SelectedFac = Request.Form["FacultySearch"].ToString();

            int index = SelectedFac.IndexOf(')');
            String shortened = SelectedFac.Substring(0, index);
            return RedirectToPage("./SignUp_Sheet", new { FacultyID = shortened.ToString(), Student = Convert.ToInt32(RouteData.Values["FacultyID"]) });
            DBClass.MeetingManagerDBConnection.Close();

        }
    }

}
