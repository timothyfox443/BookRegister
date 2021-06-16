using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegister
{
    static class DbHelper
    {
        public static SqlConnection GetConnection()
        {
            //create connection to DB
            SqlConnection connectDB =
                new SqlConnection("Data Source=localhost;" +
                                    "Initial Catalog=BookRegistration;" +
                                    "Integrated Security=True;");
            //SqlConnection con = new SqlConnection();
            //con.ConnectionString = "some connection string";
            return connectDB;
        }
    }
}
