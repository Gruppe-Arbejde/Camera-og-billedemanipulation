using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace Camera_og_billedemanipulation
{
    public partial class Form1 : Form
    {
        //variable declaration
        Stack<Bitmap> imageStack;
        internal GlobalVars gv;  // Instantiate Global Var
        bool btnCapture = false; // bool that by default is false. This bool is used to check if the capture button should be enabled or not,
                                 // in order to stop the user from using capture button when not supposed.

        public Form1()
        {
            InitializeComponent();
            buttonCamStart.Enabled = false;
            gv = new GlobalVars(); // Initialize variable 
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

            buttonsEnable(false);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Sure you want to close?", "Are you sure?", MessageBoxButtons.YesNo);
            if (DialogResult.No == dr)
            {
                e.Cancel = true;
            }
            else
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
            // Check if bool "btnCapture" is false, and if so, open a message box where it tells you to turn on webcam before you can use the capture button
            if (btnCapture == false)
            {
                MessageBox.Show("You need to turn on your webcam first");
            }
            else   // else if bool "btnCapture" is true, the button just initiates the capture.
            {
                imgCapture.Image = (Image)imgVideo.Image.Clone();
                pictureBox1.Image = (Image)imgVideo.Image.Clone();

                // Color scale buttons
                buttonsEnable(true);

                backcolorChange(Color.Transparent);
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

                buttonCamStart.Enabled = false;
                buttonStop.Enabled = true;
                do
                {
                    if (imgVideo.Image != null)
                    {
                        btnCapture = true;
                    }
                } while (btnCapture == false);
                //if(imgVideo.Image != null)
                //{
                //}
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
            try
            {
                // 
                imageStack.Push(new Bitmap(imgCapture.Image));
                //  undoToolStripMenuItem.Enabled = true;
                Bitmap bt = new Bitmap(imgCapture.Image);
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
            catch (NullReferenceException)
            {
                MessageBox.Show("You need to capture a picture first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Only if there is still something left on ehe stack
            if (imageStack.Count > 0)
                imgCapture.Image = imageStack.Pop();
        }

        private void resolutionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gv.FinalVideo != null)
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
            else
            {
                MessageBox.Show("You need to turn on your webcam first");
            }

        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (gv.FinalVideo != null)
            {
                gv.FinalVideo.Stop();
                gv.FinalVideo.WaitForStop();
                imgVideo.Image = null;
                imgCapture.Image = null;
                pictureBox1.Image = null;
                btnCapture = false;
                imageStack.Clear();
                buttonsEnable(false);
                backcolorChange(Color.Gainsboro);
            }
            gv.FinalVideo = null;
            buttonCamStart.Enabled = true;
            buttonStop.Enabled = false;

        }

        /**************************************************************************************/
        //
        /**************************************************************************************/



        /// <summary>
        /// Convert captured picture to Redscale.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void buttonRed_Click(object sender, EventArgs e)
        {
            if (btnCapture == false)
            {
                MessageBox.Show("You need to capture an image first");
            }
            else if (pictureBox1.Image != null)
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
                            bt.SetPixel(x, y, Color.FromArgb(c.R, 0, 0));
                        }
                    }
                    imgCapture.Image = bt;
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("You need to capture a picture first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (btnCapture == false)
            {
                MessageBox.Show("You need to capture an image first");
            }
            else if (pictureBox1.Image != null)
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
                            bt.SetPixel(x, y, Color.FromArgb(0, c.G, 0));
                        }
                    }
                    imgCapture.Image = bt;
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("You need to capture a picture first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (btnCapture == false)
            {
                MessageBox.Show("You need to capture an image first");
            }
            else if (pictureBox1.Image != null)
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
                catch (NullReferenceException)
                {
                    MessageBox.Show("You need to capture a picture first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void buttonsEnable(Boolean status)
        {
            // Color scale buttons
            buttonBlue.Visible = status;
            buttonRed.Visible = status;
            buttonGray.Visible = status;
            buttonGreen.Visible = status;
            buttonHistogram.Visible = status;
        }

        private void backcolorChange(Color color)
        {
            imgVideo.BackColor = color;
            imgCapture.BackColor = color;
        }

        private void buttonHistogram_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }
    }
}
