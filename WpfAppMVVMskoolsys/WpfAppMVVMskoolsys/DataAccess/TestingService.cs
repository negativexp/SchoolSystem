using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WpfAppMVVMskoolsys.DataAccess
{
    class TestingService
    {
        SchoolRepository schoolRepository;
        string[] Names;
        string[] Degress = { "Associate", "bachelor's", "master's", "doctoral" };

        public TestingService()
        {
            schoolRepository = new SchoolRepository();
            Names = File.ReadAllLines("Names.txt");
        }

        public void GenerateStudents()
        {
            for (int i = 0; i < 11; i++)
            {
                Random rdm = new Random();
                Models.Students.StudentEntity student = new Models.Students.StudentEntity();
                student.FirstName = Names[rdm.Next(Names.Length)];
                student.LastName = Names[rdm.Next(Names.Length)];
                student.Birthday = "01/01/2000";
                student.PhoneNumber = Convert.ToString(rdm.Next(0, 999999999));
                student.MothersName = Names[rdm.Next(Names.Length)];
                student.FathersName = Names[rdm.Next(Names.Length)];
                schoolRepository.CreateStudent(student);
            }
        }

        public void GenerateTeachers()
        {
            for (int i = 0; i < 11; i++)
            {
                Random rdm = new Random();
                Models.Teachers.TeacherEntity teacher = new Models.Teachers.TeacherEntity();
                teacher.FirstName = Names[rdm.Next(Names.Length)];
                teacher.LastName = Names[rdm.Next(Names.Length)];
                teacher.Birthday = "00/00/0000";
                teacher.PhoneNumber = Convert.ToString(rdm.Next(0, 999999999));
                teacher.Degree = Degress[rdm.Next(Degress.Length)];
                teacher.Salary = rdm.Next(30000, 999999);
                schoolRepository.CreateTeacher(teacher);
            }
        }
    }
}
