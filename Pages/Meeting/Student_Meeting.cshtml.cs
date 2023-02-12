using Meeting_Manager.Pages.DataClasses;
using Meeting_Manager.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

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
    }

    //Used to take the facultyID selected from the dropdown and carry it to the signup sheet
    public IActionResult OnPostSingleSelect()
        {
            string SelectedFac = Request.Form["FacultySearch"].ToString();

            int index = SelectedFac.IndexOf(')');
            String shortened = SelectedFac.Substring(0, index);
            return RedirectToPage("./SignUp_Sheet", new { FacultyID = shortened.ToString(), Faculty = Convert.ToInt32(RouteData.Values["FacultyID"]) });
            DBClass.MeetingManagerDBConnection.Close();

        }
}

}
