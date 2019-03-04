using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using craftersmine.EtherEngine.Core.EnginePrefabs;
using craftersmine.EtherEngine.Rendering;
using craftersmine.EtherEngine.Utilities;

namespace craftersmine.EtherEngine.Core
{
    /// <summary>
    /// Provides static methods to manage game
    /// </summary>
    public static class Game
    {
        internal static Window GameWnd { get; private set; }
        internal static GLGDI GLGDIInstance { get { return GameWnd.GLGDI; } }
        internal static GameUpdater GameUpdater { get; private set; }
        internal static CollisionUpdater CollisionUpdater { get; private set; }
        internal static string DefaultWindowTitle { get; private set; }

        /// <summary>
        /// Occurs when game started and ready to show scene
        /// </summary>
        public static event EventHandler GameStarted;
        /// <summary>
        /// Occurs when game exiting
        /// </summary>
        public static event EventHandler<CancelEventArgs> GameExiting;

        /// <summary>
        /// Gets or sets current used sound device
        /// </summary>
        public static SoundDevice SoundDevice { get; set; }

        /// <summary>
        /// Starts game instance with specified <see cref="Window"/>
        /// </summary>
        /// <param name="gameWindow">Main game <see cref="Window"/></param>
        public static void Run(Window gameWindow)
        {
            try
            {
                Application.EnableVisualStyles();
                string tempDirectoryPath = Environment.GetEnvironmentVariable("temp");
                Debugging.Logger = new Logger(tempDirectoryPath, "craftersmine.EtherEngine");
                Debugging.Log(LogEntryType.Info, "craftersmine EtherEngine (c) craftersmine 2018-2019");
                Debugging.Log(LogEntryType.Info, "Initializing game...");
                GameWnd = gameWindow;
                //Debugging.Log(LogEntryType.Info, "Current OpenAL audio context is " + AudioContext.CurrentContext.ToString());
                Debugging.Log(LogEntryType.Info, "Initializing OpenAL...");
                SoundDevice = new SoundDevice();
                SoundDevice.Initialize();
                Debugging.Log(LogEntryType.Info, "Creating GameUpdater...");
                GameUpdater = new GameUpdater(60);
                Debugging.Log(LogEntryType.Info, "Creating CollisionUpdater...");
                CollisionUpdater = new CollisionUpdater(60);
                DefaultWindowTitle = GameWnd.Title;
                GameWnd.Render += GameRendererHelper.OnRender;
                GameWnd.Load += GameWnd_Load;
                GameWnd.Exiting += GameWnd_Exiting;
                Debugging.Log(LogEntryType.Info, "Loading default scene...");
                SceneManager.SetScene(new DefaultScene());
                GameUpdater.Run();
                CollisionUpdater.Run();
                //GameStarted?.Invoke(null, EventArgs.Empty);
                GameWnd.Run();
                Exit(0);
            }
            catch (Exception ex)
            {
                CrashHandler.Handle(ex);
            }
        }

        private static void GameWnd_Exiting(object sender, CancelEventArgs e)
        {
            GameExiting?.Invoke(null, e);
        }

        private static void GameWnd_Load(object sender, EventArgs e)
        {
            GameStarted?.Invoke(null, EventArgs.Empty);
        }

        /// <summary>
        /// Exits from game with specified exit code
        /// </summary>
        /// <param name="exitCode">Game exit code</param>
        public static void Exit(int exitCode)
        {
            if (SceneManager.CurrentScene !=  null)
            {
                foreach (var audioChannel in SceneManager.CurrentScene.AudioChannels)
                {
                    audioChannel.Value.Stop();
                }
            }
            
            if (GameWnd != null)
                GameWnd.Close();

            else Debugging.Log(LogEntryType.Warning, "No active game window found!");
            if (exitCode != 0)
                Debugging.Log(LogEntryType.Warning, "Game exited with code " + exitCode + " (0x" + exitCode.ToString("X") + ")");
            else Debugging.Log(LogEntryType.Info, "Game exited with code " + exitCode + " (0x" + exitCode.ToString("X") + ")");
            Environment.Exit(exitCode);
        }
    }
}
