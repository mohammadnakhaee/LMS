using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.IO.Ports;
using System.Collections;

namespace EISProjects
{
    public partial class FormEISDigital : Form
    {
        public static double[] Ia;
        public static double[] Va;
        public static int index;
        public static Queue<double> V;// = new Queue();
        public static Queue<double> I;
        public FormEISDigital()
        {
            InitializeComponent();
            //Form1 form1 = 
            V = new Queue<double>(100);
            I = new Queue<double>(100);
            Va = new double[100];
            Ia = new double[100];
            int newHeit = (int)(this.Height / 2) - 20;
            GBVoltage.Height = newHeit;
            GBCurrent.Height = newHeit;
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
            //chart.Series[Index].LegendText = legend;
            chart.ChartAreas[0].Axes[0].Title = xAxis;
            chart.ChartAreas[0].Axes[1].Title = yAxis;
        }

        private void ClearPlot(Chart chart)
        {
            chart.Series.Clear();
        }

        private void PlotEISIV_t(int npoints, Chart chart1, Chart chart2, double[] xArray, double[] FittedxArray, double[] ReZArray, double[] ImZArray, double[] FittedReZArray, double[] FittedImZArray
            , int nFirstZone, double[] FirstZonetArray, double[] FirstZoneIntVData, double[] FirstZoneIntIData, double V_Error, double I_Error)
        {
            ClearPlot(chart1);
            ClearPlot(chart2);

            chart1.ChartAreas[0].AxisX.IsLogarithmic = false;
            chart2.ChartAreas[0].AxisX.IsLogarithmic = false;

            AddSeries(chart1, "Voltage data", "t", "V(t)", Color.Green);
            AddSeries(chart2, "Current data", "t", "I(t)", Color.Green);
            AddSeries(chart1, "V(t)", "t", "V(t)", V_Error < 10 ? Color.Blue : Color.DarkRed);
            AddSeries(chart2, "I(t)", "t", "I(t)", I_Error < 10 ? Color.Blue : Color.DarkRed);
            //AddSeries(chart1, "first zone V(t)", "t", "V(t)", Color.Black);
            //AddSeries(chart2, "first zone I(t)", "t", "I(t)", Color.Black);

            chart1.Series[0].ChartType = SeriesChartType.Point;
            chart1.Series[0].MarkerStyle = MarkerStyle.Circle;
            chart2.Series[0].ChartType = SeriesChartType.Point;
            chart2.Series[0].MarkerStyle = MarkerStyle.Circle;

            chart1.Series[1].ChartType = SeriesChartType.Line;
            chart2.Series[1].ChartType = SeriesChartType.Line;

            /*chart1.Series[2].ChartType = SeriesChartType.Point;
            chart1.Series[2].MarkerStyle = MarkerStyle.Star6;
            chart2.Series[2].ChartType = SeriesChartType.Point;
            chart2.Series[2].MarkerStyle = MarkerStyle.Star6;*/

            for (int i = 0; i < npoints; i++)
            {
                AddPoint(chart1, 0, xArray[i], ReZArray[i]);
                AddPoint(chart2, 0, xArray[i], ImZArray[i]);
                AddPoint(chart1, 1, FittedxArray[i], FittedReZArray[i]);
                AddPoint(chart2, 1, FittedxArray[i], FittedImZArray[i]);
            }

            /*for (int i = 0; i < nFirstZone; i++)
            {
                AddPoint(chart1, 2, FirstZonetArray[i], FirstZoneIntVData[i]);
                AddPoint(chart2, 2, FirstZonetArray[i], FirstZoneIntIData[i]);
            }*/

        }

        private void PlotIVIV_t(int npoints, Chart chart1, Chart chart2, double[] xArray, double[] ReZArray, double[] ImZArray)
        {
            ClearPlot(chart1);
            ClearPlot(chart2);

            chart1.ChartAreas[0].AxisX.IsLogarithmic = false;
            chart2.ChartAreas[0].AxisX.IsLogarithmic = false;

            AddSeries(chart1, "V(t)", "t", "V(t)", Color.Blue);
            AddSeries(chart2, "I(t)", "t", "I(t)", Color.Red);

            chart1.Series[0].ChartType = SeriesChartType.Line;
            chart2.Series[0].ChartType = SeriesChartType.Line;

            for (int i = 0; i < npoints; i++)
            {
                AddPoint(chart1, 0, xArray[i], ReZArray[i]);
                AddPoint(chart2, 0, xArray[i], ImZArray[i]);
            }
        }

