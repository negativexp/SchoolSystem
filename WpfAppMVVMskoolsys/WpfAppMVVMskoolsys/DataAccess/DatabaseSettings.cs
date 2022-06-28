using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace WpfAppMVVMskoolsys.DataAccess
{
    class DatabaseSettings
    {
        public void SaveSettings(string[] data)
        {
            string x = $"connectionString={data[0]}\n" +
                       $"databaseName={data[1]}\n" +
                       $"collectionClasses={data[2]}\n" +
                       $"collectionTeachers={data[3]}\n" +
                       $"collectionStudents={data[4]}\n";

            File.WriteAllText("db-settings.txt", x);
        }

        public string[] LoadSettings()
        {
            string[] returnData = new string[5];
            string[] data = File.ReadAllLines("db-settings.txt");
            returnData[0] = data[0].Replace("connectionString=", "");
            returnData[1] = data[1].Replace("databaseName=", "");
            returnData[2] = data[2].Replace("collectionClasses=", "");
            returnData[3] = data[3].Replace("collectionTeachers=", "");
            returnData[4] = data[4].Replace("collectionStudents=", "");
            return returnData;
        }
    }
}
