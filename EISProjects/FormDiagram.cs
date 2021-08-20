using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;

namespace EISProjects
{


    public partial class FormDiagram : Form
    {
        ////////////////////////////////////////
        //public static RichTextBox Status = new RichTextBox();
        public int PlotIndex;
        public static int YAxisIndex = 0;
        public static int XAxisIndex = 0;
        public static double[] xArray;
        public static double[] yArray;
        public static double Yfactor = 1.0;
        public bool isSelfStanding = false;
        public double MinX = 0.0;
        public double MaxX = 0.0;
        public double MinY = 0.0;
        public double MaxY = 0.0;
        public string PGxunit = "";
        public int nPlottedData = 0;
        bool isDisconnectedFromSessionSource = false;
        Sessions SelfStandingSession;
        SessionOutputData SelfStandingSessionData;
        public int DensityOfPointsPlots = 1; //1 means all
        ////////////////////////////////////////
        public FormDiagram()
        {
            InitializeComponent();

            //////////////////////////////////
            //chart1.Series.Clear();
            //SessionName.Text = "";
            PlotIndex = -1;
            //CBXAxis.SelectedIndex = 0;
            //CBYAxis.SelectedIndex = 0;
            //////////////////////////////////
            /*
        using Imsl.Chart2D;
using System.Drawing;

public class SampleTicks : FrameChart {

    public SampleTicks() {
        Chart chart = this.Chart;
        AxisXY axis = new AxisXY(chart);
        axis.AutoscaleOutput = Axis.AUTOSCALE_OFF;

        axis.AxisX.SetWindow(0.0, 6.0);
        axis.AxisX.Density = 3;
        axis.AxisX.Number = 4;
        axis.AxisX.FirstTick = 0.5;
        axis.AxisX.TickInterval = 1.5;
        axis.AxisX.TickLength = -2;

        axis.AxisY.SetWindow(0.0, 10.0);
        double[] ticksY = {0.5, 2.0, 3.0, 6.0, 10.0};
        axis.AxisY.SetTicks(ticksY);
        axis.AxisY.TickLength = -1;

        double[] y = {4, 6, 2, 1, 8};
        Data data = new Data(axis, y);
        data.DataType = Data.DATA_TYPE_LINE;
        data.LineColor = Color.Blue;
    }

    public static void Main(string[] argv) {
        System.Windows.Forms.Application.Run(new SampleTicks());
    }
}

             */

        }

        private void PlotImpedanceRe(Chart chart, bool[] overflow, double[] xArray, double[] ReZArray, int npoints, bool isLogX, string XAxisName, string YAxisName)
        {
            if (nPlottedData == 0)
            {
                ClearPlot(chart);
                if (npoints > 0 && isLogX)
                    chart.ChartAreas[0].AxisX.IsLogarithmic = true;
                else
                    chart.ChartAreas[0].AxisX.IsLogarithmic = false;
                AddSeriesPoint(chart, "Re(Z)", XAxisName, YAxisName, Color.Blue);
            }

            for (int i = nPlottedData; i < npoints; i++)
            {
                AddPoint(chart, 0, xArray[i], ReZArray[i] * Yfactor);
                if (overflow[i]) chart.Series[0].Points[chart.Series[0].Points.Count - 1].Color = Color.DarkBlue;
            }

            nPlottedData = npoints;
        }

        private void PlotMatshatkiCurrent(Chart chart, bool[] overflow, double[] xArray, double[] Current, int npoints, bool isLogX, string XAxisName, string YAxisName)
        {
            if (nPlottedData == 0)
            {
                ClearPlot(chart);
                if (npoints > 0 && isLogX)
                    chart.ChartAreas[0].AxisX.IsLogarithmic = true;
                else
                    chart.ChartAreas[0].AxisX.IsLogarithmic = false;
                AddSeriesPoint(chart, "I", XAxisName, YAxisName, Color.Blue);
            }

            double mA = 1000.0;
            for (int i = nPlottedData; i < npoints; i++)
            {
                AddPoint(chart, 0, xArray[i], Current[i] * mA * Yfactor);
                if (overflow[i]) chart.Series[0].Points[chart.Series[0].Points.Count - 1].Color = Color.DarkBlue;
            }
            nPlottedData = npoints;
        }

        private void PlotImpedanceIm(Chart chart, bool[] overflow, double[] xArray, double[] ImZArray, int npoints, bool isLogX, string XAxisName, string YAxisName)
        {
            if (nPlottedData == 0)
            {
                ClearPlot(chart);
                if (npoints > 0 && isLogX)
                    chart.ChartAreas[0].AxisX.IsLogarithmic = true;
                else
                    chart.ChartAreas[0].AxisX.IsLogarithmic = false;
                AddSeriesPoint(chart, "Im(Z)", XAxisName, YAxisName, Color.Red);
            }


            for (int i = nPlottedData; i < npoints; i++)
            {
                AddPoint(chart, 0, xArray[i], ImZArray[i] * Yfactor);
                if (overflow[i]) chart.Series[0].Points[chart.Series[0].Points.Count - 1].Color = Color.DarkRed;
            }
            nPlottedData = npoints;
        }

        private void PlotImpedanceRadius(Chart chart, bool[] overflow, double[] xArray, double[] Radius, int npoints, bool isLogX, string XAxisName, string YAxisName)
        {
            if (nPlottedData == 0)
            {
                ClearPlot(chart);
                if (npoints > 0 && isLogX)
                    chart.ChartAreas[0].AxisX.IsLogarithmic = true;
                else
                    chart.ChartAreas[0].AxisX.IsLogarithmic = false;
                AddSeriesPoint(chart, "R", XAxisName, YAxisName, Color.Green);
            }

            for (int i = nPlottedData; i < npoints; i++)
            {
                AddPoint(chart, 0, xArray[i], Radius[i] * Yfactor);
                if (overflow[i]) chart.Series[0].Points[chart.Series[0].Points.Count - 1].Color = Color.DarkGreen;
            }
            nPlottedData = npoints;
        }

        private void PlotImpedanceTheta(Chart chart, bool[] overflow, double[] xArray, double[] Theta, int npoints, bool isLogX, string XAxisName, string YAxisName)
        {
            if (nPlottedData == 0)
            {
                ClearPlot(chart);
                if (npoints > 0 && isLogX)
                    chart.ChartAreas[0].AxisX.IsLogarithmic = true;
                else
                    chart.ChartAreas[0].AxisX.IsLogarithmic = false;
                AddSeriesPoint(chart, "Theta", XAxisName, YAxisName, Color.Orange);
            }

            for (int i = nPlottedData; i < npoints; i++)
            {
                AddPoint(chart, 0, xArray[i], Theta[i] * Yfactor);
                if (overflow[i]) chart.Series[0].Points[chart.Series[0].Points.Count - 1].Color = Color.DarkOrange;
            }
            nPlottedData = npoints;
        }

        private void PlotImpedanceReIm(Chart chart, bool[] overflow, double[] xArray, double[] ReZArray, double[] ImZArray, int npoints, bool isLogX, string XAxisName, string YAxisName)
        {
            if (nPlottedData == 0)
            {
                ClearPlot(chart);
                chart.ChartAreas[0].AxisX.Minimum = Double.NaN;
                chart.ChartAreas[0].AxisX.Maximum = Double.NaN;
                if (npoints > 0 && isLogX)
                    chart.ChartAreas[0].AxisX.IsLogarithmic = true;
                else
                    chart.ChartAreas[0].AxisX.IsLogarithmic = false;
                AddSeriesPoint(chart, "Re(Z)", XAxisName, YAxisName, Color.Blue);
                AddSeries(chart, "Im(Z)", XAxisName, YAxisName, Color.Red);
            }

            for (int i = nPlottedData; i < npoints; i++)
            {
                AddPoint(chart, 0, xArray[i], ReZArray[i] * Yfactor);
                if (overflow[i]) chart.Series[0].Points[chart.Series[0].Points.Count - 1].Color = Color.DarkBlue;
                AddPoint(chart, 1, xArray[i], ImZArray[i] * Yfactor);
                if (overflow[i]) chart.Series[1].Points[chart.Series[1].Points.Count - 1].Color = Color.DarkRed;
            }
            nPlottedData = npoints;
        }

        private void PlotMotShatkiC2Inv(Chart chart, bool[] overflow, double[] xArray, double frq, double[] Im, int npoints, bool isLogX, string XAxisName, string YAxisName)
        {
            if (nPlottedData == 0)
            {
                ClearPlot(chart);
                if (npoints > 0 && isLogX)
                    chart.ChartAreas[0].AxisX.IsLogarithmic = true;
                else
                    chart.ChartAreas[0].AxisX.IsLogarithmic = false;
                AddSeriesPoint(chart, "1/C^2", XAxisName, YAxisName, Color.Orange);
            }

            double uF2 = 1.0e-12;
            for (int i = nPlottedData; i < npoints; i++)
            {
                AddPoint(chart, 0, xArray[i], Math.Pow(Im[i] * frq * 2.0 * Math.PI, 2.0) * uF2 * Yfactor);
                if (overflow[i]) chart.Series[0].Points[chart.Series[0].Points.Count - 1].Color = Color.DarkOrange;
            }
            nPlottedData = npoints;
        }

        private Color GetCVColor(int i)
        {
            Color c = Color.Black;
            if (i == 0)
                c = Color.Blue;
            else if (i == 1)
                c = Color.Maroon;
            else if (i == 2)
                c = Color.Green;
            else if (i == 3)
                c = Color.YellowGreen;
            else if (i == 4)
                c = Color.Pink;
            else if (i == 5)
                c = Color.Purple;
            else if (i == 6)
                c = Color.Orange;
            else if (i == 7)
                c = Color.PowderBlue;
            else if (i == 8)
                c = Color.Olive;
            else if (i == 9)
                c = Color.Navy;
            else if (i == 10)
                c = Color.Gray;
            else if (i == 11)
                c = Color.MistyRose;
            else if (i == 12)
                c = Color.MidnightBlue;
            else if (i == 13)
                c = Color.MediumPurple;
            else if (i == 14)
                c = Color.Linen;
            else if (i == 15)
                c = Color.LimeGreen;
            else if (i == 16)
                c = Color.LightSlateGray;
            else if (i == 17)
                c = Color.Gray;
            else if (i == 18)
                c = Color.Gold;
            else if (i == 19)
                c = Color.Fuchsia;
            else if (i == 20)
                c = Color.ForestGreen;
            else if (i == 21)
                c = Color.DarkViolet;
            else if (i == 22)
                c = Color.DarkSeaGreen;
            else if (i == 23)
                c = Color.DarkOrange;
            else if (i == 24)
                c = Color.DarkBlue;
            return c;
        }

