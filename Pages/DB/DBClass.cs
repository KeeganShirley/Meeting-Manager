using Meeting_Manager.Pages.DataClasses;
using Meeting_Manager.Pages.Login;
using Meeting_Manager.Pages.Profile;
using Microsoft.AspNetCore.Identity;
using System.Data.SqlClient;
using System.Reflection.Emit;

namespace Meeting_Manager.Pages.DB
{
    public class DBClass
    {
        // Connection at the Class Level
        public static SqlConnection MeetingManagerDBConnection = new SqlConnection();

        // Connection String
        private static readonly String? MeetingManagerDBConnString = "Server=Localhost;Database=Lab2;Trusted_Connection=True";

        public static object? MeetingManagerDBConection { get; internal set; }

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

        //Read the Faculty Data
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

        public static SqlDataReader facultyClassReader(int facultyID)
        {
            SqlCommand cmdfacultyClassRead = new SqlCommand();
            cmdfacultyClassRead.Connection = MeetingManagerDBConnection;
            cmdfacultyClassRead.Connection.ConnectionString = MeetingManagerDBConnString;
            cmdfacultyClassRead.CommandText = "SELECT * FROM Faculty;";

            cmdfacultyClassRead.Connection.Open();

            SqlDataReader tempReader = cmdfacultyClassRead.ExecuteReader();
            return tempReader;
        }

        //Read the Meeting Data
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


        public static SqlDataReader SingleStudentReader(int StudentID)
        {
            SqlCommand cmdsstudentRead = new SqlCommand();
            cmdsstudentRead.Connection = new SqlConnection();
            cmdsstudentRead.Connection.ConnectionString = MeetingManagerDBConnString;
            cmdsstudentRead.CommandText = "SELECT * FROM STUDENT WHERE StudentID = " + StudentID;
            cmdsstudentRead.Connection.Open();
            SqlDataReader tempReader = cmdsstudentRead .ExecuteReader();

            return tempReader;
        }


        //This is used to update student information within the STUDENT Table
        public static void UpdateStudent(StudentProfile s)
        {
            
                string sqlQuery = "UPDATE Student SET ";
                sqlQuery += "StudentID='" + s.StudentID + "',";
                sqlQuery += "StudentFName='" + s.StudentFName + "',";
                sqlQuery += "StudentLName='" + s.StudentLName + "',";
                sqlQuery += "StuEmail='" + s.StuEmail + "',";
                sqlQuery += "StuPhoneNum='" + s.StuPhoneNum + "',";
                sqlQuery += "GroupPartnerFirstName='" + s.GroupPartnerFirstName + "',";
                sqlQuery += "GroupPartnerLastName='" + s.GroupPartnerLastName + "',";
                sqlQuery += "GroupPartnerID=" + s.GroupPartnerID + " WHERE StudentID =" + s.StudentID;


            SqlCommand cmdupdatestudentRead = new SqlCommand();
            cmdupdatestudentRead.Connection = new SqlConnection();
            cmdupdatestudentRead.Connection.ConnectionString = MeetingManagerDBConnString;
            cmdupdatestudentRead.CommandText = sqlQuery;
            cmdupdatestudentRead.Connection.Open();
            cmdupdatestudentRead.ExecuteNonQuery();
            

        }

        //
        public static SqlDataReader SingleFacultyReader(int FacultyID)
        {
            SqlCommand cmdfacultyRead = new SqlCommand();
            cmdfacultyRead.Connection = new SqlConnection();
            cmdfacultyRead.Connection.ConnectionString = MeetingManagerDBConnString;
            cmdfacultyRead.CommandText = "SELECT * from Faculty WHERE FacultyID = " + FacultyID;
            cmdfacultyRead.Connection.Open();
            SqlDataReader tempReader = cmdfacultyRead.ExecuteReader();

            return tempReader;
        }

