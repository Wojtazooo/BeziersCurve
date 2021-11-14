using System.Collections.Generic;
using System.Drawing;

namespace BeziersCurve
{
    public class BezierCurve
    {
        public List<Point> polyline { get; private set; } = new List<Point>();

        public void DrawPolyline(Graphics g)
        {
            for (int i = 0; i < polyline.Count; i++)
            {
                var nextPoint = polyline[i];
                var R = Constants.POLYLINE_CIRCLE_R;
                g.FillEllipse(Brushes.Blue, new Rectangle(nextPoint.X - R, nextPoint.Y - R, 2 * R, 2 * R));
                if (i > 0) g.DrawLine(Pens.Green, polyline[i - 1], polyline[i]);
            }
        }

        public void SetNewPolyline(List<Point> newPolylinePoints)
        {
            polyline = newPolylinePoints;
        }

        public void MovePoint(int index, Point newPosition)
        {
            polyline[index] = newPosition;
        }
    }
}
