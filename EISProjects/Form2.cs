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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            SetLabelJustForVoltage(ref LVoltage, Form1.WarningV, "V");
            SetLabel(ref LCurrent, Form1.WarningI, "A");
            if (Form1.isEISVoltageAndCurrentWarning) label1.Visible = true;
        }

        private void BtnNo_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void BtnYes_Click(object sender, EventArgs e)
        {
            Form1.isEISVoltageAndCurrentOK = true;
            this.Dispose();
        }

        private void SetLabel(ref Label l, double n, string Unit)
        {
            double m = Math.Abs(n);
            if (m >= 1000000000.0)
                l.Text = (n / 1000000000.0).ToString("0.000") + " G" + Unit;
            else if (m < 1000000000.0 && m >= 1000000.0)
                l.Text = (n / 1000000.0).ToString("0.000") + " M" + Unit;
            else if (m < 1000000.0 && m >= 1000.0)
                l.Text = (n / 1000.0).ToString("0.000") + " K" + Unit;
            else if (m < 1000.0 && m >= 1.0)
                l.Text = (n).ToString("0.000") + " " + Unit;
            else if (m < 1.0 && m >= 0.0001)
                l.Text = (1000.0 * n).ToString("0.000") + " m" + Unit;
            else if (m < 0.0001)
                l.Text = (1000000.0 * n).ToString("0.000") + " u" + Unit;
            l.Refresh();
        }

        private void SetLabelJustForVoltage(ref Label l, double n, string Unit)
        {
            double m = Math.Abs(n);
            l.Text = n.ToString("0.00") + " " + Unit;
            l.Refresh();
        }
        
    }
}
