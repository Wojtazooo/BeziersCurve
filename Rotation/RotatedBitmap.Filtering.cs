using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using BeziersCurve.GraphicObjects;
using BeziersCurve.Helpers;

namespace BeziersCurve.Rotation
{
    public partial class RotatedBitmap
    {
        private void CountRotatedBitmapWithFiltering(BmpPixelSnoop bitmapToRotate, double angle)
        {
            var width = bitmapToRotate.Width;
            var height = bitmapToRotate.Height;
            _rotatedBitmap = new List<(FPoint, Color)>();

            var initialDictionary = new Dictionary<(int, int), Color>();

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    initialDictionary.Add((x - width / 2, y - height / 2), bitmapToRotate.GetPixel(x, y));
                }
            }


            // SHEAR X
            var shearXFirstDictionary = new Dictionary<(int, int), Color>();
            var (destMinX, destMaxX, destMinY, destMaxY) = CountRotatedBitmapBordersShearX(
                new(-width / 2.0, -height / 2.0),
                new(x: width / 2.0, -height / 2.0),
                new(width / 2.0, height / 2.0),
                new(-width / 2.0, height / 2.0),
                angle
            );
            for (var x = destMinX; x <= destMaxX; x++)
            {
                for (var y = destMinY; y <= destMaxY; y++)
                {
                    var destPixel = new FPoint(x, y);
                    var rotatedBackToSource = GraphicsCalculations.ShearXDestToSrc(x, y, angle);

                    var sourceColor =
                        GetEstimatedColorShearX(initialDictionary, rotatedBackToSource.X, rotatedBackToSource.Y);

                    if (sourceColor.HasValue)
                    {
                        shearXFirstDictionary.Add((destPixel.RoundedX, destPixel.RoundedY), sourceColor.Value);
                    }
                }
            }

            //SHEAR Y
            var shearYDictionary = new Dictionary<(int, int), Color>();
            (destMinX, destMaxX, destMinY, destMaxY) = CountRotatedBitmapBordersShearY(
                new FPoint(destMinX, destMinY),
                new FPoint(destMaxX, destMinY),
                new FPoint(destMaxX, destMaxY),
                new FPoint(destMinX, destMaxY),
                angle
            );

            for (int x = destMinX; x <= destMaxX; x++)
            {
                for (int y = destMinY; y <= destMaxY; y++)
                {
                    var destPixel = new FPoint(x, y);
                    FPoint rotatedBackToSource = GraphicsCalculations.ShearYDestToSrc(x, y, angle);

                    var sourceColor =
                        GetEstimatedColorShearY(shearXFirstDictionary, rotatedBackToSource.X, rotatedBackToSource.Y);

                    if (sourceColor.HasValue)
                    {
                        shearYDictionary.Add((destPixel.RoundedX, destPixel.RoundedY), sourceColor.Value);
                    }
                }
            }

            //SHEAR X second time
            var shearXSecondTimeDictionary = new Dictionary<(int, int), Color>();
            (destMinX, destMaxX, destMinY, destMaxY) = CountRotatedBitmapBordersShearX(
                new FPoint(destMinX, destMinY),
                new FPoint(destMaxX, destMinY),
                new FPoint(destMaxX, destMaxY),
                new FPoint(destMinX, destMaxY),
                angle
            );

            for (int x = destMinX; x <= destMaxX; x++)
            {
                for (int y = destMinY; y <= destMaxY; y++)
                {
                    var destPixel = new FPoint(x, y);
                    FPoint rotatedBackToSource = GraphicsCalculations.ShearXDestToSrc(x, y, angle);

                    var sourceColor =
                        GetEstimatedColorShearX(shearYDictionary, rotatedBackToSource.X, rotatedBackToSource.Y);

                    if (sourceColor.HasValue)
                    {
                        shearXSecondTimeDictionary.Add((destPixel.RoundedX, destPixel.RoundedY), sourceColor.Value);
                    }
                }
            }

