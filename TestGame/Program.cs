using craftersmine.EtherEngine.Core;
using craftersmine.EtherEngine.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestGame
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            new GameWindow(new WindowParameters(800, 600));
            Game.Run(GameWindow.Current);
        }
    }
}
