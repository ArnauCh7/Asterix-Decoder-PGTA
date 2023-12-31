﻿namespace WinForms
{
    partial class formSimulation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formSimulation));
            picBoxPlayPause = new PictureBox();
            picBoxRestart = new PictureBox();
            gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            timeLabel = new Label();
            timer = new System.Windows.Forms.Timer(components);
            speedLabel = new Label();
            decreaseSpeedBtn = new PictureBox();
            increaseSpeedBtn = new PictureBox();
            btnKML = new Button();
            btnReload = new Button();
            ((System.ComponentModel.ISupportInitialize)picBoxPlayPause).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBoxRestart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)decreaseSpeedBtn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)increaseSpeedBtn).BeginInit();
            SuspendLayout();
            // 
            // picBoxPlayPause
            // 
            picBoxPlayPause.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            picBoxPlayPause.Image = (System.Drawing.Image)resources.GetObject("picBoxPlayPause.Image");
            picBoxPlayPause.Location = new System.Drawing.Point(26, 405);
            picBoxPlayPause.Name = "picBoxPlayPause";
            picBoxPlayPause.Size = new System.Drawing.Size(33, 33);
            picBoxPlayPause.TabIndex = 2;
            picBoxPlayPause.TabStop = false;
            picBoxPlayPause.Click += picBoxPlayPause_Click;
            // 
            // picBoxRestart
            // 
            picBoxRestart.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            picBoxRestart.Image = (System.Drawing.Image)resources.GetObject("picBoxRestart.Image");
            picBoxRestart.Location = new System.Drawing.Point(65, 405);
            picBoxRestart.Name = "picBoxRestart";
            picBoxRestart.Size = new System.Drawing.Size(33, 33);
            picBoxRestart.TabIndex = 4;
            picBoxRestart.TabStop = false;
            picBoxRestart.Click += picBoxRestart_Click;
            // 
            // gMapControl1
            // 
            gMapControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gMapControl1.Bearing = 0F;
            gMapControl1.CanDragMap = true;
            gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            gMapControl1.GrayScaleMode = false;
            gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            gMapControl1.LevelsKeepInMemory = 5;
            gMapControl1.Location = new System.Drawing.Point(16, 41);
            gMapControl1.MarkersEnabled = true;
            gMapControl1.MaxZoom = 20;
            gMapControl1.MinZoom = 2;
            gMapControl1.MouseWheelZoomEnabled = true;
            gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            gMapControl1.Name = "gMapControl1";
            gMapControl1.NegativeMode = false;
            gMapControl1.PolygonsEnabled = true;
            gMapControl1.RetryLoadTile = 0;
            gMapControl1.RoutesEnabled = true;
            gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(33, 65, 105, 225);
            gMapControl1.ShowTileGridLines = false;
            gMapControl1.Size = new System.Drawing.Size(758, 358);
            gMapControl1.TabIndex = 5;
            gMapControl1.Zoom = 0D;
            // 
            // timeLabel
            // 
            timeLabel.Font = new Font("Bahnschrift SemiBold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            timeLabel.Location = new System.Drawing.Point(12, 9);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new System.Drawing.Size(256, 29);
            timeLabel.TabIndex = 6;
            timeLabel.Text = "00:00:00";
            // 
            // timer
            // 
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
            // 
            // speedLabel
            // 
            speedLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            speedLabel.AutoSize = true;
            speedLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            speedLabel.Location = new System.Drawing.Point(145, 417);
            speedLabel.Name = "speedLabel";
            speedLabel.Size = new System.Drawing.Size(28, 21);
            speedLabel.TabIndex = 7;
            speedLabel.Text = "x1";
            // 
            // decreaseSpeedBtn
            // 
            decreaseSpeedBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            decreaseSpeedBtn.Image = (System.Drawing.Image)resources.GetObject("decreaseSpeedBtn.Image");
            decreaseSpeedBtn.Location = new System.Drawing.Point(116, 415);
            decreaseSpeedBtn.Name = "decreaseSpeedBtn";
            decreaseSpeedBtn.Size = new System.Drawing.Size(23, 23);
            decreaseSpeedBtn.TabIndex = 8;
            decreaseSpeedBtn.TabStop = false;
            decreaseSpeedBtn.Click += decreaseSpeedBtn_Click;
            // 
            // increaseSpeedBtn
            // 
            increaseSpeedBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            increaseSpeedBtn.Image = (System.Drawing.Image)resources.GetObject("increaseSpeedBtn.Image");
            increaseSpeedBtn.Location = new System.Drawing.Point(179, 415);
            increaseSpeedBtn.Name = "increaseSpeedBtn";
            increaseSpeedBtn.Size = new System.Drawing.Size(23, 23);
            increaseSpeedBtn.TabIndex = 9;
            increaseSpeedBtn.TabStop = false;
            increaseSpeedBtn.Click += increaseSpeedBtn_Click;
            // 
            // btnKML
            // 
            btnKML.Anchor = AnchorStyles.Bottom;
            btnKML.BackColor = System.Drawing.Color.CornflowerBlue;
            btnKML.FlatAppearance.BorderSize = 0;
            btnKML.FlatStyle = FlatStyle.Flat;
            btnKML.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnKML.Location = new System.Drawing.Point(327, 405);
            btnKML.Name = "btnKML";
            btnKML.Size = new System.Drawing.Size(137, 33);
            btnKML.TabIndex = 10;
            btnKML.Text = "Download KML";
            btnKML.UseVisualStyleBackColor = false;
            btnKML.Click += btnKML_Click;
            // 
            // btnReload
            // 
            btnReload.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnReload.BackColor = System.Drawing.Color.CornflowerBlue;
            btnReload.FlatAppearance.BorderSize = 0;
            btnReload.FlatStyle = FlatStyle.Flat;
            btnReload.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnReload.Location = new System.Drawing.Point(653, 405);
            btnReload.Name = "btnReload";
            btnReload.Size = new System.Drawing.Size(106, 34);
            btnReload.TabIndex = 11;
            btnReload.Text = "Reload";
            btnReload.UseVisualStyleBackColor = false;
            btnReload.Click += btnReload_Click;
            // 
            // formSimulation
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(btnReload);
            Controls.Add(btnKML);
            Controls.Add(increaseSpeedBtn);
            Controls.Add(decreaseSpeedBtn);
            Controls.Add(speedLabel);
            Controls.Add(timeLabel);
            Controls.Add(gMapControl1);
            Controls.Add(picBoxRestart);
            Controls.Add(picBoxPlayPause);
            FormBorderStyle = FormBorderStyle.None;
            Name = "formSimulation";
            Text = "formSimulation";
            Load += formSimulation_Load;
            ((System.ComponentModel.ISupportInitialize)picBoxPlayPause).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBoxRestart).EndInit();
            ((System.ComponentModel.ISupportInitialize)decreaseSpeedBtn).EndInit();
            ((System.ComponentModel.ISupportInitialize)increaseSpeedBtn).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox picBoxPlayPause;
        private PictureBox picBoxRestart;
        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private Label timeLabel;
        private System.Windows.Forms.Timer timer;
        private Label speedLabel;
        private PictureBox decreaseSpeedBtn;
        private PictureBox increaseSpeedBtn;
        private Button btnKML;
        private Button btnReload;
    }
}