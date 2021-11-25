using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeziersCurve
{
    public class RotatedBitmap
    {
        private BmpPixelSnoop _originalBitmap;

        private List<(FPoint point, Color color)> _rotatedBitmap;
        private FPoint _center;
        private double _angle;
        private bool filtering = false;

        public RotatedBitmap(Bitmap bitmapToRotate, FPoint center, double angle, bool filteringOn)
        {
            _originalBitmap = new BmpPixelSnoop(bitmapToRotate);
            _angle = angle;
            _center = center;
            filtering = filteringOn;
            CountRotatedBitmap();
        }

        public (int minX, int maxX, int minY, int maxY) CountRotatedBitmapBorders()
        {
            var widht = _originalBitmap.Width;
            var heigth = _originalBitmap.Height;

            var _src1 = new FPoint(_center.X - widht / 2, _center.Y - heigth / 2);
            var _src2 = new FPoint(_center.X + widht / 2, _center.Y - heigth / 2);
            var _src3 = new FPoint(_center.X + widht / 2, _center.Y + heigth / 2);
            var _src4 = new FPoint(_center.X - widht / 2, _center.Y + heigth / 2);

            var p1 = GraphicsCalculations.NaiveRotatePointSrcToDest(_src1, _center, _angle);
            var p2 = GraphicsCalculations.NaiveRotatePointSrcToDest(_src2, _center, _angle);
            var p3 = GraphicsCalculations.NaiveRotatePointSrcToDest(_src3, _center, _angle);
            var p4 = GraphicsCalculations.NaiveRotatePointSrcToDest(_src4, _center, _angle);

            var minX = (int)Math.Min(Math.Min(Math.Min(p1.X, p2.X), p3.X), p4.X);
            var minY = (int)Math.Min(Math.Min(Math.Min(p1.Y, p2.Y), p3.Y), p4.Y);
            var maxX = (int)Math.Max(Math.Max(Math.Max(p1.X, p2.X), p3.X), p4.X);
            var maxY = (int)Math.Max(Math.Max(Math.Max(p1.Y, p2.Y), p3.Y), p4.Y);

            return (minX, maxX, minY, maxY);
        }

        public void CountRotatedBitmap()
        {
            var width = _originalBitmap.Width;
            var height = _originalBitmap.Height;
            _rotatedBitmap = new List<(FPoint, Color)>();

            (int minX, int maxX, int minY, int maxY) = CountRotatedBitmapBorders();

            for (int x = minX; x <= maxX; x++)
            {
                for(int y = minY; y <= maxY; y++)
                {
                    var destPixel = new FPoint(x, y);

                    FPoint rotatedBackToSource;
                    if (filtering)
                    {
                        rotatedBackToSource = GraphicsCalculations.RotateWithFilteringDestToSrc(new FPoint(x, y), _center, _angle);
                    }
                    else
                    {
                        rotatedBackToSource = GraphicsCalculations.NaiveRotatePointDestToSrc(new FPoint(x, y), _center, _angle);
                    }

                    var sourceX = rotatedBackToSource.RoundedX - _center.X + width / 2;
                    var sourceY = rotatedBackToSource.RoundedY - _center.Y + height / 2;
                    
                    if (sourceX >= 0 && sourceY >= 0 && sourceX < width && sourceY < height)
                    {
                        var sourceColor = _originalBitmap.GetPixel((int)sourceX, (int)sourceY);
                        _rotatedBitmap.Add((destPixel, sourceColor));
                    }
                }
            }

        }

        public void DrawRotatedBitmap(Bitmap bitmapToDraw)
        {
            var snoopBitmap = new BmpPixelSnoop(bitmapToDraw);

            foreach(var p in _rotatedBitmap)
            {
                var x = p.point.RoundedX;
                var y = p.point.RoundedY;

                if (x >= 0 && x < bitmapToDraw.Width && y >= 0 && y < bitmapToDraw.Height)
                    snoopBitmap.SetPixel(p.point.RoundedX, p.point.RoundedY, p.color);
            }

            snoopBitmap.Dispose();
        }

        public void SetAngle(double angle)
        {
            _angle = angle;
            CountRotatedBitmap();
        }

        public void SetCenter(FPoint newCenter)
        {
            _center = newCenter;
            CountRotatedBitmap();
        }

        public void SetFiltering(bool isFilteringOn)
        {
            filtering = isFilteringOn;
            CountRotatedBitmap();
        }
    }
}
