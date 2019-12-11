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

namespace EISProjects
{
    public partial class FormVM : Form
    {

        ///////////////////////////
        public static bool VMisConnected;
        public static int InputsCount=9;
        public static double[] Inputs;

        public static SessionInputs SI;
        public static string ReadToChar = "\r";

        public static int MaterialIndex=0;

        public static int IntVlt = 0;
        public static int IntAmp = 0;
        public static int IntFrq = 0;
        public static int IntIVRng = 0;
        public static int IntIVVlt = 0;
        public static int IntIVAmp = 0;

        public static string DeviceName = "EIS";
        public static int DeviceVersion = 2016;

        public static int IV_IDCSelect = 0;
        public static int IV_IACSelect = 0;
        public static int VSelect = 0;

        public static int VDC = 300;
        public static int IDC = 0;
        public static int VAC = 0;

        public static int nClock = 1;
        public static int RealI = 0;
        public static int ImagI = 0;
        public static int RealV = 0;
        public static int ImagV = 0;

        public static System.Windows.Forms.Timer DigitalDataSenderTimer;
        public static bool AllowToSendData = false;
        public static bool isDigitalDataSenderTimerCompleted = true;
        public static bool isDigitalDataSenderDataArraysinProsses = false;
        public static double DigitalTimeInterval = 0;
        public static int nData = 512;
        public static double[,] Data2 = new double[nData, 2];
        ///////////////////////////

        public FormVM()
        {
            InitializeComponent();
            VMisConnected = false;
            SI = new SessionInputs();
            CBMaterial.SelectedIndex = 0;


            DigitalDataSenderTimer = new System.Windows.Forms.Timer();
            isDigitalDataSenderDataArraysinProsses = false;
            isDigitalDataSenderTimerCompleted = true;
            DigitalDataSenderTimer.Interval = 1000;
            DigitalDataSenderTimer.Tick += new System.EventHandler(DigitalDataSenderTimer_Tick);
            //DigitalDataSenderTimer.Enabled = true;
            DigitalDataSenderTimer.Start();

        }

