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
using System.Management;



namespace EISProjects
{
    public partial class FormPort : Form
    {
        Form1 Form1;
        public static SerialPort CheckPort = new SerialPort("COM1", 921600, Parity.None, 8, StopBits.One);
        public static string ReadToChar = "\r";
        public static string FoundedPort = "";
        public static int DeviceVersion = 0;
        bool isFounded = false;
        public static int CheckPortTimeoutSec = Form1.FactoryDefault.CheckPortTimeoutSec;
        UInt16 PageNumber = 128;
        UInt16 PageSize = 256;
        int InteraPageSleep = 30;
        //int InteraWordSleep = 100;
        UInt16 pass = 0;
        public static int ReconnectingCount = 0;

        public FormPort(Form1 f)
        {
            InitializeComponent();
            this.Form1 = f;
            textBox1.Text = CheckPortTimeoutSec.ToString();
            CheckPort.NewLine = "\r";

            WqlEventQuery removeQuery = new WqlEventQuery("SELECT * FROM __InstanceDeletionEvent WITHIN 1 WHERE TargetInstance ISA 'Win32_SerialPort'");
            ManagementEventWatcher removeWatcher = new ManagementEventWatcher(removeQuery);
            removeWatcher.EventArrived += new EventArrivedEventHandler(DeviceRemovedEvent);
            removeWatcher.Start();
        }

        private void DeviceRemovedEvent(object sender, EventArrivedEventArgs e)
        {
            if (!EIS.Connected) return;
            Form1.IsReconnectingMode = true;
            try
            {
                Disconnect();
            }
            catch (Exception ex)
            {
               // MessageBox.Show("Something went wrong when we wanted to reconnect the system. Error number:1");
            }
            notification1.BalloonTipText = "reconnecting...";
            notification1.ShowBalloonTip(5000);
            for (int i = 0; i < 10; i++)
            {
                if (!EIS.Connected)
                {
                    try
                    {
                        Thread.Sleep(1000);
                        richTextBox1.Text = "";
                        try
                        {
                          Form1.Port.Open();
                          Thread.Sleep(100); Form1.Port.Write(";"); Thread.Sleep(100); Form1.Port.Write(";");
                          Thread.Sleep(100); Form1.Port.Write("\r"); Thread.Sleep(100);
                          Form1.Port.DiscardOutBuffer(); //Clear Buffer
                          Form1.Port.DiscardInBuffer(); //Clear Buffer
                          Form1.Port.Write("you?" + ReadToChar);
                          Thread.Sleep(100);
                          string Order = "";
                    
                          Order = Form1.Port.ReadExisting();
                          Form1.Port.DiscardOutBuffer(); //Clear Buffer
                          Form1.Port.DiscardInBuffer(); //Clear Buffer
                          if (Order.StartsWith("EIS"))
                          {
                              EIS.Connected = true;
                              isFounded = true;
                              SetPortprogressBar(10); 
                              //Form1.Status.Text = "Application is reconnected.";
                          }
                        }
                        catch { }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Somthing went wrong when we want to reconnect the system. Error number:2");
                    }
                }
            }

            if (EIS.Connected)
            {
              //  MessageBox.Show("The system reconnected.");
                SetPortprogressBar(PortprogressBar.Maximum);
                SetStatus("Application is Connected to Device.");
                Form1.IsReconnectingMode = false;
              //  notification1.
                notification1.BalloonTipText = "successfully reconnected.";
                notification1.ShowBalloonTip(2000);
               // Form1.IsReconnectingMode = false;
            }
            else
                MessageBox.Show("Sorry. We could not reconnect the system.\nCheck the USB cable and reconnect manually.");
            
        }

        private void BtnDisconnect_Click(object sender, EventArgs e)
        {
            Disconnect();
        }

        private void Disconnect()
        {
            richTextBox1.Text = "";
            try
            {
                if (Form1.Port.IsOpen) Form1.Port.Close();
            }
            catch { }
            EIS.Connected = false;
            FoundedPort = "";
            DeviceVersion = 0;
            isFounded = false;
            SetPortprogressBar(0);
            SetStatus("Application is Disconnected.");
        }

        delegate void SetIntCallback(int value);

