
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.drawingArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfPointsInput)).BeginInit();
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
            this.generateButton.Location = new System.Drawing.Point(1328, 67);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(100, 23);
            this.generateButton.TabIndex = 2;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.GenerateButtonClicked);
            // 
            // NumberOfPointsLabel
            // 
            this.NumberOfPointsLabel.AutoSize = true;
            this.NumberOfPointsLabel.Location = new System.Drawing.Point(1221, 41);
            this.NumberOfPointsLabel.Name = "NumberOfPointsLabel";
            this.NumberOfPointsLabel.Size = new System.Drawing.Size(101, 15);
            this.NumberOfPointsLabel.TabIndex = 3;
            this.NumberOfPointsLabel.Text = "Number of points";
            // 
            // numberOfPointsInput
            // 
            this.numberOfPointsInput.Location = new System.Drawing.Point(1328, 39);
            this.numberOfPointsInput.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numberOfPointsInput.Name = "numberOfPointsInput";
            this.numberOfPointsInput.Size = new System.Drawing.Size(100, 23);
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
            this.drawPolylineCheckbox.Location = new System.Drawing.Point(1186, 105);
            this.drawPolylineCheckbox.Name = "drawPolylineCheckbox";
            this.drawPolylineCheckbox.Size = new System.Drawing.Size(98, 19);
            this.drawPolylineCheckbox.TabIndex = 6;
            this.drawPolylineCheckbox.Text = "Draw Polyline";
            this.drawPolylineCheckbox.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(1186, 245);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(112, 19);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Draw Animation";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 861);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.drawPolylineCheckbox);
            this.Controls.Add(this.numberOfPointsInput);
            this.Controls.Add(this.NumberOfPointsLabel);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.drawingArea);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.drawingArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfPointsInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox drawingArea;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Label NumberOfPointsLabel;
        private System.Windows.Forms.NumericUpDown numberOfPointsInput;
        private System.Windows.Forms.CheckBox drawPolylineCheckbox;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

