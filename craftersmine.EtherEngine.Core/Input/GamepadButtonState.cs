using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.EtherEngine.Input
{
    /// <summary>
    /// Represents gamepad button state
    /// </summary>
    public struct GamepadButtonState
    {
        /// <summary>
        /// Gets button ID
        /// </summary>
        public GamepadButtons Button { get; internal set; }
        /// <summary>
        /// Gets true if button is pressed, otherwise false
        /// </summary>
        public bool IsPressed { get; internal set; }
        /// <summary>
        /// Gets true if button is released, otherwise false
        /// </summary>
        public bool IsReleased { get; internal set; }

        /// <summary>
        /// (readonly) Default state of any button
        /// </summary>
        public readonly static GamepadButtonState Empty = new GamepadButtonState() { Button = GamepadButtons.None, IsPressed = false, IsReleased = false };
    }
}
