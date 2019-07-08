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
        private float width;
        private float height;
        private float rotationAngle;
        private Vector2 rotationOrigin;

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
        /// <summary>
        /// Gets or sets object rotation angle
        /// </summary>
        public float RotationAngle { get { return rotationAngle; } set {
                while (value > 360f)
                    value -= 360f;
                while (value < 0f)
                    value += 360f;
                rotationAngle = value;
            } }
        /// <summary>
        /// Gets or sets object rotation origin position along X axis
        /// </summary>
        public float RotationOriginX { get { return rotationOrigin.X; } set { rotationOrigin.X = value; } }
        /// <summary>
        /// Gets or sets object rotation origin position along Y axis
        /// </summary>
        public float RotationOriginY { get { return rotationOrigin.Y; } set { rotationOrigin.Y = value; } }
        /// <summary>
        /// Gets or sets object scale on X axis
        /// </summary>
        public float ScaleFactorX { get; set; }
        /// <summary>
        /// Gets or sets object scale on Y axis
        /// </summary>
        public float ScaleFactorY { get; set; }

        internal float CameraX {
            get {
                xPos = X;
                if (SceneManager.CurrentScene != null)
                    if (SceneManager.CurrentScene.Camera != null)
                        xPos += SceneManager.CurrentScene.Camera.X;
                return xPos;
            }
        }
        internal float CameraY {
            get {
                yPos = Y;
                if (SceneManager.CurrentScene != null)
                    if (SceneManager.CurrentScene.Camera != null)
                        yPos += SceneManager.CurrentScene.Camera.Y;
                return yPos;
            }
        }
        internal RectangleF DrawingBoundings;

        private void UpdateBoundsRectangle()
        {
            if (DrawingBoundings == null)
                DrawingBoundings = new RectangleF(CameraX, CameraY, Width, Height);

            DrawingBoundings.Width = Width;
            DrawingBoundings.Height = Height;
            DrawingBoundings.X = CameraX;
            DrawingBoundings.Y = CameraY;
        }
    }
}
