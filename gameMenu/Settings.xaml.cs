using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using gameMenu.Debug;

namespace gameMenu
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        private static Settings settingsInstance;
        protected Settings()
        {
            InitializeComponent();
        }
        internal static Settings GetInstance()
        {
            if (CreateInstance()) return settingsInstance;
            return settingsInstance;
        }
        internal static bool CreateInstance()
        {
            if(settingsInstance == null)
            {
                settingsInstance
                     = new Settings();
                return true;
            }
            return false;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            SettingsListener.SaveSettings();
            Hide();
        }

        private void debugChckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Logging.WriteLog("Hiding DebugLog...");
            if (!debugChckBox.IsChecked.Value) Debug.Logging.HideDebugLog();
        }

        private void debugChckBox_Checked(object sender, RoutedEventArgs e)
        {
            Logging.WriteLog("Showing DebugLog...");
            if (debugChckBox.IsChecked.Value) Debug.Logging.ShowDebugLog();
        }
    }
}
