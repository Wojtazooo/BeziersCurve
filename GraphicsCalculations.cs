using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeziersCurve
{
    public class GraphicsCalculations
    {
        public static bool IsInCircle(Point point, Point circleCenter, double radius)
        {
            double dx = point.X - circleCenter.X;
            double dy = point.Y - circleCenter.Y;
            return (Math.Pow(dx, 2) + Math.Pow(dy, 2) <= Math.Pow(radius, 2));
        }
    }
}
