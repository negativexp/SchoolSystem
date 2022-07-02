using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows;

namespace WpfAppMVVMskoolsys.ViewModels.Classes
{
    class PageClassesVM
    {
        public Models.ClassRecord _classRecord { get; set; }
        public Models.Teachers.TeacherRecord _teacherRecord { get; set; }
        private Models.ClassEntity _classEntity;
        private DataAccess.SchoolRepository _schoolRepository;


        ICommand _showCreateWindowCommand;
        ICommand _createClassCommand;
        ICommand _refreshCommand;

        public PageClassesVM()
        {
            _schoolRepository = new DataAccess.SchoolRepository();
            _classRecord = new Models.ClassRecord();
            _classEntity = new Models.ClassEntity();
            _teacherRecord = new Models.Teachers.TeacherRecord();

            _showCreateWindowCommand = new RelayCommand(param => ShowCreateWindow(), null);
            _createClassCommand = new RelayCommand(param => CreateClass(param), null);
            _refreshCommand = new RelayCommand(param => GetAll(), null);

            CreateGradeList();
            GetAllTeachers();
            GetAllStudents();
            GetAll();
        }

        public void ShowCreateWindow()
        {
            Views.Classes.WindowCreateClass windowCreateClass = new Views.Classes.WindowCreateClass();
            windowCreateClass.ShowDialog();
            GetAll();
        }

        public void CreateClass(object obj)
        {
            System.Windows.Controls.ListBox listbox = obj as System.Windows.Controls.ListBox;

            _classEntity.ClassName = _classRecord.ClassName;
            _classEntity.Grade = _classRecord.Grade;
            _classEntity.RootTeacher = _classRecord.RootTeacher;
            _classEntity.Students = new Dictionary<string, string>();

            foreach (Models.Students.StudentEntity item in listbox.SelectedItems)
            {
                _classEntity.Students.Add(item.Id, item.FullName);
            }

            if (string.IsNullOrEmpty(_classRecord.ClassName) || string.IsNullOrEmpty(_classRecord.Grade) ||
               string.IsNullOrEmpty(_classRecord.RootTeacher) || _classEntity.Students.Count == 0)
            {
                MessageBox.Show("Please fill all the information about the class!", "Error");
            }
            else
            {
                try
                {
                    _schoolRepository.CreateClass(_classEntity);
                }
                catch (Exception ex) { MessageBox.Show($"Something went wrong.\n{ex.ToString()}", "error"); }
                finally
                {
                    MessageBox.Show($"Class '{_classEntity.ClassName}' has been created!", "Success");
                    GetAll();
                    ResetData();
                }
            }
        }

        public void ResetData()
        {
            _classEntity.Id = String.Empty;
            _classEntity.ClassName = String.Empty;
            _classEntity.Grade = String.Empty;
            _classEntity.RootTeacher = String.Empty;
            _classEntity.Students.Clear();
        }

        public void GetAll()
        {
            _classRecord.ClassRecords = new List<Models.ClassEntity>();
            _schoolRepository.GetAllClasses().ForEach(data => _classRecord.ClassRecords.Add(new Models.ClassEntity()
            {
                Id = data.Id,
                ClassName = data.ClassName,
                Grade = data.Grade,
                RootTeacher = data.RootTeacher
            }));
        }

        public void GetAllTeachers()
        {
            //_teacherRecord.TeacherRecords = new List<Models.Teachers.TeacherEntity>();
            Teachers = new List<string>();
            _schoolRepository.GetAllTeachers().ForEach(data => Teachers.Add(data.FullName));
        }

        public void GetAllStudents()
        {
            Students = new List<Models.Students.StudentEntity>();
            _schoolRepository.GetAllStudents().ForEach(data => Students.Add(data));
        }

        public void CreateGradeList()
        {
            Grades = new List<string>();
            Grades.Add("1st");
            Grades.Add("2nd");
            Grades.Add("3rd");
            Grades.Add("4th");
            Grades.Add("5th");
            Grades.Add("6th");
            Grades.Add("7th");
            Grades.Add("8th");
            Grades.Add("9th");
            Grades.Add("10th");
            Grades.Add("11th");
            Grades.Add("12th");
        }

        private List<Models.Students.StudentEntity> _students;
        public List<Models.Students.StudentEntity> Students
        {
            get => _students;
            set
            {
                _students = value;
            }
        }

        private List<string> _teachers;
        public List<string> Teachers
        {
            get => _teachers;
            set
            {
                _teachers = value;
            }
        }

        private List<string> _grades;
        public List<string> Grades
        {
            get => _grades;
            set
            {
                _grades = value;
            }
        }

        public ICommand ShowCreateWindowCommand
        {
            get => _showCreateWindowCommand;
        }

        public ICommand CreateClassCommand
        {
            get => _createClassCommand;
        }

        public ICommand RefreshCommand
        {
            get => _refreshCommand;
        }
    }
}
