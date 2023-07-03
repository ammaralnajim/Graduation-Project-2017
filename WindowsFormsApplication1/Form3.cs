using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;


namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            listView1.View = View.Details;
            listView1.FullRowSelect = true;

            listView1.Columns.Add("Process name", 150);
            listView1.Columns.Add("ID", 150);
            listView1.Columns.Add("Description", 150);
            listView1.Columns.Add("Status", 150);
            listView1.Columns.Add("Threads", 150);
            listView1.Columns.Add("CPU", 150);
           // listView1.Columns.Add("Averag", 150);


            listView2.View = View.Details;
            listView2.FullRowSelect = true;

            listView2.Columns.Add("Process name", 150);
            listView2.Columns.Add("ID", 150);
            listView2.Columns.Add("Commit (KB)", 150);
            listView2.Columns.Add("Working set (KB)", 150);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void add(string process,string id, string desc,string stat,string th, string CPU)
        {
            string[] row = { process,id, desc,stat,th, CPU };
            ListViewItem item = new ListViewItem(row);
            listView1.Items.Add(item);

        }

        private void add1(string process, string id, string work, string work1)
        {
            string[] row = { process, id, work,work1 };
            ListViewItem item = new ListViewItem(row);
            listView2.Items.Add(item);

        }




       

        private void timer1_Tick(object sender, EventArgs e)
        {
            // CPU
            listView1.Items.Clear();
            // Memory
            listView2.Items.Clear();
            foreach (Process pr in Process.GetProcesses())
            {
                try
                {
                    string c;
                    if (pr.Responding==true)
                        c="running";
                    else
                        c="suspending";
                    
                  
                    add(pr.ProcessName, pr.Id.ToString(), pr.MainModule.FileVersionInfo.FileDescription, c,pr.Threads.Count.ToString(), pr.TotalProcessorTime.Seconds.ToString());
                    add1(pr.ProcessName, pr.Id.ToString(),(pr.PrivateMemorySize64/1024).ToString(),(pr.WorkingSet64/1024).ToString());
                }
                catch { }
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Visible = true;
            listView2.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listView2.Visible = true;
            listView1.Visible = false;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

     

       

       

        
    }
}
