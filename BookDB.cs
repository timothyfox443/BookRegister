using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegister
{
    static class BookDB
    {
        public static List<Book> GetAllBooks()
        {
            SqlConnection connectDB = DbHelper.GetConnection();
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandText = "SELECT ISBN, " +
                "Price, " +
                "Title " +
                "FROM Book";
            sqlCMD.Connection = connectDB;
            connectDB.Open();

            SqlDataReader dataReader = sqlCMD.ExecuteReader();
            List<Book> allBooks = new List<Book>();

            while (dataReader.Read())
            {
                Book bookTemp = new Book
                {
                    ISBN = Convert.ToString(dataReader["ISBN"]),
                    Price= Convert.ToDouble(dataReader["Price"]),
                    Title= Convert.ToString(dataReader["Title"])
                };
                allBooks.Add(bookTemp);
            }
            connectDB.Close();
            return allBooks;
        }

        public static void AddBook(Book book)
        {
            SqlConnection connectDB = DbHelper.GetConnection();
            SqlCommand sqlInsertCMD = new SqlCommand();
            sqlInsertCMD.Connection = connectDB;
            sqlInsertCMD.CommandText =
                "INSERT INTO Book (ISBN, Price, Title)" +
                "VALUES(@ISBN, @Price, @Title)";
            sqlInsertCMD.Parameters.AddWithValue("@ISBN", book.ISBN);
            sqlInsertCMD.Parameters.AddWithValue("@Price", book.Price);
            sqlInsertCMD.Parameters.AddWithValue("@Title", book.Title);

            connectDB.Open();
            sqlInsertCMD.ExecuteNonQuery();
            connectDB.Close();
        }

    }
}
