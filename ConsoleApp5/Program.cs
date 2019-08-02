
using System;
using System.Data.SQLite;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            // NewMethod();

            SqlLiteManager manager = new SqlLiteManager();

            manager.Insert("insert into test(id,text) values(6,'deneme 6')");

            var lst = manager.GetList("select * from test");

            foreach (var item in lst)
            {
                Console.WriteLine(item);
            }
        }


        private static void NewMethod()
        {
            // [snip] - As C# is purely object-oriented the following lines must be put into a class:

            // We use these three SQLite objects:
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;

            // create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=database1.db;Version=3;New=True;Compress=true;");

            // open the connection:
            sqlite_conn.Open();

            // create a new SQL command:

            sqlite_cmd = sqlite_conn.CreateCommand();

            // Let the SQLiteCommand object know our SQL-Query:
            // sqlite_cmd.CommandText = "CREATE TABLE test (id integer primary key, text varchar(100));";

            // Now lets execute the SQL ;D
            // sqlite_cmd.ExecuteNonQuery();

            // Lets insert something into our new table:
            sqlite_cmd.CommandText = "INSERT INTO test (id, text) VALUES (3,'Test Text 3');";

            // And execute this again ;D
            sqlite_cmd.ExecuteNonQuery();

            // ...and inserting another line:
            sqlite_cmd.CommandText = "INSERT INTO test (id, text) VALUES (4, 'Test Text ');";

            // And execute this again ;D
            sqlite_cmd.ExecuteNonQuery();

            // But how do we read something out of our table ?
            // First lets build a SQL-Query again:
            sqlite_cmd.CommandText = "SELECT * FROM test";

            // Now the SQLiteCommand object can give us a DataReader-Object:
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            // The SQLiteDataReader allows us to run through the result lines:
            while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
            {
                // Print out the content of the text field:
                System.Console.WriteLine(sqlite_datareader["text"]);
            }

            // We are ready, now lets cleanup and close our connection:
            sqlite_conn.Close();
        }
    }
}