using System;
using System.Data.SqlClient;
using System.IO;
using System.Threading;


namespace BackUpDatabase
{
    class Program
    {
        static void Main(string[] args)
        {

            string ConnectionString = Configuration.ConnectionString;
            ConnectionString = ConnectionString.Replace("\\\\","\\");

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection { ConnectionString = ConnectionString })
                {
                    sqlConnection.Open();

                    Console.WriteLine("Creating back up file....");
                    Thread.Sleep(2000);
                    string path = $@"BACKUP DATABASE ""{Configuration.DatabaseName}"" TO DISK='{Path.Combine(Configuration.Destination,
                                   "navy_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".bak")}'";
                    SqlCommand sqlCommand = new SqlCommand(path, sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();

                    Console.WriteLine($"Successful......");
                    Console.WriteLine();
                } 

            } catch (Exception)
            {
                Console.WriteLine("Error cannot connect to the database...");
                Thread.Sleep(1000);
            }
            Console.WriteLine("Current Path Location: " + AppDomain.CurrentDomain.BaseDirectory);
            Console.WriteLine("Back Up Database Location  : " + Configuration.Destination);
            Console.WriteLine("Database Name : "+ Configuration.DatabaseName);
            Console.WriteLine("ConnectionString " + Configuration.ConnectionString);
            Thread.Sleep(1000);
            Console.WriteLine("bye...");
            Thread.Sleep(200);
        }
    }
}
