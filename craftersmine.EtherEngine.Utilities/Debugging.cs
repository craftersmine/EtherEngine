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
        /// Gets current game TPS
        /// </summary>
        public static float UpdateTime { get; internal set; }

        /// <summary>
        /// Gets current game FPS
        /// </summary>
        public static float FPS { get; internal set; }

        /// <summary>
        /// Gets current game DrawCalls per frame
        /// </summary>
        public static int RenderCalls { get; internal set; }

        /// <summary>
        /// Gets current game CU/s
        /// </summary>
        public static float FixedUpdateTime { get; internal set; }

        /// <summary>
        /// Gets current game CPU usage
        /// </summary>
        [Obsolete("(WIP) Not realized yet")]
        public static double CPU { get { throw new NotImplementedException("Not realized yet"); } internal set { } }

        /// <summary>
        /// Gets current game working set RAM usage
        /// </summary>
        public static long RAM { get { return Environment.WorkingSet; } }

        /// <summary>
        /// Gets or current game frame time
        /// </summary>
        public static float FrameTime { get; internal set; }

        /// <summary>
        /// Gets current game tickrate
        /// </summary>
        public static int TPS { get; internal set; }

        /// <summary>
        /// Gets current game fixed TPS
        /// </summary>
        public static int FixedTPS { get; internal set; }

        /// <summary>
        /// Gets current frame count
        /// </summary>
        public static long Frame { get; internal set; }
        
        /// <summary>
        /// Gets current lag time
        /// </summary>
        public static float LagTime { get; internal set; }

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
        /// Gets or sets is Rays will be drawn after first Cast call
        /// </summary>
        public static bool DrawRays { get; set; }

        /// <summary>
        /// Writes a log entry with specified prefix and content
        /// </summary>
        /// <param name="prefix">Log entry prefix</param>
        /// <param name="contents">Log entry contents</param>
        /// <param name="isOnlyConsole">Indicates log entry must log only to console if true, else false</param>
        [System.Diagnostics.DebuggerStepThrough]
        public static void Log(LogEntryType prefix, string contents, bool isOnlyConsole = false)
        {
            Logger?.Log(prefix, contents, isOnlyConsole);
        }

        /// <summary>
        /// Decodes an exception and writes exception data in log entry with specified prefix
        /// </summary>
        /// <param name="prefix">Log entry prefix</param>
        /// <param name="exception">Exception to write</param>
        /// <param name="isOnlyConsole">true if output must be only into console, otherwise false</param>
        [System.Diagnostics.DebuggerStepThrough]
        public static void LogException(LogEntryType prefix, Exception exception, bool isOnlyConsole = false)
        {
            Logger?.LogException(prefix, exception, isOnlyConsole);
        }
    }
}
