using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.EtherEngine.Core
{
    /// <summary>
    /// Contains static system-specific variables and methods
    /// </summary>
    public static class SystemEnvironment
    {
        /// <summary>
        /// %TEMP% directory
        /// </summary>
        public static string TemporaryDirectory { get { return Environment.GetEnvironmentVariable("temp"); } }
        /// <summary>
        /// AppData/Roaming user directory
        /// </summary>
        public static string AppDataDirectory { get { return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); } }
        /// <summary>
        /// AppData/Local user directory
        /// </summary>
        public static string LocalAppDataDirectory { get { return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData); } }
        /// <summary>
        /// User documents directory
        /// </summary>
        public static string MyDocumentsDirectory { get { return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); } }
        /// <summary>
        /// Current game launch arguments
        /// </summary>
        public static string[] LaunchArguments { get { return Environment.GetCommandLineArgs(); } }
    }
}
