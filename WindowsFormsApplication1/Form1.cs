using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Management.Instrumentation;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            float i = performanceCounter1.NextValue();
            progressBar1.Value = (int)i;

            float ii = performanceCounter2.NextValue();
            progressBar2.Value = (int)ii/1024;

            float iii = performanceCounter3.NextValue();
            progressBar3.Value = (int)iii;

            label6.Text = "%";
            label5.Text = "%";
            label4.Text = "%";
            label6.Text += progressBar1.Value.ToString();
            label5.Text += progressBar2.Value.ToString();
            label4.Text += progressBar3.Value.ToString();


            chart1.Series["CPU"].Points.AddY(i);

            chart2.Series["RAM"].Points.AddY(ii);
            chart3.Series["HDD"].Points.AddY(iii);

            label8.Text = "%";
            label8.Text += progressBar1.Value.ToString();

            float x = performanceCounter4.NextValue();
            label9.Text = "%"+ x.ToString();



            int pr1=0;
            foreach (Process proc in Process.GetProcesses())
            {
                
                using (PerformanceCounter pcProcess = new PerformanceCounter("Process", "% Processor Time", proc.ProcessName))
                {
                    pcProcess.NextValue();
                    pr1++;

                }

            }

            label11.Text =pr1.ToString();

            float xx = performanceCounter6.NextValue();
            label13.Text = xx.ToString();


            //Memory
            label15.Text = ii.ToString();


            Microsoft.VisualBasic.Devices.ComputerInfo d = new Microsoft.VisualBasic.Devices.ComputerInfo();
            float xxx=d.TotalPhysicalMemory;
           
            label17.Text = ((int)((xxx/1024)/1024)).ToString();
            label19.Text = (int.Parse(label17.Text) - int.Parse(label15.Text)).ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            chart1.Visible = true;
            chart2.Visible = false;
            chart3.Visible = false;
        }

        private void progressBar3_Click(object sender, EventArgs e)
        {
            chart3.Visible = true;
            chart2.Visible = false;
            chart1.Visible = false;
        }

        private void progressBar2_Click(object sender, EventArgs e)
        {
            chart2.Visible = true;
            chart1.Visible = false;
            chart3.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }

       

       
    }
}
