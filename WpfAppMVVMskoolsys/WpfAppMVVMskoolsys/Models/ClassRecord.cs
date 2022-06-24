using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace WpfAppMVVMskoolsys.Models
{
    class ClassRecord : ViewModels.ViewModelBase
    {
        private ObservableCollection<ClassRecord> _classRecords;
        public ObservableCollection<ClassRecord> ClassRecords
        {
            get => _classRecords;
            set
            {
                _classRecords = value;
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

        private void ClassRecord_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged();
        }
    }
}
