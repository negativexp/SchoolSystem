﻿using System;
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
            Teachers = new List<string>();

            _showCreateWindowCommand = new RelayCommand(param => ShowCreateWindow(), null);
            _createClassCommand = new RelayCommand(param => CreateClass(), null);
            _refreshCommand = new RelayCommand(param => GetAll(), null);

            GetAllTeachers();
            GetAll();
        }

        public void ShowCreateWindow()
        {
            Views.Classes.WindowCreateClass windowCreateClass = new Views.Classes.WindowCreateClass();
            windowCreateClass.ShowDialog();
            GetAll();
        }

        public void CreateClass()
        {
            _classEntity.ClassName = _classRecord.ClassName;
            _classEntity.Grade = _classRecord.Grade;
            _classEntity.RootTeacher = _classRecord.RootTeacher;
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

        public void ResetData()
        {
            _classEntity.Id = String.Empty;
            _classEntity.ClassName = String.Empty;
            _classEntity.Grade = String.Empty;
            _classEntity.RootTeacher = String.Empty;
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
            _teacherRecord.TeacherRecords = new List<Models.Teachers.TeacherEntity>();
            _schoolRepository.GetAllTeachers().ForEach(data => Teachers.Add(data.FullName));
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
