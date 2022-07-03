using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MongoDB.Bson;

namespace WpfAppMVVMskoolsys.DataAccess
{
    class SchoolRepository
    {
        string connectionString = "";
        string databaseName = "";
        string CollectionClasses = "";
        string CollectionTeachers = "";
        string CollectionStudents = "";

        private DataAccess.DatabaseSettings databaseSettings = new DataAccess.DatabaseSettings();

        MongoHelper database;

        public SchoolRepository()
        {
            if(File.Exists("db-settings.txt"))
            {
                string[] data = databaseSettings.LoadSettings();
                connectionString = data[0];
                databaseName = data[1];
                CollectionClasses = data[2];
                CollectionTeachers = data[3];
                CollectionStudents = data[4];
            }
            database = new MongoHelper(connectionString, databaseName);
        }

        //classes
        public void CreateClass(Models.ClassEntity _class)
        {
            database.InsertDocument<Models.ClassEntity>(CollectionClasses, _class);
        }

        public List<Models.ClassEntity> GetAllClasses()
        {
            return database.LoadAllDocuments<Models.ClassEntity>(CollectionClasses);
        }

        public void DeleteClass(Models.ClassEntity _class)
        {
            ObjectId id = ObjectId.Parse(_class.Id);
            database.DeleteDocument<Models.ClassEntity>(CollectionClasses, id);
        }

        //teachers
        public void CreateTeacher(Models.Teachers.TeacherEntity _teacher)
        {
            database.InsertDocument<Models.Teachers.TeacherEntity>(CollectionTeachers, _teacher);
        }

        public List<Models.Teachers.TeacherEntity> GetAllTeachers()
        {
            return database.LoadAllDocuments<Models.Teachers.TeacherEntity>(CollectionTeachers);
        }

        public void DeleteTeacher(Models.Teachers.TeacherEntity _teacher)
        {
            ObjectId id = ObjectId.Parse(_teacher.Id);
            database.DeleteDocument<Models.Teachers.TeacherEntity>(CollectionTeachers, id);
        }

        //students
        public void CreateStudent(Models.Students.StudentEntity _student)
        {
            database.InsertDocument<Models.Students.StudentEntity>(CollectionStudents, _student);
        }

        public List<Models.Students.StudentEntity> GetAllStudents()
        {
            return database.LoadAllDocuments<Models.Students.StudentEntity>(CollectionStudents);
        }

        public void DeleteStudent(Models.Students.StudentEntity _student)
        {
            ObjectId id = ObjectId.Parse(_student.Id);
            database.DeleteDocument<Models.Students.StudentEntity>(CollectionStudents, id);
        }
    }
}
