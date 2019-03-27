using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.EtherEngine.Core
{
    /// <summary>
    /// Represents object transformarion properties. This class cannot be inherited
    /// </summary>
    public sealed class Transform
    {
        /// <summary>
        /// Gets current X position to render
        /// </summary>
        public int RendererX { get { return (int)X - SceneManager.CurrentScene.SceneCamera.CameraX; } }
        /// <summary>
        /// Gets current Y position to render
        /// </summary>
        public int RendererY { get { return (int)Y + SceneManager.CurrentScene.SceneCamera.CameraY; } }

        /// <summary>
        /// Gets or sets object X position on scene
        /// </summary>
        public float X { get; set; }
        /// <summary>
        /// Gets or sets object Y position on scene
        /// </summary>
        public float Y { get; set; }
        /// <summary>
        /// Gets or sets object width
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// Gets or sets object height
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Gets or sets object rotation origin along X axis
        /// </summary>
        public int RotationOriginX { get; set; }
        /// <summary>
        /// Gets or sets object rotation origin along Y axis
        /// </summary>
        public int RotationOriginY { get; set; }
        /// <summary>
        /// Gets or sets object rotation angle along rotation origin
        /// </summary>
        public float RotationAngle { get; set; }

        /// <summary>
        /// Rotates object on specified angle
        /// </summary>
        /// <param name="angle">Rotation angle</param>
        public void Rotate(float angle)
        {
            RotationAngle += angle;
            if (RotationAngle >= 360.0f)
                RotationAngle = RotationAngle - 360.0f;
        }

        /// <summary>
        /// Resets object rotation origin to center of object
        /// </summary>
        public void ResetRotationOrigin()
        {
            RotationOriginX = Width / 2 + RendererX;
            RotationOriginY = Height / 2 + RendererY;
        }

        public bool CheckPointInBounds(Point point)
        {
            if (new Rectangle(RendererX, RendererY, Width, Height).Contains(point))
                return true;
            else return false;
        }

        public bool CheckPointInBounds(int x, int y)
        {
            if (new Rectangle(RendererX, RendererY, Width, Height).Contains(x, y))
                return true;
            else return false;
        }
    }
}
