using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;

namespace EISProjects
{
    public partial class Form3 : Form
    {
        public static double[] time;
        public static double[] pulse;
        public static string ReadToChar = "\r";
        public static string WriteReadToChar = "\r";
        public static double PulseMaxVoltage = 0;
        public static double PulseMinVoltage = 0;
          
        public Form3()
        {
            InitializeComponent();
            chart1.Series.Clear();
            AddSeries(chart1," ","time (ms)","Pulse",Color.Navy);
            AddSeriesPoint(chart1, "measures", "time (ms)", "Measures", Color.Red);
            AddSeries(chart1, "Low", " ", " ", Color.Red);
            AddSeries(chart1, "High", " ", " ", Color.Red);

            string PGxunit = "(V";
            if (Form1.AllSessions[Form1.Selected].PGmode == 3)
            {
                if (Form1.AllSessions[Form1.Selected].PulseCurrentRangeMode == 0)
                    PGxunit = "(A";
                else if (Form1.AllSessions[Form1.Selected].PulseCurrentRangeMode >= 1 && Form1.AllSessions[Form1.Selected].PulseCurrentRangeMode <= 3)
                    PGxunit = "(mA";
                else if (Form1.AllSessions[Form1.Selected].PulseCurrentRangeMode >= 4 && Form1.AllSessions[Form1.Selected].PulseCurrentRangeMode <= 6)
                    PGxunit = "(uA";
                else if (Form1.AllSessions[Form1.Selected].PulseCurrentRangeMode == 7)
                    PGxunit = "(nA";
            }

            u1.Text = PGxunit + ")";
            u2.Text = PGxunit + ")";
            u3.Text = PGxunit + ")";
            u4.Text = PGxunit + ")";
            u5.Text = PGxunit + ")";
            u6.Text = PGxunit + "/s)";
            u7.Text = PGxunit + ")";

            this.NUD_pulsenumber.ValueChanged -= new System.EventHandler(this.NUD_pulsenumber_ValueChanged);
            this.NUD_TotalPeriod.ValueChanged -= new System.EventHandler(this.NUD_TotalPeriod_ValueChanged);
            this.NUD_PulsePeriod.ValueChanged -= new System.EventHandler(this.NUD_PulsePeriod_ValueChanged);
            this.NUD_PulseLevel.ValueChanged -= new System.EventHandler(this.NUD_PulseLevel_ValueChanged);
            this.NUD_PulseAmp.ValueChanged -= new System.EventHandler(this.NUD_PulseAmp_ValueChanged);
            this.NUD_LevelStep.ValueChanged -= new System.EventHandler(this.NUD_LevelStep_ValueChanged);
            this.NUD_AmpStep.ValueChanged -= new System.EventHandler(this.NUD_AmpStep_ValueChanged);
            this.NUD_FinalPotential.ValueChanged -= new System.EventHandler(this.NUD_FinalPotential_ValueChanged);
            this.NUD_Frequency.ValueChanged -= new System.EventHandler(this.NUD_Frequency_ValueChanged);
            
            NUD_pulsenumber.Value = (int)Form1.AllSessions[Form1.Selected].Chrono_n;
            NUD_TotalPeriod.Value = (decimal)Form1.AllSessions[Form1.Selected].Chrono_Total_Period;
            NUD_PulsePeriod.Value = (decimal)Form1.AllSessions[Form1.Selected].Chrono_Pulse_Period;
            NUD_PulseLevel.Value = (decimal)Form1.AllSessions[Form1.Selected].Chrono_Pulse_Level;
            NUD_PulseAmp.Value = (decimal)Form1.AllSessions[Form1.Selected].Chrono_Pulse_Amplitude;
            NUD_LevelStep.Value = (decimal)Form1.AllSessions[Form1.Selected].Chrono_Level_Step;
            NUD_AmpStep.Value = (decimal)Form1.AllSessions[Form1.Selected].Chrono_Amplitude_step;
            if (Form1.AllSessions[Form1.Selected].PulseVoltammetryMode == 0) 
                NUD_FinalPotential.Value = (decimal)(((double)NUD_pulsenumber.Value - 1.0) * (double)NUD_AmpStep.Value + ((double)NUD_PulseLevel.Value + (double)NUD_PulseAmp.Value));
            else
                NUD_FinalPotential.Value = (decimal)(((double)NUD_pulsenumber.Value - 1.0) * (double)NUD_AmpStep.Value + ((double)NUD_PulseLevel.Value));
            NUD_Frequency.Value = (decimal)(1000.0 / (double)NUD_TotalPeriod.Value);


            this.NUD_pulsenumber.ValueChanged += new System.EventHandler(this.NUD_pulsenumber_ValueChanged);
            this.NUD_TotalPeriod.ValueChanged += new System.EventHandler(this.NUD_TotalPeriod_ValueChanged);
            this.NUD_PulsePeriod.ValueChanged += new System.EventHandler(this.NUD_PulsePeriod_ValueChanged);
            this.NUD_PulseLevel.ValueChanged += new System.EventHandler(this.NUD_PulseLevel_ValueChanged);
            this.NUD_PulseAmp.ValueChanged += new System.EventHandler(this.NUD_PulseAmp_ValueChanged);
            this.NUD_LevelStep.ValueChanged += new System.EventHandler(this.NUD_LevelStep_ValueChanged);
            this.NUD_AmpStep.ValueChanged += new System.EventHandler(this.NUD_AmpStep_ValueChanged);
            this.NUD_FinalPotential.ValueChanged += new System.EventHandler(this.NUD_FinalPotential_ValueChanged);
            this.NUD_Frequency.ValueChanged += new System.EventHandler(this.NUD_Frequency_ValueChanged);

            if (Form1.AllSessions[Form1.Selected].PulseReadingEdgemode == 0)
            {
                RB_Trailing.Checked = true;
                RB_Leading.Checked = false;
                RB_Differential.Checked = false;
            }
            else if (Form1.AllSessions[Form1.Selected].PulseReadingEdgemode == 1)
            {
                RB_Trailing.Checked = false;
                RB_Leading.Checked = true;
                RB_Differential.Checked = false;
            }
            else if (Form1.AllSessions[Form1.Selected].PulseReadingEdgemode == 2)
            {
                RB_Trailing.Checked = false;
                RB_Leading.Checked = false;
                RB_Differential.Checked = true;
            }
            CBVoltammetryMode.SelectedIndex = Form1.AllSessions[Form1.Selected].PulseVoltammetryMode;
            CBVoltammetryMode_SelectedIndexChanged(null, null);
            NUD_PulsePeriod.Maximum = NUD_TotalPeriod.Value - 1;
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

        private void AddSeriesPoint(Chart chart, string legend, string xAxis, string yAxis, Color color)
        {
            chart.Series.Add(legend);
            int Index = -1;
            foreach (Series S in chart.Series) Index++;
            chart.Series[Index].ChartType = SeriesChartType.Point;
            chart.Series[Index].Color = color;
            chart.Series[Index].BorderWidth = 10;
            chart.Series[Index].LegendText = legend;
            chart.ChartAreas[0].Axes[0].Title = xAxis;
            chart.ChartAreas[0].Axes[1].Title = yAxis;
            chart.Series[Index].IsVisibleInLegend = false;
        }

        private void UpdatePulse()
        {
            PulseMaxVoltage = -100000000.0;
            PulseMinVoltage = 100000000.0;
            try { chart1.Series[0].Points.Clear(); }catch { }
            try { chart1.Series[1].Points.Clear(); }catch { }
            try { chart1.Series[2].Points.Clear(); }catch { }
            try { chart1.Series[3].Points.Clear(); }catch { }
            Form1.AllSessions[Form1.Selected].Chrono_n = (int)NUD_pulsenumber.Value;
            Form1.AllSessions[Form1.Selected].Chrono_Total_Period = (double)NUD_TotalPeriod.Value;
            Form1.AllSessions[Form1.Selected].Chrono_Pulse_Period = (double)NUD_PulsePeriod.Value;
            Form1.AllSessions[Form1.Selected].Chrono_Pulse_Level = (double)NUD_PulseLevel.Value;
            Form1.AllSessions[Form1.Selected].Chrono_Pulse_Amplitude = (double)NUD_PulseAmp.Value;
            Form1.AllSessions[Form1.Selected].Chrono_Level_Step = (double)NUD_LevelStep.Value;
            Form1.AllSessions[Form1.Selected].Chrono_Amplitude_step = (double)NUD_AmpStep.Value;

            int n = Form1.AllSessions[Form1.Selected].Chrono_n;
            double TotalPeriod = Form1.AllSessions[Form1.Selected].Chrono_Total_Period;
            double PulsePeriod = Form1.AllSessions[Form1.Selected].Chrono_Pulse_Period;
            double PulseLevel = Form1.AllSessions[Form1.Selected].Chrono_Pulse_Level;
            double PulseAmp = Form1.AllSessions[Form1.Selected].Chrono_Pulse_Amplitude;
            double LevelStep = Form1.AllSessions[Form1.Selected].Chrono_Level_Step;
            double AmpStep = Form1.AllSessions[Form1.Selected].Chrono_Amplitude_step;

            if (CBVoltammetryMode.SelectedIndex == 2) PulseAmp = -PulseAmp;
            double sw = PulseAmp / 2;
            if (CBVoltammetryMode.SelectedIndex == 2) PulseLevel = PulseLevel - sw;
            double t2 = (TotalPeriod - PulsePeriod);
            if (CBVoltammetryMode.SelectedIndex == 2) AddPoint(chart1, 0, -t2, PulseLevel + sw);

            AddPoint(chart1, 0, -t2, PulseLevel);
            for (int i = 0; i < n; i++)
            {
                double vvv = PulseLevel + i * LevelStep;
                if (PulseMaxVoltage < vvv) PulseMaxVoltage = vvv;
                if (PulseMinVoltage > vvv) PulseMinVoltage = vvv;
                AddPoint(chart1, 0, 0 + i * TotalPeriod, vvv);
                vvv = PulseLevel + PulseAmp + i * AmpStep;
                if (PulseMaxVoltage < vvv) PulseMaxVoltage = vvv;
                if (PulseMinVoltage > vvv) PulseMinVoltage = vvv;
                AddPoint(chart1, 0, 0 + i * TotalPeriod, vvv);
                vvv = PulseLevel + PulseAmp + i * AmpStep;
                if (PulseMaxVoltage < vvv) PulseMaxVoltage = vvv;
                if (PulseMinVoltage > vvv) PulseMinVoltage = vvv;
                AddPoint(chart1, 0, PulsePeriod + i * TotalPeriod, vvv);
                vvv = PulseLevel + (i + 1) * LevelStep;
                if (PulseMaxVoltage < vvv) PulseMaxVoltage = vvv;
                if (PulseMinVoltage > vvv) PulseMinVoltage = vvv;
                
                if (i == n - 1 && CBVoltammetryMode.SelectedIndex == 2)
                    AddPoint(chart1, 0, PulsePeriod + i * TotalPeriod, vvv + sw - LevelStep);
                else
                    AddPoint(chart1, 0, PulsePeriod + i * TotalPeriod, vvv);

                if (Form1.AllSessions[Form1.Selected].PulseReadingEdgemode == 0)
                {
                    AddPoint(chart1, 1, 0 + i * TotalPeriod + 0.00001, PulseLevel + i * LevelStep + 0.00001);
                }
                else if (Form1.AllSessions[Form1.Selected].PulseReadingEdgemode == 1)
                {
                    AddPoint(chart1, 1, PulsePeriod + i * TotalPeriod + 0.00001, PulseLevel + PulseAmp + i * AmpStep + 0.00001);
                }
                else if (Form1.AllSessions[Form1.Selected].PulseReadingEdgemode == 2)
                {
                    AddPoint(chart1, 1, 0 + i * TotalPeriod + 0.00001, PulseLevel + i * LevelStep + 0.00001);
                    AddPoint(chart1, 1, PulsePeriod + i * TotalPeriod + 0.00001, PulseLevel + PulseAmp + i * AmpStep + 0.00001);
                }
            }
            if (CBVoltammetryMode.SelectedIndex != 2) AddPoint(chart1, 0, TotalPeriod + (n - 1) * TotalPeriod, PulseLevel + n * LevelStep);

            double Thereshold = 0;
            if (Form1.AllSessions[Form1.Selected].PulseVoltageRangeMode == 0) Thereshold = 5;
            if (Form1.AllSessions[Form1.Selected].PulseVoltageRangeMode == 1) Thereshold = 1;


            double xmin = -t2;
            double xmax = TotalPeriod + (n - 1) * TotalPeriod;
            WarnLabel.Visible = false;
            if (PulseMinVoltage < -Thereshold)
            {
                WarnLabel.Visible = true;
                AddPoint(chart1, 2, xmin, -Thereshold);
                AddPoint(chart1, 2, xmax, -Thereshold);
            }

            if (PulseMaxVoltage > Thereshold)
            {
                WarnLabel.Visible = true;
                AddPoint(chart1, 3, xmin, Thereshold);
                AddPoint(chart1, 3, xmax, Thereshold);
            }

            //double frq = 1000.0 / TotalPeriod;
            
            //frqlabel.Text = frq.ToString("0.000") + " (Hz)";
            NUD_Frequency.Value = (decimal)(1000.0 / (double)NUD_TotalPeriod.Value);
            //Eswlabel.Text = Esw.ToString("0.000") + " " + u2.Text;
            
            NUD_ScanRate.Value = (decimal)(AmpStep / (PulsePeriod / 1000.0));

        }

        private void AddPoint(Chart chart, int SeriesIndex, double x, double y)
        {
            chart.Series[SeriesIndex].Points.AddXY(x, y);
        }

        private void NUD_pulsenumber_ValueChanged(object sender, EventArgs e)
        {
            UpdatePulse();
            this.NUD_FinalPotential.ValueChanged -= new System.EventHandler(this.NUD_FinalPotential_ValueChanged);
            if (Form1.AllSessions[Form1.Selected].PulseVoltammetryMode == 0) 
                NUD_FinalPotential.Value = (decimal)(((double)NUD_pulsenumber.Value - 1.0) * (double)NUD_AmpStep.Value + ((double)NUD_PulseLevel.Value + (double)NUD_PulseAmp.Value));
            else
                NUD_FinalPotential.Value = (decimal)(((double)NUD_pulsenumber.Value - 1.0) * (double)NUD_AmpStep.Value + ((double)NUD_PulseLevel.Value));
            this.NUD_FinalPotential.ValueChanged += new System.EventHandler(this.NUD_FinalPotential_ValueChanged);
        }

        private void NUD_TotalPeriod_ValueChanged(object sender, EventArgs e)
        {
            NUD_PulsePeriod.Maximum = NUD_TotalPeriod.Value - 1;
            if (CBVoltammetryMode.SelectedIndex == 2)
            {
                NUD_PulsePeriod.Value = (decimal)((int)((double)NUD_TotalPeriod.Value / 2));
            }
            UpdatePulse();
        }

        private void NUD_PulsePeriod_ValueChanged(object sender, EventArgs e)
        {
            UpdatePulse();
        }

        private void NUD_PulseLevel_ValueChanged(object sender, EventArgs e)
        {
            UpdatePulse();
            CheckPulse();
        }

        private void NUD_PulseAmp_ValueChanged(object sender, EventArgs e)
        {
            if (CBVoltammetryMode.SelectedIndex == 2)
            {
                //NUD_PulseLevel.Value = -NUD_PulseAmp.Value;
            }
            UpdatePulse();
            CheckPulse();
        }

        private void NUD_LevelStep_ValueChanged(object sender, EventArgs e)
        {
            UpdatePulse();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (RB_Trailing.Checked)
            {
                Form1.AllSessions[Form1.Selected].PulseReadingEdgemode = 0;
                UpdatePulse();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (RB_Leading.Checked)
            {
                Form1.AllSessions[Form1.Selected].PulseReadingEdgemode = 1;
                UpdatePulse();
            }
        }

        private void BtnTest_Click(object sender, EventArgs e)
        {
            
        }

        private void RB_Differential_CheckedChanged(object sender, EventArgs e)
        {
            if (RB_Differential.Checked)
            {
                Form1.AllSessions[Form1.Selected].PulseReadingEdgemode = 2;
                UpdatePulse();
            }
        }

        private void CBVoltammetryMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form1.AllSessions[Form1.Selected].PulseVoltammetryMode = CBVoltammetryMode.SelectedIndex;
            NUD_LevelStep.Enabled = true;
            NUD_PulseLevel.Enabled = true;
            RB_Trailing.Enabled = true;
            RB_Leading.Enabled = true;
            RB_Differential.Enabled = true;
            NUD_PulsePeriod.Enabled = true;
            NUD_Esw.Visible = false;
            u7.Visible = false;
            El.Visible = false;
            swl.Visible = false;
            HzLabel.Visible = false;
            NUD_Frequency.Visible = false;
            frql.Visible = false;
            swcolon.Visible = false;
            NUD_PulseAmp.Enabled = true;

            if (CBVoltammetryMode.SelectedIndex == 0)
            {
                NUD_LevelStep.Value = 0;
                NUD_LevelStep.Enabled = false;
                if (RB_Differential.Checked)
                {
                    RB_Leading.Checked = true;
                    Form1.AllSessions[Form1.Selected].PulseReadingEdgemode = 1;
                }
                RB_Differential.Enabled = false;
            }
            else if (CBVoltammetryMode.SelectedIndex == 1)
            {
                NUD_LevelStep.Value = NUD_AmpStep.Value;
                RB_Differential_CheckedChanged(null, null);
                NUD_LevelStep.Enabled = false;
                RB_Trailing.Enabled = false;
                RB_Leading.Enabled = false;
                RB_Differential.Checked = true;
                Form1.AllSessions[Form1.Selected].PulseReadingEdgemode = 2;
                /*NUD_PulseAmp.Maximum = 10;
                NUD_PulseAmp.Minimum = -10;
                NUD_PulseAmp.Value = Math.Abs(NUD_PulseAmp.Value);
                NUD_PulseAmp.Maximum = 10;
                NUD_PulseAmp.Minimum = -10;*/
            }
            else if (CBVoltammetryMode.SelectedIndex == 2)
            {
                //NUD_LevelStep.Value = NUD_AmpStep.Value;
                //NUD_PulseLevel.Value = -NUD_PulseAmp.Value;
                //RB_Differential_CheckedChanged(null, null);
                //NUD_LevelStep.Enabled = false;
                //NUD_PulseLevel.Enabled = false;
                //RB_Trailing.Enabled = false;
                //RB_Leading.Enabled = false;
                //RB_Differential.Checked = true;
                //Form1.AllSessions[Form1.Selected].PulseReadingEdgemode = 2;
                NUD_PulseAmp.Enabled = false;
                NUD_Esw.Visible = true;
                u7.Visible = true;
                El.Visible = true;
                swl.Visible = true;
                HzLabel.Visible = true;
                NUD_Frequency.Visible = true;
                frql.Visible = true;
                swcolon.Visible = true;

                NUD_LevelStep.Value = NUD_AmpStep.Value;
                NUD_PulsePeriod.Value = (decimal)((int)((double)NUD_TotalPeriod.Value / 2));
                RB_Differential_CheckedChanged(null, null);
                NUD_LevelStep.Enabled = false;
                RB_Trailing.Enabled = false;
                RB_Leading.Enabled = false;
                NUD_PulsePeriod.Enabled = false;
                RB_Differential.Checked = true;
                Form1.AllSessions[Form1.Selected].PulseReadingEdgemode = 2;
                /*NUD_PulseAmp.Maximum = 10;
                NUD_PulseAmp.Minimum = -10;
                NUD_PulseAmp.Value = - Math.Abs(NUD_PulseAmp.Value);
                NUD_PulseAmp.Maximum = 10;
                NUD_PulseAmp.Minimum = -10;*/
            }
            else if (CBVoltammetryMode.SelectedIndex == 3)
            {
                NUD_PulseAmp.Maximum = 10;
                NUD_PulseAmp.Minimum = -10;
                //Custom mode: There is no limitation
            }

            double Esw = (double)NUD_PulseAmp.Value / 2.0;
            NUD_Esw.Value = (decimal)Esw;
        }


        private void NUD_AmpStep_ValueChanged(object sender, EventArgs e)
        {
            CheckPulse();
        }

        private void NUD_FinalPotential_ValueChanged(object sender, EventArgs e)
        {
            double sign = 1;
            if (Form1.AllSessions[Form1.Selected].PulseVoltammetryMode == 0)
            {
                if ((double)NUD_FinalPotential.Value < ((double)NUD_PulseLevel.Value + (double)NUD_PulseAmp.Value)) sign = -1;
            }
            else
            {
                if ((double)NUD_FinalPotential.Value < ((double)NUD_PulseLevel.Value)) sign = -1;
            }

            NUD_AmpStep.Minimum = -1000;
            NUD_AmpStep.Maximum = 1000;
            NUD_ScanRate.Minimum = -10000000;
            NUD_ScanRate.Maximum = 10000000;
            NUD_ScanRate.Value = (decimal)(sign * Math.Abs((double)NUD_ScanRate.Value));

            if (sign < 0)
            {
                NUD_AmpStep.Minimum = -1000;
                NUD_AmpStep.Maximum = 0;
                NUD_ScanRate.Minimum = -10000000;
                NUD_ScanRate.Maximum = 0;
            }
            else
            {
                NUD_AmpStep.Minimum = 0;
                NUD_AmpStep.Maximum = 1000;
                NUD_ScanRate.Minimum = 0;
                NUD_ScanRate.Maximum = 10000000;
            }
            CheckPulse();
            if (Form1.AllSessions[Form1.Selected].PulseVoltammetryMode == 0) 
                NUD_FinalPotential.Value = (decimal)(((double)NUD_pulsenumber.Value - 1.0) * (double)NUD_AmpStep.Value + ((double)NUD_PulseLevel.Value + (double)NUD_PulseAmp.Value));
            else
                NUD_FinalPotential.Value = (decimal)(((double)NUD_pulsenumber.Value - 1.0) * (double)NUD_AmpStep.Value + ((double)NUD_PulseLevel.Value));
        }

        private void CheckPulse()
        {
            if (Math.Abs((double)NUD_AmpStep.Value) > 0.0001)
            {
                int n=0;
                if (Form1.AllSessions[Form1.Selected].PulseVoltammetryMode == 0) 
                    n = (int)(((double)NUD_FinalPotential.Value - ((double)NUD_PulseLevel.Value + (double)NUD_PulseAmp.Value)) / (double)NUD_AmpStep.Value);
                else
                    n = (int)(((double)NUD_FinalPotential.Value - ((double)NUD_PulseLevel.Value)) / (double)NUD_AmpStep.Value);
                if ((double)NUD_PulseAmp.Value < 0) n= (int)(((double)NUD_FinalPotential.Value - ((double)NUD_PulseLevel.Value)) / (double)NUD_AmpStep.Value);

                if (n < 0)
                {
                    double sign = 1;
                    if (Form1.AllSessions[Form1.Selected].PulseVoltammetryMode == 0)
                    {
                        if ((double)NUD_FinalPotential.Value < ((double)NUD_PulseLevel.Value + (double)NUD_PulseAmp.Value)) sign = -1;
                    }
                    else
                    {
                        if ((double)NUD_FinalPotential.Value < ((double)NUD_PulseLevel.Value)) sign = -1;
                    }

                    NUD_AmpStep.Minimum = -1000;
                    NUD_AmpStep.Maximum = 1000;
                    NUD_ScanRate.Minimum = -10000000;
                    NUD_ScanRate.Maximum = 10000000;
                    NUD_ScanRate.Value = (decimal)(sign * Math.Abs((double)NUD_ScanRate.Value));

                    if (sign < 0)
                    {
                        NUD_AmpStep.Minimum = -1000;
                        NUD_AmpStep.Maximum = 0;
                        NUD_ScanRate.Minimum = -10000000;
                        NUD_ScanRate.Maximum = 0;
                    }
                    else
                    {
                        NUD_AmpStep.Minimum = 0;
                        NUD_AmpStep.Maximum = 1000;
                        NUD_ScanRate.Minimum = 0;
                        NUD_ScanRate.Maximum = 10000000;
                    }

                    return;
                }
                n++;

                if (n > (int)NUD_pulsenumber.Maximum)
                {
                    MessageBox.Show("The amplitude step is too small. The number of pulse can not be more than 9999.");
                }

                if (n == 0)
                {
                    MessageBox.Show("The amplitude step is too large. The number of pulse can not be less than 1.");
                }
                else
                {
                    this.NUD_pulsenumber.ValueChanged -= new System.EventHandler(this.NUD_pulsenumber_ValueChanged);
                    NUD_pulsenumber.Value = n;
                    this.NUD_pulsenumber.ValueChanged += new System.EventHandler(this.NUD_pulsenumber_ValueChanged);
                }
            }

            if (CBVoltammetryMode.SelectedIndex == 1 || CBVoltammetryMode.SelectedIndex == 2)
            {
                NUD_LevelStep.Value = NUD_AmpStep.Value;
            }


            UpdatePulse();
        }

        private void NUD_ScanRate_ValueChanged(object sender, EventArgs e)
        {
            double AmpStep = (double)NUD_PulsePeriod.Value / 1000.0 * (double)NUD_ScanRate.Value;
            if (AmpStep < (double)NUD_AmpStep.Minimum) AmpStep = (double)NUD_AmpStep.Minimum;
            if (AmpStep > (double)NUD_AmpStep.Maximum) AmpStep = (double)NUD_AmpStep.Maximum;
            NUD_AmpStep.Value = (decimal)AmpStep;
            CheckPulse();
        }

        private void NUD_Frequency_ValueChanged(object sender, EventArgs e)
        {
            NUD_TotalPeriod.Value = (decimal)((1000.0 / (double)NUD_Frequency.Value));
            
            //NUD_Frequency.Value = (decimal)(1000.0 / (double)NUD_TotalPeriod.Value);
            UpdatePulse();
        }

        private void NUD_Esw_ValueChanged(object sender, EventArgs e)
        {
            double newamp = 2 * ((double)NUD_Esw.Value);
            NUD_PulseAmp.Value = (decimal)(newamp);
        }
    }
}





















