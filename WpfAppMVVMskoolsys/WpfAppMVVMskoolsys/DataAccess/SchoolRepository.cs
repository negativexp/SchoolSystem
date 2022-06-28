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
        string CollectionTeachers = "teachers";
        string CollectionStudents = "students";

        MongoHelper database;

        public SchoolRepository()
        {
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

        //teachers
        public void CreateTeacher(Models.Teachers.TeacherEntity _teacher)
        {
            database.InsertDocument<Models.Teachers.TeacherEntity>(CollectionTeachers, _teacher);
        }

        public List<Models.Teachers.TeacherEntity> GetAllTeachers()
        {
            return database.LoadAllDocuments<Models.Teachers.TeacherEntity>(CollectionTeachers);
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
    }
}
