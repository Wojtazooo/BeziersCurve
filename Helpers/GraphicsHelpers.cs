using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeziersCurve
{
    public static class GraphicsHelpers
    {
        public static void DrawDot(Graphics g, Brush brush, FPoint center, int R = Constants.DOT_R)
        {
            g.FillEllipse(brush, new Rectangle(center.RoundedX - R, center.RoundedY - R, 2 * R, 2 * R));
        }
    }
}
