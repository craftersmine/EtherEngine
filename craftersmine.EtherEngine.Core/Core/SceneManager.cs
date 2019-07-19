using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.EtherEngine.Core
{
    /// <summary>
    /// Represents scene manager. This class cannot be inherited
    /// </summary>
    public sealed class SceneManager
    {
        /// <summary>
        /// Gets current loaded scene
        /// </summary>
        public static Scene CurrentScene { get; private set; }

        /// <summary>
        /// Loads scene instance into memory and executes load methods
        /// </summary>
        /// <param name="scene">Scene instance</param>
        public static void LoadScene(Scene scene)
        {
            CurrentScene = scene ?? throw new ArgumentNullException(nameof(scene), "Scene cannot be null");
            CurrentScene.OnCreate();
        }
    }
}
