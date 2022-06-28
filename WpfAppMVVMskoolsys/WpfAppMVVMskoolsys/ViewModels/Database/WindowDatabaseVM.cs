using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfAppMVVMskoolsys.ViewModels.Database
{
    class WindowDatabaseVM
    {
        private DataAccess.DatabaseSettings _databaseSettings;

        public Models.Database.DatabaseSettings DatabaseSettings { get; set; }

        ICommand _saveCommand;

        public WindowDatabaseVM()
        {
            DatabaseSettings = new Models.Database.DatabaseSettings();
            _databaseSettings = new DataAccess.DatabaseSettings();
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
        }

        public ICommand SaveCommand
        {
            get => _saveCommand;
        }
    }
}
