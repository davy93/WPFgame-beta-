using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace gameMenu.Debug
{
    static class Logging
    {
        private static DebugWindow debugWindowInstance = DebugWindow.GetInstance();

        public static void WriteLog(string message, LogType logType)
        {
            switch (logType)
            {
                case LogType.INFO:
                    WriteLine(String.Format("{0} - INFO - : {1}", DateTime.Now.ToString(), message));
                    break;
                case LogType.WARNING:
                    WriteLine(String.Format("{0} - WARN - : {1}", DateTime.Now.ToString(), message));
                    break;
                case LogType.ERROR:
                    WriteLine(String.Format("{0} - ERROR - : {1}", DateTime.Now.ToString(), message));
                    break;
                case LogType.FATAL_ERROR:
                    WriteLine(String.Format("{0} - FATAL - : {1}", DateTime.Now.ToString(), message));
                    break;
            }     
        }
        public static void WriteLog(string message)
        {
            WriteLine(String.Format("{0} - INFO - : {1}", DateTime.Now.ToString(), message));
        }
        private static void WriteLine(string message)
        {
            debugWindowInstance.logBox.Text += message + "\n";
        }
        public static void ShowDebugLog()
        {
            debugWindowInstance.Show();
        }
        public static List<string> GetLog()
        {
            List<string> log = new List<string>();
            
            string logBoxText = debugWindowInstance.logBox.Text;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < logBoxText.Length - 2; i++)
            {
                if (logBoxText[i].Equals('\n'))
                {
                    i += 1;
                    log.Add(sb.ToString());
                    sb = null;
                    sb = new StringBuilder();
                }
               
                sb.Append(logBoxText[i]);
            }

            return log;
        }

        public static void CreateLogDir()
        {
            if (!System.IO.Directory.Exists("logs"))
            {
                WriteLog("LogDirectory not exists... Creating");
                DirectoryInfo di = Directory.CreateDirectory("logs");
            }
            else WriteLog("LogDirectory exists!");
        }
    }
    enum LogType
    {
        INFO = 1,
        WARNING = 2,
        ERROR = 3,
        FATAL_ERROR = 4
    }
}
