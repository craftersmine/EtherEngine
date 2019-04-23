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
    /// Represents a line that goes through two points. The line equantion is Ax+By+C=0
    /// </summary>
    public class Line
    {
        private double eps = 1e-3;

        /// <summary>Factor A in Ax+By+C=0 equantion</summary>
        public double A { get; private set; }
        /// <summary>Factor B in Ax+By+C=0 equantion</summary>
        public double B { get; private set; }
        /// <summary>Factor C in Ax+By+C=0 equantion</summary>
        public double C { get; private set; }
        /// <summary>Admisible comparison error</summary>
        public double Eps { get; set; }
        /// <summary>Creates new instance of <see cref="Line"/></summary>
        /// <param name="startPoint">Start point of line</param>
        /// <param name="endPoint">End point of line</param>
        public Line(PointF startPoint, PointF endPoint)
        {
            Eps = eps;
            double ProjectionX = endPoint.X - startPoint.X;
            double ProjectionY = endPoint.Y - startPoint.Y;
            if (Math.Abs(ProjectionX) <= Eps && Math.Abs(ProjectionY) <= Eps)
                throw new ArgumentException("Points of line is equals");
            if (ProjectionX == 0)
            {
                A = 1;
                B = 0;
                C = -startPoint.X;
            }
            else if (ProjectionY == 0)
            {
                A = 0;
                B = 1;
                C = -startPoint.Y;
            }
            else
            {
                A = ProjectionY;
                B = -ProjectionX;
                C = startPoint.Y * ProjectionX - startPoint.X * ProjectionY;
            }

        }

        /// <summary>Calculates X by specified Y</summary>
        /// <param name="y">Y value</param>
        /// <returns>NaN if line is vertical</returns>
        public double GetX(double y)
        {
            if (A == 0)
                return double.NaN;
            return -(B * y + C) / A;
        }
        /// <summary>Calculates Y by specified X</summary>
        /// <param name="x">X value</param>
        /// <returns>NaN if line is horizontal</returns>
        public double GetY(double x)
        {
            if (B == 0)
                return double.NaN;
            return -(A * x + C) / B;
        }

        /// <summary>Checks if specified point is belongs to line and returns true if belong, otherwise false</summary>
        /// <param name="point">Point to check</param>
        public bool IsPointBelongs(PointF point)
        {
            if (Math.Abs(A) >= Math.Abs(B))
                return Math.Abs(point.X - GetX(point.Y)) <= Eps;
            return Math.Abs(point.Y - GetY(point.X)) <= Eps;
        }

        /// <summary>Checks if line intersect a specified rectangle and returns true if intersects, otherwise false</summary>
        /// <param name="rectangle"><see cref="RectangleF"/> to check</param>
        /// <returns><see langword="true"/> if intersects</returns>
        public virtual bool IsIntersectsRectangle(RectangleF rectangle)
        {
            PointF pointLeftTop;
            PointF pointRightBottom;
            if (Math.Abs(A) <= Math.Abs(B))
            {
                pointLeftTop = new PointF(rectangle.Left, (float)GetY(rectangle.Left));
                pointRightBottom = new PointF(rectangle.Right, (float)GetY(rectangle.Right));
            }
            else
            {
                pointLeftTop = new PointF((float)GetX(rectangle.Top), rectangle.Top);
                pointRightBottom = new PointF((float)GetX(rectangle.Bottom), rectangle.Bottom);
            }

            RectangleF rectIntersect = RectangleFromPoint(pointLeftTop, pointRightBottom);

            rectIntersect.Intersect(rectangle);
            return rectIntersect.Width != 0 || rectIntersect.Height != 0;
        }
        
        /// <summary>Creates rectangle from specified points</summary>
        /// <param name="point1">First point</param>
        /// <param name="point2">Second point</param>
        /// <returns>New instance of <see cref="RectangleF"/></returns>
        static public RectangleF RectangleFromPoint(PointF point1, PointF point2)
        {
            float left, top, width, height;

            if (point1.X < point2.X)
            {
                left = point1.X;
                width = point2.X - left;
            }
            else
            {
                left = point2.X;
                width = point1.X - left;
            }

            if (point1.Y < point2.Y)
            {
                top = point1.Y;
                height = point2.Y - top;
            }
            else
            {
                top = point2.Y;
                height = point1.Y - top;
            }
            return new RectangleF(left, top, width, height);
        }
    }
}
