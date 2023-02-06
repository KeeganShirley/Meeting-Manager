using Meeting_Manager.Pages.DataClasses;
using System.Data.SqlClient;

namespace Meeting_Manager.Pages.DB
{
    public class DBClass
    {
        // Connection at the Class Level
        public static SqlConnection MeetingManagerDBConnection = new SqlConnection();

        // Connection String
        private static readonly String? MeetingManagerDBConnString = "Server=Localhost;Database=OfficeHours;Trusted_Connection=True";

        public static SqlDataReader StudentReader()
        {
            SqlCommand cmdProductRead = new SqlCommand();
            cmdProductRead.Connection = MeetingManagerDBConnection;
            cmdProductRead.Connection.ConnectionString = MeetingManagerDBConnString;
            cmdProductRead.CommandText = "SELECT * FROM STUDENT";

            cmdProductRead.Connection.Open();

            SqlDataReader tempReader = cmdProductRead.ExecuteReader();

            return tempReader;
        }

        public static void InsertProduct(Product p)
        {
            String sqlQuery = "INSERT INTO Product (ProductName, ProductCost, ProductDescription) \r\nVALUES (";
            sqlQuery += "'" + p.ProductName + "',";
            sqlQuery += p.ProductCost + ",'";
            sqlQuery += p.ProductDescription + "')";

            SqlCommand cmdProductReader = new SqlCommand();
            cmdProductReader.Connection = GroceryDBConnection;
            cmdProductReader.Connection.ConnectionString = GroceryDBConnString;
            cmdProductReader.CommandText = sqlQuery;

            cmdProductReader.Connection.Open();

            cmdProductReader.ExecuteNonQuery();

        }



    }
}