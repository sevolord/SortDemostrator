using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SortDemostrator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GenerateArray();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GenerateArray();
        }
        public void GenerateArray()
        {
            int val = this.trackBar1.Value;
            int[] myArray = new int[val];
            Random rnd = new Random();
            for (int i = 0; i < val; i++) myArray[i] = rnd.Next(10, 100);

            this.chart1.Series[0].Points.Clear();
            for (int i = 1; i <= val; i++) this.chart1.Series[0].Points.AddXY(i, myArray[i - 1]);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.chart1.Series[0].Points[1].Color = Color.Red;
        }

        async public void Transposition(int a, int b) 
        {
            double c;
            this.chart1.Series[0].Points[a].Color = Color.Red;
            this.chart1.Series[0].Points[b].Color = Color.Yellow;
            await Task.Delay(1000);
            c = this.chart1.Series[0].Points[a].XValue;
            this.chart1.Series[0].Points[a].XValue = this.chart1.Series[0].Points[b].XValue;
            this.chart1.Series[0].Points[a].Color = Color.Yellow;
            //Wait();
            this.chart1.Series[0].Points[b].XValue = c;
            this.chart1.Series[0].Points[a].Color = Color.Red;
            await Task.Delay(1000);
            this.chart1.Series[0].Points[a].Color = Color.RoyalBlue;
            this.chart1.Series[0].Points[b].Color = Color.RoyalBlue;
            await Task.Delay(1000);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Transposition(1, 2);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label1.Text = trackBar2.Value.ToString(); ;
        }

        private void Wait()
        {
            int ticks = System.Environment.TickCount + this.trackBar2.Value;
            while (System.Environment.TickCount < ticks)
            {
                Application.DoEvents();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }
    }
}
