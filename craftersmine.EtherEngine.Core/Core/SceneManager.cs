using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.EtherEngine.Core
{
    public sealed class SceneManager
    {
        public static Scene CurrentScene { get; private set; }

        public static void LoadScene(string name)
        { }

        public static void LoadScene(Scene scene)
        {
            CurrentScene = scene;
        }
    }
}
