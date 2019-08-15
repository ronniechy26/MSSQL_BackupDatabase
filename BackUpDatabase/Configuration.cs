using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BackUpDatabase
{
    public class Configuration
    {

        public static string ConnectionString = 
            GetItem(AppDomain.CurrentDomain.BaseDirectory + @"\Settings.ini", "ConnectionString");
        public static string Destination = 
            GetItem(AppDomain.CurrentDomain.BaseDirectory + @"\Settings.ini", "Destination");
        public static string DatabaseName = 
            GetItem(AppDomain.CurrentDomain.BaseDirectory + @"\Settings.ini", "Databasename");

        public static string GetItem(string path, string Identifier)
        {
            StreamReader file = new StreamReader(path);
            string Result = "";
            do
            {
                string Line = file.ReadLine();
                if (Line.ToLower().StartsWith(Identifier.ToLower() + "="))
                {
                    Result = Line.Substring(Identifier.Length + 2);
                }
            } while (file.Peek() != -1);
            return Result;
        }
    }
    
}
