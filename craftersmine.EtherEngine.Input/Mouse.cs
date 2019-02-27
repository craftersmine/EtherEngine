using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Input;

namespace craftersmine.EtherEngine.Input
{
    public sealed class Mouse
    {
        public static void MouseDeviceMoveEvent(object sender, MouseMoveEventArgs e)
        {
            XDelta = e.XDelta;
            YDelta = e.YDelta;
        }

        public static void MouseDeviceButtonUpEvent(object sender, MouseButtonEventArgs e)
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

        public static void MouseDeviceButtonDownEvent(object sender, MouseButtonEventArgs e)
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

        public static void MouseDeviceWheelChangedEvent(object sender, MouseWheelEventArgs e)
        {
            WheelDelta = e.Delta;
        }

        public static MouseDevice MouseDevice { get; set; }

        public static int X { get { return MouseDevice.X; } }
        public static int XDelta { get; private set; }
        public static int Y { get { return MouseDevice.Y; } }
        public static int YDelta { get; private set; }
        public static int WheelDelta { get; private set; }

        public static bool LeftButton { get; private set; }
        public static bool RightButton { get; private set; }
        public static bool MiddleButton { get; private set; }
    }
}