        public void UpdateIVDiagram(int nData, double[] IVtDataTotal, double[] IVVDataTotal, double[] IVIDataTotal)
        {
            PlotIVIV_t(nData, chart1, chart2, IVtDataTotal, IVVDataTotal, IVIDataTotal);
        }

        public void UpdateEISDiagram(int nData, double[] tArray, double[] FittedtArray, double[] VArray, double[] IArray, double[] FittedVArray, double[] FittedIArray
            ,int nFirstZone , double[] FirstZonetArray, double[] FirstZoneIntVData, double[] FirstZoneIntIData,double V_Error,double I_Error)
        {
            PlotEISIV_t(nData, chart1, chart2, tArray, FittedtArray, VArray, IArray, FittedVArray, FittedIArray, nFirstZone, FirstZonetArray, FirstZoneIntVData, FirstZoneIntIData,  V_Error,  I_Error);
            chart1.Update();
            chart2.Update();
        }

        private void FormEISDigital_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            Form1.isFormEISDScope = false;
            //if (flowLayoutPanel1.Visible == false) return;
            try
            {
                Form1.Port.Write(";");
                Form1.Port.DataReceived -= new SerialDataReceivedEventHandler(DataReceivedHandler);
               

            }
            catch (Exception ee) { }
            System.Threading.Thread.Sleep(50);
            Form1.Port.DiscardInBuffer();
            Form1.Port.DiscardOutBuffer();
            try
            {
            
            Form1.Port.DiscardInBuffer();
            Form1.Port.WriteLine("idcselect " + status.Default.iselect.ToString());
            Form1.Port.ReadLine();
            System.Threading.Thread.Sleep(50);
            Form1.Port.DiscardInBuffer();
            Form1.Port.WriteLine("vdcselect " + status.Default.vselect.ToString());
            Form1.Port.ReadLine();
            System.Threading.Thread.Sleep(50);
            Form1.Port.DiscardInBuffer();
            Form1.Port.WriteLine("idcfilter " + status.Default.ifilter.ToString());
            Form1.Port.ReadLine();
            System.Threading.Thread.Sleep(50);
            Form1.Port.DiscardInBuffer();
            Form1.Port.WriteLine("vfilter " + status.Default.vfilter.ToString());
            Form1.Port.ReadLine();
            System.Threading.Thread.Sleep(50);
            Form1.Port.DiscardInBuffer();
            Form1.Port.WriteLine("sampleon " + (status.Default.probe ? "1" : "0"));
            Form1.Port.ReadLine();
            System.Threading.Thread.Sleep(50);
            Form1.Port.DiscardInBuffer();
            Form1.Port.WriteLine("dummyon " + (status.Default.dummy ? "1" : "0"));
            Form1.Port.ReadLine();
            System.Threading.Thread.Sleep(50);
            Form1.Port.DiscardInBuffer();
            Form1.Port.WriteLine("notch " + (status.Default.notch ? "1" : "0"));
            Form1.Port.ReadLine();
            System.Threading.Thread.Sleep(50);
            Form1.Port.DiscardInBuffer();
            Form1.Port.WriteLine("earth " + (status.Default.floated ? "1" : "0"));
            Form1.Port.ReadLine();
            System.Threading.Thread.Sleep(50);
            Form1.Port.DiscardInBuffer();
            Form1.Port.WriteLine("clmauto " + (status.Default.clm_auto ? "1" : "0"));
            Form1.Port.ReadLine();
            System.Threading.Thread.Sleep(50);
            Form1.Port.DiscardInBuffer();
            Form1.Port.WriteLine("iIs " + status.Default.iIs.ToString());
            Form1.Port.ReadLine();
            System.Threading.Thread.Sleep(50);
            Form1.Port.DiscardInBuffer();
            if (status.Default.AC)
                Form1.Port.WriteLine("ACpreget");
            else
                Form1.Port.WriteLine("DCpreget");
            Form1.Port.ReadLine();

            System.Threading.Thread.Sleep(50);
            Form1.Port.DiscardInBuffer();
            Form1.Port.WriteLine("ivset " + status.Default.dc_dac.ToString());
                Form1.Port.ReadByte(); Form1.Port.ReadByte(); Form1.Port.ReadByte(); Form1.Port.ReadByte();
                Form1.Port.ReadByte(); Form1.Port.ReadByte(); Form1.Port.ReadByte(); Form1.Port.ReadByte();
                System.Threading.Thread.Sleep(50);
            Form1.Port.DiscardInBuffer();
            Form1.Port.WriteLine("vacdac " + status.Default.vnull_dac.ToString());
            Form1.Port.ReadLine();
            System.Threading.Thread.Sleep(50);
            Form1.Port.DiscardInBuffer();
            Form1.Port.WriteLine("iacdac " + status.Default.inull_dac.ToString());
            Form1.Port.ReadLine();

     
             
            Form1.Port.DataReceived -= new SerialDataReceivedEventHandler(DataReceivedHandler);
            Form1.Port.Write(";");
           
            
            
            }
            catch
            { }
            
        }

