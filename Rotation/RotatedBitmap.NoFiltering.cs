using System;
using System.Collections.Generic;
using System.Drawing;

namespace BeziersCurve.Rotation
{
    public partial class RotatedBitmap
    {
        public (int minX, int maxX, int minY, int maxY) CountRotatedBitmapBordersNoFiltering()
        {
            var width = _originalBitmap.Width;
            var height = _originalBitmap.Height;

            var _src1 = new FPoint(_center.X - width / 2.0, _center.Y - height / 2.0);
            var _src2 = new FPoint(_center.X + width / 2.0, _center.Y - height / 2.0);
            var _src3 = new FPoint(_center.X + width / 2.0, _center.Y + height / 2.0);
            var _src4 = new FPoint(_center.X - width / 2.0, _center.Y + height / 2.0);

            var p1 = GraphicsCalculations.NaiveRotatePointSrcToDest(_src1, _center, _angle);
            var p2 = GraphicsCalculations.NaiveRotatePointSrcToDest(_src2, _center, _angle);
            var p3 = GraphicsCalculations.NaiveRotatePointSrcToDest(_src3, _center, _angle);
            var p4 = GraphicsCalculations.NaiveRotatePointSrcToDest(_src4, _center, _angle);

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

            (int minX, int maxX, int minY, int maxY) = CountRotatedBitmapBordersNoFiltering();

            for (int x = minX; x <= maxX; x++)
            {
                for (int y = minY; y <= maxY; y++)
                {
                    var destPixel = new FPoint(x, y);

                    FPoint rotatedBackToSource =
                        GraphicsCalculations.NaiveRotatePointDestToSrc(new FPoint(x, y), _center, _angle);

                    var sourceX = rotatedBackToSource.RoundedX - _center.X + width / 2;
                    var sourceY = rotatedBackToSource.RoundedY - _center.Y + height / 2;

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