using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace BeziersCurve
{
    public class FPoint
    {
        public double Y { get; set; }
        public double X { get; set; }
        public Point pointToDraw => new Point((int)Math.Round(X), (int)Math.Round(Y));
        public int RoundedX => (int)Math.Round(X);
        public int RoundedY => (int)Math.Round(Y);
        public FPoint(double x, double y)
        {
            Y = y;
            X = x;
        }

        public FPoint(Point p)
        {
            X = p.X;
            Y = p.Y;
        }

        public static implicit operator FPoint(Point p) => new FPoint(p);
        public static implicit operator Point(FPoint p) => new Point(p.RoundedX, p.RoundedY);


        public static FPoint GetPointBetween(FPoint fp1, FPoint fp2, double t)
        {
            var dx = fp2.X - fp1.X;
            var dy = fp2.Y - fp1.Y;
            return new FPoint(fp1.X + dx*t, fp1.Y + dy*t);
        }

        public static double CountDistance(FPoint fp1, FPoint fp2)
        {
            var dx = fp2.X - fp1.X; 
            var dy = fp2.Y - fp1.Y;
            return Math.Sqrt((Math.Pow(dx, 2) + Math.Pow(dy, 2)));
        }
    }
}