            _rotatedBitmap.AddRange(
                shearXSecondTimeDictionary
                    .Select(x =>
                        (new FPoint(
                                x.Key.Item1 + _center.RoundedX,
                                x.Key.Item2 + _center.RoundedY),
                            x.Value)));
        }

        private (int minX, int maxX, int minY, int maxY) CountRotatedBitmapBordersShearX(FPoint src1, FPoint src2,
            FPoint src3, FPoint src4, double angle)
        {
            var p1 = GraphicsCalculations.ShearXSrcToDest(src1.X, src1.Y, angle);
            var p2 = GraphicsCalculations.ShearXSrcToDest(src2.X, src2.Y, angle);
            var p3 = GraphicsCalculations.ShearXSrcToDest(src3.X, src3.Y, angle);
            var p4 = GraphicsCalculations.ShearXSrcToDest(src4.X, src4.Y, angle);

            var minX = (int) Math.Min(Math.Min(Math.Min(p1.X, p2.X), p3.X), p4.X);
            var minY = (int) Math.Min(Math.Min(Math.Min(p1.Y, p2.Y), p3.Y), p4.Y);
            var maxX = (int) Math.Max(Math.Max(Math.Max(p1.X, p2.X), p3.X), p4.X);
            var maxY = (int) Math.Max(Math.Max(Math.Max(p1.Y, p2.Y), p3.Y), p4.Y);

            return (minX, maxX, minY, maxY);
        }

        private (int minX, int maxX, int minY, int maxY) CountRotatedBitmapBordersShearY(FPoint src1, FPoint src2,
            FPoint src3, FPoint src4, double angle)
        {
            var p1 = GraphicsCalculations.ShearYSrcToDest(src1.X, src1.Y, angle);
            var p2 = GraphicsCalculations.ShearYSrcToDest(src2.X, src2.Y, angle);
            var p3 = GraphicsCalculations.ShearYSrcToDest(src3.X, src3.Y, angle);
            var p4 = GraphicsCalculations.ShearYSrcToDest(src4.X, src4.Y, angle);

            var minX = (int) Math.Min(Math.Min(Math.Min(p1.X, p2.X), p3.X), p4.X);
            var minY = (int) Math.Min(Math.Min(Math.Min(p1.Y, p2.Y), p3.Y), p4.Y);
            var maxX = (int) Math.Max(Math.Max(Math.Max(p1.X, p2.X), p3.X), p4.X);
            var maxY = (int) Math.Max(Math.Max(Math.Max(p1.Y, p2.Y), p3.Y), p4.Y);

            return (minX, maxX, minY, maxY);
        }

       
        private Color? GetEstimatedColorShearY(Dictionary<(int, int), Color> points, double x, double y)
        {
            var upPoint = ((int) Math.Floor(x), (int) Math.Floor(y) + 1);
            var downPoint = ((int) Math.Floor(x), (int) Math.Floor(y));

            Color? upColor = points.ContainsKey(upPoint) ? points[upPoint] : null;
            Color? downColor = points.ContainsKey(downPoint) ? points[downPoint] : null;

            if (upColor != null && downColor != null)
            {
                var pointToUpDiff = Math.Abs(upPoint.Item2 - y);
                var pointToDownDiff = Math.Abs(y - downPoint.Item2);

                var r = downColor.Value.R * (pointToUpDiff / 1.0) + upColor.Value.R * (pointToDownDiff / 1.0);
                var g = downColor.Value.G * (pointToUpDiff / 1.0) + upColor.Value.G * (pointToDownDiff / 1.0);
                var b = downColor.Value.B * (pointToUpDiff / 1.0) + upColor.Value.B * (pointToDownDiff / 1.0);

                return Color.FromArgb((int) r, (int) g, (int) b);
            }
            else if (upColor != null)
            {
                return upColor;
            }
            else if (downColor != null)
            {
                return downColor;
            }
            else
            {
                return null;
            }
        }

        private Color? GetEstimatedColorShearX(Dictionary<(int, int), Color> points, double x, double y)
        {
            var leftPoint = ((int) Math.Floor(x), (int) Math.Floor(y));
            var rightPoint = ((int) Math.Floor(x) + 1, (int) Math.Floor(y));

            Color? leftColor = points.ContainsKey(leftPoint) ? points[leftPoint] : null;
            Color? rightColor = points.ContainsKey(rightPoint) ? points[rightPoint] : null;

            if (leftColor != null && rightColor != null)
            {
                var pointToRDiff = Math.Abs(rightPoint.Item1 - x);
                var pointToLDiff = Math.Abs(x - leftPoint.Item1);

                var r = leftColor.Value.R * (pointToRDiff / 1.0) + rightColor.Value.R * (pointToLDiff / 1.0);
                var g = leftColor.Value.G * (pointToRDiff / 1.0) + rightColor.Value.G * (pointToLDiff / 1.0);
                var b = leftColor.Value.B * (pointToRDiff / 1.0) + rightColor.Value.B * (pointToLDiff / 1.0);

                return Color.FromArgb((int) r, (int) g, (int) b);
            }
            else if (rightColor != null)
            {
                return rightColor;
            }
            else if (leftColor != null)
            {
                return leftColor;
            }
            else
            {
                return null;
            }
        }
    }
}