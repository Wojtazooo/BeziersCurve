using System;
using System.Collections.Generic;
using System.Drawing;
using BeziersCurve.GraphicObjects;
using BeziersCurve.Helpers;

namespace BeziersCurve.Bezier
{
    public class BezierCurve
    {
        public List<FPoint> Polyline { get; private set; } = new ();
        public List<FPoint> BezierCurvePoints { get; private set; }
        public Dictionary<FPoint, double> Angles { get; private set; }
        private bool _updateInNextRerender = true;

        public void DrawPolyline(Graphics g)
        {
            for (var i = 0; i < Polyline.Count; i++)
            {
                var nextPoint = Polyline[i];
                GraphicsHelpers.DrawDot(g, Brushes.Blue, nextPoint);
                if (i > 0) g.DrawLine(Pens.Green, Polyline[i - 1].PointToDraw, Polyline[i].PointToDraw);
            }
        }

        public int CountMaxWidthHeight()
        {
            var minY = int.MaxValue; var maxY = int.MinValue;
            var minX = int.MaxValue; var maxX = int.MinValue;

            foreach(var p in Polyline)
            {
                if(p.X < minX) minX = p.RoundedX;
                if (p.Y < minY) minY = p.RoundedY;
                if (p.X > maxX) maxX = p.RoundedX; 
                if (p.Y > maxY) maxY = p.RoundedY;
            }
            return Math.Max(maxX - minX, maxY - minY);
        }

        public void DrawBezierLine(Graphics g)
        {
            if(_updateInNextRerender)
            {
                CountBezierLine();
                _updateInNextRerender = false;
            }
            for (var i = 1; i < BezierCurvePoints.Count; i++) g.DrawLine(Pens.Black, BezierCurvePoints[i], BezierCurvePoints[i - 1]);
        }

        private void CountBezierLine()
        {
            var tMax = CountMaxWidthHeight();

            var t = 0.0;
            var dt = 1.0 / tMax;

            var n = Polyline.Count;
            BezierCurvePoints = new List<FPoint>();
            Angles = new Dictionary<FPoint, double>();

            while (t < 1)
            {
                var previousPoints = new List<FPoint>(Polyline);
                var angle = 0.0;
                for (var i = 0; i < n - 1; i++)
                {
                    var currentPoints = new List<FPoint>();
                    for (var j = 1; j < previousPoints.Count; j++)
                    {
                        var p1 = previousPoints[j - 1];
                        var p2 = previousPoints[j];
                        var pointBetween = FPoint.GetPointBetween(p1, p2, t);
                        currentPoints.Add(pointBetween);
                    }
                    if (currentPoints.Count == 2)
                    {
                        angle = GraphicsCalculations.CountAngle(currentPoints[0], currentPoints[1]);
                    }
                    else if (currentPoints.Count == 1)
                    { 
                        BezierCurvePoints.Add(currentPoints[0]);
                        Angles.Add(currentPoints[0], angle);
                    }

                    previousPoints = new List<FPoint>(currentPoints);
                }
                t += dt;
            }
        }

        public void DrawAdditionalPoint(Graphics g, double t)
        {
            var n = Polyline.Count;
            var previousPoints = new List<FPoint>(Polyline);
            

            for(var i = 0; i < n - 1; i++)
            {
                var currentPoints = new List<FPoint>();
                for (var j = 1; j < previousPoints.Count; j++)
                {
                    var p1 = previousPoints[j - 1];
                    var p2 = previousPoints[j];
                    var pointBetween = FPoint.GetPointBetween(p1, p2, t);
                    currentPoints.Add(pointBetween);
                }

                for (var j = 0; j < currentPoints.Count; j++)
                {
                    var nextPoint = currentPoints[j];

                    var colorPower = (double)i / (n - 1) * 205+50;
                    var brush = new SolidBrush(Color.FromArgb((int)colorPower, 0, 0, 0));
                    if (currentPoints.Count == 1) GraphicsHelpers.DrawDot(g, brush, nextPoint, 10);
                    GraphicsHelpers.DrawDot(g, brush, nextPoint);
                    if (j > 0) g.DrawLine(Pens.Red, currentPoints[j - 1].PointToDraw, currentPoints[j].PointToDraw);
                    brush.Dispose();
                }
                previousPoints = currentPoints;
            }
            
        }

        public void SetNewPolyline(List<FPoint> newPolylinePoints)
        {
            Polyline = newPolylinePoints;
            _updateInNextRerender = true;
        }

        public void MovePoint(int index, FPoint newPosition)
        {
            Polyline[index] = newPosition;
            _updateInNextRerender = true;
        }
    }
}
