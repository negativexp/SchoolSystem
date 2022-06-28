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
            foreach(string x in data)
            {
                MessageBox.Show(x);
            }
        }
    }
}
