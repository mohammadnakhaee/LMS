using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EISProjects
{
    public partial class FormWait : Form
    {
        public FormWait()
        {
            InitializeComponent();
            label2.Text = Form1.FWaitTime.ToString() + "(s)";
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Form1.FWaitTime--;
            label2.Text = Form1.FWaitTime.ToString() + "(s)";
            if (Form1.FWaitTime==0)
            {
                timer1.Stop();
                this.Dispose();
            }
        }
    }
}
