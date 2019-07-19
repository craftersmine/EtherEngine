using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;

namespace craftersmine.EtherEngine.Core
{
    /// <summary>
    /// Represents a point in space
    /// </summary>
    public struct Point
    {
        private Vector2 rawPoint;

        internal Vector2 RawPoint { get { return rawPoint; } }

        /// <summary>
        /// Gets or sets point position at X axis
        /// </summary>
        public float X { get { return RawPoint.X; } set { rawPoint = new Vector2(value, Y); } }
        /// <summary>
        /// Gets or sets point position at Y axis
        /// </summary>
        public float Y { get { return RawPoint.Y; } set { rawPoint = new Vector2(X, value); } }

        /// <summary>
        /// Creates a new instance of <see cref="Point"/> with specified parameters
        /// </summary>
        /// <param name="x">Point X position</param>
        /// <param name="y">Point Y position</param>
        public Point(float x, float y)
        {
            rawPoint = new Vector2(x, y);
        }

        internal Point(Vector2 vec)
        {
            rawPoint = vec;
        }
    }
}
