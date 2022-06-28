using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows;

namespace WpfAppMVVMskoolsys.ViewModels.Students
{
    class PageStudentsVM
    {
        private Models.Students.StudentEntity _studentEntity;
        public Models.Students.StudentRecord _studentRecord { get; set; }
        private DataAccess.SchoolRepository _schoolRepository;

        ICommand _showCreateWindowCommand;
        ICommand _createStudentCommand;

        public PageStudentsVM()
        {
            _studentEntity = new Models.Students.StudentEntity();
            _schoolRepository = new DataAccess.SchoolRepository();
            _studentRecord = new Models.Students.StudentRecord();

            _showCreateWindowCommand = new RelayCommand(param => ShowCreateWindow(), null);
            _createStudentCommand = new RelayCommand(param => CreateStudent(), null);
            GetAll();
        }

        public void ShowCreateWindow()
        {
            Views.Students.WindowCreateStudent windowCreateStudent = new Views.Students.WindowCreateStudent();
            windowCreateStudent.ShowDialog();
            GetAll();
        }

        public void CreateStudent()
        {
            _studentEntity.FirstName = _studentRecord.FirstName;
            _studentEntity.LastName = _studentRecord.LastName;
            _studentEntity.Birthday = _studentRecord.Birthday;
            _studentEntity.PhoneNumber = _studentRecord.PhoneNumber;
            _studentEntity.MothersName = _studentRecord.MothersName;
            _studentEntity.FathersName = _studentRecord.FathersName;
            try
            {
                _schoolRepository.CreateStudent(_studentEntity);
            }
            catch (Exception ex) { MessageBox.Show($"Something went wrong.\n{ex.ToString()}", "error"); }
            finally
            {
                MessageBox.Show($"Student '{_studentEntity.FullName}' has been created!", "Success");
                GetAll();
                ResetData();
            }
        }

        public void ResetData()
        {
            _studentEntity.Id = String.Empty;
            _studentEntity.FirstName = String.Empty;
            _studentEntity.LastName = String.Empty;
            _studentEntity.Birthday = String.Empty;
            _studentEntity.PhoneNumber = String.Empty;
            _studentEntity.MothersName = String.Empty;
            _studentEntity.FathersName = String.Empty;
        }

        public void GetAll()
        {
            _studentRecord.StudentRecords = new List<Models.Students.StudentEntity>();
            _schoolRepository.GetAllStudents().ForEach(data => _studentRecord.StudentRecords.Add(new Models.Students.StudentEntity()
            {
                Id = data.Id,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Birthday = data.Birthday,
                PhoneNumber = data.PhoneNumber,
                MothersName = data.MothersName,
                FathersName = data.FathersName
            }));
        }

        public ICommand ShowCreateWindowCommand
        {
            get => _showCreateWindowCommand;
        }

        public ICommand CreateStudentCommand
        {
            get => _createStudentCommand;
        }
    }
}
