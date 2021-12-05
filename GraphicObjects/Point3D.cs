using System;
using System.Drawing;

namespace FillingSphere.GraphicalObjects
{
    public class Point3d
    {
        public double X;
        public double Y;
        public double Z;
        public Point Point2D => new Point((int)Math.Round(X), (int)Math.Round(Y));

        public Point3d(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public void Move(Point3d vertex)
        {
            X += vertex.X;
            Y += vertex.Y;
            Z += vertex.Y;
        }

        public override string ToString()
        {
            return $"{X}, {Y}, {Z}";
        }

        public static Point3d operator -(Point3d a, Point3d b) => new Point3d(a.X - b.X, a.Y - b.Y, a.Z - b.Z);

        public static Point3d getCrossProduct(Point3d a, Point3d b)
        {
            double cx = a.Y * b.Z - a.Z * b.Y;
            double cy = a.Z * b.X - a.X * b.Z;
            double cz = a.X * b.Y - a.Y * b.X;
            return new Point3d(cx, cy, cz);
        }

        public static Point3d operator *(Point3d a, double b) => new Point3d(a.X * b, a.Y * b, a.Z * b);
        public static Point3d operator *(double b, Point3d a) => new Point3d(a.X * b, a.Y * b, a.Z * b);
        public static Point3d operator +(Point3d a, Point3d b) => new Point3d(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    }
}