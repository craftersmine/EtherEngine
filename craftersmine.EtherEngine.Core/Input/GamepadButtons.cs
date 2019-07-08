using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XInput = SharpDX.XInput;

namespace craftersmine.EtherEngine.Input
{
    /// <summary>
    /// Contains gamepad buttons
    /// </summary>
    public enum GamepadButtons
    {
        /// <summary>
        /// Green A button
        /// </summary>
        A = XInput.GamepadButtonFlags.A,
        /// <summary>
        /// Red B button
        /// </summary>
        B = XInput.GamepadButtonFlags.B,
        /// <summary>
        /// Blue X button
        /// </summary>
        X = XInput.GamepadButtonFlags.X,
        /// <summary>
        /// Yellow Y button
        /// </summary>
        Y = XInput.GamepadButtonFlags.Y,
        /// <summary>
        /// Right bumper - RB
        /// </summary>
        RightBumper = XInput.GamepadButtonFlags.RightShoulder,
        /// <summary>
        /// Left bumper - LB
        /// </summary>
        LeftBumper = XInput.GamepadButtonFlags.LeftShoulder,
        /// <summary>
        /// Right thumbstick - RS
        /// </summary>
        RightStick = XInput.GamepadButtonFlags.RightThumb,
        /// <summary>
        /// Left thumbstick - LS
        /// </summary>
        LeftStick = XInput.GamepadButtonFlags.LeftThumb,
        /// <summary>
        /// DPad left
        /// </summary>
        DPadLeft = XInput.GamepadButtonFlags.DPadLeft,
        /// <summary>
        /// DPad up
        /// </summary>
        DPadUp = XInput.GamepadButtonFlags.DPadUp,
        /// <summary>
        /// DPad right
        /// </summary>
        DPadRight = XInput.GamepadButtonFlags.DPadRight,
        /// <summary>
        /// DPad down
        /// </summary>
        DPadDown = XInput.GamepadButtonFlags.DPadDown,
        /// <summary>
        /// On XOne gamepad three-lines button, equivalent to X360 start button
        /// </summary>
        Menu = XInput.GamepadButtonFlags.Start,
        /// <summary>
        /// On XOne gamepad two-rectangles button, equivalent to X360 back button
        /// </summary>
        View = XInput.GamepadButtonFlags.Back,
        /// <summary>
        /// On X360 gamepad nearby Guide button white arrow to right, equivalent to XOne Menu button
        /// </summary>
        Start = XInput.GamepadButtonFlags.Start,
        /// <summary>
        /// On X360 gamepad nearby Guide button white arrow to left, equivalent to XOne View button
        /// </summary>
        Back = XInput.GamepadButtonFlags.Back,
        /// <summary>
        /// None
        /// </summary>
        None = XInput.GamepadButtonFlags.None
    }
}
