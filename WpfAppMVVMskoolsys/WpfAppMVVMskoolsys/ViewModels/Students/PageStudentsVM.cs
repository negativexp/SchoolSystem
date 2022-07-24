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
        ICommand _deleteStudentCommand;

        public PageStudentsVM()
        {
            _studentEntity = new Models.Students.StudentEntity();
            _schoolRepository = new DataAccess.SchoolRepository();
            _studentRecord = new Models.Students.StudentRecord();

            _showCreateWindowCommand = new RelayCommand(param => ShowCreateWindow(), null);
            _createStudentCommand = new RelayCommand(param => CreateStudent(), null);
            _deleteStudentCommand = new RelayCommand(param => DeleteStudent(param), null);

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

            if (string.IsNullOrEmpty(_studentRecord.FirstName) || string.IsNullOrEmpty(_studentRecord.LastName) ||
                string.IsNullOrEmpty(_studentRecord.Birthday))
            {
                MessageBox.Show("Please fill all the information about the student!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    _schoolRepository.CreateStudent(_studentEntity);
                }
                catch (Exception ex) { MessageBox.Show($"Something went wrong.\n{ex.ToString()}", "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
                finally
                {
                    MessageBox.Show($"Student '{_studentEntity.FullName}' has been created!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    GetAll();
                    ResetData();
                }
            }
        }

        public void DeleteStudent(object obj)
        {
            System.Windows.Controls.DataGrid data = obj as System.Windows.Controls.DataGrid;
            string names = "";

            if (data.SelectedItems.Count > 0)
            {
                foreach (Models.Students.StudentEntity _student in data.SelectedItems)
                {
                    names += $"\"{_student.FullName}\", ";
                }
                names = names.Remove(names.Length - 2);
                if (MessageBox.Show($"{names} Will be deleted. Are you sure?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    foreach (Models.Students.StudentEntity _student in data.SelectedItems)
                    {
                        _schoolRepository.DeleteStudent(_student);
                    }
                    MessageBox.Show("Done!", "Sucess", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            GetAll();
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

        public ICommand DeleteStudentCommand
        {
            get => _deleteStudentCommand;
        }

        public ICommand CreateStudentCommand
        {
            get => _createStudentCommand;
        }
    }
}
