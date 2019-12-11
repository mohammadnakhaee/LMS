using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Resources;
using System.Runtime.InteropServices;

namespace EISProjects
{
    public partial class FormFitting : Form
    {
        ////////////////////////////////////////

        public static Point Location0 = new Point();
        public static bool isMove = false;
        public static int FitSelectedSession;
        public static int FitSelectedCircuit;
        public static int FitSelectedElement;
        public static int FitSelectedMethod;

        public static int MMAX = 50;
        public static int mfit = 0;
        public static double[] da = new double[MMAX];
        public static double[,] da2 = new double[MMAX, 1];
        public static double[] atry = new double[MMAX];
        public static double[] beta = new double[MMAX];
        public static double ochisq = 0;

        public static List<Panel> ElementsGUI = new List<Panel> { };

        int LinkIndexStart = 0;
        int LinkIndexEnd = 0;

        public static bool ElementAdded = false;
        public static bool ElementRemoved = false;
        Element DeletedElement = new Element();

        [DllImport(@"C:\Users\Mohamad\Documents\Fortran Projects\testcb\bin\Debug\testcb.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "graphimpedancereim_")]
        public static extern void graphimpedancereim(ref double x, double[] a, ref int ma, ref double ReZ, ref double ImZ, ref int nGraphPoints, int[,] circuit, ref int nElements);

        [DllImport(@"C:\Users\Mohamad\Documents\Fortran Projects\testcb\bin\Debug\testcb.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "findfit_")]
        public static extern void FindFitMethodPolar(ref int ndata, double[] frq, double[] AbsZ2, double[] InitialValues, ref int ma, int[] ia, ref int nGraphPoints, int[,] circuit, ref int nElements, double[] a);
        ////////////////////////////////////////

        public FormFitting()
        {
            InitializeComponent();
        }

        private void BtnAutoFitt_Click(object sender, EventArgs e)
        {
            bool err = false;

            int ndata = 100;
            int ma = 3;
            int nca = 3;

            double[] x = new double[ndata];
            double[] y = new double[ndata];
            double[] sig = new double[ndata];
            double[] a = new double[ma];
            int[] ia = new int[ma];
            double[,] covar = new double[ma, ma];
            double[,] alpha = new double[ma, ma];
            double chisq = 0;
            double chisq0 = 0;
            double alamda = 0;
            double DeltaChiSq = 0;
            double dx = 0.1;
            int counter = 0;

            for (int i = 1; i <= ndata; i++)
            {
                x[i - 1] = (i - 1) * dx;
                y[i - 1] = 5 * x[i - 1] * x[i - 1] + 1 + 0.1 * Math.Sin(x[i - 1] * 10);
                sig[i - 1] = 0.05;
            }

            alamda = -1;

            ia[0] = 1;
            ia[1] = 1;
            ia[2] = 1;

            a[0] = 2.2;
            a[1] = 0.1;
            a[2] = 1.1;

            counter = 0;
            chisq0 = 0;
            DeltaChiSq = 1.0;

            while (Math.Abs(DeltaChiSq) >= 0.1 && !err)
            {
                counter++;
                err = mrqmin(ref x, ref y, ref sig, ref ndata, ref a, ref ia, ref ma, ref covar, ref alpha, ref nca, ref chisq, ref alamda);
                listBox1.Items.Add("counter=" + counter.ToString() + "  chi2=" + chisq.ToString());
                DeltaChiSq = chisq - chisq0;
                chisq0 = chisq;
            }

            if (!err)
            {
                alamda = 0;
                err = mrqmin(ref x, ref y, ref sig, ref ndata, ref a, ref ia, ref ma, ref covar, ref alpha, ref nca, ref chisq, ref alamda);
                listBox1.Items.Add("a[0]=" + a[0].ToString());
                listBox1.Items.Add("a[1]=" + a[1].ToString());
                listBox1.Items.Add("a[2]=" + a[2].ToString());
                listBox1.Items.Add("err=" + err.ToString());
            }
            else
            {
                listBox1.Items.Add("err=" + err.ToString());
            }

        }

        private bool funcs(ref double x, ref double[] a, ref double ymod, ref double[] dyda, ref int ma)
        {
            bool err = false;
            try
            {
                ymod = a[0] * x * x + a[1] * x + a[2];

                dyda[0] = x * x;
                dyda[1] = x;
                dyda[2] = 1;
            }
            catch
            {
                err = true;
            }

            return err;
        }

        private bool gaussj(ref double[,] a, ref int n, ref int np, ref double[,] b, ref int m, ref int mp)
        {
            int NMAX = 50;
            int icol = 0;
            int irow = 0;
            int i = 0; int j = 0; int k = 0; int l = 0; int ll = 0;
            int[] indxc, indxr;
            int[] ipiv;
            indxc = new int[NMAX];
            indxr = new int[NMAX];
            ipiv = new int[NMAX];
            double big = 0;
            double dum = 0;
            double pivinv = 0;
            bool err = false;

            try
            {

                for (j = 1; j <= n; j++)
                {
                    ipiv[j - 1] = 0;
                }


                for (i = 1; i <= n; i++)
                {
                    big = 0;
                    for (j = 1; j <= n; j++)
                    {
                        if (ipiv[j - 1] != 1)
                        {
                            for (k = 1; k <= n; k++)
                            {
                                if (ipiv[k - 1] == 0)
                                {
                                    if (Math.Abs(a[j - 1, k - 1]) >= big)
                                    {
                                        big = Math.Abs(a[j - 1, k - 1]);
                                        irow = j;
                                        icol = k;
                                    }
                                }
                                else if (ipiv[k - 1] > 1)
                                {
                                    err = true;
                                }
                            }
                        }
                    }

                    ipiv[icol - 1] = ipiv[icol - 1] + 1;


                    if (irow != icol)
                    {

                        for (l = 1; l <= n; l++)
                        {
                            dum = a[irow - 1, l - 1];
                            a[irow - 1, l - 1] = a[icol - 1, l - 1];
                            a[icol - 1, l - 1] = dum;
                        }
                        for (l = 1; l <= m; l++)
                        {
                            dum = b[irow - 1, l - 1];
                            b[irow - 1, l - 1] = b[icol - 1, l - 1];
                            b[icol - 1, l - 1] = dum;
                        }
                    }
                    indxr[i - 1] = irow;
                    indxc[i - 1] = icol;
                    if (a[icol - 1, icol - 1] == 0)
                    {
                        err = true;
                    }

                    pivinv = 1 / a[icol - 1, icol - 1];
                    a[icol - 1, icol - 1] = 1;

                    for (l = 1; l <= n; l++)
                    {
                        a[icol - 1, l - 1] = a[icol - 1, l - 1] * pivinv;
                    }
                    for (l = 1; l <= m; l++)
                    {
                        b[icol - 1, l - 1] = b[icol - 1, l - 1] * pivinv;
                    }
                    for (ll = 1; ll <= n; ll++)
                    {
                        if (ll != icol)
                        {
                            dum = a[ll - 1, icol - 1];
                            a[ll - 1, icol - 1] = 0;
                            for (l = 1; l <= n; l++)
                            {
                                a[ll - 1, l - 1] = a[ll - 1, l - 1] - a[icol - 1, l - 1] * dum;
                            }
                            for (l = 1; l <= m; l++)
                            {
                                b[ll - 1, l - 1] = b[ll - 1, l - 1] - b[icol - 1, l - 1] * dum;
                            }
                        }
                    }
                }

                for (l = n; l >= 1; l--)
                {
                    if (indxr[l - 1] != indxc[l - 1])
                    {
                        for (k = 1; k <= n; k++)
                        {
                            dum = a[k - 1, indxr[l - 1] - 1];
                            a[k - 1, indxr[l - 1] - 1] = a[k, indxc[l - 1] - 1];
                            a[k - 1, indxc[l - 1] - 1] = dum;
                        }
                    }
                }


            }
            catch
            {
                err = true;
            }

            return err;
        }

        private bool covsrt(ref double[,] covar, ref int npc, ref int ma, ref int[] ia, ref int mfit)
        {
            double swap = 0;
            int k = 0;
            int i = 0; int j = 0;
            bool err = false;
            try
            {
                for (i = mfit + 1; i <= ma; i++)
                {
                    for (j = 1; j <= i; j++)
                    {
                        covar[i - 1, j - 1] = 0;
                        covar[j - 1, i - 1] = 0;
                    }
                }

                k = mfit;

                for (j = ma; j >= 1; j--)
                {
                    if (ia[j - 1] != 0)
                    {
                        for (i = 1; i <= ma; i++)
                        {
                            swap = covar[i - 1, k - 1];
                            covar[i - 1, k - 1] = covar[i - 1, j - 1];
                            covar[i - 1, j - 1] = swap;
                        }
                        for (i = 1; i <= ma; i++)
                        {
                            swap = covar[k - 1, i - 1];
                            covar[k - 1, i - 1] = covar[j - 1, i - 1];
                            covar[j - 1, i - 1] = swap;
                        }
                        k = k - 1;
                    }
                }


            }
            catch
            {
                err = true;
            }

            return err;
        }

        private bool mrqcof(ref double[] x, ref double[] y, ref double[] sig, ref int ndata, ref double[] a, ref int[] ia, ref int ma, ref double[,] alpha, ref double[] beta, ref int nalp, ref double chisq)
        {
            int mfit = 0;
            int j = 0; int k = 0; int i = 0; int l = 0; int m = 0;

            bool err = false;
            bool err1 = false;

            double ymod = 0; double sig2i = 0; double dy = 0; double wt = 0;
            double[] dyda = new double[MMAX];

            try
            {


                mfit = 0;
                for (j = 1; j <= ma; j++)
                {
                    if (ia[j - 1] != 0) mfit = mfit + 1;
                }
                for (j = 1; j <= mfit; j++)
                {
                    for (k = 1; k <= j; k++)
                    {
                        alpha[j - 1, k - 1] = 0;
                    }
                    beta[j - 1] = 0;
                }
                chisq = 0;
                for (i = 1; i <= ndata; i++)
                {
                    err1 = funcs(ref x[i - 1], ref a, ref ymod, ref dyda, ref ma);
                    sig2i = 1 / (sig[i - 1] * sig[i - 1]);
                    dy = y[i - 1] - ymod;
                    j = 0;
                    for (l = 1; l <= ma; l++)
                    {
                        if (ia[l - 1] != 0)
                        {
                            j = j + 1;
                            wt = dyda[l - 1] * sig2i;
                            k = 0;
                            for (m = 1; m <= l; m++)
                            {
                                if (ia[m - 1] != 0)
                                {
                                    k = k + 1;
                                    alpha[j - 1, k - 1] = alpha[j - 1, k - 1] + wt * dyda[m - 1];
                                }
                            }
                            beta[j - 1] = beta[j - 1] + dy * wt;
                        }
                    }
                    chisq = chisq + dy * dy * sig2i;
                }
                for (j = 2; j <= mfit; j++)
                {
                    for (k = 1; k <= j - 1; k++)
                    {
                        alpha[k - 1, j - 1] = alpha[j - 1, k - 1];
                    }
                }

            }
            catch
            {
                err = true;
            }

            return err;
        }

        private bool mrqmin(ref double[] x, ref double[] y, ref double[] sig, ref int ndata, ref double[] a, ref int[] ia, ref int ma, ref double[,] covar, ref double[,] alpha, ref int nca, ref double chisq, ref double alamda)
        {
            int j = 0; int k = 0; int l = 0;


            bool err = false;


            int one = 1;

            try
            {

                if (alamda < 0)
                {
                    mfit = 0;
                    for (j = 1; j <= ma; j++)
                    {
                        if (ia[j - 1] != 0) mfit = mfit + 1;
                    }
                    alamda = 0.001;
                    err = mrqcof(ref x, ref y, ref sig, ref ndata, ref a, ref ia, ref ma, ref alpha, ref beta, ref nca, ref chisq);
                    ochisq = chisq;
                    for (j = 1; j <= ma; j++)
                    {
                        atry[j - 1] = a[j - 1];
                    }
                }
                for (j = 1; j <= mfit; j++)
                {
                    for (k = 1; k <= mfit; k++)
                    {
                        covar[j - 1, k - 1] = alpha[j - 1, k - 1];
                    }
                    covar[j - 1, j - 1] = alpha[j - 1, j - 1] * (1 + alamda);
                    da[j - 1] = beta[j - 1];
                }
                for (int c = 1; c <= MMAX; c++)
                {
                    da2[c - 1, 0] = da[c - 1];
                }
                err = gaussj(ref covar, ref mfit, ref nca, ref da2, ref one, ref one);
                for (int c = 1; c <= MMAX; c++)
                {
                    da[c - 1] = da2[c - 1, 0];
                }
                if (alamda == 0)
                {
                    err = covsrt(ref covar, ref nca, ref ma, ref ia, ref mfit);
                    return err;
                }
                j = 0;
                for (l = 1; l <= ma; l++)
                {
                    if (ia[l - 1] != 0)
                    {
                        j = j + 1;
                        atry[l - 1] = a[l - 1] + da[j - 1];
                    }
                }
                err = mrqcof(ref x, ref y, ref sig, ref ndata, ref atry, ref ia, ref ma, ref covar, ref da, ref nca, ref chisq);
                if (chisq < ochisq)
                {
                    alamda = 0.1 * alamda;
                    ochisq = chisq;
                    for (j = 1; j <= mfit; j++)
                    {
                        for (k = 1; k <= mfit; k++)
                        {
                            alpha[j - 1, k - 1] = covar[j - 1, k - 1];
                        }
                        beta[j - 1] = da[j - 1];
                    }
                    for (l = 1; l <= ma; l++)
                    {
                        a[l - 1] = atry[l - 1];
                    }
                }
                else
                {
                    alamda = 10 * alamda;
                    chisq = ochisq;
                }



            }
            catch
            {
                err = true;
            }

            return err;
        }

        private void FormFitting_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Form1.isFormFit = false;
            this.Hide();
        }

        private void SessionName_SelectedIndexChanged(object sender, EventArgs e)
        {
            FitSelectedSession = SessionName.SelectedIndex;
            if (Form1.AllSessions[FitSelectedSession].isFinished)
            {
                LabelError.Text = "";
                double[] frqTable = new double[Form1.AllSessionsData[FitSelectedSession].ReceivedDataCount];
                double frq = Form1.AllSessions[FitSelectedSession].ACFrqFrom;
                for (int i = 0; i < Form1.AllSessionsData[FitSelectedSession].ReceivedDataCount; i++)
                {
                    frqTable[i] = frq;
                    frq = frq * Form1.AllSessions[FitSelectedSession].ACFrqStep;
                }
                PlotImpedance(chart1, frqTable, Form1.AllSessionsData[FitSelectedSession].ReZ, Form1.AllSessionsData[FitSelectedSession].ImZ, Form1.AllSessionsData[FitSelectedSession].ReceivedDataCount);
                GBContents.Enabled = true;
            }
            else
            {
                if (Form1.AllSessions[FitSelectedSession].isStarted)
                {
                    LabelError.ForeColor = Color.Orange;
                    LabelError.Text = "This session is not complete yet. Please wait ...";
                    GBContents.Enabled = true;
                }
                else
                {
                    LabelError.ForeColor = Color.Red;
                    LabelError.Text = "There is no data in this session ...";
                    GBContents.Enabled = true;
                }
            }
        }

        private void PlotImpedance(Chart chart, double[] FrqArray, double[] ReZArray, double[] ImZArray, int npoints)
        {
            ClearPlot(chart);
            chart.ChartAreas[0].AxisX.IsLogarithmic = true;
            AddSeries(chart, "Re(Z)", "Frequancy", "Impedance", Color.Blue);
            AddSeries(chart, "Im(Z)", "Frequancy", "Impedance", Color.Red);
            for (int i = 0; i < npoints; i++)
            {
                AddPoint(chart, 0, FrqArray[i], ReZArray[i]);
                AddPoint(chart, 1, FrqArray[i], ImZArray[i]);
            }
        }

        private void PlotFittedImpedance(Chart chart, double[] FrqArray, double[] ReZArray, double[] ImZArray, double[] FitReZArray, double[] FitImZArray, int npoints)
        {
            ClearPlot(chart);
            chart.ChartAreas[0].AxisX.IsLogarithmic = true;
            AddSeries(chart, "Re(Z)", "Frequancy", "Impedance", Color.Blue);
            AddSeries(chart, "Im(Z)", "Frequancy", "Impedance", Color.Red);
            for (int i = 0; i < npoints; i++)
            {
                AddPoint(chart, 0, FrqArray[i], ReZArray[i]);
                AddPoint(chart, 1, FrqArray[i], ImZArray[i]);
            }

            chart.ChartAreas[0].AxisX.IsLogarithmic = true;
            AddSeries(chart, "Fitted Re(Z)", "Frequancy", "Impedance", Color.Blue);
            AddSeries(chart, "Fitted Im(Z)", "Frequancy", "Impedance", Color.Red);
            chart.Series[2].BorderWidth = 3;
            chart.Series[2].BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chart.Series[3].BorderWidth = 3;
            chart.Series[3].BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            for (int i = 0; i < npoints; i++)
            {
                AddPoint(chart, 2, FrqArray[i], FitReZArray[i]);
                AddPoint(chart, 3, FrqArray[i], FitImZArray[i]);
                //chart.Series[2].Points[i].BorderDashStyle = ChartDashStyle.Dash;
                //chart.Series[2].Points[i].BorderDashStyle = ChartDashStyle.Dash;
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

        private void C_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;
        }

        private void C_MouseMove(object sender, MouseEventArgs e)
        {
            Panel thisPanel = (Panel)sender;
            if ((ModifierKeys & Keys.Control) == Keys.Control)
                thisPanel.Cursor = Cursors.Cross;
            else
                thisPanel.Cursor = Cursors.Hand;
            if (isMove)
            {
                Point NewLocation = new Point(thisPanel.Location.X + e.X - Location0.X, thisPanel.Location.Y + e.Y - Location0.Y);
                if (NewLocation.X < 0) NewLocation.X = 0;
                if (NewLocation.Y < 0) NewLocation.Y = 0;
                thisPanel.Location = NewLocation;
                Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit].Elements[FitSelectedElement].X = thisPanel.Location.X;
                Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit].Elements[FitSelectedElement].Y = thisPanel.Location.Y;
                CircuitDeskTop.Refresh();
            }
        }

        private void C_MouseDown(object sender, MouseEventArgs e)
        {
            Panel thisPanel = (Panel)sender;
            SellectElement(Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit], thisPanel);
            if (e.Button == MouseButtons.Right)
            {
                //int xOffset = e.X;
                //int yOffset = e.Y;
                if (FitSelectedElement > 1) CMElements.Show(thisPanel, new Point(e.X, e.Y));
            }
            else
            {
                if ((ModifierKeys & Keys.Control) == Keys.Control)
                {
                    if (e.X < thisPanel.Size.Width / 2)
                        LinkIndexStart = Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit].Elements[FitSelectedElement].Input;
                    else
                        LinkIndexStart = Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit].Elements[FitSelectedElement].Output;

                    if (Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit].Elements[FitSelectedElement].Mode == -1)
                        LinkIndexStart = Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit].Elements[FitSelectedElement].Output;
                    if (Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit].Elements[FitSelectedElement].Mode == -2)
                        LinkIndexStart = Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit].Elements[FitSelectedElement].Input;

                    //if (e.X < thisPanel.Size.Width / 2)
                    //    WireStart = new PointF(thisPanel.Location.X, thisPanel.Location.Y + thisPanel.Size.Height / 2);
                    //else
                    //    WireStart = new PointF(thisPanel.Location.X + thisPanel.Size.Width, thisPanel.Location.Y + thisPanel.Size.Height / 2);
                    thisPanel.DoDragDrop(thisPanel.Text, DragDropEffects.All);
                }
                else
                {
                    isMove = true;
                    Location0 = e.Location;
                }
            }
        }

        private void C_DragDrop(object sender, DragEventArgs e)
        {
            Panel thisPanel = (Panel)sender;
            int TargetIndex = GetElementIndex(Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit], thisPanel);
            if (TargetIndex != FitSelectedElement)
            {
                PointF targetPoint = thisPanel.PointToClient(new Point(e.X, e.Y));
                if (targetPoint.X < thisPanel.Size.Width / 2)
                    LinkIndexEnd = Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit].Elements[TargetIndex].Input;
                else
                    LinkIndexEnd = Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit].Elements[TargetIndex].Output;
                if (Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit].Elements[TargetIndex].Mode == -1)
                    LinkIndexEnd = Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit].Elements[TargetIndex].Output;
                if (Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit].Elements[TargetIndex].Mode == -2)
                    LinkIndexEnd = Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit].Elements[TargetIndex].Input;

                Link NewLink = new Link();
                NewLink.i = Math.Min(LinkIndexStart, LinkIndexEnd);
                NewLink.j = Math.Max(LinkIndexStart, LinkIndexEnd);
                if (LinkIndexStart == NewLink.i)
                {
                    NewLink.iElement = FitSelectedElement;
                    NewLink.jElement = TargetIndex;
                }
                else
                {
                    NewLink.iElement = TargetIndex;
                    NewLink.jElement = FitSelectedElement;
                }
                bool isValid = CheckNewLink(NewLink, Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit].Links);
                if (isValid)
                {
                    Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit].Links.Add(NewLink);
                    Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit].nLinks++;
                    SortLinks(ref Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit].Links);
                    SetGraphPoints(Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit], Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit].Links);
                    List<int> BadElements = new List<int>() { };
                    bool Err = CheckElementsIO(Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit], ref BadElements);
                    if (Err)
                    {
                        RemoveLink(Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit], NewLink);
                        string BadElementsNames = "";
                        foreach (int k in BadElements)
                        {
                            if (k == 0)
                                BadElementsNames = Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit].Elements[k].name;
                            else
                                BadElementsNames = BadElementsNames + ", " + Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit].Elements[k].name;
                        }
                        MessageBox.Show("Invalid Wire. Error in element(s)\n" + BadElementsNames + "\nThis wire will be removed ...");
                        SetGraphPoints(Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit], Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit].Links);
                    }
                }

                CircuitDeskTop.Refresh();
                UpdateDiagrams();
            }
        }

        private void C_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
            listBox1.Items.Add("C_DragEnter");
        }

        private void C_DragLeave(object sender, EventArgs e)
        {
            listBox1.Items.Add("C_DragLeave");
        }

        private void C_DragOver(object sender, DragEventArgs e)
        {
            Panel thisPanel = (Panel)sender;
        }

        private void TSBSelMod_Click(object sender, EventArgs e)
        {
            TSBSelMod.Checked = true;
            TSBResMod.Checked = false;
            TSBCapMod.Checked = false;
            TSBIndMod.Checked = false;
            //TSBWireMod.Checked = false;
        }

        private void TSBResMod_Click(object sender, EventArgs e)
        {
            TSBSelMod.Checked = false;
            TSBResMod.Checked = true;
            TSBCapMod.Checked = false;
            TSBIndMod.Checked = false;
            //TSBWireMod.Checked = false;
        }

        private void TSBCapMod_Click(object sender, EventArgs e)
        {
            TSBSelMod.Checked = false;
            TSBResMod.Checked = false;
            TSBCapMod.Checked = true;
            TSBIndMod.Checked = false;
            //TSBWireMod.Checked = false;
        }

        private void TSBIndMod_Click(object sender, EventArgs e)
        {
            TSBSelMod.Checked = false;
            TSBResMod.Checked = false;
            TSBCapMod.Checked = false;
            TSBIndMod.Checked = true;
            //TSBWireMod.Checked = false;
        }

        private void TSBWireMod_Click(object sender, EventArgs e)
        {
            TSBSelMod.Checked = false;
            TSBResMod.Checked = false;
            TSBCapMod.Checked = false;
            TSBIndMod.Checked = false;
            //TSBWireMod.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //int m = 1;
            //int n = 0;
            //double x = 1;
            //double y = 0;
            //sub(ref m, ref n, ref x, ref y);
            //sub(ref m, ref n, ref x, ref y);
            //sub(ref m, ref n, ref x, ref y);

        }

        private void BtnNewCircuit_Click(object sender, EventArgs e)
        {
            foreach (Panel EGUI in ElementsGUI)
            {
                EGUI.Dispose();
            }
            ElementsGUI.Clear();

            Circuit newC = new Circuit();
            newC.isFitted = false;
            newC.isTrue = false;
            newC.nElements = 0;
            Form1.AllSessions[FitSelectedSession].nCircuits++;
            int nCircuit = Form1.AllSessions[FitSelectedSession].nCircuits;
            newC.name = "Circuit " + nCircuit.ToString();
            CBCircuitName.Items.Add(newC.name);
            newC.FitMethod = 1;
            Form1.AllSessions[FitSelectedSession].Circuits.Add(newC);

            CBCircuitName.SelectedIndex = nCircuit - 1;
            CBFitMethod.SelectedIndex = 0;

            Panel input = new Panel();
            input.Parent = CircuitDeskTop;
            input.Location = new Point(100, CircuitDeskTop.Size.Height / 2);
            input.Size = new System.Drawing.Size(41, 21);
            input.AllowDrop = true;
            int s = FitSelectedSession;
            int c = FitSelectedCircuit;
            Element NewElm1 = new Element();
            Form1.AllSessions[s].Circuits[c].Elements.Add(NewElm1);
            Form1.AllSessions[s].Circuits[c].nElements++;
            int nE = Form1.AllSessions[s].Circuits[c].nElements;
            Form1.AllSessions[s].Circuits[c].Elements[nE - 1].HashCode = input.GetHashCode();
            Form1.AllSessions[s].Circuits[c].Elements[nE - 1].Mode = -1;
            input.BackgroundImage = global::EISProjects.Properties.Resources.input;
            RearrangeElementsIO(Form1.AllSessions[s].Circuits[c]);
            input.BackgroundImageLayout = ImageLayout.Stretch;
            input.Cursor = Cursors.Hand;
            input.Show();
            input.MouseDown += new MouseEventHandler(C_MouseDown);
            input.MouseUp += new MouseEventHandler(C_MouseUp);
            input.MouseMove += new MouseEventHandler(C_MouseMove);
            input.DragDrop += new DragEventHandler(C_DragDrop);
            input.DragEnter += new DragEventHandler(C_DragEnter);
            input.DragLeave += new EventHandler(C_DragLeave);
            input.DragOver += new DragEventHandler(C_DragOver);
            ElementsGUI.Add(input);
            SellectElement(Form1.AllSessions[s].Circuits[c], input);
            Form1.AllSessions[s].Circuits[c].Elements[nE - 1].X = input.Location.X;
            Form1.AllSessions[s].Circuits[c].Elements[nE - 1].Y = input.Location.Y;

            Panel output = new Panel();
            output.Parent = CircuitDeskTop;
            output.Location = new Point(CircuitDeskTop.Size.Width - 100 - 41, CircuitDeskTop.Size.Height / 2);
            output.Size = new System.Drawing.Size(41, 21);
            output.AllowDrop = true;
            s = FitSelectedSession;
            c = FitSelectedCircuit;
            Element NewElm2 = new Element();
            Form1.AllSessions[s].Circuits[c].Elements.Add(NewElm2);
            Form1.AllSessions[s].Circuits[c].nElements++;
            nE = Form1.AllSessions[s].Circuits[c].nElements;
            Form1.AllSessions[s].Circuits[c].Elements[nE - 1].HashCode = output.GetHashCode();
            Form1.AllSessions[s].Circuits[c].Elements[nE - 1].Mode = -2;
            output.BackgroundImage = global::EISProjects.Properties.Resources.output1;
            RearrangeElementsIO(Form1.AllSessions[s].Circuits[c]);
            output.BackgroundImageLayout = ImageLayout.Stretch;
            output.Cursor = Cursors.Hand;
            output.Show();
            output.MouseDown += new MouseEventHandler(C_MouseDown);
            output.MouseUp += new MouseEventHandler(C_MouseUp);
            output.MouseMove += new MouseEventHandler(C_MouseMove);
            output.DragDrop += new DragEventHandler(C_DragDrop);
            output.DragEnter += new DragEventHandler(C_DragEnter);
            output.DragLeave += new EventHandler(C_DragLeave);
            output.DragOver += new DragEventHandler(C_DragOver);
            ElementsGUI.Add(output);
            SellectElement(Form1.AllSessions[s].Circuits[c], output);
            Form1.AllSessions[s].Circuits[c].Elements[nE - 1].X = output.Location.X;
            Form1.AllSessions[s].Circuits[c].Elements[nE - 1].Y = output.Location.Y;


            toolStrip1.Enabled = true;
        }

        private void CBCircuitName_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Panel EGUI in ElementsGUI)
            {
                EGUI.Dispose();
            }
            ElementsGUI.Clear();
            FitSelectedCircuit = CBCircuitName.SelectedIndex;
            int nE = 0;
            foreach (Element E in Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit].Elements)
            {
                nE++;
                Panel NewRes = new Panel();
                NewRes.Parent = CircuitDeskTop;
                NewRes.Location = new Point(E.X, E.Y);
                NewRes.Size = new System.Drawing.Size(41, 21);
                NewRes.AllowDrop = true;

                int s = FitSelectedSession;
                int c = FitSelectedCircuit;
                //int m = FitSelectedMethod;

                //Element NewElm = new Element();
                //Form1.AllSessions[s].Circuits[c].Elements.Add(NewElm);
                //Form1.AllSessions[s].Circuits[c].nElements++;
                //int nE = Form1.AllSessions[s].Circuits[c].nElements;
                E.HashCode = NewRes.GetHashCode();
                //E.X = NewRes.Location.X;
                //E.Y = NewRes.Location.Y;

                if (E.Mode == 1)
                {
                    NewRes.BackgroundImage = global::EISProjects.Properties.Resources.res1;
                }

                if (E.Mode == 2)
                {
                    NewRes.BackgroundImage = global::EISProjects.Properties.Resources.cap1;
                }

                if (E.Mode == 3)
                {
                    NewRes.BackgroundImage = global::EISProjects.Properties.Resources.ind1;
                }

                if (E.Mode == -1)
                {
                    NewRes.BackgroundImage = global::EISProjects.Properties.Resources.input;
                }

                if (E.Mode == -2)
                {
                    NewRes.BackgroundImage = global::EISProjects.Properties.Resources.output1;
                }
                ElementAdded = true;
                RearrangeElementsIO(Form1.AllSessions[s].Circuits[c]);
                ElementAdded = false;

                NewRes.BackgroundImageLayout = ImageLayout.Stretch;
                NewRes.Cursor = Cursors.Hand;
                NewRes.Show();
                NewRes.MouseDown += new MouseEventHandler(C_MouseDown);
                NewRes.MouseUp += new MouseEventHandler(C_MouseUp);
                NewRes.MouseMove += new MouseEventHandler(C_MouseMove);
                NewRes.DragDrop += new DragEventHandler(C_DragDrop);
                NewRes.DragEnter += new DragEventHandler(C_DragEnter);
                NewRes.DragLeave += new EventHandler(C_DragLeave);
                NewRes.DragOver += new DragEventHandler(C_DragOver);
                ElementsGUI.Add(NewRes);
                SellectElement(Form1.AllSessions[s].Circuits[c], NewRes);

            }


            CBFitMethod.Enabled = true;
        }

        private void CBFitMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            FitSelectedMethod = CBFitMethod.SelectedIndex;
        }

        //private void panel3_Paint(object sender, PaintEventArgs e)
        //{
        //    // Create four Pen objects with red,
        //    // blue, green, and black colors and
        //    // different widths
        //    Pen redPen = new Pen(Color.Red, 1);
        //    Pen bluePen = new Pen(Color.Blue, 2);
        //    Pen greenPen = new Pen(Color.Green, 3);
        //    Pen blackPen = new Pen(Color.Black, 4);

        //    // Draw line using float coordinates
        //    float x1 = 20.0F, y1 = 20.0F;
        //    float x2 = 200.0F, y2 = 20.0F;
        //    e.Graphics.DrawLine(redPen, x1, y1, x2, y2);

        //    // Draw line using Point structure
        //    Point p1 = new Point(20, 20);
        //    Point p2 = new Point(20, 200);
        //    e.Graphics.DrawLine(greenPen, p1, p2);

        //    //Draw line using PointF structures
        //    PointF ptf1 = new PointF(20.0F, 20.0f);
        //    PointF ptf2 = new PointF(200.0F, 200.0f);
        //    e.Graphics.DrawLine(bluePen, ptf1, ptf2);

        //    // Draw line using integer coordinates
        //    int X1 = 60, Y1 = 40, X2 = 250, Y2 = 100;
        //    e.Graphics.DrawLine(blackPen, X1, Y1, X2, Y2);

        //    //Dispose of objects
        //    redPen.Dispose();
        //    bluePen.Dispose();
        //    greenPen.Dispose();
        //    blackPen.Dispose();
        //}

        private void CircuitDeskTop_Click(object sender, EventArgs e)
        {
            //var mouseEventArgs = e as MouseEventArgs;
            MouseEventArgs eM = (MouseEventArgs)e;
            if (eM.Button == MouseButtons.Left && !TSBSelMod.Checked && !((ModifierKeys & Keys.Control) == Keys.Control))
            {
                Panel NewRes = new Panel();
                NewRes.Parent = CircuitDeskTop;
                NewRes.Location = new Point(eM.X - 20, eM.Y - 10);
                NewRes.Size = new System.Drawing.Size(41, 21);
                NewRes.AllowDrop = true;

                int s = FitSelectedSession;
                int c = FitSelectedCircuit;
                //int m = FitSelectedMethod;

                Element NewElm = new Element();
                Form1.AllSessions[s].Circuits[c].Elements.Add(NewElm);
                Form1.AllSessions[s].Circuits[c].nElements++;
                int nE = Form1.AllSessions[s].Circuits[c].nElements;
                Form1.AllSessions[s].Circuits[c].Elements[nE - 1].HashCode = NewRes.GetHashCode();
                Form1.AllSessions[s].Circuits[c].Elements[nE - 1].X = NewRes.Location.X;
                Form1.AllSessions[s].Circuits[c].Elements[nE - 1].Y = NewRes.Location.Y;

                if (TSBResMod.Checked)
                {
                    Form1.AllSessions[s].Circuits[c].Elements[nE - 1].Mode = 1;
                    NewRes.BackgroundImage = global::EISProjects.Properties.Resources.res1;
                }

                if (TSBCapMod.Checked)
                {
                    Form1.AllSessions[s].Circuits[c].Elements[nE - 1].Mode = 2;
                    NewRes.BackgroundImage = global::EISProjects.Properties.Resources.cap1;
                }

                if (TSBIndMod.Checked)
                {
                    Form1.AllSessions[s].Circuits[c].Elements[nE - 1].Mode = 3;
                    NewRes.BackgroundImage = global::EISProjects.Properties.Resources.ind1;
                }

                ElementAdded = true;
                RearrangeElementsIO(Form1.AllSessions[s].Circuits[c]);
                ElementAdded = false;

                NewRes.BackgroundImageLayout = ImageLayout.Stretch;
                NewRes.Cursor = Cursors.Hand;
                NewRes.Show();
                NewRes.MouseDown += new MouseEventHandler(C_MouseDown);
                NewRes.MouseUp += new MouseEventHandler(C_MouseUp);
                NewRes.MouseMove += new MouseEventHandler(C_MouseMove);
                NewRes.DragDrop += new DragEventHandler(C_DragDrop);
                NewRes.DragEnter += new DragEventHandler(C_DragEnter);
                NewRes.DragLeave += new EventHandler(C_DragLeave);
                NewRes.DragOver += new DragEventHandler(C_DragOver);
                ElementsGUI.Add(NewRes);
                SellectElement(Form1.AllSessions[s].Circuits[c], NewRes);
                UpdateDiagrams();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ElementsGUI[FitSelectedElement].Dispose();
            Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit].nElements--;
            ElementsGUI.RemoveAt(FitSelectedElement);
            DeletedElement.Input = Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit].Elements[FitSelectedElement].Input;
            DeletedElement.Output = Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit].Elements[FitSelectedElement].Output;
            Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit].Elements.RemoveAt(FitSelectedElement);
            ElementRemoved = true;
            RearrangeElementsIO(Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit]);
            ElementRemoved = false;
            FitSelectedElement = -1;
            UpdateElementGB();
            CircuitDeskTop.Refresh();
        }

        private void CircuitDeskTop_Paint(object sender, PaintEventArgs e)
        {
            if (EIS.nSsn > 0 && Form1.AllSessions[FitSelectedSession].nCircuits > 0)
            {
                DrawWires(Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit], e);
            }
        }

        private void DrawWires(Circuit C, PaintEventArgs e)
        {
            e.Graphics.Clear(CircuitDeskTop.BackColor);
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Point startP = new Point();
            Point endP = new Point();
            var pen = new Pen(Color.Black, 2);
            foreach (Link link in C.Links)
            {
                if (link.i % 2 == 0)
                    startP = new Point(ElementsGUI[link.iElement].Location.X, ElementsGUI[link.iElement].Location.Y + 10);
                else
                    startP = new Point(ElementsGUI[link.iElement].Location.X + 41, ElementsGUI[link.iElement].Location.Y + 10);

                if (link.j % 2 == 0)
                    endP = new Point(ElementsGUI[link.jElement].Location.X, ElementsGUI[link.jElement].Location.Y + 10);
                else
                    endP = new Point(ElementsGUI[link.jElement].Location.X + 41, ElementsGUI[link.jElement].Location.Y + 10);

                e.Graphics.DrawLine(pen, startP, endP);
            }
        }

        private void RearrangeElementsIO(Circuit C)
        {
            int i = 1;
            int iR = 0;
            int iC = 0;
            int iL = 0;

            foreach (Element E in C.Elements)
            {
                i++;
                E.Input = i;
                i++;
                E.Output = i;
                if (E.Mode == -1)
                {
                    i--;
                    E.Input = 0;
                    i--;
                    E.Output = 1;
                    E.name = "Input";
                }
                if (E.Mode == -2)
                {
                    i--;
                    E.Input = 2 * C.nElements - 2;
                    i--;
                    E.Output = 2 * C.nElements - 1;
                    E.name = "Output";
                }
                if (E.Mode == 1)
                {
                    iR++;
                    E.name = "R" + iR.ToString();
                }
                if (E.Mode == 2)
                {
                    iC++;
                    E.name = "C" + iC.ToString();
                }
                if (E.Mode == 3)
                {
                    iL++;
                    E.name = "L" + iL.ToString();
                }
            }

            if (ElementAdded)
            {
                foreach (Link L in C.Links)
                {
                    if (L.j == 2 * (C.nElements - 1) - 2) L.j = 2 * C.nElements - 2;
                }
            }



            if (ElementRemoved)
            {
                int nDeleted = 0;
                for (int k = C.nLinks - 1; k > -1; k--)
                {
                    if (C.Links[k].i == DeletedElement.Input ||
                        C.Links[k].i == DeletedElement.Output ||
                        C.Links[k].j == DeletedElement.Input ||
                        C.Links[k].j == DeletedElement.Output)
                    {
                        C.Links.RemoveAt(k);
                        nDeleted++;
                    }
                }
                C.nLinks = C.nLinks - nDeleted;

                foreach (Link L in C.Links)
                {
                    if (L.i > DeletedElement.Input)
                        L.i = L.i - 2;
                    if (L.j > DeletedElement.Output)
                        L.j = L.j - 2;

                    if (L.iElement > FitSelectedElement)
                        L.iElement = L.iElement - 1;

                    if (L.jElement > FitSelectedElement)
                        L.jElement = L.jElement - 1;
                }
            }
        }

        private int GetElementIndex(Circuit C, Panel Panel)
        {
            int ind = -1;
            foreach (Element E in C.Elements)
            {
                ind++;
                if (E.HashCode == Panel.GetHashCode()) break;
            }

            return ind;
        }

        private void SellectElement(Circuit C, Panel Panel)
        {
            int ind = -1;
            foreach (Element E in C.Elements)
            {
                ind++;
                if (E.HashCode == Panel.GetHashCode()) break;
            }

            FitSelectedElement = ind;

            int i = -1;
            foreach (Panel EGUI in ElementsGUI)
            {
                i++;
                if (C.Elements[i].Mode == -1)
                    EGUI.BackgroundImage = global::EISProjects.Properties.Resources.input;
                if (C.Elements[i].Mode == -2)
                    EGUI.BackgroundImage = global::EISProjects.Properties.Resources.output1;
                if (C.Elements[i].Mode == 1)
                    EGUI.BackgroundImage = global::EISProjects.Properties.Resources.res1;
                if (C.Elements[i].Mode == 2)
                    EGUI.BackgroundImage = global::EISProjects.Properties.Resources.cap1;
                if (C.Elements[i].Mode == 3)
                    EGUI.BackgroundImage = global::EISProjects.Properties.Resources.ind1;
            }

            if (C.Elements[ind].Mode == -1)
                Panel.BackgroundImage = global::EISProjects.Properties.Resources.selinput;
            if (C.Elements[ind].Mode == -2)
                Panel.BackgroundImage = global::EISProjects.Properties.Resources.seloutput1;
            if (C.Elements[ind].Mode == 1)
                Panel.BackgroundImage = global::EISProjects.Properties.Resources.selres;
            if (C.Elements[ind].Mode == 2)
                Panel.BackgroundImage = global::EISProjects.Properties.Resources.selcap;
            if (C.Elements[ind].Mode == 3)
                Panel.BackgroundImage = global::EISProjects.Properties.Resources.selind;
            Panel.Refresh();
            UpdateElementGB();
        }

        public bool CheckNewLink(Link NewLink, List<Link> AllLinks)
        {
            bool isNot = true;
            foreach (Link link in AllLinks)
            {
                if (link.i == NewLink.i && link.j == NewLink.j)
                {
                    isNot = false;
                    break;
                }
            }

            bool isValid = isNot;
            return isValid;
        }

        public void SortLinks(ref List<Link> AllLinks)
        {
            List<Link> BufLinks = new List<Link>() { };

            int nLinks;
            int Min;
            int iMin;
            int count;

            nLinks = 0;
            foreach (Link link in AllLinks)
            {
                nLinks++;
                BufLinks.Add(AllLinks[nLinks - 1]);
            }
            AllLinks.Clear();

            while (nLinks > 0)
            {
                nLinks = 0;
                foreach (Link link in BufLinks) nLinks++;

                if (nLinks > 0)
                {
                    Min = BufLinks[0].i;
                    iMin = 0;
                    count = -1;
                    foreach (Link link in BufLinks)
                    {
                        count++;
                        if (Min > link.i)
                        {
                            Min = link.i;
                            iMin = count;
                        }
                    }

                    AllLinks.Add(BufLinks[iMin]);
                    BufLinks.RemoveAt(iMin);
                }
            }
        }

        public void SetGraphPoints(Circuit circuit, List<Link> AllLinks)
        {
            int nLinks = 0;
            int iG = 0;
            foreach (Link link in AllLinks) nLinks++;

            //List<Link> BufLinks = new List<Link>() { };

            //List<SameGraphPoints> AllSameGraph = new List<SameGraphPoints>() { };

            if (nLinks > 0)
            {
                iG++;
                SameGraphPoints NewSG = new SameGraphPoints();
                NewSG.Points.Add(AllLinks[0].i);
                NewSG.Points.Add(AllLinks[0].j);
                circuit.AllSameGraph.Add(NewSG);

                for (int i = 1; i < nLinks; i++)
                {
                    int SameGraphIndex = -1;
                    bool isFound = false;
                    foreach (SameGraphPoints SG in circuit.AllSameGraph)
                    {
                        SameGraphIndex++;
                        foreach (int SGP in SG.Points)
                        {
                            if (AllLinks[i].i == SGP || AllLinks[i].j == SGP)
                            {
                                isFound = true;
                                break;
                            }
                        }
                        if (isFound) break;
                    }

                    if (isFound)
                    {
                        circuit.AllSameGraph[SameGraphIndex].Points.Add(AllLinks[i].i);
                        circuit.AllSameGraph[SameGraphIndex].Points.Add(AllLinks[i].j);
                    }
                    else
                    {
                        SameGraphPoints OtherNewSG = new SameGraphPoints();
                        OtherNewSG.Points.Add(AllLinks[i].i);
                        OtherNewSG.Points.Add(AllLinks[i].j);
                        circuit.AllSameGraph.Add(OtherNewSG);
                    }
                }
            }

            int ii = 0;
            int jj = 0;
            bool isChanged = true;
            while (isChanged)
            {
                isChanged = false;

                ii = -1;
                foreach (SameGraphPoints SG in circuit.AllSameGraph)
                {
                    ii++;
                    jj = -1;
                    foreach (SameGraphPoints TestSG in circuit.AllSameGraph)
                    {
                        jj++;
                        if (ii != jj)
                        {
                            foreach (int SGP in SG.Points)
                            {
                                foreach (int TestSGP in TestSG.Points)
                                {
                                    if (SGP == TestSGP)
                                    {
                                        isChanged = true;
                                        break;
                                    }
                                }
                                if (isChanged) break;
                            }
                        }
                        if (isChanged) break;
                    }
                    if (isChanged) break;
                }

                if (isChanged)
                {
                    int Minij = 0;
                    int Maxij = 0;
                    Minij = Math.Min(ii, jj);
                    Maxij = Math.Max(ii, jj);
                    foreach (int SGP in circuit.AllSameGraph[Maxij].Points)
                    {
                        circuit.AllSameGraph[Minij].Points.Add(SGP);
                    }
                    circuit.AllSameGraph.RemoveAt(Maxij);
                }

            }

            for (int k = 0; k < circuit.nElements; k++)
            {
                circuit.Elements[k].InputGraph = -1;
                circuit.Elements[k].OutputGraph = -1;

                int SGInd;

                bool isFounded = false;
                SGInd = -1;
                foreach (SameGraphPoints SG in circuit.AllSameGraph)
                {
                    SGInd++;
                    foreach (int SGP in SG.Points)
                    {
                        if (circuit.Elements[k].Input == SGP)
                        {
                            isFounded = true;
                            break;
                        }
                    }
                    if (isFounded) break;
                }
                if (isFounded) circuit.Elements[k].InputGraph = SGInd + 1;

                isFounded = false;
                SGInd = -1;
                foreach (SameGraphPoints SG in circuit.AllSameGraph)
                {
                    SGInd++;
                    foreach (int SGP in SG.Points)
                    {
                        if (circuit.Elements[k].Output == SGP)
                        {
                            isFounded = true;
                            break;
                        }
                    }
                    if (isFounded) break;
                }
                if (isFounded) circuit.Elements[k].OutputGraph = SGInd + 1;

            }

            int nSame = 0;
            foreach (SameGraphPoints SG in circuit.AllSameGraph) nSame++;
            circuit.nGraphPoint = nSame;

            //circuit.isTrue = true;

            //for (int GPoint = 1; GPoint <= 2 * (circuit.nElements - 1); GPoint++)
            //{
            //    bool isLink=false;
            //    foreach (Link L in circuit.Links)
            //    {
            //        if (GPoint == L.i || GPoint == L.j)
            //        {
            //            isLink = true;
            //            break;
            //        }
            //    }
            //    if (!isLink)
            //    {
            //        circuit.isTrue=false;
            //        break;
            //    }
            //}

            //if (circuit.isTrue)
            //{
            //    int[,] CGraph = new int[circuit.nElements - 2, 3];
            //    bool[] Visited = new bool[nSame];
            //    for (int i = 0; i < circuit.nElements - 2; i++) Visited[i] = false;

            //    CreateCGraph(circuit, ref CGraph);
            //    DFS(1, CGraph, circuit.nElements - 2, ref Visited);
            //    CreateCGraph(circuit, ref CGraph);
            //    if (Visited[nSame - 1] == false) circuit.isTrue = false;
            //    if (Visited[nSame - 1] == false) circuit.isTrue = false;
            //}

        }

        public void DFS(int v, int[,] CGraph, int nCGraph, ref bool[] Visited)
        {
            Visited[v - 1] = true;
            for (int i = 0; i < nCGraph; i++)
            {
                if (CGraph[i, 1] == v && Visited[CGraph[i, 2] - 1] == false)
                    DFS(CGraph[i, 2], CGraph, nCGraph, ref Visited);
                if (CGraph[i, 2] == v && Visited[CGraph[i, 1] - 1] == false)
                    DFS(CGraph[i, 1], CGraph, nCGraph, ref Visited);
            }
        }


        public bool CheckElementsIO(Circuit circuit, ref List<int> BadElements)
        {
            bool Err = false;
            for (int k = 0; k < circuit.nElements; k++)
            {
                if (circuit.Elements[k].InputGraph == circuit.Elements[k].OutputGraph && circuit.Elements[k].OutputGraph != -1)
                {
                    Err = true;
                    BadElements.Add(k);
                }
            }
            return Err;
        }

        public void RemoveLink(Circuit circuit, Link link)
        {
            int ind = -1;
            foreach (Link Lnk in circuit.Links)
            {
                ind++;
                if (Lnk.i == link.i && Lnk.j == link.j) break;
            }
            circuit.Links.RemoveAt(ind);
            circuit.nLinks--;
        }

        public void UpdateElementGB()
        {
            if (FitSelectedElement > 1)
            {
                GBElement.Enabled = true;
                TBElementName.Text = Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit].Elements[FitSelectedElement].name;
                if (Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit].Elements[FitSelectedElement].Mode == 1)
                {
                    TBElementKind.Text = "Resistor";
                    ElementVal1Name.Text = "Inital R:";

                    TBElementVal1.Visible = true;
                    ElementVal1Name.Visible = true;

                    ElementVal2Name.Visible = false;
                    TBElementVal2.Visible = false;
                }
                if (Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit].Elements[FitSelectedElement].Mode == 2)
                {
                    TBElementKind.Text = "Capacitor";
                    ElementVal1Name.Text = "Inital C:";

                    TBElementVal1.Visible = true;
                    ElementVal1Name.Visible = true;

                    TBElementVal2.Visible = false;
                    ElementVal2Name.Visible = false;
                }
                if (Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit].Elements[FitSelectedElement].Mode == 3)
                {
                    TBElementKind.Text = "Inductor";
                    ElementVal1Name.Text = "Inital L:";

                    TBElementVal1.Visible = true;
                    ElementVal1Name.Visible = true;

                    TBElementVal2.Visible = false;
                    ElementVal2Name.Visible = false;
                }
                TBElementVal1.Text = Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit].Elements[FitSelectedElement].Val.ToString();
            }
            else
            {
                TBElementName.Text = "";
                TBElementKind.Text = "";
                GBElement.Enabled = false;

                TBElementVal1.Visible = false;
                ElementVal1Name.Visible = false;

                TBElementVal2.Visible = false;
                ElementVal2Name.Visible = false;
            }
        }

        private void TBElementVal1_TextChanged(object sender, EventArgs e)
        {
            DigitTextChange(ref Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit].Elements[FitSelectedElement].Val, TBElementVal1);
            UpdateDiagrams();
        }

        private void TBElementVal2_TextChanged(object sender, EventArgs e)
        {
            DigitTextChange(ref Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit].Elements[FitSelectedElement].Val2, TBElementVal2);
            UpdateDiagrams();
        }

        private void DigitTextChange(ref double digit, TextBox tb)
        {
            try
            {
                digit = Convert.ToDouble(tb.Text);
            }
            catch
            {
                tb.Text = digit.ToString();
                MessageBox.Show("Please type digit only ...");
            }
        }

        private void BtnCheck_Click(object sender, EventArgs e)
        {
            double ReZ = 0;
            double ImZ = 0;

            int ma = 0;
            foreach (Element E in Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit].Elements)
            {
                if (E.Mode == 1 || E.Mode == 2 || E.Mode == 3) ma++;
            }

            double[] a = new double[ma];
            int nElements = Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit].nElements - 2;
            int nGraphPoints = Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit].nGraphPoint;
            int[,] CGraph = new int[nElements, 3];

            int i = -1;
            foreach (Element E in Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit].Elements)
            {
                if (E.Mode == 1 || E.Mode == 2 || E.Mode == 3)
                {
                    i++;
                    a[i] = E.Val;
                }
            }

            CreateCGraph(Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit], ref CGraph);

            int[,] CGraphDag = new int[3, nElements];

            for (int ii = 0; ii < nElements; ii++)
                for (int jj = 0; jj < 3; jj++)
                    CGraphDag[jj, ii] = CGraph[ii, jj];

            double FrqStart = Form1.AllSessions[FitSelectedSession].ACFrqFrom;
            double FrqTo = Form1.AllSessions[FitSelectedSession].ACFrqTo;
            double FrqStep = Form1.AllSessions[FitSelectedSession].ACFrqStep;
            int nData = 0;
            for (double frq = FrqStart; frq <= FrqTo; frq = frq * FrqStep) nData++;
            double[] frqTable = new double[Form1.AllSessionsData[FitSelectedSession].ReceivedDataCount];
            double[] ReZTable = new double[nData];
            double[] ImZTable = new double[nData];

            i = -1;
            for (double frq = FrqStart; frq <= FrqTo; frq = frq * FrqStep)
            {
                i++;
                graphimpedancereim(ref frq, a, ref ma, ref ReZ, ref ImZ, ref nGraphPoints, CGraphDag, ref nElements);
                ReZTable[i] = ReZ;
                ImZTable[i] = ImZ;
                frqTable[i] = frq;
            }

            //Plot(ReZTable, nData, chart1, "ReZ", FrqStart, FrqTo);
            //ClearPlot(chart);
            PlotFittedImpedance(chart1, frqTable, Form1.AllSessionsData[FitSelectedSession].ReZ, Form1.AllSessionsData[FitSelectedSession].ImZ, ReZTable, ImZTable, nData);
            GBFitting.Enabled = true;
        }

        private void UpdateDiagrams()
        {
            //double ReZ = 0;
            //double ImZ = 0;

            //int ma = 0;
            //foreach (Element E in Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit].Elements)
            //{
            //    if (E.Mode == 1 || E.Mode == 2 || E.Mode == 3) ma++;
            //}

            //double[] a = new double[ma];
            //int nElements = Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit].nElements - 2;
            //int nGraphPoints = Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit].nGraphPoint;
            //int[,] CGraph = new int[nElements, 3];

            //int i = -1;
            //foreach (Element E in Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit].Elements)
            //{
            //    if (E.Mode == 1 || E.Mode == 2 || E.Mode == 3)
            //    {
            //        i++;
            //        a[i] = E.Val;
            //    }
            //}

            //CreateCGraph(Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit], ref CGraph);

            //int[,] CGraphDag = new int[3, nElements];

            //for (int ii = 0; ii < nElements; ii++)
            //    for (int jj = 0; jj < 3; jj++)
            //        CGraphDag[jj, ii] = CGraph[ii, jj];

            //double FrqStart = Form1.AllSessions[FitSelectedSession].ACFrqFrom;
            //double FrqTo = Form1.AllSessions[FitSelectedSession].ACFrqTo;
            //double FrqStep = Form1.AllSessions[FitSelectedSession].ACFrqStep;
            //int nData = 0;
            //for (double frq = FrqStart; frq <= FrqTo; frq = frq * FrqStep) nData++;
            //double[] frqTable = new double[Form1.AllSessionsData[FitSelectedSession].ReceivedDataCount];
            //double[] ReZTable = new double[nData];
            //double[] ImZTable = new double[nData];

            //i = -1;
            //for (double frq = FrqStart; frq <= FrqTo; frq = frq * FrqStep)
            //{
            //    i++;
            //    graphimpedancereim(ref frq, a, ref ma, ref ReZ, ref ImZ, ref nGraphPoints, CGraphDag, ref nElements);
            //    ReZTable[i] = ReZ;
            //    ImZTable[i] = ImZ;
            //    frqTable[i] = frq;
            //}

            ////Plot(ReZTable, nData, chart1, "ReZ", FrqStart, FrqTo);
            ////ClearPlot(chart);
            //PlotFittedImpedance(chart1, frqTable, Form1.AllSessionsData[FitSelectedSession].ReZ, Form1.AllSessionsData[FitSelectedSession].ImZ, ReZTable, ImZTable, nData);
            //GBFitting.Enabled = true;
        }


        private void CreateCGraph(Circuit C, ref int[,] CGraph)
        {
            int i = -1;
            foreach (Element E in C.Elements)
            {
                if (E.Mode == 1 || E.Mode == 2 || E.Mode == 3)
                {
                    i++;
                    CGraph[i, 0] = E.InputGraph;
                    CGraph[i, 1] = E.OutputGraph;
                    CGraph[i, 2] = E.Mode;
                }
            }
        }

        private void BtnFindFit_Click(object sender, EventArgs e)
        {

            int ma = 0;
            foreach (Element E in Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit].Elements)
            {
                if (E.Mode == 1 || E.Mode == 2 || E.Mode == 3) ma++;
            }

            double[] a = new double[ma];
            int[] ia = new int[ma];
            double[] InitialValues = new double[ma];
            int nElements = Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit].nElements - 2;
            int nGraphPoints = Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit].nGraphPoint;
            int[,] CGraph = new int[nElements, 3];

            int i = -1;
            foreach (Element E in Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit].Elements)
            {
                if (E.Mode == 1 || E.Mode == 2 || E.Mode == 3)
                {
                    i++;
                    ia[i] = 1;
                    a[i] = E.Val;
                    InitialValues[i] = E.Val;
                }
            }

            CreateCGraph(Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit], ref CGraph);

            int[,] CGraphDag = new int[3, nElements];

            for (int ii = 0; ii < nElements; ii++)
                for (int jj = 0; jj < 3; jj++)
                    CGraphDag[jj, ii] = CGraph[ii, jj];

            double FrqStart = Form1.AllSessions[FitSelectedSession].ACFrqFrom;
            double FrqTo = Form1.AllSessions[FitSelectedSession].ACFrqTo;
            double FrqStep = Form1.AllSessions[FitSelectedSession].ACFrqStep;
            int nData = 0;
            for (double frq = FrqStart; frq <= FrqTo; frq = frq * FrqStep) nData++;

            double[] FrqTable = new double[nData];
            double[] AbsZ2 = new double[nData];
            int k = -1;
            for (double frq = FrqStart; frq <= FrqTo; frq = frq * FrqStep)
            {
                k++;
                FrqTable[k] = frq;
                AbsZ2[k] = 4.5 * 4.5;
            }

            FindFitMethodPolar(ref nData, FrqTable, AbsZ2, InitialValues, ref ma, ia, ref nGraphPoints, CGraphDag, ref nElements, a);

            i = -1;
            foreach (Element E in Form1.AllSessions[FitSelectedSession].Circuits[FitSelectedCircuit].Elements)
            {
                if (E.Mode == 1 || E.Mode == 2 || E.Mode == 3)
                {
                    i++;
                    E.Val = a[i];
                }
            }
        }
    }
}
