using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.EtherEngine.Utilities
{
    /// <summary>
    /// Represents static methods for debugging
    /// </summary>
    public sealed class Debugging
    {
        internal static Logger StaticLogger { get; set; }

        /// <summary>
        /// Gets or sets is FPS counter draws on screen
        /// </summary>
        public static bool DrawFPS { get; set; }

        /// <summary>
        /// Gets or sets is DrawCall counter is shown in titlebar after window title
        /// </summary>
        public static bool ShowDrawCallsPerFrameInTitle { get; set; }

        /// <summary>
        /// Writes a log entry with specified prefix and content
        /// </summary>
        /// <param name="prefix">Log entry prefix</param>
        /// <param name="contents">Log entry contents</param>
        /// <param name="isOnlyConsole">Indicates log entry must log only to console if true, else false</param>
        public static void Log(LogEntryType prefix, string contents, bool isOnlyConsole = false)
        {
            StaticLogger?.Log(prefix, contents, isOnlyConsole);
        }

        /// <summary>
        /// Decodes an exception and writes exception data in log entry with specified prefix
        /// </summary>
        /// <param name="prefix">Log entry prefix</param>
        /// <param name="exception">Exception to write</param>
        public static void LogException(LogEntryType prefix, Exception exception)
        {
            StaticLogger?.LogException(prefix, exception);
        }
    }
}
