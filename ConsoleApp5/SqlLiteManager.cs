using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace ConsoleApp5
{
    public class SqlLiteManager
    {
        SQLiteConnection sqlite_conn;
        SQLiteCommand sqlite_cmd;
        SQLiteDataReader sqlite_datareader;



        public SqlLiteManager(string sqlliteConnection = "Data Source= database1.db; Version=3;New=True;Compress=true;")
        {
            sqlite_conn = new SQLiteConnection("Data Source=database1.db;Version=3;New=True;Compress=true;");

            sqlite_cmd = sqlite_conn.CreateCommand();
        }

        public void Insert(string script)
        {
            sqlite_conn.Open();
            sqlite_cmd.CommandText = script;
            sqlite_cmd.ExecuteNonQuery();
            sqlite_conn.Close();
        }


        public List<string> GetList(string script)
        {
            // Let the SQLiteCommand object know our SQL-Query:
            // sqlite_cmd.CommandText = "CREATE TABLE test (id integer primary key, text varchar(100));";

            sqlite_conn.Open();
            sqlite_cmd.CommandText = "SELECT * FROM test";

            // Now the SQLiteCommand object can give us a DataReader-Object:
            sqlite_datareader = sqlite_cmd.ExecuteReader();


            var lst = new List<string>();
            // The SQLiteDataReader allows us to run through the result lines:
            while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
            {
                // Print out the content of the text field:
                lst.Add(sqlite_datareader["id"].ToString() + sqlite_datareader["text"].ToString());
            }

            // We are ready, now lets cleanup and close our connection:
            sqlite_conn.Close();

            return lst;

        }
    }
}