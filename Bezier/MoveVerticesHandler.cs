using System.Drawing;
using System.Windows.Forms;
using BeziersCurve.Helpers;

namespace BeziersCurve.Bezier
{
    public class MoveVerticesHandler
    {
        private BezierCurve BezierCurve { get; }
        private PictureBox DrawingArea { get; }
        private bool _moving;
        private int? _indexOfPointToMove; 

        public MoveVerticesHandler(BezierCurve bezierCurve, PictureBox drawingArea)
        {
            BezierCurve = bezierCurve;
            DrawingArea = drawingArea;
        }

        public void HandleMouseMove(MouseEventArgs e)
        {
            var mousePoint = new Point(e.X, e.Y);
            if (_moving)
            {
                if (_indexOfPointToMove != null) BezierCurve.MovePoint(_indexOfPointToMove.Value, mousePoint);
                return;
            }

            foreach (var p in BezierCurve.Polyline)
            {
                if (GraphicsCalculations.IsInCircle(mousePoint, p, Constants.DetectionRadius))
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

            foreach (var p in BezierCurve.Polyline)
            {
                if (GraphicsCalculations.IsInCircle(mousePoint, p, Constants.DetectionRadius))
                {
                    this._indexOfPointToMove = BezierCurve.Polyline.IndexOf(p);
                    _moving = true;
                    return;
                }
            }
        }

        public void HandleMouseUp(MouseEventArgs e)
        {
            _moving = false;
            _indexOfPointToMove = null;
        }
    }
}