        private void PlotIVLine(Chart chart, double[] Vlt, double[] Amp, int npoints, bool isLogX, string XAxisName, string YAxisName)
        {
            ClearPlot(chart);

            double maxvlt = -100000000;
            double minvlt = 100000000;
            double maxamp = -100000000;
            double minamp = 100000000;
            for (int i = 0; i < npoints; i++)
            {
                if (minvlt > Vlt[i]) minvlt = Vlt[i];
                if (maxvlt < Vlt[i]) maxvlt = Vlt[i];
            }

            minvlt = minvlt - Math.Abs(minvlt) / 20.0;
            maxvlt = maxvlt + Math.Abs(maxvlt) / 20.0;

            double y0 = (minvlt + maxvlt) / 2.0;

            minvlt = minvlt - y0;
            maxvlt = maxvlt - y0;

            minvlt = minvlt * 1.1;
            maxvlt = maxvlt * 1.1;

            minvlt = minvlt + y0;
            maxvlt = maxvlt + y0;

            for (int i = 0; i < npoints; i++)
            {
                if (minamp > Amp[i]) minamp = Amp[i];
                if (maxamp < Amp[i]) maxamp = Amp[i];
            }

            minamp = minamp - Math.Abs(minamp) / 20.0;
            maxamp = maxamp + Math.Abs(maxamp) / 20.0;

            y0 = (minamp + maxamp) / 2.0;

            minamp = minamp - y0;
            maxamp = maxamp - y0;

            minamp = minamp * 1.1;
            maxamp = maxamp * 1.1;

            minamp = minamp + y0;
            maxamp = maxamp + y0;

            MaxX = maxvlt;
            MinX = minvlt;
            MaxY = maxamp * Yfactor;
            MinY = minamp * Yfactor;
            if (isSelfStanding)
            {
                chart.ChartAreas[0].AxisX.IsMarginVisible = true;
                chart.ChartAreas[0].AxisX.Maximum = maxvlt;
                chart.ChartAreas[0].AxisX.Minimum = minvlt;
                chart.ChartAreas[0].AxisY.Maximum = maxamp * Yfactor;
                chart.ChartAreas[0].AxisY.Minimum = minamp * Yfactor;
            }

            if (!(Form1.AllSessions[PlotIndex].Mode == 3 && Form1.AllSessions[PlotIndex].isCVEnable))
            {
                //double[] SortVlt = new double[npoints];
                //double[] SortAmp = new double[npoints];
                //for (int i = 0; i < npoints; i++)
                //{
                    //SortVlt[i] = Vlt[i];
                    //SortAmp[i] = Amp[i];
                //}

                //Array.Sort(SortVlt, SortAmp);
                //Array.Sort(SortVlt);

                if (npoints > 0 && isLogX)
                    chart.ChartAreas[0].AxisX.IsLogarithmic = true;
                else
                    chart.ChartAreas[0].AxisX.IsLogarithmic = false;

                AddSeries(chart, "I(V)", XAxisName, YAxisName, Color.Blue);
                AddSeries(chart, "X Axis", "", "", Color.Red); AddPoint(chart, 1, MinX * 10, 0); AddPoint(chart, 1, MaxX * 10, 0);
                AddSeries(chart, "Y Axis", "", "", Color.Red); AddPoint(chart, 2, 0, MinY * 10 * Yfactor); AddPoint(chart, 2, 0, MaxY * 10 * Yfactor);

                /*for (int i = 0; i < npoints; i++)
                {
                    //AddPoint(chart, 0, SortVlt[i], SortAmp[i] * Yfactor);
                    AddPoint(chart, 0, Vlt[i], Amp[i] * Yfactor);
                }*/
                nPlottedData = 0;
                if (nPlottedData + DensityOfPointsPlots > npoints - 1) return;

                int i;
                for (i = nPlottedData; i < npoints; i += DensityOfPointsPlots)
                {
                    AddPoint(chart, 0, Vlt[i], Amp[i] * Yfactor);
                }
                nPlottedData = i;
            }
            else
            {
                int CVnFirst = (int)((Form1.AllSessions[PlotIndex].IVvoltageTo - Form1.AllSessions[PlotIndex].CVStartpoint) / (Form1.AllSessions[PlotIndex].IVvoltageTo - Form1.AllSessions[PlotIndex].IVVoltageFrom) * (Form1.AllSessions[PlotIndex].IVVoltageNStepp - 1)) + 1;
                //double[] SortVlt = new double[CVnFirst];
                //double[] SortAmp = new double[CVnFirst];
                //for (int i = 0; i < CVnFirst; i++)
                //{
                    //SortVlt[i] = Vlt[i];
                    //SortAmp[i] = Amp[i];
                //}

                //Array.Sort(SortVlt, SortAmp);
                //Array.Sort(SortVlt);

                if (npoints > 0 && isLogX)
                    chart.ChartAreas[0].AxisX.IsLogarithmic = true;
                else
                    chart.ChartAreas[0].AxisX.IsLogarithmic = false;

                AddSeries(chart, "I(V) 1", XAxisName, YAxisName, GetCVColor(1));
                for (int i = 0; i < CVnFirst; i++)
                {
                    //AddPoint(chart, 0, SortVlt[i], SortAmp[i] * Yfactor);
                    AddPoint(chart, 0, Vlt[i], Amp[i] * Yfactor);
                }

                int n1 = Form1.AllSessions[PlotIndex].IVVoltageNStepp;
                
                //AddSeries(chart, "I(V) 1", XAxisName, YAxisName, GetCVColor(1));
                for (int i = 0; i < n1; i++)
                {
                    AddPoint(chart, chart.Series.Count - 1, Vlt[CVnFirst + i], Amp[CVnFirst + i] * Yfactor);
                }

                for (int ic = 1; ic < Form1.AllSessions[PlotIndex].CVItteration; ic++)
                {   
                    /*double[] VC1 = new double[n1];
                    double[] VC2 = new double[n1];
                    double[] VC = new double[n1 * 2];
                    double[] IC1 = new double[n1];
                    double[] IC2 = new double[n1];
                    double[] IC = new double[n1 * 2];

                    for (int ic1 = 0; ic1 < n1; ic1++)
                    {
                        int ind1 = CVnFirst + ic1 + ic * n1 * 2;
                        VC1[ic1] = Vlt[ind1];
                        IC1[ic1] = Amp[ind1];
                        int ind2 = CVnFirst + ic1 + n1 + ic * n1 * 2;
                        VC2[ic1] = Vlt[ind2];
                        IC2[ic1] = Amp[ind2];
                    }

                    //Array.Sort(VC1, IC1);
                    //Array.Sort(VC1);
                    //Array.Sort(VC2, IC2);
                    //Array.Sort(VC2);

                    for (int ic1 = 0; ic1 < n1; ic1++)
                    {
                        //VC[ic1] = VC1[ic1];
                        //VC[ic1 + n1] = VC2[n1 - 1 - ic1];
                        //IC[ic1] = IC1[ic1];
                        //IC[ic1 + n1] = IC2[n1 - 1 - ic1];
                        VC[ic1] = VC1[ic1];
                        VC[ic1 + n1] = VC2[ic1];
                        IC[ic1] = IC1[ic1];
                        IC[ic1 + n1] = IC2[ic1];
                    }*/

                    if (2 * n1 > 0 && isLogX)
                        chart.ChartAreas[0].AxisX.IsLogarithmic = true;
                    else
                        chart.ChartAreas[0].AxisX.IsLogarithmic = false;

                    AddSeries(chart, "I(V) " + (ic + 1).ToString(), XAxisName, YAxisName, GetCVColor(ic + 1));
                    for (int i = 0; i < 2 * n1; i++)
                    {
                        //AddPoint(chart, chart.Series.Count - 1, VC[i], IC[i] * Yfactor);
                        AddPoint(chart, chart.Series.Count - 1, Vlt[CVnFirst + (2 * ic - 1) * n1 + i], Amp[CVnFirst + (2 * ic - 1) * n1 + i] * Yfactor);
                    }

                }
                

                AddSeries(chart, "X Axis", " ", " ", Color.Red); AddPoint(chart, chart.Series.Count - 1, MinX, 0); AddPoint(chart, chart.Series.Count - 1, MaxX, 0);
                AddSeries(chart, "Y Axis", " ", " ", Color.Red); AddPoint(chart, chart.Series.Count - 1, 0, MinY * Yfactor); AddPoint(chart, chart.Series.Count - 1, 0, MaxY * Yfactor);
            }



            // SetXAxis(chart1, Vlt[0], Vlt[npoints - 1]);

        }

        private void PlotIVPoint(Chart chart, double[] Vlt, double[] Amp, int npoints, bool isLogX, string XAxisName, string YAxisName)
        {
            if (npoints > 0)
            {
                if (XAxisIndex == 2)
                {
                    chart.ChartAreas[0].AxisX.Maximum = MaxX;
                    chart.ChartAreas[0].AxisX.Minimum = MinX;
                }

                if (YAxisIndex == 2)
                {
                    chart.ChartAreas[0].AxisY.Maximum = MaxY;
                    chart.ChartAreas[0].AxisY.Minimum = MinY;
                }

                //ClearPlot(chart);
                if (isSelfStanding && nPlottedData == 0)
                {
                    chart.ChartAreas[0].AxisX.IsMarginVisible = true;
                    chart.ChartAreas[0].AxisX.Maximum = MaxX;
                    chart.ChartAreas[0].AxisX.Minimum = MinX;
                    chart.ChartAreas[0].AxisY.Maximum = MaxY * Yfactor;
                    chart.ChartAreas[0].AxisY.Minimum = MinY * Yfactor;
                    chart.ChartAreas[0].AxisX.Interval = Math.Floor((MaxX - MinX)) / 10;
                }

                if (!(Form1.AllSessions[PlotIndex].Mode==3 && Form1.AllSessions[PlotIndex].isCVEnable))
                {
                    if (nPlottedData == 0)
                    {
                        if (npoints > 0 && isLogX)
                            chart.ChartAreas[0].AxisX.IsLogarithmic = true;
                        else
                            chart.ChartAreas[0].AxisX.IsLogarithmic = false;
                        AddSeries(chart, "I(V)", XAxisName, YAxisName, Color.Blue);
                        //AddSeries(chart, "X Axis", "", "", Color.Red); AddPoint(chart, 1, MinX * 10, 0); AddPoint(chart, 1, MaxX * 10, 0);
                        //AddSeries(chart, "Y Axis", "", "", Color.Red); AddPoint(chart, 2, 0, MinY * 10 * Yfactor); AddPoint(chart, 2, 0, MaxY * 10 * Yfactor);
                        AddSeries(chart, "X Axis", "", "", Color.Red); AddPoint(chart, 1, MinX * 10 * 0.0000000001, 0.0000000001); AddPoint(chart, 1, MaxX * 10 *0.0000000001, 0.0000000001);
                        AddSeries(chart, "Y Axis", "", "", Color.Red); AddPoint(chart, 2, 0.0000000001, MinY * 10 * Yfactor * 0.0000000001); AddPoint(chart, 2, 0.0000000001, MaxY * 10 * Yfactor * 0.0000000001);
                        chart.Series[0].ChartType = SeriesChartType.Point;
                        chart.Series[0].MarkerStyle = MarkerStyle.None;
                        AddPoint(chart, 0, Vlt[0], Amp[0] * Yfactor);
                        nPlottedData = 1;
                    }//baname jadid ro rikhtan u001
                     /* if (isSelfStanding)
                        {
                            chart.ChartAreas[0].AxisX.IsMarginVisible = false;
                            chart.ChartAreas[0].AxisX.Maximum = MaxX;
                            chart.ChartAreas[0].AxisX.Minimum = MinX;
                            chart.ChartAreas[0].AxisY.Maximum = MaxY * Yfactor;
                            chart.ChartAreas[0].AxisY.Minimum = MinY * Yfactor;
                        }*/
           
                    if (nPlottedData + DensityOfPointsPlots > npoints - 1) return;

                    int i;
                    for (i = nPlottedData; i < npoints; i+=DensityOfPointsPlots)
                    {
                        AddPoint(chart, 0, Vlt[i], Amp[i] * Yfactor);
                    }
                    nPlottedData = i;
                }
                else
                {
                    ClearPlot(chart);
                    int CVnFirst = (int)((Form1.AllSessions[PlotIndex].IVvoltageTo - Form1.AllSessions[PlotIndex].CVStartpoint) / (Form1.AllSessions[PlotIndex].IVvoltageTo - Form1.AllSessions[PlotIndex].IVVoltageFrom) * (Form1.AllSessions[PlotIndex].IVVoltageNStepp - 1)) + 1;
                    int npoints0 = Math.Min(npoints, CVnFirst);

                    if (npoints0 > 0 && isLogX)
                        chart.ChartAreas[0].AxisX.IsLogarithmic = true;
                    else
                        chart.ChartAreas[0].AxisX.IsLogarithmic = false;
                    AddSeries(chart, "I(V) 1", XAxisName, YAxisName, GetCVColor(1));
                    chart.Series[0].ChartType = SeriesChartType.Point;
                    chart.Series[0].MarkerStyle = MarkerStyle.None;

                    for (int i = 0; i < npoints0; i++)
                    {
                        AddPoint(chart, 0, Vlt[i], Amp[i] * Yfactor);
                    }

                    
                    int n1 = Form1.AllSessions[PlotIndex].IVVoltageNStepp;

                    if (npoints0 == CVnFirst)
                    {
                        int npoints1 = Math.Min(npoints - CVnFirst, n1);
                        //AddSeries(chart, "I(V) 1", XAxisName, YAxisName, GetCVColor(1));
                        //chart.Series[chart.Series.Count - 1].ChartType = SeriesChartType.Point;
                        //chart.Series[chart.Series.Count - 1].MarkerStyle = MarkerStyle.Circle;
                        for (int i = 0; i < npoints1; i++)
                        {
                            AddPoint(chart, chart.Series.Count - 1, Vlt[CVnFirst + i], Amp[CVnFirst + i] * Yfactor);
                        }
                    }

                    for (int ic = 1; ic < Form1.AllSessions[PlotIndex].CVItteration; ic++)
                    {
                        try
                        {
                            if (2 * n1 > 0 && isLogX)
                                chart.ChartAreas[0].AxisX.IsLogarithmic = true;
                            else
                                chart.ChartAreas[0].AxisX.IsLogarithmic = false;

                            AddSeries(chart, "I(V) " + (ic + 1).ToString(), XAxisName, YAxisName, GetCVColor(ic + 1));
                            chart.Series[chart.Series.Count - 1].ChartType = SeriesChartType.Point;
                            chart.Series[chart.Series.Count - 1].MarkerStyle = MarkerStyle.None;
                            for (int i = 0; i < 2 * n1; i++)
                            {
                                AddPoint(chart, chart.Series.Count - 1, Vlt[CVnFirst + (2 * ic - 1) * n1 + i], Amp[CVnFirst + (2 * ic - 1) * n1 + i] * Yfactor);
                            }
                        }
                        catch
                        { }
                    }


                    AddSeries(chart, "X Axis", " ", " ", Color.Red);//barnamr ro dorost kardam bash-1
                    int ns = chart.Series.Count;
                    AddPoint(chart, ns - 1, MinX, 0); AddPoint(chart, ns - 1, MaxX, 0);
                    AddSeries(chart, "Y Axis", " ", " ", Color.Red);
                    AddPoint(chart, ns, 0, MinY * Yfactor); AddPoint(chart, ns, 0, MaxY * Yfactor);
                }
            }
        }

        private void AddPoint(Chart chart, int SeriesIndex, double x, double y)
        {
            chart.Series[SeriesIndex].Points.AddXY(x, y);
        }

