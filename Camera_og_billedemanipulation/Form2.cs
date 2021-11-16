using AForge.Imaging;
using AForge.Math;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Camera_og_billedemanipulation
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }

        public System.Drawing.Image ImageFromForm1 { get; set; }

        private void Form2_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = ImageFromForm1;

            // gather statistics
            ImageStatistics stat = new ImageStatistics((Bitmap)pictureBox1.Image);
            // get red channel's histogram
            Histogram red = stat.Red;
            // check mean value of red channel
            if (red.Mean > 128)
            {
                // do further processing
            }
        }
    }
}
