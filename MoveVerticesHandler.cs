using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeziersCurve
{
    public class MoveVerticesHandler
    {
        private BezierCurve BezierCurve { get; set; }
        private PictureBox DrawingArea { get; set; }
        private bool moving = false;
        private int? indexOfPointToMove = null; 

        public MoveVerticesHandler(BezierCurve bezierCurve, PictureBox drawingArea)
        {
            BezierCurve = bezierCurve;
            DrawingArea = drawingArea;
        }

        public void HandleMouseMove(MouseEventArgs e)
        {
            var mousePoint = new Point(e.X, e.Y);
            if (moving)
            {
                BezierCurve.polyline[indexOfPointToMove.Value] = mousePoint;
                return;
            }

            foreach (var p in BezierCurve.polyline)
            {
                if (GraphicsCalculations.IsInCircle(mousePoint, p, Constants.DETECTION_RADIUS))
                {
                    DrawingArea.Cursor = Cursors.Hand;
                    return;
                }
            }
            DrawingArea.Cursor = Cursors.Default;
        }

        public void HandleMouseDown(MouseEventArgs e)
        {
            var mousePoint = new Point(e.X, e.Y);

            foreach (var p in BezierCurve.polyline)
            {
                if (GraphicsCalculations.IsInCircle(mousePoint, p, Constants.DETECTION_RADIUS))
                {
                    this.indexOfPointToMove = BezierCurve.polyline.IndexOf(p);
                    moving = true;
                    return;
                }
            }
        }

        public void HandleMouseUp(MouseEventArgs e)
        {
            moving = false;
            indexOfPointToMove = null;
        }
    }
}
