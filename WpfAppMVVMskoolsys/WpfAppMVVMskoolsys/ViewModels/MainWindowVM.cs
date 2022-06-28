using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace WpfAppMVVMskoolsys.ViewModels
{
    class MainWindowVM
    {
        ICommand _classesPage;
        ICommand _teachersPage;
        ICommand _studentsPage;
        ICommand _databaseWindow;
        ICommand _exitCommand;

        public MainWindowVM()
        {
            _classesPage = new RelayCommand(param => ChangeToClassesPage(param as System.Windows.Controls.Frame), null);
            _teachersPage = new RelayCommand(param => ChangeToTeachersPage(param as System.Windows.Controls.Frame), null);
            _studentsPage = new RelayCommand(param => ChangeToStudentsPage(param as System.Windows.Controls.Frame), null);

            _exitCommand = new RelayCommand(param => CloseApplication(), null);
        }

        public void ChangeToClassesPage(System.Windows.Controls.Frame frame)
        {
            frame.Content = new Views.Classes.PageClasses();
        }

        public void ChangeToTeachersPage(System.Windows.Controls.Frame frame)
        {
            frame.Content = new Views.Teachers.PageTeachers();
        }

        public void ChangeToStudentsPage(System.Windows.Controls.Frame frame)
        {
            frame.Content = new Views.Students.PageStudents();
        }

        public void CloseApplication()
        {
            Application.Current.Shutdown();
        }

        public ICommand ClassesPage
        {
            get => _classesPage;
        }

        public ICommand TeachersPage
        {
            get => _teachersPage;
        }

        public ICommand StudentsPage
        {
            get => _studentsPage;
        }

        public ICommand ExitCommand
        {
            get => _exitCommand;
        }
    }
}
