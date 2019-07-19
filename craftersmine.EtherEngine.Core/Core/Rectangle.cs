using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;

namespace craftersmine.EtherEngine.Core
{
    /// <summary>
    /// Represents a rectangle
    /// </summary>
    public struct Rectangle
    {
        private RectangleF rawRect;

        internal RectangleF RawRectangle { get { return rawRect; } }

        /// <summary>
        /// Gets rectangle position along X axis
        /// </summary>
        public float X { get { return rawRect.X; } }
        /// <summary>
        /// Gets rectangle position along Y axis
        /// </summary>
        public float Y { get { return rawRect.Y; } }
        /// <summary>
        /// Gets rectangle width
        /// </summary>
        public float Width { get { return rawRect.Width; } }
        /// <summary>
        /// Gets rectangle height
        /// </summary>
        public float Height { get { return rawRect.Height; } }
        /// <summary>
        /// Gets true if rectangle empty, otherwise false
        /// </summary>
        public bool IsEmpty { get { return rawRect.IsEmpty; } }
        /// <summary>
        /// Gets center point of rectangle
        /// </summary>
        public Point Center { get { return new Point(rawRect.Center); } }

        /// <summary>
        /// Creates a new instance of <see cref="Rectangle"/> with specified x, y, width and height
        /// </summary>
        /// <param name="x">Rectangle position along X axis</param>
        /// <param name="y">Rectangle position along Y axis</param>
        /// <param name="width">Rectangle width</param>
        /// <param name="height">Rectangle height</param>
        public Rectangle(float x, float y, float width, float height)
        {
            rawRect = new RectangleF(x, y, width, height);
        }

        /// <summary>
        /// Checks if another rectangle intersects with this rectangle and returns true if intersects, otherwise false
        /// </summary>
        /// <param name="rect">Rectangle to check</param>
        /// <returns></returns>
        public bool IsIntersectsWith(Rectangle rect)
        {
            return rawRect.Intersects(rect.RawRectangle);
        }

        /// <summary>
        /// Checks if this rectangle contains specified point and returns true if contains, otherwise false
        /// </summary>
        /// <param name="point">Point to check</param>
        /// <returns></returns>
        public bool IsContainsPoint(Point point)
        {
            return rawRect.Contains(point.RawPoint);
        }

        /// <summary>
        /// Inflates rectangle boundings on specified value
        /// </summary>
        /// <param name="horizontalValue">Horizontal inflation value</param>
        /// <param name="verticalValue">Vertical inflation value</param>
        public void Inflate(float horizontalValue, float verticalValue)
        {
            rawRect.Inflate(horizontalValue, verticalValue);
        }

        /// <summary>
        /// Offsets rectangle on specific coordinates
        /// </summary>
        /// <param name="x">Position along X axis</param>
        /// <param name="y">Position along Y axis</param>
        public void Offset(float x, float y)
        {
            rawRect.Offset(x, y);
        }
    }
}
