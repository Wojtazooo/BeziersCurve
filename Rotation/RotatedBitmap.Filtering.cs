using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BeziersCurve.Rotation
{
    public partial class RotatedBitmap
    {
        private void CountRotatedBitmapWithFiltering()
        {
            var width = _originalBitmap.Width;
            var height = _originalBitmap.Height;
            _rotatedBitmap = new List<(FPoint, Color)>();

            var initialDictionary = new Dictionary<(int, int), Color>();

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    initialDictionary.Add((x - width / 2, y - height / 2), _originalBitmap.GetPixel(x, y));
                }
            }


            // SHEAR X
            var shearXFirstDictionary = new Dictionary<(int, int), Color>();
            var (destMinX, destMaxX, destMinY, destMaxY) = CountRotatedBitmapBordersShearX(
                new FPoint(-width / 2, -height / 2),
                new FPoint(width / 2, -height / 2),
                new FPoint(width / 2, height / 2),
                new FPoint(-width / 2, height / 2)
            );
            for (int x = destMinX; x <= destMaxX; x++)
            {
                for (int y = destMinY; y <= destMaxY; y++)
                {
                    var destPixel = new FPoint(x, y);
                    FPoint rotatedBackToSource = GraphicsCalculations.ShearXDestToSrc(x, y, _angle);

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
                new FPoint(destMinX, destMaxY)
            );

            for (int x = destMinX; x <= destMaxX; x++)
            {
                for (int y = destMinY; y <= destMaxY; y++)
                {
                    var destPixel = new FPoint(x, y);
                    FPoint rotatedBackToSource = GraphicsCalculations.ShearYDestToSrc(x, y, _angle);

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
                new FPoint(destMinX, destMaxY)
            );

            for (int x = destMinX; x <= destMaxX; x++)
            {
                for (int y = destMinY; y <= destMaxY; y++)
                {
                    var destPixel = new FPoint(x, y);
                    FPoint rotatedBackToSource = GraphicsCalculations.ShearXDestToSrc(x, y, _angle);

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
            FPoint src3, FPoint src4)
        {
            var p1 = GraphicsCalculations.ShearXSrcToDest(src1.X, src1.Y, _angle);
            var p2 = GraphicsCalculations.ShearXSrcToDest(src2.X, src2.Y, _angle);
            var p3 = GraphicsCalculations.ShearXSrcToDest(src3.X, src3.Y, _angle);
            var p4 = GraphicsCalculations.ShearXSrcToDest(src4.X, src4.Y, _angle);

            var minX = (int) Math.Min(Math.Min(Math.Min(p1.X, p2.X), p3.X), p4.X);
            var minY = (int) Math.Min(Math.Min(Math.Min(p1.Y, p2.Y), p3.Y), p4.Y);
            var maxX = (int) Math.Max(Math.Max(Math.Max(p1.X, p2.X), p3.X), p4.X);
            var maxY = (int) Math.Max(Math.Max(Math.Max(p1.Y, p2.Y), p3.Y), p4.Y);

            return (minX, maxX, minY, maxY);
        }

        private (int minX, int maxX, int minY, int maxY) CountRotatedBitmapBordersShearY(FPoint src1, FPoint src2,
            FPoint src3, FPoint src4)
        {
            var p1 = GraphicsCalculations.ShearYSrcToDest(src1.X, src1.Y, _angle);
            var p2 = GraphicsCalculations.ShearYSrcToDest(src2.X, src2.Y, _angle);
            var p3 = GraphicsCalculations.ShearYSrcToDest(src3.X, src3.Y, _angle);
            var p4 = GraphicsCalculations.ShearYSrcToDest(src4.X, src4.Y, _angle);

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

                var R = downColor.Value.R * (pointToUpDiff / 1.0) + upColor.Value.R * (pointToDownDiff / 1.0);
                var G = downColor.Value.G * (pointToUpDiff / 1.0) + upColor.Value.G * (pointToDownDiff / 1.0);
                var B = downColor.Value.B * (pointToUpDiff / 1.0) + upColor.Value.B * (pointToDownDiff / 1.0);

                return Color.FromArgb((int) R, (int) G, (int) B);
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

                var R = leftColor.Value.R * (pointToRDiff / 1.0) + rightColor.Value.R * (pointToLDiff / 1.0);
                var G = leftColor.Value.G * (pointToRDiff / 1.0) + rightColor.Value.G * (pointToLDiff / 1.0);
                var B = leftColor.Value.B * (pointToRDiff / 1.0) + rightColor.Value.B * (pointToLDiff / 1.0);

                return Color.FromArgb((int) R, (int) G, (int) B);
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

        private Color? GetColorFromBitmapShearX(BmpPixelSnoop bitmap, double x, double y)
        {
            if (y < 0 || y >= bitmap.Height) return null;

            var (leftX, leftY) = ((int) Math.Floor(x), (int) Math.Floor(y));
            var (rightX, rightY) = ((int) Math.Floor(x) + 1, (int) Math.Floor(y));

            if (leftX >= bitmap.Width) return null;
            if (rightX < 0) return null;

            if (leftX < 0)
            {
                return bitmap.GetPixel(rightX, rightY);
            }
            else if (rightX >= bitmap.Width)
            {
                return bitmap.GetPixel(leftX, leftY);
            }
            else
            {
                var pointToRDiff = Math.Abs(rightX - x);
                var pointToLDiff = Math.Abs(x - leftX);

                var leftColor = bitmap.GetPixel(leftX, leftY);
                var rightColor = bitmap.GetPixel(rightX, rightY);


                var R = leftColor.R * (pointToRDiff / 1.0) + rightColor.R * (pointToLDiff / 1.0);
                var G = leftColor.G * (pointToRDiff / 1.0) + rightColor.G * (pointToLDiff / 1.0);
                var B = leftColor.B * (pointToRDiff / 1.0) + rightColor.B * (pointToLDiff / 1.0);

                return Color.FromArgb((int) R, (int) G, (int) B);
            }
        }
    }
}