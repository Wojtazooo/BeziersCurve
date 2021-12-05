using System;
using System.Collections.Generic;
using System.Drawing;
using BeziersCurve.GraphicObjects;
using BeziersCurve.Helpers;

namespace BeziersCurve.Rotation
{
    public partial class RotatedBitmap
    {
        public (int minX, int maxX, int minY, int maxY) CountRotatedBitmapBordersNoFiltering()
        {
            var width = _originalBitmap.Width;
            var height = _originalBitmap.Height;

            var src1 = new FPoint(_center.X - width / 2.0, _center.Y - height / 2.0);
            var src2 = new FPoint(_center.X + width / 2.0, _center.Y - height / 2.0);
            var src3 = new FPoint(_center.X + width / 2.0, _center.Y + height / 2.0);
            var src4 = new FPoint(_center.X - width / 2.0, _center.Y + height / 2.0);

            var p1 = GraphicsCalculations.NaiveRotatePointSrcToDest(src1, _center, _angle);
            var p2 = GraphicsCalculations.NaiveRotatePointSrcToDest(src2, _center, _angle);
            var p3 = GraphicsCalculations.NaiveRotatePointSrcToDest(src3, _center, _angle);
            var p4 = GraphicsCalculations.NaiveRotatePointSrcToDest(src4, _center, _angle);

            var minX = (int) Math.Min(Math.Min(Math.Min(p1.X, p2.X), p3.X), p4.X);
            var minY = (int) Math.Min(Math.Min(Math.Min(p1.Y, p2.Y), p3.Y), p4.Y);
            var maxX = (int) Math.Max(Math.Max(Math.Max(p1.X, p2.X), p3.X), p4.X);
            var maxY = (int) Math.Max(Math.Max(Math.Max(p1.Y, p2.Y), p3.Y), p4.Y);

            return (minX, maxX, minY, maxY);
        }

        private void CountRotatedBitmapNoFiltering()
        {
            var width = _originalBitmap.Width;
            var height = _originalBitmap.Height;
            _rotatedBitmap = new List<(FPoint, Color)>();

            var (minX, maxX, minY, maxY) = CountRotatedBitmapBordersNoFiltering();

            for (var x = minX; x <= maxX; x++)
            {
                for (var y = minY; y <= maxY; y++)
                {
                    var destPixel = new FPoint(x, y);

                    var rotatedBackToSource =
                        GraphicsCalculations.NaiveRotatePointDestToSrc(new FPoint(x, y), _center, _angle);

                    var sourceX = rotatedBackToSource.RoundedX - _center.X + width / 2.0;
                    var sourceY = rotatedBackToSource.RoundedY - _center.Y + height / 2.0;

                    if (sourceX >= 0 && sourceY >= 0 && sourceX < width && sourceY < height)
                    {
                        var sourceColor = _originalBitmap.GetPixel((int) sourceX, (int) sourceY);
                        _rotatedBitmap.Add((destPixel, sourceColor));
                    }
                }
            }
        }
    }
}