using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using craftersmine.EtherEngine.Utilities;
using XInput = SharpDX.XInput;

namespace craftersmine.EtherEngine.Input
{
    /// <summary>
    /// Represents gamepad 
    /// </summary>
    public sealed class Gamepad
    {
        private XInput.Controller Gamepad1;
        private XInput.Controller Gamepad2;
        private XInput.Controller Gamepad3;
        private XInput.Controller Gamepad4;
        //private XInput.Controller GamepadAny;

        private XInput.State EmptyState = new XInput.State();
        
        internal static Gamepad GamepadInstance { get; set; }

        /// <summary>
        /// Gets true if XInput feature is supported by operating system, otherwise false
        /// </summary>
        public bool IsSupported { get; private set; }
        
        /// <summary>
        /// Gets true if gamepad/s connected, otherwise false
        /// </summary>
        public bool IsDeviceConnected { get; private set; }

        internal Gamepad()
        {
            try
            {
                Gamepad1 = new XInput.Controller(XInput.UserIndex.One);
                Gamepad2 = new XInput.Controller(XInput.UserIndex.Two);
                Gamepad3 = new XInput.Controller(XInput.UserIndex.Three);
                Gamepad4 = new XInput.Controller(XInput.UserIndex.Four);
                IsSupported = true;
            }
            catch (Exception ex)
            {
                IsSupported = false;
                Debugging.Log(LogEntryType.Warning, "Unable to find XInput library or it's not supported by your OS - " + ex.HResult.ToHexademicalStringWithPrefix());
                Debugging.LogException(LogEntryType.Warning, ex);
            }
            //GamepadAny = new XInput.Controller(XInput.UserIndex.Any);
            GamepadInstance = this;
        }

        /// <summary>
        /// Returns true if specified <paramref name="button"/> pressed on gamepad
        /// </summary>
        /// <param name="button">Button to check</param>
        /// <returns></returns>
        public static bool IsButtonDown(GamepadButtons button)
        {
            return IsButtonDown(button, GamepadNumbers.One);
        }

        /// <summary>
        /// Returns true if specified <paramref name="button"/> pressed on gamepad of specified player
        /// </summary>
        /// <param name="button">Button to check</param>
        /// <param name="gamepadNumber">Gamepad number</param>
        /// <returns></returns>
        public static bool IsButtonDown(GamepadButtons button, GamepadNumbers gamepadNumber)
        {
            if (GamepadInstance.IsDeviceConnected)
                if (GamepadInstance.IsSupported)
                    if (GetState(gamepadNumber).Gamepad.Buttons == (GetState(gamepadNumber).Gamepad.Buttons | (XInput.GamepadButtonFlags)button))
                        return true;
                    else return false;
                else return false;
            else return false;
        }

        /// <summary>
        /// Gets values of specified thumbstick like X and Y axis etc
        /// </summary>
        /// <param name="stick">Stick to get values</param>
        /// <param name="gamepadNumber">Gamepad number</param>
        /// <returns></returns>
        public static GamepadStickState GetStickValue(GamepadSticks stick, GamepadNumbers gamepadNumber)
        {
            if (GamepadInstance.IsDeviceConnected)
            {
                if (GamepadInstance.IsSupported)
                {
                    XInput.State state = GetState(gamepadNumber);
                    GamepadStickState gamepadStick = GamepadStickState.Empty;
                    switch (stick)
                    {
                        case GamepadSticks.LeftStick:
                            gamepadStick.IsDown = IsButtonDown(GamepadButtons.LeftStick);
                            gamepadStick.X = state.Gamepad.LeftThumbX;
                            gamepadStick.Y = state.Gamepad.LeftThumbY;
                            break;
                        case GamepadSticks.RightStick:
                            gamepadStick.IsDown = IsButtonDown(GamepadButtons.LeftStick);
                            gamepadStick.X = state.Gamepad.LeftThumbX;
                            gamepadStick.Y = state.Gamepad.LeftThumbY;
                            break;
                    }
                    return gamepadStick;
                }
                else return GamepadStickState.Empty;
            }
            else return GamepadStickState.Empty;
        }

        private static XInput.State GetState(GamepadNumbers gamepadNumber)
        {
            try
            {
                if (Gamepad.GamepadInstance.IsSupported)
                {
                    XInput.State state = GamepadInstance.EmptyState;
                    switch (gamepadNumber)
                    {
                        case GamepadNumbers.One:
                            state = GamepadInstance.Gamepad1.GetState();
                            break;
                        case GamepadNumbers.Two:
                            state = GamepadInstance.Gamepad2.GetState();
                            break;
                        case GamepadNumbers.Three:
                            state = GamepadInstance.Gamepad3.GetState();
                            break;
                        case GamepadNumbers.Four:
                            state = GamepadInstance.Gamepad4.GetState();
                            break;
                    }
                    GamepadInstance.IsDeviceConnected = true;
                    return state;
                }
                else return GamepadInstance.EmptyState;
            }
            catch (Exception ex)
            {
                Debugging.LogException(LogEntryType.Warning, ex);
                GamepadInstance.IsDeviceConnected = false;
                return GamepadInstance.EmptyState;
            }
        }
    }
}
