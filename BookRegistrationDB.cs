using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegister
{
    static class BookRegistrationDB
    {
        public static List<Registration> GetRegistrations()
        {
            SqlConnection connectDB = DbHelper.GetConnection();
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandText = "SELECT CustomerID, " +
                "ISBN, " +
                "RegDate " +
                "FROM Registration";
            sqlCMD.Connection = connectDB;
            connectDB.Open();

            SqlDataReader dataReader = sqlCMD.ExecuteReader();
            List<Registration> allRegistrations = new List<Registration>();

            while (dataReader.Read())
            {
                Registration registrationTemp = new Registration
                {
                    CustomerID = Convert.ToInt32(dataReader["CustomerID"]),
                    ISBN = Convert.ToString(dataReader["ISBN"]),
                    RegDate = Convert.ToDateTime(dataReader["RegDate"])
                };
                allRegistrations.Add(registrationTemp);
            }
            connectDB.Close();
            return allRegistrations;
        }

        public static void AddRegistration(Registration registration)
        {
            SqlConnection connectDB = DbHelper.GetConnection();
            SqlCommand sqlInsertCMD = new SqlCommand();
            sqlInsertCMD.Connection = connectDB;
            sqlInsertCMD.CommandText =
                "INSERT INTO Registration (CustomerID, ISBN, RegDate)" +
                "VALUES(@CustomerID, @ISBN, @RegDate)";
            sqlInsertCMD.Parameters.AddWithValue("@CustomerID", registration.CustomerID);
            sqlInsertCMD.Parameters.AddWithValue("@ISBN", registration.ISBN);
            sqlInsertCMD.Parameters.AddWithValue("@RegDate", registration.RegDate);

            connectDB.Open();
            sqlInsertCMD.ExecuteNonQuery();
            connectDB.Close();
        }

    }

}

