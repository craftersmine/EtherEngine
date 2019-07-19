using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.EtherEngine.Input
{
    /// <summary>
    /// Represents current gamepad thumbstick state
    /// </summary>
    public struct GamepadStickState
    {
        /// <summary>
        /// Gets stick ID
        /// </summary>
        public GamepadSticks Stick { get; internal set; }
        /// <summary>
        /// Gets current thumbstick position along X axis (-1.0f - 1.0f, 0.0f means centered)
        /// </summary>
        public float X { get; internal set; }
        /// <summary>
        /// Gets current thumbstick position along Y axis (-1.0f - 1.0f, 0.0f means centered)
        /// </summary>
        public float Y { get; internal set; }
        /// <summary>
        /// Gets true if thumbstick is pressed, otherwise false. Equivalent to IsButtonPressed(GamepadButtons.Left/RightStick)
        /// </summary>
        public bool IsDown { get; internal set; }
        /// <summary>
        /// Gets thumbstick deadzone
        /// </summary>
        [Obsolete("Will be removed in future releases")]
        public float Deadzone { get; internal set; }

        /// <summary>
        /// (readonly) Default state of thumbsticks
        /// </summary>
        public readonly static GamepadStickState Empty = new GamepadStickState() { X = 0f, Y = 0f, IsDown = false };
    }
}
