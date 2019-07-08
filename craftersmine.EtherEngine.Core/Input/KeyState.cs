using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.EtherEngine.Input
{
    /// <summary>
    /// Represents keyboard key state
    /// </summary>
    public struct KeyState
    {
        /// <summary>
        /// Gets keyboard key
        /// </summary>
        public Key Key { get; internal set; }
        /// <summary>
        /// Gets true if key pressed, otherwise false
        /// </summary>
        public bool IsPressed { get; internal set; }
        /// <summary>
        /// Gets true if key released, otherwise false
        /// </summary>
        public bool IsReleased { get; internal set; }
    }
}
