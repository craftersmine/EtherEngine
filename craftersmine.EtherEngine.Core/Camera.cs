using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.EtherEngine.Core
{
    public sealed class Camera
    {
        public int FrameWidth { get; private set; }
        public int FrameHeight { get; private set; }
        public int CameraX { get; private set; }
        public int CameraY { get; private set; }

        public Camera(int frameWidth, int frameHeight)
        {
            FrameHeight = frameHeight;
            FrameWidth = frameWidth;
        }

        public void MoveCamera(int x, int y)
        {
            CameraX += x;
            CameraY += y;
        }

        public void PlaceCamera(int x, int y)
        {
            CameraX = x;
            CameraY = y;
        }
    }
}
