using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.EtherEngine.Core
{
    /// <summary>
    /// Represents a camera. This class cannot be inherited
    /// </summary>
    public sealed class Camera
    {
        /// <summary>
        /// Gets or sets camera position along X axis
        /// </summary>
        public float X { get; set; }
        /// <summary>
        /// Gets or sets camera position along Y axis
        /// </summary>
        public float Y { get; set; }

        /// <summary>
        /// Creates a new instance of <see cref="Camera"/> with default parameters
        /// </summary>
        public Camera()
        {
            X = 0;
            Y = 0;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Camera"/> with specified parameters
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Camera(float x, float y)
        {
            X = x;
            Y = y;
        }
    }
}
