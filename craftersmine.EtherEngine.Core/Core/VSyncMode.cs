using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.EtherEngine.Core
{
    /// <summary>
    /// Renderer VSync modes
    /// </summary>
    public enum VSyncMode
    {
        /// <summary>
        /// VSync disabled (Maximum posible FPS)
        /// </summary>
        Off,
        /// <summary>
        /// VSync enabled (Maximum posible FPS restricted by monitor refresh rate)
        /// </summary>
        On,
        /// <summary>
        /// VSync enabled, half of rate (Maximum posible FPS restricted by half of monitor refresh rate)
        /// </summary>
        Half,
        /// <summary>
        /// VSync disabled (Maximum posible FPS), equal to <see cref="VSyncMode.Off"/>
        /// </summary>
        Disabled = Off,
        /// <summary>
        /// VSync enabled (Maximum posible FPS restricted by monitor refresh rate), equal to <see cref="VSyncMode.On"/>
        /// </summary>
        Enabled = On,
        /// <summary>
        /// VSync enabled, half of rate (Maximum posible FPS restricted by half of monitor refresh rate), equal to <see cref="VSyncMode.Half"/>
        /// </summary>
        EverySecondVBlank = Half
    }
}
