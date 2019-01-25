using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.EtherEngine.Rendering
{
    /// <summary>
    /// Enumerates available VSync modes
    /// </summary>
    public enum VSyncMode
    {
        /// <summary>
        /// VSync enabled, unless framerate falls below one half of target framerate. If no target framerate specified, this behaves exactly like <see cref="On"/>
        /// </summary>
        Adaptive = OpenTK.VSyncMode.Adaptive,
        /// <summary>
        /// VSync enabled
        /// </summary>
        On = OpenTK.VSyncMode.On,
        /// <summary>
        /// VSync disabled
        /// </summary>
        Off = OpenTK.VSyncMode.Off
    }
}
