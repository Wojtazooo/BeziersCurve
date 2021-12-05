using System.Drawing;
using BeziersCurve.GraphicObjects;

namespace BeziersCurve.Helpers
{
    public static class GraphicsHelpers
    {
        public static void DrawDot(Graphics g, Brush brush, FPoint center, int r = Constants.DotR)
        {
            g.FillEllipse(brush, new Rectangle(center.RoundedX - r, center.RoundedY - r, 2 * r, 2 * r));
        }
    }
}