        private void SetPortprogressBar(int value)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.PortprogressBar.InvokeRequired)
            {
                SetIntCallback d = new SetIntCallback(SetPortprogressBar);
                this.Invoke(d, new object[] { value });
            }
            else
            {
                try
                {
                    this.PortprogressBar.Value = value;
                    this.PortprogressBar.Refresh();
                }
                catch
                {
                }
            }
        }

        delegate void SetStringCallback(string value);

        private void SetStatus(string value)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.PortprogressBar.InvokeRequired)
            {
                SetStringCallback d = new SetStringCallback(SetStatus);
                this.Invoke(d, new object[] { value });
            }
            else
            {
                try
                {
                    Form1.Status.Text = value;
                    Form1.Status.Refresh();
                }
                catch
                {
                }
            }
        }

        private void SetUpdateprogressBar(int value)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.UpdateProgressbar.InvokeRequired)
            {
                SetIntCallback d = new SetIntCallback(SetUpdateprogressBar);
                this.Invoke(d, new object[] { value });
            }
            else
            {
                this.UpdateProgressbar.Value = value;
                this.UpdateProgressbar.Refresh();
            }
        }

        private void SetUpdatePageProgressbar(int value)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.UpdatePageProgressbar.InvokeRequired)
            {
                SetIntCallback d = new SetIntCallback(SetUpdatePageProgressbar);
                this.Invoke(d, new object[] { value });
            }
            else
            {
                this.UpdatePageProgressbar.Value = value;
                this.UpdatePageProgressbar.Refresh();
            }
        }

        private void BtnShowPorts_Click(object sender, EventArgs e)
        {
            DetectAndConnect();
        }

        private void DetectAndConnect()
        {
            string DeviceName = "";
            string Ver = "";
            isFounded = false;
            SetPortprogressBar(1);
            for (int trynum = 0; trynum < 2; trynum++)
            {
                if (!isFounded)
                {
                    richTextBox1.Text = "";
                    if (trynum == 0)
                        Form1.Status.Text = "Searching ...";
                    else
                        Form1.Status.Text = "Searching ...";
                    Form1.Status.Refresh();
                    string[] ArrayComPortsNames = null;
                    int index = -1;
                    FoundedPort = "";
                    DeviceVersion = 0;

                    string ComPortName = null;
                    ArrayComPortsNames = SerialPort.GetPortNames();
                    PortprogressBar.Maximum = 2 * ArrayComPortsNames.Length + 1;
                    do
                    {
                        index++;

                        if (!isFounded)
                        {
                            int newval = PortprogressBar.Value + 1;
                            SetPortprogressBar(newval);

                            if (CheckPort.IsOpen) CheckPort.Close();
                            CheckPort.WriteTimeout = CheckPortTimeoutSec; CheckPort.ReadTimeout = CheckPortTimeoutSec;
                            if (ArrayComPortsNames.Length == 0)
                            {
                                SetPortprogressBar(0);
                                return;
                            }
                            CheckPort.PortName = ArrayComPortsNames[index];
                            
                            // try to open the selected port:
                            try
                            {
                                CheckPort.Open();
                                CheckPort.DiscardOutBuffer(); //Clear Buffer
                                CheckPort.DiscardInBuffer(); //Clear Buffer
                                try
                                {
                                    CheckPort.DiscardOutBuffer(); //Clear Buffer
                                    CheckPort.DiscardInBuffer(); //Clear Buffer
                                    CheckPort.Write("you?" + ReadToChar);
                                    Thread.SpinWait(2000 * 1000);
                                    string Order = "";
                                    try
                                    {
                                        Order = CheckPort.ReadTo(ReadToChar);
                                    }
                                    catch
                                    {
                                    }
                                    if (Order == "EIS")
                                        Order = "EIS.......";
                                    switch (Order)
                                    {
                                        case "EIS.......":
                                            FoundedPort = CheckPort.PortName;
                                            //DeviceVersion = Convert.ToInt32(Commands[1]);
                                            DeviceVersion = 1;
                                            isFounded = true;
                                            CheckPort.Write("ver?" + ReadToChar);
                                            try
                                            {
                                                Ver = CheckPort.ReadTo(ReadToChar);
                                                
                                                string[] Parts;
                                                char[] delimiterChars = { '.' };
                                                Parts = Ver.Split(delimiterChars);
                                                try
                                                {
                                                    int CurrentVer;
                                                    if (Parts[0] == "b")
                                                    {
                                                        Form1.BoardType = 2;
                                                        CurrentVer = Convert.ToInt16(Parts[1]);
                                                    }
                                                    else
                                                    {
                                                        Form1.BoardType = 1;
                                                        CurrentVer = Convert.ToInt16(Ver);
                                                    }
                                                    Form1.Port = CheckPort;
                                                    CheckUpdates(CurrentVer);
                                                }
                                                catch { }
                                            }
                                            catch
                                            {
                                            }
                                            DeviceName = Order;
                                            break;
                                        default:
                                            if (CheckPort.IsOpen) CheckPort.Close();
                                            break;
                                    }

                                }
                                catch { }
                            }
                            catch { }

                        }

                        if (ArrayComPortsNames[index] == FoundedPort)
                        {
                            richTextBox1.Text += ArrayComPortsNames[index] + DeviceName + " Ver:" + Ver + "\n";
                        }
                        else
                        {
                            richTextBox1.Text += ArrayComPortsNames[index] + "\n";
                        }
                        richTextBox1.Refresh();
                    }
                    while (!((ArrayComPortsNames[index] == ComPortName) ||
                                        (index == ArrayComPortsNames.GetUpperBound(0))));

                    if (CheckPort.IsOpen) CheckPort.Close();
                    if (isFounded)
                    {
                        Form1.Port.ReadBufferSize = 2^16; //2^12
                        //Form1.Port.WriteBufferSize = 2147483647;
                        Form1.Port.WriteTimeout = Form1.FactoryDefault.PortTimeout; Form1.Port.ReadTimeout = Form1.FactoryDefault.PortTimeout;
                        if (Form1.Port.IsOpen) Form1.Port.Close();
                        Form1.Port.PortName = FoundedPort;
                        // try to open the selected port:
                    //    try
                        {
                            Form1.Port.Open();
                            Form1.Port.DiscardOutBuffer(); //Clear Buffer
                            Form1.Port.DiscardInBuffer(); //Clear Buffer
                            SetPortprogressBar(PortprogressBar.Maximum);
                            EIS.Connected = true;
                            Form1.Status.Text = "Application is Connected to Device.";
                            notification1.BalloonTipText = "Application is Connected to Device.";
                            notification1.ShowBalloonTip(2000);
                            Form1.resetdevice();

                            try
                            {
                                Form1.Port.DiscardOutBuffer(); //Clear Buffer
                                Form1.Port.DiscardInBuffer(); //Clear Buffer
                                Form1.Port.Write("idcselect 0\r");
                                Thread.SpinWait(2000 * 1000);
                                string ans = Form1.Port.ReadTo(ReadToChar);
                                Form1.Port.DiscardOutBuffer(); //Clear Buffer
                                Form1.Port.DiscardInBuffer(); //Clear Buffer
                                if (ans == "OK")
                                {
                                   
                                }
                            }
                            catch { }
                            try
                            {
                                Form1.Port.DiscardOutBuffer(); //Clear Buffer
                                Form1.Port.DiscardInBuffer(); //Clear Buffer
                                Form1.Port.Write("sampleon 0\r");
                                Thread.SpinWait(2000 * 1000);
                                string ans = Form1.Port.ReadTo(ReadToChar);
                                Form1.Port.DiscardOutBuffer(); //Clear Buffer
                                Form1.Port.DiscardInBuffer(); //Clear Buffer
                                if (ans == "OK")
                                {
                                    Form1.isProbOn = false;
                                    Form1.SetSampleOff();
                                }
                            }
                            catch { }


                            try
                            {
                                Form1.Port.DiscardOutBuffer(); //Clear Buffer
                                Form1.Port.DiscardInBuffer(); //Clear Buffer
                                Form1.Port.Write("dummyon 0\r");
                                Thread.SpinWait(2000 * 1000);
                                string ans = Form1.Port.ReadTo(ReadToChar);
                                Form1.Port.DiscardOutBuffer(); //Clear Buffer
                                Form1.Port.DiscardInBuffer(); //Clear Buffer
                                if (ans == "OK")
                                {
                                    Form1.isDummyOn = false;
                                    Form1.SetSampleOff();
                                }
                            }
                            catch { }

                            bool isdone = Form1.microloadSetting();
                            Form1.loadSetting(ref Form1.Settings);
                            Form1.saveSetting(ref Form1.Settings, "../settings.bin");
                            int microver = Form1.GetVersionSetting("../microsettings.bin");
                            int Myver = Form1.GetVersionSetting("../settings.bin");
                            if (microver != -1)
                            {
                                FileStream s = new FileStream("../settings.bin", FileMode.Open);
                                long sLength = s.Length;
                                byte[] sbytes = new byte[sLength];
                                for (int i = 0; i < sLength; i++) sbytes[i] = (byte)s.ReadByte();
                                s.Close();

                                FileStream ms = new FileStream("../microsettings.bin", FileMode.Open);
                                long msLength = ms.Length;
                                byte dummy;
                                for (int i = 0; i < 5; i++) dummy = (byte)ms.ReadByte();
                                for (int i = 5; i < msLength; i++) sbytes[i] = (byte)ms.ReadByte();
                                ms.Close();

                                s = new FileStream("../settings.bin", FileMode.Create);
                                for (int i = 0; i < sLength; i++) s.WriteByte(sbytes[i]);
                                s.Close();

                                Form1.loadSetting(ref Form1.Settings);
                                if (microver < Form1.Settings.Version)
                                {
                                    MessageBox.Show("micro save number 4");
                                    Form1.microsaveSetting("../settings.bin");
                                }
                            }
                            else
                            {
                                MessageBox.Show("micro save number 5");
                                Form1.microsaveSetting("../settings.bin");
                            }


                            Form1.isFormPort = false;
                            this.Hide();

                        }
                     /*   catch
                        {
                            SetPortprogressBar(0);
                            MessageBox.Show("Serial port " + Form1.Port.PortName + " cannot be opened!", " Error ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }*/
                    }
                    else
                    {
                        if (trynum > 0)
                        {
                            SetPortprogressBar(0);
                            MessageBox.Show("Device is not found.", " Error ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Form1.Status.Text = "Device is not found.!";
                        }
                    }

                }
            }
        }

        private void FormPort_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Form1.isFormPort = false;
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DigitTextChangeInt(ref CheckPortTimeoutSec, textBox1);
        }

        private void DigitTextChangeInt(ref int digit, TextBox tb)
        {
            try
            {
                digit = Convert.ToInt32(tb.Text);
            }
            catch
            {
                tb.Text = digit.ToString();
                MessageBox.Show("Please type integer only ...");
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckUpdates(2);
        }

        private void CheckUpdates(int CurrentVersion)
        {
            List<string> Ufiles = new List<string> { };
            List<int> Uvers = new List<int> { };

            try
            {
                string path = "Update";
                if (Directory.Exists(path))
                {
                    string[] fileEntries = Directory.GetFiles(path);
                    foreach (string file in fileEntries)
                    {
                        string filename = Path.GetFileName(file);
                        string[] Parts;
                        char[] delimiterChars = { '.' };
                        int ver;
                        Parts = filename.Split(delimiterChars);
                        try
                        {
                            ver = Convert.ToInt16(Parts[1]);
                            if (Parts[0] == "u")
                            {
                                Ufiles.Add(file);
                                Uvers.Add(ver);
                            }
                        }
                        catch { }
                    }

                    int iv = -1;
                    int MaxVer = -1;
                    string MaxVerFile = "";
                    foreach (int v in Uvers)
                    {
                        iv++;
                        if (MaxVer < v)
                        {

                            MaxVer = v;
                            MaxVerFile = Ufiles[iv];
                        }
                    }
                    if (MaxVer > CurrentVersion)
                    {
                        if (File.Exists(MaxVerFile))
                        {
                            FileStream FileProtocol = new FileStream(MaxVerFile, FileMode.Open);
                            BinaryReader br = new BinaryReader(FileProtocol);
                            long nBytes = FileProtocol.Length;
                            byte[] MaxVerBytes = new byte[PageNumber*PageSize];

                            for (int ib = 0; ib < PageNumber * PageSize; ib++) MaxVerBytes[ib] = 0xFF;
                            for (int ib = 0; ib < nBytes; ib++) MaxVerBytes[ib] = br.ReadByte();

                            br.Close();

                            UpdateMicro(MaxVer, MaxVerBytes, nBytes);
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void BLUpdates_FromFile(int CurrentVersion)
        {

            string sFileName="Update";
            try
            {
                OpenFileDialog choofdlog = new OpenFileDialog();
                choofdlog.Filter = "All Files (*.*)|*.*";
                choofdlog.FilterIndex = 1;
                

                if (choofdlog.ShowDialog() == DialogResult.OK)
                {
                     sFileName = choofdlog.FileName;
                            
                }
                //string path = "Update";
                //if (Directory.Exists(sFileName))
                {
                    
                    {
                        if (File.Exists(sFileName))
                        {
                            FileStream FileProtocol = new FileStream(sFileName, FileMode.Open);
                            BinaryReader br = new BinaryReader(FileProtocol);
                            long nBytes = FileProtocol.Length;
                            if (nBytes > 64000) return;
                            byte[] MaxVerBytes = new byte[PageNumber * PageSize];

                            for (int ib = 0; ib < PageNumber * PageSize; ib++) MaxVerBytes[ib] = 0xFF;
                            for (int ib = 0; ib < nBytes; ib++) MaxVerBytes[ib] = br.ReadByte();

                            br.Close();

                            if (BLUpdateMicro(1, MaxVerBytes, nBytes) == 1)
                            {

                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void BLCheckUpdates(int CurrentVersion)
        {
            List<string> Ufiles = new List<string> { };
            List<int> Uvers = new List<int> { };

            try
            {
                string path = "Update";
                if (Directory.Exists(path))
                {
                    string[] fileEntries = Directory.GetFiles(path);
                    foreach (string file in fileEntries)
                    {
                        string filename = Path.GetFileName(file);
                        string[] Parts;
                        char[] delimiterChars = { '.' };
                        int ver;
                        Parts = filename.Split(delimiterChars);
                        try
                        {
                            ver = Convert.ToInt16(Parts[1]);
                            if (Parts[0] == "u")
                            {
                                Ufiles.Add(file);
                                Uvers.Add(ver);
                            }
                        }
                        catch { }
                    }

                    int iv = -1;
                    int MaxVer = -1;
                    string MaxVerFile = "";
                    foreach (int v in Uvers)
                    {
                        iv++;
                        if (MaxVer < v)
                        {

                            MaxVer = v;
                            MaxVerFile = Ufiles[iv];
                        }
                    }
                    if (MaxVer > CurrentVersion)
                    {
                        if (File.Exists(MaxVerFile))
                        {
                            FileStream FileProtocol = new FileStream(MaxVerFile, FileMode.Open);
                            BinaryReader br = new BinaryReader(FileProtocol);
                            long nBytes = FileProtocol.Length;
                            byte[] MaxVerBytes = new byte[PageNumber * PageSize];

                            for (int ib = 0; ib < PageNumber * PageSize; ib++) MaxVerBytes[ib] = 0xFF;
                            for (int ib = 0; ib < nBytes; ib++) MaxVerBytes[ib] = br.ReadByte();

                            br.Close();

                            if(BLUpdateMicro(MaxVer, MaxVerBytes, nBytes) == 1)
                            {
                                if (File.Exists(MaxVerFile))
                                {
                                    File.Copy(MaxVerFile, Path.Combine(Path.GetFullPath(MaxVerFile), "backup_u"), true);
                                    File.Delete(MaxVerFile);
                                }

                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void UpdateMicro(int ver, byte[] Bytes, long nBytes)
        {
            byte[] checkback = new byte[PageNumber * PageSize];
            try
            {
                Form1.Port.ReadTimeout = 9000;
                Form1.Port.NewLine = "\r";
                Form1.Port.DiscardOutBuffer(); //Clear Buffer
                Form1.Port.DiscardInBuffer(); //Clear Buffer
                Form1.Port.WriteLine("update");
                Thread.Sleep(500);
                Form1.Port.Write("a");
                Thread.Sleep(100);
               
                Form1.Port.ReadByte();
                Form1.Port.DiscardInBuffer(); //Clear Buffer
                Form1.Port.Write("U"); Thread.Sleep(10); Form1.Port.Write("N"); Thread.Sleep(10);
                Form1.Port.Write("U"); Thread.Sleep(10); Form1.Port.Write("N"); Thread.Sleep(10);
                Form1.Port.Write("U"); Thread.Sleep(10); Form1.Port.Write("N"); Thread.Sleep(10);
                Form1.Port.Write("U"); Thread.Sleep(10); Form1.Port.Write("N"); Thread.Sleep(10);
                Form1.Port.Write("U"); Thread.Sleep(10); Form1.Port.Write("N"); Thread.Sleep(10);
                Form1.Port.Write("U"); Thread.Sleep(10); Form1.Port.Write("N"); Thread.Sleep(10);
                Form1.Port.Write("U"); Thread.Sleep(10); Form1.Port.Write("N"); Thread.Sleep(10);
                Form1.Port.Write("U"); Thread.Sleep(10); Form1.Port.Write("N"); Thread.Sleep(10);
                Form1.Port.Write("U"); Thread.Sleep(10); Form1.Port.Write("N"); Thread.Sleep(10);
                Form1.Port.Write("U"); Thread.Sleep(10); Form1.Port.Write("N"); Thread.Sleep(10);
                Thread.Sleep(10);
                Form1.Port.ReadByte();
                Form1.Port.DiscardOutBuffer(); //Clear Buffer
                Form1.Port.DiscardInBuffer(); //Clear Buffer
                Form1.Port.Write("p");
                Thread.Sleep(10);
                if (Form1.Port.ReadByte() != 'S') throw(new Exception("error:4001 Command:p"));
                Form1.Port.Write("S");
                Thread.Sleep(10);
                if (Form1.Port.ReadByte() != 'A') throw(new Exception("error:4002 Command:S"));
                if (Form1.Port.ReadByte() != 'V') throw(new Exception("error:4003 Command:S"));
                if (Form1.Port.ReadByte() != 'R') throw(new Exception("error:4004 Command:S"));
                if (Form1.Port.ReadByte() != 'B') throw(new Exception("error:4005 Command:S"));
                if (Form1.Port.ReadByte() != 'O') throw(new Exception("error:4006 Command:S"));
                if (Form1.Port.ReadByte() != 'O') throw(new Exception("error:4007 Command:S"));
                if (Form1.Port.ReadByte() != 'T') throw(new Exception("error:4008 Command:S"));
                Form1.Port.Write("V");
                Thread.Sleep(10);
                if (Form1.Port.ReadByte() != '1') throw(new Exception("error:4009 Command:V"));
                if (Form1.Port.ReadByte() != '6') throw(new Exception("error:4010 Command:V"));

                Thread.Sleep(10);
                Form1.Port.Write("7");
                Thread.Sleep(10);
                Form1.Port.Write("u");
                Thread.Sleep(10);

                Form1.Port.Write("5");
                Thread.Sleep(1);
                UInt16 zero0 = pass;
                byte[] zeroBytes0 = BitConverter.GetBytes(zero0);
                Form1.Port.Write(zeroBytes0, 0, 1);
                Thread.Sleep(1);

                Form1.Port.Write("e");
                Thread.Sleep(100);
                if (Form1.Port.ReadByte() != '\r') throw(new Exception("error:4011 Command:e"));

                

              //  Form1.Port.Write("A");
               // Thread.Sleep(1);
               // zero = 0;
              //  zeroBytes = BitConverter.GetBytes(zero);
                
                Form1.Port.Write("A");
                Thread.Sleep(10);
                UInt16 zero = 0;
                byte[] zeroBytes = BitConverter.GetBytes(zero);
                Form1.Port.Write(zeroBytes, 0, 1); Thread.Sleep(1);
                Form1.Port.Write(zeroBytes, 1, 1);
                
                
                Thread.Sleep(10);
                if (Form1.Port.ReadByte() != '\r') throw (new Exception("error:4012 Command:A"));
                Form1.Port.Write("z");
                Thread.Sleep(1);
                byte s1 = (byte)Form1.Port.ReadByte();
                byte s2 = (byte)Form1.Port.ReadByte();
                byte s3 = (byte)Form1.Port.ReadByte();
                if (s3 != '\r') throw (new Exception("error:4012 Command:z"));
                int ib=-1;

                
                UpdatePageProgressbar.Maximum = PageNumber - 1;
                SetUpdatePageProgressbar(0);
                Thread.Sleep(1000);
                for (int p = 0; p < PageNumber; p++)
                {
                    Thread.Sleep(InteraPageSleep);
                    SetUpdatePageProgressbar(p);
                    Form1.Port.Write("B");
                    //  Thread.Sleep(100);
                    UInt16 PS = PageSize;
                    byte[] PSBytes = BitConverter.GetBytes(PS);
                    Form1.Port.Write(PSBytes, 1, 1); Thread.Sleep(1);
                    Form1.Port.Write(PSBytes, 0, 1); Thread.Sleep(1);
                    Form1.Port.Write("F");
                    Thread.Sleep(1);
                    UpdateProgressbar.Maximum = PageSize - 1;
                    SetUpdateprogressBar(0);
                    Form1.Port.Write(Bytes, p * 256, 256);// Thread.Sleep(10);
                    //for (int i = 0; i < PageSize; i++)
                    //{
                    //    Thread.Sleep(InteraWordSleep);
                    //    SetUpdateprogressBar(i);
                    //    ib++;
                    //    Form1.Port.Write(Bytes, ib, 1); 
                    //}
                    if (Form1.Port.ReadByte() != '\r') throw (new Exception("error:4012 Command:B"));
                    this.Text = "updating:" + (100 * p / PageNumber).ToString() + "%";
                }
                


                Thread.Sleep(1000);
                Form1.Port.Write("A");
                Thread.Sleep(1);
                zero = 0;
                zeroBytes = BitConverter.GetBytes(zero);
                Form1.Port.Write(zeroBytes, 0, 1); Thread.Sleep(1);
                Form1.Port.Write(zeroBytes, 1, 1);
                Thread.Sleep(1);
                byte check = (byte)Form1.Port.ReadByte();
                if (check != '\r') throw (new Exception("error:4012 Command:A"));

                Form1.Port.Write("z");
                Thread.Sleep(1);
                byte s21 = (byte)Form1.Port.ReadByte();
                byte s22 = (byte)Form1.Port.ReadByte();
                if (Form1.Port.ReadByte() != '\r') throw (new Exception("error:4012 Command:z"));

                ib = -1;
                UpdatePageProgressbar.Maximum = PageNumber - 1;
                SetUpdatePageProgressbar(0);
                Thread.Sleep(1000);
                for (int p = 0; p < PageNumber; p++)
                {
                    Thread.Sleep(InteraPageSleep);
                    SetUpdatePageProgressbar(p);
                    Form1.Port.Write("g");
                    Thread.Sleep(1);
                    UInt16 PS = PageSize;
                    byte[] PSBytes = BitConverter.GetBytes(PS);
                    Form1.Port.Write(PSBytes, 1, 1); Thread.Sleep(1);
                    Form1.Port.Write(PSBytes, 0, 1); Thread.Sleep(1);
                    Form1.Port.Write("F");
                    Thread.Sleep(1);
                    UpdateProgressbar.Maximum = PageSize - 1;
                    SetUpdateprogressBar(0);
                    for (int i = 0; i < PageSize; i++)
                    {
                        //SetUpdateprogressBar(i);
                        //Thread.Sleep(InteraWordSleep);
                        ib++;
                        checkback[ib] = (byte)Form1.Port.ReadByte(); //Thread.Sleep(1);
                        if (!(checkback[ib] == Bytes[ib]) && (ib < nBytes)) throw (new Exception("error:4013 number of byte=" + ib.ToString()));// Thread.Sleep(1);
                    }
                }

                Thread.Sleep(1);
                Form1.Port.Write("8");
                Thread.Sleep(1);
                byte[] verBytes = BitConverter.GetBytes((byte)ver);
                Form1.Port.Write(verBytes, 0, 1);
                Thread.Sleep(1);
                Form1.Port.Write("7");
                Thread.Sleep(1);
                Form1.Port.Write("v");
                Thread.Sleep(1);

                Form1.Port.Write("0");
                Thread.SpinWait(2000 * 1000);
                this.Text = "Connection";
                Form1.Port.WriteLine("dummy");
                Form1.Port.ReadLine();
                Form1.Port.DiscardInBuffer();
                Form1.Port.DiscardOutBuffer();
                //          if (Form1.Port.ReadByte() != '\r') throw(new Exception("error:4012 Command:0"));
                Form1.Port.WriteLine("ver?");
                Form1.Status.Text = "Firmware is updated ... ver=" + Form1.Port.ReadLine();
            }
            catch(Exception e)
            {
                MessageBox.Show("Boot loader error ...\n" + e.Message);
            }

        }

        private int BLUpdateMicro(int ver, byte[] Bytes, long nBytes)
        {
            byte[] checkback = new byte[PageNumber * PageSize];
            byte[] deltacheckback = new byte[PageNumber * PageSize];
            try
            {
                Form1.Port.ReadTimeout = 9000;
                Form1.Port.NewLine = "\r";
                Thread.Sleep(1);
                Form1.Port.DiscardOutBuffer(); //Clear Buffer
                Form1.Port.DiscardInBuffer(); //Clear Buffer
                Form1.Port.Write("p");
                Thread.Sleep(1);
                if (Form1.Port.ReadByte() != 'S') throw (new Exception("error:4001 Command:p"));
                Form1.Port.Write("S");
                Thread.Sleep(1);
                if (Form1.Port.ReadByte() != 'A') throw (new Exception("error:4002 Command:S"));
                if (Form1.Port.ReadByte() != 'V') throw (new Exception("error:4003 Command:S"));
                if (Form1.Port.ReadByte() != 'R') throw (new Exception("error:4004 Command:S"));
                if (Form1.Port.ReadByte() != 'B') throw (new Exception("error:4005 Command:S"));
                if (Form1.Port.ReadByte() != 'O') throw (new Exception("error:4006 Command:S"));
                if (Form1.Port.ReadByte() != 'O') throw (new Exception("error:4007 Command:S"));
                if (Form1.Port.ReadByte() != 'T') throw (new Exception("error:4008 Command:S"));
                Form1.Port.Write("V");
                Thread.Sleep(1);
                if (Form1.Port.ReadByte() != '1') throw (new Exception("error:4009 Command:V"));
                if (Form1.Port.ReadByte() != '6') throw (new Exception("error:4010 Command:V"));

                Thread.Sleep(1);
                Form1.Port.Write("7");
                Thread.Sleep(1);
                Form1.Port.Write("u");
                Thread.Sleep(1);

                Form1.Port.Write("5");
                Thread.Sleep(1);
                UInt16 zero0 = pass;
                byte[] zeroBytes0 = BitConverter.GetBytes(zero0);
                Form1.Port.Write(zeroBytes0, 0, 1);
                Thread.Sleep(1);

                Form1.Port.Write("e");
                Thread.Sleep(100);
                if (Form1.Port.ReadByte() != '\r') throw (new Exception("error:4011 Command:e"));
                //  Form1.Port.Write("A");
                // Thread.Sleep(1);
                // zero = 0;
                //  zeroBytes = BitConverter.GetBytes(zero);
                Form1.Port.Write("A");
                Thread.Sleep(1);
                UInt16 zero = 0;
                byte[] zeroBytes = BitConverter.GetBytes(zero);
                Form1.Port.Write(zeroBytes, 0, 1); Thread.Sleep(1);
                Form1.Port.Write(zeroBytes, 1, 1);
                //Form1.Port.Write(zeroBytes, 0, 1); Thread.Sleep(1);
                //Form1.Port.Write(zeroBytes, 1, 1);
                Thread.Sleep(1);
                if (Form1.Port.ReadByte() != '\r') throw (new Exception("error:4012 Command:A"));
                Form1.Port.Write("z");
                Thread.Sleep(1);
                byte s1 = (byte)Form1.Port.ReadByte();
                byte s2 = (byte)Form1.Port.ReadByte();
                if (Form1.Port.ReadByte() != '\r') throw (new Exception("error:4012 Command:z"));
                int ib = -1;
                
                UpdatePageProgressbar.Maximum = PageNumber - 1;
                SetUpdatePageProgressbar(0);
                Thread.Sleep(1000);
                for (int p = 0; p < PageNumber; p++)
                {
                    Thread.Sleep(InteraPageSleep);
                    SetUpdatePageProgressbar(p);
                    Form1.Port.Write("B");
                  //  Thread.Sleep(100);
                    UInt16 PS = PageSize;
                    byte[] PSBytes = BitConverter.GetBytes(PS);
                    Form1.Port.Write(PSBytes, 1, 1); Thread.Sleep(1);
                    Form1.Port.Write(PSBytes, 0, 1); Thread.Sleep(1);
                    Form1.Port.Write("F");
                    Thread.Sleep(1);
                    UpdateProgressbar.Maximum = PageSize - 1;
                    SetUpdateprogressBar(0);
                    Form1.Port.Write(Bytes, p * 256, 256); //Thread.Sleep(10);
                    /*for (int i = 0; i < PageSize; i++)
                    {
                        Thread.Sleep(1);
                        SetUpdateprogressBar(i);
                        ib++;
                        Form1.Port.Write(Bytes, ib, 1); //Thread.Sleep(1);
                    }*/
                    if (Form1.Port.ReadByte() != '\r') throw (new Exception("error:4012 Command:B"));
                    this.Text = "updating:" + (100 * p / PageNumber).ToString() + "%";
                }
                
                Thread.Sleep(1000);
                Form1.Port.Write("A");
                Thread.Sleep(1);
                zero = 0;
                zeroBytes = BitConverter.GetBytes(zero);
                Form1.Port.Write(zeroBytes, 0, 1); Thread.Sleep(1);
                Form1.Port.Write(zeroBytes, 1, 1);
                Thread.Sleep(1);
                byte check = (byte)Form1.Port.ReadByte();
                if (check != '\r') throw (new Exception("error:4012 Command:A"));

                Form1.Port.Write("z");
                Thread.Sleep(1);
                byte s21 = (byte)Form1.Port.ReadByte();
                byte s22 = (byte)Form1.Port.ReadByte();
                if (Form1.Port.ReadByte() != '\r') throw (new Exception("error:4012 Command:z"));

                ib = -1;
                UpdatePageProgressbar.Maximum = PageNumber - 1;
                SetUpdatePageProgressbar(0);
                Thread.Sleep(1000);
                for (int p = 0; p < PageNumber; p++)
                {
                    Thread.Sleep(InteraPageSleep);
                    SetUpdatePageProgressbar(p);
                    Form1.Port.Write("g");
                    Thread.Sleep(1);
                    UInt16 PS = PageSize;
                    byte[] PSBytes = BitConverter.GetBytes(PS);
                    Form1.Port.Write(PSBytes, 1, 1); Thread.Sleep(1);
                    Form1.Port.Write(PSBytes, 0, 1); Thread.Sleep(1);
                    Form1.Port.Write("F");
                    Thread.Sleep(2);
                    UpdateProgressbar.Maximum = PageSize - 1;
                    SetUpdateprogressBar(0);
                    
                    for (int i = 0; i < PageSize; i++)
                    {
                        //Thread.Sleep(InteraWordSleep);
                        //SetUpdateprogressBar(i);
                        ib++;
                        checkback[ib] = (byte)Form1.Port.ReadByte(); //Thread.Sleep(1);
                        deltacheckback[ib] = (byte)(checkback[ib] - Bytes[ib]);
                        if (!(checkback[ib] == Bytes[ib]) && (ib < nBytes))
                        {
                            throw (new Exception("error:4013 number of byte=" + ib.ToString()));
                        }
                    }
                }

                Thread.Sleep(1);
                Form1.Port.Write("8");
                Thread.Sleep(1);
                byte[] verBytes = BitConverter.GetBytes((byte)ver);
                Form1.Port.Write(verBytes, 0, 1);
                Thread.Sleep(1);
                Form1.Port.Write("7");
                Thread.Sleep(1);
                Form1.Port.Write("v");
                Thread.Sleep(1);

                Form1.Port.Write("0");
                Thread.SpinWait(2000 * 1000);
                this.Text = "Connection";
                Form1.Port.WriteLine("dummy");
                Form1.Port.ReadLine();
                Form1.Port.DiscardInBuffer();
                Form1.Port.DiscardOutBuffer();
                //          if (Form1.Port.ReadByte() != '\r') throw(new Exception("error:4012 Command:0"));
                Form1.Port.WriteLine("ver?");
                Form1.Status.Text = "Firmware is updated ... ver=" + Form1.Port.ReadLine();
                return 1;
            }
            catch (Exception e)
            {
                MessageBox.Show("Boot loader error ...\n" + e.Message);
                return 0;
            }

        }

        private void firmWareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(new Form() { TopMost = true }, "You are requesting to upgrade to a newer release of firmware.\nDo you realy want to continue?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.No) return;
            string DeviceName = "";
            string Ver = "";
            isFounded = false;
            SetPortprogressBar(1);
            for (int trynum = 0; trynum < 2; trynum++)
            {
                if (!isFounded)
                {
                    richTextBox1.Text = "";
                    if (trynum == 0)
                        Form1.Status.Text = "Searching ...";
                    else
                        Form1.Status.Text = "Searching ...";
                    Form1.Status.Refresh();
                    string[] ArrayComPortsNames = null;
                    int index = -1;
                    FoundedPort = "";
                    DeviceVersion = 0;

                    string ComPortName = null;
                    ArrayComPortsNames = SerialPort.GetPortNames();
                    PortprogressBar.Maximum = 2 * ArrayComPortsNames.Length + 1;
                    do
                    {
                        index++;

                        if (!isFounded)
                        {
                            int newval = PortprogressBar.Value + 1;
                            SetPortprogressBar(newval);

                            if (CheckPort.IsOpen) CheckPort.Close();
                            CheckPort.WriteTimeout = CheckPortTimeoutSec; CheckPort.ReadTimeout = CheckPortTimeoutSec;
                            CheckPort.PortName = ArrayComPortsNames[index];
                            // try to open the selected port:
                            try
                            {
                                CheckPort.Open();
                                CheckPort.DiscardOutBuffer(); //Clear Buffer
                                CheckPort.DiscardInBuffer(); //Clear Buffer
                                try
                                {
                                    CheckPort.DiscardOutBuffer(); //Clear Buffer
                                    CheckPort.DiscardInBuffer(); //Clear Buffer
                                    //CheckPort.Write("you?" + ReadToChar);
                                    CheckPort.Write("1");
                                    Thread.SpinWait(2000 * 1000);
                                    string Order = "";
                                    try
                                    {
                                        for (int i = 0; i < 10; i++) Order = Order + (char)CheckPort.ReadChar();
                                    }
                                    catch
                                    {
                                    }

                                    switch (Order)
                                    {
                                        case "EIS.......":
                                            FoundedPort = CheckPort.PortName;
                                            DeviceVersion = 1;
                                            isFounded = true;
                                            //CheckPort.Write("ver?" + ReadToChar);
                                            CheckPort.Write("2");
                                            try
                                            {
                                                //Ver = CheckPort.ReadTo(ReadToChar);
                                                int intVer = CheckPort.ReadByte();
                                                Ver = intVer.ToString();
                                                Form1.Port = CheckPort;
                                                //int CurrentVer = Convert.ToInt16(Ver);
                                                CheckPort.Write("3");
                                                int intValid = CheckPort.ReadByte();
                                                char Valid = (char)((byte)intValid);
                                                BLCheckUpdates(0);
                                            }
                                            catch
                                            {
                                            }
                                            DeviceName = Order;
                                            break;
                                        default:
                                            if (CheckPort.IsOpen) CheckPort.Close();
                                            break;
                                    }

                                }
                                catch { }
                            }
                            catch { }

                        }

                        /*
                         * 1 name 10 ta character read(offset=0,cont=10)
                         * 2 ver 0:255  readbyte -> unsign
                         * 3 valid  v=valid readbyte
                         * 7 u
                         * 
                         * 7 v
                         * 10 -1  write
                         */

                        if (ArrayComPortsNames[index] == FoundedPort)
                        {
                            richTextBox1.Text += ArrayComPortsNames[index] + DeviceName + " Ver:" + Ver + "\n";
                        }
                        else
                        {
                            richTextBox1.Text += ArrayComPortsNames[index] + "\n";
                        }
                        richTextBox1.Refresh();
                    }
                    while (!((ArrayComPortsNames[index] == ComPortName) ||
                                        (index == ArrayComPortsNames.GetUpperBound(0))));

                    if (CheckPort.IsOpen) CheckPort.Close();
                    if (isFounded)
                    {
                        Form1.Port.WriteTimeout = Form1.FactoryDefault.PortTimeout; Form1.Port.ReadTimeout = Form1.FactoryDefault.PortTimeout;
                        Form1.Port.PortName = FoundedPort;
                        if (Form1.Port.IsOpen) Form1.Port.Close();
                        // try to open the selected port:
                        SetPortprogressBar(0);
                    }
                    else
                    {
                        if (trynum > 0)
                        {
                            SetPortprogressBar(0);
                            MessageBox.Show("Device is not found.", " Error ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Form1.Status.Text = "Device is not found.!";
                        }
                    }

                }
            }
        }

        private void loadFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(new Form() { TopMost = true }, "You are requesting to upgrade to a newer release of firmware.\nDo you realy want to continue?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.No) return;
            string DeviceName = "";
            string Ver = "";
            isFounded = false;
            SetPortprogressBar(1);
            for (int trynum = 0; trynum < 2; trynum++)
            {
                if (!isFounded)
                {
                    richTextBox1.Text = "";
                    if (trynum == 0)
                        Form1.Status.Text = "Searching ...";
                    else
                        Form1.Status.Text = "Searching ...";
                    Form1.Status.Refresh();
                    string[] ArrayComPortsNames = null;
                    int index = -1;
                    FoundedPort = "";
                    DeviceVersion = 0;

                    string ComPortName = null;
                    ArrayComPortsNames = SerialPort.GetPortNames();
                    PortprogressBar.Maximum = 2 * ArrayComPortsNames.Length + 1;
                    do
                    {
                        index++;

                        if (!isFounded)
                        {
                            int newval = PortprogressBar.Value + 1;
                            SetPortprogressBar(newval);

                            if (CheckPort.IsOpen) CheckPort.Close();
                            CheckPort.WriteTimeout = CheckPortTimeoutSec; CheckPort.ReadTimeout = CheckPortTimeoutSec;
                            CheckPort.PortName = ArrayComPortsNames[index];
                            // try to open the selected port:
                            try
                            {
                                CheckPort.Open();
                                CheckPort.DiscardOutBuffer(); //Clear Buffer
                                CheckPort.DiscardInBuffer(); //Clear Buffer
                                try
                                {
                                    CheckPort.DiscardOutBuffer(); //Clear Buffer
                                    CheckPort.DiscardInBuffer(); //Clear Buffer
                                    //CheckPort.Write("you?" + ReadToChar);
                                    CheckPort.Write("1");
                                    Thread.SpinWait(2000 * 1000);
                                    string Order = "";
                                    try
                                    {
                                        for (int i = 0; i < 10; i++) Order = Order + (char)CheckPort.ReadChar();
                                    }
                                    catch
                                    {
                                    }

                                    switch (Order)
                                    {
                                        case "EIS.......":
                                            FoundedPort = CheckPort.PortName;
                                            DeviceVersion = 1;
                                            isFounded = true;
                                            //CheckPort.Write("ver?" + ReadToChar);
                                            CheckPort.Write("2");
                                            try
                                            {
                                                //Ver = CheckPort.ReadTo(ReadToChar);
                                                int intVer = CheckPort.ReadByte();
                                                Ver = intVer.ToString();
                                                Form1.Port = CheckPort;
                                                //int CurrentVer = Convert.ToInt16(Ver);
                                                CheckPort.Write("3");
                                                int intValid = CheckPort.ReadByte();
                                                char Valid = (char)((byte)intValid);
                                                BLCheckUpdates(0);
                                            }
                                            catch
                                            {
                                            }
                                            DeviceName = Order;
                                            break;
                                        default:
                                            if (CheckPort.IsOpen) CheckPort.Close();
                                            break;
                                    }

                                }
                                catch { }
                            }
                            catch { }

                        }

                        /*
                         * 1 name 10 ta character read(offset=0,cont=10)
                         * 2 ver 0:255  readbyte -> unsign
                         * 3 valid  v=valid readbyte
                         * 7 u
                         * 
                         * 7 v
                         * 10 -1  write
                         */

                        if (ArrayComPortsNames[index] == FoundedPort)
                        {
                            richTextBox1.Text += ArrayComPortsNames[index] + DeviceName + " Ver:" + Ver + "\n";
                        }
                        else
                        {
                            richTextBox1.Text += ArrayComPortsNames[index] + "\n";
                        }
                        richTextBox1.Refresh();
                    }
                    while (!((ArrayComPortsNames[index] == ComPortName) ||
                                        (index == ArrayComPortsNames.GetUpperBound(0))));

                    if (CheckPort.IsOpen) CheckPort.Close();
                    if (isFounded)
                    {
                        Form1.Port.WriteTimeout = Form1.FactoryDefault.PortTimeout; Form1.Port.ReadTimeout = Form1.FactoryDefault.PortTimeout;
                        Form1.Port.PortName = FoundedPort;
                        if (Form1.Port.IsOpen) Form1.Port.Close();
                        // try to open the selected port:
                        SetPortprogressBar(0);
                    }
                    else
                    {
                        if (trynum > 0)
                        {
                            SetPortprogressBar(0);
                            MessageBox.Show("Device is not found.", " Error ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Form1.Status.Text = "Device is not found.!";
                        }
                    }

                }
            }

        }
    }
}
