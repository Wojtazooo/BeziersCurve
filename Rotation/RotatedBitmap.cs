using System;
using System.Collections.Generic;
using System.Drawing;
using BeziersCurve.GraphicObjects;

namespace BeziersCurve.Rotation
{
    public partial class RotatedBitmap
    {
        private readonly BmpPixelSnoop _originalBitmap;
        private BmpPixelSnoop _originalBitmap180;

        private List<(FPoint point, Color color)> _rotatedBitmap;
        private FPoint _center;
        private double _angle;
        private bool _filtering;

        public RotatedBitmap(Bitmap bitmapToRotate, FPoint center, double angle, bool filteringOn)
        {
            _originalBitmap = new BmpPixelSnoop(bitmapToRotate);
            GenerateBitmap180();
            _center = center;
            _angle = angle;
            _filtering = filteringOn;
            CountRotatedBitmap();
        }

        public void CountRotatedBitmap()
        {
            if (_angle == Math.PI) return;
            if (_filtering)
            {
                if (_angle is < Math.PI/2 or > 3*Math.PI/2)
                {
                    CountRotatedBitmapWithFiltering(_originalBitmap, _angle);

                }
                else
                {
                    CountRotatedBitmapWithFiltering(_originalBitmap180, _angle - Math.PI);
                }
            }
            else
            {
                CountRotatedBitmapNoFiltering();
            }
        }

        private void GenerateBitmap180()
        {
            _angle = Math.PI;
            _center = new FPoint(_originalBitmap.Width/2 - 1, _originalBitmap.Height/2 - 1);
            CountRotatedBitmapNoFiltering();
            var bitmap180 = new Bitmap(_originalBitmap.Width, _originalBitmap.Height);
            DrawRotatedBitmap(bitmap180);
            _originalBitmap180 = new BmpPixelSnoop(bitmap180);
        }

        public void DrawRotatedBitmap(Bitmap bitmapToDraw)
        {
            var snoopBitmap = new BmpPixelSnoop(bitmapToDraw);

            foreach (var p in _rotatedBitmap)
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
            _filtering = isFilteringOn;
            CountRotatedBitmap();
        }
    }
}