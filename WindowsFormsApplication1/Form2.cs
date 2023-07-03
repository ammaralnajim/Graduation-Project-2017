using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        
        

        
        public Form2()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            PerformanceCounter[] PC = new PerformanceCounter[10];
            PC[0] = performanceCounter1;
            
            //var pc = new PerformanceCounter("Processor", "% Processor Time");
            var cat = new PerformanceCounterCategory("Processor");
            var instances = cat.GetInstanceNames();
            int ii = 0;
            string[,] aa = new string[50, 2];
            foreach (var s in instances)
            {
               ii++;
            }





            chart5.Series.Clear();
            for (int i = 0; i < ii-1; i++)
            {
                performanceCounter1.InstanceName = "0,"+i.ToString();
             //   performanceCounter1.InstanceName = i.ToString();
                float q =performanceCounter1.NextValue();
                      q = performanceCounter1.NextValue();
                Series series1 = new Series("Core" + i,100);
                chart5.Series.Add(series1);
                chart5.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                chart5.Series[i].Points.AddY(q);
               
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
