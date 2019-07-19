using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;

namespace craftersmine.EtherEngine.Core
{
    /// <summary>
    /// Represents an object transformation
    /// </summary>
    public struct Transform
    {
        private float xPos;
        private float yPos;
        private float camXPos;
        private float camYPos;
        private float width;
        private float height;

        /// <summary>
        /// Gets or sets object position along X axis
        /// </summary>
        public float X { get { return xPos; } set { xPos = value; UpdateBoundsRectangle(); } }
        /// <summary>
        /// Gets or sets object position along Y axis
        /// </summary>
        public float Y { get { return yPos; } set { yPos = value; UpdateBoundsRectangle(); } }
        /// <summary>
        /// Gets or sets objec width
        /// </summary>
        public float Width { get { return width; } set { width = value; UpdateBoundsRectangle(); } }
        /// <summary>
        /// Gets or sets object height
        /// </summary>
        public float Height { get { return height; } set { height = value; UpdateBoundsRectangle(); } }

        internal float CameraX {
            get {
                camXPos = X;
                if (SceneManager.CurrentScene != null)
                    if (SceneManager.CurrentScene.Camera != null)
                        camXPos += SceneManager.CurrentScene.Camera.X;
                return camXPos;
            }
        }
        internal float CameraY {
            get {
                camYPos = Y;
                if (SceneManager.CurrentScene != null)
                    if (SceneManager.CurrentScene.Camera != null)
                        camYPos += SceneManager.CurrentScene.Camera.Y;
                return camYPos;
            }
        }
        internal Rectangle DrawingBoundings;

        internal void UpdateBoundsRectangle()
        {
            DrawingBoundings = new Rectangle(CameraX, CameraY, Width, Height);
        }
    }
}
