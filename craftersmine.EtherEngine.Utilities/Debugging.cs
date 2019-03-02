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
        /// <summary>
        /// Gets or sets current game logger
        /// </summary>
        public static Logger Logger { get; set; }

        /// <summary>
        /// Gets or [ENGINE PROPERTY METHOD] sets current game TPS
        /// </summary>
        public static int TPS { get; set; }

        /// <summary>
        /// Gets or [ENGINE PROPERTY METHOD] sets current game FPS
        /// </summary>
        public static int FPS { get; set; }

        /// <summary>
        /// Gets or [ENGINE PROPERTY METHOD] sets current game DrawCalls per frame
        /// </summary>
        public static int DrawCalls { get; set; }

        /// <summary>
        /// Gets or [ENGINE PROPERTY METHOD] sets current game CU/s
        /// </summary>
        public static int CollisionsUpdatesPerSecond { get; set; }

        /// <summary>
        /// Gets or [ENGINE PROPERTY METHOD] sets current game CPU usage
        /// </summary>
        [Obsolete("(WIP) Not realized yet")]
        public static double CPU { get { throw new NotImplementedException("Not realized yet"); } set { } }
        /// <summary>
        /// Gets or [ENGINE PROPERTY METHOD] sets current game RAM usage
        /// </summary>
        [Obsolete("(WIP) Not realized yet")]
        public static double RAM { get { throw new NotImplementedException("Not realized yet"); } set { } }

        /// <summary>
        /// Gets or [ENGINE PROPERTY METHOD] sets current game frame time
        /// </summary>
        public static double FrameTime { get; set; }

        /// <summary>
        /// Gets or sets true if debug info draws on screen, else false
        /// </summary>
        public static bool DrawDebug { get; set; }

        /// <summary>
        /// Gets or sets true if debug bounds draws on screen, else false
        /// </summary>
        public static bool DrawBounds { get; set; }

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
            Logger?.Log(prefix, contents, isOnlyConsole);
        }

        /// <summary>
        /// Decodes an exception and writes exception data in log entry with specified prefix
        /// </summary>
        /// <param name="prefix">Log entry prefix</param>
        /// <param name="exception">Exception to write</param>
        public static void LogException(LogEntryType prefix, Exception exception)
        {
            Logger?.LogException(prefix, exception);
        }
    }
}
