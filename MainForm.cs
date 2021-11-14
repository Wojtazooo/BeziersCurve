using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeziersCurve
{
    public partial class MainForm : Form
    {
        private Timer _renderingTimer;
        private BezierCurve _bezierCurve;
        private Graphics drawingAreaGraphics;
        public MainForm()
        {
            InitializeComponent();
            InitializeRefreshTimer();
            InitializeGraphics();
        }

        private void InitializeGraphics()
        {
            if (drawingArea.Image == null)
            {
                drawingArea.Image = new Bitmap(drawingArea.Width, drawingArea.Height);
            }
            drawingAreaGraphics = Graphics.FromImage(drawingArea.Image);
        }

        private void GenerateBezierCurve(int numberOfVertices)
        {
            var dx = drawingArea.Width / (numberOfVertices + 1);
            var drawingAreaMiddleY = drawingArea.Height / 2;

            List<Point> polylinePoints = new List<Point>();
            for(int i = 0; i < numberOfVertices; i++)
            {
                polylinePoints.Add(new Point(dx * (i + 1), drawingAreaMiddleY));
            }
            _bezierCurve = new BezierCurve(polylinePoints);
        }

        private void InitializeRefreshTimer()
        {
            _renderingTimer = new Timer();
            _renderingTimer.Interval = Constants.REFRESH_TIME_IN_MS;
            _renderingTimer.Tick += UpdateView;
            _renderingTimer.Start();
        }

        private void UpdateView(object sender, EventArgs e)
        {
            drawingAreaGraphics.Clear(Color.White);
            _bezierCurve?.DrawPolyline(drawingAreaGraphics);
            drawingArea.Invalidate();
        }

        private void GenerateButtonClicked(object sender, EventArgs e)
        {
            GenerateBezierCurve((int)numberOfPointsInput.Value);
        }
    }

    public class BezierCurve
    {
        private List<Point> polyline = new List<Point>();

        public BezierCurve(List<Point> initalPolylinePoints)
        {
            polyline = new List<Point>(initalPolylinePoints);
        }
        public void DrawPolyline(Graphics g)
        {
            for(int i = 0; i < polyline.Count; i++)
            {
                var nextPoint = polyline[i];
                var R = Constants.POLYLINE_CIRCLE_R;
                g.FillEllipse(Brushes.Blue, new Rectangle(nextPoint.X - R, nextPoint.Y - R, 2*R, 2*R));
                if (i > 0) g.DrawLine(Pens.Green, polyline[i - 1], polyline[i]);
            }
        }
    }
}
