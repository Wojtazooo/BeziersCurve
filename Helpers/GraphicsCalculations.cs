using System;
using System.Drawing;
using BeziersCurve.GraphicObjects;

namespace BeziersCurve.Helpers
{
    public class GraphicsCalculations
    {
        public static bool IsInCircle(Point point, Point circleCenter, double radius)
        {
            double dx = point.X - circleCenter.X;
            double dy = point.Y - circleCenter.Y;
            return (Math.Pow(dx, 2) + Math.Pow(dy, 2) <= Math.Pow(radius, 2));
        }

        public static FPoint NaiveRotatePointSrcToDest(FPoint pointToRotate, FPoint center, double angle)
        {
            var cosA = Math.Cos(angle);
            var sinA = Math.Sin(angle);

            var x1 = pointToRotate.X - center.X;
            var y1 = pointToRotate.Y - center.Y;

            var x2 = cosA*x1 + sinA * y1;
            var y2 = -sinA*x1 + cosA*y1;

            return new FPoint(x2 + center.X, y2 + center.Y);
        }

        public static FPoint NaiveRotatePointDestToSrc(FPoint pointToRotate, FPoint center, double angle)
        {
            var cosA = Math.Cos(angle);
            var sinA = Math.Sin(angle);

            var x1 = pointToRotate.X - center.X;
            var y1 = pointToRotate.Y - center.Y;

            var x2 = cosA * x1 - sinA * y1;
            var y2 = sinA * x1 + cosA * y1;

            return new FPoint(x2 + center.X, y2 + center.Y);
        }

        public static FPoint ShearXDestToSrc(double x1, double y1, double angle)
        {
            var tgA2 = Math.Tan(angle / 2);
            return new FPoint(x1 - tgA2 * y1, y1);
        }

        public static FPoint ShearYDestToSrc(double x1, double y1, double angle)
        {
            return new FPoint(x1, Math.Sin(angle) * x1 + y1);
        }

        public static FPoint ShearXSrcToDest(double x1, double y1, double angle)
        {
            var tgA2 = Math.Tan(angle / 2);
            return new FPoint(x1 + tgA2 * y1, y1);
        }

        public static FPoint ShearYSrcToDest(double x1, double y1, double angle)
        {
            return new FPoint(x1, - Math.Sin(angle) * x1 + y1);
        }

        public static double CountAngle(FPoint p1, FPoint p2)
        {
            var dx = p2.X - p1.X;
            var dy = p2.Y - p1.Y;


            if (dx == 0 && dy == 0) return 0;

            if(dx == 0)
            {
                if(dy > 0)
                {
                    return Math.PI / 2;
                }
                else
                {
                    return -Math.PI / 2;
                }
            }

            var angle = Math.Atan(Math.Abs(dy)/Math.Abs(dx));

            if (dx > 0 && dy >= 0) return -angle;
            else if (dx > 0 && dy < 0) return angle;
            else if (dx < 0 && dy >= 0) return -Math.PI + angle;
            else return Math.PI - angle;
        }
    }
}
