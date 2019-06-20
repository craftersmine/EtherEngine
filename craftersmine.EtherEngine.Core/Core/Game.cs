using SharpDX.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace craftersmine.EtherEngine.Core
{
    public static class Game
    {
        internal static IntPtr GameWndPointer { get; set; }
        internal static GameWindow GameWindow { get; set; }
        internal static Renderer.Renderer Renderer { get; set; }

        public static void Run(GameWindow gameWindow)
        {
            GameWindow = gameWindow;
            GameWndPointer = GameWindow.Handle;

            // TODO: Game initialization logic goes below here
            Renderer = new Renderer.Renderer(GameWndPointer);
            Renderer.RenderLoop = new RenderLoop(GameWindow);
            SceneManager.LoadScene(new Scene { BackgroundColor = new Color(.5f) });



            RenderLoop.Run(GameWindow, new RenderLoop.RenderCallback(Renderer.Render));
        }

        public static void Exit(int exitCode)
        {
            //Renderer.Stop(); // This will dispose all resources!
        }
    }
}
