using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;

namespace WpfAppMVVMskoolsys.Models.Students
{
    class StudentRecord : ViewModels.ViewModelBase
    {
        private List<StudentEntity> _studentRecords;
        public List<StudentEntity> StudentRecords
        {
            get => _studentRecords;
            set
            {
                _studentRecords = value;
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
        private string _birthday;
        public string Birthday
        {
            get => _birthday;
            set
            {
                _birthday = value;
                OnPropertyChanged();
            }
        }
        private string _phoneNumber;
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                OnPropertyChanged();
            }
        }
        private string _mothersName;
        public string MothersName
        {
            get => _mothersName;
            set
            {
                _mothersName = value;
                OnPropertyChanged();
            }
        }
        private string _fathersName;
        public string FathersName
        {
            get => _fathersName;
            set
            {
                _fathersName = value;
                OnPropertyChanged();
            }
        }
        private void StudentRecord_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged();
        }
    }
}
