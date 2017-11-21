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

namespace gameMenu.Debug
{
    /// <summary>
    /// Interaction logic for DebugWindow.xaml
    /// </summary>
    public partial class DebugWindow : Window
    {
        private static DebugWindow currentInstance;
        protected DebugWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Gets DebugLog Current Instanc
        /// </summary>
        /// <returns></returns>
        internal static DebugWindow GetInstance()
        {
           if(CreateDebugInstance())  return currentInstance;
           return currentInstance;
        }
        /// <summary>
        /// Creates new instance (if it's true), if it's exists return false
        /// </summary>
        /// <returns></returns>
        internal static bool CreateDebugInstance()
        {
            if(currentInstance == null)
            {
                currentInstance = new DebugWindow();
                return true;
            }
            return false;
        }

    }
}
