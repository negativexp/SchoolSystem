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
            string[] data = File.ReadAllLines("db-settings.txt");
            data[0] = data[0].Replace("connectionString=", "");
            data[1] = data[1].Replace("databaseName=", "");
            data[2] = data[2].Replace("collectionClasses=", "");
            data[3] = data[3].Replace("collectionTeachers=", "");
            data[4] = data[4].Replace("collectionStudents=", "");
            return data;
        }
    }
}