        private void FormEISDigital_Resize(object sender, EventArgs e)
        {
            int newHeit = (int)(this.Height / 2) - 20;
            GBVoltage.Height = newHeit;
            GBCurrent.Height = newHeit;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearPlot(chart1);

            chart1.ChartAreas[0].AxisX.IsLogarithmic = false;

            AddSeries(chart1, "V(t)", "t", "V(t)", Color.Blue);

            chart1.Series[0].ChartType = SeriesChartType.Line;

            for (int i = 0; i < 100; i++)
            {
                AddPoint(chart1, 0, i, i);
                if (i > 50) chart1.Series[0].Points[chart1.Series[0].Points.Count-1].Color = Color.Red;
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearPlot(chart1);
            ClearPlot(chart2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "start")
            {
                button2.Text = "stop";
                if(chart1.Series.IsUniqueName("V_live"))
                AddSeries(chart1, "V_live", "Num", "volt", Color.DarkBlue);
                if (chart1.Series.IsUniqueName("I_live"))
                AddSeries(chart2, "I_live", "Num", "Amp ", Color.DarkBlue);
                chart1.ChartAreas[0].AxisY.Minimum = -2045;
                chart2.ChartAreas[0].AxisY.Minimum = -2045;
                chart1.ChartAreas[0].AxisY.Maximum = 2045;
                chart2.ChartAreas[0].AxisY.Maximum = 2045;
                for (int i = 0; i < 100; i++)
                {
                  //  V.Enqueue(0);
                  //  I.Enqueue(0);
                    chart1.Series[0].Points.AddXY(i, 0);
                    chart2.Series[0].Points.AddXY(i, 0);
                }
                timer1.Start();
                try
                {
                 
                    Form1.Port.DiscardInBuffer();
                    Form1.Port.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                    Form1.Port.WriteLine("scope 799");
                }
                catch(Exception ee) { }
            }
            else
            {
                 
                button2.Text = "start";
                timer1.Stop();
                ClearPlot(chart1);
                ClearPlot(chart2);
                try
                {
                Form1.Port.DataReceived -= new SerialDataReceivedEventHandler(DataReceivedHandler);
                Form1.Port.Write(";");
                    
            }
                catch (Exception ee) { }
                index = 0;
        }
        }
        private void DataReceivedHandler(object sender, EventArgs e)
        {
            Int16 v, i;
            try
            {
                SerialPort p = (SerialPort)sender;
                v = (Int16)(((UInt16)p.ReadByte()) | (((UInt16)p.ReadByte()) << 8));
                i = (Int16)(((byte)p.ReadByte()) | (((byte)p.ReadByte()) << 8));
                Va[index] = v;
                Ia[index] = i;
                index++;
                if (index >= 100) index = 0;
                // V.Dequeue();
                //  I.Dequeue();
                // V.Enqueue(v);
                //I.Enqueue(i);
                //for (int i = 0; i < 100; i++)
                // int n = 0, pp;
                if (index == 0)
                    for (int n = 0; n < 100; n++)
                    {
                        // pp = index + n + 1;
                        //  if (pp >= 100) pp -= 100;
                        chart1.Series[0].Points[n].YValues[0] = Va[n];
                        chart2.Series[0].Points[n].YValues[0] = Ia[n];
                    }
            }
            catch 
            { }
            //backgroundWorker1.RunWorkerAsync();
            //chart1.Series.Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          /*  int n = 0,p;
           for(n=0;n<100;n++)
            {
                p = index + n +1;
                if (p >= 100) p -= 100;
                chart1.Series[0].Points[n].YValues[0] = Ia[p];

            }*/
            chart1.Series.Invalidate();
            chart1.Update();
            chart2.Series.Invalidate();
            chart2.Update();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           // chart1.Series.Invalidate();
            //chart1.Update();
        }

        private void refresh(object sender, EventArgs e)
        {
            if (button2.Text == "stop")
                button2_Click(sender, null);
            try
            {
                Form1.Port.DataReceived -= new SerialDataReceivedEventHandler(DataReceivedHandler);
                Form1.Port.Write(";");

            }
            catch (Exception ee) { }
            System.Threading.Thread.Sleep(50);
            Form1.Port.DiscardInBuffer();
            Form1.Port.DiscardOutBuffer();
            try
            {
                Form1.Port.DiscardInBuffer();
                if (sender.Equals(comboBox1))
                {
                    
                    Form1.Port.WriteLine("idcselect " + comboBox1.SelectedIndex.ToString());
                    Form1.Port.ReadLine();
                }
                if (sender.Equals(comboBox3))
                {
                    Form1.Port.WriteLine("idcfilter " + comboBox3.SelectedIndex.ToString());
                    Form1.Port.ReadLine();
                }
                if (sender.Equals(comboBox4))
                {
                    Form1.Port.WriteLine("vfilter " + comboBox4.SelectedIndex.ToString());
                    Form1.Port.ReadLine();
                }
                if (sender.Equals(checkBox1))
                {
                    Form1.Port.WriteLine("sampleon " + (checkBox1.Checked ? "1" : "0"));
                    Form1.Port.ReadLine();
                }
                if (sender.Equals(checkBox2))
                {
                    Form1.Port.WriteLine("dummyon " + (checkBox2.Checked ? "1" : "0"));
                    Form1.Port.ReadLine();
                }
                if (sender.Equals(comboBox2))
                {
                    Form1.Port.WriteLine("vdcselect " + comboBox2.SelectedIndex.ToString());
                    Form1.Port.ReadLine();
                }
                if (sender.Equals(comboBox_iIs))
                {
                    Form1.Port.WriteLine("iIs " + comboBox_iIs.SelectedIndex.ToString());
                    Form1.Port.ReadLine();
                }
                if (sender.Equals(checkBox_notch))
                {
                    Form1.Port.WriteLine("notch " + (checkBox_notch.Checked ? "1" : "0"));
                    Form1.Port.ReadLine();
                }
                if (sender.Equals(checkBox_float))
                {
                    Form1.Port.WriteLine("earth " + (checkBox_float.Checked ? "1" : "0"));
                    Form1.Port.ReadLine();
                }
                if (sender.Equals(checkBox_clm))
                {
                    Form1.Port.WriteLine("clmauto " + (checkBox_clm.Checked ? "1" : "0"));
                    Form1.Port.ReadLine();
                }
                if (sender.Equals(checkBox_AC))
                {
                    if(checkBox_AC.Checked)
                    Form1.Port.WriteLine("ACpreget");
                    else
                    Form1.Port.WriteLine("DCpreget");
                    Form1.Port.ReadLine();
                }
                if (sender.Equals(numericUpDown_dac))
                {
                    Form1.Port.WriteLine("ivset " + (2047 + 20.47 * (double)numericUpDown_dac.Value));
                    System.Threading.Thread.Sleep(50);
                    Form1.Port.ReadByte(); Form1.Port.ReadByte(); Form1.Port.ReadByte(); Form1.Port.ReadByte();
                    Form1.Port.ReadByte(); Form1.Port.ReadByte(); Form1.Port.ReadByte(); Form1.Port.ReadByte();
                }
                if (sender.Equals(numericUpDown_vacdac))
                {
                    Form1.Port.WriteLine("vacdac " + (2047 + 20.47*(double)numericUpDown_vacdac.Value));
                    Form1.Port.ReadLine();
                }
                if (sender.Equals(numericUpDown_iacdac))
                {
                    Form1.Port.WriteLine("iacdac " + (2047 + 20.47 * (double)numericUpDown_iacdac.Value));
                    Form1.Port.ReadLine();
                }
                // Form1.Port.DiscardInBuffer();
                //Form1.Port.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                // Form1.Port.WriteLine("scope 799");
            }
            catch (Exception ee) { }
            System.Threading.Thread.Sleep(50);
            button2_Click(sender, null);
        }

        private void checkBox_notch_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
