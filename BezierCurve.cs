﻿using System;
using System.Collections.Generic;
using System.Drawing;

namespace BeziersCurve
{
    public class BezierCurve
    {
        public List<FPoint> polyline { get; private set; } = new List<FPoint>();
        public List<FPoint> bezierCurvePoints { get; private set; }
        public Dictionary<FPoint, double> angles { get; private set; }
        
        
        private bool _updateInNextRerender = true;

        public void DrawPolyline(Graphics g)
        {
            for (int i = 0; i < polyline.Count; i++)
            {
                var nextPoint = polyline[i];
                GraphicsHelpers.DrawDot(g, Brushes.Blue, nextPoint);
                if (i > 0) g.DrawLine(Pens.Green, polyline[i - 1].pointToDraw, polyline[i].pointToDraw);
            }
        }

        public int CountMaxWidthHeight()
        {
            var minY = int.MaxValue; var maxY = int.MinValue;
            var minX = int.MaxValue; var maxX = int.MinValue;

            foreach(var p in polyline)
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
            for (int i = 1; i < bezierCurvePoints.Count; i++) g.DrawLine(Pens.Black, bezierCurvePoints[i], bezierCurvePoints[i - 1]);
        }

        private void CountBezierLine()
        {
            var tMax = CountMaxWidthHeight();

            var t = 0.0;
            var dt = 1.0 / tMax;

            var n = polyline.Count;
            bezierCurvePoints = new List<FPoint>();
            angles = new Dictionary<FPoint, double>();

            while (t < 1)
            {
                var previouesPoints = new List<FPoint>(polyline);
                var angle = 0.0;
                for (int i = 0; i < n - 1; i++)
                {
                    var currentPoints = new List<FPoint>();
                    for (int j = 1; j < previouesPoints.Count; j++)
                    {
                        var p1 = previouesPoints[j - 1];
                        var p2 = previouesPoints[j];
                        FPoint pointBetween = FPoint.GetPointBetween(p1, p2, t);
                        currentPoints.Add(pointBetween);
                    }
                    if (currentPoints.Count == 2)
                    {
                        angle = GraphicsCalculations.CountAngle(currentPoints[0], currentPoints[1]);
                    }
                    else if (currentPoints.Count == 1)
                    { 
                        bezierCurvePoints.Add(currentPoints[0]);
                        angles.Add(currentPoints[0], angle);
                    }

                    previouesPoints = new List<FPoint>(currentPoints);
                }
                t += dt;
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
                previouesPoints = currentPoints;
            }
            
        }

        public void SetNewPolyline(List<FPoint> newPolylinePoints)
        {
            polyline = newPolylinePoints;
            _updateInNextRerender = true;
        }

        public void MovePoint(int index, FPoint newPosition)
        {
            polyline[index] = newPosition;
            _updateInNextRerender = true;
        }
    }
}
