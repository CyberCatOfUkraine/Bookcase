using DataStore.Managers;
using DataStore.Mappers;
using Logic;
using SettingsSaver.LocalModels;
using System;
using System.IO;
using System.Threading;

namespace SettingsSaver
{
    public static class SettingsManager
    {
        static ISetting _settings =new Setting();
        const string _settingsFileName= "settings";
        static FileManager fileManager = new();
        static string SettingsFilePath => Path.Combine(Environment.CurrentDirectory, Globals.Globals.ConfigurationDirName, _settingsFileName);
        static SettingsManager()
        {
            Thread thread = new(LoadSettings);
            thread.Start();
        }
        private static void LoadSettings()
        {
            if (_settings.BooksPath == null)
            {
                _settings.BooksPath = Globals.Globals.DefaultBooksDirName;
            }

            if (!fileManager.IsExist(SettingsFilePath))
            {
                fileManager.Create(SettingsFilePath);
                fileManager.Write(SettingsFilePath, Mapper<ISetting>.Map(_settings));
                return;
            }
            else
            {
                _settings = Mapper<ISetting>.Map(fileManager.Read(SettingsFilePath));
                new BookManager().SetBooks(_settings.Books);
                new UserManager().SetUsers(_settings.Users);
            }
        }
        public static void SaveBookFolderPath(string path)
        {
            _settings.BooksPath = path;
        }
        public static string ReadBookFolderPath()
        {
            return _settings.BooksPath;
        }
        public static void SaveSetting()
        {
            _settings.Books = new BookManager().GetBooks();
            _settings.Users = new UserManager().GetUsers();
            fileManager.Write(SettingsFilePath, Mapper<ISetting>.Map(_settings));
        }
    }
}
