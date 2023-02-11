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
            SqlCommand cmdstudentRead = new SqlCommand();
            cmdstudentRead.Connection = MeetingManagerDBConnection;
            cmdstudentRead.Connection.ConnectionString = MeetingManagerDBConnString;
            cmdstudentRead.CommandText = "SELECT * FROM STUDENT";

            cmdstudentRead.Connection.Open();

            SqlDataReader tempReader = cmdstudentRead.ExecuteReader();

            return tempReader;
        }


        public static SqlDataReader facultyReader()
        {
            SqlCommand cmdfacultyRead = new SqlCommand();
            cmdfacultyRead.Connection = MeetingManagerDBConnection;
            cmdfacultyRead.Connection.ConnectionString = MeetingManagerDBConnString;
            cmdfacultyRead.CommandText = "SELECT * FROM FACULTY";

            cmdfacultyRead.Connection.Open();

            SqlDataReader tempReader = cmdfacultyRead.ExecuteReader();

            return tempReader;
        }

        public static SqlDataReader MeetingReader()
        {
            SqlCommand cmdMeetingRead = new SqlCommand();
            cmdMeetingRead.Connection = MeetingManagerDBConnection;
            cmdMeetingRead.Connection.ConnectionString = MeetingManagerDBConnString;
            cmdMeetingRead.CommandText = "SELECT * FROM MEETING";

            cmdMeetingRead.Connection.Open();

            SqlDataReader tempReader = cmdMeetingRead.ExecuteReader();

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

        public static SqlDataReader SingleStudentReader(int StudentID)
        {
            SqlCommand cmdsstudentRead = new SqlCommand();
            cmdsstudentRead.Connection = new SqlConnection();
            //cmdsstudentRead.Connection = MeetingManagerDBConnection;
            cmdsstudentRead.Connection.ConnectionString = MeetingManagerDBConnString;
            cmdsstudentRead.CommandText = "SELECT * FROM STUDENT WHERE StudentID = " + StudentID;
            cmdsstudentRead.Connection.Open();
            SqlDataReader tempReader = cmdsstudentRead .ExecuteReader();

            return tempReader;
        }

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


                SqlCommand cmdupdatestudentRead = new SqlCommand();
            cmdupdatestudentRead.Connection = new SqlConnection();
            cmdupdatestudentRead.Connection.ConnectionString = MeetingManagerDBConnString;
            cmdupdatestudentRead.CommandText = sqlQuery;
            cmdupdatestudentRead.Connection.Open();
            cmdupdatestudentRead.ExecuteNonQuery();
            

        }

        public static SqlDataReader SingleFacultyReader(int FacultyID)
        {
            SqlCommand cmdfacultyRead = new SqlCommand();
            cmdfacultyRead.Connection = new SqlConnection();
            cmdfacultyRead.Connection.ConnectionString = MeetingManagerDBConnString;
            cmdfacultyRead.CommandText = "SELECT * FROM FACULTY WHERE FacultyID = " + FacultyID;
            cmdfacultyRead.Connection.Open();
            SqlDataReader tempReader = cmdfacultyRead.ExecuteReader();

            return tempReader;
        }


        public static void UpdateFaculty(FacultyProfile f)
        {

            string sqlQuery = "UPDATE FACULTY SET ";
            sqlQuery += "FacultyID='" + f.FacultyID + "',";
            sqlQuery += "FacultyFName='" + f.FacultyFName + "',";
            sqlQuery += "FacultyLName='" + f.FacultyLName + "',";
            sqlQuery += "FacultyEmail='" + f.FacultyEmail + "',";
            sqlQuery += "OfficePhoneNum='" + f.OfficePhoneNum + "',";
            sqlQuery += "OfficeLoc='" + f.OfficeLocation + "',";
            sqlQuery += "FacultyDescription='" + f.FacultyDescription + "',";
            sqlQuery += "FacultyClass1='" + f.FacultyClass1 + "',";
            sqlQuery += "FacultyClass2='" + f.FacultyClass2 + "',";
            sqlQuery += "FacultyClass3='" + f.FacultyClass3 + "',";
            sqlQuery += "FacultyClass4='" + f.FacultyClass4 + "',";
            sqlQuery += "FacultyClass5='" + f.FacultyClass5 + "' WHERE FACULTYID =" + f.FacultyID;


            SqlCommand cmdupdatefacultyRead = new SqlCommand();
            cmdupdatefacultyRead.Connection = new SqlConnection();
            cmdupdatefacultyRead.Connection.ConnectionString = MeetingManagerDBConnString;
            cmdupdatefacultyRead.CommandText = sqlQuery;
            cmdupdatefacultyRead.Connection.Open();
            cmdupdatefacultyRead.ExecuteNonQuery();


        }




        public static SqlDataReader SingleMeetingReader(int MeetingID)
        {
            SqlCommand cmdMeetingRead = new SqlCommand();
            cmdMeetingRead.Connection = new SqlConnection();
            cmdMeetingRead.Connection = MeetingManagerDBConnection;
            cmdMeetingRead.Connection.ConnectionString = MeetingManagerDBConnString;
            cmdMeetingRead.CommandText = "SELECT * FROM Meeting WHERE MeetingID = " + MeetingID;

            cmdMeetingRead.Connection.Open();
            SqlDataReader tempReader = cmdMeetingRead.ExecuteReader();

            return tempReader;
        }

        public static void UpdateMeeting(MeetingProfile m, int facultyID)
        {

            string sqlQuery = "INSERT INTO MEETING (MeetingID, MeetingTime, MeetingDate, FacultyID, StudentID) VALUES (";
            sqlQuery +=  m.MeetingID + ", " + m.MeetingTime + ", " + m.MeetingDate + ", " + facultyID  + ", " + m.StudentID;
            sqlQuery +=  ");";

            SqlCommand cmdupdatestudentRead = new SqlCommand();
            cmdupdatestudentRead.Connection = new SqlConnection();
            cmdupdatestudentRead.Connection.ConnectionString = MeetingManagerDBConnString;
            cmdupdatestudentRead.CommandText = sqlQuery;
            cmdupdatestudentRead.Connection.Open();
            _ = cmdupdatestudentRead.ExecuteNonQuery();


        }


    }
}