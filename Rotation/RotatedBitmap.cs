using System;
using System.Collections.Generic;
using System.Drawing;

namespace BeziersCurve.Rotation
{
    public partial class RotatedBitmap
    {
        private readonly BmpPixelSnoop _originalBitmap;

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

        public void CountRotatedBitmap()
        {
            if (_angle == Math.PI) return;
            if (filtering)
            {
                CountRotatedBitmapWithFiltering();
            }
            else
            {
                CountRotatedBitmapNoFiltering();
            }
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
            filtering = isFilteringOn;
            CountRotatedBitmap();
        }
    }
}