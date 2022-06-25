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

        public PageTeachersVM()
        {
            _teacherRecord = new Models.Teachers.TeacherRecord();
            _teacherEntity = new Models.Teachers.TeacherEntity();
            _schoolRepository = new DataAccess.SchoolRepository();

            _showCreateWindowCommand = new RelayCommand(param => ShowCreateWindow(), null);
            _createTeacherCommand = new RelayCommand(param => CreateTeacher(), null);
            GetAll();
        }

        public void ShowCreateWindow()
        {
            Views.Teachers.WindowCreateTeacher windowCreateTeacher = new Views.Teachers.WindowCreateTeacher();
            windowCreateTeacher.ShowDialog();
        }

        public void CreateTeacher()
        {
            _teacherEntity.FirstName = _teacherRecord.FirstName;
            _teacherEntity.LastName = _teacherRecord.LastName;
            _teacherEntity.Birthday = _teacherRecord.Birthday;
            _teacherEntity.Degree = _teacherRecord.Degree;
            _teacherEntity.Salary = _teacherRecord.Salary;
            try
            {
                _schoolRepository.CreateTeacher(_teacherEntity);
            }
            catch (Exception ex) { MessageBox.Show($"Something went wrong.\n{ex.ToString()}", "error"); }
            finally
            {
                MessageBox.Show($"Techer '{_teacherEntity.FullName}' has been created!", "Success");
                GetAll();
                ResetData();
            }
        }

        public void ResetData()
        {
            _teacherEntity.FirstName = String.Empty;
            _teacherEntity.LastName = String.Empty;
            _teacherEntity.Birthday = null;
            _teacherEntity.Degree = String.Empty;
            _teacherEntity.Salary = null;
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
                Salary = data.Salary
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
    }
}
