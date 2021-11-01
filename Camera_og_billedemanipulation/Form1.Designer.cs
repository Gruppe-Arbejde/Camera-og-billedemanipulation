namespace Camera_og_billedemanipulation
{
    partial class Form1
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
            this.imgVideo = new System.Windows.Forms.PictureBox();
            this.buttonCapture = new System.Windows.Forms.Button();
            this.comboBoxCameraList = new System.Windows.Forms.ComboBox();
            this.buttonCamStart = new System.Windows.Forms.Button();
            this.imgCapture = new System.Windows.Forms.PictureBox();
            this.buttonGray = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resolutionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonGreen = new System.Windows.Forms.Button();
            this.buttonRed = new System.Windows.Forms.Button();
            this.buttonBlue = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgVideo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCapture)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // imgVideo
            // 
            this.imgVideo.BackColor = System.Drawing.Color.Gainsboro;
            this.imgVideo.Location = new System.Drawing.Point(12, 32);
            this.imgVideo.Margin = new System.Windows.Forms.Padding(2);
            this.imgVideo.Name = "imgVideo";
            this.imgVideo.Size = new System.Drawing.Size(254, 172);
            this.imgVideo.TabIndex = 0;
            this.imgVideo.TabStop = false;
            // 
            // buttonCapture
            // 
            this.buttonCapture.BackColor = System.Drawing.Color.Red;
            this.buttonCapture.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCapture.ForeColor = System.Drawing.Color.White;
            this.buttonCapture.Location = new System.Drawing.Point(12, 208);
            this.buttonCapture.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCapture.Name = "buttonCapture";
            this.buttonCapture.Size = new System.Drawing.Size(254, 51);
            this.buttonCapture.TabIndex = 1;
            this.buttonCapture.Text = "Capture";
            this.buttonCapture.UseVisualStyleBackColor = false;
            this.buttonCapture.Click += new System.EventHandler(this.buttonCapture_Click);
            // 
            // comboBoxCameraList
            // 
            this.comboBoxCameraList.FormattingEnabled = true;
            this.comboBoxCameraList.Location = new System.Drawing.Point(546, 4);
            this.comboBoxCameraList.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxCameraList.Name = "comboBoxCameraList";
            this.comboBoxCameraList.Size = new System.Drawing.Size(215, 21);
            this.comboBoxCameraList.TabIndex = 2;
            // 
            // buttonCamStart
            // 
            this.buttonCamStart.Location = new System.Drawing.Point(437, 4);
            this.buttonCamStart.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCamStart.Name = "buttonCamStart";
            this.buttonCamStart.Size = new System.Drawing.Size(50, 20);
            this.buttonCamStart.TabIndex = 3;
            this.buttonCamStart.Text = "Start";
            this.buttonCamStart.UseVisualStyleBackColor = true;
            this.buttonCamStart.Click += new System.EventHandler(this.buttonCamStart_Click);
            // 
            // imgCapture
            // 
            this.imgCapture.BackColor = System.Drawing.Color.Gainsboro;
            this.imgCapture.Location = new System.Drawing.Point(281, 32);
            this.imgCapture.Margin = new System.Windows.Forms.Padding(2);
            this.imgCapture.Name = "imgCapture";
            this.imgCapture.Size = new System.Drawing.Size(358, 227);
            this.imgCapture.TabIndex = 4;
            this.imgCapture.TabStop = false;
            // 
            // buttonGray
            // 
            this.buttonGray.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonGray.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGray.ForeColor = System.Drawing.Color.White;
            this.buttonGray.Location = new System.Drawing.Point(643, 179);
            this.buttonGray.Margin = new System.Windows.Forms.Padding(2);
            this.buttonGray.Name = "buttonGray";
            this.buttonGray.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.buttonGray.Size = new System.Drawing.Size(119, 45);
            this.buttonGray.TabIndex = 15;
            this.buttonGray.Text = "Gray";
            this.buttonGray.UseVisualStyleBackColor = false;
            this.buttonGray.Click += new System.EventHandler(this.buttonGrayscale_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.resolutionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(767, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.undoToolStripMenuItem.Text = "&Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // resolutionToolStripMenuItem
            // 
            this.resolutionToolStripMenuItem.Name = "resolutionToolStripMenuItem";
            this.resolutionToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.resolutionToolStripMenuItem.Text = "&Resolution";
            this.resolutionToolStripMenuItem.Click += new System.EventHandler(this.resolutionToolStripMenuItem_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(491, 4);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(50, 20);
            this.buttonStop.TabIndex = 11;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonGreen
            // 
            this.buttonGreen.BackColor = System.Drawing.Color.Green;
            this.buttonGreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGreen.ForeColor = System.Drawing.Color.White;
            this.buttonGreen.Location = new System.Drawing.Point(643, 81);
            this.buttonGreen.Margin = new System.Windows.Forms.Padding(2);
            this.buttonGreen.Name = "buttonGreen";
            this.buttonGreen.Size = new System.Drawing.Size(119, 45);
            this.buttonGreen.TabIndex = 13;
            this.buttonGreen.Text = "Green";
            this.buttonGreen.UseVisualStyleBackColor = false;
            this.buttonGreen.Click += new System.EventHandler(this.buttonGreen_Click);
            // 
            // buttonRed
            // 
            this.buttonRed.BackColor = System.Drawing.Color.Red;
            this.buttonRed.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRed.ForeColor = System.Drawing.Color.White;
            this.buttonRed.Location = new System.Drawing.Point(643, 32);
            this.buttonRed.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRed.Name = "buttonRed";
            this.buttonRed.Size = new System.Drawing.Size(119, 45);
            this.buttonRed.TabIndex = 12;
            this.buttonRed.Text = "Red";
            this.buttonRed.UseVisualStyleBackColor = false;
            this.buttonRed.Click += new System.EventHandler(this.buttonRed_Click);
            // 
            // buttonBlue
            // 
            this.buttonBlue.BackColor = System.Drawing.Color.Blue;
            this.buttonBlue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBlue.ForeColor = System.Drawing.Color.White;
            this.buttonBlue.Location = new System.Drawing.Point(643, 130);
            this.buttonBlue.Margin = new System.Windows.Forms.Padding(2);
            this.buttonBlue.Name = "buttonBlue";
            this.buttonBlue.Size = new System.Drawing.Size(119, 45);
            this.buttonBlue.TabIndex = 14;
            this.buttonBlue.Text = "Blue";
            this.buttonBlue.UseVisualStyleBackColor = false;
            this.buttonBlue.Click += new System.EventHandler(this.buttonBlue_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(146, 250);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(119, 44);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 280);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonBlue);
            this.Controls.Add(this.buttonRed);
            this.Controls.Add(this.buttonGreen);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonGray);
            this.Controls.Add(this.imgCapture);
            this.Controls.Add(this.buttonCamStart);
            this.Controls.Add(this.comboBoxCameraList);
            this.Controls.Add(this.buttonCapture);
            this.Controls.Add(this.imgVideo);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "WebCam Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgVideo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCapture)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgVideo;
        private System.Windows.Forms.Button buttonCapture;
        private System.Windows.Forms.ComboBox comboBoxCameraList;
        private System.Windows.Forms.Button buttonCamStart;
        private System.Windows.Forms.PictureBox imgCapture;
        private System.Windows.Forms.Button buttonGray;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resolutionToolStripMenuItem;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonGreen;
        private System.Windows.Forms.Button buttonRed;
        private System.Windows.Forms.Button buttonBlue;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

