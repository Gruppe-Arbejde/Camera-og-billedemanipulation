﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AForge.Imaging.Filters;
using AForge.Video;
using AForge.Video.DirectShow;

namespace Camera_og_billedemanipulation
{
    public partial class Form1 : Form
    {
        //variable declaration
        Stack<Bitmap> imageStack;
        internal GlobalVars gv;  // Instantiate Global Var
        bool btnCapture = false; // bool that by default is false. This bool is used to check if the capture button should be enabled or not, in order to stop the user from using capture button when not supposed.
        //bool imgCaptureBox = false;

        public Form1()
        {
            InitializeComponent();
            buttonCamStart.Enabled = false;
            gv = new GlobalVars(); // Initialize variable 
            timer1.Interval = 1000; // How often our timer should take a picture (time is in ms. 1000ms = 1 second)
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            imageStack = new Stack<Bitmap>();

            gv.VideoCaptureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo VideoCaptureDevice in gv.VideoCaptureDevices)
            {
                comboBoxCameraList.Items.Add(VideoCaptureDevice.Name);
            }
            if (comboBoxCameraList.Items.Count > 0)
            {
                comboBoxCameraList.SelectedIndex = 0;
                buttonCamStart.Enabled = true;
            }
            buttonStop.Enabled = false;
            buttonsStatus(false);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // We ask the user if they want to close the program.
            DialogResult dr = MessageBox.Show("Sure you want to close?", "Are you sure?", MessageBoxButtons.YesNo);
            if (DialogResult.No == dr)
            {
                e.Cancel = true; // if they so no, then we cancel the shutdown
            }
            else // otherwise we'll just shutdown the program.
            {
                if (gv.FinalVideo != null)
                {
                    gv.FinalVideo.Stop();
                    gv.FinalVideo.WaitForStop();
                }
                gv.FinalVideo = null;
            }
        }

