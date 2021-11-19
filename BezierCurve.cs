using System.Collections.Generic;
using System.Drawing;

namespace BeziersCurve
{
    public class BezierCurve
    {
        public List<FPoint> polyline { get; private set; } = new List<FPoint>();

        public void DrawPolyline(Graphics g)
        {
            for (int i = 0; i < polyline.Count; i++)
            {
                var nextPoint = polyline[i];
                GraphicsHelpers.DrawDot(g, Brushes.Blue, nextPoint);
                if (i > 0) g.DrawLine(Pens.Green, polyline[i - 1].pointToDraw, polyline[i].pointToDraw);
            }
        }

        public void DrawAdditionalPoint(Graphics g, double t)
        {
            var n = polyline.Count;
            var previouesPoints = new List<FPoint>(polyline);
            

            for(int i = 0; i < n - 1; i++)
            {
                var currentPoints = new List<FPoint>();
                for (int j = 1; j < previouesPoints.Count; j++)
                {
                    var p1 = previouesPoints[j - 1];
                    var p2 = previouesPoints[j];
                    FPoint pointBetween = FPoint.GetPointBetween(p1, p2, t);
                    currentPoints.Add(pointBetween);
                }

                for (int j = 0; j < currentPoints.Count; j++)
                {
                    var nextPoint = currentPoints[j];

                    var colorPower = (double)i / (n - 1) * 205+50;
                    var brush = new SolidBrush(Color.FromArgb((int)colorPower, 0, 0, 0));
                    if (currentPoints.Count == 1) GraphicsHelpers.DrawDot(g, brush, nextPoint, 10);
                    GraphicsHelpers.DrawDot(g, brush, nextPoint);
                    if (j > 0) g.DrawLine(Pens.Red, currentPoints[j - 1].pointToDraw, currentPoints[j].pointToDraw);
                    brush.Dispose();
                }
                previouesPoints = new List<FPoint>(currentPoints);
            }
            
        }

        public void SetNewPolyline(List<FPoint> newPolylinePoints)
        {
            polyline = newPolylinePoints;
        }

        public void MovePoint(int index, FPoint newPosition)
        {
            polyline[index] = newPosition;
        }
    }
}
