/*
 * 
 * Special thanks from https://cyberforum.ru/ 
 * Especialy for EldHasp and others who helped me to make this!
 * 
 * 
 * Actual topic [Russian] http://www.cyberforum.ru/csharp-beginners/thread2440114.html
 * 
 */


using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.EtherEngine.Core
{
    /// <summary>
    /// Represents a segment of line. This class cannot be inherited
    /// </summary>
    public sealed class Segment : Line
    {
        /// <summary>
        /// Start point of segment
        /// </summary>
        public PointF Start { get; private set; }

        /// <summary>
        /// End point of segment
        /// </summary>
        public PointF End { get; private set; }

        /// <summary>
        /// Creates new instance of <see cref="Segment"/> with specified start and end points
        /// </summary>
        /// <param name="start">Segment start point</param>
        /// <param name="end">Segment end point</param>
        public Segment(PointF start, PointF end) : base(start, end)
        {
            Start = start;
            End = end;
        }

        /// <summary>
        /// Checks if <see cref="Segment"/> intersects with specified <paramref name="rectangle"/> and returns true if intersects, otherwise false/>
        /// </summary>
        /// <param name="rectangle"><see cref="RectangleF"/> to check</param>
        /// <returns>true if intersects, otherwise false</returns>
        public override bool IsIntersectsRectangle(RectangleF rectangle)
        {
            RectangleF rectIntersect = RectangleFromPoint(Start, End);

            rectIntersect.Intersect(rectangle);
            if (rectIntersect.Width == 0 && rectIntersect.Height == 0)
                return false;
            return base.IsIntersectsRectangle(rectangle);
        }
    }
}
