using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.IO;

namespace WpfAppMVVMskoolsys.ViewModels.Database
{
    class WindowDatabaseVM
    {
        private DataAccess.DatabaseSettings _databaseSettings;

        public Models.Database.DatabaseSettings DatabaseSettings { get; set; }

        ICommand _saveCommand;
        ICommand _testing;

        public WindowDatabaseVM()
        {
            DatabaseSettings = new Models.Database.DatabaseSettings();
            _databaseSettings = new DataAccess.DatabaseSettings();

            if(File.Exists("db-settings.txt"))
            {
                string[] data = _databaseSettings.LoadSettings();
                DatabaseSettings.ConnectionString = data[0];
                DatabaseSettings.DatabaseName = data[1];
                DatabaseSettings.CollectionClasses = data[2];
                DatabaseSettings.CollectionTeachers = data[3];
                DatabaseSettings.CollectionStudents = data[4];
            }

            _saveCommand = new RelayCommand(param => SaveSettings(), null);
            _testing = new RelayCommand(param => _databaseSettings.LoadSettings(), null);
        }

        public void SaveSettings()
        {
            string[] settings = new string[5];
            settings[0] = DatabaseSettings.ConnectionString;
            settings[1] = DatabaseSettings.DatabaseName;
            settings[2] = DatabaseSettings.CollectionClasses;
            settings[3] = DatabaseSettings.CollectionTeachers;
            settings[4] = DatabaseSettings.CollectionStudents;
            _databaseSettings.SaveSettings(settings);
            MessageBox.Show("Settings updated!", "Success!");
        }

        public ICommand SaveCommand
        {
            get => _saveCommand;
        }

        public ICommand testing
        {
            get => _testing;
        }
    }
}
