using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace WpfAppMVVMskoolsys.Models
{
    class ClassRecord : ViewModels.ViewModelBase
    {
        private List<ClassEntity> _classRecords;
        public List<ClassEntity> ClassRecords
        {
            get => _classRecords;
            set
            {
                _classRecords = value;
                OnPropertyChanged();
            }
        }
        private string _id;
        public string Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }
        private string _className;
        public string ClassName
        {
            get => _className;
            set
            {
                _className = value;
                OnPropertyChanged();
            }
        }
        private string _grade;
        public string Grade
        {
            get => _grade;
            set
            {
                _grade = value;
                OnPropertyChanged();
            }
        }
        private string _rootTeacher;
        public string RootTeacher
        {
            get => _rootTeacher;
            set
            {
                _rootTeacher = value;
                OnPropertyChanged();
            }
        }
        private Dictionary<string, string> _students;
        public Dictionary<string, string> Students
        {
            get => _students;
            set
            {
                _students = value;
                OnPropertyChanged();
            }
        }

        private void ClassRecord_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged();
        }
    }
}
