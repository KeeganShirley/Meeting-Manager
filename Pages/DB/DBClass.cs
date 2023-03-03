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
            cmdQueueUpdate.Parameters.AddWithValue("@FacultyID", FacultyID);
            cmdQueueUpdate.CommandText = "sp_joinQueue";
            cmdQueueUpdate.Connection.Open();
            cmdQueueUpdate.ExecuteScalar();

        }

     

        // For Hashed Passwords

        private static readonly String? AuthConnString = "Server=Localhost;Database=AUTH;Trusted_Connection=True";


        public static bool HashedParameterLogin(string Username, string Password, out int studentID, out int facultyID)
        {
            SqlCommand cmdLogin = new SqlCommand();
            cmdLogin.Connection = new SqlConnection();
           
            cmdLogin.Connection = AuthConnection;
            cmdLogin.Connection.ConnectionString = AuthConnString;
            cmdLogin.CommandType = System.Data.CommandType.StoredProcedure;

            cmdLogin.Parameters.AddWithValue("@Username", Username);
            cmdLogin.Parameters.AddWithValue("@Password", Password);

            cmdLogin.CommandText = "sp_login_check";
            cmdLogin.Connection.Open();
            SqlDataReader hashReader = cmdLogin.ExecuteReader();
            if (hashReader.Read())
            {
                if (hashReader["StudentID"] != DBNull.Value)
                {
                    int.TryParse(hashReader["StudentID"].ToString(), out studentID);
                    string correctHash = hashReader["Password"].ToString();
                    if (PasswordHash.ValidatePassword(Password, correctHash))
                    {
                        facultyID = 0;
                        return true;
                    }
                }
                else if (hashReader["FacultyID"] != DBNull.Value)
                {
                    int.TryParse(hashReader["FacultyID"].ToString(), out facultyID);
                    string correctHash = hashReader["Password"].ToString();
                    if (PasswordHash.ValidatePassword(Password, correctHash))
                    {
                        studentID = 0;
                        return true;
                    }
                }
            }
            studentID = 0;
            facultyID = 0;
            return false;
        }



        

        public static void CreateStudentHashedUser(string Username, string Password)
        {
            SqlCommand cmdcreateuser = new SqlCommand();

            cmdcreateuser.Connection = MeetingManagerDBConnection;
            cmdcreateuser.Connection.ConnectionString = MeetingManagerDBConnString;
            cmdcreateuser.Connection = AuthConnection;
            cmdcreateuser.Connection.ConnectionString = AuthConnString;
            


            cmdcreateuser.CommandType = System.Data.CommandType.StoredProcedure;
            cmdcreateuser.Parameters.AddWithValue("@Username", Username);
            cmdcreateuser.Parameters.AddWithValue("@Password", PasswordHash.HashPassword(Password));
            cmdcreateuser.CommandText = "sp_createStudent1";
            cmdcreateuser.Connection.Open();
            
            // ExecuteScalar() returns back data type Object
            // Use a typecast to convert this to an int.
            // Method returns first column of first row.
            cmdcreateuser.ExecuteScalar();
            cmdcreateuser.Connection.Close();

            SqlCommand cmdcreateauth = new SqlCommand();
            cmdcreateauth.Connection = AuthConnection;
            cmdcreateauth.Connection.ConnectionString = AuthConnString;

            cmdcreateauth.CommandType = System.Data.CommandType.StoredProcedure;
            cmdcreateauth.Parameters.AddWithValue("@Username", Username);
            cmdcreateauth.Parameters.AddWithValue("@Password", Password);
            cmdcreateauth.CommandText = "sp_authlogin1";
            cmdcreateauth.Connection.Open();

            cmdcreateauth.ExecuteScalar();
            cmdcreateauth.Connection.Close();
        }

        public static void CreateFacultyHashedUser(string Username, string Password)
        {

            SqlCommand cmdcreateuser = new SqlCommand();
            cmdcreateuser.Connection = AuthConnection;
            cmdcreateuser.Connection.ConnectionString = AuthConnString;

            cmdcreateuser.CommandType = System.Data.CommandType.StoredProcedure;
            cmdcreateuser.Parameters.AddWithValue("@Username", Username);
            cmdcreateuser.Parameters.AddWithValue("@Password", PasswordHash.HashPassword(Password));
            cmdcreateuser.CommandText = "sp_createFaculty1";
            cmdcreateuser.Connection.Open();

            // ExecuteScalar() returns back data type Object
            // Use a typecast to convert this to an int.
            // Method returns first column of first row.
            cmdcreateuser.ExecuteScalar();
            cmdcreateuser.Connection.Close();


            SqlCommand cmdcreateauth = new SqlCommand();
            cmdcreateauth.Connection = AuthConnection;
            cmdcreateauth.Connection.ConnectionString = AuthConnString;

            cmdcreateauth.CommandType = System.Data.CommandType.StoredProcedure;
            cmdcreateauth.Parameters.AddWithValue("@Username", Username);
            cmdcreateauth.Parameters.AddWithValue("@Password", Password);
            cmdcreateauth.CommandText = "sp_authlogin1";
            cmdcreateauth.Connection.Open();
            

            cmdcreateauth.ExecuteScalar();
            cmdcreateauth.Connection.Close();
        }


    }

}
