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
        ICommand _exitCommand;

        public MainWindowVM()
        {
            _classesPage = new RelayCommand(param => ChangeToClassesPage(param), null);
            _exitCommand = new RelayCommand(param => CloseApplication(), null);
        }

        public void ChangeToClassesPage(object obj)
        {
            if(obj is System.Windows.Controls.Frame frame)
            {
                frame.Content = new Views.Classes.PageClasses();
            }
        }

        public void CloseApplication()
        {
            Application.Current.Shutdown();
        }

        public ICommand ClassesPage
        {
            get => _classesPage;
        }

        public ICommand ExitCommand
        {
            get => _exitCommand;
        }
    }
}
