using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace EISProjects
{
    public partial class ChronoTimingForm : Form
    {
        bool cancel = true;
        int nSteps = 1;
        public ChronoTimingForm()
        {
            InitializeComponent();
            chart1.Series.Clear();
            AddSeries(chart1, " ", "time (ms)", "Voltage", Color.Navy);
            cancel = true;
            FillForm();
            cancel = false;
            if (Form1.AllSessions[Form1.Selected].PGmode == 3)
            {
                string PGxunit = "";
                uint Amode = 1;
                decimal range =(decimal)1.5;
                if (Form1.AllSessions[Form1.Selected].IVCurrentRangeMode == 0)
                { PGxunit = "(A)"; Amode = 1; }
                else if (Form1.AllSessions[Form1.Selected].IVCurrentRangeMode >= 1 && Form1.AllSessions[Form1.Selected].IVCurrentRangeMode <= 3)
                { PGxunit = "(mA)"; Amode = 1000; }
                else if (Form1.AllSessions[Form1.Selected].IVCurrentRangeMode >= 4 && Form1.AllSessions[Form1.Selected].IVCurrentRangeMode <= 6)
                { PGxunit = "(uA)"; Amode = 1000000; }
                else if (Form1.AllSessions[Form1.Selected].IVCurrentRangeMode == 7)
                { PGxunit = "(nA)"; Amode = 1000000000; }
                label15.Text = PGxunit;
                label3.Text = "Current";
                range = (decimal)((1.5) / Math.Pow(10, Form1.AllSessions[Form1.Selected].IVCurrentRangeMode)) * Amode;
                v1.Maximum = range; v1.Minimum = -range; v1.Increment = range / 15;
                v2.Maximum = range; v2.Minimum = -range; v2.Increment = range / 15;
                v3.Maximum = range; v3.Minimum = -range; v3.Increment = range / 15;
                v4.Maximum = range; v4.Minimum = -range; v4.Increment = range / 15;
                v5.Maximum = range; v5.Minimum = -range; v5.Increment = range / 15;
                v6.Maximum = range; v6.Minimum = -range; v6.Increment = range / 15;
                v7.Maximum = range; v7.Minimum = -range; v7.Increment = range / 15;
                v8.Maximum = range; v8.Minimum = -range; v8.Increment = range / 15;
                v9.Maximum = range; v9.Minimum = -range; v9.Increment = range / 15;
                v10.Maximum = range; v10.Minimum = -range; v10.Increment = range / 15;
            }
            else
            {
                
                decimal range = (decimal)1.5;
                range = (decimal)((1.5) * ((Form1.AllSessions[Form1.Selected].IVVoltageRangeMode) == 0 ? (5.0):(1.0)));
                v1.Maximum = range; v1.Minimum = -range; v1.Increment = range / 15;
                v2.Maximum = range; v2.Minimum = -range; v2.Increment = range / 15;
                v3.Maximum = range; v3.Minimum = -range; v3.Increment = range / 15;
                v4.Maximum = range; v4.Minimum = -range; v4.Increment = range / 15;
                v5.Maximum = range; v5.Minimum = -range; v5.Increment = range / 15;
                v6.Maximum = range; v6.Minimum = -range; v6.Increment = range / 15;
                v7.Maximum = range; v7.Minimum = -range; v7.Increment = range / 15;
                v8.Maximum = range; v8.Minimum = -range; v8.Increment = range / 15;
                v9.Maximum = range; v9.Minimum = -range; v9.Increment = range / 15;
                v10.Maximum = range; v10.Minimum = -range; v10.Increment = range / 15;
            }
            
            
            UpdatePulse();
        }

        private void AddSeries(Chart chart, string legend, string xAxis, string yAxis, Color color)
        {
            chart.Series.Add(legend);
            int Index = -1;
            foreach (Series S in chart.Series) Index++;
            chart.Series[Index].ChartType = SeriesChartType.Line;
            chart.Series[Index].Color = color;
            chart.Series[Index].BorderWidth = 5;
            chart.Series[Index].LegendText = legend;
            chart.ChartAreas[0].Axes[0].Title = xAxis;
            chart.ChartAreas[0].Axes[1].Title = yAxis;
            chart.Series[Index].IsVisibleInLegend = false;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (cancel) return;
            bool isadd = true;
            if (nSteps > (int)numericUpDown1.Value) isadd = false;
            if (isadd)
            {
                if ((int)numericUpDown1.Value == 2) t2.Enabled = isadd;
                else if ((int)numericUpDown1.Value == 3) t3.Enabled = isadd;
                else if ((int)numericUpDown1.Value == 4) t4.Enabled = isadd;
                else if ((int)numericUpDown1.Value == 5) t5.Enabled = isadd;
                else if ((int)numericUpDown1.Value == 6) t6.Enabled = isadd;
                else if ((int)numericUpDown1.Value == 7) t7.Enabled = isadd;
                else if ((int)numericUpDown1.Value == 8) t8.Enabled = isadd;
                else if ((int)numericUpDown1.Value == 9) t9.Enabled = isadd;
                else if ((int)numericUpDown1.Value == 10) t10.Enabled = isadd;

                if ((int)numericUpDown1.Value == 2) v2.Enabled = isadd;
                else if ((int)numericUpDown1.Value == 3) v3.Enabled = isadd;
                else if ((int)numericUpDown1.Value == 4) v4.Enabled = isadd;
                else if ((int)numericUpDown1.Value == 5) v5.Enabled = isadd;
                else if ((int)numericUpDown1.Value == 6) v6.Enabled = isadd;
                else if ((int)numericUpDown1.Value == 7) v7.Enabled = isadd;
                else if ((int)numericUpDown1.Value == 8) v8.Enabled = isadd;
                else if ((int)numericUpDown1.Value == 9) v9.Enabled = isadd;
                else if ((int)numericUpDown1.Value == 10) v10.Enabled = isadd;

                if ((int)numericUpDown1.Value == 2) ocp2.Enabled = isadd;
                else if ((int)numericUpDown1.Value == 3) ocp3.Enabled = isadd;
                else if ((int)numericUpDown1.Value == 4) ocp4.Enabled = isadd;
                else if ((int)numericUpDown1.Value == 5) ocp5.Enabled = isadd;
                else if ((int)numericUpDown1.Value == 6) ocp6.Enabled = isadd;
                else if ((int)numericUpDown1.Value == 7) ocp7.Enabled = isadd;
                else if ((int)numericUpDown1.Value == 8) ocp8.Enabled = isadd;
                else if ((int)numericUpDown1.Value == 9) ocp9.Enabled = isadd;
                else if ((int)numericUpDown1.Value == 10) ocp10.Enabled = isadd;
            }
            else
            {
                if ((int)numericUpDown1.Value == 1) t2.Enabled = isadd;
                else if ((int)numericUpDown1.Value == 2) t3.Enabled = isadd;
                else if ((int)numericUpDown1.Value == 3) t4.Enabled = isadd;
                else if ((int)numericUpDown1.Value == 4) t5.Enabled = isadd;
                else if ((int)numericUpDown1.Value == 5) t6.Enabled = isadd;
                else if ((int)numericUpDown1.Value == 6) t7.Enabled = isadd;
                else if ((int)numericUpDown1.Value == 7) t8.Enabled = isadd;
                else if ((int)numericUpDown1.Value == 8) t9.Enabled = isadd;
                else if ((int)numericUpDown1.Value == 9) t10.Enabled = isadd;

                if ((int)numericUpDown1.Value == 1) v2.Enabled = isadd;
                else if ((int)numericUpDown1.Value == 2) v3.Enabled = isadd;
                else if ((int)numericUpDown1.Value == 3) v4.Enabled = isadd;
                else if ((int)numericUpDown1.Value == 4) v5.Enabled = isadd;
                else if ((int)numericUpDown1.Value == 5) v6.Enabled = isadd;
                else if ((int)numericUpDown1.Value == 6) v7.Enabled = isadd;
                else if ((int)numericUpDown1.Value == 7) v8.Enabled = isadd;
                else if ((int)numericUpDown1.Value == 8) v9.Enabled = isadd;
                else if ((int)numericUpDown1.Value == 9) v10.Enabled = isadd;

                if ((int)numericUpDown1.Value == 1) ocp2.Enabled = isadd;
                else if ((int)numericUpDown1.Value == 2) ocp3.Enabled = isadd;
                else if ((int)numericUpDown1.Value == 3) ocp4.Enabled = isadd;
                else if ((int)numericUpDown1.Value == 4) ocp5.Enabled = isadd;
                else if ((int)numericUpDown1.Value == 5) ocp6.Enabled = isadd;
                else if ((int)numericUpDown1.Value == 6) ocp7.Enabled = isadd;
                else if ((int)numericUpDown1.Value == 7) ocp8.Enabled = isadd;
                else if ((int)numericUpDown1.Value == 8) ocp9.Enabled = isadd;
                else if ((int)numericUpDown1.Value == 9) ocp10.Enabled = isadd;

            }


            nSteps = (int)numericUpDown1.Value;
            
            UpdatePulse();
        }

        private void FillForm()
        {
            numericUpDown1.Value = (Decimal)Form1.AllSessions[Form1.Selected].Chrono_nsteps;
            nSteps = Form1.AllSessions[Form1.Selected].Chrono_nsteps;
            dt1.Value = (Decimal)Form1.AllSessions[Form1.Selected].Chrono_dt;
            dt_ValueChanged(null, null);
            bool isadd = true;
            for (int i= 1; i<=nSteps; i++)
            {
                if (i == 2) t2.Enabled = isadd;
                else if (i == 3) t3.Enabled = isadd;
                else if (i == 4) t4.Enabled = isadd;
                else if (i == 5) t5.Enabled = isadd;
                else if (i == 6) t6.Enabled = isadd;
                else if (i == 7) t7.Enabled = isadd;
                else if (i == 8) t8.Enabled = isadd;
                else if (i == 9) t9.Enabled = isadd;
                else if (i == 10) t10.Enabled = isadd;

                if (i == 2) v2.Enabled = isadd;
                else if (i == 3) v3.Enabled = isadd;
                else if (i == 4) v4.Enabled = isadd;
                else if (i == 5) v5.Enabled = isadd;
                else if (i == 6) v6.Enabled = isadd;
                else if (i == 7) v7.Enabled = isadd;
                else if (i == 8) v8.Enabled = isadd;
                else if (i == 9) v9.Enabled = isadd;
                else if (i == 10) v10.Enabled = isadd;

                if (i == 2) ocp2.Enabled = isadd;
                else if (i == 3) ocp3.Enabled = isadd;
                else if (i == 4) ocp4.Enabled = isadd;
                else if (i == 5) ocp5.Enabled = isadd;
                else if (i == 6) ocp6.Enabled = isadd;
                else if (i == 7) ocp7.Enabled = isadd;
                else if (i == 8) ocp8.Enabled = isadd;
                else if (i == 9) ocp9.Enabled = isadd;
                else if (i == 10) ocp10.Enabled = isadd;

            }

            t1.Value = (Decimal)Form1.AllSessions[Form1.Selected].Chrono_t1;
            t2.Value = (Decimal)Form1.AllSessions[Form1.Selected].Chrono_t2;
            t3.Value = (Decimal)Form1.AllSessions[Form1.Selected].Chrono_t3;
            t4.Value = (Decimal)Form1.AllSessions[Form1.Selected].Chrono_t4;
            t5.Value = (Decimal)Form1.AllSessions[Form1.Selected].Chrono_t5;
            t6.Value = (Decimal)Form1.AllSessions[Form1.Selected].Chrono_t6;
            t7.Value = (Decimal)Form1.AllSessions[Form1.Selected].Chrono_t7;
            t8.Value = (Decimal)Form1.AllSessions[Form1.Selected].Chrono_t8;
            t9.Value = (Decimal)Form1.AllSessions[Form1.Selected].Chrono_t9;
            t10.Value = (Decimal)Form1.AllSessions[Form1.Selected].Chrono_t10;

            v1.Value = (Decimal)Form1.AllSessions[Form1.Selected].Chrono_v1;
            v2.Value = (Decimal)Form1.AllSessions[Form1.Selected].Chrono_v2;
            v3.Value = (Decimal)Form1.AllSessions[Form1.Selected].Chrono_v3;
            v4.Value = (Decimal)Form1.AllSessions[Form1.Selected].Chrono_v4;
            v5.Value = (Decimal)Form1.AllSessions[Form1.Selected].Chrono_v5;
            v6.Value = (Decimal)Form1.AllSessions[Form1.Selected].Chrono_v6;
            v7.Value = (Decimal)Form1.AllSessions[Form1.Selected].Chrono_v7;
            v8.Value = (Decimal)Form1.AllSessions[Form1.Selected].Chrono_v8;
            v9.Value = (Decimal)Form1.AllSessions[Form1.Selected].Chrono_v9;
            v10.Value = (Decimal)Form1.AllSessions[Form1.Selected].Chrono_v10;

            ocp1.Checked = Form1.AllSessions[Form1.Selected].Chrono_ocp1;
            ocp2.Checked = Form1.AllSessions[Form1.Selected].Chrono_ocp2;
            ocp3.Checked = Form1.AllSessions[Form1.Selected].Chrono_ocp3;
            ocp4.Checked = Form1.AllSessions[Form1.Selected].Chrono_ocp4;
            ocp5.Checked = Form1.AllSessions[Form1.Selected].Chrono_ocp5;
            ocp6.Checked = Form1.AllSessions[Form1.Selected].Chrono_ocp6;
            ocp7.Checked = Form1.AllSessions[Form1.Selected].Chrono_ocp7;
            ocp8.Checked = Form1.AllSessions[Form1.Selected].Chrono_ocp8;
            ocp9.Checked = Form1.AllSessions[Form1.Selected].Chrono_ocp9;
            ocp10.Checked = Form1.AllSessions[Form1.Selected].Chrono_ocp10;

        }

        private void UpdatePulse()
        {
            Form1.AllSessions[Form1.Selected].Chrono_nsteps = (int)numericUpDown1.Value;

            Form1.AllSessions[Form1.Selected].Chrono_t1 = (double)t1.Value;
            Form1.AllSessions[Form1.Selected].Chrono_t2 = (double)t2.Value;
            Form1.AllSessions[Form1.Selected].Chrono_t3 = (double)t3.Value;
            Form1.AllSessions[Form1.Selected].Chrono_t4 = (double)t4.Value;
            Form1.AllSessions[Form1.Selected].Chrono_t5 = (double)t5.Value;
            Form1.AllSessions[Form1.Selected].Chrono_t6 = (double)t6.Value;
            Form1.AllSessions[Form1.Selected].Chrono_t7 = (double)t7.Value;
            Form1.AllSessions[Form1.Selected].Chrono_t8 = (double)t8.Value;
            Form1.AllSessions[Form1.Selected].Chrono_t9 = (double)t9.Value;
            Form1.AllSessions[Form1.Selected].Chrono_t10 = (double)t10.Value;

            Form1.AllSessions[Form1.Selected].Chrono_v1 = (double)v1.Value;
            Form1.AllSessions[Form1.Selected].Chrono_v2 = (double)v2.Value;
            Form1.AllSessions[Form1.Selected].Chrono_v3 = (double)v3.Value;
            Form1.AllSessions[Form1.Selected].Chrono_v4 = (double)v4.Value;
            Form1.AllSessions[Form1.Selected].Chrono_v5 = (double)v5.Value;
            Form1.AllSessions[Form1.Selected].Chrono_v6 = (double)v6.Value;
            Form1.AllSessions[Form1.Selected].Chrono_v7 = (double)v7.Value;
            Form1.AllSessions[Form1.Selected].Chrono_v8 = (double)v8.Value;
            Form1.AllSessions[Form1.Selected].Chrono_v9 = (double)v9.Value;
            Form1.AllSessions[Form1.Selected].Chrono_v10 = (double)v10.Value;

            Form1.AllSessions[Form1.Selected].Chrono_dt = (double)dt1.Value;

            Form1.AllSessions[Form1.Selected].Chrono_ocp1 = ocp1.Checked;
            Form1.AllSessions[Form1.Selected].Chrono_ocp2 = ocp2.Checked;
            Form1.AllSessions[Form1.Selected].Chrono_ocp3 = ocp3.Checked;
            Form1.AllSessions[Form1.Selected].Chrono_ocp4 = ocp4.Checked;
            Form1.AllSessions[Form1.Selected].Chrono_ocp5 = ocp5.Checked;
            Form1.AllSessions[Form1.Selected].Chrono_ocp6 = ocp6.Checked;
            Form1.AllSessions[Form1.Selected].Chrono_ocp7 = ocp7.Checked;
            Form1.AllSessions[Form1.Selected].Chrono_ocp8 = ocp8.Checked;
            Form1.AllSessions[Form1.Selected].Chrono_ocp9 = ocp9.Checked;
            Form1.AllSessions[Form1.Selected].Chrono_ocp10 = ocp10.Checked;

            //PulseMaxVoltage = -100000000.0;
            //PulseMinVoltage = 100000000.0;
            try { chart1.Series[0].Points.Clear(); } catch { }

            //Form1.AllSessions[Form1.Selected].Chrono_n = (int)NUD_pulsenumber.Value;
            double oldval = Form1.AllSessions[Form1.Selected].PretreatmentVoltage;
            double told = -Form1.AllSessions[Form1.Selected].EqTime;
            AddPoint(chart1, 0, told, oldval);
            told = 0;
            for (int i = 1; i <= nSteps; i++)
            {
                double ocp = 0;
                double t = 0;
                double v = 0;

                if (i == 1) t = (double)t1.Value;
                else if (i == 2) t = (double)t2.Value;
                else if (i == 3) t = (double)t3.Value;
                else if (i == 4) t = (double)t4.Value;
                else if (i == 5) t = (double)t5.Value;
                else if (i == 6) t = (double)t6.Value;
                else if (i == 7) t = (double)t7.Value;
                else if (i == 8) t = (double)t8.Value;
                else if (i == 9) t = (double)t9.Value;
                else if (i == 10) t = (double)t10.Value;

                if (i == 1 && ocp1.Checked) ocp = 1;
                else if (i == 2 && ocp2.Checked) ocp = 1;
                else if (i == 3 && ocp3.Checked) ocp = 1;
                else if (i == 4 && ocp4.Checked) ocp = 1;
                else if (i == 5 && ocp5.Checked) ocp = 1;
                else if (i == 6 && ocp6.Checked) ocp = 1;
                else if (i == 7 && ocp7.Checked) ocp = 1;
                else if (i == 8 && ocp8.Checked) ocp = 1;
                else if (i == 9 && ocp9.Checked) ocp = 1;
                else if (i == 10 && ocp10.Checked) ocp = 1;

                if (i == 1) v = (double)v1.Value;
                else if (i == 2) v = (double)v2.Value;
                else if (i == 3) v = (double)v3.Value;
                else if (i == 4) v = (double)v4.Value;
                else if (i == 5) v = (double)v5.Value;
                else if (i == 6) v = (double)v6.Value;
                else if (i == 7) v = (double)v7.Value;
                else if (i == 8) v = (double)v8.Value;
                else if (i == 9) v = (double)v9.Value;
                else if (i == 10) v = (double)v10.Value;

                AddPoint(chart1, 0, told, oldval);
                oldval = v; 
                AddPoint(chart1, 0, told, oldval);
                told = told + t;
            }

            AddPoint(chart1, 0, told, oldval);
             
        }

        private void AddPoint(Chart chart, int SeriesIndex, double x, double y)
        {
            chart.Series[SeriesIndex].Points.AddXY(x, y);
        }
         
        private void v1_ValueChanged(object sender, EventArgs e)
        {
            if (cancel) return;
            UpdatePulse();
        }

        private void dt_ValueChanged(object sender, EventArgs e)
        {
            int maxper = (int)(9998 * (double)dt1.Value / 1000.0);
            if ((double)dt1.Value < 1000) maxper = (int)(maxper / 19);
            //if (maxper)
            maxperiod.Text = "Maximum period of each part: " + maxper.ToString() + "(sec)";
            t1.Maximum = maxper;
            t2.Maximum = maxper;
            t3.Maximum = maxper;
            t4.Maximum = maxper;
            t5.Maximum = maxper;
            t6.Maximum = maxper;
            t7.Maximum = maxper;
            t8.Maximum = maxper;
            t9.Maximum = maxper;
            t10.Maximum = maxper;
            v1_ValueChanged(null, null);
        }
    }
}
