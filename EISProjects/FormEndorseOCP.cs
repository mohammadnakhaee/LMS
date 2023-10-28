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
    public partial class FormEndorseOCP : Form
    {
        public FormEndorseOCP()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.isEndorseOCTOk = false;
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1.isEndorseOCTOk = true;
            this.Dispose();
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            DigitTextChange(ref Form1.EndorseOCTSugestedV, textBox1, -1000, 1000);
        }

        private void DigitTextChange(ref double digit, TextBox tb, double min, double max)
        {
            try
            {
                digit = Convert.ToDouble(tb.Text);
                if (digit < min) digit = min;
                if (digit > max) digit = max;
            }
            catch
            {
                tb.Text = digit.ToString();
                MessageBox.Show("Please type digit only ...");
            }
        }

        private void FormEndorseOCP_Shown(object sender, EventArgs e)
        {
            try
            {
                Form1.isEndorseOCTOk = false;
                textBox1.Text = Form1.EndorseOCTSugestedV.ToString();
                if (Form1.AllSessions[EIS.RunningSession].isOCP && Form1.AllSessions[EIS.RunningSession].isOCPAutoStart) button2_Click(null, null);
            }
            catch { }
        }
    }
}
