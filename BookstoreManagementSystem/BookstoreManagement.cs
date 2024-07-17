using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;
namespace BookstoreManagementSystem
{
    internal class BookstoreManagement
    {
        public BookstoreManagement() {
            using MySqlConnection connection = GetConnection();
            connection.Open();
            Console.WriteLine("Database connected!");

            while (true)
            {
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Update Book");
                Console.WriteLine("3. Delete Book");
                Console.WriteLine("4. View All Books");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        //call AddBook method
                        break;
                    case 2:
                        // Call UpdateBook method
                        break;
                    case 3:
                        // Call DeleteBook method
                        break;
                    case 4:
                        // Call ViewAllBooks method
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }

            connection.Close();
            Console.WriteLine("Database connection closed.");



        }

        public MySqlConnection GetConnection()
        {
            MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder();
            sb.Server = "localhost";
            sb.UserID = "root";
            sb.Database = "BookstoreDB";
            MySqlConnection connection = new MySqlConnection(sb.ToString());
            return connection;
        }

        public void AddBook(MySqlConnection connection, string title, int authorID, decimal price, string isbn)
        {
            string query = "Insert INTO Books (Title, AuthorID, Price, ISBN)" +
                "VALUES(@Title, @AuthorID, @Price, @ISBN)";
            using MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Title", title);
            command.Parameters.AddWithValue("@AuthorID", authorID);
            command.Parameters.AddWithValue("@Price", price);
            command.Parameters.AddWithValue("@ISBN", isbn);
            command.ExecuteNonQuery();
        }





        static void Main(string[] args)
        {
            new BookstoreManagement();
        }
    }
}
