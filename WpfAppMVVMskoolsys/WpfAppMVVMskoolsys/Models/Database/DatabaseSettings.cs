using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppMVVMskoolsys.Models.Database
{
    class DatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CollectionClasses { get; set; }
        public string CollectionTeachers { get; set; }
        public string CollectionStudents { get; set; }
    }
}
