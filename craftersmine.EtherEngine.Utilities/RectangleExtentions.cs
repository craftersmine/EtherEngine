using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.EtherEngine.Utilities
{
    public static class RectangleExtentions
    {
        public static bool IsLineIntersects(this Rectangle r, int x1, int y1, int x2, int y2)
        {
            return IsLineIntersects(r, new Point(x1, y1), new Point(x2, y2));
        }

        public static bool IsLineIntersects(this Rectangle r, Point p1, Point p2)
        {
            if (r.Left > p1.X || r.Right < p2.X)
            {
                return false;
            }

            if (r.Top < p1.Y || r.Bottom > p2.Y)
            {
                return false;
            }

            var yAtRectLeft = CalculateYForX(r.Left, p1, p2);
            var yAtRectRight = CalculateYForX(r.Right, p1, p2);

            if (r.Bottom > yAtRectLeft && r.Bottom > yAtRectRight)
            {
                return false;
            }

            if (r.Top < yAtRectLeft && r.Top < yAtRectRight)
            {
                return false;
            }

            return true;
        }

        private static float CalculateYForX(float x, Point p1, Point p2)
        {
            return p1.Y - (x - p1.X) * ((p1.Y - p2.Y) / (p2.X - p1.X));
        }
    }
}