        void FinalVideo_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap video = (Bitmap)eventArgs.Frame.Clone();
            imgVideo.Image = video;
        }

        private void buttonCapture_Click(object sender, EventArgs e)
        {
            // We check if our bool "btnCapture" is false, and if so, then a message box will tell the user to turn on their webcam before capturing an image
            if (btnCapture == false)
            {
                MessageBox.Show($"{NoWebOn}", $"{NoWebDet}");
            }
            // Otherwise we'll enable the capture button. If "btnCapture" is true.
            else
            {
                imgCapture.Image = (Image)imgVideo.Image.Clone();
                pictureBox1.Image = (Image)imgVideo.Image.Clone();

                buttonsStatus(true);    // Color scale buttons
                backcolorChange(Color.Transparent); // Hides the button, when we don't need it
            }
        }

        private void buttonCamStart_Click(object sender, EventArgs e)
        {
            gv.FinalVideo = new VideoCaptureDevice(gv.VideoCaptureDevices[comboBoxCameraList.SelectedIndex].MonikerString);

            CameraSettings cs = new CameraSettings(gv);
            DialogResult dr = cs.ShowDialog();

            if (DialogResult.OK == dr)
            {
                // Get vidoresolution possibilities
                VideoCapabilities[] vc = gv.FinalVideo.VideoCapabilities;
                // Get selected resolution
                int resolutionSelection = int.Parse(cs.tabControl1.SelectedTab.Text) - 1;  // Minus 1 due to 0 offset
                // Set camera resolution
                gv.FinalVideo.VideoResolution = vc[resolutionSelection];
                // Enable eventhandler
                gv.FinalVideo.NewFrame += new NewFrameEventHandler(FinalVideo_NewFrame);
                gv.FinalVideo.Start();
                // Since already have our cam started, we'll disable the start button. and at the same time enable the stop button.
                buttonCamStart.Enabled = false;
                buttonStop.Enabled = true;
                do
                {
                    // and if our picturebox "imgVideo" is not empy, then we'll allow change the bool "btnCapture" to true. 
                    if (imgVideo.Image != null)
                    {
                        btnCapture = true;
                    }
                } while (btnCapture == false);
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Only if there is still something left on the stack
            if (imageStack.Count > 0)
                imgCapture.Image = imageStack.Pop();
        }

        private void resolutionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imgVideo.Image == null)
            {
                MessageBox.Show($"{NoWebOn}", $"{NoWebDet}");
            }
            else
            {
                gv.FinalVideo.SignalToStop();
                gv.FinalVideo.Stop();
                gv.FinalVideo.WaitForStop();
                gv.FinalVideo.NewFrame -= new NewFrameEventHandler(FinalVideo_NewFrame);

                CameraSettings cs = new CameraSettings(gv);
                DialogResult dr = cs.ShowDialog();

                if (DialogResult.OK == dr)
                {
                    VideoCapabilities[] vc = gv.FinalVideo.VideoCapabilities;
                    int resolutionSelection = int.Parse(cs.tabControl1.SelectedTab.Text) - 1;  // Minus 1 due to 0 offset

                    gv.FinalVideo.VideoResolution = vc[resolutionSelection];

                    gv.FinalVideo.NewFrame += new NewFrameEventHandler(FinalVideo_NewFrame);
                    gv.FinalVideo.Start();

                    buttonCamStart.Enabled = false;
                    buttonStop.Enabled = true;
                }
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            // We check if there's anything we should stop, and if there is, then we'll close it, and wait.
            if (gv.FinalVideo != null)
            {
                gv.FinalVideo.Stop();
                gv.FinalVideo.WaitForStop();
            }
            imgVideo.Image = null;
            imgCapture.Image = null;
            pictureBox1.Image = null;
            btnCapture = false;
            imageStack.Clear();
            buttonsStatus(false);
            backcolorChange(Color.Gainsboro);
            gv.FinalVideo = null;
            buttonCamStart.Enabled = true;
            buttonStop.Enabled = false;
        }

        private void loadImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            //var path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            ofd.Title = "Open Image";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            ofd.Filter = "Image Files(*.BMP;*.JPG;*.PNG;*.GIF)|*.BMP;*.JPG;*.PNG;*.GIF|All Files(*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Bitmap bt = new Bitmap(ofd.FileName);
                imgCapture.Image = bt;
                pictureBox1.Image = bt;
                buttonsStatus(true);
                buttonStop.Enabled = true;

                // Resize a picture to fit.
                if (bt.Width < imgCapture.Width && bt.Height < imgCapture.Height)
                {
                    imgCapture.SizeMode = PictureBoxSizeMode.Normal;
                    pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
                }
                else
                {
                    imgCapture.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
            ofd.Dispose(); // Disposes everything that is unnecessary.
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imgCapture.Image == null)
            {
                MessageBox.Show("Please capture an image first.", "No image detected!");
            }
            else
            {
                SaveFileDialog sfd = new SaveFileDialog();

                sfd.Title = "Save Image"; // Form title
                sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                sfd.Filter = "Image Files(*.JPG)|*.JPG|All files (*.*)|*.*";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    imgCapture.Image.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Jpeg); // "imgCapture" - From wecam project!
                }
                sfd.Dispose(); // Disposes everything that is unnecessary.
            }
        }

        private void buttonHistogram_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            Bitmap bt = new Bitmap(pictureBox1.Image);
            
            form2.ImageFromForm1 = bt;
            form2.ShowDialog();
        }

        /// <summary>
        /// Convert captured picture to Redscale.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void buttonRed_Click(object sender, EventArgs e)
        {
            // We'll check if the picturebox actually contains any image. and if not, then we'll tell the user to capture one first
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("You need to capture an image first");
            }
            // otherwise we'll see if the picturebox is not empty, and if it isn't then we'll continue.
            else if (pictureBox1.Image != null)
            {
                try
                {
                    imageStack.Push(new Bitmap(pictureBox1.Image));
                    //  undoToolStripMenuItem.Enabled = true;
                    Bitmap bt = new Bitmap(pictureBox1.Image);
                    for (int y = 0; y < bt.Height; y++)
                    {
                        for (int x = 0; x < bt.Width; x++)
                        {
                            Color c = bt.GetPixel(x, y);

                            int avg = (c.R + c.G + c.B) / 3;
                            bt.SetPixel(x, y, Color.FromArgb(c.R, 0, 0));
                        }
                    }
                    imgCapture.Image = bt;
                }
                // error handling
                catch (NullReferenceException)
                {
                    MessageBox.Show("You need to capture a picture first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Convert captured picture to Greenscale.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        ///
        private void buttonGreen_Click(object sender, EventArgs e)
        {
            // We'll check if the picturebox actually contains any image. and if not, then we'll tell the user to capture one first
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("You need to capture an image first");
            }
            // otherwise we'll see if the picturebox is not empty, and if it isn't then we'll continue.
            else if (pictureBox1.Image != null)
            {
                try
                {
                    imageStack.Push(new Bitmap(pictureBox1.Image));
                    //  undoToolStripMenuItem.Enabled = true;
                    Bitmap bt = new Bitmap(pictureBox1.Image);
                    for (int y = 0; y < bt.Height; y++)
                    {
                        for (int x = 0; x < bt.Width; x++)
                        {
                            Color c = bt.GetPixel(x, y);

                            int avg = (c.R + c.G + c.B) / 3;
                            bt.SetPixel(x, y, Color.FromArgb(0, c.G, 0));
                        }
                    }
                    imgCapture.Image = bt;
                }
                // error handling
                catch (NullReferenceException)
                {
                    MessageBox.Show("You need to capture a picture first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Convert captured picture to Bluescale.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void buttonBlue_Click(object sender, EventArgs e)
        {
            // We'll check if the picturebox actually contains any image. and if not, then we'll tell the user to capture one first
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("You need to capture an image first");
            }
            // otherwise we'll see if the picturebox is not empty, and if it isn't then we'll continue.
            else if (pictureBox1.Image != null)
            {
                try
                {
                    // 
                    imageStack.Push(new Bitmap(pictureBox1.Image));
                    //  undoToolStripMenuItem.Enabled = true;
                    Bitmap bt = new Bitmap(pictureBox1.Image);
                    for (int y = 0; y < bt.Height; y++)
                    {
                        for (int x = 0; x < bt.Width; x++)
                        {
                            Color c = bt.GetPixel(x, y);

                            int avg = (c.R + c.G + c.B) / 3;
                            bt.SetPixel(x, y, Color.FromArgb(0, 0, c.B));
                        }
                    }
                    imgCapture.Image = bt;
                }
                // error handling
                catch (NullReferenceException)
                {
                    MessageBox.Show("You need to capture a picture first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Convert captured picture to Grayscale.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void buttonGrayscale_Click(object sender, EventArgs e)
        {
            // We'll check if the picturebox actually contains any image. and if not, then we'll tell the user to capture one first
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("You need to capture an image first");
            }
            // otherwise we'll see if the picturebox is not empty, and if it isn't then we'll continue.
            else if (pictureBox1.Image != null)
                try
                {
                    imageStack.Push(new Bitmap(pictureBox1.Image));
                    //  undoToolStripMenuItem.Enabled = true;
                    Bitmap bt = new Bitmap(pictureBox1.Image);
                    for (int y = 0; y < bt.Height; y++)
                    {
                        for (int x = 0; x < bt.Width; x++)
                        {
                            Color c = bt.GetPixel(x, y);

                            int avg = (c.R + c.G + c.B) / 3;
                            bt.SetPixel(x, y, Color.FromArgb(avg, avg, avg));
                        }
                    }
                    imgCapture.Image = bt;
                }
                // error handling
                catch (NullReferenceException)
                {
                    MessageBox.Show("You need to capture a picture first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void backcolorChange(Color color)
        {
            imgVideo.BackColor = color;
            imgCapture.BackColor = color;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Bitmap bt = (Bitmap)imgVideo.Image.Clone();

            // It is only possible to make the theshold on a grayscale picture 
            // create grayscale filter (BT709) 
            Grayscale filter = new Grayscale(0.2125, 0.7154, 0.0721);

            // apply the filter 
            Bitmap grayImage = filter.Apply(bt);

            imgCapture.Image = (System.Drawing.Image)grayImage.Clone();
        }

        private void buttonTimer_Click_1(object sender, EventArgs e)
        {
            // we're checking if "btnCapture" is false, and if so, we'll prompt the user to enable their webcam first.
            if (btnCapture == false)
            {
                MessageBox.Show($"{NoWebOn}", $"{NoWebDet}");
            }
            else
            {
                timer1.Enabled = !timer1.Enabled;

                switch (buttonTimer.Text)
                {
                    // when we click on the timer button when it says start timer, then we'll change the text on the button and also the colour.
                    case "Start Timer":
                        buttonTimer.Text = "Stop Timer";
                        buttonTimer.BackColor = Color.Red;
                        break;
                    // when we click on the timer button when it says start timer, then we'll change the text on the button and also the colour.
                    case "Stop Timer":
                        buttonTimer.Text = "Start Timer";
                        buttonTimer.BackColor = Color.LimeGreen;
                        break;
                    default:
                        buttonTimer.Text = "Stop Timer";
                        buttonTimer.BackColor = Color.Red;
                        break;
                }
                imgCapture.Image = (Image)imgVideo.Image.Clone();
                pictureBox1.Image = (Image)imgVideo.Image.Clone();

                // Color scale buttons
                buttonsStatus(true);

                backcolorChange(Color.Transparent);
            }
        }

        private void buttonsStatus(Boolean status)
        {
            // Color scale buttons
            buttonBlue.Visible = status;
            buttonRed.Visible = status;
            buttonGray.Visible = status;
            buttonGreen.Visible = status;
            buttonHistogram.Visible = status;

        }

        string NoWebOn = "You need to turn your webcam on first.";
        string NoWebDet = "No webcam detected!";
    }
}
