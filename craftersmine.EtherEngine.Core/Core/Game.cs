using craftersmine.EtherEngine.Exceptions;
using craftersmine.EtherEngine.Input;
using craftersmine.EtherEngine.Utilities;
using SharpDX.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace craftersmine.EtherEngine.Core
{
    /// <summary>
    /// Contains static Game management and initialization methods. This class cannot be inherited
    /// </summary>
    public static class Game
    {
        internal static IntPtr GameWndPointer { get; set; }
        internal static GameWindow GameWindow { get; set; }
        internal static Renderer.Renderer Renderer { get; set; }
        internal static UpdateTimer GameUpdater { get; set; }
        internal static Logger Logger { get; set; }
        internal static Keyboard KeyboardInstance { get; set; }
        internal static Gamepad GamepadInstance { get; set; }

        /// <summary>
        /// Gets or sets true if game will exit after user presses Close button on window title, otherwise false
        /// </summary>
        public static bool IsCloseWindowExitsGame { get; set; } = true;

        /// <summary>
        /// Gets true if game is paused, otherwise false
        /// </summary>
        public static bool IsPaused { get {
                return GameUpdater.CurrentState == TimerState.Paused ? true : false;
            } }

        /// <summary>
        /// Occurs when game engine initializes game
        /// </summary>
        public static event EventHandler GameInitialized;

        /// <summary>
        /// Occurs when game engine performs update when game updater is paused
        /// </summary>
        public static event EventHandler GamePausedUpdate;

        /// <summary>
        /// Initializes and starts the game
        /// </summary>
        /// <param name="gameWindow">Game window instance</param>
        public static void Run(GameWindow gameWindow)
        {
            try
            {
                if (SystemEnvironment.LaunchArguments.Contains("--disableLogging") || SystemEnvironment.LaunchArguments.Contains("-dl"))
                {
                    Console.WriteLine("craftersmine EtherEngine (c) craftersmine 2018-2019");
                    Debugging.Logger = null;
                    Console.WriteLine("Game Logging capability is disabled! To enable logging please remove \"--disableLogging\" or \"-dl\" argument from shortcut or start line");
                }
                else
                    Debugging.Logger = new Logger(SystemEnvironment.TemporaryDirectory, "craftersmine.EtherEngine");
                Debugging.Log(LogEntryType.Info, "craftersmine EtherEngine (c) craftersmine 2018-2019");

                Debugging.Log(LogEntryType.Info, "Enabling visual styles...");
                Application.EnableVisualStyles();

                GameWindow = gameWindow;
                GameWndPointer = GameWindow.Handle;

                Debugging.Log(LogEntryType.Info, "Initializing DirectInput keyboard...");
                KeyboardInstance = new Keyboard();
                Debugging.Log(LogEntryType.Info, "Initializing XInput gamepad...");
                GamepadInstance = new Gamepad();

                Debugging.Log(LogEntryType.Info, "Creating GameUpdater...");
                GameUpdater = new UpdateTimer(60);
                GameUpdater.FixedUpdate += GameUpdateHandlers.FixedUpdateHandler;
                GameUpdater.Update += GameUpdateHandlers.UpdateHandler;
                GameUpdater.PausedUpdate += GameUpdateHandlers.PausedUpdateHandler;

                // TODO: Game initialization logic goes below here
                Debugging.Log(LogEntryType.Info, "Creating Renderer...");
                Renderer = new Renderer.Renderer(GameWndPointer);
                Debugging.Log(LogEntryType.Info, "Loading default scene...");
                SceneManager.LoadScene(new Scene { BackgroundColor = new Color(0f) });

                Renderer.SetFullscreenState(GameWindow.WindowParameters.IsFullscreen);

                Debugging.Log(LogEntryType.Done, "Game initialized!");
                GameInitialized += Initialized;
                RenderLoop.Run(GameWindow, new RenderLoop.RenderCallback(Renderer.Render));
            }
            catch (Exception ex)
            {
                CrashHandler.Handle(ex);
            }
        }

        private static void Initialized(object sender, EventArgs e)
        {
            Debugging.DrawBounds = true;
            Debugging.Log(LogEntryType.Info, "Starting GameUpdater...");
            GameUpdater.Start();
        }

        /// <summary>
        /// Exits the game with specified exit code (0 = No error or exception, otherwise indicates game crashed)
        /// </summary>
        /// <param name="exitCode">Exit code</param>
        public static void Exit(int exitCode)
        {
            Debugging.Log(LogEntryType.Info, "Exiting game...");
            Debugging.Log(LogEntryType.Info, "Stopping GameUpdater...");
            GameUpdater.Stop();
            if (exitCode != 0)
                Debugging.Log(LogEntryType.Warning, "Game exited with exit code " + exitCode.ToHexademicalStringWithPrefix());
            else Debugging.Log(LogEntryType.Info, "Game exited with exit code " + exitCode.ToHexademicalStringWithPrefix());
            Environment.Exit(exitCode);
        }

        public static void Pause()
        {
            GameUpdater?.Pause();
        }

        public static void Resume()
        {
            GameUpdater.Start();
        }

        internal static void RaiseGameInitialized()
        {
            GameInitialized?.Invoke(null, EventArgs.Empty);
        }

        internal static void RaisePausedUpdate()
        {
            GamePausedUpdate?.Invoke(null, EventArgs.Empty);
        }
    }
}
