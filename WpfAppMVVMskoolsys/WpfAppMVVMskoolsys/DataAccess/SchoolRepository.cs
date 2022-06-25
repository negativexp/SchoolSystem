using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppMVVMskoolsys.DataAccess
{
    class SchoolRepository
    {
        string connectionString = "mongodb://localhost:27017";
        string databaseName = "schoolsys_db";
        string CollectionClasses = "classes";

        MongoHelper database;

        public SchoolRepository()
        {
            database = new MongoHelper(connectionString, databaseName);
        }

        public void CreateClass(Models.ClassEntity _class)
        {
            database.InsertDocument<Models.ClassEntity>(CollectionClasses, _class);
        }

        public List<Models.ClassEntity> GetAll()
        {
            return database.LoadAllDocuments<Models.ClassEntity>(CollectionClasses);
        }
    }
}