        private void BtnShowPorts_Click(object sender, EventArgs e)
        {
            PortList.Items.Clear();
            string[] ArrayComPortsNames = null;
            int index = -1;

            string ComPortName = null;
            ArrayComPortsNames = SerialPort.GetPortNames();
            do
            {
                index++;
                PortList.Items.Add(ArrayComPortsNames[index]);
            }

            while (!((ArrayComPortsNames[index] == ComPortName) ||
                                (index == ArrayComPortsNames.GetUpperBound(0))));


            BtnConnect.Enabled = true;
            BtnDisconnect.Enabled = true;
            CBMaterial.Enabled = true;
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            if (PortList.SelectedIndex > -1)
            {
                VMPort.WriteTimeout = Form1.FactoryDefault.PortTimeout; VMPort.ReadTimeout = Form1.FactoryDefault.PortTimeout;
                if (VMPort.IsOpen) VMPort.Close();
                VMPort.PortName = PortList.SelectedItem.ToString();
                // try to open the selected port:
                try
                {
                    VMPort.Open();
                    VMisConnected = true;
                    VMStatus.Text = "Virtual Machine is Connected to " + VMPort.PortName;
                    VMPort.DiscardOutBuffer(); //Clear Buffer
                    VMPort.DiscardInBuffer(); //Clear Buffer
                }


                catch
                {
                    MessageBox.Show("Serial port " + VMPort.PortName + " cannot be opened!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    // cmbComSelect.SelectedText = "";
                    VMStatus.Text = "Select serial port!";
                }
            }
            else
            {
                MessageBox.Show("Please select a valid port from list to connect Virtual Machine ...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnDisconnect_Click(object sender, EventArgs e)
        {
            if (VMPort.IsOpen) VMPort.Close();
            VMisConnected = false;
            VMStatus.Text = "Virtual Machine is Disconnected.";
        }

        private void VMPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (VMisConnected)
            {
                string ReceivedData = "error:1101";
                string[] Commands;
                string Order;

                char[] delimiterChars = { ' ' };
                Commands = ReceivedData.Split(delimiterChars);
                try
                {
                    ReceivedData = VMPort.ReadTo(ReadToChar);
                }
                catch
                {
                    Order = "error:1101";
                    // The connection has timed out.
                }

                try
                {
                    Commands = ReceivedData.Split(delimiterChars);
                    Order = Commands[0];
                }
                catch
                {
                    Order = "error:1102";
                }

                switch (Order)
                {
                    case "error:1101":
                        VMPort.DiscardOutBuffer(); //Clear Buffer
                        VMPort.DiscardInBuffer(); //Clear Buffer
                        MessageBox.Show("Run is stoped because of error 1101 ...");
                        SetVMStatus("Run is stoped because of error 1101 ...");
                        VMPort.Write("Stoped" + ReadToChar);
                        break;
                    case "error:1102":
                        VMPort.DiscardOutBuffer(); //Clear Buffer
                        VMPort.DiscardInBuffer(); //Clear Buffer
                        MessageBox.Show("Run is stoped because of error 1102 ...");
                        SetVMStatus("Run is stoped because of error 1102 ...");
                        VMPort.Write("Stoped" + ReadToChar);
                        break;
                    case "you?":
                        VMPort.Write(DeviceName + ReadToChar);
                        break;
                    case "ver?":
                        VMPort.Write(DeviceVersion.ToString() + ReadToChar);
                        break;
                    case "IDCS":
                        IV_IDCSelect = Convert.ToInt32(Commands[1]);
                        //Thread.SpinWait(4000 * 1000);
                        VMPort.Write("OK" + ReadToChar);
                        break;
                    case "IACS":
                        IV_IACSelect = Convert.ToInt32(Commands[1]);
                        //Thread.SpinWait(4000 * 1000);
                        VMPort.Write("OK" + ReadToChar);
                        break;
                    case "VS":
                        VSelect = Convert.ToInt32(Commands[1]);
                        //Thread.SpinWait(4000 * 1000);
                        VMPort.Write("OK" + ReadToChar);
                        break;
                    case "SVDC":
                        VDC = Convert.ToInt32(Commands[1]);
                        Test2IV(ref VDC, IV_IDCSelect, ref IDC);
                        //Thread.SpinWait(4000 * 1000);
                        VMPort.Write("OK" + ReadToChar);
                        break;
                    case "SVAC":
                        VAC = Convert.ToInt32(Commands[1]);
                        //Thread.SpinWait(4000 * 1000);
                        VMPort.Write("OK" + ReadToChar);
                        break;
                    case "SAF":
                        nClock = Convert.ToInt32(Commands[1]);
                        double dfrq = Form1.GetFrqConvert(nClock,1);
                        double dRealI=0,dImagI=0, dRealV=0, dImagV=0;
                        if (MaterialIndex == 0) TestData2(dfrq, ref dRealI, ref dImagI, ref dRealV, ref dImagV);
                        if (MaterialIndex == 1) FeCNData2(dfrq, ref dRealI, ref dImagI, ref dRealV, ref dImagV);
                        RealI = Form1.SetAnalogeConvert(dRealI);
                        ImagI = Form1.SetAnalogeConvert(dImagI);
                        RealV = Form1.SetAnalogeConvert(dRealV);
                        ImagV = Form1.SetAnalogeConvert(dImagV);
                        //Thread.SpinWait(4000 * 1000);
                        VMPort.Write("OK" + ReadToChar);
                        break;
                    case "GVDC":
                        //Thread.SpinWait(4000 * 1000);
                        VMPort.Write(VDC.ToString() + ReadToChar);
                        break;
                    case "GIDC":
                        //Thread.SpinWait(4000 * 1000);
                        VMPort.Write(IDC.ToString() + ReadToChar);
                        break;
                    case "GF":
                        VMPort.Write(nClock.ToString() + ReadToChar);
                        break;
                    case "GRI":
                        VMPort.Write(RealI.ToString() + ReadToChar);
                        break;
                    case "GII":
                        VMPort.Write(ImagI.ToString() + ReadToChar);
                        break;
                    case "GRV":
                        VMPort.Write(RealV.ToString() + ReadToChar);
                        break;
                    case "GIV":
                        VMPort.Write(ImagV.ToString() + ReadToChar);
                        break;
                    case "eisd":
                        nClock = Convert.ToInt32(Commands[1]);
                        //double dfrq = Form1.GetFrqConvert(nClock);
                        AllowToSendData = true;
                        break;
                    case "Imp?":
                        VMPort.Write("Vlt?" + ReadToChar);
                        break;
                    case "IVAmp?":
                        VMPort.Write("IVVlt?" + ReadToChar);
                        break;
                    case "Vlt":
                        try
                        {
                            IntVlt = Convert.ToInt32(Commands[1]);
                            VMPort.Write("Amp?" + ReadToChar);
                        }
                        catch
                        {
                            VMPort.DiscardOutBuffer(); //Clear Buffer
                            VMPort.DiscardInBuffer(); //Clear Buffer
                            MessageBox.Show("Run is stoped because of error 1103 ...");
                            SetVMStatus("Run is stoped because of error 1103 ...");
                            VMPort.Write("Stoped" + ReadToChar);
                        }
                        break;
                    case "Amp":
                        try
                        {
                            IntAmp = Convert.ToInt32(Commands[1]);
                            VMPort.Write("Frq?" + ReadToChar);
                        }
                        catch
                        {
                            VMPort.DiscardOutBuffer(); //Clear Buffer
                            VMPort.DiscardInBuffer(); //Clear Buffer
                            MessageBox.Show("Run is stoped because of error 1103 ...");
                            SetVMStatus("Run is stoped because of error 1103 ...");
                            VMPort.Write("Stoped" + ReadToChar);
                        }
                        break;
                    case "Frq":
                        try
                        {
                            IntFrq = Convert.ToInt32(Commands[1]);

                            double  frq = 0.1 * IntFrq;
                            double ReZ = 0;
                            double ImZ = 0;

                            Thread.SpinWait(4000 * 1000);
                            if (MaterialIndex == 0) TestData(frq, ref ReZ, ref ImZ);
                            if (MaterialIndex == 1) FeCNData(frq, ref ReZ, ref ImZ);
                            VMPort.Write("Imp " + ReZ.ToString() + " " + ImZ.ToString() + ReadToChar);
                        }
                        catch
                        {
                            VMPort.DiscardOutBuffer(); //Clear Buffer
                            VMPort.DiscardInBuffer(); //Clear Buffer
                            MessageBox.Show("Run is stoped because of error 1103 ...");
                            SetVMStatus("Run is stoped because of error 1103 ...");
                            VMPort.Write("Stoped" + ReadToChar);
                        }
                        break;
                    case "IVVlt":
                        try
                        {
                            IntIVVlt = Convert.ToInt32(Commands[1]);
                            VMPort.Write("IVRng?" + ReadToChar);
                        }
                        catch
                        {
                            VMPort.DiscardOutBuffer(); //Clear Buffer
                            VMPort.DiscardInBuffer(); //Clear Buffer
                            MessageBox.Show("Run is stoped because of error 1103 ...");
                            SetVMStatus("Run is stoped because of error 1103 ...");
                            VMPort.Write("Stoped" + ReadToChar);
                        }
                        break;
                    case "IVRng":
                        try
                        {
                            IntIVRng = Convert.ToInt32(Commands[1]);

                            double vlt = 0.1 * IntIVVlt;

                            Thread.SpinWait(4000 * 1000);
                            if (MaterialIndex == 0) TestIV(vlt, IntIVRng, ref IntAmp);
                            if (MaterialIndex == 1) FeCNIV(vlt, IntIVRng, ref IntAmp);
                            VMPort.Write("IVAmp " + IntAmp.ToString() + ReadToChar);
                        }
                        catch
                        {
                            VMPort.DiscardOutBuffer(); //Clear Buffer
                            VMPort.DiscardInBuffer(); //Clear Buffer
                            MessageBox.Show("Run is stoped because of error 1103 ...");
                            SetVMStatus("Run is stoped because of error 1103 ...");
                            VMPort.Write("Stoped" + ReadToChar);
                        }
                        break;
                    default:
                        VMPort.DiscardOutBuffer(); //Clear Buffer
                        VMPort.DiscardInBuffer(); //Clear Buffer
                        MessageBox.Show("Undefined command is received from EIS ...");
                        SetVMStatus("Virtual Machine is stoped because of undefined command ...");
                        VMPort.Write("Stoped" + ReadToChar);
                        break;
                }
            }
        }

        delegate void SetTextCallback(string text);

        private void DigitalDataSenderTimer_Tick(object sender, EventArgs e)
        {
            if (AllowToSendData)
            {
                AllowToSendData = false;
                if (!isDigitalDataSenderDataArraysinProsses)
                {
                    if (isDigitalDataSenderTimerCompleted)
                    {
                        isDigitalDataSenderDataArraysinProsses = true;
                        int TestDigitalEISTimerInterval = (int)(2 * 8000 / nClock);
                        if (TestDigitalEISTimerInterval > Form1.DigitalEISTimerMinInterval)
                            DigitalDataSenderTimer.Interval = TestDigitalEISTimerInterval;
                        else
                            DigitalDataSenderTimer.Interval = Form1.DigitalEISTimerMinInterval;

                        double dfrq = Form1.GetFrqConvert(nClock,1);
                        double dRealI = 0, dImagI = 0, dRealV = 0, dImagV = 0;

                        if (MaterialIndex == 0) TestData2(dfrq, ref dRealI, ref dImagI, ref dRealV, ref dImagV);
                        if (MaterialIndex == 1) FeCNData2(dfrq, ref dRealI, ref dImagI, ref dRealV, ref dImagV);

                        DigitalTimeInterval = 0.0327675;

                        for (int iData = 0; iData < nData; iData++)
                        {
                            double t = iData * DigitalTimeInterval;
                            Data2[iData, 0] = dRealV * Math.Sin(2 * 3.141592 * dfrq * t) + dImagV * Math.Cos(2 * 3.141592 * dfrq * t) +
                                0.01 * t + 0.1;
                            Data2[iData, 1] = dRealI * Math.Sin(2 * 3.141592 * dfrq * t) + dImagI * Math.Cos(2 * 3.141592 * dfrq * t) -
                                0.01 * t - 0.1;
                        }

                        isDigitalDataSenderTimerCompleted = false;
                        isDigitalDataSenderDataArraysinProsses = false;
                        AllowToSendData = true;
                    }
                    else
                    {
                        AllowToSendData = false;
                        byte[] byte2 = new byte[1];
                        byte2[0] = 255;
                        VMPort.Write(byte2, 0, 1);
                        byte2[0] = 255;
                        VMPort.Write(byte2, 0, 1);

                        for (int iData = 0; iData < nData; iData++)
                        {
                            byte[] byte4 = new byte[1];
                            int MyV = Form1.SetDCVConvert(Data2[iData, 0], VSelect, 0, 0);
                            int MyI = Form1.SetDCVConvert(Data2[iData, 1], VSelect, 0, 0); // Correct this later to I

                            byte4[0] = (byte)(Math.Floor(1.0 * MyV / 256));
                            VMPort.Write(byte4, 0, 1);
                            byte4[0] = (byte)(MyV % 256);
                            VMPort.Write(byte4, 0, 1);
                            byte4[0] = (byte)(Math.Floor(1.0 * MyI / 256));
                            VMPort.Write(byte4, 0, 1);
                            byte4[0] = (byte)(MyI % 256);
                            VMPort.Write(byte4, 0, 1);
                        }

                        isDigitalDataSenderTimerCompleted = true;
                        DigitalDataSenderTimer.Interval = 1000;
                    }
                }
            }
        }


        private void SetVMStatus(string text)
        {
            if (VMStatus.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetVMStatus);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                VMStatus.Text = text;
            }
        }

        private void VMTimer_Tick(object sender, EventArgs e)
        {

        }

        private void FormVM_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Form1.isVM = false;
            this.Hide();
        }

        private void TestData(double frq, ref double ReZ, ref double ImZ)
        {
            Random r = new Random();

            double R1 = 2;
            double R2 = 1;
            double R3 = 2;
            double R4 = 1;
            double c1 = 0.1;
            double c2 = 0.01;
            double c3 = 0.0001;

            ReZ = R1 / (1 + c1 * c1 * R1 * R1 * frq * frq) + R2 / (1 + c2 * c2 * R2 * R2 * frq * frq) + R3 / (1 + c3 * c3 * R3 * R3 * frq * frq) + R4 + r.NextDouble()/10;
            ImZ = -(c1 * R1 * R1 * frq) / (1 + c1 * c1 * R1 * R1 * frq * frq) - (c2 * R2 * R2 * frq) / (1 + c2 * c2 * R2 * R2 * frq * frq) - (c3 * R3 * R3 * frq) / (1 + c3 * c3 * R3 * R3 * frq * frq) + r.NextDouble() / 10;
        }

        private void TestData2(double frq, ref double RealI, ref double ImagI, ref double RealV, ref double ImagV)
        {
            double ReZ = 0.0;
            double ImZ = 0.0;
            TestData(frq, ref ReZ, ref ImZ);
            RealI = 1;
            ImagI = 1;
            RealV = -ImZ + ReZ;
            ImagV = ImZ + ReZ;
        }

        private void TestIV(double vlt, int RangeMode, ref int IntAmp)
        {
            Random r = new Random();
            IntAmp = (int)((.75 * vlt + r.NextDouble()/2) * 1000);
        }

        private void Test2IV(ref int IntVlt, int RangeMode, ref int IntAmp)
        {
            Random r = new Random();
            IntVlt = (int)(IntVlt + 80*r.NextDouble() - 40);
            if (RangeMode==0)
                IntAmp = (int)((0.7 * IntVlt + 100 * r.NextDouble() - 50));
            else if (RangeMode==1)
                IntAmp = (int)((1.0 * IntVlt + 100 * r.NextDouble() - 50));
            else if (RangeMode==2)
                IntAmp = (int)((1.2 * IntVlt + 100 * r.NextDouble() - 50));
        }

        private void FeCNIV(double vlt, int RangeMode, ref int IntAmp)
        {
            Random r = new Random();
            IntAmp = (int)((3.5 * vlt + r.NextDouble()/3) * 1000);
        }

        private void FeCNData2(double frq, ref double RealI, ref double ImagI, ref double RealV, ref double ImagV)
        {
            double ReZ = 0.0;
            double ImZ = 0.0;
            FeCNData(frq, ref ReZ, ref ImZ);
            RealI = 1;
            ImagI = 1;
            RealV = -ImZ + ReZ;
            ImagV = ImZ + ReZ;
        }

        private void FeCNData(double frq, ref double ReZ, ref double ImZ)
        {
            //Frequency (Hz)	Zre (ohms)	Zim (ohms)	
            double[] frqTable = new double[61]{
                100000,
                79432.82,
                63095.73,
                50118.72,
                39810.72,
                31622.78,
                25118.87,
                19952.62,
                15848.93,
                12589.25,
                10000,
                7943.282,
                6309.573,
                5011.873,
                3981.072,
                3162.278,
                2511.886,
                1995.262,
                1584.893,
                1258.925,
                1000,
                794.3282,
                630.9573,
                501.1872,
                398.1072,
                316.2278,
                251.1886,
                199.5262,
                158.4893,
                125.8925,
                100,
                79.43282,
                63.09573,
                50.11872,
                39.81072,
                31.62278,
                25.11886,
                19.95262,
                15.84893,
                12.58925,
                10,
                7.943282,
                6.309574,
                5.011872,
                3.981072,
                3.162278,
                2.511886,
                1.995262,
                1.584893,
                1.258925,
                1,
                0.7943282,
                0.6309574,
                0.5011872,
                0.3981072,
                0.3162278,
                0.2511886,
                0.1995262,
                0.1584893,
                0.1258925,
                0.1
            };

            double[] ReZTable = new double[61]{
                43.86171165,
                43.71019663,
                43.72848381,
                43.69134342,
                43.78671738,
                43.86150293,
                43.89463381,
                44.03730985,
                44.19731739,
                44.38126938,
                44.60435749,
                44.86322037,
                45.09699689,
                45.40172561,
                45.68455044,
                45.97306962,
                46.31093485,
                46.60251689,
                46.922661,
                47.20159899,
                47.46656338,
                47.76271755,
                47.99685866,
                48.21800074,
                48.48118045,
                48.69367482,
                48.94244174,
                49.15792293,
                49.44903395,
                49.66570261,
                49.98663778,
                50.28929917,
                50.5830347,
                50.9631402,
                51.30138071,
                51.6367892,
                52.05342922,
                52.54641036,
                52.97413682,
                53.62233649,
                54.04708394,
                54.84786788,
                55.30747161,
                56.09032173,
                57.28565864,
                57.73452914,
                58.48823412,
                59.4092295,
                60.38997253,
                61.47072697,
                62.72256454,
                65.56473778,
                65.6726649,
                67.34051632,
                69.21130662,
                71.95109633,
                75.03247324,
                76.41237043,
                78.49913014,
                83.7096601,
                86.0045363
            };

            double[] ImZTable = new double[61]{
            -0.599533257,
            -0.641877149,
            -0.665059501,
            -0.691142276,
            -0.801051186,
            -0.871895864,
            -0.992719416,
            -1.181699605,
            -1.296618907,
            -1.398418612,
            -1.502949511,
            -1.597289476,
            -1.698497223,
            -1.772556286,
            -1.846957505,
            -1.901733945,
            -1.904490868,
            -1.889056883,
            -1.915571384,
            -1.88419425,
            -1.865414508,
            -1.832267974,
            -1.835810773,
            -1.815313114,
            -1.847027334,
            -1.862636346,
            -1.917740806,
            -1.965213135,
            -2.064537998,
            -2.157946919,
            -2.282606213,
            -2.423865719,
            -2.581687906,
            -2.756379767,
            -2.994555578,
            -3.20561145,
            -3.440181465,
            -3.715819118,
            -4.059958873,
            -4.509230358,
            -4.824415009,
            -5.485447876,
            -5.76652116,
            -6.062881747,
            -6.886734807,
            -7.793659471,
            -8.312489822,
            -8.977980632,
            -9.756389953,
            -10.49004926,
            -11.39871976,
            -12.97702364,
            -15.19733317,
            -15.85328977,
            -16.48964117,
            -17.92349682,
            -22.55562599,
            -23.78576374,
            -27.55237868,
            -29.00829359,
            -32.35538925
        };
            int i = -1;
            for (double f = 0.1; f < 100000; f = f * 1.258925)
            {
                i++;
                if (f >= frq) break;
            }
            if (i > 59) i = 59;

            ReZ = ReZTable[60 - i] + (ReZTable[60 - i - 1] - ReZTable[60 - i]) / (frqTable[60 - i - 1] - frqTable[60 - i]) * (frq - frqTable[60 - i]);
            ImZ = ImZTable[60 - i] + (ImZTable[60 - i - 1] - ImZTable[60 - i]) / (frqTable[60 - i - 1] - frqTable[60 - i]) * (frq - frqTable[60 - i]);
        }

        private void CBMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            MaterialIndex = CBMaterial.SelectedIndex;
        }
    }
}
