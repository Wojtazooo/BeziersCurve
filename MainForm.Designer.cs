
namespace BeziersCurve
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.drawingArea = new System.Windows.Forms.PictureBox();
            this.generateButton = new System.Windows.Forms.Button();
            this.NumberOfPointsLabel = new System.Windows.Forms.Label();
            this.numberOfPointsInput = new System.Windows.Forms.NumericUpDown();
            this.drawPolylineCheckbox = new System.Windows.Forms.CheckBox();
            this.DrawAnimationCheckBox = new System.Windows.Forms.CheckBox();
            this.playButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.AnimationLevel = new System.Windows.Forms.TrackBar();
            this.rotatingCheckbox = new System.Windows.Forms.RadioButton();
            this.rotationWithCurveCheckbox = new System.Windows.Forms.RadioButton();
            this.filteringCheckBox = new System.Windows.Forms.CheckBox();
            this.PolylineOptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ImageHeightInput = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ImageWidthInput = new System.Windows.Forms.NumericUpDown();
            this.LoadImageButton = new System.Windows.Forms.Button();
            this.ImagePreview = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.drawingArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfPointsInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnimationLevel)).BeginInit();
            this.PolylineOptionsGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageHeightInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageWidthInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImagePreview)).BeginInit();
            this.SuspendLayout();
            // 
            // drawingArea
            // 
            this.drawingArea.Location = new System.Drawing.Point(12, 12);
            this.drawingArea.Name = "drawingArea";
            this.drawingArea.Size = new System.Drawing.Size(1153, 837);
            this.drawingArea.TabIndex = 0;
            this.drawingArea.TabStop = false;
            this.drawingArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawingArea_MouseDown);
            this.drawingArea.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawingArea_MouseMove);
            this.drawingArea.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawingArea_MouseUp);
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(27, 71);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(151, 23);
            this.generateButton.TabIndex = 2;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.GenerateButtonClicked);
            // 
            // NumberOfPointsLabel
            // 
            this.NumberOfPointsLabel.AutoSize = true;
            this.NumberOfPointsLabel.Location = new System.Drawing.Point(49, 24);
            this.NumberOfPointsLabel.Name = "NumberOfPointsLabel";
            this.NumberOfPointsLabel.Size = new System.Drawing.Size(101, 15);
            this.NumberOfPointsLabel.TabIndex = 3;
            this.NumberOfPointsLabel.Text = "Number of points";
            // 
            // numberOfPointsInput
            // 
            this.numberOfPointsInput.Location = new System.Drawing.Point(27, 42);
            this.numberOfPointsInput.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numberOfPointsInput.Name = "numberOfPointsInput";
            this.numberOfPointsInput.Size = new System.Drawing.Size(151, 23);
            this.numberOfPointsInput.TabIndex = 4;
            this.numberOfPointsInput.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numberOfPointsInput.ValueChanged += new System.EventHandler(this.numberOfPointsInput_ValueChanged);
            // 
            // drawPolylineCheckbox
            // 
            this.drawPolylineCheckbox.AutoSize = true;
            this.drawPolylineCheckbox.Checked = true;
            this.drawPolylineCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.drawPolylineCheckbox.Location = new System.Drawing.Point(15, 112);
            this.drawPolylineCheckbox.Name = "drawPolylineCheckbox";
            this.drawPolylineCheckbox.Size = new System.Drawing.Size(98, 19);
            this.drawPolylineCheckbox.TabIndex = 6;
            this.drawPolylineCheckbox.Text = "Draw Polyline";
            this.drawPolylineCheckbox.UseVisualStyleBackColor = true;
            // 
            // DrawAnimationCheckBox
            // 
            this.DrawAnimationCheckBox.AutoSize = true;
            this.DrawAnimationCheckBox.Location = new System.Drawing.Point(15, 148);
            this.DrawAnimationCheckBox.Name = "DrawAnimationCheckBox";
            this.DrawAnimationCheckBox.Size = new System.Drawing.Size(112, 19);
            this.DrawAnimationCheckBox.TabIndex = 7;
            this.DrawAnimationCheckBox.Text = "Draw Animation";
            this.DrawAnimationCheckBox.UseVisualStyleBackColor = true;
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(27, 73);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(70, 23);
            this.playButton.TabIndex = 10;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Location = new System.Drawing.Point(103, 73);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(75, 23);
            this.pauseButton.TabIndex = 11;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // AnimationLevel
            // 
            this.AnimationLevel.Location = new System.Drawing.Point(15, 22);
            this.AnimationLevel.Maximum = 200;
            this.AnimationLevel.Name = "AnimationLevel";
            this.AnimationLevel.Size = new System.Drawing.Size(183, 45);
            this.AnimationLevel.TabIndex = 12;
            this.AnimationLevel.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // rotatingCheckbox
            // 
            this.rotatingCheckbox.AutoSize = true;
            this.rotatingCheckbox.Checked = true;
            this.rotatingCheckbox.Location = new System.Drawing.Point(23, 118);
            this.rotatingCheckbox.Name = "rotatingCheckbox";
            this.rotatingCheckbox.Size = new System.Drawing.Size(70, 19);
            this.rotatingCheckbox.TabIndex = 13;
            this.rotatingCheckbox.TabStop = true;
            this.rotatingCheckbox.Text = "Rotation";
            this.rotatingCheckbox.UseVisualStyleBackColor = true;
            // 
            // rotationWithCurveCheckbox
            // 
            this.rotationWithCurveCheckbox.AutoSize = true;
            this.rotationWithCurveCheckbox.Location = new System.Drawing.Point(23, 155);
            this.rotationWithCurveCheckbox.Name = "rotationWithCurveCheckbox";
            this.rotationWithCurveCheckbox.Size = new System.Drawing.Size(148, 19);
            this.rotationWithCurveCheckbox.TabIndex = 14;
            this.rotationWithCurveCheckbox.Text = "Rotation with the curve";
            this.rotationWithCurveCheckbox.UseVisualStyleBackColor = true;
            // 
            // filteringCheckBox
            // 
            this.filteringCheckBox.AutoSize = true;
            this.filteringCheckBox.Location = new System.Drawing.Point(23, 194);
            this.filteringCheckBox.Name = "filteringCheckBox";
            this.filteringCheckBox.Size = new System.Drawing.Size(97, 19);
            this.filteringCheckBox.TabIndex = 15;
            this.filteringCheckBox.Text = "With Filtering";
            this.filteringCheckBox.UseVisualStyleBackColor = true;
            this.filteringCheckBox.CheckedChanged += new System.EventHandler(this.filteringCheckBox_CheckedChanged);
            // 
            // PolylineOptionsGroupBox
            // 
            this.PolylineOptionsGroupBox.Controls.Add(this.drawPolylineCheckbox);
            this.PolylineOptionsGroupBox.Controls.Add(this.generateButton);
            this.PolylineOptionsGroupBox.Controls.Add(this.numberOfPointsInput);
            this.PolylineOptionsGroupBox.Controls.Add(this.NumberOfPointsLabel);
            this.PolylineOptionsGroupBox.Controls.Add(this.DrawAnimationCheckBox);
            this.PolylineOptionsGroupBox.Location = new System.Drawing.Point(1171, 12);
            this.PolylineOptionsGroupBox.Name = "PolylineOptionsGroupBox";
            this.PolylineOptionsGroupBox.Size = new System.Drawing.Size(213, 194);
            this.PolylineOptionsGroupBox.TabIndex = 16;
            this.PolylineOptionsGroupBox.TabStop = false;
            this.PolylineOptionsGroupBox.Text = "Polyline options";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.AnimationLevel);
            this.groupBox2.Controls.Add(this.playButton);
            this.groupBox2.Controls.Add(this.filteringCheckBox);
            this.groupBox2.Controls.Add(this.pauseButton);
            this.groupBox2.Controls.Add(this.rotationWithCurveCheckbox);
            this.groupBox2.Controls.Add(this.rotatingCheckbox);
            this.groupBox2.Location = new System.Drawing.Point(1171, 614);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(213, 235);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Animation";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ImageHeightInput);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.ImageWidthInput);
            this.groupBox3.Controls.Add(this.LoadImageButton);
            this.groupBox3.Controls.Add(this.ImagePreview);
            this.groupBox3.Location = new System.Drawing.Point(1171, 212);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(213, 396);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Image";
            // 
            // ImageHeightInput
            // 
            this.ImageHeightInput.Location = new System.Drawing.Point(72, 353);
            this.ImageHeightInput.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.ImageHeightInput.Name = "ImageHeightInput";
            this.ImageHeightInput.Size = new System.Drawing.Size(106, 23);
            this.ImageHeightInput.TabIndex = 5;
            this.ImageHeightInput.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.ImageHeightInput.ValueChanged += new System.EventHandler(this.ImageHeightInput_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 355);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Height";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 312);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Width";
            // 
            // ImageWidthInput
            // 
            this.ImageWidthInput.Location = new System.Drawing.Point(72, 310);
            this.ImageWidthInput.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.ImageWidthInput.Name = "ImageWidthInput";
            this.ImageWidthInput.Size = new System.Drawing.Size(106, 23);
            this.ImageWidthInput.TabIndex = 2;
            this.ImageWidthInput.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.ImageWidthInput.ValueChanged += new System.EventHandler(this.ImageWidthInput_ValueChanged);
            // 
            // LoadImageButton
            // 
            this.LoadImageButton.Location = new System.Drawing.Point(27, 259);
            this.LoadImageButton.Name = "LoadImageButton";
            this.LoadImageButton.Size = new System.Drawing.Size(151, 23);
            this.LoadImageButton.TabIndex = 1;
            this.LoadImageButton.Text = "Load image";
            this.LoadImageButton.UseVisualStyleBackColor = true;
            this.LoadImageButton.Click += new System.EventHandler(this.LoadImageButton_Click);
            // 
            // ImagePreview
            // 
            this.ImagePreview.Image = global::BeziersCurve.Properties.Resources.szachownica1;
            this.ImagePreview.ImageLocation = "";
            this.ImagePreview.Location = new System.Drawing.Point(7, 36);
            this.ImagePreview.Name = "ImagePreview";
            this.ImagePreview.Size = new System.Drawing.Size(200, 200);
            this.ImagePreview.TabIndex = 0;
            this.ImagePreview.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1390, 861);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.PolylineOptionsGroupBox);
            this.Controls.Add(this.drawingArea);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.drawingArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfPointsInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnimationLevel)).EndInit();
            this.PolylineOptionsGroupBox.ResumeLayout(false);
            this.PolylineOptionsGroupBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageHeightInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageWidthInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImagePreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox drawingArea;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Label NumberOfPointsLabel;
        private System.Windows.Forms.NumericUpDown numberOfPointsInput;
        private System.Windows.Forms.CheckBox drawPolylineCheckbox;
        private System.Windows.Forms.CheckBox DrawAnimationCheckBox;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.TrackBar AnimationLevel;
        private System.Windows.Forms.RadioButton rotatingCheckbox;
        private System.Windows.Forms.RadioButton rotationWithCurveCheckbox;
        private System.Windows.Forms.CheckBox filteringCheckBox;
        private System.Windows.Forms.GroupBox PolylineOptionsGroupBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button LoadImageButton;
        private System.Windows.Forms.NumericUpDown ImageHeightInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown ImageWidthInput;
        private System.Windows.Forms.PictureBox ImagePreview;
    }
}

