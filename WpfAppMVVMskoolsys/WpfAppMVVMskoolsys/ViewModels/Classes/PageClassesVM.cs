using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace WpfAppMVVMskoolsys.ViewModels.Classes
{
    class PageClassesVM
    {
        public Models.ClassRecord _classRecord { get; set; }
        private Models.ClassEntity _classEntity;
        private DataAccess.SchoolRepository _schoolRepository;

        ICommand _showCreateWindowCommand;
        ICommand _createClassCommand;

        public PageClassesVM()
        {
            _schoolRepository = new DataAccess.SchoolRepository();
            _classRecord = new Models.ClassRecord();
            _classEntity = new Models.ClassEntity();

            _showCreateWindowCommand = new RelayCommand(param => ShowCreateWindow(), null);
            _createClassCommand = new RelayCommand(param => CreateClass(), null);
        }

        public void ShowCreateWindow()
        {
            Views.Classes.WindowCreateClass windowCreateClass = new Views.Classes.WindowCreateClass();
            windowCreateClass.Show();
        }

        public void CreateClass()
        {
            MessageBox.Show("is this working?");
            _classEntity.ClassName = _classRecord.ClassName;
            _classEntity.Grade = _classRecord.Grade;
            _classEntity.RootTeacher = _classRecord.RootTeacher;
            _schoolRepository.CreateClass(_classEntity);
            ResetData();
        }

        public void ResetData()
        {
            _classEntity.ClassName = String.Empty;
            _classEntity.Grade = String.Empty;
            _classEntity.RootTeacher = String.Empty;
        }

        public ICommand ShowCreateWindowCommand
        {
            get => _showCreateWindowCommand;
        }
        public ICommand CreateClassCommand
        {
            get => _createClassCommand;
        }
    }
}
