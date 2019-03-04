using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using craftersmine.EtherEngine.Core.Forms;
using craftersmine.EtherEngine.Utilities;

namespace craftersmine.EtherEngine.Core
{
    /// <summary>
    /// Provides static methods for exception handling
    /// </summary>
    public static class CrashHandler
    {
        /// <summary>
        /// Handles provided exception, writes exception data to log file, shows message to user and then exits from game
        /// </summary>
        /// <param name="ex">Exception to handle</param>
        public static void Handle(Exception ex)
        {
            Debugging.LogException(LogEntryType.Crash, ex);
            new CrashHandlerForm(ex).ShowDialog();
            Game.Exit(ex.HResult);
        }
    }
}
