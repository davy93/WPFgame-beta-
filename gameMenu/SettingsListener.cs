using System;
using System.IO;
using System.Collections.Generic;
using gameMenu.Debug;

namespace gameMenu
{
    static class SettingsListener
    {
        private static Settings settingsInstance = Settings.GetInstance();
        private static string settingsFile = "settings.cfg";
        private static List<Setters> setters = new List<Setters>(); 
        private class Setters
        {
            public string SetterName;
            public string SetterValue;
            public string Header;

            public Setters(string setterName, string setterValue, string header)
            {
                SetterName = setterName;
                SetterValue = setterValue;
                Header = header;
            }

            public override string ToString()
            {
                return String.Format("{0}={1}",SetterName, SetterValue);
            }
        }

        public static void LoadSettings()
        {

            if (!File.Exists(settingsFile)) { Logging.WriteLog("Settings file does not exists", LogType.WARNING); return; }
            Logging.WriteLog("Loading Settings...");
            List<string> setterValues = new List<string>();
            List<string> setterNames = new List<string>();
            StreamReader sr = new StreamReader(settingsFile);
            while (!sr.EndOfStream)
            {
                string[] temp = sr.ReadLine().Split('=');
                setterNames.Add(temp[0]);
                setterValues.Add(temp[1]);
            }
            sr.Close();


            for (int i = 0; i < setterNames.Count; i++)
            {
                switch (setterNames[i])
                {
                    case "Debugging":
                        bool value = Convert.ToBoolean(setterValues[i]);
                        settingsInstance.debugChckBox.IsChecked = value;
                        break;
                }
            }
            Logging.WriteLog("Loaded Settings!");
        }
        public static void SaveSettings()
        {
            #region Values
            bool debugging = settingsInstance.debugChckBox.IsChecked.Value;
            #endregion
            #region Setters
            Setters debugger = new Setters("Debugging", debugging.ToString(), "[DEBUG]");
            setters.Add(debugger);
            #endregion
            Logging.WriteLog("Saving settings...");
            StreamWriter sw = new StreamWriter(settingsFile);
            for (int i = 0; i < setters.Count; i++)
            {
                sw.WriteLine(setters[i].ToString());
            }
            sw.Close();
            Logging.WriteLog("Saved Settings...");
        }
        public static void DiscardSettings()
        {
            LoadSettings();
            settingsInstance.Hide();
        }
        public static void ShowSettings()
        {
            LoadSettings();
            settingsInstance.Show();
        }

        public static bool DebugMode()
        {
            LoadSettings();
            return settingsInstance.debugChckBox.IsChecked.Value;
        }
    }
    
}
