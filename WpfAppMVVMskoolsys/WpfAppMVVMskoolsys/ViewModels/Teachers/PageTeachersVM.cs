using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows;

namespace WpfAppMVVMskoolsys.ViewModels.Teachers
{
    class PageTeachersVM
    {
        public Models.Teachers.TeacherRecord _teacherRecord { get; set; }
        private Models.Teachers.TeacherEntity _teacherEntity;
        private DataAccess.SchoolRepository _schoolRepository;

        ICommand _showCreateWindowCommand;
        ICommand _createTeacherCommand;
        ICommand _deleteStudentCommand;
        ICommand _refreshCommand;

        public PageTeachersVM()
        {
            _teacherRecord = new Models.Teachers.TeacherRecord();
            _teacherEntity = new Models.Teachers.TeacherEntity();
            _schoolRepository = new DataAccess.SchoolRepository();

            _showCreateWindowCommand = new RelayCommand(param => ShowCreateWindow(), null);
            _createTeacherCommand = new RelayCommand(param => CreateTeacher(), null);
            _deleteStudentCommand = new RelayCommand(param => DeleteTeacher(param), null);
            _refreshCommand = new RelayCommand(param => GetAll(), null);
            GetAll();
        }

        public void ShowCreateWindow()
        {
            Views.Teachers.WindowCreateTeacher windowCreateTeacher = new Views.Teachers.WindowCreateTeacher();
            windowCreateTeacher.ShowDialog();
            GetAll();
        }

        public void CreateTeacher()
        {
            _teacherEntity.FirstName = _teacherRecord.FirstName;
            _teacherEntity.LastName = _teacherRecord.LastName;
            _teacherEntity.Birthday = _teacherRecord.Birthday;
            _teacherEntity.Degree = _teacherRecord.Degree;
            _teacherEntity.Salary = _teacherRecord.Salary;
            _teacherEntity.PhoneNumber = _teacherRecord.PhoneNumber;

            if(string.IsNullOrEmpty(_teacherRecord.FirstName) || string.IsNullOrEmpty(_teacherRecord.LastName) ||
               string.IsNullOrEmpty(_teacherRecord.Birthday))
            {
                MessageBox.Show("Please fill all the information about the teacher!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    _schoolRepository.CreateTeacher(_teacherEntity);
                }
                catch (Exception ex) { MessageBox.Show($"Something went wrong.\n{ex.ToString()}", "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
                finally
                {
                    MessageBox.Show($"Techer '{_teacherEntity.FullName}' has been created!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    GetAll();
                    ResetData();
                }
            }
        }

        public void DeleteTeacher(object obj)
        {
            System.Windows.Controls.DataGrid data = obj as System.Windows.Controls.DataGrid;
            string names = "";

            if (data.SelectedItems.Count > 0)
            {
                foreach (Models.Teachers.TeacherEntity _teacher in data.SelectedItems)
                {
                    names += $"\"{_teacher.FullName}\", ";
                }
                names = names.Remove(names.Length - 2);
                if (MessageBox.Show($"{names} Will be deleted. Are you sure?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    foreach (Models.Teachers.TeacherEntity _teacher in data.SelectedItems)
                    {
                        _schoolRepository.DeleteTeacher(_teacher);
                    }
                    MessageBox.Show("Done!", "Sucess", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            GetAll();
        }

        public void ResetData()
        {
            _teacherEntity.Id = String.Empty;
            _teacherEntity.FirstName = String.Empty;
            _teacherEntity.LastName = String.Empty;
            _teacherEntity.Birthday = null;
            _teacherEntity.Degree = String.Empty;
            _teacherEntity.Salary = 0;
            _teacherEntity.PhoneNumber = String.Empty;
        }

        public void GetAll()
        {
            _teacherRecord.TeacherRecords = new List<Models.Teachers.TeacherEntity>();
            _schoolRepository.GetAllTeachers().ForEach(data => _teacherRecord.TeacherRecords.Add(new Models.Teachers.TeacherEntity()
            {
                Id = data.Id,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Birthday = data.Birthday,
                Degree = data.Degree,
                Salary = data.Salary,
                PhoneNumber = data.PhoneNumber
            }));
        }

        public ICommand ShowCreateWindowCommand
        {
            get => _showCreateWindowCommand;
        }

        public ICommand CreateTeacherCommand
        {
            get => _createTeacherCommand;
        }

        public ICommand DeleteTeacherCommand
        {
            get => _deleteStudentCommand;
        }

        public ICommand RefreshCommand
        {
            get => _refreshCommand;
        }
    }
}
