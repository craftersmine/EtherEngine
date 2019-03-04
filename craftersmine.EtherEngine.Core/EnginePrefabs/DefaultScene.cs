using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.EtherEngine.Core.EnginePrefabs
{
    /// <summary>
    /// Represents default, empty scene. This class cannot be inherited
    /// </summary>
    public sealed class DefaultScene : Scene
    {
        /// <summary>
        /// Creates new <see cref="DefaultScene"/> instance
        /// </summary>
        public DefaultScene()
        {
            BackgroundColor = Color.Black;
        }
    }
}
