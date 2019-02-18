using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using craftersmine.EtherEngine.GDK.Core;
using craftersmine.EtherEngine.GDK.Properties;
using craftersmine.EtherEngine.Utilities;

namespace craftersmine.EtherEngine.GDK
{
    static class Program
    {
        static Logger Logger;

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                string temp = Environment.GetEnvironmentVariable("temp");
                Logger = new Logger(temp, "craftersmine.EtherEngine.GDK");
            }
            catch
            {
                MessageBox.Show("Unable to create logger! Logging is not provided! Try to reload application if you need logging! If error occurs after, please contact me", "Logger creation failure!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Log(LogEntryType.Info, "Initializing GDK...");
            StaticData.Settings = Settings.Default;
            Log(LogEntryType.Info, "Creating LocaleManager...");
            StaticData.LocaleManager = new LocaleManager();
            StaticData.LocaleManager.LoadLocalesList();
            Log(LogEntryType.Info, "Loading \"" + StaticData.Settings.Locale + "\" locale...");
            StaticData.LocaleManager.LoadLocale(StaticData.Settings.Locale);
            Log(LogEntryType.Info, "Building window...");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        public static void Log(LogEntryType prefix, string contents, bool onlyConsole = false)
        {
            Logger?.Log(prefix, contents, onlyConsole);
        }

        public static void LogException(LogEntryType prefix, Exception exception)
        {
            Logger?.LogException(prefix, exception);
        }
    }
}