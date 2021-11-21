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

        public RotatedBitmap(Bitmap bitmapToRotate, FPoint center, double angle)
        {
            _originalBitmap = new BmpPixelSnoop(bitmapToRotate);
            _angle = angle;
            _center = center;
            CountRotatedBitmap();
        }

        public void CountRotatedBitmap()
        {
            var width = _originalBitmap.Width; ;
            var height = _originalBitmap.Height;

            _rotatedBitmap = new List<(FPoint, Color)>();
            for(int i = 0; i < width; i++)
            {
                for(int j = 0; j < height; j++)
                {
                    var pointToRotate = new FPoint(i + _center.X - width / 2.0, j + _center.Y - height / 2.0);
                    var rotatedPoint = GraphicsCalculations.RotatePointByAngle(pointToRotate, _center, _angle);
                    var color = _originalBitmap.GetPixel(i, j);

                    _rotatedBitmap.Add((rotatedPoint, color));
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
    }
}
