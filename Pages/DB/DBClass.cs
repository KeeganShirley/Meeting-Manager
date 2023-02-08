using Meeting_Manager.Pages.DataClasses;
using Meeting_Manager.Pages.Profile;
using System.Data.SqlClient;

namespace Meeting_Manager.Pages.DB
{
    public class DBClass
    {
        // Connection at the Class Level
        public static SqlConnection MeetingManagerDBConnection = new SqlConnection();

        // Connection String
        private static readonly String? MeetingManagerDBConnString = "Server=Localhost;Database=OfficeHours;Trusted_Connection=True";

        public static object MeetingManagerDBConection { get; internal set; }

        public static SqlDataReader Reader()
        {
            SqlCommand cmdProductRead = new SqlCommand();
            cmdProductRead.Connection = MeetingManagerDBConnection;
            cmdProductRead.Connection.ConnectionString = MeetingManagerDBConnString;
            cmdProductRead.CommandText = "SELECT * FROM STUDENT";

            cmdProductRead.Connection.Open();

            SqlDataReader tempReader = cmdProductRead.ExecuteReader();

            return tempReader;
        }


        public static SqlDataReader facultyReader()
        {
            SqlCommand cmdProductRead = new SqlCommand();
            cmdProductRead.Connection = MeetingManagerDBConnection;
            cmdProductRead.Connection.ConnectionString = MeetingManagerDBConnString;
            cmdProductRead.CommandText = "SELECT * FROM FACULTY";

            cmdProductRead.Connection.Open();

            SqlDataReader tempReader = cmdProductRead.ExecuteReader();

            return tempReader;
        }

        //public static void InsertProduct(Product p)
        //{
        //    String sqlQuery = "INSERT INTO Product (ProductName, ProductCost, ProductDescription) \r\nVALUES (";
        //    sqlQuery += "'" + p.ProductName + "',";
        //    sqlQuery += p.ProductCost + ",'";
        //    sqlQuery += p.ProductDescription + "')";

        //    SqlCommand cmdProductReader = new SqlCommand();
        //    cmdProductReader.Connection = GroceryDBConnection;
        //    cmdProductReader.Connection.ConnectionString = GroceryDBConnString;
        //    cmdProductReader.CommandText = sqlQuery;

        //    cmdProductReader.Connection.Open();

        //    cmdProductReader.ExecuteNonQuery();

        //}

        public static void UpdateStudent(StudentProfile s)
        {
            
                string sqlQuery = "UPDATE Student SET ";
                sqlQuery += "StudentID='" + s.StudentID + "',";
                sqlQuery += "StudentFName='" + s.StudentFName + "',";
                sqlQuery += "StudentLName='" + s.StudentLName + "',";
                sqlQuery += "StuEmail='" + s.StuEmail + "',";
                sqlQuery += "StuPhoneNum='" + s.StuPhoneNum + "',";
                sqlQuery += "GroupPartnerFirstName='" + s.GroupPartnerFirstName + "',";
                sqlQuery += "GroupPartnerLastName='" + s.GroupPartnerLastName + "' WHERE StudentID =" + s.StudentID;


                SqlCommand cmdProductRead = new SqlCommand();
                cmdProductRead.Connection = new SqlConnection();
                cmdProductRead.Connection.ConnectionString = MeetingManagerDBConnString;
                cmdProductRead.CommandText = sqlQuery;
                cmdProductRead.Connection.Open();
                cmdProductRead.ExecuteNonQuery();
            

        }

    }
}