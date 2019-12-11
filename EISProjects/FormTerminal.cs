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

namespace EISProjects
{
    public partial class FormTerminal : Form
    {
        bool isAllowToTick = true;
        int TotalTime = 0;
        int WaitTime = 5;
        bool isDataReceived = false;
        bool isDataReceivedSet = false;
        int HistoryIndex =0 ;
        public FormTerminal()
        {
            InitializeComponent();
            RBSlashr.Checked = true;
            TimerReceiver.Stop();
            TBOutput.Text = ">>> ";
            History.Items.Add("");
        }

        private void FormTerminal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isDataReceivedSet)
            {
                Form1.Port.DataReceived -= new System.IO.Ports.SerialDataReceivedEventHandler(this.EISPort_DataReceived);
                isDataReceivedSet = false;
            }

            Form1.isFormTerminal = false;
            e.Cancel = true;
            this.Hide();
        }

        public void EISPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            isDataReceived = true;
        }

        private void TBOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter && e.KeyCode != Keys.Up && e.KeyCode != Keys.Down) return;
            if (e.KeyCode != Keys.Enter)
            {
                if (e.KeyCode == Keys.Up)
                    HistoryIndex++;
                else
                    HistoryIndex--;
                if (HistoryIndex >= History.Items.Count) HistoryIndex = History.Items.Count - 1;
                if (HistoryIndex < 0) HistoryIndex = 0;
                TBOrder.Text = History.Items[HistoryIndex].ToString();
                return;
            }

            string order = TBOrder.Text;
            if (order!="") History.Items.Insert(1, order);
            HistoryIndex = 0;
            string CompleteOrder = order;

            if (RBSlashr.Checked) CompleteOrder = order + "\r";
            if (RBSlashn.Checked) CompleteOrder = order + "\n";

            TBOutput.Text = TBOutput.Text + order + "\n" + ">>> ";
            ScrollToEnd();
            TBOrder.Text = "";

            try
            {
                Form1.Port.DiscardOutBuffer(); //Clear Buffer
                Form1.Port.DiscardInBuffer(); //Clear Buffer
                Form1.Port.Write(CompleteOrder);
                Thread.Sleep(100);
            }
            catch { }
            TotalTime = 0;
            TimerReceiver.Start();
        }

        private void ScrollToEnd()
        {
            TBOutput.SelectionStart = TBOutput.Text.Length;
            TBOutput.ScrollToCaret();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            TBOutput.Text = ">>> ";
        }

        private void TimerReceiver_Tick(object sender, EventArgs e)
        {
            if (isAllowToTick)
            {
                isAllowToTick = false;
                TotalTime = TotalTime + TimerReceiver.Interval;
                if (TotalTime > WaitTime*1000)
                {
                    TimerReceiver.Stop();
                    isAllowToTick = true;
                    return;
                }

                if (isDataReceived)
                {
                    isDataReceived = false;
                    //Thread.Sleep(50);
                    try
                    {
                        //string output = Form1.Port.ReadExisting();
                        while (Form1.Port.BytesToRead != 0)
                        {
                            char output = (char)Form1.Port.ReadByte();
                            if ((byte)output >= 32 && (byte)output <= 126)
                                TBOutput.Text = TBOutput.Text + output;
                            else
                                TBOutput.Text = TBOutput.Text + "{" + ((int)output).ToString("X2") + "}";
                        }

                        TBOutput.Text = TBOutput.Text + "\n" + ">>> ";
                        ScrollToEnd();
                    }
                    catch
                    {
                    }
                    TimerReceiver.Stop();
                }

                isAllowToTick = true;
            }
        }

        private void TBWaitTime_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int s = Convert.ToInt32(TBWaitTime.Text);
                if (s > 0)
                    WaitTime = s;
                else
                    TBWaitTime.Text = WaitTime.ToString();
            }
            catch
            {
                TBWaitTime.Text = WaitTime.ToString();
            }
        }

        private void FormTerminal_Shown(object sender, EventArgs e)
        {
            
        }

        private void FormTerminal_Load(object sender, EventArgs e)
        {
            
        }

        private void FormTerminal_Paint(object sender, PaintEventArgs e)
        {
            if (!isDataReceivedSet)
            {
                Form1.Port.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.EISPort_DataReceived);
                isDataReceivedSet = true;
            }
        }

        private void History_DoubleClick(object sender, EventArgs e)
        {
            TBOrder.Text = History.Items[History.SelectedIndex].ToString();

            string order = TBOrder.Text;
            HistoryIndex = 0;
            string CompleteOrder = order;

            if (RBSlashr.Checked) CompleteOrder = order + "\r";
            if (RBSlashn.Checked) CompleteOrder = order + "\n";

            TBOutput.Text = TBOutput.Text + order + "\n" + ">>> ";
            ScrollToEnd();
            TBOrder.Text = "";

            try
            {
                Form1.Port.DiscardOutBuffer(); //Clear Buffer
                Form1.Port.DiscardInBuffer(); //Clear Buffer
                Form1.Port.Write(CompleteOrder);
                Thread.Sleep(100);
            }
            catch { }
            TotalTime = 0;
            TimerReceiver.Start();
        }

        private void History_Click(object sender, EventArgs e)
        {
            TBOrder.Text = History.Items[History.SelectedIndex].ToString();
        }
    }
}
