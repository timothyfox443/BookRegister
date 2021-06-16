using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegister
{
    static class CustomerDB
    {
        public static List<Customer> GetAllCustomers()
        {
            SqlConnection connectDB = DbHelper.GetConnection();
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandText = "SELECT CustomerID " +
                ", DateOfBirth " +
                ", FirstName " +
                ", LastName " +
                ", Title " +
                "FROM Customer";
            sqlCMD.Connection = connectDB;
            connectDB.Open();

            SqlDataReader dataReader = sqlCMD.ExecuteReader();
            List<Customer> allCustomer = new List<Customer>();

            while (dataReader.Read())
            {
                Customer customerTemp = new Customer
                {
                    CustomerID = Convert.ToInt32(dataReader["CustomerID"]),
                    DateOfBirth = Convert.ToDateTime(dataReader["DateOfBirth"]),
                    FirstName = Convert.ToString(dataReader["FirstName"]),
                    LastName = Convert.ToString(dataReader["LastName"]),
                    Appelation = Convert.ToString(dataReader["Title"])
                };
                allCustomer.Add(customerTemp);
            }
            connectDB.Close();
            return allCustomer;
        }

        public static void AddCustomer(Customer customer)
        {
            SqlConnection connectDB = DbHelper.GetConnection();
            SqlCommand sqlInsertCMD = new SqlCommand();
            sqlInsertCMD.Connection = connectDB;
            sqlInsertCMD.CommandText =
                "INSERT INTO Customer (DateOfBirth, FirstName, LastName, Title)" +
                "VALUES(@DateOfBirth, @FirstName, @LastName, @Appelation)";
            //sqlInsertCMD.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
            sqlInsertCMD.Parameters.AddWithValue("@DateOfBirth", customer.DateOfBirth);
            sqlInsertCMD.Parameters.AddWithValue("@FirstName", customer.FirstName);
            sqlInsertCMD.Parameters.AddWithValue("@LastName", customer.LastName);
            sqlInsertCMD.Parameters.AddWithValue("@Appelation", customer.Appelation);


            connectDB.Open();
            sqlInsertCMD.ExecuteNonQuery();
            connectDB.Close();
        }

    }
}
