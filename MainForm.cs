using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        private bool AnimationRightDirection = true;
        private int _animationProgress = 0;
        private Bitmap _bitmapToRotate = null;
        private RotatedBitmap _rotatedBitmap = null;
        private bool animationAcitve = false;
        public MainForm()
        {
            InitializeComponent();
            InitializeRefreshTimer();
            InitializeGraphics();
            _bezierCurve = new BezierCurve();
            GenerateButtonClicked(null, null);
            moveVerticesHandler = new MoveVerticesHandler(_bezierCurve, drawingArea);
            _bitmapToRotate = new Bitmap(ImagePreview.Image);
            GenerateRotatedBitmap();
        }

        private void InitializeGraphics()
        {
            if (drawingArea.Image == null)
            {
                drawingArea.Image = new Bitmap(drawingArea.Width, drawingArea.Height);
            }
            drawingAreaGraphics = Graphics.FromImage(drawingArea.Image);
        }

        private void GenerateRotatedBitmap()
        {
            _rotatedBitmap = new RotatedBitmap(_bitmapToRotate, new FPoint(drawingArea.Width/2, drawingArea.Height/2), 0, filteringCheckBox.Checked);
        }

        private void GenerateBezierCurve(int numberOfVertices)
        {
            var dx = drawingArea.Width / (numberOfVertices + 1);
            var drawingAreaMiddleY = drawingArea.Height / 2;

            Random random = new Random();

            List<FPoint> polylinePoints = new List<FPoint>();
            for(int i = 0; i < numberOfVertices; i++)
            {
                var yRandomizer = random.NextDouble() * 2 - 1;

                polylinePoints.Add(new FPoint(dx * (i + 1), (int)(drawingAreaMiddleY + yRandomizer*drawingAreaMiddleY)));
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

            if(animationAcitve)
            {
                if (_animationProgress == Constants.ANIMATION_RANGE) AnimationRightDirection = false;
                else if (_animationProgress == 0) AnimationRightDirection = true;
                if (AnimationRightDirection) _animationProgress++;
                if (!AnimationRightDirection) _animationProgress--;
                AnimationLevel.Value = _animationProgress;
            }

            if(drawPolylineCheckbox.Checked) _bezierCurve?.DrawPolyline(drawingAreaGraphics);
            if(DrawAnimationCheckBox.Checked)
            {
                var t = (double)_animationProgress / Constants.ANIMATION_RANGE;
                _bezierCurve?.DrawAdditionalPoint(drawingAreaGraphics,t);
            }
            _bezierCurve?.DrawBezierLine(drawingAreaGraphics);



            var currentProgress = (double)_animationProgress / Constants.ANIMATION_RANGE;
            var currentPointOnBezier = _bezierCurve.bezierCurvePoints[(int)(currentProgress * (_bezierCurve.bezierCurvePoints.Count - 1))];


            var bitmapToDraw = (Bitmap)drawingArea.Image;


            if (DrawImage.Checked)
            {
                if (rotatingCheckbox.Checked)
                {
                    var angle = currentProgress * 2 * Math.PI;
                    _rotatedBitmap.SetAngle(angle);
                }
                else if (rotationWithCurveCheckbox.Checked)
                {
                    var angle = _bezierCurve.angles[currentPointOnBezier];
                    _rotatedBitmap.SetAngle(angle);
                    _rotatedBitmap.SetCenter(currentPointOnBezier);

                }
                _rotatedBitmap?.DrawRotatedBitmap(bitmapToDraw);
            }
            
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

        private void numberOfPointsInput_ValueChanged(object sender, EventArgs e)
        {
            GenerateButtonClicked(null, null);
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            animationAcitve = true;
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            animationAcitve = false;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            _animationProgress = AnimationLevel.Value;
        }

        private void filteringCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _rotatedBitmap.SetFiltering(filteringCheckBox.Checked);
        }

        private Bitmap OpenBitmapDialog()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var path = openFileDialog.FileName;
                if (Constants.ImageExtensions.Contains(Path.GetExtension(path).ToUpperInvariant()))
                {
                    return (Bitmap)Bitmap.FromFile(path);
                }
                else
                {
                    MessageBox.Show($"Invalid extension", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return null;
        }

        private void LoadImageButton_Click(object sender, EventArgs e)
        {
            var bitmapToSet = OpenBitmapDialog();
            if(bitmapToSet != null)
            {
                _bitmapToRotate = new Bitmap(bitmapToSet, new Size((int)ImageWidthInput.Value, (int)ImageHeightInput.Value));
                ImagePreview.Image = new Bitmap(bitmapToSet, new Size((int)ImagePreview.Width, (int)ImagePreview.Height));
                GenerateRotatedBitmap();
            }
        }

        private void HandleResize()
        {
            var resizedBitmap = new Bitmap(ImagePreview.Image, new Size((int)ImageWidthInput.Value, (int)ImageHeightInput.Value));
            _bitmapToRotate = new Bitmap(resizedBitmap);
            resizedBitmap.Dispose();
            GenerateRotatedBitmap();
        }

        private void ImageWidthInput_ValueChanged(object sender, EventArgs e)
        {
            HandleResize();
        }

        private void ImageHeightInput_ValueChanged(object sender, EventArgs e)
        {
            HandleResize();
        }
    }
}
