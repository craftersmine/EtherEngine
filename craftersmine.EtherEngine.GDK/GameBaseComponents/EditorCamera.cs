using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.EtherEngine.GDK.GameBaseComponents
{
    /// <summary>
    /// Represents game camera for culling invisible objects. This class cannot be inherited
    /// </summary>
    [Serializable]
    public sealed class Camera
    {
        /// <summary>
        /// Gets camera frame width
        /// </summary>
        public int FrameWidth { get; private set; }
        /// <summary>
        /// Gets camera frame height
        /// </summary>
        public int FrameHeight { get; private set; }
        /// <summary>
        /// Gets camera X axis position
        /// </summary>
        public int CameraX { get; private set; }
        /// <summary>
        /// Gets camera Y axis position
        /// </summary>
        public int CameraY { get; private set; }

        /// <summary>
        /// Creates new <see cref="Camera"/> instance with specified frame width and height
        /// </summary>
        /// <param name="frameWidth">Camera frame width</param>
        /// <param name="frameHeight">Camera frame height</param>
        public Camera(int frameWidth, int frameHeight)
        {
            FrameHeight = frameHeight;
            FrameWidth = frameWidth;
        }

        /// <summary>
        /// Move camera on specific amount along X and Y axis
        /// </summary>
        /// <param name="x">Amount to move camera along X axis</param>
        /// <param name="y">Amount to move camera along Y axis</param>
        public void MoveCamera(int x, int y)
        {
            CameraX += x;
            CameraY += y;
        }

        /// <summary>
        /// Sets camera position on specified X and Y
        /// </summary>
        /// <param name="x">X position</param>
        /// <param name="y">Y position</param>
        public void PlaceCamera(int x, int y)
        {
            CameraX = x;
            CameraY = y;
        }

        public void ResizeFrame(int width, int height)
        {
            FrameWidth = width;
            FrameHeight = height;
        }
    }
}
