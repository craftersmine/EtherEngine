using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using craftersmine.EtherEngine.Core.EnginePrefabs;
using craftersmine.EtherEngine.Rendering;
using craftersmine.EtherEngine.Utilities;

namespace craftersmine.EtherEngine.Core
{
    public sealed class Game
    {
        internal static Window GameWnd { get; private set; }
        internal static GLGDI GLGDIInstance { get { return GameWnd.GLGDI; } }
        internal static GameUpdater GameUpdater { get; private set; }
        internal static CollisionUpdater CollisionUpdater { get; private set; }
        internal static string DefaultWindowTitle { get; private set; }

        public static event EventHandler GameStarted;
        public static event EventHandler GameExited;

        public static void Run(Window gameWindow)
        {
            try
            {
                string tempDirectoryPath = Environment.GetEnvironmentVariable("temp");
                Debugging.Logger = new Logger(tempDirectoryPath, "craftersmine.EtherEngine");
                Debugging.Log(LogEntryType.Info, "craftersmine EtherEngine (c) craftersmine 2018-2019");
                Debugging.Log(LogEntryType.Info, "Initializing game...");
                GameWnd = gameWindow;
                Debugging.Log(LogEntryType.Info, "Creating GameUpdater...");
                GameUpdater = new GameUpdater(60);
                Debugging.Log(LogEntryType.Info, "Creating CollisionUpdater...");
                CollisionUpdater = new CollisionUpdater(60);
                DefaultWindowTitle = GameWnd.Title;
                GameWnd.Render += GameRendererHelper.OnRender;
                GameWnd.Load += GameWnd_Load;
                Debugging.Log(LogEntryType.Info, "Loading default scene...");
                SceneManager.SetScene(new DefaultScene());
                GameUpdater.Run();
                CollisionUpdater.Run();
                //GameStarted?.Invoke(null, EventArgs.Empty);
                GameWnd.Run();
            }
            catch (Exception ex)
            {
                Debugging.LogException(LogEntryType.Crash, ex);
                MessageBox.Show("Something went wrong!\r\nMessage: " + ex.Message + "\r\n\r\nStacktrace:\r\n" + ex.StackTrace, "Engine Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Exit(ex.HResult);
            }
        }

        private static void GameWnd_Load(object sender, EventArgs e)
        {
            GameStarted?.Invoke(null, EventArgs.Empty);
        }

        public static void Exit(int exitCode)
        {
            GameExited?.Invoke(null, EventArgs.Empty);
            if (GameWnd != null)
                GameWnd.Close();

            else Debugging.Log(LogEntryType.Warning, "No active game window found!");
            if (exitCode != 0)
                Debugging.Log(LogEntryType.Warning, "Game exited with code " + exitCode + " (0x" + exitCode.ToString("X") + ")");
            else Debugging.Log(LogEntryType.Info, "Game exited with code " + exitCode + "(0x" + exitCode.ToString("X") + ")");
            Environment.Exit(exitCode);
        }
    }
}
