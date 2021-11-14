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
        private MoveVerticesHandler moveVerticesHandler;
        public MainForm()
        {
            InitializeComponent();
            InitializeRefreshTimer();
            InitializeGraphics();
            _bezierCurve = new BezierCurve();
            GenerateButtonClicked(null, null);
            moveVerticesHandler = new MoveVerticesHandler(_bezierCurve, drawingArea);
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
            _bezierCurve.SetNewPolyline(polylinePoints);
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

        private void drawingArea_MouseMove(object sender, MouseEventArgs e)
        {
            moveVerticesHandler?.HandleMouseMove(e);
        }

        private void drawingArea_MouseDown(object sender, MouseEventArgs e)
        {
            moveVerticesHandler?.HandleMouseDown(e);
        }

        private void drawingArea_MouseUp(object sender, MouseEventArgs e)
        {
            moveVerticesHandler?.HandleMouseUp(e);
        }
    }
}
