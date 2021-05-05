using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace EISProjects
{
    public partial class FormDataGrid : Form
    {
        public static int DGSelectedSession = -1;
        public static bool isExportAllSession = false;
        public static double Yfactor = 1.0;

        public FormDataGrid()
        {
            InitializeComponent();

            ExportFileDialog.Filter = "XML Files|*.xml";
        }

        private void RefreshDataGrid()
        {
            SsnGridView.Rows.Clear();
            SsnGridView.Columns.Clear();

            if (DGSelectedSession > -1)
            {
                BtnExportSsn.Enabled = true;

                string NormalVoltPGCurrent = "Voltage [V]";
                string NormalCurrentPGVolt = "Current [A]";
                string NormalSetVoltPGSetCurrent = "Real Voltage [V]";
                string PGxunit = "";
                if (Form1.AllSessions[DGSelectedSession].PGmode == 3)
                {
                    if (Form1.AllSessions[DGSelectedSession].Mode == 2 || Form1.AllSessions[DGSelectedSession].Mode == 3)
                    {
                        if (Form1.AllSessions[DGSelectedSession].IVCurrentRangeMode == 0)
                            PGxunit = "[A]";
                        else if (Form1.AllSessions[DGSelectedSession].IVCurrentRangeMode >= 1 && Form1.AllSessions[DGSelectedSession].IVCurrentRangeMode <= 3)
                            PGxunit = "[mA]";
                        else if (Form1.AllSessions[DGSelectedSession].IVCurrentRangeMode >= 4 && Form1.AllSessions[DGSelectedSession].IVCurrentRangeMode <= 6)
                            PGxunit = "[uA]";
                        else if (Form1.AllSessions[DGSelectedSession].IVCurrentRangeMode == 7)
                            PGxunit = "[nA]";
                    }
                    else if (Form1.AllSessions[DGSelectedSession].Mode == 4)
                    {
                        if (Form1.AllSessions[DGSelectedSession].PulseCurrentRangeMode == 0)
                            PGxunit = "[A]";
                        else if (Form1.AllSessions[DGSelectedSession].PulseCurrentRangeMode >= 1 && Form1.AllSessions[DGSelectedSession].PulseCurrentRangeMode <= 3)
                            PGxunit = "[mA]";
                        else if (Form1.AllSessions[DGSelectedSession].PulseCurrentRangeMode >= 4 && Form1.AllSessions[DGSelectedSession].PulseCurrentRangeMode <= 6)
                            PGxunit = "[uA]";
                        else if (Form1.AllSessions[DGSelectedSession].PulseCurrentRangeMode == 7)
                            PGxunit = "[nA]";
                    }
                    NormalVoltPGCurrent = "Current " + PGxunit;
                    NormalCurrentPGVolt = "Real Current [A]";
                    NormalSetVoltPGSetCurrent = "Voltage [V]";
                }

                switch (Form1.AllSessions[DGSelectedSession].Mode)
                {
                    case 0:
                        if (Form1.AllSessions[DGSelectedSession].isStarted)
                        {
                            SsnGridView.Columns.Add("Frequency [Hz]", "Frequency [Hz]  ");
                            SsnGridView.Columns.Add("Re(Z) [Ohm]", "Re(Z) [Ohm]     ");
                            SsnGridView.Columns.Add("-Im(Z) [Ohm]", "-Im(Z) [Ohm]     ");
                            SsnGridView.Columns.Add("R [Ohm]", "R [Ohm]         ");
                            SsnGridView.Columns.Add("Theta [Degree]", "Theta [Degree]  ");
                            for (int f = 0; f < Form1.AllSessionsData[DGSelectedSession].ReceivedDataCount; f++)
                            {
                                SsnGridView.Rows.Add("");
                                SsnGridView.Rows[f].Cells[0].Value = Form1.AllSessionsData[DGSelectedSession].Frq[f];
                                SsnGridView.Rows[f].Cells[1].Value = Form1.AllSessionsData[DGSelectedSession].ReZ[f];
                                SsnGridView.Rows[f].Cells[2].Value = -Form1.AllSessionsData[DGSelectedSession].Imz[f];
                                SsnGridView.Rows[f].Cells[3].Value = (Math.Sqrt(Math.Pow(Form1.AllSessionsData[DGSelectedSession].ReZ[f], 2.0) + Math.Pow(Form1.AllSessionsData[DGSelectedSession].Imz[f], 2.0)));
                                SsnGridView.Rows[f].Cells[4].Value = (Math.Atan2(Form1.AllSessionsData[DGSelectedSession].Imz[f], Form1.AllSessionsData[DGSelectedSession].ReZ[f]));
                            }
                        }
                        break;
                    case 1:
                        if (Form1.AllSessions[DGSelectedSession].isStarted)
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
                            for (int f = 0; f < Form1.AllSessionsData[DGSelectedSession].ReceivedDataCount; f++)
                            {
                                double frq = Form1.AllSessions[DGSelectedSession].ACFrqConstant;
                                SsnGridView.Rows.Add("");
                                SsnGridView.Rows[f].Cells[0].Value = Form1.AllSessionsData[DGSelectedSession].Vlt[f];
                                SsnGridView.Rows[f].Cells[1].Value = Math.Pow(Form1.AllSessionsData[DGSelectedSession].Imz[f] * frq * 2.0 * Math.PI, 2.0) * uF2;
                                SsnGridView.Rows[f].Cells[2].Value = Form1.AllSessionsData[DGSelectedSession].Amp[f] * mA;
                                SsnGridView.Rows[f].Cells[3].Value = Form1.AllSessionsData[DGSelectedSession].ReZ[f];
                                SsnGridView.Rows[f].Cells[4].Value = Form1.AllSessionsData[DGSelectedSession].Imz[f];
                                SsnGridView.Rows[f].Cells[5].Value = (Math.Sqrt(Math.Pow(Form1.AllSessionsData[DGSelectedSession].ReZ[f], 2.0) + Math.Pow(Form1.AllSessionsData[DGSelectedSession].Imz[f], 2.0)));
                                SsnGridView.Rows[f].Cells[6].Value = (Math.Atan2(Form1.AllSessionsData[DGSelectedSession].Imz[f], Form1.AllSessionsData[DGSelectedSession].ReZ[f]));
                            }
                        }
                        break;
                    case 2:
                        if (Form1.AllSessions[DGSelectedSession].isStarted)
                        {
                            SsnGridView.Columns.Add(NormalVoltPGCurrent, NormalVoltPGCurrent);
                            SsnGridView.Columns.Add(NormalCurrentPGVolt, NormalCurrentPGVolt);
                            SsnGridView.Columns.Add("Time [sec]", "Time [sec]");
                            SsnGridView.Columns.Add(NormalSetVoltPGSetCurrent, NormalSetVoltPGSetCurrent);
                            for (int f = 0; f < Form1.AllSessionsData[DGSelectedSession].ReceivedDataCount; f++)
                            {
                                SsnGridView.Rows.Add("");
                                SsnGridView.Rows[f].Cells[0].Value = Form1.AllSessionsData[DGSelectedSession].Vlt[f];
                                SsnGridView.Rows[f].Cells[1].Value = Form1.AllSessionsData[DGSelectedSession].Amp[f];
                                SsnGridView.Rows[f].Cells[2].Value = Form1.AllSessionsData[DGSelectedSession].ReZ[f];
                                SsnGridView.Rows[f].Cells[3].Value = Form1.AllSessionsData[DGSelectedSession].Imz[f];
                            }
                        }
                        break;
                    case 3:
                        if (Form1.AllSessions[DGSelectedSession].isStarted)
                        {
                            SsnGridView.Columns.Add(NormalVoltPGCurrent, NormalVoltPGCurrent);
                            SsnGridView.Columns.Add(NormalCurrentPGVolt, NormalCurrentPGVolt);
                            SsnGridView.Columns.Add("Time [sec]", "Time [sec]");
                            SsnGridView.Columns.Add(NormalSetVoltPGSetCurrent, NormalSetVoltPGSetCurrent);
                            for (int f = 0; f < Form1.AllSessionsData[DGSelectedSession].ReceivedDataCount; f++)
                            {
                                SsnGridView.Rows.Add("");
                                SsnGridView.Rows[f].Cells[0].Value = Form1.AllSessionsData[DGSelectedSession].Vlt[f];
                                SsnGridView.Rows[f].Cells[1].Value = Form1.AllSessionsData[DGSelectedSession].Amp[f];
                                SsnGridView.Rows[f].Cells[2].Value = Form1.AllSessionsData[DGSelectedSession].ReZ[f];
                                SsnGridView.Rows[f].Cells[3].Value = Form1.AllSessionsData[DGSelectedSession].Imz[f];
                            }
                        }
                        break;
                    case 4:
                        if (Form1.AllSessions[DGSelectedSession].isStarted)
                        {
                            SsnGridView.Columns.Add(NormalVoltPGCurrent, NormalVoltPGCurrent);
                            SsnGridView.Columns.Add(NormalCurrentPGVolt, NormalCurrentPGVolt);
                            SsnGridView.Columns.Add("Time [sec]", "Time [sec]");
                            SsnGridView.Columns.Add(NormalSetVoltPGSetCurrent, NormalSetVoltPGSetCurrent);
                            for (int f = 0; f < Form1.AllSessionsData[DGSelectedSession].ReceivedDataCount; f++)
                            {
                                SsnGridView.Rows.Add("");
                                SsnGridView.Rows[f].Cells[0].Value = Form1.AllSessionsData[DGSelectedSession].Vlt[f];
                                SsnGridView.Rows[f].Cells[1].Value = Form1.AllSessionsData[DGSelectedSession].Amp[f];
                                SsnGridView.Rows[f].Cells[2].Value = Form1.AllSessionsData[DGSelectedSession].ReZ[f];
                                SsnGridView.Rows[f].Cells[3].Value = Form1.AllSessionsData[DGSelectedSession].Imz[f];
                            }
                        }
                        break;
                    default:

                        break;
                }
                
            }
            else
            {
                BtnExportSsn.Enabled = false;
            }
        }

        private void BtnExportSsn_Click(object sender, EventArgs e)
        {
            isExportAllSession = false;
            ExportFileDialog.Filter = "XML Files (*.xml)|*.xml|Data Files (*.dat)|*.dat";
            ExportFileDialog.ShowDialog();
        }

        private void BtnExportAllSsns_Click(object sender, EventArgs e)
        {
            isExportAllSession = true;
            ExportFileDialog.Filter = "XML Files (*.xml)|*.xml";
            ExportFileDialog.ShowDialog();
        }

        private void SessionName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DGSelectedSession = SessionName.SelectedIndex;
            CBUnit.SelectedIndex = 2;
            /*if (Form1.AllSessions[DGSelectedSession].Mode == 2 || Form1.AllSessions[DGSelectedSession].Mode == 3 || Form1.AllSessions[DGSelectedSession].Mode == 4)
            {
                if (Form1.AllSessions[DGSelectedSession].IVCurrentRangeMode == 0)
                    CBUnit.SelectedIndex = 2;
                else if (Form1.AllSessions[DGSelectedSession].IVCurrentRangeMode == 1)
                    CBUnit.SelectedIndex = 1;
                else
                    CBUnit.SelectedIndex = 0;
            }*/

            RefreshDataGrid();
        }

        private void FormDataGrid_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Form1.isFormDG = false;
            this.Hide();
        }

        private void ExportFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            if (isExportAllSession)
            {
                ExportAllSessions(ExportFileDialog.FileName);
            }
            else
            {
                if (ExportFileDialog.FilterIndex == 1) ExportThisSession(Form1.AllSessions[DGSelectedSession], ExportFileDialog.FileName);
                if (ExportFileDialog.FilterIndex == 2) ExportData(Form1.AllSessions[DGSelectedSession], Form1.AllSessionsData[DGSelectedSession], ExportFileDialog.FileName);
            }
        }

        private void ExportData(Sessions S, SessionOutputData SD, string Path)
        {
            try
            {
                StreamWriter FileProtocol = new StreamWriter(Path);

                for (int i = 0; i < SD.ReceivedDataCount; i++)
                {
                    if (S.Mode == 0) FileProtocol.Write(SD.Frq[i].ToString() + "   " + (SD.ReZ[i] * Yfactor).ToString() + "   " + (-SD.Imz[i] * Yfactor).ToString() + "\n");
                    if (S.Mode == 1) FileProtocol.Write(SD.Vlt[i].ToString() + "   " + (SD.ReZ[i] * Yfactor).ToString() + "   " + (SD.Imz[i] * Yfactor).ToString() + "\n");
                    //if (S.Mode == 2) FileProtocol.Write(SD.Amp[i].ToString() + "   " + (SD.ReZ[i] * Yfactor).ToString() + "   " + (SD.ImZ[i] * Yfactor).ToString() + "\n");
                    if (S.Mode == 2 || S.Mode == 3 || S.Mode == 4) FileProtocol.Write(SD.Vlt[i].ToString() + "   " + (SD.Amp[i] * Yfactor).ToString() + "   " + (SD.ReZ[i] * Yfactor).ToString() + "   " + (SD.Imz[i] * Yfactor).ToString() + "\n");
                }

                FileProtocol.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error in writing to file ...");
            }
        }

        private void ExportThisSession(Sessions S, string FileName)
        {
            DataSet ds = new DataSet(S.name);
            DataTable table = new DataTable(S.name);

            foreach (DataGridViewColumn col in SsnGridView.Columns)
                table.Columns.Add(col.HeaderText, typeof(string));

            foreach (DataGridViewRow row in SsnGridView.Rows)
            {
                table.Rows.Add();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    table.Rows[row.Index][cell.ColumnIndex] = cell.Value.ToString();
                }
            }

            ds.Tables.Add(table);
            try
            {
                ds.WriteXml(FileName);
            }
            catch
            {
                MessageBox.Show("Error in writing to file ...");
            }
        }

        private void ExportAllSessions(string FileName)
        {
            int CurrentIndex = SessionName.SelectedIndex;
            DataSet ds = new DataSet("All Sessions");

            int iS = -1;
            foreach (Sessions S in Form1.AllSessions)
            {
                iS++;
                SessionName.SelectedIndex = iS;
                DataTable table = new DataTable(S.name);

                foreach (DataGridViewColumn col in SsnGridView.Columns)
                    table.Columns.Add(col.HeaderText, typeof(string));

                foreach (DataGridViewRow row in SsnGridView.Rows)
                {
                    table.Rows.Add();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        table.Rows[row.Index][cell.ColumnIndex] = cell.Value.ToString();
                    }
                }
                ds.Tables.Add(table);
            }

            try
            {
                ds.WriteXml(FileName);
            }
            catch
            {
                MessageBox.Show("Error in writing to file ...");
            }

            SessionName.SelectedIndex = CurrentIndex;
        }

        private void CBUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DGSelectedSession != -1)
            {
                if (CBUnit.SelectedIndex == 0)
                    Yfactor = 1000000.0;
                else if (CBUnit.SelectedIndex == 1)
                    Yfactor = 1000.0;
                else if (CBUnit.SelectedIndex == 2)
                    Yfactor = 1.0;
                else if (CBUnit.SelectedIndex == 3)
                    Yfactor = 0.001;
                else if (CBUnit.SelectedIndex == 4)
                    Yfactor = 0.000001;

                RefreshDataGrid();
            }
        }






    }
}