        private void AddSeriesPoint(Chart chart, string legend, string xAxis, string yAxis, Color color)
        {
            chart.Series.Add(legend);
            int Index = -1;
            foreach (Series S in chart.Series) Index++;
            chart.Series[Index].ChartType = SeriesChartType.Point;
            chart.Series[Index].Color = color;
            chart.Series[Index].LegendText = legend;
            chart.ChartAreas[0].Axes[0].Title = xAxis;
            chart.ChartAreas[0].Axes[1].Title = yAxis;
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

        public void SessionName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (SessionName.Visible) PlotIndex = SessionName.SelectedIndex;
                nPlottedData = 0;
                string NormalVoltPGCurrent = "Voltage [V]";
                string NormalCurrentPGVolt = "Current [A]";
                string NormalSetVoltPGSetCurrent = "Real Voltage [V]";

                if (Form1.AllSessions[PlotIndex].PGmode == 3)
                {
                    if (Form1.AllSessions[PlotIndex].Mode == 2 || Form1.AllSessions[PlotIndex].Mode == 3)
                    {
                        if (Form1.AllSessions[PlotIndex].IVCurrentRangeMode == 0)
                            PGxunit = "[A]";
                        else if (Form1.AllSessions[PlotIndex].IVCurrentRangeMode >= 1 && Form1.AllSessions[PlotIndex].IVCurrentRangeMode <= 3)
                            PGxunit = "[mA]";
                        else if (Form1.AllSessions[PlotIndex].IVCurrentRangeMode >= 4 && Form1.AllSessions[PlotIndex].IVCurrentRangeMode <= 6)
                            PGxunit = "[uA]";
                        else if (Form1.AllSessions[PlotIndex].IVCurrentRangeMode == 7)
                            PGxunit = "[nA]";
                    }
                    else if (Form1.AllSessions[PlotIndex].Mode == 4)
                    {
                        if (Form1.AllSessions[PlotIndex].PulseCurrentRangeMode == 0)
                            PGxunit = "[A]";
                        else if (Form1.AllSessions[PlotIndex].PulseCurrentRangeMode >= 1 && Form1.AllSessions[PlotIndex].PulseCurrentRangeMode <= 3)
                            PGxunit = "[mA]";
                        else if (Form1.AllSessions[PlotIndex].PulseCurrentRangeMode >= 4 && Form1.AllSessions[PlotIndex].PulseCurrentRangeMode <= 6)
                            PGxunit = "[uA]";
                        else if (Form1.AllSessions[PlotIndex].PulseCurrentRangeMode == 7)
                            PGxunit = "[nA]";
                    }
                    else if (Form1.AllSessions[PlotIndex].Mode == 5)
                    {
                        if (Form1.AllSessions[PlotIndex].Charge_CurrentRangeMode == 0)
                            PGxunit = "[A]";
                        else if (Form1.AllSessions[PlotIndex].Charge_CurrentRangeMode >= 1 && Form1.AllSessions[PlotIndex].Charge_CurrentRangeMode <= 3)
                            PGxunit = "[mA]";
                        else if (Form1.AllSessions[PlotIndex].Charge_CurrentRangeMode >= 4 && Form1.AllSessions[PlotIndex].Charge_CurrentRangeMode <= 6)
                            PGxunit = "[uA]";
                        else if (Form1.AllSessions[PlotIndex].Charge_CurrentRangeMode == 7)
                            PGxunit = "[nA]";
                    }
                    NormalVoltPGCurrent = "Current " + PGxunit;
                    NormalCurrentPGVolt = "Real Current [A]";
                    NormalSetVoltPGSetCurrent = "Voltage [V]";
                }
                

                if (PlotIndex > -1)
                {
                    Xpanel.Enabled = true;
                    Ypanel.Enabled = true;
                    CBXAxis.Items.Clear();
                    CBYAxis.Items.Clear();
                    //CBIUnit.Items.Clear();
                    if (Form1.AllSessions[PlotIndex].Mode == 0)
                    {
                        CBXAxis.Items.Add("Frequency [Hz]");
                        CBXAxis.Items.Add("Re(Z) [Ohm]");
                        CBXAxis.Items.Add("-Im(Z) [Ohm]");
                        CBXAxis.Items.Add("r [Ohm]");
                        CBXAxis.Items.Add("Theta [Degree]");

                        CBYAxis.Items.Add("Re(Z) & Im(Z) [Ohm]");
                        CBYAxis.Items.Add("Re(Z) [Ohm]");
                        CBYAxis.Items.Add("-Im(Z) [Ohm]");
                        CBYAxis.Items.Add("r [Ohm]");
                        CBYAxis.Items.Add("Theta [Degree]");
                        //CBIUnit.Items.Add("Ohm");
                        //CBIUnit.Items.Add("K Ohm");
                        //CBIUnit.Items.Add("M Ohm");
                    }

                    if (Form1.AllSessions[PlotIndex].Mode == 1)
                    {


                        CBXAxis.Items.Add(NormalVoltPGCurrent);
                        CBXAxis.Items.Add("Re(Z) [Ohm]");
                        CBXAxis.Items.Add("Im(Z) [Ohm]");
                        CBXAxis.Items.Add("r [Ohm]");
                        CBXAxis.Items.Add("Theta [Degree]");

                        CBYAxis.Items.Add("1/C^2 [(uF)^-2]");
                        CBYAxis.Items.Add("I [mA]");
                        CBYAxis.Items.Add("Re(Z) [Ohm]");
                        CBYAxis.Items.Add("Im(Z) [Ohm]");
                        CBYAxis.Items.Add("r [Ohm]");
                        CBYAxis.Items.Add("Theta [Degree]");

                        //CBIUnit.Items.Add("F^-2");
                        //CBIUnit.Items.Add("K F^-2");
                        //CBIUnit.Items.Add("M F^-2");
                    }


                    
                    /*if (Form1.AllSessions[PlotIndex].Mode == 2)
                    {
                        CBXAxis.Items.Add("Time [sec]");
                        CBYAxis.Items.Add(NormalCurrentPGVolt);
                        //CBIUnit.Items.Add("Amper");
                        //CBIUnit.Items.Add("mili Amper");
                        //CBIUnit.Items.Add("micro Amper");
                    }

                    if (Form1.AllSessions[PlotIndex].Mode == 3 || Form1.AllSessions[PlotIndex].Mode == 4)
                    {
                        CBXAxis.Items.Add(NormalVoltPGCurrent);
                        CBYAxis.Items.Add(NormalCurrentPGVolt);
                        //CBIUnit.Items.Add("Amper");
                        //CBIUnit.Items.Add("mili Amper");
                        //CBIUnit.Items.Add("micro Amper");
                    }*/

                    if (Form1.AllSessions[PlotIndex].Mode == 2 || Form1.AllSessions[PlotIndex].Mode == 3 || Form1.AllSessions[PlotIndex].Mode == 4)
                    {
                        CBXAxis.Items.Add(NormalVoltPGCurrent);
                        CBYAxis.Items.Add(NormalVoltPGCurrent);

                        CBXAxis.Items.Add(NormalCurrentPGVolt);
                        CBYAxis.Items.Add(NormalCurrentPGVolt);

                        CBXAxis.Items.Add("Time [sec]");
                        CBYAxis.Items.Add("Time [sec]");

                        CBXAxis.Items.Add(NormalSetVoltPGSetCurrent);
                        CBYAxis.Items.Add(NormalSetVoltPGSetCurrent);
                        

                    }

                    if (Form1.AllSessions[PlotIndex].Mode == 5)
                    {
                        CBXAxis.Items.Add(NormalVoltPGCurrent);
                        CBYAxis.Items.Add(NormalVoltPGCurrent);

                        CBXAxis.Items.Add(NormalCurrentPGVolt);
                        CBYAxis.Items.Add(NormalCurrentPGVolt);

                        CBXAxis.Items.Add("Time [sec]");
                        CBYAxis.Items.Add("Time [sec]");
                        
                    }

                    if (Form1.AllSessions[PlotIndex].Mode == 3 || Form1.AllSessions[PlotIndex].Mode == 5)
                    {
                        CBYAxis.Items.Add("Log(I)");
                        CBYAxis.Items.Add("Log(t)");
                    }

                    CBXAxis.SelectedIndex = 0;
                    CBYAxis.SelectedIndex = 0;

                    if (Form1.AllSessions[PlotIndex].Mode == 3 || Form1.AllSessions[PlotIndex].Mode == 4)
                    {
                        CBXAxis.SelectedIndex = 0;

                        if (Form1.AllSessions[Form1.Selected].PGmode == 3)
                            CBYAxis.SelectedIndex = 3;
                        else
                            CBYAxis.SelectedIndex = 1;
                    }

                    if (Form1.AllSessions[PlotIndex].Mode == 2)
                    {
                        CBXAxis.SelectedIndex = 2;
                        if (Form1.AllSessions[Form1.Selected].PGmode == 3)
                            CBYAxis.SelectedIndex = 3;
                        else
                            CBYAxis.SelectedIndex = 1;
                    }

                    if (Form1.AllSessions[PlotIndex].Mode == 5)
                    {
                        CBXAxis.SelectedIndex = 2;
                        if (Form1.AllSessions[Form1.Selected].PGmode == 3)
                            CBYAxis.SelectedIndex = 0;
                        else
                            CBYAxis.SelectedIndex = 0;
                    }

                    CBIUnit.SelectedIndex = 2;
                    if ((Form1.AllSessions[Form1.Selected].PGmode != 3) && (Form1.AllSessions[PlotIndex].Mode == 2 || Form1.AllSessions[PlotIndex].Mode == 3))
                    {
                        if (Form1.AllSessions[PlotIndex].IVCurrentRangeMode == 0)
                            CBIUnit.SelectedIndex = 2;
                        else if (Form1.AllSessions[PlotIndex].IVCurrentRangeMode >= 1 && Form1.AllSessions[PlotIndex].IVCurrentRangeMode <= 3)
                            CBIUnit.SelectedIndex = 1;
                        else
                            CBIUnit.SelectedIndex = 0;
                    }

                    if ((Form1.AllSessions[Form1.Selected].PGmode != 3) && (Form1.AllSessions[PlotIndex].Mode == 4))
                    {
                        if (Form1.AllSessions[PlotIndex].PulseCurrentRangeMode == 0)
                            CBIUnit.SelectedIndex = 2;
                        else if (Form1.AllSessions[PlotIndex].PulseCurrentRangeMode >= 1 && Form1.AllSessions[PlotIndex].PulseCurrentRangeMode <= 3)
                            CBIUnit.SelectedIndex = 1;
                        else
                            CBIUnit.SelectedIndex = 0;
                    }

                    if (Form1.AllSessions[PlotIndex].isStarted)
                    {
                        if (Form1.AllSessions[PlotIndex].isFinished)
                        {
                            FigureTimer.Enabled = false;
                            CheckStartTimer.Enabled = false;
                            //Plot(Form1.AllSessionsData[PlotIndex].ReZ, Form1.AllSessionsData[PlotIndex].ReceivedDataCount, chart1, Form1.AllSessions[PlotIndex].Name,
                            //    Form1.AllSessions[PlotIndex].ACFrqFrom, Form1.AllSessions[PlotIndex].ACFrqTo);

                            UpdateDiagram();
                        }
                        else
                        {
                            CheckStartTimer.Enabled = false;
                            FigureTimer.Enabled = true;
                        }
                    }
                    else
                    {
                        FigureTimer.Enabled = false;
                        CheckStartTimer.Enabled = true;
                        chart1.ChartAreas[0].AxisX.IsLogarithmic = false;
                        chart1.Series.Clear();
                    }
                }
                else
                {
                    chart1.ChartAreas[0].AxisX.IsLogarithmic = false;
                    chart1.Series.Clear();
                    Xpanel.Enabled = false;
                    Ypanel.Enabled = false;
                }
            }
            catch
            {
            }
        }

