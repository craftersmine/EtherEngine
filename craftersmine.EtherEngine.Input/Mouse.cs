using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Input;

namespace craftersmine.EtherEngine.Input
{
    /// <summary>
    /// Provides static methods to handle mouse input
    /// </summary>
    public static class Mouse
    {
        internal static void MouseDeviceMoveEvent(object sender, MouseMoveEventArgs e)
        {
            XDelta = e.XDelta;
            YDelta = e.YDelta;
        }
        
        internal static void MouseDeviceButtonUpEvent(object sender, MouseButtonEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButton.Left:
                    LeftButton = false;
                    break;
                case MouseButton.Middle:
                    MiddleButton = false;
                    break;
                case MouseButton.Right:
                    RightButton = false;
                    break;
            }
        }
        
        internal static void MouseDeviceButtonDownEvent(object sender, MouseButtonEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButton.Left:
                    LeftButton = true;
                    break;
                case MouseButton.Middle:
                    MiddleButton = true;
                    break;
                case MouseButton.Right:
                    RightButton = true;
                    break;
            }
        }
        
        internal static void MouseDeviceWheelChangedEvent(object sender, MouseWheelEventArgs e)
        {
            WheelDelta = e.Delta;
        }
        
        internal static MouseDevice MouseDevice { get; set; }

        /// <summary>
        /// Gets current mouse X position on game window
        /// </summary>
        public static int X { get { return MouseDevice.X; } }
        /// <summary>
        /// Gets current mouse X delta while moving
        /// </summary>
        public static int XDelta { get; private set; }
        /// <summary>
        /// Gets current mouse Y position on game window
        /// </summary>
        public static int Y { get { return MouseDevice.Y; } }
        /// <summary>
        /// Gets current mouse Y delta while moving
        /// </summary>
        public static int YDelta { get; private set; }
        /// <summary>
        /// Gets current mouse wheel delta
        /// </summary>
        public static int WheelDelta { get; private set; }

        /// <summary>
        /// Gets true if mouse left button pressed, else false
        /// </summary>
        public static bool LeftButton { get; private set; }
        /// <summary>
        /// Gets true if mouse right button pressed, else false
        /// </summary>
        public static bool RightButton { get; private set; }
        /// <summary>
        /// Gets true if mouse middle (wheel) button pressed, else false
        /// </summary>
        public static bool MiddleButton { get; private set; }

        /// <summary>
        /// Resets X, Y and wheel deltas to 0
        /// </summary>
        public static void ResetDeltas()
        {
            XDelta = 0;
            YDelta = 0;
            WheelDelta = 0;
        }
    }
}
