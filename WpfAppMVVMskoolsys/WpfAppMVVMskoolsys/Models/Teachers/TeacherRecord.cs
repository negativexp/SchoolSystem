using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace WpfAppMVVMskoolsys.Models.Teachers
{
    class TeacherRecord : ViewModels.ViewModelBase
    {
        private List<TeacherEntity> _teacherRecords;
        public List<TeacherEntity> TeacherRecords
        {
            get => _teacherRecords;
            set
            {
                _teacherRecords = value;
                OnPropertyChanged();
            }
        }
        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }
        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }
        private DateTime _birthday;
        public DateTime Birthday
        {
            get => _birthday;
            set
            {
                _birthday = value;
                OnPropertyChanged();
            }
        }
        private string _degree;
        public string Degree
        {
            get => _degree;
            set
            {
                _degree = value;
                OnPropertyChanged();
            }
        }
        private int _salary;
        public int Salary
        {
            get => _salary;
            set
            {
                _salary = value;
                OnPropertyChanged();
            }
        }

        private void TeacherRecord_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged();
        }
    }
}
