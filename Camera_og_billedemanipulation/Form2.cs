using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Math;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

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

            pictureBoxOriginal.Image = ImageFromForm1;
            Bitmap bt = new Bitmap(pictureBoxOriginal.Image);

            Grayscale filter = new Grayscale(0.2125, 0.7154, 0.0721);
            Bitmap grayImage = filter.Apply(bt);
            pictureBoxOriginal.Image = grayImage;

            pictureBoxFiltered.Image = pictureBoxOriginal.Image;

            // gather statistics
            ImageStatistics his = new ImageStatistics(grayImage);
            // get gray histogram (for grayscale image)
            Histogram histogram = his.Gray;
            // output some histogram's information
            System.Diagnostics.Debug.WriteLine("Mean = " + histogram.Mean);
            System.Diagnostics.Debug.WriteLine("Min = " + histogram.Min);
            System.Diagnostics.Debug.WriteLine("Max = " + histogram.Max);
            int[] xData = new int[256];

            var series1 = new Series
            {
                Name = "serie1",
                Color = Color.Black,
                ChartType = SeriesChartType.Column
            };
            for (int i = 0; i < histogram.Values.Count(); i++)
            {
                series1.Points.AddXY(xData[i], histogram.Values[i]);
            }
            // Transfer series data to form chart series 
            chart1.Series["Series1"] = series1;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int value = trackBar1.Value;

            ThresholdIndex.Text = value.ToString();

            Threshold filter = new Threshold(value);
            Bitmap bt = filter.Apply((Bitmap)pictureBoxOriginal.Image);
            pictureBoxFiltered.Image = bt;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
