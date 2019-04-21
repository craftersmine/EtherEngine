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
            if (r.Contains(p1) || r.Contains(p2))
                return true;
            return false;
        }
    }
}