        private void FigureTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                UpdateDiagram();
                if (Form1.AllSessions[PlotIndex].isFinished && !isDisconnectedFromSessionSource)
                {
                    SelfStandingSession = new Sessions();
                    SelfStandingSessionData = new SessionOutputData();
                    CopySessions(PlotIndex, ref SelfStandingSession, ref SelfStandingSessionData);
                    FigureTimer.Enabled = false;
                    isDisconnectedFromSessionSource = true;
                }
            }
            catch
            {
            }
        }

        private void CopySessions(int Index, ref Sessions NewSession, ref SessionOutputData EmptyData)
        {
            NewSession.active = Form1.AllSessions[Index].active;
            NewSession.isCVEnable = Form1.AllSessions[Index].isCVEnable;
            NewSession.V_OCT = Form1.AllSessions[Index].V_OCT;
            NewSession.IdealVoltage = Form1.AllSessions[Index].IdealVoltage;
            NewSession.isOCP = Form1.AllSessions[Index].isOCP;
            NewSession.isOCPAutoStart = Form1.AllSessions[Index].isOCPAutoStart;
            NewSession.PGmode = Form1.AllSessions[Index].PGmode;
            NewSession.RelRef = Form1.AllSessions[Index].RelRef;
            NewSession.EqTime = Form1.AllSessions[Index].EqTime;
            NewSession.Mode = Form1.AllSessions[Index].Mode;

            NewSession.EISDCCurrentRangeModea = Form1.AllSessions[Index].EISDCCurrentRangeModea;
            NewSession.EISACRegulatorMode = Form1.AllSessions[Index].EISACRegulatorMode;
            NewSession.EISACCurrentRangeMode = Form1.AllSessions[Index].EISACCurrentRangeMode;
            NewSession.EISVmlpMax = Form1.AllSessions[Index].EISVmlpMax;
            NewSession.EISImlpMax = Form1.AllSessions[Index].EISImlpMax;
            NewSession.EISfilterMode = Form1.AllSessions[Index].EISfilterMode;
            NewSession.EISAverageNumberL = Form1.AllSessions[Index].EISAverageNumberL;
            NewSession.EISAverageNumberH = Form1.AllSessions[Index].EISAverageNumberH;
            NewSession.EISMode = Form1.AllSessions[Index].EISMode;
            NewSession.EISOCMode = Form1.AllSessions[Index].EISOCMode;
            NewSession.EISVoltageRangeMode = Form1.AllSessions[Index].EISVoltageRangeMode;
            NewSession.IVVoltageRangeMode = Form1.AllSessions[Index].IVVoltageRangeMode;
            NewSession.IVChrono_VFilter = Form1.AllSessions[Index].IVChrono_VFilter;
            NewSession.Pulse_VFilter = Form1.AllSessions[Index].Pulse_VFilter;

            NewSession.PulseVoltagerangeMode = Form1.AllSessions[Index].PulseVoltagerangeMode;
            NewSession.PulseCurrentRangeMode = Form1.AllSessions[Index].PulseCurrentRangeMode;
            NewSession.PulseVmlp = Form1.AllSessions[Index].PulseVmlp;
            NewSession.PulseImlpp = Form1.AllSessions[Index].PulseImlpp;
            NewSession.PulseReadingEdgemode = Form1.AllSessions[Index].PulseReadingEdgemode;
            NewSession.PulseVoltammetryMode = Form1.AllSessions[Index].PulseVoltammetryMode;

            NewSession.Charge_CurrentCharge = Form1.AllSessions[Index].Charge_CurrentCharge;
            NewSession.Charge_CurrentDischarge = Form1.AllSessions[Index].Charge_CurrentDischarge;
            NewSession.Charge_VoltageMax = Form1.AllSessions[Index].Charge_VoltageMax;
            NewSession.Charge_VoltageMin = Form1.AllSessions[Index].Charge_VoltageMin;
            NewSession.Charge_TotalTime = Form1.AllSessions[Index].Charge_TotalTime;
            NewSession.Charge_NumberOfCycles = Form1.AllSessions[Index].Charge_NumberOfCycles;
            NewSession.Charge_DataCount = Form1.AllSessions[Index].Charge_DataCount;
            NewSession.Charge_VoltageRangeMode = Form1.AllSessions[Index].Charge_VoltageRangeMode;
            NewSession.Charge_CurrentRangeMode = Form1.AllSessions[Index].Charge_CurrentRangeMode;
            NewSession.Charge_Vmlp = Form1.AllSessions[Index].Charge_Vmlp;
            NewSession.Charge_Imlp = Form1.AllSessions[Index].Charge_Imlp;
            NewSession.Charge_VFilter = Form1.AllSessions[Index].Charge_VFilter;
            NewSession.Charge_dt_ms = Form1.AllSessions[Index].Charge_dt_ms;

            NewSession.DCVoltageConstant = Form1.AllSessions[Index].DCVoltageConstant;
            NewSession.DCVoltageFrom = Form1.AllSessions[Index].DCVoltageFrom;
            NewSession.DCVoltageTo = Form1.AllSessions[Index].DCVoltageTo;
            NewSession.DCVoltageStep = Form1.AllSessions[Index].DCVoltageStep;

            NewSession.ACAmpConstant = Form1.AllSessions[Index].ACAmpConstant;
            NewSession.ACAmpFrom = Form1.AllSessions[Index].ACAmpFrom;
            NewSession.ACAmpTo = Form1.AllSessions[Index].ACAmpTo;
            NewSession.ACAmpStep = Form1.AllSessions[Index].ACAmpStep;

            NewSession.ACFrqConstant = Form1.AllSessions[Index].ACFrqConstant;
            NewSession.ACFrqFrom = Form1.AllSessions[Index].ACFrqFrom;
            NewSession.ACFrqTo = Form1.AllSessions[Index].ACFrqTo;
            NewSession.ACFrqNStep = Form1.AllSessions[Index].ACFrqNStep;

            NewSession.IVCurrentRangeMode = Form1.AllSessions[Index].IVCurrentRangeMode;
            NewSession.IVVmlp = Form1.AllSessions[Index].IVVmlp;
            NewSession.IVImlp = Form1.AllSessions[Index].IVImlp;
            NewSession.IVVoltageFrom = Form1.AllSessions[Index].IVVoltageFrom;
            NewSession.IVVoltageNStepp = Form1.AllSessions[Index].IVVoltageNStepp;
            NewSession.CVStartpoint = Form1.AllSessions[Index].CVStartpoint;

            NewSession.PretreatmentVoltage = Form1.AllSessions[Index].PretreatmentVoltage;
            NewSession.isPreProcProbOn = Form1.AllSessions[Index].isPreProcProbOn;
            NewSession.isChBPostProcProbOff = Form1.AllSessions[Index].isChBPostProcProbOff;

            NewSession.CVItteration = Form1.AllSessions[Index].CVItteration;
            NewSession.IVvoltageTo = Form1.AllSessions[Index].IVvoltageTo;
            NewSession.ChronoEndTime = Form1.AllSessions[Index].ChronoEndTime;
            NewSession.IVTimestep = Form1.AllSessions[Index].IVTimestep;

            NewSession.Chrono_n = Form1.AllSessions[Index].Chrono_n;
            NewSession.Chrono_Total_Period = Form1.AllSessions[Index].Chrono_Total_Period;
            NewSession.Chrono_Pulse_Period = Form1.AllSessions[Index].Chrono_Pulse_Period;
            NewSession.Chrono_Pulse_Level = Form1.AllSessions[Index].Chrono_Pulse_Level;
            NewSession.Chrono_Pulse_Amplitude = Form1.AllSessions[Index].Chrono_Pulse_Amplitude;
            NewSession.Chrono_Level_Step = Form1.AllSessions[Index].Chrono_Level_Step;
            NewSession.Chrono_Amplitude_step = Form1.AllSessions[Index].Chrono_Amplitude_step;
            NewSession.Chrono_isfast = Form1.AllSessions[Index].Chrono_isfast;
            NewSession.Chrono_nsteps = Form1.AllSessions[Index].Chrono_nsteps;
            NewSession.Chrono_t1 = Form1.AllSessions[Index].Chrono_t1;
            NewSession.Chrono_t2 = Form1.AllSessions[Index].Chrono_t2;
            NewSession.Chrono_t3 = Form1.AllSessions[Index].Chrono_t3;
            NewSession.Chrono_t4 = Form1.AllSessions[Index].Chrono_t4;
            NewSession.Chrono_t5 = Form1.AllSessions[Index].Chrono_t5;
            NewSession.Chrono_t6 = Form1.AllSessions[Index].Chrono_t6;
            NewSession.Chrono_t7 = Form1.AllSessions[Index].Chrono_t7;
            NewSession.Chrono_t8 = Form1.AllSessions[Index].Chrono_t8;
            NewSession.Chrono_t9 = Form1.AllSessions[Index].Chrono_t9;
            NewSession.Chrono_t10 = Form1.AllSessions[Index].Chrono_t10;
            NewSession.Chrono_v1 = Form1.AllSessions[Index].Chrono_v1;
            NewSession.Chrono_v2 = Form1.AllSessions[Index].Chrono_v2;
            NewSession.Chrono_v3 = Form1.AllSessions[Index].Chrono_v3;
            NewSession.Chrono_v4 = Form1.AllSessions[Index].Chrono_v4;
            NewSession.Chrono_v5 = Form1.AllSessions[Index].Chrono_v5;
            NewSession.Chrono_v6 = Form1.AllSessions[Index].Chrono_v6;
            NewSession.Chrono_v7 = Form1.AllSessions[Index].Chrono_v7;
            NewSession.Chrono_v8 = Form1.AllSessions[Index].Chrono_v8;
            NewSession.Chrono_v9 = Form1.AllSessions[Index].Chrono_v9;
            NewSession.Chrono_v10 = Form1.AllSessions[Index].Chrono_v10;
            NewSession.Chrono_dt = Form1.AllSessions[Index].Chrono_dt;
            NewSession.Chrono_ocp1 = Form1.AllSessions[Index].Chrono_ocp1;
            NewSession.Chrono_ocp2 = Form1.AllSessions[Index].Chrono_ocp2;
            NewSession.Chrono_ocp3 = Form1.AllSessions[Index].Chrono_ocp3;
            NewSession.Chrono_ocp4 = Form1.AllSessions[Index].Chrono_ocp4;
            NewSession.Chrono_ocp5 = Form1.AllSessions[Index].Chrono_ocp5;
            NewSession.Chrono_ocp6 = Form1.AllSessions[Index].Chrono_ocp6;
            NewSession.Chrono_ocp7 = Form1.AllSessions[Index].Chrono_ocp7;
            NewSession.Chrono_ocp8 = Form1.AllSessions[Index].Chrono_ocp8;
            NewSession.Chrono_ocp9 = Form1.AllSessions[Index].Chrono_ocp9;
            NewSession.Chrono_ocp10 = Form1.AllSessions[Index].Chrono_ocp10;
            NewSession.ExportAtFinalDIR = Form1.AllSessions[Index].ExportAtFinalDIR;
            NewSession.isExportAtFinal = Form1.AllSessions[Index].isExportAtFinal;
            NewSession.isStarted = Form1.AllSessions[Index].isStarted;
            NewSession.isFinished = Form1.AllSessions[Index].isFinished;
            NewSession.isACAmpConstant = Form1.AllSessions[Index].isACAmpConstant;
            NewSession.isACFrqConstant = Form1.AllSessions[Index].isACFrqConstant;
            NewSession.isDCVoltageConstant = Form1.AllSessions[Index].isDCVoltageConstant;
            NewSession.name = Form1.AllSessions[Index].name;
            NewSession.DataAndTime = Form1.AllSessions[Index].DataAndTime;
            NewSession.index = Form1.AllSessions[Index].index;

            EmptyData.ACAmpDim = Form1.AllSessionsData[Index].ACAmpDim;
            EmptyData.ACFrqDim = Form1.AllSessionsData[Index].ACFrqDim;
            EmptyData.DCVltDim = Form1.AllSessionsData[Index].DCVltDim;
            EmptyData.IVAmpDim = Form1.AllSessionsData[Index].IVAmpDim;
            EmptyData.ReceivedDataCount = Form1.AllSessionsData[Index].ReceivedDataCount;

            if (NewSession.Mode == 0 || NewSession.Mode == 1) //EIS and M-SH
            {
                if (NewSession.Mode == 0)
                    EmptyData.Frq = new double[EmptyData.ReceivedDataCount];
                else
                {
                    EmptyData.Vlt = new double[EmptyData.ReceivedDataCount];
                    EmptyData.Amp = new double[EmptyData.ReceivedDataCount];
                }
                EmptyData.ReZ = new double[EmptyData.ReceivedDataCount];
                EmptyData.Imz = new double[EmptyData.ReceivedDataCount];
                EmptyData.overflow = new bool[EmptyData.ReceivedDataCount];
                for (int i = 0; i < EmptyData.ReceivedDataCount; i++)
                {
                    if (NewSession.Mode == 0)
                        EmptyData.Frq[i] = Form1.AllSessionsData[Index].Frq[i];
                    else
                    {
                        EmptyData.Vlt[i] = Form1.AllSessionsData[Index].Vlt[i];
                        EmptyData.Amp[i] = Form1.AllSessionsData[Index].Amp[i];
                    }
                    EmptyData.ReZ[i] = Form1.AllSessionsData[Index].ReZ[i];
                    EmptyData.Imz[i] = Form1.AllSessionsData[Index].Imz[i];
                    EmptyData.overflow[i] = Form1.AllSessionsData[Index].overflow[i];
                }
            }

            if (NewSession.Mode == 2 || NewSession.Mode == 3 || NewSession.Mode == 4)   //IV mode
            {
                EmptyData.Vlt = new double[EmptyData.ReceivedDataCount];
                EmptyData.Amp = new double[EmptyData.ReceivedDataCount];
                EmptyData.ReZ = new double[EmptyData.ReceivedDataCount];
                EmptyData.Imz = new double[EmptyData.ReceivedDataCount];
                for (int i = 0; i < EmptyData.ReceivedDataCount; i++)
                {
                    EmptyData.Vlt[i] = Form1.AllSessionsData[Index].Vlt[i];
                    EmptyData.Amp[i] = Form1.AllSessionsData[Index].Amp[i];
                    EmptyData.ReZ[i] = Form1.AllSessionsData[Index].ReZ[i];
                    EmptyData.Imz[i] = Form1.AllSessionsData[Index].Imz[i];
                }
            }
            if (NewSession.Mode == 5)   //charge mode battery mode
            {
                EmptyData.Vlt = new double[EmptyData.ReceivedDataCount];
                EmptyData.Amp = new double[EmptyData.ReceivedDataCount];
                EmptyData.ReZ = new double[EmptyData.ReceivedDataCount];
                for (int i = 0; i < EmptyData.ReceivedDataCount; i++)
                {
                    EmptyData.Vlt[i] = Form1.AllSessionsData[Index].Vlt[i];
                    EmptyData.Amp[i] = Form1.AllSessionsData[Index].Amp[i];
                    EmptyData.ReZ[i] = Form1.AllSessionsData[Index].ReZ[i];
                }
            }
        }

        private void CheckStartTimer_Tick(object sender, EventArgs e)
        {
            if (Form1.AllSessions[PlotIndex].isStarted)
            {
                CheckStartTimer.Enabled = false;
                FigureTimer.Enabled = true;
            }
        }

        private void FormDiagram_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.isFormDiagram = false;
            if (!isSelfStanding)
            {
                e.Cancel = true;
                this.Hide();
            }
            else
            {
                this.Dispose();
            }
        }

        private void CBYAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            YAxisIndex = CBYAxis.SelectedIndex;
            nPlottedData = 0;
            UpdateDiagram();
        }

        private void CBXAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            XAxisIndex = CBXAxis.SelectedIndex;
            nPlottedData = 0;
            UpdateDiagram();
        }

        private void UpdateDiagram()
        {
            if (Math.Abs(MinY - MaxY) < 0.000000001)
            {
                MinY = MinY - Math.Abs(MinY) / 20.0;
                MaxY = MaxY + Math.Abs(MaxY) / 20.0;
            }

            if (isDisconnectedFromSessionSource)
            {
                SelfStandingUpdateDiagram();
            }
            else
            {

                if (CBXAxis.SelectedIndex > -1 && CBYAxis.SelectedIndex > -1 && (SessionName.SelectedIndex > -1 || !SessionName.Visible))
                {
                    int nDate = Form1.AllSessionsData[PlotIndex].ReceivedDataCount;
                    bool isLogX = false;

                    if (Form1.AllSessions[PlotIndex].Mode == 2 || Form1.AllSessions[PlotIndex].Mode == 3 || Form1.AllSessions[PlotIndex].Mode == 4)
                    {
                        xArray = new double[nDate];
                        yArray = new double[nDate];
                        if (XAxisIndex == 0) for (int i = 0; i < nDate; i++) xArray[i] = Form1.AllSessionsData[PlotIndex].Vlt[i]; //NormalVoltPGCurrent
                        if (XAxisIndex == 1) for (int i = 0; i < nDate; i++) xArray[i] = Form1.AllSessionsData[PlotIndex].Amp[i]; //NormalCurrentPGVolt
                        if (XAxisIndex == 2) for (int i = 0; i < nDate; i++) xArray[i] = Form1.AllSessionsData[PlotIndex].ReZ[i]; //Time [sec]
                        if (XAxisIndex == 3) for (int i = 0; i < nDate; i++) xArray[i] = Form1.AllSessionsData[PlotIndex].Imz[i]; //NormalSetVoltPGSetCurrent

                        if (YAxisIndex == 0) for (int i = 0; i < nDate; i++) yArray[i] = Form1.AllSessionsData[PlotIndex].Vlt[i]; //NormalVoltPGCurrent
                        if (YAxisIndex == 1) for (int i = 0; i < nDate; i++) yArray[i] = Form1.AllSessionsData[PlotIndex].Amp[i]; //NormalCurrentPGVolt
                        if (YAxisIndex == 2) for (int i = 0; i < nDate; i++) yArray[i] = Form1.AllSessionsData[PlotIndex].ReZ[i]; //Time [sec]
                        if (YAxisIndex == 3) for (int i = 0; i < nDate; i++) yArray[i] = Form1.AllSessionsData[PlotIndex].Imz[i]; //NormalSetVoltPGSetCurrent
                        if (YAxisIndex == 4)
                            for (int i = 0; i < nDate; i++)
                            {
                                double x = Form1.AllSessionsData[PlotIndex].Amp[i];
                                if (x == 0) x = 0.00001;
                                yArray[i] = Math.Log(Math.Abs(x)); //Log(NormalCurrentPGVolt)
                            }
                        if (YAxisIndex == 5)
                            for (int i = 0; i < nDate; i++)
                            {
                                double x = Form1.AllSessionsData[PlotIndex].ReZ[i];
                                if (x == 0) x = 0.00001;
                                yArray[i] = Math.Log(Math.Abs(x)); //Log(Time [sec])
                            }

                        int narray = Form1.AllSessionsData[EIS.RunningSession].ReZ.Length;
                        if (XAxisIndex == 2) MinX = Form1.AllSessionsData[EIS.RunningSession].ReZ[0];
                        if (XAxisIndex == 2) MaxX = Form1.AllSessionsData[EIS.RunningSession].ReZ[narray - 1];
                        if (YAxisIndex == 2) MinY = Form1.AllSessionsData[EIS.RunningSession].ReZ[0];
                        if (YAxisIndex == 2) MaxY = Form1.AllSessionsData[EIS.RunningSession].ReZ[narray - 1];

                        if (Form1.AllSessions[PlotIndex].isFinished)
                        {
                            PlotIVLine(chart1, xArray, yArray,
                            nDate, isLogX, CBXAxis.SelectedItem.ToString(), CBYAxis.SelectedItem.ToString());
                        }
                        else
                        {
                            PlotIVPoint(chart1, xArray, yArray,
                            nDate, isLogX, CBXAxis.SelectedItem.ToString(), CBYAxis.SelectedItem.ToString());
                        }

                    }
                    else if (Form1.AllSessions[PlotIndex].Mode == 5)
                    {
                        xArray = new double[nDate];
                        yArray = new double[nDate];
                        if (XAxisIndex == 0) for (int i = 0; i < nDate; i++) xArray[i] = Form1.AllSessionsData[PlotIndex].Vlt[i]; //NormalVoltPGCurrent
                        if (XAxisIndex == 1) for (int i = 0; i < nDate; i++) xArray[i] = Form1.AllSessionsData[PlotIndex].Amp[i]; //NormalCurrentPGVolt
                        if (XAxisIndex == 2) for (int i = 0; i < nDate; i++) xArray[i] = Form1.AllSessionsData[PlotIndex].ReZ[i]; //Time [sec]
                        //if (XAxisIndex == 3) for (int i = 0; i < nDate; i++) xArray[i] = Form1.AllSessionsData[PlotIndex].Charge_SetV[i]; //NormalSetVoltPGSetCurrent

                        if (YAxisIndex == 0) for (int i = 0; i < nDate; i++) yArray[i] = Form1.AllSessionsData[PlotIndex].Vlt[i]; //NormalVoltPGCurrent
                        if (YAxisIndex == 1) for (int i = 0; i < nDate; i++) yArray[i] = Form1.AllSessionsData[PlotIndex].Amp[i]; //NormalCurrentPGVolt
                        if (YAxisIndex == 2) for (int i = 0; i < nDate; i++) yArray[i] = Form1.AllSessionsData[PlotIndex].ReZ[i]; //Time [sec]
                        //if (YAxisIndex == 3) for (int i = 0; i < nDate; i++) yArray[i] = Form1.AllSessionsData[PlotIndex].Charge_SetV[i]; //NormalSetVoltPGSetCurrent
                        if (YAxisIndex == 3)
                            for (int i = 0; i < nDate; i++)
                            {
                                double x = Form1.AllSessionsData[PlotIndex].Amp[i];
                                if (x == 0) x = 0.00001;
                                yArray[i] = Math.Log(Math.Abs(x)); //Log(NormalCurrentPGVolt)
                            }
                        if (YAxisIndex == 4)
                            for (int i = 0; i < nDate; i++)
                            {
                                double x = Form1.AllSessionsData[PlotIndex].ReZ[i];
                                if (x == 0) x = 0.00001;
                                yArray[i] = Math.Log(Math.Abs(x)); //Log(Time [sec])
                            }

                        int narray = Form1.AllSessionsData[EIS.RunningSession].ReZ.Length;
                        if (XAxisIndex == 2) MinX = Form1.AllSessionsData[EIS.RunningSession].ReZ[0];
                        if (YAxisIndex == 2) MinY = Form1.AllSessionsData[EIS.RunningSession].ReZ[0];
                        if (nDate > 1)
                        {
                            if (XAxisIndex == 2) MaxX = Form1.AllSessionsData[EIS.RunningSession].ReZ[nDate - 1];
                            if (YAxisIndex == 2) MaxY = Form1.AllSessionsData[EIS.RunningSession].ReZ[nDate - 1];
                        }
                        else
                        {
                            if (XAxisIndex == 2) MaxX = Form1.AllSessionsData[EIS.RunningSession].ReZ[0];
                            if (YAxisIndex == 2) MaxY = Form1.AllSessionsData[EIS.RunningSession].ReZ[0];
                        }

                        if (Form1.AllSessions[PlotIndex].isFinished)
                        {
                            PlotIVLine(chart1, xArray, yArray,
                            nDate, isLogX, CBXAxis.SelectedItem.ToString(), CBYAxis.SelectedItem.ToString());
                        }
                        else
                        {
                            PlotIVPoint(chart1, xArray, yArray,
                            nDate, isLogX, CBXAxis.SelectedItem.ToString(), CBYAxis.SelectedItem.ToString());
                        }

                    }
                    else
                    {
                        if (XAxisIndex == 0)
                        {
                            if (Form1.AllSessions[PlotIndex].Mode == 0)
                            {
                                /*double frqMultStep = Math.Pow(Form1.AllSessions[PlotIndex].ACFrqTo / Form1.AllSessions[PlotIndex].ACFrqFrom, 1.0 / (Form1.AllSessions[PlotIndex].ACFrqNStep - 1));
                                xArray = new double[nDate];
                                double frq = Form1.AllSessions[PlotIndex].ACFrqFrom;
                                for (int i = 0; i < nDate; i++)
                                {
                                    xArray[i] = frq;
                                    frq = frq * frqMultStep;
                                }*/
                                xArray = new double[nDate];
                                for (int i = 0; i < nDate; i++)
                                {
                                    xArray[i] = Form1.AllSessionsData[PlotIndex].Frq[i];
                                }
                                isLogX = true;
                            }

                            if (Form1.AllSessions[PlotIndex].Mode == 1)
                            {
                                /*double frqMultStep = Math.Pow(Form1.AllSessions[PlotIndex].ACFrqTo / Form1.AllSessions[PlotIndex].ACFrqFrom, 1.0 / (Form1.AllSessions[PlotIndex].ACFrqNStep - 1));
                                xArray = new double[nDate];
                                double frq = Form1.AllSessions[PlotIndex].ACFrqFrom;
                                for (int i = 0; i < nDate; i++)
                                {
                                    xArray[i] = frq;
                                    frq = frq * frqMultStep;
                                }*/
                                xArray = new double[nDate];
                                for (int i = 0; i < nDate; i++)
                                {
                                    xArray[i] = Form1.AllSessionsData[PlotIndex].Vlt[i];
                                }
                                isLogX = false;
                            }


                        }

                        if (XAxisIndex == 1)
                        {
                            xArray = new double[nDate];
                            for (int i = 0; i < nDate; i++)
                            {
                                xArray[i] = Form1.AllSessionsData[PlotIndex].ReZ[i];
                            }
                        }

                        if (XAxisIndex == 2)
                        {
                            xArray = new double[nDate];
                            for (int i = 0; i < nDate; i++)
                            {
                                xArray[i] = -Form1.AllSessionsData[PlotIndex].Imz[i];
                            }
                        }

                        if (XAxisIndex == 3)
                        {
                            xArray = new double[nDate];
                            for (int i = 0; i < nDate; i++)
                            {
                                xArray[i] = Math.Sqrt(Math.Pow(Form1.AllSessionsData[PlotIndex].ReZ[i], 2.0) + Math.Pow(Form1.AllSessionsData[PlotIndex].Imz[i], 2.0));
                            }
                        }

                        if (XAxisIndex == 4)
                        {
                            xArray = new double[nDate];
                            for (int i = 0; i < nDate; i++)
                            {
                                xArray[i] = Math.Atan2(Form1.AllSessionsData[PlotIndex].Imz[i], Form1.AllSessionsData[PlotIndex].ReZ[i]);
                            }
                        }

                        if (YAxisIndex == 0)
                        {
                            if (Form1.AllSessions[PlotIndex].Mode == 0)
                            {
                                PlotImpedanceReIm(chart1, Form1.AllSessionsData[PlotIndex].overflow, Form1.AllSessionsData[PlotIndex].Frq, Form1.AllSessionsData[PlotIndex].ReZ, Form1.AllSessionsData[PlotIndex].Imz,
                                nDate, isLogX, CBXAxis.SelectedItem.ToString(), CBYAxis.SelectedItem.ToString());
                            }

                            if (Form1.AllSessions[PlotIndex].Mode == 1)
                            {
                                PlotMotShatkiC2Inv(chart1, Form1.AllSessionsData[PlotIndex].overflow, Form1.AllSessionsData[PlotIndex].Vlt, Form1.AllSessions[PlotIndex].ACFrqConstant, Form1.AllSessionsData[PlotIndex].Imz,
                                nDate, isLogX, CBXAxis.SelectedItem.ToString(), CBYAxis.SelectedItem.ToString());
                            }

                            if (Form1.AllSessions[PlotIndex].Mode == 2 || Form1.AllSessions[PlotIndex].Mode == 3 || Form1.AllSessions[PlotIndex].Mode == 4)
                            {
                                if (Form1.AllSessions[PlotIndex].isFinished)
                                {
                                    PlotIVLine(chart1, Form1.AllSessionsData[PlotIndex].Vlt, Form1.AllSessionsData[PlotIndex].Amp,
                                    nDate, isLogX, CBXAxis.SelectedItem.ToString(), CBYAxis.SelectedItem.ToString());
                                }
                                else
                                {
                                    PlotIVPoint(chart1, Form1.AllSessionsData[PlotIndex].Vlt, Form1.AllSessionsData[PlotIndex].Amp,
                                    nDate, isLogX, CBXAxis.SelectedItem.ToString(), CBYAxis.SelectedItem.ToString());
                                }





                                //To Debug
                                //double[] cntarray = new double[nDate];
                                //for (int ii = 0; ii < nDate; ii++) cntarray[ii] = 1.0 * ii;
                                //PlotIV(chart1, cntarray, Form1.AllSessionsData[PlotIndex].Vlt,
                                //nDate, isLogX, CBXAxis.SelectedItem.ToString(), CBYAxis.SelectedItem.ToString());
                            }
                        }

                        if (YAxisIndex == 1)
                        {
                            if (Form1.AllSessions[PlotIndex].Mode == 0) PlotImpedanceRe(chart1, Form1.AllSessionsData[PlotIndex].overflow, xArray, Form1.AllSessionsData[PlotIndex].ReZ,
                            nDate, isLogX, CBXAxis.SelectedItem.ToString(), CBYAxis.SelectedItem.ToString());

                            if (Form1.AllSessions[PlotIndex].Mode == 1) PlotMatshatkiCurrent(chart1, Form1.AllSessionsData[PlotIndex].overflow, xArray, Form1.AllSessionsData[PlotIndex].Amp,
                            nDate, isLogX, CBXAxis.SelectedItem.ToString(), CBYAxis.SelectedItem.ToString());
                        }

                        if (YAxisIndex == 2)
                        {
                            double[] MinusImZ = new double[Form1.AllSessionsData[PlotIndex].Imz.Length];
                            for (int i = 0; i < Form1.AllSessionsData[PlotIndex].Imz.Length; i++)
                                MinusImZ[i] = -Form1.AllSessionsData[PlotIndex].Imz[i];

                            if (Form1.AllSessions[PlotIndex].Mode == 0) PlotImpedanceIm(chart1, Form1.AllSessionsData[PlotIndex].overflow, xArray, MinusImZ,
                            nDate, isLogX, CBXAxis.SelectedItem.ToString(), CBYAxis.SelectedItem.ToString());

                            if (Form1.AllSessions[PlotIndex].Mode == 1) PlotImpedanceRe(chart1, Form1.AllSessionsData[PlotIndex].overflow, xArray, Form1.AllSessionsData[PlotIndex].ReZ,
                            nDate, isLogX, CBXAxis.SelectedItem.ToString(), CBYAxis.SelectedItem.ToString());
                        }

                        if (YAxisIndex == 3)
                        {
                            if (Form1.AllSessions[PlotIndex].Mode == 0)
                            {
                                double[] yArray = new double[nDate];
                                for (int i = 0; i < nDate; i++)
                                {
                                    yArray[i] = Math.Sqrt(Math.Pow(Form1.AllSessionsData[PlotIndex].ReZ[i], 2.0) + Math.Pow(Form1.AllSessionsData[PlotIndex].Imz[i], 2.0));
                                }
                                PlotImpedanceRadius(chart1, Form1.AllSessionsData[PlotIndex].overflow, xArray, yArray,
                                nDate, isLogX, CBXAxis.SelectedItem.ToString(), CBYAxis.SelectedItem.ToString());
                            }

                            if (Form1.AllSessions[PlotIndex].Mode == 1) PlotImpedanceIm(chart1, Form1.AllSessionsData[PlotIndex].overflow, xArray, Form1.AllSessionsData[PlotIndex].Imz,
                            nDate, isLogX, CBXAxis.SelectedItem.ToString(), CBYAxis.SelectedItem.ToString());
                        }

                        if (YAxisIndex == 4)
                        {
                            if (Form1.AllSessions[PlotIndex].Mode == 0)
                            {
                                double[] yArray = new double[nDate];
                                for (int i = 0; i < nDate; i++)
                                {
                                    yArray[i] = Math.Atan2(Form1.AllSessionsData[PlotIndex].Imz[i], Form1.AllSessionsData[PlotIndex].ReZ[i]);
                                }
                                PlotImpedanceTheta(chart1, Form1.AllSessionsData[PlotIndex].overflow, xArray, yArray,
                                nDate, isLogX, CBXAxis.SelectedItem.ToString(), CBYAxis.SelectedItem.ToString());
                            }

                            if (Form1.AllSessions[PlotIndex].Mode == 1)
                            {
                                double[] yArray = new double[nDate];
                                for (int i = 0; i < nDate; i++)
                                {
                                    yArray[i] = Math.Sqrt(Math.Pow(Form1.AllSessionsData[PlotIndex].ReZ[i], 2.0) + Math.Pow(Form1.AllSessionsData[PlotIndex].Imz[i], 2.0));
                                }
                                PlotImpedanceRadius(chart1, Form1.AllSessionsData[PlotIndex].overflow, xArray, yArray,
                                nDate, isLogX, CBXAxis.SelectedItem.ToString(), CBYAxis.SelectedItem.ToString());
                            }
                        }

                        if (YAxisIndex == 5)
                        {
                            if (Form1.AllSessions[PlotIndex].Mode == 1)
                            {
                                double[] yArray = new double[nDate];
                                for (int i = 0; i < nDate; i++)
                                {
                                    yArray[i] = Math.Atan2(Form1.AllSessionsData[PlotIndex].Imz[i], Form1.AllSessionsData[PlotIndex].ReZ[i]);
                                }
                                PlotImpedanceTheta(chart1, Form1.AllSessionsData[PlotIndex].overflow, xArray, yArray,
                                nDate, isLogX, CBXAxis.SelectedItem.ToString(), CBYAxis.SelectedItem.ToString());
                            }
                        }
                    }
                }
            }
        }

        private void SelfStandingInitializeDiagram(Chart chart, double[] Vlt, double[] Amp, int npoints, bool isLogX, string XAxisName, string YAxisName)
        {
            if (npoints > 0)
            {
                ClearPlot(chart);
                if (isSelfStanding)
                {
                    chart.ChartAreas[0].AxisX.IsMarginVisible = true;
                    chart.ChartAreas[0].AxisX.Maximum = MaxX;
                    chart.ChartAreas[0].AxisX.Minimum = MinX;
                    chart.ChartAreas[0].AxisY.Maximum = MaxY * Yfactor;
                    chart.ChartAreas[0].AxisY.Minimum = MinY * Yfactor;
                    chart.ChartAreas[0].AxisX.Interval = Math.Floor((MaxX - MinX)) / 10;
                }

                if (!Form1.AllSessions[PlotIndex].isCVEnable)
                {
                    if (npoints > 0 && isLogX)
                        chart.ChartAreas[0].AxisX.IsLogarithmic = true;
                    else
                        chart.ChartAreas[0].AxisX.IsLogarithmic = false;
                    AddSeries(chart, "I(V)", XAxisName, YAxisName, Color.Blue);
                    AddSeries(chart, "", "", "", Color.Red); AddPoint(chart, 1, MinX * 10, 0); AddPoint(chart, 1, MaxX * 10, 0);
                    AddSeries(chart, "", "", "", Color.Red); AddPoint(chart, 2, 0, MinY * 10 * Yfactor); AddPoint(chart, 2, 0, MaxY * 10 * Yfactor);
                    chart.Series[0].ChartType = SeriesChartType.Point;
                    chart.Series[0].MarkerStyle = MarkerStyle.None;
                    /* if (isSelfStanding)
                     {
                         chart.ChartAreas[0].AxisX.IsMarginVisible = false;
                         chart.ChartAreas[0].AxisX.Maximum = MaxX;
                         chart.ChartAreas[0].AxisX.Minimum = MinX;
                         chart.ChartAreas[0].AxisY.Maximum = MaxY * Yfactor;
                         chart.ChartAreas[0].AxisY.Minimum = MinY * Yfactor;
                     }*/

                    for (int i = 0; i < npoints; i++)
                    {
                        AddPoint(chart, 0, Vlt[i], Amp[i] * Yfactor);
                    }
                }
                else
                {
                    int CVnFirst = (int)((Form1.AllSessions[PlotIndex].IVvoltageTo - Form1.AllSessions[PlotIndex].CVStartpoint) / (Form1.AllSessions[PlotIndex].IVvoltageTo - Form1.AllSessions[PlotIndex].IVVoltageFrom) * (Form1.AllSessions[PlotIndex].IVVoltageNStepp - 1)) + 1;
                    if (npoints > 0 && isLogX)
                        chart.ChartAreas[0].AxisX.IsLogarithmic = true;
                    else
                        chart.ChartAreas[0].AxisX.IsLogarithmic = false;
                    AddSeries(chart, "I(V) 1", XAxisName, YAxisName, Color.Blue);
                    chart.Series[0].ChartType = SeriesChartType.Point;
                    chart.Series[0].MarkerStyle = MarkerStyle.None;

                    for (int i = 0; i < CVnFirst; i++)
                    {
                        AddPoint(chart, 0, Vlt[i], Amp[i] * Yfactor);
                    }

                    for (int ic = 0; ic < Form1.AllSessions[PlotIndex].CVItteration; ic++)
                    {
                        for (int jc = 0; jc < 2; jc++)
                        {
                            int it = ic * 2 + jc;
                            //int mynpoints = (it + 1) * Form1.AllSessions[PlotIndex].IVVoltageNStepp - 1;
                            int mynpoints = npoints - it * Form1.AllSessions[PlotIndex].IVVoltageNStepp;
                            if (mynpoints > Form1.AllSessions[PlotIndex].IVVoltageNStepp) mynpoints = Form1.AllSessions[PlotIndex].IVVoltageNStepp;
                            if (mynpoints > 0)
                            {
                                if (mynpoints > 0 && isLogX)
                                    chart.ChartAreas[0].AxisX.IsLogarithmic = true;
                                else
                                    chart.ChartAreas[0].AxisX.IsLogarithmic = false;
                                AddSeries(chart, "I(V) " + (it + 1).ToString(), XAxisName, YAxisName, GetCVColor(ic));
                                chart.Series[it].ChartType = SeriesChartType.Point;
                                chart.Series[it].MarkerStyle = MarkerStyle.None;
                                /* if (isSelfStanding)
                                 {
                                     chart.ChartAreas[0].AxisX.IsMarginVisible = false;
                                     chart.ChartAreas[0].AxisX.Maximum = MaxX;
                                     chart.ChartAreas[0].AxisX.Minimum = MinX;
                                     chart.ChartAreas[0].AxisY.Maximum = MaxY * Yfactor;
                                     chart.ChartAreas[0].AxisY.Minimum = MinY * Yfactor;
                                 }*/

                                for (int i = it * Form1.AllSessions[PlotIndex].IVVoltageNStepp; i < it * Form1.AllSessions[PlotIndex].IVVoltageNStepp + mynpoints; i++)
                                {
                                    AddPoint(chart, it, Vlt[i], Amp[i] * Yfactor);
                                }
                            }
                        }
                    }
                    AddSeries(chart, "", "", "", Color.Red); AddPoint(chart, chart.Series.Count - 1, MinX*10, 0); AddPoint(chart, chart.Series.Count - 1, MaxX * 10, 0);
                    AddSeries(chart, "", "", "", Color.Red); AddPoint(chart, chart.Series.Count - 1, 0, MinY * 10 * Yfactor); AddPoint(chart, chart.Series.Count - 1, 0, MaxY * 10 * Yfactor);
                }
            }
        }


        private void SelfStandingUpdateDiagram()
        {

            if (CBXAxis.SelectedIndex > -1 && CBYAxis.SelectedIndex > -1 && (SessionName.SelectedIndex > -1 || !SessionName.Visible))
            {
                int nDate = SelfStandingSessionData.ReceivedDataCount;
                bool isLogX = false;

                if (Form1.AllSessions[PlotIndex].Mode == 2 || Form1.AllSessions[PlotIndex].Mode == 3 || Form1.AllSessions[PlotIndex].Mode == 4)
                {
                    xArray = new double[nDate];
                    yArray = new double[nDate];
                    if (XAxisIndex == 0) for (int i = 0; i < nDate; i++) xArray[i] = SelfStandingSessionData.Vlt[i];
                    if (XAxisIndex == 1) for (int i = 0; i < nDate; i++) xArray[i] = SelfStandingSessionData.Amp[i];
                    if (XAxisIndex == 2) for (int i = 0; i < nDate; i++) xArray[i] = SelfStandingSessionData.ReZ[i];
                    if (XAxisIndex == 3) for (int i = 0; i < nDate; i++) xArray[i] = SelfStandingSessionData.Imz[i];

                    if (YAxisIndex == 0) for (int i = 0; i < nDate; i++) yArray[i] = SelfStandingSessionData.Vlt[i];
                    if (YAxisIndex == 1) for (int i = 0; i < nDate; i++) yArray[i] = SelfStandingSessionData.Amp[i];
                    if (YAxisIndex == 2) for (int i = 0; i < nDate; i++) yArray[i] = SelfStandingSessionData.ReZ[i];
                    if (YAxisIndex == 3) for (int i = 0; i < nDate; i++) yArray[i] = SelfStandingSessionData.Imz[i];

                    if (YAxisIndex == 4)
                        for (int i = 0; i < nDate; i++)
                        {
                            double x = SelfStandingSessionData.Amp[i];
                            if (x == 0) x = 0.00001;
                            yArray[i] = Math.Log(Math.Abs(x)); //Log(NormalCurrentPGVolt)
                        }
                    if (YAxisIndex == 5)
                        for (int i = 0; i < nDate; i++)
                        {
                            double x = SelfStandingSessionData.ReZ[i];
                            if (x == 0) x = 0.00001;
                            yArray[i] = Math.Log(Math.Abs(x)); //Log(Time [sec])
                        }

                    PlotIVLine(chart1, xArray, yArray,
                        nDate, isLogX, CBXAxis.SelectedItem.ToString(), CBYAxis.SelectedItem.ToString());

                    /*if (Form1.AllSessions[PlotIndex].isFinished)
                    {
                        PlotIVLine(chart1, xArray, yArray,
                        nDate, isLogX, CBXAxis.SelectedItem.ToString(), CBYAxis.SelectedItem.ToString());
                    }
                    else
                    {
                        PlotIVPoint(chart1, xArray, yArray,
                        nDate, isLogX, CBXAxis.SelectedItem.ToString(), CBYAxis.SelectedItem.ToString());
                    }*/
                }
                else if (Form1.AllSessions[PlotIndex].Mode == 5)
                {
                    xArray = new double[nDate];
                    yArray = new double[nDate];
                    if (XAxisIndex == 0) for (int i = 0; i < nDate; i++) xArray[i] = SelfStandingSessionData.Vlt[i]; //NormalVoltPGCurrent
                    if (XAxisIndex == 1) for (int i = 0; i < nDate; i++) xArray[i] = SelfStandingSessionData.Amp[i]; //NormalCurrentPGVolt
                    if (XAxisIndex == 2) for (int i = 0; i < nDate; i++) xArray[i] = SelfStandingSessionData.ReZ[i]; //Time [sec]
                                                                                                                                   //if (XAxisIndex == 3) for (int i = 0; i < nDate; i++) xArray[i] = Form1.AllSessionsData[PlotIndex].Charge_SetV[i]; //NormalSetVoltPGSetCurrent

                    if (YAxisIndex == 0) for (int i = 0; i < nDate; i++) yArray[i] = SelfStandingSessionData.Vlt[i]; //NormalVoltPGCurrent
                    if (YAxisIndex == 1) for (int i = 0; i < nDate; i++) yArray[i] = SelfStandingSessionData.Amp[i]; //NormalCurrentPGVolt
                    if (YAxisIndex == 2) for (int i = 0; i < nDate; i++) yArray[i] = SelfStandingSessionData.ReZ[i]; //Time [sec]
                                                                                                                                   //if (YAxisIndex == 3) for (int i = 0; i < nDate; i++) yArray[i] = Form1.AllSessionsData[PlotIndex].Charge_SetV[i]; //NormalSetVoltPGSetCurrent
                    if (YAxisIndex == 3)
                        for (int i = 0; i < nDate; i++)
                        {
                            double x = SelfStandingSessionData.Amp[i];
                            if (x == 0) x = 0.00001;
                            yArray[i] = Math.Log(Math.Abs(x)); //Log(NormalCurrentPGVolt)
                        }
                    if (YAxisIndex == 4)
                        for (int i = 0; i < nDate; i++)
                        {
                            double x = SelfStandingSessionData.ReZ[i];
                            if (x == 0) x = 0.00001;
                            yArray[i] = Math.Log(Math.Abs(x)); //Log(Time [sec])
                        }

                    PlotIVLine(chart1, xArray, yArray,
                        nDate, isLogX, CBXAxis.SelectedItem.ToString(), CBYAxis.SelectedItem.ToString());

                    /*if (Form1.AllSessions[PlotIndex].isFinished)
                    {
                       PlotIVLine(chart1, xArray, yArray,
                        nDate, isLogX, CBXAxis.SelectedItem.ToString(), CBYAxis.SelectedItem.ToString()); 
                    }
                    else
                    {
                        PlotIVPoint(chart1, xArray, yArray,
                        nDate, isLogX, CBXAxis.SelectedItem.ToString(), CBYAxis.SelectedItem.ToString());
                    }*/

                }
                else
                {
                    if (XAxisIndex == 0)
                    {
                        if (SelfStandingSession.Mode == 0)
                        {
                            xArray = new double[nDate];
                            for (int i = 0; i < nDate; i++)
                            {
                                xArray[i] = SelfStandingSessionData.Frq[i];
                            }
                            isLogX = true;
                        }

                        if (SelfStandingSession.Mode == 1)
                        {
                            xArray = new double[nDate];
                            for (int i = 0; i < nDate; i++)
                            {
                                xArray[i] = SelfStandingSessionData.Vlt[i];
                            }
                            isLogX = false;
                        }
                    }

                    if (XAxisIndex == 1)
                    {
                        xArray = new double[nDate];
                        for (int i = 0; i < nDate; i++)
                        {
                            xArray[i] = SelfStandingSessionData.ReZ[i];
                        }
                    }

                    if (XAxisIndex == 2)
                    {
                        xArray = new double[nDate];
                        for (int i = 0; i < nDate; i++)
                        {
                            xArray[i] = SelfStandingSessionData.Imz[i];
                        }
                    }

                    if (XAxisIndex == 3)
                    {
                        xArray = new double[nDate];
                        for (int i = 0; i < nDate; i++)
                        {
                            xArray[i] = Math.Sqrt(Math.Pow(SelfStandingSessionData.ReZ[i], 2.0) + Math.Pow(SelfStandingSessionData.Imz[i], 2.0));
                        }
                    }

                    if (XAxisIndex == 4)
                    {
                        xArray = new double[nDate];
                        for (int i = 0; i < nDate; i++)
                        {
                            xArray[i] = Math.Atan2(SelfStandingSessionData.Imz[i], SelfStandingSessionData.ReZ[i]);
                        }
                    }

                    if (YAxisIndex == 0)
                    {
                        if (SelfStandingSession.Mode == 0)
                        {
                            PlotImpedanceReIm(chart1, SelfStandingSessionData.overflow, SelfStandingSessionData.Frq, SelfStandingSessionData.ReZ, SelfStandingSessionData.Imz,
                            nDate, isLogX, CBXAxis.SelectedItem.ToString(), CBYAxis.SelectedItem.ToString());
                        }

                        if (SelfStandingSession.Mode == 1)
                        {
                            PlotMotShatkiC2Inv(chart1, SelfStandingSessionData.overflow, SelfStandingSessionData.Vlt, SelfStandingSession.ACFrqConstant, SelfStandingSessionData.Imz,
                            nDate, isLogX, CBXAxis.SelectedItem.ToString(), CBYAxis.SelectedItem.ToString());
                        }

                        if (SelfStandingSession.Mode == 2 || SelfStandingSession.Mode == 3 || SelfStandingSession.Mode == 4)
                        {
                            if (SelfStandingSession.isFinished)
                            {
                                PlotIVLine(chart1, SelfStandingSessionData.Vlt, SelfStandingSessionData.Amp,
                                nDate, isLogX, CBXAxis.SelectedItem.ToString(), CBYAxis.SelectedItem.ToString());
                            }
                            else
                            {
                                PlotIVPoint(chart1, SelfStandingSessionData.Vlt, SelfStandingSessionData.Amp,
                                nDate, isLogX, CBXAxis.SelectedItem.ToString(), CBYAxis.SelectedItem.ToString());
                            }

                        }
                    }

                    if (YAxisIndex == 1)
                    {
                        if (SelfStandingSession.Mode == 0) PlotImpedanceRe(chart1, SelfStandingSessionData.overflow, xArray, SelfStandingSessionData.ReZ,
                            nDate, isLogX, CBXAxis.SelectedItem.ToString(), CBYAxis.SelectedItem.ToString());

                        if (SelfStandingSession.Mode == 1) PlotMatshatkiCurrent(chart1, SelfStandingSessionData.overflow, xArray, SelfStandingSessionData.Amp,
                            nDate, isLogX, CBXAxis.SelectedItem.ToString(), CBYAxis.SelectedItem.ToString());
                    }

                    if (YAxisIndex == 2)
                    {
                        if (SelfStandingSession.Mode == 0) PlotImpedanceIm(chart1, SelfStandingSessionData.overflow, xArray, SelfStandingSessionData.Imz,
                        nDate, isLogX, CBXAxis.SelectedItem.ToString(), CBYAxis.SelectedItem.ToString());

                        if (SelfStandingSession.Mode == 1) PlotImpedanceRe(chart1, SelfStandingSessionData.overflow, xArray, SelfStandingSessionData.ReZ,
                            nDate, isLogX, CBXAxis.SelectedItem.ToString(), CBYAxis.SelectedItem.ToString());
                    }

                    if (YAxisIndex == 3)
                    {
                        if (SelfStandingSession.Mode == 0)
                        {
                            double[] yArray = new double[nDate];
                            for (int i = 0; i < nDate; i++)
                            {
                                yArray[i] = Math.Sqrt(Math.Pow(SelfStandingSessionData.ReZ[i], 2.0) + Math.Pow(SelfStandingSessionData.Imz[i], 2.0));
                            }
                            PlotImpedanceRadius(chart1, SelfStandingSessionData.overflow, xArray, yArray,
                            nDate, isLogX, CBXAxis.SelectedItem.ToString(), CBYAxis.SelectedItem.ToString());
                        }

                        if (SelfStandingSession.Mode == 1) PlotImpedanceIm(chart1, SelfStandingSessionData.overflow, xArray, SelfStandingSessionData.Imz,
                        nDate, isLogX, CBXAxis.SelectedItem.ToString(), CBYAxis.SelectedItem.ToString());
                    }

                    if (YAxisIndex == 4)
                    {
                        if (SelfStandingSession.Mode == 0)
                        {
                            double[] yArray = new double[nDate];
                            for (int i = 0; i < nDate; i++)
                            {
                                yArray[i] = Math.Atan2(SelfStandingSessionData.Imz[i], SelfStandingSessionData.ReZ[i]);
                            }
                            PlotImpedanceTheta(chart1, SelfStandingSessionData.overflow, xArray, yArray,
                            nDate, isLogX, CBXAxis.SelectedItem.ToString(), CBYAxis.SelectedItem.ToString());
                        }

                        if (SelfStandingSession.Mode == 1)
                        {
                            double[] yArray = new double[nDate];
                            for (int i = 0; i < nDate; i++)
                            {
                                yArray[i] = Math.Sqrt(Math.Pow(SelfStandingSessionData.ReZ[i], 2.0) + Math.Pow(SelfStandingSessionData.Imz[i], 2.0));
                            }
                            PlotImpedanceRadius(chart1, SelfStandingSessionData.overflow, xArray, yArray,
                            nDate, isLogX, CBXAxis.SelectedItem.ToString(), CBYAxis.SelectedItem.ToString());
                        }
                    }

                    if (YAxisIndex == 5)
                    {
                        if (SelfStandingSession.Mode == 1)
                        {
                            double[] yArray = new double[nDate];
                            for (int i = 0; i < nDate; i++)
                            {
                                yArray[i] = Math.Atan2(SelfStandingSessionData.Imz[i], SelfStandingSessionData.ReZ[i]);
                            }
                            PlotImpedanceTheta(chart1, SelfStandingSessionData.overflow, xArray, yArray,
                            nDate, isLogX, CBXAxis.SelectedItem.ToString(), CBYAxis.SelectedItem.ToString());
                        }
                    }
                }
            }
        }

        private void SetXAxis(Chart chart, double min, double max)
        {
            if (min == max)
            {
                min = min - .01;
                max = max + .01;
            }

            double Min = Math.Min(min, max);
            double Max = Math.Max(min, max);

            double delta = (Max - Min) / 10;

            if (Min * Max < 0)
            {
                double f = Math.Pow(10, (int)(Math.Floor(Math.Log10(delta))));
                delta = (double)((int)(delta / f)) * f;
                int n = (int)(-Min / delta) + 1;
                chart.ChartAreas[0].AxisX.Minimum = -n * delta;
            }
            else
                chart.ChartAreas[0].AxisX.Minimum = Min;

            chart.ChartAreas[0].AxisX.Interval = delta;
        }

        private void CBIUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            if (PlotIndex != -1)
            {
                if (CBIUnit.SelectedIndex == 0)
                    Yfactor = 1000000.0;
                else if (CBIUnit.SelectedIndex == 1)
                    Yfactor = 1000.0;
                else if (CBIUnit.SelectedIndex == 2)
                    Yfactor = 1.0;
                else if (CBIUnit.SelectedIndex == 3)
                    Yfactor = 0.001;
                else if (CBIUnit.SelectedIndex == 4)
                    Yfactor = 0.000001;

                nPlottedData = 0;
                UpdateDiagram();
            }
        }

        private void BtnExportData_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Data files (*.dat)|*.dat";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                int nData = chart1.Series[0].Points.Count;
                ExportData(nData, chart1.Series, saveFileDialog1.FileName, Form1.AllSessions[PlotIndex].Mode);
            }
        }

        private void ExportData(int nData, SeriesCollection s, string Path, int mode)
        {
            try
            {
                StreamWriter FileProtocol = new StreamWriter(Path);
                int nSerries = s.Count;

                if (isDisconnectedFromSessionSource)
                {
                    if (SelfStandingSession.Mode == 2 || SelfStandingSession.Mode == 3 || SelfStandingSession.Mode == 4) nSerries = nSerries - 2;
                }
                else
                {
                    if (Form1.AllSessions[PlotIndex].Mode == 2 || Form1.AllSessions[PlotIndex].Mode == 3 || Form1.AllSessions[PlotIndex].Mode == 4) nSerries = nSerries - 2;
                }

                String line = "";
                for (int iser = 0; iser < nSerries; iser++)
                {
                    for (int i = 0; i < nData; i++)
                    {
                        line = s[iser].Points[i].XValue.ToString() + "\t" + s[iser].Points[i].YValues[0].ToString().ToString() + "\n";
                        FileProtocol.Write(line);
                    }
                    line = "\n";
                    FileProtocol.Write(line);
                }
                FileProtocol.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error in writing to file ...");
            }
        }

        private void ReportData(int nData, Sessions Sess, SessionOutputData SessD, SeriesCollection s, string Path, int mode)
        {
            try
            {
                StreamWriter FileProtocol = new StreamWriter(Path);
                int nSerries = s.Count;
                string pgArg = "Voltage";
                string pgUnit = "(Volt)";
                if (Sess.PGmode == 3)
                {
                    pgArg = "Current";
                    pgUnit = "(Amper)";
                }

                FileProtocol.Write("Session name: " + Sess.name + "\n");
                FileProtocol.Write(Sess.DataAndTime + "\n");
                if (Sess.Mode == 2 || Sess.Mode == 3 || Sess.Mode == 4) nSerries = nSerries - 2;
                if (Sess.Mode == 0)
                {
                    FileProtocol.Write("Type: EIS\n");
                    FileProtocol.Write("Equilibration time: " + Sess.EqTime + "\n");
                    if (Sess.PGmode == 3)
                        FileProtocol.Write("Current: " + Sess.DCVoltageConstant + "(Amper)\n");
                    else
                        FileProtocol.Write("DC Voltage: " + Sess.DCVoltageConstant + "(Volt)\n");
                    FileProtocol.Write("AC Voltage: " + Sess.ACAmpConstant + "(mV)\n");
                    FileProtocol.Write("Frequency Start: " + Sess.ACFrqFrom + "(Hz)\n");
                    FileProtocol.Write("Frequency End: " + Sess.ACFrqTo + "(Hz)\n");
                    FileProtocol.Write("Number of Steps: " + Sess.ACFrqNStep + "(Hz)\n");
                }
                if (Sess.Mode == 1)
                {
                    FileProtocol.Write("Type: Mott Schotkey\n");
                    FileProtocol.Write("Equilibration time: " + Sess.EqTime + "\n");
                    FileProtocol.Write("Frequency: " + Sess.ACFrqConstant + "(Hz)\n");
                    FileProtocol.Write("AC Voltage: " + Sess.ACAmpConstant + "(mV)\n");
                    FileProtocol.Write(pgArg + " Start: " + Sess.DCVoltageFrom + pgUnit + "\n");
                    FileProtocol.Write(pgArg + " End: " + Sess.DCVoltageTo + pgUnit + "\n");
                    FileProtocol.Write("Number of Steps: " + Sess.ACFrqNStep + "\n");
                }
                if (Sess.Mode == 2)
                {
                    FileProtocol.Write("Type: Chronoamperometry\n");
                    FileProtocol.Write("Equilibration time: " + Sess.EqTime + "\n");
                    FileProtocol.Write(pgArg + ": " + Sess.IVVoltageFrom + pgUnit + "\n");
                    FileProtocol.Write("Time Start: 0\n");
                    FileProtocol.Write("Time End: " + Sess.ChronoEndTime + "(sec)\n");
                    FileProtocol.Write("Number of Steps: " + Sess.IVVoltageNStepp + "\n");
                }
                if (Sess.Mode == 3)
                {
                    if (Sess.isCVEnable)
                        FileProtocol.Write("Type: C-V\n");
                    else
                        FileProtocol.Write("Type: Linear sweep\n");
                    FileProtocol.Write("Equilibration time: " + Sess.EqTime + "\n");
                    FileProtocol.Write(pgArg + " Start: " + Sess.IVVoltageFrom + pgUnit + "\n");
                    FileProtocol.Write(pgArg + " End: " + Sess.IVvoltageTo + pgUnit + "\n");
                    double vel = 1000.0 * (Math.Abs(Sess.IVvoltageTo - Sess.IVVoltageFrom) / Sess.IVVoltageNStepp / Sess.IVTimestep);
                    FileProtocol.Write("Velocity: " + vel + "(V/s)\n");
                    FileProtocol.Write("Time step: " + Sess.IVTimestep + "(ms)\n");
                    if (Sess.isCVEnable)
                    {
                        FileProtocol.Write("Start point: " + Sess.CVStartpoint + "\n");
                        FileProtocol.Write("Itteration: " + Sess.CVItteration + "\n");
                    }
                }
                if (Sess.Mode == 4)
                {
                    FileProtocol.Write("Type: Pulse\n");
                    FileProtocol.Write("Equilibration time: " + Sess.EqTime + "\n");
                    FileProtocol.Write(pgArg + " Start: " + Sess.IVVoltageFrom + pgUnit + "\n");
                    FileProtocol.Write(pgArg + " End: " + Sess.IVvoltageTo + pgUnit + "\n");
                    double vel = 1000.0 * (Math.Abs(Sess.IVvoltageTo - Sess.IVVoltageFrom) / Sess.IVVoltageNStepp / Sess.IVTimestep);
                    FileProtocol.Write("Velocity: " + vel + "(V/s)\n");
                    FileProtocol.Write("Time step: " + Sess.IVTimestep + "(ms)\n");
                    if (Sess.isCVEnable)
                    {
                        FileProtocol.Write("Start point: " + Sess.CVStartpoint + "\n");
                        FileProtocol.Write("Itteration: " + Sess.CVItteration + "\n");
                    }
                }

                //FileProtocol.Write("Number of serries:" + nSerries.ToString() + "\n");
                FileProtocol.Write("Number of data:" + nData.ToString() + "\n");

                FileProtocol.Write("\n");

                //FileProtocol.Write("x: " + CBXAxis.SelectedItem.ToString() + " y: " + CBYAxis.SelectedItem.ToString() + " (" + CBIUnit.SelectedItem.ToString() + ")\n");
                //FileProtocol.Write("\n");
                String line = "";



                System.Windows.Forms.DataGridView SsnGridView = new System.Windows.Forms.DataGridView();
                SsnGridView.Rows.Clear();
                SsnGridView.Columns.Clear();

                //string NormalVoltPGCurrent = "Voltage [V]";
                //string NormalCurrentPGVolt = "Current [A]";
                //if (Form1.AllSessions[PlotIndex].PGmode == 3)
                //{
                //    NormalVoltPGCurrent = "Current [A]";
                //    NormalCurrentPGVolt = "Voltage [V]";
                //}

                string NormalVoltPGCurrent = "Voltage [V]";
                string NormalCurrentPGVolt = "Current [A]";
                string NormalSetVoltPGSetCurrent = "Real Voltage [V]";

                if (Form1.AllSessions[PlotIndex].PGmode == 3)
                {
                    if (Form1.AllSessions[PlotIndex].Mode == 2 || Form1.AllSessions[PlotIndex].Mode == 3)
                    {
                        if (Form1.AllSessions[PlotIndex].IVCurrentRangeMode == 0)
                            PGxunit = "[A]";
                        else if (Form1.AllSessions[PlotIndex].IVCurrentRangeMode >= 1 && Form1.AllSessions[PlotIndex].IVCurrentRangeMode <= 3)
                            PGxunit = "[mA]";
                        else if (Form1.AllSessions[PlotIndex].IVCurrentRangeMode >= 4 && Form1.AllSessions[PlotIndex].IVCurrentRangeMode <= 6)
                            PGxunit = "[uA]";
                        else if (Form1.AllSessions[PlotIndex].IVCurrentRangeMode == 7)
                            PGxunit = "[nA]";
                    }
                    else if (Form1.AllSessions[PlotIndex].Mode == 4)
                    {
                        if (Form1.AllSessions[PlotIndex].PulseCurrentRangeMode == 0)
                            PGxunit = "[A]";
                        else if (Form1.AllSessions[PlotIndex].PulseCurrentRangeMode >= 1 && Form1.AllSessions[PlotIndex].PulseCurrentRangeMode <= 3)
                            PGxunit = "[mA]";
                        else if (Form1.AllSessions[PlotIndex].PulseCurrentRangeMode >= 4 && Form1.AllSessions[PlotIndex].PulseCurrentRangeMode <= 6)
                            PGxunit = "[uA]";
                        else if (Form1.AllSessions[PlotIndex].PulseCurrentRangeMode == 7)
                            PGxunit = "[nA]";
                    }
                    NormalVoltPGCurrent = "Current " + PGxunit;
                    NormalCurrentPGVolt = "Real Current [A]";
                    NormalSetVoltPGSetCurrent = "Voltage [V]";
                }

                switch (Sess.Mode)
                {
                    case 0:
                        if (Sess.isStarted)
                        {
                            SsnGridView.Columns.Add("Frequency [Hz]", "Frequency [Hz]  ");
                            SsnGridView.Columns.Add("Re(Z) [Ohm]", "Re(Z) [Ohm]     ");
                            SsnGridView.Columns.Add("-Im(Z) [Ohm]", "-Im(Z) [Ohm]     ");
                            SsnGridView.Columns.Add("R [Ohm]", "R [Ohm]         ");
                            SsnGridView.Columns.Add("Theta [Degree]", "Theta [Degree]  ");
                            for (int f = 0; f < SessD.ReceivedDataCount; f++)
                            {
                                SsnGridView.Rows.Add("");
                                SsnGridView.Rows[f].Cells[0].Value = SessD.Frq[f];
                                SsnGridView.Rows[f].Cells[1].Value = SessD.ReZ[f];
                                SsnGridView.Rows[f].Cells[2].Value = -SessD.Imz[f];
                                SsnGridView.Rows[f].Cells[3].Value = (Math.Sqrt(Math.Pow(SessD.ReZ[f], 2.0) + Math.Pow(SessD.Imz[f], 2.0)));
                                SsnGridView.Rows[f].Cells[4].Value = (Math.Atan2(SessD.Imz[f], SessD.ReZ[f]));
                            }
                        }
                        break;
                    case 1:
                        if (Sess.isStarted)
                        {
                            SsnGridView.Columns.Add(NormalVoltPGCurrent, NormalVoltPGCurrent + "     ");
                            SsnGridView.Columns.Add("1/c^2 [(nF)^-2]", "1/c^2 [(uF)^-2] ");
                            SsnGridView.Columns.Add("Current [mA]", "Current [mA]    ");
                            SsnGridView.Columns.Add("Re(Z) [Ohm]", "Re(Z) [Ohm]     ");
                            SsnGridView.Columns.Add("Im(Z) [Ohm]", "Im(Z) [Ohm]     ");
                            SsnGridView.Columns.Add("R [Ohm]", "R [Ohm]         ");
                            SsnGridView.Columns.Add("Theta [Degree]", "Theta [Degree]  ");

                            double uF2 = 1.0e-12;
                            double mA = 1000.0;
                            for (int f = 0; f < SessD.ReceivedDataCount; f++)
                            {
                                double frq = Sess.ACFrqConstant;
                                SsnGridView.Rows.Add("");
                                SsnGridView.Rows[f].Cells[0].Value = SessD.Vlt[f];
                                SsnGridView.Rows[f].Cells[1].Value = Math.Pow(SessD.Imz[f] * frq * 2.0 * Math.PI, 2.0) * uF2;
                                SsnGridView.Rows[f].Cells[2].Value = SessD.Amp[f] * mA;
                                SsnGridView.Rows[f].Cells[3].Value = SessD.ReZ[f];
                                SsnGridView.Rows[f].Cells[4].Value = SessD.Imz[f];
                                SsnGridView.Rows[f].Cells[5].Value = (Math.Sqrt(Math.Pow(SessD.ReZ[f], 2.0) + Math.Pow(SessD.Imz[f], 2.0)));
                                SsnGridView.Rows[f].Cells[6].Value = (Math.Atan2(SessD.Imz[f], SessD.ReZ[f]));
                            }
                        }
                        break;
                    case 2:
                        if (Sess.isStarted)
                        {
                            SsnGridView.Columns.Add(NormalVoltPGCurrent, NormalVoltPGCurrent);
                            SsnGridView.Columns.Add(NormalCurrentPGVolt, NormalCurrentPGVolt);
                            SsnGridView.Columns.Add("Time [sec]", "Time [sec]");
                            SsnGridView.Columns.Add(NormalSetVoltPGSetCurrent, NormalSetVoltPGSetCurrent);
                            for (int f = 0; f < SessD.ReceivedDataCount; f++)
                            {
                                SsnGridView.Rows.Add("");
                                SsnGridView.Rows[f].Cells[0].Value = SessD.Vlt[f];
                                SsnGridView.Rows[f].Cells[1].Value = SessD.Amp[f];
                                SsnGridView.Rows[f].Cells[2].Value = SessD.ReZ[f];
                                SsnGridView.Rows[f].Cells[3].Value = SessD.Imz[f];
                            }
                        }
                        break;
                    case 3:
                        if (Sess.isStarted)
                        {
                            SsnGridView.Columns.Add(NormalVoltPGCurrent, NormalVoltPGCurrent);
                            SsnGridView.Columns.Add(NormalCurrentPGVolt, NormalCurrentPGVolt);
                            SsnGridView.Columns.Add("Time [sec]", "Time [sec]");
                            SsnGridView.Columns.Add(NormalSetVoltPGSetCurrent, NormalSetVoltPGSetCurrent);
                            for (int f = 0; f < SessD.ReceivedDataCount; f++)
                            {
                                SsnGridView.Rows.Add("");
                                SsnGridView.Rows[f].Cells[0].Value = SessD.Vlt[f];
                                SsnGridView.Rows[f].Cells[1].Value = SessD.Amp[f];
                                SsnGridView.Rows[f].Cells[2].Value = SessD.ReZ[f];
                                SsnGridView.Rows[f].Cells[3].Value = SessD.Imz[f];
                            }
                        }
                        break;
                    case 4:
                        if (Sess.isStarted)
                        {
                            SsnGridView.Columns.Add(NormalVoltPGCurrent, NormalVoltPGCurrent);
                            SsnGridView.Columns.Add(NormalCurrentPGVolt, NormalCurrentPGVolt);
                            SsnGridView.Columns.Add("Time [sec]", "Time [sec]");
                            SsnGridView.Columns.Add(NormalSetVoltPGSetCurrent, NormalSetVoltPGSetCurrent);
                            for (int f = 0; f < SessD.ReceivedDataCount; f++)
                            {
                                SsnGridView.Rows.Add("");
                                SsnGridView.Rows[f].Cells[0].Value = SessD.Vlt[f];
                                SsnGridView.Rows[f].Cells[1].Value = SessD.Amp[f];
                                SsnGridView.Rows[f].Cells[2].Value = SessD.ReZ[f];
                                SsnGridView.Rows[f].Cells[3].Value = SessD.Imz[f];
                            }
                        }
                        break;
                    default:

                        break;
                }

                for (int j = 0; j < SsnGridView.ColumnCount; j++)
                {
                    if (j == 0)
                        line = SsnGridView.Columns[j].HeaderText;
                    else
                        line = line + "\t" + SsnGridView.Columns[j].HeaderText;
                }
                line = line + "\n";
                FileProtocol.Write(line);

                FileProtocol.Write("\n");

                for (int i = 0; i < SessD.ReceivedDataCount; i++)
                {
                    for (int j = 0; j < SsnGridView.ColumnCount; j++)
                    {
                        if (j == 0)
                            line = SsnGridView.Rows[i].Cells[j].Value.ToString();
                        else
                            line = line + "\t" + SsnGridView.Rows[i].Cells[j].Value.ToString();
                    }
                    line = line + "\n";
                    FileProtocol.Write(line);
                }

                FileProtocol.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in writing to file ...\n" + ex.Message);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (ChSeries.Visible)
            {
                ChSeries.Items.Clear();
                ChSeries.Visible = false;
            }
            else
            {
                int ns = chart1.Series.Count;
                for (int js = 0; js < ns; js++)
                {
                    ChSeries.Items.Add(chart1.Series[js].LegendText, chart1.Series[js].Enabled);
                }
                ChSeries.Visible = true;
            }
        }

        private void ChSeries_SelectedIndexChanged(object sender, EventArgs e)
        {
            //nPlottedData = 0;
            int ns = chart1.Series.Count;
            for (int js = 0; js < ns; js++)
            {
                chart1.Series[js].Enabled = false;
            }

            foreach (int indexChecked in ChSeries.CheckedIndices)
            {
                chart1.Series[indexChecked].Enabled = true;
            }
        }

        private void ChSeries_ItemCheck(object sender, ItemCheckEventArgs e)
        {

        }

        private void ChSeries_Validated(object sender, EventArgs e)
        {

        }

        private void ChSeries_KeyUp(object sender, KeyEventArgs e)
        {
            int ns = chart1.Series.Count;
            for (int js = 0; js < ns; js++)
            {
                chart1.Series[js].Enabled = false;
            }

            foreach (int indexChecked in ChSeries.CheckedIndices)
            {
                chart1.Series[indexChecked].Enabled = true;
            }
        }

        private void BtnMakeReport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Data files (*.dat)|*.dat";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                int nData = chart1.Series[0].Points.Count;

                if (isDisconnectedFromSessionSource)
                    ReportData(nData, SelfStandingSession, SelfStandingSessionData, chart1.Series, saveFileDialog1.FileName, Form1.AllSessions[PlotIndex].Mode);
                else
                    ReportData(nData, Form1.AllSessions[PlotIndex], Form1.AllSessionsData[PlotIndex], chart1.Series, saveFileDialog1.FileName, Form1.AllSessions[PlotIndex].Mode);
            }
        }

        private void OpenInExcel_Click(object sender, EventArgs e)
        {
            int nData = chart1.Series[0].Points.Count;
            string path = Directory.GetCurrentDirectory();
            if (isDisconnectedFromSessionSource)
                ReportData(nData, SelfStandingSession, SelfStandingSessionData, chart1.Series, @".\data.dat", Form1.AllSessions[PlotIndex].Mode);
            else
                ReportData(nData, Form1.AllSessions[PlotIndex], Form1.AllSessionsData[PlotIndex], chart1.Series, @".\data.dat", Form1.AllSessions[PlotIndex].Mode);


            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            process.StartInfo = startInfo;
            startInfo.FileName = "notepad data.xml";

            Process.Start(@".\data.dat");
            //process.Start();"explorer.exe",
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            YAxisIndex = CBYAxis.SelectedIndex;
            nPlottedData = 0;
            UpdateDiagram();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            YAxisIndex = CBYAxis.SelectedIndex;
            nPlottedData = 0;
            UpdateDiagram();
        }
    }
}
