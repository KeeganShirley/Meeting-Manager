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
        public static SqlConnection AuthConnection = new SqlConnection();

        // Connection String
        private static readonly String? MeetingManagerDBConnString = "Server=Localhost;Database=Lab3;Trusted_Connection=True";

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
            cmdMeetingRead.CommandText = "SELECT * FROM MEETING, STUDENT";

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

            SqlCommand cmdupdatestudentRead = new SqlCommand();
            cmdupdatestudentRead.Connection = new SqlConnection();
            cmdupdatestudentRead.Connection.ConnectionString = MeetingManagerDBConnString;
            cmdupdatestudentRead.CommandType = System.Data.CommandType.StoredProcedure;
            cmdupdatestudentRead.Parameters.AddWithValue("@StudentID", s.StudentID);
            cmdupdatestudentRead.Parameters.AddWithValue("@StudentFName", s.StudentFName);
            cmdupdatestudentRead.Parameters.AddWithValue("@StudentLName", s.StudentLName);
            cmdupdatestudentRead.Parameters.AddWithValue("@StuEmail", s.StuEmail);
            cmdupdatestudentRead.Parameters.AddWithValue("@StuPHoneNum", s.StuPhoneNum);
            cmdupdatestudentRead.Parameters.AddWithValue("@GroupPartnerFirstName", s.GroupPartnerFirstName);
            cmdupdatestudentRead.Parameters.AddWithValue("@GroupPartnerLastName", s.GroupPartnerLastName);
            cmdupdatestudentRead.Parameters.AddWithValue("@GroupPartnerID", s.GroupPartnerID);
            cmdupdatestudentRead.CommandText = "sp_updatestudent";
            cmdupdatestudentRead.Connection.Open();
            cmdupdatestudentRead.ExecuteScalar();

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


            SqlCommand cmdupdatefacultyRead = new SqlCommand();
            cmdupdatefacultyRead.Connection = new SqlConnection();
            cmdupdatefacultyRead.Connection.ConnectionString = MeetingManagerDBConnString;
            cmdupdatefacultyRead.CommandType = System.Data.CommandType.StoredProcedure;
            cmdupdatefacultyRead.Parameters.AddWithValue("@FacultyID", f.FacultyID);
            cmdupdatefacultyRead.Parameters.AddWithValue("@FacultyFName", f.FacultyFName);
            cmdupdatefacultyRead.Parameters.AddWithValue("@FacultyLName", f.FacultyLName);
            cmdupdatefacultyRead.Parameters.AddWithValue("@FacultyEmail", f.FacultyEmail);
            cmdupdatefacultyRead.Parameters.AddWithValue("@OfficePhoneNum", f.OfficePhoneNum);
            cmdupdatefacultyRead.Parameters.AddWithValue("@OfficeLoc", f.OfficeLocation);
            cmdupdatefacultyRead.Parameters.AddWithValue("@Availability", f.Availability);
            cmdupdatefacultyRead.Parameters.AddWithValue("@Class1", f.Class1);
            cmdupdatefacultyRead.Parameters.AddWithValue("@Class2", f.Class2);
            cmdupdatefacultyRead.Parameters.AddWithValue("@Class3", f.Class3);
            cmdupdatefacultyRead.Parameters.AddWithValue("@Class4", f.Class4);
            cmdupdatefacultyRead.Parameters.AddWithValue("@Class5", f.Class5);
            cmdupdatefacultyRead.CommandText = "sp_updatefaculty";
            cmdupdatefacultyRead.Connection.Open();
            cmdupdatefacultyRead.ExecuteScalar();


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
        //public static void UpdateMeeting(MeetingProfile m, int facultyID)
        //{

        //    int currentMaxMeetingID = 0;

        //    // Get the highest MeetingID value in the DB
        //    string sqlQueryCount = "SELECT MAX(MeetingID) FROM MEETING";
        //    SqlCommand cmdGetMaxMeetingID = new SqlCommand(sqlQueryCount, MeetingManagerDBConnection);
        //    cmdGetMaxMeetingID.Connection.Open();
        //    SqlDataReader reader = cmdGetMaxMeetingID.ExecuteReader();

        //    if (reader.Read())
        //    {
        //        currentMaxMeetingID = reader.GetInt32(0);
        //    }

        //    reader.Close();

        //    cmdGetMaxMeetingID.Connection.Close();

        //    // Increment the current highest MeetingID value by 1
        //    m.MeetingID = currentMaxMeetingID + 1;

        //    //Insert the data from the SignUp sheet into the Meeting table
        //    string sqlQuery = "INSERT INTO MEETING (MeetingID, MeetingTime, MeetingDate, FacultyID, StudentID) VALUES (";
        //    sqlQuery += "'" + m.MeetingID + "', ";
        //    sqlQuery += "'" + m.MeetingTime + "', ";
        //    sqlQuery += "'" + m.MeetingDate + "', ";
        //    sqlQuery += facultyID + ", ";
        //    sqlQuery += m.StudentID + ");";

        //    SqlCommand cmdUpdateMeeting = new SqlCommand();
        //    cmdUpdateMeeting.Connection = MeetingManagerDBConnection;
        //    cmdUpdateMeeting.Connection.ConnectionString = MeetingManagerDBConnString;
        //    cmdUpdateMeeting.CommandText = sqlQuery;

        //    cmdUpdateMeeting.Connection.Open();

        //    cmdUpdateMeeting.ExecuteNonQuery();


        //}

        public static void UpdateMeeting(MeetingProfile m, int facultyID)
        {

            string sqlQueryCount = "SELECT COUNT(*) FROM MEETING";
            SqlCommand cmdGetMeetingCount = new SqlCommand(sqlQueryCount, MeetingManagerDBConnection);
            cmdGetMeetingCount.Connection.Open();
            int meetingCount = (int)cmdGetMeetingCount.ExecuteScalar();
            cmdGetMeetingCount.Connection.Close();

            int currentMaxMeetingID = 0;
            if (meetingCount > 0)
            {
                // Get the highest MeetingID value in the DB
                string sqlQueryMax = "SELECT MAX(MeetingID) FROM MEETING";
                SqlCommand cmdGetMaxMeetingID = new SqlCommand(sqlQueryMax, MeetingManagerDBConnection);
                cmdGetMaxMeetingID.Connection.Open();
                SqlDataReader reader = cmdGetMaxMeetingID.ExecuteReader();

                if (reader.Read())
                {
                    currentMaxMeetingID = reader.GetInt32(0);
                }

                reader.Close();
                cmdGetMaxMeetingID.Connection.Close();
            }

            // Increment the current highest MeetingID value by 1
            m.MeetingID = currentMaxMeetingID + 1;

            // Insert the data from the SignUp sheet into the Meeting table
            SqlCommand cmdupdatemeeting = new SqlCommand();
            cmdupdatemeeting.Connection = new SqlConnection();
            cmdupdatemeeting.Connection.ConnectionString = MeetingManagerDBConnString;
            cmdupdatemeeting.CommandType = System.Data.CommandType.StoredProcedure;
            cmdupdatemeeting.Parameters.AddWithValue("@MeetingID", m.MeetingID);
            cmdupdatemeeting.Parameters.AddWithValue("@MeetingTime", m.MeetingTime);
            cmdupdatemeeting.Parameters.AddWithValue("@MeetingDate", m.MeetingDate);
            cmdupdatemeeting.Parameters.AddWithValue("@facultyID", m.FacultyID);
            cmdupdatemeeting.Parameters.AddWithValue("@studentid", m.StudentID);
            cmdupdatemeeting.CommandText = "sp_createmeeting";
            cmdupdatemeeting.Connection.Open();
            cmdupdatemeeting.ExecuteScalar();
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

        public static SqlDataReader UserType(string typeQuery)
        {
            SqlCommand cmdType = new SqlCommand();
            cmdType.Connection = MeetingManagerDBConnection;
            cmdType.Connection.ConnectionString = MeetingManagerDBConnString;
            cmdType.CommandText = typeQuery;
            cmdType.Connection.Open();

            SqlDataReader tempReader = cmdType.ExecuteReader();
            return tempReader;

            cmdType.Connection.Close();

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


        public static SqlDataReader QueueReader(int StudentID, int FacultyID)
        {
            SqlCommand cmdQueueRead = new SqlCommand();

            cmdQueueRead.Connection = MeetingManagerDBConnection;
            cmdQueueRead.Connection.ConnectionString = MeetingManagerDBConnString;
            cmdQueueRead.CommandText = "SELECT * FROM QUEUE, FACULTY WHERE QUEUE.FACULTYID = " + FacultyID + " AND STUDENTID = " + StudentID;

            cmdQueueRead.Connection.Open();

            SqlDataReader tempReader = cmdQueueRead.ExecuteReader();
            return tempReader;
        }
            
    
        public static void QueueUpdate(int StudentID, int FacultyID)
        {
            SqlCommand cmdQueueUpdate = new SqlCommand();

            cmdQueueUpdate.Connection = new SqlConnection();
            cmdQueueUpdate.Connection = MeetingManagerDBConnection;
            cmdQueueUpdate.Connection.ConnectionString = MeetingManagerDBConnString;
            cmdQueueUpdate.CommandType = System.Data.CommandType.StoredProcedure;
            cmdQueueUpdate.Parameters.AddWithValue("@StudentID", StudentID);
            cmdQueueUpdate.Parameters.AddWithValue("@StudentID", FacultyID);
            cmdQueueUpdate.CommandText = "sp_joinQueue";
            cmdQueueUpdate.Connection.Open();
            cmdQueueUpdate.ExecuteScalar();

        }

        public static void CreateStudentAccount(int StudentID, String Username, String Password)
        {
            SqlCommand cmdStudentCreate = new SqlCommand();

            cmdStudentCreate.Connection = MeetingManagerDBConnection;
            cmdStudentCreate.Connection.ConnectionString = MeetingManagerDBConnString;
            cmdStudentCreate.CommandText = "INSERT INTO CREDENTIALS (Username, Password, StudentID) VALUES ('" + Username + "', '" + Password + "', " + StudentID + ")";

            cmdStudentCreate.Connection.Open();

            cmdStudentCreate.ExecuteNonQuery();

            cmdStudentCreate.Connection.Close();

        }

        public static void CreateFacultyAccount(int FacultyID, String Username, String Password)
        {
            SqlCommand cmdFacultyCreate = new SqlCommand();

            cmdFacultyCreate.Connection = MeetingManagerDBConnection;
            cmdFacultyCreate.Connection.ConnectionString = MeetingManagerDBConnString;
            cmdFacultyCreate.CommandText = "INSERT INTO CREDENTIALS (Username, Password, FacultyID) VALUES ('" + Username + "', '" + Password + "', " + FacultyID + ")";

            cmdFacultyCreate.Connection.Open();

            cmdFacultyCreate.ExecuteNonQuery();

            cmdFacultyCreate.Connection.Close();

        }

        // For Hashed Passwords

        private static readonly String? AuthConnString = "Server=Localhost;Database=AUTH;Trusted_Connection=True";


        //public static bool HashedParameterLogin(string Username, string Password)
        //{
        //    SqlCommand cmdlogin = new SqlCommand();
        //    cmdlogin.Connection = new SqlConnection();
        //    cmdlogin.Connection.ConnectionString = MeetingManagerDBConnString;
        //    cmdlogin.CommandType = System.Data.CommandType.StoredProcedure;
        //    cmdlogin.Parameters.AddWithValue("@Username", Username);
        //    cmdlogin.Parameters.AddWithValue("@Password", PasswordHash.HashPassword(Password));
        //    cmdlogin.CommandText = "login";
        //    cmdlogin.Connection.Open();
        //    if (((int)cmdlogin.ExecuteScalar()) > 0)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        //public static bool HashedParameterLogin(string Username, string Password)
        //{

        //    SqlCommand cmdLogin = new SqlCommand();
        //    cmdLogin.Connection = new SqlConnection();
        //    cmdLogin.Connection.ConnectionString = MeetingManagerDBConnString;
        //    cmdLogin.CommandType = System.Data.CommandType.StoredProcedure;

        //    cmdLogin.Parameters.AddWithValue("@Username", Username);
        //    cmdLogin.Parameters.AddWithValue("@Password", Password);

        //    cmdLogin.CommandText = "sp_login";
        //    cmdLogin.Connection.Open();

        //    // ExecuteScalar() returns back data type Object
        //    // Use a typecast to convert this to an int.
        //    // Method returns first column of first row.
        //    SqlDataReader hashReader = cmdLogin.ExecuteReader();
        //    if (hashReader.Read())
        //    {
        //        string correctHash = hashReader["Password"].ToString();

        //        if (PasswordHash.ValidatePassword(Password, correctHash))
        //        {
        //            return true;
        //        }
        //    }

        //    return false;
        //}

        public static bool HashedStudentParameterLogin(string Username, string Password, out int studentID)
        {
            SqlCommand cmdLogin = new SqlCommand();
            cmdLogin.Connection = new SqlConnection();
            cmdLogin.Connection.ConnectionString = MeetingManagerDBConnString;
            cmdLogin.CommandType = System.Data.CommandType.StoredProcedure;

            cmdLogin.Parameters.AddWithValue("@Username", Username);
            cmdLogin.Parameters.AddWithValue("@Password", Password);

            cmdLogin.CommandText = "sp_login_student";
            cmdLogin.Connection.Open();

            SqlDataReader hashReader = cmdLogin.ExecuteReader();
            if (hashReader.Read())
            {
                string correctHash = hashReader["Password"].ToString();

                if (PasswordHash.ValidatePassword(Password, correctHash))
                {
                    studentID = (int)hashReader["StudentID"];
                    return true;
                }
            }

            studentID = 0;
            return false;
        }

        public static bool HashedFacultyParameterLogin(string Username, string Password, out int facultyID)
        {
            SqlCommand cmdLogin = new SqlCommand();
            cmdLogin.Connection = new SqlConnection();
            cmdLogin.Connection.ConnectionString = MeetingManagerDBConnString;
            cmdLogin.CommandType = System.Data.CommandType.StoredProcedure;

            cmdLogin.Parameters.AddWithValue("@Username", Username);
            cmdLogin.Parameters.AddWithValue("@Password", Password);

            cmdLogin.CommandText = "sp_login_faculty";
            cmdLogin.Connection.Open();

            SqlDataReader hashReader = cmdLogin.ExecuteReader();
            if (hashReader.Read())
            {
                string correctHash = hashReader["Password"].ToString();

                if (PasswordHash.ValidatePassword(Password, correctHash))
                {
                    facultyID = (int)hashReader["FacultyID"];
                    return true;
                }
            }

            facultyID = 0;
            return false;
        }


        public static void CreateHashedUser(string Username, string Password)
        {

            SqlCommand cmdcreateuser = new SqlCommand();
            cmdcreateuser.Connection = MeetingManagerDBConnection;
            cmdcreateuser.Connection.ConnectionString = MeetingManagerDBConnString;

            cmdcreateuser.CommandType = System.Data.CommandType.StoredProcedure;
            cmdcreateuser.Parameters.AddWithValue("@Username", Username);
            cmdcreateuser.Parameters.AddWithValue("@Password", PasswordHash.HashPassword(Password));
            cmdcreateuser.CommandText = "sp_createuser";
            cmdcreateuser.Connection.Open();

            // ExecuteScalar() returns back data type Object
            // Use a typecast to convert this to an int.
            // Method returns first column of first row.
            cmdcreateuser.ExecuteScalar();

            SqlCommand cmdcreateauth = new SqlCommand();
            cmdcreateauth.Connection = AuthConnection;
            cmdcreateauth.Connection.ConnectionString = AuthConnString;

            cmdcreateauth.CommandType = System.Data.CommandType.StoredProcedure;
            cmdcreateauth.Parameters.AddWithValue("@Username", Username);
            cmdcreateauth.Parameters.AddWithValue("@Password", Password);
            cmdcreateauth.CommandText = "sp_authlogin";
            cmdcreateauth.Connection.Open();

            cmdcreateauth.ExecuteScalar();
        }

        public static void CreateStudentHashedUser(string Username, string Password)
        {
            SqlCommand cmdcreateuser = new SqlCommand();
            cmdcreateuser.Connection = MeetingManagerDBConnection;
            cmdcreateuser.Connection.ConnectionString = MeetingManagerDBConnString;

            cmdcreateuser.CommandType = System.Data.CommandType.StoredProcedure;
            cmdcreateuser.Parameters.AddWithValue("@Username", Username);
            cmdcreateuser.Parameters.AddWithValue("@Password", PasswordHash.HashPassword(Password));
            cmdcreateuser.CommandText = "sp_createStudent";
            cmdcreateuser.Connection.Open();

            // ExecuteScalar() returns back data type Object
            // Use a typecast to convert this to an int.
            // Method returns first column of first row.
            cmdcreateuser.ExecuteScalar();

            SqlCommand cmdcreateauth = new SqlCommand();
            cmdcreateauth.Connection = AuthConnection;
            cmdcreateauth.Connection.ConnectionString = AuthConnString;

            cmdcreateauth.CommandType = System.Data.CommandType.StoredProcedure;
            cmdcreateauth.Parameters.AddWithValue("@Username", Username);
            cmdcreateauth.Parameters.AddWithValue("@Password", Password);
            cmdcreateauth.CommandText = "sp_authlogin";
            cmdcreateauth.Connection.Open();

            cmdcreateauth.ExecuteScalar();
        }

        public static void CreateFacultyHashedUser(string Username, string Password)
        {

            SqlCommand cmdcreateuser = new SqlCommand();
            cmdcreateuser.Connection = MeetingManagerDBConnection;
            cmdcreateuser.Connection.ConnectionString = MeetingManagerDBConnString;

            cmdcreateuser.CommandType = System.Data.CommandType.StoredProcedure;
            cmdcreateuser.Parameters.AddWithValue("@Username", Username);
            cmdcreateuser.Parameters.AddWithValue("@Password", PasswordHash.HashPassword(Password));
            cmdcreateuser.CommandText = "sp_createFaculty";
            cmdcreateuser.Connection.Open();

            // ExecuteScalar() returns back data type Object
            // Use a typecast to convert this to an int.
            // Method returns first column of first row.
            cmdcreateuser.ExecuteScalar();

            SqlCommand cmdcreateauth = new SqlCommand();
            cmdcreateauth.Connection = AuthConnection;
            cmdcreateauth.Connection.ConnectionString = AuthConnString;

            cmdcreateauth.CommandType = System.Data.CommandType.StoredProcedure;
            cmdcreateauth.Parameters.AddWithValue("@Username", Username);
            cmdcreateauth.Parameters.AddWithValue("@Password", Password);
            cmdcreateauth.CommandText = "sp_authlogin";
            cmdcreateauth.Connection.Open();

            cmdcreateauth.ExecuteScalar();
        }


    }

}
