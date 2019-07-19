using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DI = SharpDX.DirectInput;

namespace craftersmine.EtherEngine.Input
{
    /// <summary>
    /// Contains static methods to get an input from keyboard. This class cannot be inherited
    /// </summary>
    public sealed class Keyboard
    {
        private DI.Keyboard DirectInputKeyboard;
        internal static Keyboard KeyboardInstance { get; set; }

        internal Keyboard()
        {
            DirectInputKeyboard = new DI.Keyboard(new DI.DirectInput());
            DirectInputKeyboard.Properties.BufferSize = 128;
            DirectInputKeyboard.Acquire();

            KeyboardInstance = this;
        }

        /// <summary>
        /// Gets specified key states
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns></returns>
        public static KeyState GetKeyState(Key key)
        {
            KeyboardInstance.DirectInputKeyboard.Acquire();
            var keyState = new KeyState();
            keyState.Key = Key.Unknown;
            keyState.IsPressed = false;
            keyState.IsReleased = false;

            KeyboardInstance.DirectInputKeyboard.Poll();
            var data = KeyboardInstance.DirectInputKeyboard.GetBufferedData();
            foreach (var dataEntry in data)
            {
                if (dataEntry.Key == (DI.Key)key)
                {
                    keyState.Key = (Key)dataEntry.Key;
                    keyState.IsPressed = dataEntry.IsPressed;
                    keyState.IsReleased = dataEntry.IsReleased; // BUG: IsReleased state doesn't triggered due fast Update rate
                }
            }

            return keyState;
        }

        /// <summary>
        /// Checks if the specified key pressed or not and returns true if pressed, otherwise false
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns></returns>
        public static bool IsKeyPressed(Key key)
        {
            KeyboardInstance.DirectInputKeyboard.Acquire();
            var data = KeyboardInstance.DirectInputKeyboard.GetCurrentState();
            return data.IsPressed((DI.Key)key);
        }
    }
}
