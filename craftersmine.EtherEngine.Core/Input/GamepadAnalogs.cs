using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XInput = SharpDX.XInput;

namespace craftersmine.EtherEngine.Input
{
    /// <summary>
    /// Contains gamepad triggers
    /// </summary>
    public enum GamepadTriggers
    {
        /// <summary>
        /// Left trigger - LT
        /// </summary>
        LeftTrigger,
        /// <summary>
        /// Right trigger - RT
        /// </summary>
        RightTrigger
    }

    /// <summary>
    /// Contains gamepad thumbsticks
    /// </summary>
    public enum GamepadSticks
    {
        /// <summary>
        /// Left thumbstick - LS
        /// </summary>
        LeftStick = XInput.GamepadButtonFlags.LeftThumb,
        /// <summary>
        /// Right thumbstick - RS
        /// </summary>
        RightStick = XInput.GamepadButtonFlags.RightThumb
    }
}