        //This is used to update faculty information within the FACULTY Table
        public static void UpdateFaculty(FacultyProfile f)
        {
            string sqlQuery = "UPDATE FACULTY SET ";
            sqlQuery += "FacultyFName = '" + f.FacultyFName + "', ";
            sqlQuery += "FacultyLName = '" + f.FacultyLName + "', ";
            sqlQuery += "FacultyEmail = '" + f.FacultyEmail + "', ";
            sqlQuery += "OfficePhoneNum = '" + f.OfficePhoneNum + "', ";
            sqlQuery += "OfficeLoc = '" + f.OfficeLocation + "', ";
            sqlQuery += "Availability = '" + f.Availability + "', ";
            sqlQuery += "Class1 = '" + f.Class1 + "', ";
            sqlQuery += "Class2 = '" + f.Class2 + "', ";
            sqlQuery += "Class3 = '" + f.Class3 + "', ";
            sqlQuery += "Class4 = '" + f.Class4 + "', ";
            sqlQuery += "Class5 = '" + f.Class5 + "' WHERE FacultyID = " + f.FacultyID;

            SqlCommand cmdupdatefacultyRead = new SqlCommand();
            cmdupdatefacultyRead.Connection = new SqlConnection();
            cmdupdatefacultyRead.Connection.ConnectionString = MeetingManagerDBConnString;
            cmdupdatefacultyRead.CommandText = sqlQuery;
            cmdupdatefacultyRead.Connection.Open();
            cmdupdatefacultyRead.ExecuteNonQuery();


        }

        public static SqlDataReader ClassReader()
        {
            SqlCommand cmdClassRead = new SqlCommand();

            cmdClassRead.Connection = MeetingManagerDBConnection;
            cmdClassRead.Connection.ConnectionString = MeetingManagerDBConnString;
            cmdClassRead.CommandText = "SELECT ClassID FROM CLASS";

            cmdClassRead.Connection.Open();

            SqlDataReader tempReader = cmdClassRead.ExecuteReader();
            return tempReader;
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

        //This is used to update the meeting table with signup sheet information
        public static void UpdateMeeting(MeetingProfile m, int facultyID)
        {

            int currentMaxMeetingID = 0;

            // Get the highest MeetingID value in the DB
            string sqlQueryCount = "SELECT MAX(MeetingID) FROM MEETING";
            SqlCommand cmdGetMaxMeetingID = new SqlCommand(sqlQueryCount, MeetingManagerDBConnection);
            cmdGetMaxMeetingID.Connection.Open();
            SqlDataReader reader = cmdGetMaxMeetingID.ExecuteReader();

            if (reader.Read())
            {
                currentMaxMeetingID = reader.GetInt32(0);
            }

            reader.Close();

            cmdGetMaxMeetingID.Connection.Close();

            // Increment the current highest MeetingID value by 1
            m.MeetingID = currentMaxMeetingID + 1;

            //Insert the data from the SignUp sheet into the Meeting table
            string sqlQuery = "INSERT INTO MEETING (MeetingID, MeetingTime, MeetingDate, FacultyID, StudentID) VALUES (";
            sqlQuery += "'" + m.MeetingID + "', ";
            sqlQuery += "'" + m.MeetingTime + "', ";
            sqlQuery += "'" + m.MeetingDate + "', ";
            sqlQuery += facultyID + ", ";
            sqlQuery += m.StudentID + ");";

            SqlCommand cmdUpdateMeeting = new SqlCommand();
            cmdUpdateMeeting.Connection = MeetingManagerDBConnection;
            cmdUpdateMeeting.Connection.ConnectionString = MeetingManagerDBConnString;
            cmdUpdateMeeting.CommandText = sqlQuery;

            cmdUpdateMeeting.Connection.Open();

            cmdUpdateMeeting.ExecuteNonQuery();


        }

        public static int LoginQuery(string loginQuery)
        {
            // This method expects to receive an SQL SELECT
            // query that uses the COUNT command.
            SqlCommand cmdLogin = new SqlCommand();
            cmdLogin.Connection = MeetingManagerDBConnection;
            cmdLogin.Connection.ConnectionString = MeetingManagerDBConnString;
            cmdLogin.CommandText = loginQuery;
            cmdLogin.Connection.Open();
            // ExecuteScalar() returns back data type Object
            // Use a typecast to convert this to an int.
            // Method returns first column of first row.
            int rowCount = (int)cmdLogin.ExecuteScalar();
            return rowCount;
        }
        public static int SecureLogin(string Username, string Password)
        {
            string loginQuery =
            "SELECT COUNT(*) FROM Credentials where Username = @Username and Password = @Password";
        SqlCommand cmdLogin = new SqlCommand();
            cmdLogin.Connection = MeetingManagerDBConnection;
            cmdLogin.Connection.ConnectionString = MeetingManagerDBConnString;
            cmdLogin.CommandText = loginQuery;
            cmdLogin.Parameters.AddWithValue("@Username", Username);
            cmdLogin.Parameters.AddWithValue("@Password", Password);
            cmdLogin.Connection.Open();
            // ExecuteScalar() returns back data type Object
            // Use a typecast to convert this to an int.
            // Method returns first column of first row.
            int rowCount = (int)cmdLogin.ExecuteScalar();
            return rowCount;
        }


    }
    
}
   

