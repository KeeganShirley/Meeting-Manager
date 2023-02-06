using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Meeting_Manager.Pages.Profile
{
    public class Student_ProfileModel : PageModel
    {
        public void OnGet()
        {
            SqlDataReader studentReader = DBClass.StudentReader();
        
            while(studentReader.Read())
            {
                StudentID = Int32.Parse(studentReader["StudentID"].ToString());
                StudentFName = studentReader["StudentFName"].ToString();
                StudentLName = st
            }        
        }




    }
}
