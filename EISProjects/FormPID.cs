using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace EISProjects
{
    public partial class FormPID : Form
    {
        double previous_error = 0;
        double integral = 0;
        double derivative = 0;
        double error = 0;
        double setpoint = 0;
        double measured_value = 0;
        int dt = 200;
        double Kp = 5.0;
        double Ki = 3.0;
        double Kd = 0;
        double output;
        double Oldoutput;
        public static string ReadToChar = "\r";
        public static string WriteReadToChar = "\n";
        int idcselect=1;
        int IMLP = 0;
        bool isTuningTimerCompeted = true;
        double Time = 0.0;
        int method = 0;
        double dV = 0.1;
        double MixingPercent = 50.0;
        int ivltSimpleFinder;
        bool isFirstStep;
        double TheVoltageisset = 0;
        double TheCurrentisset = 0;
        double TotalTime = 0;

        public FormPID()
        {
            InitializeComponent();
            if (Form1.BoardType > 1)
            {
                label7.Visible = false;
                comboBox1.Visible = false;
                groupBox5.Visible = false;
                groupBox6.Visible = false;
                groupBox7.Visible = false;
                groupBox8.Visible = false;
            }

            if (Form1.isRunStart && Form1.AllSessions[EIS.RunningSession].isOCP && Form1.AllSessions[EIS.RunningSession].isOCPAutoStart)
            {
                button1_Click(null,null);
                TotalTime = 0;
                AutoContinueTimer.Start();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (EIS.Connected)
            {
                TheVoltageisset = 0;
                TheCurrentisset = 0;

                ClearPlot(chart1);
                ClearPlot(chart2);

                chart1.ChartAreas[0].AxisX.IsLogarithmic = false;
                chart2.ChartAreas[0].AxisX.IsLogarithmic = false;

                AddSeries(chart1, "V(t)", "t", "V(t)", Color.Blue);
                AddSeries(chart2, "I(t)", "t", "I(t)", Color.Red);

                chart1.Series[0].ChartType = SeriesChartType.Line;
                chart2.Series[0].ChartType = SeriesChartType.Line;

                Time = 0;
                isFirstStep = true;
                previous_error = 0;
                integral = 0;
                setpoint = 0;
                output = 0.5;
                Oldoutput = output;
                isTuningTimerCompeted = true;
                IMLP = 0;
                TuningTimer.Start();
                button1.Enabled = false;
            }
            else
            {
                MessageBox.Show("Application is not connected to device ...");
            }
        }

        private void StopRun()
        {            
            TuningTimer.Stop();
            MessageBox.Show("Run is Stoped ...");
        }

        private void TuningTimer_Tick(object sender, EventArgs e)
        {
            if (dt < 1) dt = 1;
            TuningTimer.Interval = dt;
            string ans;
            TheVoltageisset = 0;
            TheCurrentisset = 0;

            if (isTuningTimerCompeted)
            {
                isTuningTimerCompeted = false;

                int zeroset = Form1.Settings.Zeroset0;

                try
                {
                    Form1.Port.DiscardOutBuffer(); //Clear Buffer
                    Form1.Port.DiscardInBuffer(); //Clear Buffer
                    Form1.Port.Write("zeroset " + zeroset.ToString() + WriteReadToChar);
                    Thread.SpinWait(2000 * 1000);
                    ans = Form1.Port.ReadTo(ReadToChar);
                    if (ans == "OK") { }
                }
                catch { }



                try
                {
                    Form1.Port.DiscardOutBuffer(); //Clear Buffer
                    Form1.Port.DiscardInBuffer(); //Clear Buffer
                    Form1.Port.Write("idcmlp " + IMLP.ToString() + WriteReadToChar);
                    Thread.SpinWait(2000 * 1000);
                    ans = Form1.Port.ReadTo(ReadToChar);
                    Form1.Port.DiscardOutBuffer(); //Clear Buffer
                    Form1.Port.DiscardInBuffer(); //Clear Buffer
                    if (ans == "OK")
                    {
                        //SetLabel(ref Label_Imlp, 0);
                    }
                    else
                        StopRun();
                }
                catch { }



                try
                {
                    Form1.Port.DiscardOutBuffer(); //Clear Buffer
                    Form1.Port.DiscardInBuffer(); //Clear Buffer
                    Form1.Port.Write("vdcmlp 0" + WriteReadToChar);
                    Thread.SpinWait(2000 * 1000);
                    ans = Form1.Port.ReadTo(ReadToChar);
                    Form1.Port.DiscardOutBuffer(); //Clear Buffer
                    Form1.Port.DiscardInBuffer(); //Clear Buffer
                    if (ans == "OK")
                    {
                        //SetLabel(ref Label_Vmlp, 0);
                    }
                    else
                        StopRun();
                }
                catch { }

                Form1.CurrentDigitalEIS_VAC_RMS = 0.0;
                int iCurrentDigitalEIS_VAC_RMS = Form1.SetACVoltageConvert(Form1.CurrentDigitalEIS_VAC_RMS, 0);
                try
                {
                    Form1.Port.DiscardOutBuffer(); //Clear Buffer
                    Form1.Port.DiscardInBuffer(); //Clear Buffer
                    Form1.Port.Write("acset " + iCurrentDigitalEIS_VAC_RMS.ToString() + WriteReadToChar);
                    Thread.SpinWait(2000 * 1000);
                    ans = Form1.Port.ReadTo(ReadToChar);
                    Form1.Port.DiscardOutBuffer(); //Clear Buffer
                    Form1.Port.DiscardInBuffer(); //Clear Buffer
                    if (ans == "OK")
                    {
                        //SetLabel(ref iLabel_vac, iCurrentDigitalEIS_VAC_RMS);
                        //SetLabel(ref Label_vac, CurrentDigitalEIS_VAC_RMS);
                    }
                    else
                        StopRun();
                }
                catch { }

                Form1.Port.DiscardOutBuffer(); //Clear Buffer
                Form1.Port.DiscardInBuffer(); //Clear Buffer
                Form1.Port.Write("setselect 0" + WriteReadToChar);
                Thread.SpinWait(2000 * 1000);
                ans = Form1.Port.ReadTo(ReadToChar);
                Form1.Port.DiscardOutBuffer(); //Clear Buffer
                Form1.Port.DiscardInBuffer(); //Clear Buffer
                if (ans == "OK")
                {
                    //SetLabel(ref Label_VSelect, AllSessions[EIS.RunningSession].EISVoltageRangeMode);
                }
                else
                    StopRun();

                try
                {
                    Form1.Port.DiscardOutBuffer(); //Clear Buffer
                    Form1.Port.DiscardInBuffer(); //Clear Buffer
                    Form1.Port.Write("idcselect " + idcselect.ToString() + WriteReadToChar);
                    Thread.SpinWait(2000 * 1000);
                    ans = Form1.Port.ReadTo(ReadToChar);
                    Form1.Port.DiscardOutBuffer(); //Clear Buffer
                    Form1.Port.DiscardInBuffer(); //Clear Buffer
                    if (ans == "OK")
                    {
                        //SetLabel(ref Label_ISelect, AllSessions[EIS.RunningSession].EISDCCurrentRangeMode);
                    }
                    else
                        StopRun();
                }
                catch
                {
                    StopRun();
                }

                try
                {
                    double vlt = output;
                    int ivlt = Form1.SetDCVConvert(vlt, 0,0,0);
                    if (method == 0 && isFirstStep)
                    {
                        ivltSimpleFinder = ivlt;
                        isFirstStep = false;
                    }
                    else
                    {
                        ivlt = ivltSimpleFinder;
                    }
                    Form1.Port.DiscardOutBuffer(); //Clear Buffer
                    Form1.Port.DiscardInBuffer(); //Clear Buffer
                    Form1.Port.Write("ivset " + ivlt.ToString() + ReadToChar);
                    Form1.Port.Write(WriteReadToChar);
                    Thread.SpinWait(2000 * 1000);
                    //SetLabel(ref iLabel_vdc, ivlt);
                    //SetLabel(ref Label_vdc, vlt);

                    try
                    {
                        byte[] AllBytes1 = new byte[4];
                        byte[] AllBytes2 = new byte[4];
                        int word;

                        AllBytes1[0] = (byte)Form1.Port.ReadByte();
                        AllBytes1[1] = (byte)Form1.Port.ReadByte();
                        AllBytes1[2] = (byte)Form1.Port.ReadByte();
                        AllBytes1[3] = (byte)Form1.Port.ReadByte();
                        AllBytes2[0] = (byte)Form1.Port.ReadByte();
                        AllBytes2[1] = (byte)Form1.Port.ReadByte();
                        AllBytes2[2] = (byte)Form1.Port.ReadByte();
                        AllBytes2[3] = (byte)Form1.Port.ReadByte();

                        int nData = Form1.IVnData;
                        word = AllBytes1[0] | (AllBytes1[1] << 8) | (AllBytes1[2] << 16) | (AllBytes1[3] << 24);
                        double Vmean = (double)word / (double)nData;

                        word = AllBytes2[0] | (AllBytes2[1] << 8) | (AllBytes2[2] << 16) | (AllBytes2[3] << 24);
                        double Imean = (double)word / (double)nData;

                        //FormEISDScope.UpdateIVDiagram(IVnDataTotal, IVtDataTotal, IVVDataTotal, IVIDataTotal);

                        TheVoltageisset = Form1.GetDCVConvert(Vmean, 0, 0);
                        if (Form1.AllSessions[EIS.RunningSession].RelRef) TheVoltageisset = -TheVoltageisset;
                        TheCurrentisset = Form1.GetDCIConvert(Imean, idcselect, IMLP);

                        measured_value = TheCurrentisset;
                    }
                    catch { }
                }
                catch
                {
                }

                AddPoint(chart1, 0, Time, TheVoltageisset);
                AddPoint(chart2, 0, Time, TheCurrentisset);
                Time = Time + (double)dt;

                if (Form1.BoardType < 2)
                {
                    if (method == 0)
                    {
                        Oldoutput = output;
                        double TheVoltageissetplusdV = 0.0;
                        double TheCurrentissetplusdV = 0.0;

                        try
                        {
                            //double vlt = output + dV;
                            //int ivlt = Form1.SetDCVConvert(vlt, 0);
                            int ivlt = ivltSimpleFinder;

                            Form1.Port.DiscardOutBuffer(); //Clear Buffer
                            Form1.Port.DiscardInBuffer(); //Clear Buffer
                            Form1.Port.Write("ivset " + ivlt.ToString() + ReadToChar);
                            Form1.Port.Write(WriteReadToChar);
                            Thread.SpinWait(2000 * 1000);
                            //SetLabel(ref iLabel_vdc, ivlt);
                            //SetLabel(ref Label_vdc, vlt);

                            try
                            {
                                byte[] AllBytes1 = new byte[4];
                                byte[] AllBytes2 = new byte[4];
                                int word;

                                AllBytes1[0] = (byte)Form1.Port.ReadByte();
                                AllBytes1[1] = (byte)Form1.Port.ReadByte();
                                AllBytes1[2] = (byte)Form1.Port.ReadByte();
                                AllBytes1[3] = (byte)Form1.Port.ReadByte();
                                AllBytes2[0] = (byte)Form1.Port.ReadByte();
                                AllBytes2[1] = (byte)Form1.Port.ReadByte();
                                AllBytes2[2] = (byte)Form1.Port.ReadByte();
                                AllBytes2[3] = (byte)Form1.Port.ReadByte();

                                int nData = Form1.IVnData;
                                word = AllBytes1[0] | (AllBytes1[1] << 8) | (AllBytes1[2] << 16) | (AllBytes1[3] << 24);
                                double Vmean = (double)word / (double)nData;

                                word = AllBytes2[0] | (AllBytes2[1] << 8) | (AllBytes2[2] << 16) | (AllBytes2[3] << 24);
                                double Imean = (double)word / (double)nData;

                                //FormEISDScope.UpdateIVDiagram(IVnDataTotal, IVtDataTotal, IVVDataTotal, IVIDataTotal);

                                TheVoltageissetplusdV = Form1.GetDCVConvert(Vmean, 0, 0);
                                if (Form1.AllSessions[EIS.RunningSession].RelRef) TheVoltageissetplusdV = -TheVoltageissetplusdV;
                                TheCurrentissetplusdV = Form1.GetDCIConvert(Imean, idcselect, IMLP);

                                //measured_value = TheCurrentisset;
                            }
                            catch { }
                        }
                        catch
                        {
                        }

                        if (TheCurrentisset > 0) ivltSimpleFinder = ivltSimpleFinder + 1;
                        if (TheCurrentisset < 0) ivltSimpleFinder = ivltSimpleFinder - 1;


                        //ivltSimpleFinder = ivltSimpleFinder - Math.Sign(TheCurrentisset / fPrime);
                        output = Form1.GetDCVConvert(ivltSimpleFinder, 0, 0);
                        if (Form1.AllSessions[EIS.RunningSession].RelRef) output = -output;
                    }
                    else if (method == 1)
                    {
                        error = setpoint - measured_value;
                        integral = integral + error * (double)dt;
                        derivative = (error - previous_error) / (double)dt;
                        Oldoutput = output;
                        double newoutput = Kp * error + Ki * integral + Kd * derivative;
                        output = 0.8 * Oldoutput + 0.2 * newoutput;
                        //if (output == Oldoutput) output = 0.1;
                        previous_error = error;
                    }
                    else if (method == 2)
                    {
                        Oldoutput = output;
                        double TheVoltageissetplusdV = 0.0;
                        double TheCurrentissetplusdV = 0.0;

                        try
                        {
                            double vlt = output + dV;
                            int ivlt = Form1.SetDCVConvert(vlt, 0,0,0);
                            Form1.Port.DiscardOutBuffer(); //Clear Buffer
                            Form1.Port.DiscardInBuffer(); //Clear Buffer
                            Form1.Port.Write("ivset " + ivlt.ToString() + ReadToChar);
                            Form1.Port.Write(WriteReadToChar);
                            Thread.SpinWait(2000 * 1000);
                            //SetLabel(ref iLabel_vdc, ivlt);
                            //SetLabel(ref Label_vdc, vlt);

                            try
                            {
                                byte[] AllBytes1 = new byte[4];
                                byte[] AllBytes2 = new byte[4];
                                int word;

                                AllBytes1[0] = (byte)Form1.Port.ReadByte();
                                AllBytes1[1] = (byte)Form1.Port.ReadByte();
                                AllBytes1[2] = (byte)Form1.Port.ReadByte();
                                AllBytes1[3] = (byte)Form1.Port.ReadByte();
                                AllBytes2[0] = (byte)Form1.Port.ReadByte();
                                AllBytes2[1] = (byte)Form1.Port.ReadByte();
                                AllBytes2[2] = (byte)Form1.Port.ReadByte();
                                AllBytes2[3] = (byte)Form1.Port.ReadByte();

                                int nData = Form1.IVnData;
                                word = AllBytes1[0] | (AllBytes1[1] << 8) | (AllBytes1[2] << 16) | (AllBytes1[3] << 24);
                                double Vmean = (double)word / (double)nData;

                                word = AllBytes2[0] | (AllBytes2[1] << 8) | (AllBytes2[2] << 16) | (AllBytes2[3] << 24);
                                double Imean = (double)word / (double)nData;

                                //FormEISDScope.UpdateIVDiagram(IVnDataTotal, IVtDataTotal, IVVDataTotal, IVIDataTotal);

                                TheVoltageissetplusdV = Form1.GetDCVConvert(Vmean, 0, 0);
                                if (Form1.AllSessions[EIS.RunningSession].RelRef) TheVoltageissetplusdV = -TheVoltageissetplusdV;
                                TheCurrentissetplusdV = Form1.GetDCIConvert(Imean, idcselect, IMLP);

                                //measured_value = TheCurrentisset;
                            }
                            catch { }
                        }
                        catch
                        {
                        }

                        double ddV = TheVoltageissetplusdV - TheVoltageisset;
                        if (Math.Abs(ddV) < 0.0000000001) ddV = 0.0000000001;
                        double ddI = TheCurrentissetplusdV - TheCurrentisset;
                        double fPrime = ddI / ddV;
                        if (Math.Abs(fPrime) < 0.0000000001) fPrime = 0.0000000001;
                        double newoutput = TheVoltageisset - TheCurrentisset / fPrime;
                        output = (1.0 - MixingPercent / 100.0) * Oldoutput + MixingPercent / 100.0 * newoutput;
                    }
                }
                
                isTuningTimerCompeted = true;
            }
        }

        private void CBidcselect_SelectedIndexChanged(object sender, EventArgs e)
        {
            idcselect = CBidcselect.SelectedIndex;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1.EndorseOCTSugestedV = TheVoltageisset;
            Form1.isEndorseOCTOk = false;
            FormEndorseOCP fe = new FormEndorseOCP();
            fe.ShowDialog();

            if (Form1.isEndorseOCTOk)
            {
                Form1.isOCTContinueRequested = true;
                TuningTimer.Stop();
                Form1.SugestedVOCP = Form1.EndorseOCTSugestedV;
                this.Dispose();
            }
        }

        private void FormPID_FormClosed(object sender, FormClosedEventArgs e)
        {
            TuningTimer.Stop();
            Form1.isformPID = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DigitTextChange(ref Kp, textBox1, -10000, 10000);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            DigitTextChange(ref Ki, textBox2 , -10000, 10000);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            DigitTextChange(ref Kd, textBox3, -10000, 10000);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            IntDigitTextChange(ref dt, textBox4, 0, 60000);
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
        
        private void IntDigitTextChange(ref int digit, TextBox tb, int min, int max)
        {
            try
            {
                digit = Convert.ToInt32(tb.Text);
                if (digit < min) digit = min;
                if (digit > max) digit = max;
            }
            catch
            {
                tb.Text = digit.ToString();
                MessageBox.Show("Please type integer only ...");
            }
        }

        private void AddPoint(Chart chart, int SeriesIndex, double x, double y)
        {
            chart.Series[SeriesIndex].Points.AddXY(x, y);
        }

        private void AddSeries(Chart chart, string legend, string xAxis, string yAxis, Color color)
        {
            chart.Series.Add(legend);
            int Index = -1;
            foreach (Series S in chart.Series) Index++;
            chart.Series[Index].ChartType = SeriesChartType.Line;
            chart.Series[Index].Color = color;
            chart.Series[Index].LegendText = legend;
            chart.ChartAreas[0].Axes[0].Title = xAxis;
            chart.ChartAreas[0].Axes[1].Title = yAxis;
        }

        private void ClearPlot(Chart chart)
        {
            chart.Series.Clear();
        }

        private void FormPID_Shown(object sender, EventArgs e)
        {
            idcselect = 1;
            CBidcselect.SelectedIndex = idcselect;
            textBox1.Text = Kp.ToString();
            textBox2.Text = Ki.ToString();
            textBox3.Text = Kd.ToString();
            textBox4.Text = dt.ToString();
            textBox5.Text = dV.ToString();
            textBox7.Text = MixingPercent.ToString();
            
            comboBox1.SelectedIndex = 0;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox1.Location = new Point(7, 129);
            groupBox2.Location = new Point(7, 129);
            groupBox3.Location = new Point(7, 129);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart2.Series[0].Points.Clear();
            Time = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TuningTimer.Stop();
            button1_Click(null, null);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1.isOCTContinueRequested = false;
            TuningTimer.Stop();
            this.Dispose();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            method = comboBox1.SelectedIndex;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            if (method == 1)
                groupBox1.Visible = true;
            else if (method == 2)
                groupBox2.Visible = true;
            else if (method == 3)
                groupBox3.Visible = true;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            DigitTextChange(ref dV, textBox5, -10, 10);
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            DigitTextChange(ref MixingPercent, textBox7, 0, 100);
        }

        private void AutoContinueTimer_Tick(object sender, EventArgs e)
        {
            TotalTime = TotalTime + AutoContinueTimer.Interval;
            if (TotalTime > 10000) button2_Click(null, null);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Data files (*.dat)|*.dat";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                int nData = chart1.Series[0].Points.Count;
                int nData2 = chart2.Series[0].Points.Count;
                if (nData > nData2) nData = nData2;
                ExportData(nData, chart1.Series[0].Points, chart2.Series[0].Points, saveFileDialog1.FileName);
            }
        }


        private void ExportData(int nData, DataPointCollection p1, DataPointCollection p2, string Path)
        {
            try
            {
                StreamWriter FileProtocol = new StreamWriter(Path);

                for (int i = 0; i < nData; i++)
                {
                    FileProtocol.Write(p1[i].XValue.ToString() + "   " + p1[i].YValues[0].ToString().ToString() + "   " + p2[i].YValues[0].ToString().ToString() + "\n");
                }

                FileProtocol.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error in writing to file ...");
            }
        }



    }
}
