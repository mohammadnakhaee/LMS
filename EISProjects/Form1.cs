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
using System.Diagnostics;



namespace EISProjects
{
    public partial class Form1 : Form
    {
        ////////////////////////////////////////
        public static int Version = 1024;
        public static int SettingsVersion = 8;
        public static SettingsData Settings = new SettingsData();
        public static RichTextBox Status = new RichTextBox();
        public static SerialPort Port = new SerialPort("COM1", 921600, Parity.None, 8, StopBits.One);
        public static List<Sessions> AllSessions = new List<Sessions> { };
        public static List<RichTextBox> AllSessionsGUI = new List<RichTextBox> { };
        public static List<int> AllSessionsHashCode = new List<int> { };
        public static int Selected = 0;
        public static Color SelectedColor = Color.SeaShell;
        public static FactoryDefaults FactoryDefault = new FactoryDefaults();
        public static List<SessionOutputData> AllSessionsData = new List<SessionOutputData> { };
        public static FormPort FormPort;
        public static FormVM VM = new FormVM();
        public static FormDiagram FormDiagram = new FormDiagram();
        public static FormFitting FormFit = new FormFitting();
        public static FormDataGrid FormDG = new FormDataGrid();
        public static FormEISDigital FormEISDScope = new FormEISDigital();
        public static FormEISDigital FormEISDScope2 = new FormEISDigital();
        public static FormTerminal formTerminal = new FormTerminal();
        public static bool isProbOn = false;
        public static bool isDummyOn = false;
        public static bool isFormPort = false;
        public static bool isVM = false;
        public static bool isFormDiagram = false;
        public static bool isFormFit = false;
        public static bool isFormDG = false;
        public static bool isFormEISDScope = false;
        public static bool isFormEISDScope2 = false;
        public static bool isFormTerminal = false;
        public static bool isFormSetting = false;
        public static int[] SessionsDim;
        public static int nPBAllSessions;
        public static int PBAllSessionsValue;
        public static bool isOpenNewFile = false;
        public static bool isDataToExport = false;
        public static bool isRunPause = false;
        public static bool isRunStart = false;
        public static string ReadToChar = "\r";
        public static string WriteReadToChar = "\r";
        public static bool isRunCanseled = false;
        public static double deltaV, deltaI, frqMultStep;
        public static int IVnDataTotal;
        public static int PulsenDataTotal;
        public static bool isPulseTimerTickInProcess = false;
        public static double[] IVVDataTotal;
        public static double[] IVIDataTotal;
        public static double[] IVtDataTotal;
        public static double[] PulseVDataTotal;
        public static double[] PulseIDataTotal;
        public static double[] PulsetDataTotal;
        public static bool isDataReceivedSet = false;
        public static bool isIVTimerTickSet = false;
        public static bool isPulseTimerTickSet = false;
        public static System.Windows.Forms.Timer IVTimer1;
        public static System.Windows.Forms.Timer PulseTimer1;
        public static bool isAnalogEISTimerTickSet = false;
        public static System.Windows.Forms.Timer AnalogEISTimer;
        public static bool isAnalogEISStepCompleted = true;
        public static int AnalogEISStepUnSuccessCounter = 0;
        public static int AnalogEISTimerMinInterval = 1000;
        public static bool isDigitalEISTimerTickSet = false;
        public static System.Windows.Forms.Timer DigitalEISTimer;
        public static bool isDigitalEISStepCompleted = true;
        public static int DigitalEISStepUnSuccessCounter = 0;
        public static int DigitalEISTimerMinInterval = 200;
        public static bool AllowToTick = true;
        public static bool isDataReceived = false;
        public static int IVnData = 512;
        public static int PulsenData = 10;
        public static int PulseiDataAchieved = 0;
        public static int[,] PulseAllBytesAchieved = new int[2 * PulsenData, 4];
        public static int DigitalEISReceivernData = 512;
        public static bool isIAmpApplyed = false;
        public static int isThisTheBestImlp = 0;
        public static bool isVAmpApplyed = false;
        public static int isThisTheBestVmlp = 0;
        public static int DEISCurrentImlp = 0;
        public static int OldDEISCurrentImlp = -1;
        public static int DEISCurrentVmlp = 0;
        public int EISMaxIDCSelect = 0;
        public static int OldDEISCurrentVmlp = -1;
        public static bool isNeedToCorrect = true;
        public static double CurrentDigitalEIS_VAC_RMS = 0;
        public static int oldiCurrentDigitalEIS_VAC_RMS = -1;
        public static double TheLastAmplitude = 0;
        public static bool isFrequencyChanged = true;
        public static bool isCBIVVoltageRangeCompleted = true;
        public static bool isCBIVRangeCompleted = true;
        public static bool isCBPulseVoltageRangeCompleted = true;
        public static bool isCBPulseRangeCompleted = true;
        public static bool isVmlpCompleted = true;
        public static bool isImlpCompleted = true;
        public static bool isPulseVmlpCompleted = true;
        public static bool isPulseImlpCompleted = true;
        public static double ThisIV_Ioffset = 0;
        public static double ThisIV_Voffset = 0;
        public static double ThisPulse_Ioffset = 0;
        public static double ThisPulse_Voffset = 0;
        public static bool isIVRangesChanged = true;
        public static bool isPulseRangesChanged = true;
        public static bool isAdminLoged = false;
        public static bool isPreProccessingCompleted = false;
        public static bool isformPID = false;
        public static int TotalTime = 0;
        public static bool isEndorseOCTOk = false;
        public static double EndorseOCTSugestedV = 0.0;
        public static bool isOCTContinueRequested = false;
        public static double SugestedVOCP = 0.0;
        public static int EISAverageNumberCounter = 0;
        public static double EISRealImpMean = 0;
        public static double EISImagImpMean = 0;
        public static Process process;
        public static bool GoToNext = true;
        public static bool isEISVoltageAndCurrentOK = false;
        public static double WarningV = 0;
        public static double WarningI = 0;
        public static bool isEISVoltageAndCurrentWarning = false;
        public static int FWaitTime = 0;
        public static int EISfalseCounter = 0;
        public static int BoardType = 1;
        public static double IVMaxFineCurrent = 1.0;
        public static double PulseMaxFineCurrent = 1.0;
        public static double IVChronoTimeStep = 0.0;
        public static double PulseTimeStep = 0;
        public static double IVChronoVset = 0.0;
        public static double IVChronoDVset = 0.0;
        public static int IVVsetcnt = 0;
        public static int EISMotLast_idcmlp = 0;
        public static int EISMotLast_vdcmlp = 0;
        public static double PulseMaxVoltage = 0;
        public static double PulseMinVoltage = 0;
        public static bool IsReconnectingMode = false;
        public static double EISVAmplitudeRMS = 0.0;
        int Ecount = 0;
        int pgmode = 0;
        public static double CV_newExactdelta = 0;
        public static double i_zero = 0;
        public static int iIs=3,iacdac, iIschanged=0;
        //public static System.Timers.Timer IVTimer1;
        //public static void loadSetting(ref SettingsData Settings);
        ////////////////////////////////////////

        public Form1()
        {


            Settings.Version = SettingsVersion;
            InitializeComponent();
            Port.ReadBufferSize = 100000;
            FormPort = new FormPort(this);
            loadSetting(ref Settings);
            //////////////////////////////
            Settings.DEISMeanPercent = FactoryDefault.DEISMeanPercent;
            Settings.DEISNOverFlow0 = FactoryDefault.DEISNOverFlow0;
            //////////////////////////////
            EIS.ready = true;
            EIS.Connected = false;
            EIS.ReceiveMode = false;

            isProbOn = false;
            SampleOnBtn.Text = "Probe On";
            SampleOnBtn.ForeColor = Color.Red;

            Status.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            Status.Dock = System.Windows.Forms.DockStyle.Left;
            Status.ForeColor = System.Drawing.SystemColors.Window;
            Status.Location = new System.Drawing.Point(0, 0);
            Status.Name = "Status";
            Status.Size = new System.Drawing.Size(127, 49);
            Status.TabIndex = 0;
            Status.Text = "Ready";
            Status.Parent = StatusPanel;
            Status.Show();

            Port.NewLine = ReadToChar;

            FormPort.MaximizeBox = false;
            VM.MaximizeBox = false;

            EIS.ReScaleFactor = FactoryDefault.ReScaleFactor;

            saveFileDialog1.Filter = "EIS Files|*.eis";
            openFileDialog1.Filter = "EIS Files|*.eis";
            saveFileDialogSSnExp.Filter = "Data Files|*.dat";
            //////////////////////////////

            chart1.Series.Clear();
            AddSeries(" ", "time (ms)", "Pulse", Color.Navy);
            AddSeriesPoint("measures", "time (ms)", "Measures", Color.Red);
            AddSeries("Low", " ", " ", Color.Red);
            AddSeries("High", " ", " ", Color.Red);

            SetCustomBorder();
            SetButtonStyles();
            SetLogoStyles();
#if !DEBUG
                Size s = GBAdminLog.Size;
            s.Height = 20;
            GBAdminLog.Size = s;
#endif

            System.ComponentModel.ComponentResourceManager resources =
    new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Icon = ((System.Drawing.Icon)(global::EISProjects.Properties.Resources.LMS));



    }

        private void SetButtonStyles()
        {
            ChangeStyle(BtnNew);
            ChangeStyle(BtnOpen);
            ChangeStyle(BtnSave);
            ChangeStyle(BtnSaveAs);
            ChangeStyle(button3);
            ChangeStyle(CheckPID);
            ChangeStyle(BtnAppend);
            ChangeStyle(BtnImport);
            ChangeStyle(BtnDuplicate);
            ChangeStyle(BtnDelete);
            ChangeStyle(BtnPort);
            ChangeStyle(BtnDiagram);
            ChangeStyle(BtnFitt);
            ChangeStyle(BtnSetting);
            ChangeStyle(BtnSetting);
            ChangeStyle(button1);
            ChangeStyle(button2);
            ChangeStyle(BtnTerminal);
            ChangeStyle(BtnShowData);
            ChangeStyle(BtnVirtualMachine);
            ChangeStyle(BtnCreateSession);
            ChangeStyle(BtnFindOCP);
            ChangeStyle(button11);
            ChangeStyle(button_notch);
            ChangeStyle(button_earth);
            ChangeStyle(BtnOffsetRemoval, 'g');
            ChangeStyle(button9, 'g');
            ChangeStyle(button8, 'g');
            ChangeStyle(BtnSaveOffsetSettings, 'g');
            ChangeStyle(BtnBackupSettings, 'g');
            ChangeStyle(BtnRecoverSettings, 'g');
            ChangeStyle(BtnAbout);
            ChangeStyle(button4);
            ChangeStyle(BtnLogout,'r');

            ChangeStyle(SampleOnBtn,'r');
            ChangeStyle(DummyOnBtn,'r');
            ChangeStyle(BtnRunS,'g');
            ChangeStyle(BtnRun,'g');
            ChangeStyle(BtnPauseContinue,'g');

            
        }

        private void SetCustomBorder()
        {
            //this.FormBorderStyle = FormBorderStyle.None;
            PictureBox Border = new PictureBox();
            Border.Parent = this;
            Border.Location = new Point(0, 0);
            Border.Size = new Size(100, 32);
            Border.Dock = DockStyle.Top;
            //Border.Image = global::EISProjects.Properties.Resources.border;
            //Border.Image = global::CAngle.Properties.Resources.cangleiconpng;
            Border.BackColor = Color.FromArgb(110,128,160);
            Border.SizeMode = PictureBoxSizeMode.StretchImage;
            Border.Paint += Border_Paint;
            Border.DoubleClick += Border_DoubleClick;
            Border.MouseDown += Border_MouseDown;
            Border.MouseMove += Border_MouseMove;
            Border.MouseUp += Border_MouseUp;

            PictureBox mylogo = new PictureBox();
            mylogo.Parent = Border;
            float aspectratio = (float)global::EISProjects.Properties.Resources.logolink_normal.Width / (float)global::EISProjects.Properties.Resources.logolink_normal.Height;
            mylogo.Size = new Size((int)Math.Round(aspectratio * Border.Height), Border.Height);
            mylogo.Dock = DockStyle.Right;
            SetLogoStyle(mylogo);

            Font drawFont2 = new Font("Marlett", 10, FontStyle.Bold);

            Button MinimizeButton = new Button();
            MinimizeButton.Parent = Border;
            MinimizeButton.Size = new Size(Border.Height, Border.Height);
            MinimizeButton.FlatStyle = FlatStyle.Flat;
            MinimizeButton.FlatAppearance.BorderSize = 0;
            MinimizeButton.Dock = DockStyle.Right;
            MinimizeButton.Font = drawFont2;
            MinimizeButton.ForeColor = Color.White;
            char c = '\u0030';
            MinimizeButton.Text = c.ToString();
            MinimizeButton.Click += MinimizeButton_Click;

            Button RestoreButton = new Button();
            RestoreButton.Parent = Border;
            RestoreButton.Size = new Size(Border.Height, Border.Height);
            RestoreButton.FlatStyle = FlatStyle.Flat;
            RestoreButton.FlatAppearance.BorderSize = 0;
            RestoreButton.Dock = DockStyle.Right;
            RestoreButton.Font = drawFont2;
            RestoreButton.ForeColor = Color.White;
            if (this.WindowState == FormWindowState.Maximized)
                c = '\u0032';
            else
                c = '\u0031';
            RestoreButton.Text = c.ToString();
            RestoreButton.Click += RestoreButton_Click;
            RestoreButton.Paint += RestoreButton_Paint;

            Button CloseButton = new Button();
            CloseButton.Parent = Border;
            CloseButton.Size = new Size(Border.Height, Border.Height);
            CloseButton.FlatStyle = FlatStyle.Flat;
            CloseButton.FlatAppearance.BorderSize = 0;
            CloseButton.Dock = DockStyle.Right;
            CloseButton.Font = drawFont2;
            CloseButton.ForeColor = Color.White;
            c = '\u0072';
            CloseButton.Text = c.ToString();
            CloseButton.Click += CloseButton_Click;

            tabControl1.Parent.BackColor = Color.FromArgb(214, 219, 233);

            //EnterFullScreenMode();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.MessageLoop)
            {
                if (EIS.nSsn > 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to save project?", "save", MessageBoxButtons.YesNoCancel);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (EIS.FileName == "")
                            BtnSaveAs_Click(null, null);
                        else
                            BtnSave_Click(null, null);

                        System.Environment.Exit(0);
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        //System.Windows.Forms.Application.Exit();
                        System.Environment.Exit(0);
                    }
                }
                else
                {
                   // System.Windows.Forms.Application.Exit();
                    System.Environment.Exit(0);
                }
                
            }
            else
            {
                // Console app
                System.Environment.Exit(0);
            }
        }

        private void RestoreButton_Paint(object sender, PaintEventArgs e)
        {
            Button RestoreButton = (Button)sender;
            char c = '\u0032';
            if (this.WindowState == FormWindowState.Maximized)
                c = '\u0032';
            else
                c = '\u0031';
            RestoreButton.Text = c.ToString();
        }

        private void RestoreButton_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
                LeaveFullScreenMode();
            else
                EnterFullScreenMode();
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        int mouseX = 0; int mouseY = 0; bool isMove = false;
        private void Border_MouseDown(object sender, MouseEventArgs e)
        {
            isMove = true;
            mouseX = e.X;
            mouseY = e.Y;
        }

        private void Border_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMove)
            {
                int dx = e.X - mouseX;
                int dy = e.Y - mouseY;
                this.SetDesktopLocation(this.Location.X + dx, this.Location.Y + dy);
            }
        }

        private void Border_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;
        }

        private void Border_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
                LeaveFullScreenMode();
            else
                EnterFullScreenMode();
        }

        private void Border_Paint(object sender, PaintEventArgs e)
        {
            // Create string to draw.
            String drawString = "LMS";

            // Create font and brush.
            Font drawFont = new Font("Arial", 11, FontStyle.Bold);

            SolidBrush drawBrush = new SolidBrush(Color.FromArgb(255, 255, 255));

            // Create point for upper-left corner of drawing.
            int x0 = 5;
            int y0 = 0;
            float y = 8.0F;

            // Set format of string.
            StringFormat drawFormat = new StringFormat();
            drawFormat.FormatFlags = StringFormatFlags.NoWrap;

            // Draw string to screen.
            float aspectratio = (float)global::EISProjects.Properties.Resources.iconpng.Width / (float)global::EISProjects.Properties.Resources.iconpng.Height;
            int logowidth = (int)Math.Round(30.0 * aspectratio);
            e.Graphics.DrawImage(global::EISProjects.Properties.Resources.iconpng, (int)x0, (int)y0, logowidth, 30);

            e.Graphics.DrawString(drawString, drawFont, drawBrush, logowidth + 9, y-2, drawFormat);
        }

        private void EnterFullScreenMode()
        {
            this.ControlBox = true;
            //this.ControlBox = true;
            this.WindowState = FormWindowState.Maximized;
            this.ControlBox = false;
            //this.ControlBox = true;

            //this.Hide();
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //this.WindowState = FormWindowState.Normal;
            //this.WindowState = FormWindowState.Maximized;
            //this.Show();
        }

        private void LeaveFullScreenMode()
        {
            //this.Text = " ";
            this.WindowState = FormWindowState.Normal;
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                //this.ControlBox = true;
                //this.WindowState = FormWindowState.Normal;
                this.WindowState = FormWindowState.Maximized;
                this.ControlBox = false;
            }
        }

        private void MaximizeWindow()
        {
            var rectangle = Screen.FromControl(this).Bounds;
            this.FormBorderStyle = FormBorderStyle.None;
            Size = new Size(rectangle.Width, rectangle.Height);
            Location = new Point(0, 0);
            Rectangle workingRectangle = Screen.PrimaryScreen.WorkingArea;
            this.Size = new Size(workingRectangle.Width, workingRectangle.Height);
        }

        private void ResizableWindow()
        {
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
        }

        private void SetLogoStyles()
        {
            //SetLogoStyle(pictureBox1);
            //SetLogoStyle(pictureBox2);
            //SetLogoStyle(pictureBox3);
            //SetLogoStyle(pictureBox4);
            //SetLogoStyle(pictureBox5);
            //SetLogoStyle(pictureBox6);
            //SetLogoStyle(pictureBox7);
        }

        private void SetLogoStyle(PictureBox pictureBox)
        {
            pictureBox.BackgroundImage = global::EISProjects.Properties.Resources.logolink_normal;
            pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox.MouseEnter += Logo_MouseEnter;
            pictureBox.MouseLeave += Logo_MouseLeave;
            pictureBox.MouseClick += Logo_MouseClick;
        }

        private void Logo_MouseClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start("http://irasol.com");
        }

        private void Logo_MouseLeave(object sender, EventArgs e)
        {
            PictureBox logo = (PictureBox)sender;
            logo.BackgroundImage = global::EISProjects.Properties.Resources.logolink_normal;
        }

        private void Logo_MouseEnter(object sender, EventArgs e)
        {
            PictureBox logo = (PictureBox)sender;
            logo.BackgroundImage = global::EISProjects.Properties.Resources.logolink_move;
        }

        private void ChangeStyle(Button button, Char color='b')
        {
            button.TabStop = false;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Tag = color;
            button.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent
            if (color=='r')
                button.BackgroundImage = global::EISProjects.Properties.Resources.btn_red_normal;
            else if (color == 'g')
                button.BackgroundImage = global::EISProjects.Properties.Resources.btn_green_normal;
            else if (color == 'b')
                button.BackgroundImage = global::EISProjects.Properties.Resources.btn_blue_normal;
            button.BackgroundImageLayout = ImageLayout.Stretch;
            button.MouseEnter += Button_MouseEnter;
            button.MouseLeave += Button_MouseLeave;
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if ((Char)btn.Tag == 'r')
                btn.BackgroundImage = global::EISProjects.Properties.Resources.btn_red_normal;
            else if ((Char)btn.Tag == 'g')
                btn.BackgroundImage = global::EISProjects.Properties.Resources.btn_green_normal;
            else if ((Char)btn.Tag == 'b')
                btn.BackgroundImage = global::EISProjects.Properties.Resources.btn_blue_normal;
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if ((Char)btn.Tag == 'r')
                btn.BackgroundImage = global::EISProjects.Properties.Resources.btn_red_mouse_move;
            else if ((Char)btn.Tag == 'g')
                btn.BackgroundImage = global::EISProjects.Properties.Resources.btn_green_mouse_move;
            else if ((Char)btn.Tag == 'b')
                btn.BackgroundImage = global::EISProjects.Properties.Resources.btn_blue_mouse_move;
        }

        private void BtnDiagram_Click(object sender, EventArgs e)
        {
            if (isFormDiagram)
            {
                FormDiagram.Hide();
                isFormDiagram = false;
            }
            else
            {
                try
                {
                    FormDiagram.Show(this);
                    isFormDiagram = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BtnPort_Click(object sender, EventArgs e)
        {
            if (isFormPort)
            {
                FormPort.Hide();
                isFormPort = false;
            }
            else
            {
                FormPort.Show(this);
                isFormPort = true;
            }
        }

        private void SessionsGUI_MouseDown(object sender, MouseEventArgs e)
        {
            int SelectedHashCode = sender.GetHashCode();
            int count = 0;
            DeSelectAll();
            foreach (RichTextBox SGUI in AllSessionsGUI)
            {
                if (SGUI.GetHashCode() == SelectedHashCode)
                {
                    Selected = count;
                    SGUI.BackColor = SelectedColor;
                    LoadSelectedProperties();
                    break;
                }
                count++;
            }

            if (e.Button == MouseButtons.Right)
                CMSSession.Show(AllSessionsGUI[Selected], new Point(e.X, e.Y));
        }

        private void DeSelectAll()
        {
            foreach (RichTextBox SGUI in AllSessionsGUI)
                SGUI.BackColor = Color.SlateGray;
        }

        private void LoadSelectedProperties()
        {

            if (AllSessions[Selected].PGmode == 3)
            {
                AllSessions[Selected].IVVoltageRangeMode = 1;
                AllSessions[Selected].PulseVoltageRangeMode = 1;
                AllSessions[Selected].EISVoltageRangeMode = 1;
                CBIVVoltageRangeMode.Enabled = false;
                CBPulseVoltageRangeMode.Enabled = false;
                CBEISVoltageRangeMode.Enabled = false;
            }
            else
            {
                CBIVVoltageRangeMode.Enabled = true;
                CBPulseVoltageRangeMode.Enabled = true;
                CBEISVoltageRangeMode.Enabled = true;
            }

            TBSsnName.Text = AllSessions[Selected].name;
            //TBSsnName.Text = AllSessions[Selected].DataAndTime;
            ChBActive.Checked = AllSessions[Selected].active;
            ChBisCVEnable.Checked = AllSessions[Selected].isCVEnable;
            ChBOCT.Checked = AllSessions[Selected].isOCP;
            ChBOCPAutoStart.Checked = AllSessions[Selected].isOCPAutoStart;
            CB_PGMode.SelectedIndex = AllSessions[Selected].PGmode;
            ChBRelRef.Checked = AllSessions[Selected].RelRef;
            TBEqTime.Text = AllSessions[Selected].EqTime.ToString();

            CBEISOCMode.Enabled = AllSessions[Selected].isOCP;
            TBVOCP.Enabled = AllSessions[Selected].isOCP;
            BtnUseSuggestedVOCP.Enabled = AllSessions[Selected].isOCP;
            ChBOCPAutoStart.Enabled = AllSessions[Selected].isOCP;
            LabelSuggestedVOCP.Text = SugestedVOCP.ToString();
            TBVOCP.Text = AllSessions[Selected].V_OCT.ToString();
            TBIdealVoltage.Text = AllSessions[Selected].IdealVoltage.ToString();

            CBMode.SelectedIndex = AllSessions[Selected].Mode;

            CBEISMode.SelectedIndex = AllSessions[Selected].EISMode;
            CBEISFilterMode.SelectedIndex = AllSessions[Selected].EISfilterMode;
            BtnEISAveNum.Text = AllSessions[Selected].EISAverageNumberL.ToString();
            BtnEISAveNumH.Text = AllSessions[Selected].EISAverageNumberH.ToString();
            CBEISOCMode.SelectedIndex = AllSessions[Selected].EISOCMode;
            CBEISVoltageRangeMode.SelectedIndex = AllSessions[Selected].EISVoltageRangeMode;
            CBEISDCCurrentRangeMode.SelectedIndex = 0;// AllSessions[Selected].EISDCCurrentRangeModea;
                                                      // CBEISACCurrentRangeMode.SelectedIndex = 0;//EISACCurrentRangeMode
            CBEISACRegulatorMode.SelectedIndex = AllSessions[Selected].EISACRegulatorMode;
            CBEISACCurrentRangeMode.SelectedIndex = AllSessions[Selected].EISACCurrentRangeMode;
            CBEISMaxVmlp.SelectedIndex = AllSessions[Selected].EISVmlpMax;
            CBEISMaxImlp.SelectedIndex = AllSessions[Selected].EISImlpMax;

            if (AllSessions[Selected].Mode == 0)
            {
                TBDCVoltageConstant.Text = AllSessions[Selected].DCVoltageConstant.ToString();
                TBACFrqFrom.Text = AllSessions[Selected].ACFrqFrom.ToString();
                TBACFrqTo.Text = AllSessions[Selected].ACFrqTo.ToString();
            }
            else
            {
                TBDCVoltageConstant.Text = AllSessions[Selected].ACFrqConstant.ToString();
                TBACFrqFrom.Text = AllSessions[Selected].DCVoltageFrom.ToString();
                TBACFrqTo.Text = AllSessions[Selected].DCVoltageTo.ToString();
            }

            TBACAmpConstant.Text = (AllSessions[Selected].ACAmpConstant * 1000).ToString();
            TBACFrqNStep.Text = AllSessions[Selected].ACFrqNStep.ToString();
            TBMSCHACAmpCnst.Text = AllSessions[Selected].ACAmpConstant.ToString();
            TBMSCHACFrqCnst.Text = AllSessions[Selected].ACFrqConstant.ToString();
            TBMSCHDCVFrm.Text = AllSessions[Selected].DCVoltageFrom.ToString();
            TBMSCHDCVTo.Text = AllSessions[Selected].DCVoltageTo.ToString();
            TBMSCHDCVStp.Text = AllSessions[Selected].DCVoltageStep.ToString();
            TBCVDCVltCnst.Text = AllSessions[Selected].DCVoltageConstant.ToString();
            TBCVACFrqCnst.Text = AllSessions[Selected].ACFrqConstant.ToString();
            TBCVACAmpFrm.Text = AllSessions[Selected].ACAmpFrom.ToString();
            TBCVACAmpTo.Text = AllSessions[Selected].ACAmpTo.ToString();
            TBCVACAmpStp.Text = AllSessions[Selected].ACAmpStep.ToString();
            TBIVVoltageFrom.Text = AllSessions[Selected].IVVoltageFrom.ToString();
            if (AllSessions[Selected].Mode == 2)
                TBIVVoltageTo.Text = AllSessions[Selected].ChronoEndTime.ToString();
            else
                TBIVVoltageTo.Text = AllSessions[Selected].IVvoltageTo.ToString();
            TBIVVoltageStep.Text = AllSessions[Selected].IVVoltageNStepp.ToString();
            TB_CV_StartPoint.Text = AllSessions[Selected].CVStartpoint.ToString();
            TBPretreatmentVoltage.Text = AllSessions[Selected].PretreatmentVoltage.ToString();
            ChBPreProcProbOn.Checked = AllSessions[Selected].isPreProcProbOn;
            ChBPostProcProbOff.Checked = AllSessions[Selected].isChBPostProcProbOff;
            TB_CV_Itteration.Text = AllSessions[Selected].CVItteration.ToString();
            CBIVVoltageRangeMode.SelectedIndex = AllSessions[Selected].IVVoltageRangeMode;
            IVChronoVFilter.SelectedIndex = AllSessions[Selected].IVChrono_VFilter;
            PlseVFilter.SelectedIndex = AllSessions[Selected].Pulse_VFilter;

            CBPulseVoltageRangeMode.SelectedIndex = AllSessions[Selected].PulseVoltageRangeMode;
            CBPulseCurrentRangeMode.SelectedIndex = AllSessions[Selected].PulseCurrentRangeMode;
            CBPulseVmlp.SelectedIndex = AllSessions[Selected].PulseVmlp;
            CBPulseImlp.SelectedIndex = AllSessions[Selected].PulseImlpp;


            if (AllSessions[Selected].PulseReadingEdgemode == 0)
            {
                RB_Trailing.Checked = true;
                RB_Leading.Checked = false;
                RB_Differential.Checked = false;
            }
            else if (AllSessions[Selected].PulseReadingEdgemode == 1)
            {
                RB_Trailing.Checked = false;
                RB_Leading.Checked = true;
                RB_Differential.Checked = false;
            }
            else if (AllSessions[Selected].PulseReadingEdgemode == 2)
            {
                RB_Trailing.Checked = false;
                RB_Leading.Checked = false;
                RB_Differential.Checked = true;
            }


            RB_Trailing.Enabled = true;
            RB_Leading.Enabled = true;
            RB_Differential.Enabled = true;

            if (AllSessions[Selected].PulseVoltammetryMode == 0)
            {
                RB_Differential.Enabled = false;
            }
            else if (AllSessions[Selected].PulseVoltammetryMode == 1)
            {
                RB_Trailing.Enabled = false;
                RB_Leading.Enabled = false;
            }
            else if (AllSessions[Selected].PulseVoltammetryMode == 2)
            {
                RB_Trailing.Enabled = false;
                RB_Leading.Enabled = false;
            }
            else if (AllSessions[Selected].PulseVoltammetryMode == 3)
            {

            }

            CBIVRange.SelectedIndex = AllSessions[Selected].IVCurrentRangeMode;

            TBIdealVoltage.Enabled = !(ChBPostProcProbOff.Checked);

            isVmlpCompleted = false;
            isImlpCompleted = false;

            VMLP.Items.Clear();
            IMLP.Items.Clear();

            double IVMaxFineCurrentTemp = 1;
            int pow2mlp = 1;
            for (int mlp = 0; mlp < 7; mlp++)
            {
                double Vmax = Settings.GetDCV_Domain;
                double Imax = 0;

                if (CBIVRange.SelectedIndex == 0)
                    Imax = 1;
                else if (CBIVRange.SelectedIndex == 1)
                    Imax = 100;
                else if (CBIVRange.SelectedIndex == 2)
                    Imax = 10;
                else if (CBIVRange.SelectedIndex == 3)  //Added in EISProject66
                    Imax = 1;
                else if (CBIVRange.SelectedIndex == 4)  //Added in EISProject71
                    Imax = 100;
                else if (CBIVRange.SelectedIndex == 5)  //Added in EISProject71
                    Imax = 10;
                else if (CBIVRange.SelectedIndex == 6)  //Added in EISProject71
                    Imax = 1;
                else if (CBIVRange.SelectedIndex == 7)  //Added in EISProject71
                    Imax = 100;

                double dImax = 1.0 * Imax / pow2mlp;
                double dVmax = 1.0 * Vmax / pow2mlp;

                double Ifact = Math.Pow(10, Math.Floor(Math.Log10(dImax)));
                double Vfact = Math.Pow(10, Math.Floor(Math.Log10(dVmax)));
                dImax = Math.Floor(dImax / Ifact) * Ifact;
                dVmax = Math.Floor(dVmax / Vfact) * Vfact;

                VMLP.Items.Add("[-" + dVmax.ToString() + "(V)  ..  " + dVmax.ToString() + "(V)]");

                if (CBIVRange.SelectedIndex <= 0)
                {
                    IMLP.Items.Add("[-" + dImax.ToString() + "(A)  ..  " + dImax.ToString() + "(A)]");
                    if (AllSessions[Selected].IVImlp == mlp) IVMaxFineCurrentTemp = dImax;
                }
                else if (CBIVRange.SelectedIndex == 1)
                {
                    IMLP.Items.Add("[-" + dImax.ToString() + "(mA)  ..  " + dImax.ToString() + "(mA)]");
                    if (AllSessions[Selected].IVImlp == mlp) IVMaxFineCurrentTemp = dImax * 0.001;
                }
                else if (CBIVRange.SelectedIndex == 2)
                {
                    IMLP.Items.Add("[-" + dImax.ToString() + "(mA)  ..  " + dImax.ToString() + "(mA)]");
                    if (AllSessions[Selected].IVImlp == mlp) IVMaxFineCurrentTemp = dImax * 0.001;
                }
                else if (CBIVRange.SelectedIndex == 3)                                                          //Added in EISProject66
                {
                    IMLP.Items.Add("[-" + dImax.ToString() + "(mA)  ..  " + dImax.ToString() + "(mA)]");
                    if (AllSessions[Selected].IVImlp == mlp) IVMaxFineCurrentTemp = dImax * 0.001;
                }
                else if (CBIVRange.SelectedIndex == 4)                                                          //Added in EISProject71
                {
                    IMLP.Items.Add("[-" + dImax.ToString() + "(uA)  ..  " + dImax.ToString() + "(uA)]");
                    if (AllSessions[Selected].IVImlp == mlp) IVMaxFineCurrentTemp = dImax * 0.000001;
                }
                else if (CBIVRange.SelectedIndex == 5)                                                          //Added in EISProject71
                {
                    IMLP.Items.Add("[-" + dImax.ToString() + "(uA)  ..  " + dImax.ToString() + "(uA)]");
                    if (AllSessions[Selected].IVImlp == mlp) IVMaxFineCurrentTemp = dImax * 0.000001;
                }
                else if (CBIVRange.SelectedIndex == 6)                                                          //Added in EISProject71
                {
                    IMLP.Items.Add("[-" + dImax.ToString() + "(uA)  ..  " + dImax.ToString() + "(uA)]");
                    if (AllSessions[Selected].IVImlp == mlp) IVMaxFineCurrentTemp = dImax * 0.000001;
                }
                else if (CBIVRange.SelectedIndex == 7)                                                          //Added in EISProject71
                {
                    IMLP.Items.Add("[-" + dImax.ToString() + "(nA)  ..  " + dImax.ToString() + "(nA)]");
                    if (AllSessions[Selected].IVImlp == mlp) IVMaxFineCurrentTemp = dImax * 0.000000001;
                }

                if (AllSessions[Selected].Mode == 2 | AllSessions[Selected].Mode == 3) IVMaxFineCurrent = IVMaxFineCurrentTemp;
                pow2mlp = pow2mlp * 2;
            }

            VMLP.SelectedIndex = AllSessions[Selected].IVVmlp;
            IMLP.SelectedIndex = AllSessions[Selected].IVImlp;

            isVmlpCompleted = true;
            isImlpCompleted = true;



            isPulseVmlpCompleted = false;
            isPulseImlpCompleted = false;

            CBPulseVmlp.Items.Clear();
            CBPulseImlp.Items.Clear();

            double IVMaxFineCurrentTemp0 = 0;
            pow2mlp = 1;
            for (int mlp = 0; mlp < 7; mlp++)
            {
                double Vmax = Settings.GetDCV_Domain;
                double Imax = 0;

                if (CBPulseCurrentRangeMode.SelectedIndex == 0)
                    Imax = 1;
                else if (CBPulseCurrentRangeMode.SelectedIndex == 1)
                    Imax = 100;
                else if (CBPulseCurrentRangeMode.SelectedIndex == 2)
                    Imax = 10;
                else if (CBPulseCurrentRangeMode.SelectedIndex == 3)  //Added in EISProject66
                    Imax = 1;
                else if (CBPulseCurrentRangeMode.SelectedIndex == 4)  //Added in EISProject71
                    Imax = 100;
                else if (CBPulseCurrentRangeMode.SelectedIndex == 5)  //Added in EISProject71
                    Imax = 10;
                else if (CBPulseCurrentRangeMode.SelectedIndex == 6)  //Added in EISProject71
                    Imax = 1;
                else if (CBPulseCurrentRangeMode.SelectedIndex == 7)  //Added in EISProject71
                    Imax = 100;

                double dImax = 1.0 * Imax / pow2mlp;
                double dVmax = 1.0 * Vmax / pow2mlp;

                double Ifact = Math.Pow(10, Math.Floor(Math.Log10(dImax)));
                double Vfact = Math.Pow(10, Math.Floor(Math.Log10(dVmax)));
                dImax = Math.Floor(dImax / Ifact) * Ifact;
                dVmax = Math.Floor(dVmax / Vfact) * Vfact;

                CBPulseVmlp.Items.Add("[-" + dVmax.ToString() + "(V)  ..  " + dVmax.ToString() + "(V)]");

                if (CBPulseCurrentRangeMode.SelectedIndex <= 0)
                {
                    CBPulseImlp.Items.Add("[-" + dImax.ToString() + "(A)  ..  " + dImax.ToString() + "(A)]");
                    if (AllSessions[Selected].PulseImlpp == mlp) IVMaxFineCurrentTemp0 = dImax;
                }
                else if (CBPulseCurrentRangeMode.SelectedIndex == 1)
                {
                    CBPulseImlp.Items.Add("[-" + dImax.ToString() + "(mA)  ..  " + dImax.ToString() + "(mA)]");
                    if (AllSessions[Selected].PulseImlpp == mlp) IVMaxFineCurrentTemp0 = dImax * 0.001;
                }
                else if (CBPulseCurrentRangeMode.SelectedIndex == 2)
                {
                    CBPulseImlp.Items.Add("[-" + dImax.ToString() + "(mA)  ..  " + dImax.ToString() + "(mA)]");
                    if (AllSessions[Selected].PulseImlpp == mlp) IVMaxFineCurrentTemp0 = dImax * 0.001;
                }
                else if (CBPulseCurrentRangeMode.SelectedIndex == 3)                                                          //Added in EISProject66
                {
                    CBPulseImlp.Items.Add("[-" + dImax.ToString() + "(mA)  ..  " + dImax.ToString() + "(mA)]");
                    if (AllSessions[Selected].PulseImlpp == mlp) IVMaxFineCurrentTemp0 = dImax * 0.001;
                }
                else if (CBPulseCurrentRangeMode.SelectedIndex == 4)                                                          //Added in EISProject71
                {
                    CBPulseImlp.Items.Add("[-" + dImax.ToString() + "(uA)  ..  " + dImax.ToString() + "(uA)]");
                    if (AllSessions[Selected].PulseImlpp == mlp) IVMaxFineCurrentTemp0 = dImax * 0.000001;
                }
                else if (CBPulseCurrentRangeMode.SelectedIndex == 5)                                                          //Added in EISProject71
                {
                    CBPulseImlp.Items.Add("[-" + dImax.ToString() + "(uA)  ..  " + dImax.ToString() + "(uA)]");
                    if (AllSessions[Selected].PulseImlpp == mlp) IVMaxFineCurrentTemp0 = dImax * 0.000001;
                }
                else if (CBPulseCurrentRangeMode.SelectedIndex == 6)                                                          //Added in EISProject71
                {
                    CBPulseImlp.Items.Add("[-" + dImax.ToString() + "(uA)  ..  " + dImax.ToString() + "(uA)]");
                    if (AllSessions[Selected].PulseImlpp == mlp) IVMaxFineCurrentTemp0 = dImax * 0.000001;
                }
                else if (CBPulseCurrentRangeMode.SelectedIndex == 7)                                                          //Added in EISProject71
                {
                    CBPulseImlp.Items.Add("[-" + dImax.ToString() + "(nA)  ..  " + dImax.ToString() + "(nA)]");
                    if (AllSessions[Selected].PulseImlpp == mlp) IVMaxFineCurrentTemp0 = dImax * 0.000000001;
                }

                if (AllSessions[Selected].Mode == 4) PulseMaxFineCurrent = IVMaxFineCurrentTemp0;
                pow2mlp = pow2mlp * 2;
            }

            CBPulseVmlp.SelectedIndex = AllSessions[Selected].PulseVmlp;
            CBPulseImlp.SelectedIndex = AllSessions[Selected].PulseImlpp;

            isPulseVmlpCompleted = true;
            isPulseImlpCompleted = true;




            TBTimeStep.Text = AllSessions[Selected].IVTimestep.ToString();
            double vel = Math.Abs(AllSessions[Selected].IVvoltageTo - AllSessions[Selected].IVVoltageFrom) / AllSessions[Selected].IVVoltageNStepp / AllSessions[Selected].IVTimestep * 1000.0;
            TBIVVelosity.Text = vel.ToString();

            GBEIS.Enabled = false;
            GBPulse.Enabled = false;
            GBCV.Enabled = false;
            GBIV.Enabled = false;


            if (AllSessions[Selected].Mode == 0 || AllSessions[Selected].Mode == 1)
            {
                if (AllSessions[Selected].Mode == 0)
                {
                    GBEIS.Text = "EIS";
                    groupBox1.Text = "DC";
                    label3.Text = "DC Voltage:";
                    GBFrequency.Text = "AC Frequency";
                }
                else
                {
                    GBEIS.Text = "Mott Schotkey";
                    groupBox1.Text = "Mott Schotkey inputs";
                    label3.Text = "Frequency:";
                    GBFrequency.Text = "DC Voltage";
                }

                GBEIS.Enabled = true;

                Point p = GBPreprocessing.Location;
                Size s = GBPreprocessing.Size;

                p.Y = CBMode.Location.Y + CBMode.Size.Height + 15;
                s.Height = 263;
                GBPreprocessing.Location = p;
                GBPreprocessing.Size = s;

                p.Y = p.Y + s.Height + 10;
                s.Height = 547;
                GBEIS.Location = p;
                GBEIS.Size = s;

                p.Y = p.Y + s.Height + 10;
                s.Height = 20;
                GBPulse.Location = p;
                GBPulse.Size = s;

                p.Y = p.Y + s.Height + 10;
                s.Height = 20;
                GBIV.Location = p;
                GBIV.Size = s;

                p.Y = p.Y + s.Height + 10;
                s.Height = 213;
                GBPostprocessing.Location = p;
                GBPostprocessing.Size = s;
            }

            if (AllSessions[Selected].Mode == 4)
            {
                UpdatePulse();
                GBPulse.Enabled = true;

                Point p = GBPreprocessing.Location;
                Size s = GBPreprocessing.Size;

                p.Y = CBMode.Location.Y + CBMode.Size.Height + 15;
                s.Height = 263;
                GBPreprocessing.Location = p;
                GBPreprocessing.Size = s;

                p.Y = p.Y + s.Height + 10;
                s.Height = 20;
                GBEIS.Location = p;
                GBEIS.Size = s;

                p.Y = p.Y + s.Height + 10;
                s.Height = 420;
                GBPulse.Location = p;
                GBPulse.Size = s;

                p.Y = p.Y + s.Height + 10;
                s.Height = 20;
                GBIV.Location = p;
                GBIV.Size = s;

                p.Y = p.Y + s.Height + 10;
                s.Height = 213;
                GBPostprocessing.Location = p;
                GBPostprocessing.Size = s;
            }

            if (AllSessions[Selected].Mode == 2 || AllSessions[Selected].Mode == 3)
            {
                GBIV.Enabled = true;
                Point p = GBPreprocessing.Location;
                Size s = GBPreprocessing.Size;

                p.Y = CBMode.Location.Y + CBMode.Size.Height + 15;
                s.Height = 263;
                GBPreprocessing.Location = p;
                GBPreprocessing.Size = s;

                p.Y = p.Y + s.Height + 10;
                s.Height = 20;
                GBEIS.Location = p;
                GBEIS.Size = s;

                p.Y = p.Y + s.Height + 10;
                s.Height = 20;
                GBPulse.Location = p;
                GBPulse.Size = s;

                p.Y = p.Y + s.Height + 10;
                s.Height = 213;
                GBPostprocessing.Size = s;
                if (AllSessions[Selected].Mode == 3)
                    s.Height = 507;
                else if (AllSessions[Selected].Mode == 2)
                    s.Height = 319;
                if (AllSessions[Selected].isCVEnable) GBCV.Enabled = true;
                
                if (AllSessions[Selected].Mode == 3)
                {
                    btnChronoTiming.Visible = false;
                    ChBChronoFastMode.Visible = false;
                    GBIV.Text = "I-V and CV";
                    label22.Text = "Initial potential:";
                    label20.Text = "Final potential:";
                    Point p0 = label22.Location;
                    p0.X = 14;
                    label22.Location = p0;
                    p0 = label20.Location;
                    p0.X = 14;
                    label20.Location = p0;
                    TBIVVoltageStep.Enabled = true;
                    TBIVVoltageFrom.Enabled = true;
                    TBIVVoltageTo.Enabled = true;
                    TBIVVoltagedV.Enabled = true;
                    btnChronoTiming.Enabled = false;
                    if (AllSessions[Selected].PGmode == 3)
                    {
                        string unit = "";
                        if (AllSessions[Selected].IVCurrentRangeMode == 0)
                            unit = "(A)";
                        else if (AllSessions[Selected].IVCurrentRangeMode >= 1 && AllSessions[Selected].IVCurrentRangeMode <= 3)
                            unit = "(mA)";
                        else if (AllSessions[Selected].IVCurrentRangeMode >= 4 && AllSessions[Selected].IVCurrentRangeMode <= 6)
                            unit = "(uA)";
                        else if (AllSessions[Selected].IVCurrentRangeMode == 7)
                            unit = "(nA)";
                        MinUnitLabel.Text = unit;
                        MaxUnitLabel.Text = unit;
                        StepUnitLabel.Text = unit;

                        if (AllSessions[Selected].IVCurrentRangeMode != 0)
                            label41.Text = "(10^-" + AllSessions[Selected].IVCurrentRangeMode.ToString() + " A/s)";
                        else
                            label41.Text = "(A/s)";
                    }
                    else
                    {
                        MinUnitLabel.Text = "(volt)";
                        MaxUnitLabel.Text = "(volt)";
                        StepUnitLabel.Text = "(volt)";
                        label41.Text = "(V/s)";
                    }
                }
                else if (AllSessions[Selected].Mode == 2)
                {
                    GBIV.Text = "Chronoamperometry";
                    label20.Text = "End time:";
                    if (AllSessions[Selected].PGmode == 3)
                    {
                        string unit = "";
                        if (AllSessions[Selected].IVCurrentRangeMode == 0)
                            unit = "(A)";
                        else if (AllSessions[Selected].IVCurrentRangeMode >= 1 && AllSessions[Selected].IVCurrentRangeMode <= 3)
                            unit = "(mA)";
                        else if (AllSessions[Selected].IVCurrentRangeMode >= 4 && AllSessions[Selected].IVCurrentRangeMode <= 6)
                            unit = "(uA)";
                        else if (AllSessions[Selected].IVCurrentRangeMode == 7)
                            unit = "(nA)";
                        MinUnitLabel.Text = unit;
                        MaxUnitLabel.Text = "(sec)";
                        StepUnitLabel.Text = "(sec)";
                        label22.Text = "Current:";
                    }
                    else
                    {
                        MinUnitLabel.Text = "(volt)";
                        MaxUnitLabel.Text = "(sec)";
                        StepUnitLabel.Text = "(sec)";
                        label22.Text = "Voltage:";
                    }

                    Point p0 = label22.Location;
                    p0.X = 34;
                    label22.Location = p0;
                    p0 = label20.Location;
                    p0.X = 34;
                    label20.Location = p0;

                    ChBChronoFastMode.Visible = true;
                    ChBChronoFastMode.Checked = AllSessions[Selected].Chrono_isfast;
                    if (AllSessions[Selected].Chrono_isfast && AllSessions[Selected].IVVoltageNStepp > 512)
                    {
                        AllSessions[Selected].IVVoltageNStepp = 512;
                        TBIVVelosity_Validated(null, null);
                        TBIVVoltageStep.Text = AllSessions[Selected].IVVoltageNStepp.ToString();
                    }

                    btnChronoTiming.Visible = true;
                    if (AllSessions[Selected].Chrono_isfast)
                    {
                        TBIVVoltageStep.Enabled = true;
                        TBIVVoltageFrom.Enabled = true;
                        TBIVVoltageTo.Enabled = true;
                        TBIVVoltagedV.Enabled = true;
                        btnChronoTiming.Enabled = false;
                    }
                    else
                    {
                        TBIVVoltageStep.Enabled = false;
                        TBIVVoltageFrom.Enabled = false;
                        TBIVVoltageTo.Enabled = false;
                        TBIVVoltagedV.Enabled = false;
                        btnChronoTiming.Enabled = true;
                    }
                }


                GBIV.Location = p;
                GBIV.Size = s;

                p.Y = p.Y + s.Height + 10;
                s.Height = 213;
                GBPostprocessing.Location = p;
                GBPostprocessing.Size = s;
            }

            if (AllSessions[Selected].Mode == 1) GBPulse.Enabled = true;
            //if (AllSessions[Selected].Mode == 2) GBCV.Enabled = true;
            if (AllSessions[Selected].Mode == 2 || AllSessions[Selected].Mode == 3) GBIV.Enabled = true;

            ChBExport.Checked = AllSessions[Selected].isExportAtFinal;
            maskedTextBox1.Text = AllSessions[Selected].ExportAtFinalDIR;
            if (ChBExport.Checked)
            {
                maskedTextBox1.Enabled = true;
                BtnSsnExpLocation.Enabled = true;
                if (maskedTextBox1.Text == "")
                    ExpWarningLable.Visible = true;
                else
                    ExpWarningLable.Visible = false;
            }
            else
            {
                maskedTextBox1.Enabled = false;
                BtnSsnExpLocation.Enabled = false;
                ExpWarningLable.Visible = false;
            }

            double max = AllSessions[Selected].IVvoltageTo;
            double min = AllSessions[Selected].IVVoltageFrom;
            if (AllSessions[Selected].Mode == 2)
            {
                min = 0;
                max = AllSessions[Selected].ChronoEndTime;
            }
            double dV = (double)((max - min) / (AllSessions[Selected].IVVoltageNStepp - 1));
            this.TBIVVoltagedV.Validated -= new System.EventHandler(this.TBIVVoltagedV_Validated);
            TBIVVoltagedV.Text = dV.ToString("0.00000000");
            this.TBIVVoltagedV.Validated += new System.EventHandler(this.TBIVVoltagedV_Validated);


            if (EIS.nSsn >= 0) PanelProperties.Visible = true;
        }

        private void BtnCreateSession_Click(object sender, EventArgs e)
        {
            int theFirstOpenMode = -1;
            if (theFirstOpenMode == -1 && Settings.isEIS) theFirstOpenMode = 0;
            if (theFirstOpenMode == -1 && Settings.isMSH) theFirstOpenMode = 1;
            if (theFirstOpenMode == -1 && Settings.isChrono) theFirstOpenMode = 2;
            if (theFirstOpenMode == -1 && (Settings.isIV0 || Settings.isCV)) theFirstOpenMode = 3;
            if (theFirstOpenMode == -1 && Settings.isPulse) theFirstOpenMode = 4;

            if (theFirstOpenMode != -1)
            {
                int ns = EIS.nSsn + 1;
                DeSelectAll();
                Sessions NewSession = new Sessions();
                NewSession.active = true;
                NewSession.V_OCT = FactoryDefault.V_OCT;
                NewSession.IdealVoltage = FactoryDefault.IdealVoltage;
                NewSession.isOCP = FactoryDefault.isOCP;
                NewSession.isOCPAutoStart = FactoryDefault.isOCPAutoStart;
                NewSession.PGmode = FactoryDefault.PGmode;
                NewSession.RelRef = FactoryDefault.RelRef;
                NewSession.EqTime = FactoryDefault.EqTime;

                NewSession.EISDCCurrentRangeModea = FactoryDefault.EISDCCurrentRangeModea;
                NewSession.EISACRegulatorMode = FactoryDefault.EISACRegulatorMode;
                NewSession.EISACCurrentRangeMode = FactoryDefault.EISACCurrentRangeMode;
                NewSession.EISVmlpMax = FactoryDefault.EISVmlpMax;
                NewSession.EISImlpMax = FactoryDefault.EISImlpMax;
                NewSession.EISfilterMode = FactoryDefault.EISfilterMode;
                NewSession.EISAverageNumberL = FactoryDefault.EISAverageNumberL;
                NewSession.EISAverageNumberH = FactoryDefault.EISAverageNumberH;
                NewSession.Mode = theFirstOpenMode;
                NewSession.EISMode = FactoryDefault.EISMode;
                NewSession.EISOCMode = FactoryDefault.EISOCMode;
                NewSession.EISVoltageRangeMode = FactoryDefault.EISVoltageRangeMode;
                NewSession.IVVoltageRangeMode = FactoryDefault.IVVoltageRangeMode;
                NewSession.IVChrono_VFilter = FactoryDefault.IVChrono_VFilter;
                NewSession.Pulse_VFilter = FactoryDefault.Pulse_VFilter;


                NewSession.PulseVoltageRangeMode = FactoryDefault.PulseVoltageRangeMode;
                NewSession.PulseCurrentRangeMode = FactoryDefault.PulseCurrentRangeMode;
                NewSession.PulseVmlp = FactoryDefault.PulseVmlp;
                NewSession.PulseImlpp = FactoryDefault.PulseImlpp;
                NewSession.PulseReadingEdgemode = FactoryDefault.PulseReadingEdgemode;
                NewSession.PulseVoltammetryMode = FactoryDefault.PulseVoltammetryMode;

                NewSession.DCVoltageConstant = FactoryDefault.DCVoltageConstant;
                NewSession.DCVoltageFrom = FactoryDefault.DCVoltageFrom;
                NewSession.DCVoltageTo = FactoryDefault.DCVoltageTo;
                NewSession.DCVoltageStep = FactoryDefault.DCVoltageStep;

                NewSession.ACAmpConstant = FactoryDefault.ACAmpConstant;
                NewSession.ACAmpFrom = FactoryDefault.ACAmpFrom;
                NewSession.ACAmpTo = FactoryDefault.ACAmpTo;
                NewSession.ACAmpStep = FactoryDefault.ACAmpStep;

                NewSession.ACFrqConstant = FactoryDefault.ACFrqConstant;
                NewSession.ACFrqFrom = FactoryDefault.ACFrqFrom;
                NewSession.ACFrqTo = FactoryDefault.ACFrqTo;
                NewSession.ACFrqNStep = FactoryDefault.ACFrqNStep;

                NewSession.IVVoltageFrom = FactoryDefault.IVVoltageFrom;
                NewSession.IVvoltageTo = FactoryDefault.IVvoltageTo;
                NewSession.ChronoEndTime = FactoryDefault.ChronoEndTime;
                NewSession.IVVoltageNStepp = FactoryDefault.IVVoltageNStepp;
                NewSession.CVStartpoint = FactoryDefault.CVStartpoint;

                NewSession.PretreatmentVoltage = FactoryDefault.PretreatmentVoltage;
                NewSession.isPreProcProbOn = FactoryDefault.isPreProcProbOn;
                NewSession.isChBPostProcProbOff = FactoryDefault.isChBPostProcProbOff;

                NewSession.CVItteration = FactoryDefault.CVItteration;
                NewSession.IVCurrentRangeMode = FactoryDefault.IVCurrentRangeMode;
                NewSession.IVVmlp = FactoryDefault.IVVmlp;
                NewSession.IVImlp = FactoryDefault.IVImlp;
                NewSession.IVTimestep = FactoryDefault.IVTimestep;

                NewSession.Chrono_n = FactoryDefault.Chrono_n;
                NewSession.Chrono_Total_Period = FactoryDefault.Chrono_Total_Period;
                NewSession.Chrono_Pulse_Period = FactoryDefault.Chrono_Pulse_Period;
                NewSession.Chrono_Pulse_Level = FactoryDefault.Chrono_Pulse_Level;
                NewSession.Chrono_Pulse_Amplitude = FactoryDefault.Chrono_Pulse_Amplitude;
                NewSession.Chrono_Level_Step = FactoryDefault.Chrono_Level_Step;
                NewSession.Chrono_Amplitude_step = FactoryDefault.Chrono_Amplitude_step;
                NewSession.Chrono_isfast = FactoryDefault.Chrono_isfast;

                NewSession.Chrono_nsteps = FactoryDefault.Chrono_nsteps;

                NewSession.Chrono_t1 = FactoryDefault.Chrono_t1;
                NewSession.Chrono_t2 = FactoryDefault.Chrono_t2;
                NewSession.Chrono_t3 = FactoryDefault.Chrono_t3;
                NewSession.Chrono_t4 = FactoryDefault.Chrono_t4;
                NewSession.Chrono_t5 = FactoryDefault.Chrono_t5;
                NewSession.Chrono_t6 = FactoryDefault.Chrono_t6;
                NewSession.Chrono_t7 = FactoryDefault.Chrono_t7;
                NewSession.Chrono_t8 = FactoryDefault.Chrono_t8;
                NewSession.Chrono_t9 = FactoryDefault.Chrono_t9;
                NewSession.Chrono_t10 = FactoryDefault.Chrono_t10;

                NewSession.Chrono_v1 = FactoryDefault.Chrono_v1;
                NewSession.Chrono_v2 = FactoryDefault.Chrono_v2;
                NewSession.Chrono_v3 = FactoryDefault.Chrono_v3;
                NewSession.Chrono_v4 = FactoryDefault.Chrono_v4;
                NewSession.Chrono_v5 = FactoryDefault.Chrono_v5;
                NewSession.Chrono_v6 = FactoryDefault.Chrono_v6;
                NewSession.Chrono_v7 = FactoryDefault.Chrono_v7;
                NewSession.Chrono_v8 = FactoryDefault.Chrono_v8;
                NewSession.Chrono_v9 = FactoryDefault.Chrono_v9;
                NewSession.Chrono_v10 = FactoryDefault.Chrono_v10;

                NewSession.Chrono_dt = FactoryDefault.Chrono_dt;

                NewSession.Chrono_ocp1 = FactoryDefault.Chrono_ocp1;
                NewSession.Chrono_ocp2 = FactoryDefault.Chrono_ocp2;
                NewSession.Chrono_ocp3 = FactoryDefault.Chrono_ocp3;
                NewSession.Chrono_ocp4 = FactoryDefault.Chrono_ocp4;
                NewSession.Chrono_ocp5 = FactoryDefault.Chrono_ocp5;
                NewSession.Chrono_ocp6 = FactoryDefault.Chrono_ocp6;
                NewSession.Chrono_ocp7 = FactoryDefault.Chrono_ocp7;
                NewSession.Chrono_ocp8 = FactoryDefault.Chrono_ocp8;
                NewSession.Chrono_ocp9 = FactoryDefault.Chrono_ocp9;
                NewSession.Chrono_ocp10 = FactoryDefault.Chrono_ocp10;

                NewSession.name = "Session " + ns.ToString();
                NewSession.index = EIS.nSsn;
                AllSessions.Add(NewSession);

                RichTextBox NewSessionGUI = new RichTextBox();
                NewSessionGUI.Location = new Point(0, EIS.nSsn * 37);
                NewSessionGUI.Size = new Size(1000, 35);
                NewSessionGUI.BorderStyle = BorderStyle.Fixed3D;
                AllSessionsGUI.Add(NewSessionGUI);
                AllSessionsGUI[EIS.nSsn].Parent = Desktop;
                AllSessionsGUI[EIS.nSsn].Show();
                AllSessionsGUI[EIS.nSsn].MouseDown += new System.Windows.Forms.MouseEventHandler(this.SessionsGUI_MouseDown);
                AllSessionsGUI[EIS.nSsn].BackColor = SelectedColor;
                AllSessionsGUI[EIS.nSsn].ReadOnly = true;
                AllSessionsGUI[EIS.nSsn].Cursor = Cursor.Current;
                AllSessionsGUI[EIS.nSsn].Text = "Session Name: " + NewSession.name + " " + NewSession.DataAndTime;

                Selected = EIS.nSsn;
                FormDiagram.SessionName.Items.Add(AllSessions[Selected].name);
                FormFit.SessionName.Items.Add(AllSessions[Selected].name);
                FormDG.SessionName.Items.Add(AllSessions[Selected].name);
                LoadSelectedProperties();

                SessionOutputData EmptyData = new SessionOutputData();
                AllSessionsData.Add(EmptyData);
                //FormFit.SFits=new FormFit.
                EIS.nSsn++;
            }
            else
            {
                MessageBox.Show("Features are not installed to create new session.\nYou should ask administrator to add features to application.");
            }
        }

        private void BtnAbout_Click(object sender, EventArgs e)
        {
            AboutBox AB = new AboutBox();
            AB.ShowDialog();
        }

        private void TBSsnName_TextChanged(object sender, EventArgs e)
        {
            string NewName = TBSsnName.Text;
            AllSessionsGUI[Selected].Text = "Session Name: " + NewName + " " + AllSessions[Selected].DataAndTime;
            AllSessions[Selected].name = NewName;
            FormFit.SessionName.Items[Selected] = NewName;
            FormDiagram.SessionName.Items[Selected] = NewName;
            FormDG.SessionName.Items[Selected] = NewName;
        }

        private void ChBActive_CheckedChanged(object sender, EventArgs e)
        {
            AllSessions[Selected].active = ChBActive.Checked;
            if (ChBActive.Checked)
            {
                AllSessionsGUI[Selected].ForeColor = Color.Black;
                CBMode.Enabled = true;
                GBEIS.Enabled = true;
                GBPulse.Enabled = true;
                GBCV.Enabled = true;
                GBIV.Enabled = true;
                GBExport.Enabled = true;
            }
            else
            {
                AllSessionsGUI[Selected].ForeColor = Color.Red;
                CBMode.Enabled = false;
                GBEIS.Enabled = false;
                GBPulse.Enabled = false;
                GBCV.Enabled = false;
                GBIV.Enabled = false;
                GBExport.Enabled = false;
            }

            checkmethods();
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

        private void DigitTextChangeWithFactor(ref double digit, TextBox tb, double min, double max, double Factor)
        {
            try
            {
                digit = Convert.ToDouble(tb.Text) / Factor;
                if (digit < min) digit = min;
                if (digit > max) digit = max;
            }
            catch
            {
                tb.Text = (digit * Factor).ToString();
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

        private void TBDCVoltageConstant_TextChanged(object sender, EventArgs e)
        {
            if (AllSessions[Selected].Mode == 0)
                DigitTextChange(ref AllSessions[Selected].DCVoltageConstant, TBDCVoltageConstant, -5, 5);
            else
                DigitTextChange(ref AllSessions[Selected].ACFrqConstant, TBDCVoltageConstant, Settings.SetDigitalf_Min, Settings.SetDigitalf_Max);

            //TBCVDCVltCnst.Text = TBDCVoltageConstant.Text;
        }

        private void TBACAmpConstant_TextChanged(object sender, EventArgs e)
        {
            DigitTextChangeWithFactor(ref AllSessions[Selected].ACAmpConstant, TBACAmpConstant, 0, 2, 1000);
            //TBMSCHACAmpCnst.Text = TBACAmpConstant.Text;
        }

        private void TBACFrqFrom_TextChanged(object sender, EventArgs e)
        {
            if (AllSessions[Selected].Mode == 0)
                DigitTextChange(ref AllSessions[Selected].ACFrqFrom, TBACFrqFrom, Settings.SetDigitalf_Min, Settings.SetDigitalf_Max);
            else
                DigitTextChange(ref AllSessions[Selected].DCVoltageFrom, TBACFrqFrom, -5, 5);
        }

        private void TBACFrqTo_TextChanged(object sender, EventArgs e)
        {
            if (AllSessions[Selected].Mode == 0)
                DigitTextChange(ref AllSessions[Selected].ACFrqTo, TBACFrqTo, Settings.SetDigitalf_Min, Settings.SetDigitalf_Max);
            else
                DigitTextChange(ref AllSessions[Selected].DCVoltageTo, TBACFrqTo, -5, 5);
        }

        private void TBACFrqStep_TextChanged(object sender, EventArgs e)
        {
            if (AllSessions[Selected].Mode == 0)
                IntDigitTextChange(ref AllSessions[Selected].ACFrqNStep, TBACFrqNStep, 2, 2000);
            else
                IntDigitTextChange(ref AllSessions[Selected].DCVoltageStep, TBACFrqNStep, 2, 2000);
        }

        private void TBMSCHACAmpCnst_TextChanged(object sender, EventArgs e)
        {
            DigitTextChange(ref AllSessions[Selected].ACAmpConstant, TBMSCHACAmpCnst, 0, 1);
            TBACAmpConstant.Text = TBMSCHACAmpCnst.Text;
        }

        private void TBMSCHACFrqCnst_TextChanged(object sender, EventArgs e)
        {
            DigitTextChange(ref AllSessions[Selected].ACFrqConstant, TBMSCHACFrqCnst, Settings.SetDigitalf_Min, Settings.SetDigitalf_Max);
            TBCVACFrqCnst.Text = TBMSCHACFrqCnst.Text;
        }

        private void TBMSCHDCVFrm_TextChanged(object sender, EventArgs e)
        {
            DigitTextChange(ref AllSessions[Selected].DCVoltageFrom, TBMSCHDCVFrm, -2, 2);
        }

        private void TBMSCHDCVTo_TextChanged(object sender, EventArgs e)
        {
            DigitTextChange(ref AllSessions[Selected].DCVoltageTo, TBMSCHDCVTo, -2, 2);
        }

        private void TBMSCHDCVStp_TextChanged(object sender, EventArgs e)
        {
            IntDigitTextChange(ref AllSessions[Selected].DCVoltageStep, TBMSCHDCVStp, 2, 1000);
        }

        private void TBCVDCVltCnst_TextChanged(object sender, EventArgs e)
        {
            DigitTextChange(ref AllSessions[Selected].DCVoltageConstant, TBCVDCVltCnst, -2, 2);
            TBDCVoltageConstant.Text = TBCVDCVltCnst.Text;

        }

        private void TBCVACFrqCnst_TextChanged(object sender, EventArgs e)
        {
            DigitTextChange(ref AllSessions[Selected].ACFrqConstant, TBCVACFrqCnst, Settings.SetDigitalf_Min, Settings.SetDigitalf_Max);
            TBMSCHACFrqCnst.Text = TBCVACFrqCnst.Text;
        }

        private void TBCVACAmpFrm_TextChanged(object sender, EventArgs e)
        {
            DigitTextChange(ref AllSessions[Selected].ACAmpFrom, TBCVACAmpFrm, 0, 2);
        }

        private void TBCVACAmpTo_TextChanged(object sender, EventArgs e)
        {
            DigitTextChange(ref AllSessions[Selected].ACAmpTo, TBCVACAmpTo, 0, 2);
        }

        private void TBCVACAmpStp_TextChanged(object sender, EventArgs e)
        {
            DigitTextChange(ref AllSessions[Selected].ACAmpStep, TBCVACAmpStp, 2, 1000);
        }

        private void StopRun()
        {
            Port.DiscardOutBuffer();
            Port.DiscardInBuffer();
            Port.Write(";");
            //OCTTimer.Stop();
            PreproccessingTimer.Stop();
            ProbWarningLabel.Visible = false;
            Port.DiscardOutBuffer(); //Clear Buffer
            Port.DiscardInBuffer(); //Clear Buffer
            isRunPause = false;
            DisableBtnPauseContinue("Pause");
            isRunStart = false;
            RestartBtnRun("Start all");
            ActiveBtnCreateSession("");
            PBAllSessionsValue = 1;
            SetPBAllSessions(PBAllSessionsValue);

            Thread.Sleep(100);
            Port.DiscardOutBuffer();
            Port.DiscardInBuffer();
            Port.Write(";");

            if (isIVTimerTickSet)
            {
                IVTimer1.Stop();
                IVTimer1.Dispose();
                isIVTimerTickSet = false;
            }

            if (isPulseTimerTickSet)
            {
                PulseTimer1.Stop();
                PulseTimer1.Dispose();
                isPulseTimerTickSet = false;
            }

            if (isDataReceivedSet)
            {
                Port.DataReceived -= new System.IO.Ports.SerialDataReceivedEventHandler(this.EISPort_DataReceived);
                isDataReceivedSet = false;
            }

            if (isAnalogEISTimerTickSet)
            {
                AnalogEISTimer.Stop();
                AnalogEISTimer.Dispose();
                isAnalogEISTimerTickSet = false;
            }

            if (isDigitalEISTimerTickSet)
            {
                DigitalEISTimer.Stop();
                DigitalEISTimer.Dispose();
                isDigitalEISTimerTickSet = false;
            }
            //IVTimer1.Enabled = false;
            if (!isProbOn && !isDummyOn)
            {
                SampleOnBtn.Enabled = true;
                DummyOnBtn.Enabled = true;
            }
            else
            {
                if (isProbOn) SampleOnBtn.Enabled = true;
                if (isDummyOn) DummyOnBtn.Enabled = true;
            }

            Thread.Sleep(100);
            Port.DiscardOutBuffer();
            Port.DiscardInBuffer();
            Port.Write(";");


            SetStatus("Run is stoped.");
        }

        private void BtnRun_Click(object sender, EventArgs e)
        {
            loadSetting(ref Settings);
            bool isAnyFinished = false;
            for (int j = 0; j < EIS.nSsn; j++)
            {
                if (AllSessions[j].active && AllSessions[j].isFinished == true)
                {
                    isAnyFinished = true;
                    break;
                }
            }

            if (isAnyFinished && !isRunStart)
            {
                FormRunWarning FormRunWarn = new FormRunWarning();
                for (int j = 0; j < EIS.nSsn; j++)
                {
                    if (AllSessions[j].active && AllSessions[j].isFinished == true)
                    {
                        FormRunWarn.listBox1.Items.Add(AllSessions[j].name);
                    }
                }
                FormRunWarn.ShowDialog();
                FormRunWarn.Dispose();

                if (!isRunCanseled)
                {
                    StartRunning();
                }
            }
            else
            {
                StartRunning();
            }
        }

        private void StartRunning()
        {
            if (isRunStart)
            {
                StopRun();
            }
            else
            {
                GoToNext = true;
                if (EIS.Connected)
                {
                    if (EIS.nSsn == 0)
                        MessageBox.Show("There is no session to run! Create new session by following path ...\n\nTools->New Session");
                    else
                    {
                        Port.DiscardOutBuffer(); //Clear Buffer
                        Port.DiscardInBuffer(); //Clear Buffer
                        //AllSessionsData.Clear();
                        SessionsDim = new int[EIS.nSsn];
                        nPBAllSessions = 0;
                        for (int j = 0; j < EIS.nSsn; j++)
                        {
                            if (AllSessions[j].active)
                            {
                                AllSessions[j].isStarted = false;
                                AllSessions[j].isFinished = false;
                                SessionsDim[j] = Dim(AllSessions[j]);
                                nPBAllSessions = nPBAllSessions + SessionsDim[j];
                            }
                        }

                        PBAllSessionsValue = 0;
                        PBAllSessions.Minimum = 1;
                        PBAllSessions.Maximum = nPBAllSessions;

                        //////////////////////////////////////////////////////////////////////
                        //Finding the first Active Session
                        int i;
                        for (i = 0; i < EIS.nSsn; i++)
                        {
                            if (AllSessions[i].active && EIS.ready)
                            {
                                EIS.RunningSession = i;
                                AllSessions[EIS.RunningSession].isStarted = true;
                                RunSession(AllSessions[i]);
                                break;
                            }
                        }
                        //////////////////////////////////////////////////////////////////////

                        EIS.RunCompleted = false;
                        if (i == EIS.nSsn)
                            MessageBox.Show("There is no active session to run!!!\nSelect a session and check Active checkbox in properties.");

                    }
                }
                else
                {
                    MessageBox.Show("Application is not connected to any device. Go to following path and check connections and ports ...\n\nMeasurement->Connect");
                }
            }
        }

        private void SetLabel(ref Label l, int n)
        {
            l.Text = n.ToString();
            l.Refresh();
        }

        private void SetLabel(ref Label l, double n, string Unit)
        {
            double m = Math.Abs(n);
            if (m >= 1000000000.0)
                l.Text = (n / 1000000000.0).ToString("0.000") + " G" + Unit;
            else if (m < 1000000000.0 && m >= 1000000.0)
                l.Text = (n / 1000000.0).ToString("0.000") + " M" + Unit;
            else if (m < 1000000.0 && m >= 1000.0)
                l.Text = (n / 1000.0).ToString("0.000") + " K" + Unit;
            else if (m < 1000.0 && m >= 1.0)
                l.Text = (n).ToString("0.000") + " " + Unit;
            else if (m < 1.0 && m >= 0.0001)
                l.Text = (1000.0 * n).ToString("0.000") + " m" + Unit;
            else if (m < 0.0001)
                l.Text = (1000000.0 * n).ToString("0.000") + " u" + Unit;
            l.Refresh();
        }

        private void SetLabelJustForVoltage(ref Label l, double n, string Unit)
        {
            double m = Math.Abs(n);
            l.Text = n.ToString("0.000") + " " + Unit;
            l.Refresh();
        }

        private void SetLabel(ref Label l, bool n)
        {
            l.Text = n.ToString();
            l.Refresh();
        }

        private int Dim(Sessions S)
        {
            int Dimention = 0;
            if (S.Mode == 0)
                Dimention = S.ACFrqNStep;
            if (S.Mode == 1)
                Dimention = S.DCVoltageStep;
            if (S.Mode == 2)
            {
                if (S.Chrono_isfast)
                {
                    Dimention = S.IVVoltageNStepp;
                }
                else
                {
                    double[] t = new double[10];
                    double[] dt = new double[10];
                    int[] n = new int[10];
                    int[] ntot = new int[10];
                    for (int i = 1; i <= 10; i++)
                    {
                        if (i == 1) t[i - 1] = S.Chrono_t1;
                        else if (i == 2) t[i - 1] = S.Chrono_t2;
                        else if (i == 3) t[i - 1] = S.Chrono_t3;
                        else if (i == 4) t[i - 1] = S.Chrono_t4;
                        else if (i == 5) t[i - 1] = S.Chrono_t5;
                        else if (i == 6) t[i - 1] = S.Chrono_t6;
                        else if (i == 7) t[i - 1] = S.Chrono_t7;
                        else if (i == 8) t[i - 1] = S.Chrono_t8;
                        else if (i == 9) t[i - 1] = S.Chrono_t9;
                        else if (i == 10) t[i - 1] = S.Chrono_t10;

                        dt[i - 1] = S.Chrono_dt / 1000.0;
                        
                        n[i - 1] = (int)(t[i - 1] / dt[i - 1]) + 1;
                        ntot[i - 1] = 0;
                        for (int j = 0; j < i; j++) ntot[i - 1] = ntot[i - 1] + n[j];
                    }

                    Dimention = ntot[S.Chrono_nsteps - 1];
                }
            }

            if (S.Mode == 3)
            {
                if (S.isCVEnable)
                {
                    int CVnFirst = (int)((S.IVvoltageTo - S.CVStartpoint) / (S.IVvoltageTo - S.IVVoltageFrom) * (S.IVVoltageNStepp - 1));
                    Dimention = S.IVVoltageNStepp * (S.CVItteration * 2 - 1) + CVnFirst;
                }
                else
                    Dimention = S.IVVoltageNStepp;
            }

            if (S.Mode == 4)
            {
                //if (S.PulseReadingEdgeMode == 2)
                //    Dimention = S.Chrono_n - 1;
                //else
                Dimention = S.Chrono_n;
            }


            return Dimention;
        }

        private void RunSession(Sessions S)
        {
            try
            {
                //if (isOCTCompleted || !AllSessions[EIS.RunningSession].OCT)
                //{isOCTCompleted = false;
                if (isPreProccessingCompleted)
                {
                    //isOCTContinueRequested = false;
                    isPreProccessingCompleted = false;
                    SampleOnBtn.Enabled = false;
                    DummyOnBtn.Enabled = false;
                    DebugListBox.Items.Clear();
                    ProbWarningLabel.Visible = false;
                    SetStatus("Session: " + S.name + " is running ...");
                    S.DataAndTime = "Date: " + string.Format("{0:dd/MM/yyyy}", DateTime.Today) + "  Time: " + string.Format("{0:HH:mm:ss tt}", DateTime.Now);
                    AllSessionsGUI[EIS.RunningSession].Text = "Session Name: " + S.name + " " + S.DataAndTime;
                    //isIVRangesChanged = true;

                    resetdevice();
                    AllSessionsData[EIS.RunningSession].OpenCircuitVoltage = 0;
                    if (AllSessions[EIS.RunningSession].Mode == 0)
                    {
                        int FrqCnt = AllSessions[EIS.RunningSession].ACFrqNStep;
                        AllSessionsData[EIS.RunningSession].ACFrqDim = FrqCnt;
                        AllSessionsData[EIS.RunningSession].Frq = new double[FrqCnt];
                        AllSessionsData[EIS.RunningSession].ReZ = new double[FrqCnt];
                        AllSessionsData[EIS.RunningSession].Imz = new double[FrqCnt];
                        AllSessionsData[EIS.RunningSession].overflow = new bool[FrqCnt];
                    }

                    if (AllSessions[EIS.RunningSession].Mode == 1)
                    {
                        int VltCnt = AllSessions[EIS.RunningSession].DCVoltageStep;
                        //for (double v = AllSessions[EIS.RunningSession].DCVoltageFrom; v < AllSessions[EIS.RunningSession].DCVoltageTo; v = v + AllSessions[EIS.RunningSession].DCVoltageStep) VltCnt++;
                        AllSessionsData[EIS.RunningSession].DCVltDim = VltCnt;
                        AllSessionsData[EIS.RunningSession].Vlt = new double[VltCnt];
                        AllSessionsData[EIS.RunningSession].Amp = new double[VltCnt];
                        AllSessionsData[EIS.RunningSession].ReZ = new double[VltCnt];
                        AllSessionsData[EIS.RunningSession].Imz = new double[VltCnt];
                        AllSessionsData[EIS.RunningSession].overflow = new bool[VltCnt];
                    }


                    if (AllSessions[EIS.RunningSession].Mode == 2)
                    {
                        if (AllSessions[EIS.RunningSession].Chrono_isfast)
                        {
                            int VltCnt = AllSessions[EIS.RunningSession].IVVoltageNStepp;
                            AllSessionsData[EIS.RunningSession].IVAmpDim = VltCnt;
                            AllSessionsData[EIS.RunningSession].Vlt = new double[VltCnt];
                            AllSessionsData[EIS.RunningSession].Amp = new double[VltCnt];
                            AllSessionsData[EIS.RunningSession].ReZ = new double[VltCnt];
                            AllSessionsData[EIS.RunningSession].Imz = new double[VltCnt];
                        }
                        else
                        {
                            int ntotal = 0;
                            for (int i = 1; i <= AllSessions[EIS.RunningSession].Chrono_nsteps; i++)
                            {
                                double t = 0;
                                double v = 0;
                                double dt = 0;

                                if (i == 1) t = AllSessions[EIS.RunningSession].Chrono_t1;
                                else if (i == 2) t = AllSessions[EIS.RunningSession].Chrono_t2;
                                else if (i == 3) t = AllSessions[EIS.RunningSession].Chrono_t3;
                                else if (i == 4) t = AllSessions[EIS.RunningSession].Chrono_t4;
                                else if (i == 5) t = AllSessions[EIS.RunningSession].Chrono_t5;
                                else if (i == 6) t = AllSessions[EIS.RunningSession].Chrono_t6;
                                else if (i == 7) t = AllSessions[EIS.RunningSession].Chrono_t7;
                                else if (i == 8) t = AllSessions[EIS.RunningSession].Chrono_t8;
                                else if (i == 9) t = AllSessions[EIS.RunningSession].Chrono_t9;
                                else if (i == 10) t = AllSessions[EIS.RunningSession].Chrono_t10;

                                if (i == 1) v = AllSessions[EIS.RunningSession].Chrono_v1;
                                else if (i == 2) v = AllSessions[EIS.RunningSession].Chrono_v2;
                                else if (i == 3) v = AllSessions[EIS.RunningSession].Chrono_v3;
                                else if (i == 4) v = AllSessions[EIS.RunningSession].Chrono_v4;
                                else if (i == 5) v = AllSessions[EIS.RunningSession].Chrono_v5;
                                else if (i == 6) v = AllSessions[EIS.RunningSession].Chrono_v6;
                                else if (i == 7) v = AllSessions[EIS.RunningSession].Chrono_v7;
                                else if (i == 8) v = AllSessions[EIS.RunningSession].Chrono_v8;
                                else if (i == 9) v = AllSessions[EIS.RunningSession].Chrono_v9;
                                else if (i == 10) v = AllSessions[EIS.RunningSession].Chrono_v10;

                                dt = AllSessions[EIS.RunningSession].Chrono_dt / 1000.0;
                                
                                ntotal = ntotal + (int)(t / dt) + 1;
                            }

                            int VltCnt = ntotal;
                            AllSessionsData[EIS.RunningSession].IVAmpDim = VltCnt;
                            AllSessionsData[EIS.RunningSession].Vlt = new double[VltCnt];
                            AllSessionsData[EIS.RunningSession].Amp = new double[VltCnt];
                            AllSessionsData[EIS.RunningSession].ReZ = new double[VltCnt];
                            AllSessionsData[EIS.RunningSession].Imz = new double[VltCnt];
                        }
                    }

                    if (AllSessions[EIS.RunningSession].Mode == 3)
                    {
                        if (AllSessions[EIS.RunningSession].isCVEnable)
                        {
                            int CVnFirst = (int)((AllSessions[EIS.RunningSession].IVvoltageTo - AllSessions[EIS.RunningSession].CVStartpoint) / (AllSessions[EIS.RunningSession].IVvoltageTo - AllSessions[EIS.RunningSession].IVVoltageFrom) * (AllSessions[EIS.RunningSession].IVVoltageNStepp - 1));
                            int CVItt = AllSessions[EIS.RunningSession].CVItteration * 2 - 1;
                            int VltCnt = AllSessions[EIS.RunningSession].IVVoltageNStepp * CVItt + CVnFirst;
                            AllSessionsData[EIS.RunningSession].IVAmpDim = VltCnt;
                            AllSessionsData[EIS.RunningSession].Vlt = new double[VltCnt];
                            AllSessionsData[EIS.RunningSession].Amp = new double[VltCnt];
                            AllSessionsData[EIS.RunningSession].ReZ = new double[VltCnt];
                            AllSessionsData[EIS.RunningSession].Imz = new double[VltCnt];
                        }
                        else
                        {
                            int VltCnt = AllSessions[EIS.RunningSession].IVVoltageNStepp;
                            AllSessionsData[EIS.RunningSession].IVAmpDim = VltCnt;
                            AllSessionsData[EIS.RunningSession].Vlt = new double[VltCnt];
                            AllSessionsData[EIS.RunningSession].Amp = new double[VltCnt];
                            AllSessionsData[EIS.RunningSession].ReZ = new double[VltCnt];
                            AllSessionsData[EIS.RunningSession].Imz = new double[VltCnt];
                        }
                    }


                    if (AllSessions[EIS.RunningSession].Mode == 4)
                    {
                        int VltCnt = AllSessions[EIS.RunningSession].Chrono_n;
                        //if (S.PulseReadingEdgeMode == 2) VltCnt = AllSessions[EIS.RunningSession].Chrono_n - 1;
                        AllSessionsData[EIS.RunningSession].IVAmpDim = VltCnt;
                        AllSessionsData[EIS.RunningSession].Vlt = new double[VltCnt];
                        AllSessionsData[EIS.RunningSession].Amp = new double[VltCnt];
                        AllSessionsData[EIS.RunningSession].ReZ = new double[VltCnt];
                        AllSessionsData[EIS.RunningSession].Imz = new double[VltCnt];
                    }

                    AllSessionsData[EIS.RunningSession].ReceivedDataCount = 0;
                    isRunStart = true;
                    BtnPauseContinue.Enabled = true;
                    BtnRun.Text = "Stop";
                    BtnCreateSession.Enabled = false;

                    Port.DiscardOutBuffer();
                    Port.DiscardInBuffer();
                    Port.Write("PGmode " + S.PGmode.ToString() + WriteReadToChar);
                    Thread.Sleep(100);
                    string ans = Port.ReadTo(ReadToChar);
                    if (ans != "OK") throw new Exception("The command OK is not received.\r error number:m10001 Command:PGmode");

                    int MyVFilter = 0; int MyIFilter = 0;
                    if (!(AllSessions[EIS.RunningSession].Mode == 0 || AllSessions[EIS.RunningSession].Mode == 1))
                    {
                        if (S.PGmode == 3)
                        { MyVFilter = 4; MyIFilter = 0; }
                        else
                        { MyVFilter = 2; MyIFilter = 2; }
                    }

                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    Port.Write("vfilter " + MyVFilter.ToString() + WriteReadToChar);
                    Thread.Sleep(10);
                    ans = Port.ReadTo(ReadToChar);
                    if (ans != "OK") throw new Exception("The command OK is not received.\r error number:200000 Command:vfilter");
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " VFilter: " + MyVFilter.ToString());
                    SetLabel(ref Label_VFilter, MyVFilter);

                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    Port.Write("idcfilter " + MyIFilter.ToString() + WriteReadToChar);
                    Thread.Sleep(10);
                    ans = Port.ReadTo(ReadToChar);
                    if (ans != "OK") throw new Exception("The command OK is not received.\r error number:200000 Command:Ifilter");
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " IFilter: " + MyIFilter.ToString());
                    SetLabel(ref Label_IFilter, MyIFilter);
                    ///////////////////////////////////////////////////////////////////
                    if (AllSessions[EIS.RunningSession].Mode == 0)
                        Start_EIS();  
                    else if (AllSessions[EIS.RunningSession].Mode == 1)
                        Start_EIS();
                    else if (AllSessions[EIS.RunningSession].Mode == 2)
                    {
                        Start_IV_Chrono();
                    }
                    else if (AllSessions[EIS.RunningSession].Mode == 3)
                        Start_IV_Chrono();
                    else if (AllSessions[EIS.RunningSession].Mode == 4)
                        Start_Pulse();
                    ///////////////////////////////////////////////////////////////////
                }
                else
                {
                    TotalTime = 0;
                    PreproccessingTimer.Start();
                    //if (!isOCTContinueRequested) StopRun();
                }
            }
            catch (Exception ex)
            {
                StopRun();
                MessageBox.Show("Run is Stoped because of error:\r" + ex.Message + "\rin Function:RunSession()");
            }
        }


        private int FindTheBestIDCSelectForChrono(double vlt, int VoltageRangeMode, int DCCurrentRangeMode, int PGmode)
        {
            int OldDirection = 0;
            int Direction = 0;
            int NewDCCurrentRangeMode = DCCurrentRangeMode;
            string ans = "";
            bool changed = true;

            try
            {
                while (changed)
                {
                    int ivlt = SetDCVConvert(vlt, VoltageRangeMode, DCCurrentRangeMode, PGmode);
                    double TheVoltageisset = 0;
                    double TheCurrentisset = 0;
                    double intTheVoltageisset = 0;
                    double intTheCurrentisset = 0;
                    firmware_ivset(ivlt, ref intTheVoltageisset, ref intTheCurrentisset, ref TheVoltageisset, ref TheCurrentisset);
                    int TheCase = 0;
                    double part = 7.0 / 100.0 * 4095;
                    if (intTheCurrentisset < part)
                        TheCase = -1;
                    else if (intTheCurrentisset >= part && intTheCurrentisset < 2048 - part)
                        TheCase = 0;
                    else if (intTheCurrentisset >= 2048 - part && intTheCurrentisset < 2048 + part)
                        TheCase = 1;
                    else if (intTheCurrentisset >= 2048 + part && intTheCurrentisset < 4095 - part)
                        TheCase = 0;
                    else
                        TheCase = -1;

                    if (TheCase == 0 || NewDCCurrentRangeMode == 0 || NewDCCurrentRangeMode == 7 || OldDirection * Direction < 0)
                    {
                        changed = false;
                        break;
                    }
                    else if (TheCase == 1)
                    {
                        NewDCCurrentRangeMode--;
                        OldDirection = Direction;
                        Direction = 1;
                    }
                    else if (TheCase == -1)
                    {
                        NewDCCurrentRangeMode++;
                        OldDirection = Direction;
                        Direction = -1;
                    }

                    Port.DiscardOutBuffer();
                    Port.DiscardInBuffer();
                    Port.Write("idcselect " + NewDCCurrentRangeMode.ToString() + WriteReadToChar);
                    Thread.Sleep(500);
                    ans = Port.ReadTo(ReadToChar);
                    if (ans != "OK") throw new Exception("The command OK is not received.\r error number:1000000001 Command:idcselect");
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " idcselect " + NewDCCurrentRangeMode.ToString());
                    SetLabel(ref Label_ISelect, NewDCCurrentRangeMode);
                }

                Port.DiscardOutBuffer();
                Port.DiscardInBuffer();
                Port.Write("idcselect " + DCCurrentRangeMode.ToString() + WriteReadToChar);
                Thread.Sleep(100);
                ans = Port.ReadTo(ReadToChar);
                if (ans != "OK") throw new Exception("The command OK is not received.\r error number:1000000002 Command:idcselect");
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " idcselect " + DCCurrentRangeMode.ToString());
                SetLabel(ref Label_ISelect, DCCurrentRangeMode);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString() + " in function: FindTheBestIDCSelectForChrono()"); }

            return NewDCCurrentRangeMode;
        }

        private void firmware_ivset(int ivlt, ref double intTheVoltageisset, ref double intTheCurrentisset, ref double TheVoltageisset, ref double TheCurrentisset)
        {
            Port.DiscardOutBuffer(); //Clear Buffer
            Port.DiscardInBuffer(); //Clear Buffer
            Port.Write("ivset " + ivlt.ToString() + ReadToChar);
            DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " ivset:" + ivlt.ToString());
            Port.Write(WriteReadToChar);
            Thread.Sleep(100);

            try
            {
                byte[] AllBytes1 = new byte[4];
                byte[] AllBytes2 = new byte[4];
                int word;

                AllBytes1[0] = (byte)Port.ReadByte();
                AllBytes1[1] = (byte)Port.ReadByte();
                AllBytes1[2] = (byte)Port.ReadByte();
                AllBytes1[3] = (byte)Port.ReadByte();
                AllBytes2[0] = (byte)Port.ReadByte();
                AllBytes2[1] = (byte)Port.ReadByte();
                AllBytes2[2] = (byte)Port.ReadByte();
                AllBytes2[3] = (byte)Port.ReadByte();

                int nData = IVnData;
                word = AllBytes1[0] | (AllBytes1[1] << 8) | (AllBytes1[2] << 16) | (AllBytes1[3] << 24);
                double Vmean = (double)word / (double)nData;

                word = AllBytes2[0] | (AllBytes2[1] << 8) | (AllBytes2[2] << 16) | (AllBytes2[3] << 24);
                double Imean = (double)word / (double)nData;

                intTheVoltageisset = Vmean;
                intTheCurrentisset = Imean;

                //FormEISDScope.UpdateIVDiagram(IVnDataTotal, IVtDataTotal, IVVDataTotal, IVIDataTotal);
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " Vmean:" + Vmean.ToString());
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " Imean:" + Imean.ToString());

                TheVoltageisset = GetDCVConvert(Vmean, DEISCurrentVmlp, AllSessions[EIS.RunningSession].EISVoltageRangeMode);
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " The Voltage is set:" + TheVoltageisset.ToString());

                TheCurrentisset = GetDCIConvert(Imean, AllSessions[EIS.RunningSession].EISDCCurrentRangeModea, DEISCurrentImlp);
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " The Current is set:" + TheCurrentisset.ToString());
            }
            catch
            {
                throw new Exception("error number:firmware100001 Command:ivset in Function: firmware_ivset()");
            }
        }

        private bool Start_EIS()
        {
            bool isError = true;
            double TheCurrentisset=0;
            try
            {
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " EIS digital is starting ...");

                if (!isDataReceivedSet)
                {
                    Port.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.EISPort_DataReceived);
                    isDataReceivedSet = true;
                }
                string ans;
                isIAmpApplyed = false;
                isVAmpApplyed = false;
                isThisTheBestImlp = 0;
                isThisTheBestVmlp = 0;
                DEISCurrentImlp = 0;
                DEISCurrentVmlp = 0;
                OldDEISCurrentImlp = -1;
                OldDEISCurrentVmlp = -1;
                EISAverageNumberCounter = 0;
                EISRealImpMean = 0;
                EISImagImpMean = 0;

                int nItteration = AllSessions[EIS.RunningSession].ACFrqNStep;
                if (AllSessions[EIS.RunningSession].Mode == 1) nItteration = AllSessions[EIS.RunningSession].DCVoltageStep;
                for (int iii = 0; iii < nItteration; iii++) AllSessionsData[EIS.RunningSession].overflow[iii] = false;

                Port.DiscardOutBuffer();
                Port.DiscardInBuffer();
                Port.Write("vfilter 3" + WriteReadToChar);
                Thread.Sleep(100);
                ans = Port.ReadTo(ReadToChar);
                if (ans != "OK") throw new Exception("The command OK is not received.\r error number:100001 Command:vfilter");
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " vfilter:3");
                SetLabel(ref Label_Imlp, 0);

                Port.DiscardOutBuffer();
                Port.DiscardInBuffer();
                Port.Write("idcselect 2" + WriteReadToChar);
                Thread.Sleep(100);
                ans = Port.ReadTo(ReadToChar);
                if (ans != "OK") throw new Exception("The command OK is not received.\r error number:100001 Command:idcselect");

                Port.DiscardOutBuffer();
                Port.DiscardInBuffer();
                Port.Write("idcmlp 0" + WriteReadToChar);
                Thread.Sleep(100);
                ans = Port.ReadTo(ReadToChar);
                if (ans != "OK") throw new Exception("The command OK is not received.\r error number:100002 Command:idcmlp");
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " idcmlp:0");
                SetLabel(ref Label_Imlp, 0);

                Port.DiscardOutBuffer();
                Port.DiscardInBuffer();
                Port.Write("vdcmlp 0" + WriteReadToChar);
                Thread.Sleep(100);
                ans = Port.ReadTo(ReadToChar);
                if (ans != "OK") throw new Exception("The command OK is not received.\r error number:100003 Command:vdcmlp");
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " vdcmlp:0");
                SetLabel(ref Label_Vmlp, 0);


                Port.DiscardOutBuffer();
                Port.DiscardInBuffer();
                Port.Write("setselect " + AllSessions[EIS.RunningSession].EISVoltageRangeMode + WriteReadToChar);
                Thread.Sleep(100);
                ans = Port.ReadTo(ReadToChar);
                if (ans != "OK") throw new Exception("The command OK is not received.\r error number:100004 Command:setselect");
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " setselect:" + AllSessions[EIS.RunningSession].EISVoltageRangeMode.ToString());
                SetLabel(ref Label_VSelect, AllSessions[EIS.RunningSession].EISVoltageRangeMode);

                int zeroset;
                if (AllSessions[EIS.RunningSession].EISVoltageRangeMode == 0)
                    zeroset = Settings.Zeroset0;
                else
                    zeroset = Settings.Zeroset1;

                Port.DiscardOutBuffer();
                Port.DiscardInBuffer();
                Port.Write("zeroset " + zeroset.ToString() + WriteReadToChar);
                Thread.Sleep(100);
                ans = Port.ReadTo(ReadToChar);
                if (ans != "OK") throw new Exception("The command OK is not received.\r error number:100005 Command:zeroset");
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " zeroset:" + zeroset.ToString());
                isDataReceived = false;
                Thread.Sleep(100);
                isDigitalEISStepCompleted = false;
                AllowToTick = true;

                CurrentDigitalEIS_VAC_RMS = AllSessions[EIS.RunningSession].ACAmpConstant;
                int iCurrentDigitalEIS_VAC_RMS = SetACVoltageConvert(CurrentDigitalEIS_VAC_RMS*5.0/4.0, AllSessions[EIS.RunningSession].EISVoltageRangeMode);

                Port.DiscardOutBuffer();
                Port.DiscardInBuffer();
                Port.Write("acset " + iCurrentDigitalEIS_VAC_RMS.ToString() + WriteReadToChar);
                Thread.Sleep(100);
                ans = Port.ReadTo(ReadToChar);
                if (ans != "OK") throw new Exception("The command OK is not received.\r error number:100006 Command:acset");
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " acset:" + iCurrentDigitalEIS_VAC_RMS.ToString());
                SetLabel(ref iLabel_vac, iCurrentDigitalEIS_VAC_RMS);
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " Vac:" + CurrentDigitalEIS_VAC_RMS.ToString());
                SetLabel(ref Label_vac, CurrentDigitalEIS_VAC_RMS, "V");

                EISInitializeAutoMaximumIDCSelectFinder(ref EISMaxIDCSelect);
                
                int iIsv= (int)((EISMaxIDCSelect-1) / 2);
                if (iIsv > 3) iIsv = 3;
                EISMaxIDCSelect = 7;
                AllSessions[EIS.RunningSession].EISDCCurrentRangeModea = 2;// EISMaxIDCSelect;  //Check it

                Port.DiscardOutBuffer();
                Port.DiscardInBuffer();
                Port.Write("idcselect " + AllSessions[EIS.RunningSession].EISDCCurrentRangeModea.ToString() + WriteReadToChar);
                Thread.Sleep(100);
                ans = Port.ReadTo(ReadToChar);
                if (ans != "OK") throw new Exception("The command OK is not received.\r error number:100007 Command:idcselect");
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " idcselect " + AllSessions[EIS.RunningSession].EISDCCurrentRangeModea.ToString());
                SetLabel(ref Label_ISelect, AllSessions[EIS.RunningSession].EISDCCurrentRangeModea);

                double vlt = AllSessions[EIS.RunningSession].DCVoltageConstant;
                if (AllSessions[EIS.RunningSession].Mode == 1) vlt = AllSessions[EIS.RunningSession].DCVoltageFrom;

                if (AllSessions[EIS.RunningSession].isOCP && AllSessions[EIS.RunningSession].EISOCMode == 1) vlt = vlt + AllSessions[EIS.RunningSession].V_OCT;
                if (AllSessions[EIS.RunningSession].RelRef) vlt = -vlt;

                if (AllSessions[EIS.RunningSession].Mode == 1)
                {
                    SetIVFilter(AllSessions[EIS.RunningSession].EISfilterMode, 1 / (AllSessions[EIS.RunningSession].ACFrqFrom), AllSessions[EIS.RunningSession].EISDCCurrentRangeModea, AllSessions[EIS.RunningSession].EISVoltageRangeMode);
                    // vlt = -vlt;
                    EISMaxIDCSelect = FindTheBestIDCSelectForChrono(vlt, AllSessions[EIS.RunningSession].EISVoltageRangeMode, AllSessions[EIS.RunningSession].EISDCCurrentRangeModea, AllSessions[EIS.RunningSession].PGmode);
                }

                int ivlt = SetDCVConvert(vlt, AllSessions[EIS.RunningSession].EISVoltageRangeMode, AllSessions[EIS.RunningSession].EISDCCurrentRangeModea, AllSessions[EIS.RunningSession].PGmode);
                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer
                Port.Write("ivset " + ivlt.ToString() + ReadToChar);
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " ivset:" + ivlt.ToString());
                Port.Write(WriteReadToChar);
                Thread.Sleep(100);

                try
                {
                    byte[] AllBytes1 = new byte[4];
                    byte[] AllBytes2 = new byte[4];
                    int word;

                    AllBytes1[0] = (byte)Port.ReadByte();
                    AllBytes1[1] = (byte)Port.ReadByte();
                    AllBytes1[2] = (byte)Port.ReadByte();
                    AllBytes1[3] = (byte)Port.ReadByte();
                    AllBytes2[0] = (byte)Port.ReadByte();
                    AllBytes2[1] = (byte)Port.ReadByte();
                    AllBytes2[2] = (byte)Port.ReadByte();
                    AllBytes2[3] = (byte)Port.ReadByte();

                    int nData = IVnData;
                    word = AllBytes1[0] | (AllBytes1[1] << 8) | (AllBytes1[2] << 16) | (AllBytes1[3] << 24);
                    double Vmean = (double)word / (double)nData;

                    word = AllBytes2[0] | (AllBytes2[1] << 8) | (AllBytes2[2] << 16) | (AllBytes2[3] << 24);
                    double Imean = (double)word / (double)nData;

                    //FormEISDScope.UpdateIVDiagram(IVnDataTotal, IVtDataTotal, IVVDataTotal, IVIDataTotal);
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " Vmean:" + Vmean.ToString());
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " Imean:" + Imean.ToString());

                    double TheVoltageisset = GetDCVConvert(Vmean, DEISCurrentVmlp, AllSessions[EIS.RunningSession].EISVoltageRangeMode);
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " The Voltage is set:" + TheVoltageisset.ToString());

                    TheCurrentisset = GetDCIConvert(Imean, AllSessions[EIS.RunningSession].EISDCCurrentRangeModea, DEISCurrentImlp);
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " The Current is set:" + TheCurrentisset.ToString());

                }
                catch
                {
                    throw new Exception("Error in reading ivset.\r error number:1000071 Command:ivset");
                }

                if (AllSessions[EIS.RunningSession].isOCP && AllSessions[EIS.RunningSession].isOCPAutoStart)
                {
                    BtnFindOCP_Click(null, null);
                    BtnUseSuggestedVOCP_Click(null, null);
                }
                else
                {
                    if (AllSessions[EIS.RunningSession].EqTime > 0)
                    {
                        DebugListBox.Items.Add("stp: Wait " + AllSessions[EIS.RunningSession].EqTime.ToString() + "(s)" + " " + AllSessions[EIS.RunningSession].DataAndTime);
                        FWaitTime = AllSessions[EIS.RunningSession].EqTime;
                        FormWait fw = new FormWait();
                        fw.ShowDialog();
                    }
                }

                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer
                Port.Write("ivset " + ivlt.ToString() + ReadToChar);
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " ivset:" + ivlt.ToString());
                Port.Write(WriteReadToChar);
                Thread.Sleep(100);

                try
                {
                    byte[] AllBytes1 = new byte[4];
                    byte[] AllBytes2 = new byte[4];
                    int word;

                    AllBytes1[0] = (byte)Port.ReadByte();
                    AllBytes1[1] = (byte)Port.ReadByte();
                    AllBytes1[2] = (byte)Port.ReadByte();
                    AllBytes1[3] = (byte)Port.ReadByte();
                    AllBytes2[0] = (byte)Port.ReadByte();
                    AllBytes2[1] = (byte)Port.ReadByte();
                    AllBytes2[2] = (byte)Port.ReadByte();
                    AllBytes2[3] = (byte)Port.ReadByte();

                    int nData = IVnData;
                    word = AllBytes1[0] | (AllBytes1[1] << 8) | (AllBytes1[2] << 16) | (AllBytes1[3] << 24);
                    double Vmean = (double)word / (double)nData;

                    word = AllBytes2[0] | (AllBytes2[1] << 8) | (AllBytes2[2] << 16) | (AllBytes2[3] << 24);
                    double Imean = (double)word / (double)nData;

                    //FormEISDScope.UpdateIVDiagram(IVnDataTotal, IVtDataTotal, IVVDataTotal, IVIDataTotal);
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " Vmean:" + Vmean.ToString());
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " Imean:" + Imean.ToString());

                    double TheVoltageisset = GetDCVConvert(Vmean, DEISCurrentVmlp, AllSessions[EIS.RunningSession].EISVoltageRangeMode);
                    if (AllSessions[EIS.RunningSession].RelRef) TheVoltageisset = -TheVoltageisset;
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " The Voltage is set:" + TheVoltageisset.ToString());
                    SetLabel(ref iLabel_vdc, (int)Vmean);
                    SetLabelJustForVoltage(ref Label_vdc, TheVoltageisset, "V");
                    WarningV = TheVoltageisset;

                    TheCurrentisset = GetDCIConvert(Imean, AllSessions[EIS.RunningSession].EISDCCurrentRangeModea, DEISCurrentImlp);
                    if (AllSessions[EIS.RunningSession].RelRef) TheCurrentisset = -TheCurrentisset;
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " The Current is set:" + TheCurrentisset.ToString());
                    SetLabel(ref Label_idc, TheCurrentisset, "A");
                    WarningI = TheCurrentisset;
                }
                catch
                {
                    throw new Exception("Error in reading ivset.\r error number:1000072 Command:ivset");
                }

                /////////////////////////////////////////////
                ///Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer
                Port.Write("ACpreget" + WriteReadToChar);
                Port.ReadTo(ReadToChar);
               // Thread.Sleep(100);
                Port.DiscardOutBuffer();
                Port.DiscardInBuffer();

                Izero(-TheCurrentisset);


                Port.Write("iIs " + (iIsv).ToString() + WriteReadToChar);
                Thread.Sleep(100);
                ans = Port.ReadTo(ReadToChar);
                if (ans != "OK") throw new Exception("The command OK is not received.\r error number:100006 Command:iIs");
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " iIs:" + (iIsv).ToString());
                SetLabel(ref label_iIs, (iIsv));

                //////////////////////////////////////////

                ///////////////////////////////////////////
                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer
                Port.Write("aczero" + WriteReadToChar);
                Thread.Sleep(10);
                ans = Port.ReadTo(ReadToChar);
                if (ans != "OK") throw new Exception("The command OK is not received.\r error number:100008 Command:aczero");
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " AC_zero ");

                Thread.Sleep(10);
                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer
                Port.Write("aczero" + WriteReadToChar);
                Thread.Sleep(10);
                ans = Port.ReadTo(ReadToChar);
                if (ans != "OK") throw new Exception("The command OK is not received.\r error number:100009 Command:aczero");
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " AC_zero ");

                Port.DiscardOutBuffer();
                Port.DiscardInBuffer();
                Port.Write("vaczero" + WriteReadToChar);
                Thread.Sleep(10);
                ans = Port.ReadTo(ReadToChar);
                if (ans != "OK") throw new Exception("The command OK is not received.\r error number:100010 Command:vaczero");
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " V_AC_zero ");
               
                Thread.Sleep(10);
                Port.DiscardOutBuffer();
                Port.DiscardInBuffer();
                Port.Write("vaczero" + WriteReadToChar);
                Thread.Sleep(100);
                ans = Port.ReadTo(ReadToChar);
                if (ans != "OK") throw new Exception("The command OK is not received.\r error number:100011 Command:vaczero");
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " V_AC_zero ");

                Port.DiscardOutBuffer();
                Port.DiscardInBuffer();


                isEISVoltageAndCurrentOK = false;
                if (!GoToNext)
                {
                    Form2 f2 = new Form2();
                    isEISVoltageAndCurrentWarning = false;

                    if (AllSessions[EIS.RunningSession].EISDCCurrentRangeModea == 0 && Math.Abs(WarningI) > Math.Abs(Settings.GetDCI_Domain / Settings.GetDCI_Select0 / 10.0) ||
                        AllSessions[EIS.RunningSession].EISDCCurrentRangeModea == 1 && Math.Abs(WarningI) > Math.Abs(Settings.GetDCI_Domain / Settings.GetDCI_Select1 / 10.0) ||
                        AllSessions[EIS.RunningSession].EISDCCurrentRangeModea == 2 && Math.Abs(WarningI) > Math.Abs(Settings.GetDCI_Domain / Settings.GetDCI_select2 / 10.0) ||
                        AllSessions[EIS.RunningSession].EISDCCurrentRangeModea == 3 && Math.Abs(WarningI) > Math.Abs(Settings.GetDCI_Domain / Settings.GetDCI_Select3 / 10.0) ||
                        AllSessions[EIS.RunningSession].EISDCCurrentRangeModea == 4 && Math.Abs(WarningI) > Math.Abs(Settings.GetDCI_Domain / Settings.GetDCI_Select4 / 10.0) ||
                        AllSessions[EIS.RunningSession].EISDCCurrentRangeModea == 5 && Math.Abs(WarningI) > Math.Abs(Settings.GetDCI_Domain / Settings.GetDCI_Select5 / 10.0) ||
                        AllSessions[EIS.RunningSession].EISDCCurrentRangeModea == 6 && Math.Abs(WarningI) > Math.Abs(Settings.GetDCI_Domain / Settings.GetDCI_Select6 / 10.0) ||
                        AllSessions[EIS.RunningSession].EISDCCurrentRangeModea == 7 && Math.Abs(WarningI) > Math.Abs(Settings.GetDCI_Domain / Settings.GetDCI_Select7 / 10.0))
                        isEISVoltageAndCurrentWarning = true;
                    f2.ShowDialog();
                }

                if (GoToNext || isEISVoltageAndCurrentOK)
                {
                    if (AllSessions[EIS.RunningSession].Mode == 0)
                        frqMultStep = Math.Pow(AllSessions[EIS.RunningSession].ACFrqTo / AllSessions[EIS.RunningSession].ACFrqFrom, 1.0 / (AllSessions[EIS.RunningSession].ACFrqNStep - 1));
                    else
                        frqMultStep = (AllSessions[EIS.RunningSession].DCVoltageTo - AllSessions[EIS.RunningSession].DCVoltageFrom) / (AllSessions[EIS.RunningSession].DCVoltageStep - 1);
                    isFrequencyChanged = true;

                    if (AllSessions[EIS.RunningSession].EISMode == 1 && !isDigitalEISTimerTickSet)
                    {
                        DigitalEISStepUnSuccessCounter = 0;
                        isDigitalEISStepCompleted = true;
                        DigitalEISTimer = new System.Windows.Forms.Timer();
                        isDigitalEISTimerTickSet = true;
                        DigitalEISTimer.Interval = DigitalEISTimerMinInterval;
                        DigitalEISTimer.Tick += new System.EventHandler(DigitalEISTimer_Tick);
                        DigitalEISTimer.Enabled = true;
                        DigitalEISTimer.Start();
                    }
#if DEBUG
                    if (!isFormEISDScope2) button2_Click_1(null, null);
#else
                                                if (!isFormEISDScope) button1_Click(null, null);
#endif
                    FormDiagram newfd = new FormDiagram();
                    //newfd.MdiParent = this;
                    newfd.PlotIndex = EIS.RunningSession;
                    newfd.isSelfStanding = true;
                    newfd.SessionName.Visible = false;
                    newfd.SessionName_SelectedIndexChanged(null, null);
                    newfd.label1.Text = AllSessions[EIS.RunningSession].name;
                    newfd.label1.Font = new Font("", 14);
                    newfd.Show();
                }
                else
                {
                    throw new Exception("error number:100012 Command:vaczero");
                }

                isError = false;
            }
            catch (Exception ex)
            {
                isError = true;
                StopRun();
                MessageBox.Show("Run is Stoped because of error:\r" + ex.Message + "\rin Function:Start_EIS()");
            }
            return isError;
        }

        private bool Start_IV_Chrono()
        {
            bool isError = true;
            try
            {
                if (isDataReceivedSet)
                {
                    Port.DataReceived -= new System.IO.Ports.SerialDataReceivedEventHandler(this.EISPort_DataReceived);
                    isDataReceivedSet = false;
                }

                string ans;
                Port.Write("iacdac 2047" + WriteReadToChar);
                Port.DiscardOutBuffer();
                Port.DiscardInBuffer();
                Thread.Sleep(250);
                ans = Port.ReadTo(ReadToChar);
                Port.Write("iIs 3" + WriteReadToChar);
                Port.DiscardOutBuffer();
                 Port.DiscardInBuffer();
                Thread.Sleep(100);
                ans = Port.ReadTo(ReadToChar);
                SetLabel(ref label_iIs, 3);
                Thread.Sleep(10);
                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer
                Port.Write("idcselect " + AllSessions[EIS.RunningSession].IVCurrentRangeMode.ToString() + WriteReadToChar);
                Thread.Sleep(100);
                ans = Port.ReadTo(ReadToChar);
                if (ans != "OK") throw new Exception("The command OK is not received.\r error number:200001 Command:idcselect");
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " Idcselect=" + AllSessions[EIS.RunningSession].IVCurrentRangeMode.ToString());

                if (AllSessions[EIS.RunningSession].IVCurrentRangeMode <= 1 && AllSessions[EIS.RunningSession].PGmode == 1)
                {
                    Port.DiscardOutBuffer();
                    Port.DiscardInBuffer();
                    Port.Write("PGmode 0" + WriteReadToChar);
                    pgmode = 0;
                    Thread.Sleep(100);
                    ans = Port.ReadTo(ReadToChar);
                    if (ans != "OK") throw new Exception("The command OK is not received.\r error number:m10001 Command:PGmode");
                }


                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer
                Port.Write("setselect " + AllSessions[EIS.RunningSession].IVVoltageRangeMode.ToString() + WriteReadToChar);
                Thread.Sleep(100);
                ans = Port.ReadTo(ReadToChar);
                if (ans != "OK") throw new Exception("The command OK is not received.\r error number:200002 Command:setselect");
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " Setselect=" + AllSessions[EIS.RunningSession].IVVoltageRangeMode.ToString());

                SetIVFilter(0, (double)AllSessions[EIS.RunningSession].IVTimestep * AllSessions[EIS.RunningSession].IVVoltageNStepp / 100000, AllSessions[EIS.RunningSession].IVCurrentRangeMode, AllSessions[EIS.RunningSession].IVVoltageRangeMode);

                if (AllSessions[Selected].IVChrono_VFilter < 3)
                {
                    int MyVFilter = AllSessions[Selected].IVChrono_VFilter; //For IV and chrono and pulse
                    if (MyVFilter > 0) MyVFilter += 2;
                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    Port.Write("vfilter " + MyVFilter.ToString() + WriteReadToChar);
                    
                    ans = Port.ReadTo(ReadToChar);
                    if (ans != "OK") throw new Exception("The command OK is not received.\r error number:mm200000 Command:vfilter");
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " VFilter: " + MyVFilter.ToString());
                    SetLabel(ref Label_VFilter, MyVFilter);

                }

                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer
                Port.Write("acset 0" + WriteReadToChar);
                Thread.Sleep(100);
                ans = Port.ReadTo(ReadToChar);
                if (ans != "OK") throw new Exception("The command OK is not received.\r error number:200003 Command:acset");
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " acset: 0");
                SetLabel(ref iLabel_vac, 0);
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " Vac: 0.0");
                SetLabel(ref Label_vac, 0, "V");

                int zeroset;
                if (AllSessions[EIS.RunningSession].IVVoltageRangeMode == 0)
                    zeroset = Settings.Zeroset0;
                else
                    zeroset = Settings.Zeroset1;

                if (AllSessions[EIS.RunningSession].PGmode == 3)
                    GetGalvanostatZerosetOffset(AllSessions[EIS.RunningSession].IVCurrentRangeMode);
                 
                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer
                Port.Write("zeroset " + zeroset.ToString() + WriteReadToChar);
                Thread.Sleep(100);
                ans = Port.ReadTo(ReadToChar);
                isDataReceived = false;
                Thread.Sleep(100);
                isDigitalEISStepCompleted = false;
                AllowToTick = true;
                if (ans != "OK") throw new Exception("The command OK is not received.\r error number:200004 Command:zeroset");
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " zeroset=" + zeroset.ToString());

                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer
                Port.Write("vdcmlp " + AllSessions[EIS.RunningSession].IVVmlp.ToString() + WriteReadToChar);
                Thread.Sleep(100);
                ans = Port.ReadTo(ReadToChar);
                if (ans != "OK") throw new Exception("The command OK is not received.\r error number:200005 Command:vdcmlp");
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " vdcmlp=" + AllSessions[EIS.RunningSession].IVVmlp.ToString());

                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer
                Port.Write("idcmlp " + AllSessions[EIS.RunningSession].IVImlp.ToString() + WriteReadToChar);
                Thread.Sleep(100);
                ans = Port.ReadTo(ReadToChar);
                if (ans != "OK") throw new Exception("The command OK is not received.\r error number:200006 Command:idcmlp");
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " idcmlp=" + AllSessions[EIS.RunningSession].IVImlp.ToString());


                if (isIVRangesChanged)
                {
                    CalculateSpecificIVOffsets(AllSessions[EIS.RunningSession].IVCurrentRangeMode, AllSessions[EIS.RunningSession].IVImlp, AllSessions[EIS.RunningSession].IVVmlp, ref ThisIV_Ioffset, ref ThisIV_Voffset);
                    GetVOffsetFromSettings(AllSessions[EIS.RunningSession].IVVmlp, ref ThisIV_Voffset);
                    isIVRangesChanged = false;
                }

                double setvolt0 = AllSessions[EIS.RunningSession].IVVoltageFrom;
                if (AllSessions[EIS.RunningSession].isCVEnable)
                    setvolt0 = AllSessions[EIS.RunningSession].CVStartpoint;
                    if (AllSessions[EIS.RunningSession].RelRef) setvolt0 = -setvolt0;

                int ivlt = SetDCVConvert(setvolt0, AllSessions[EIS.RunningSession].IVVoltageRangeMode, AllSessions[EIS.RunningSession].IVCurrentRangeMode, AllSessions[EIS.RunningSession].PGmode);
                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " ivset=" + ivlt.ToString() + " vset=" + setvolt0.ToString());
                Port.Write("ivset " + ivlt.ToString() + ReadToChar);
                Port.Write(WriteReadToChar);
                Thread.Sleep(100);

                try
                {
                    byte[] AllBytes1 = new byte[4];
                    byte[] AllBytes2 = new byte[4];
                    int word;

                    AllBytes1[0] = (byte)Port.ReadByte();
                    AllBytes1[1] = (byte)Port.ReadByte();
                    AllBytes1[2] = (byte)Port.ReadByte();
                    AllBytes1[3] = (byte)Port.ReadByte();
                    AllBytes2[0] = (byte)Port.ReadByte();
                    AllBytes2[1] = (byte)Port.ReadByte();
                    AllBytes2[2] = (byte)Port.ReadByte();
                    AllBytes2[3] = (byte)Port.ReadByte();

                    int nData = IVnData;
                    word = AllBytes1[0] | (AllBytes1[1] << 8) | (AllBytes1[2] << 16) | (AllBytes1[3] << 24);
                    double Vmean = (double)word / (double)nData;

                    word = AllBytes2[0] | (AllBytes2[1] << 8) | (AllBytes2[2] << 16) | (AllBytes2[3] << 24);
                    double Imean = (double)word / (double)nData;

                    //FormEISDScope.UpdateIVDiagram(IVnDataTotal, IVtDataTotal, IVVDataTotal, IVIDataTotal);

                    double TheVoltageisset = GetDCVConvertWithNewOffset(Vmean, AllSessions[EIS.RunningSession].IVVmlp, ThisIV_Voffset, AllSessions[EIS.RunningSession].IVVoltageRangeMode);
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " The Voltage is set:" + TheVoltageisset.ToString());

                }
                catch
                {
                    throw new Exception("Error in reading ivset.\r error number:2000061 Command:ivset");
                }

                if (AllSessions[EIS.RunningSession].isOCP && AllSessions[EIS.RunningSession].isOCPAutoStart)
                {
                    BtnFindOCP_Click(null, null);
                    BtnUseSuggestedVOCP_Click(null, null);
                }
                else
                {
                    if (AllSessions[EIS.RunningSession].EqTime > 0)
                    {
                        DebugListBox.Items.Add("stp: Wait " + AllSessions[EIS.RunningSession].EqTime.ToString() + "(s)" + " " + AllSessions[EIS.RunningSession].DataAndTime);
                        FWaitTime = AllSessions[EIS.RunningSession].EqTime;
                        FormWait fw = new FormWait();
                        fw.ShowDialog();
                    }
                }

                IVnDataTotal = AllSessions[EIS.RunningSession].IVVoltageNStepp * (IVnData - 1);
                IVVDataTotal = new double[IVnDataTotal];
                IVIDataTotal = new double[IVnDataTotal];
                IVtDataTotal = new double[IVnDataTotal];
                double dt = 1.0 * AllSessions[EIS.RunningSession].IVTimestep / (IVnData - 2);
                for (int it = 0; it < IVnDataTotal; it++)
                {
                    IVVDataTotal[it] = 0;
                    IVIDataTotal[it] = 0;
                    IVtDataTotal[it] = it * dt;
                }

                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer

                double ivvltfrom = AllSessions[EIS.RunningSession].IVVoltageFrom;
                double cvvltstart = AllSessions[EIS.RunningSession].CVStartpoint;
                double ivvltto = AllSessions[EIS.RunningSession].IVvoltageTo;

                IVVsetcnt = 0;
                if (AllSessions[EIS.RunningSession].Mode == 3)          //IV
                {
                    if (AllSessions[EIS.RunningSession].isCVEnable)
                    {
                        int CVnFirst = (int)((AllSessions[EIS.RunningSession].IVvoltageTo - AllSessions[EIS.RunningSession].CVStartpoint) / (AllSessions[EIS.RunningSession].IVvoltageTo - AllSessions[EIS.RunningSession].IVVoltageFrom) * (AllSessions[EIS.RunningSession].IVVoltageNStepp - 1));
                        IVChronoVset = cvvltstart;
                        IVChronoDVset = (ivvltto - cvvltstart) / (CVnFirst - 1); //It will set some lines later
                    }
                    else
                    {
                        IVChronoVset = ivvltfrom;
                        IVChronoDVset = (ivvltto - ivvltfrom) / (AllSessions[EIS.RunningSession].IVVoltageNStepp - 1);
                    }
                }
                else if (AllSessions[EIS.RunningSession].Mode == 2)
                {
                    if (AllSessions[EIS.RunningSession].Chrono_isfast)
                    {
                        IVChronoVset = ivvltfrom;
                        IVChronoDVset = 0;
                    }
                    else
                    {
                        IVChronoVset = AllSessions[EIS.RunningSession].Chrono_v1;
                        IVChronoDVset = 0;
                    }
                }

                if (AllSessions[EIS.RunningSession].RelRef)
                {
                    cvvltstart = - cvvltstart;
                    ivvltfrom = -ivvltfrom;
                    ivvltto = -ivvltto;
                }
                int ivltStart = SetDCVConvert(cvvltstart, AllSessions[EIS.RunningSession].IVVoltageRangeMode, AllSessions[EIS.RunningSession].IVCurrentRangeMode, AllSessions[EIS.RunningSession].PGmode);
                int ivltFrom = SetDCVConvert(ivvltfrom, AllSessions[EIS.RunningSession].IVVoltageRangeMode, AllSessions[EIS.RunningSession].IVCurrentRangeMode, AllSessions[EIS.RunningSession].PGmode);
                int ivltTo = SetDCVConvert(ivvltto, AllSessions[EIS.RunningSession].IVVoltageRangeMode, AllSessions[EIS.RunningSession].IVCurrentRangeMode, AllSessions[EIS.RunningSession].PGmode);

                
                FormDiagram newfd = new FormDiagram();
                //newfd.MdiParent = this;
                newfd.PlotIndex = EIS.RunningSession;
                newfd.isSelfStanding = true;
                double x1 = 0;
                double x2 = 0;
                if (AllSessions[EIS.RunningSession].Mode == 3)          //IV
                {
                    x1 = AllSessions[EIS.RunningSession].IVVoltageFrom;
                    x2 = AllSessions[EIS.RunningSession].IVvoltageTo;
                }
                else if (AllSessions[EIS.RunningSession].Mode == 2)     //Chrono
                { 
                    if (AllSessions[EIS.RunningSession].Chrono_isfast)
                    {
                        x1 = 0;
                        x2 = AllSessions[EIS.RunningSession].ChronoEndTime;
                    }
                    else
                    {
                        double tend=0;
                        for (int i=1; i <= AllSessions[EIS.RunningSession].Chrono_nsteps; i++)
                        {
                            double dtt = 0;
                            if (i == 1) dtt = AllSessions[EIS.RunningSession].Chrono_t1;
                            else if (i == 2) dtt = AllSessions[EIS.RunningSession].Chrono_t2;
                            else if (i == 3) dtt = AllSessions[EIS.RunningSession].Chrono_t3;
                            else if (i == 4) dtt = AllSessions[EIS.RunningSession].Chrono_t4;
                            else if (i == 5) dtt = AllSessions[EIS.RunningSession].Chrono_t5;
                            else if (i == 6) dtt = AllSessions[EIS.RunningSession].Chrono_t6;
                            else if (i == 7) dtt = AllSessions[EIS.RunningSession].Chrono_t7;
                            else if (i == 8) dtt = AllSessions[EIS.RunningSession].Chrono_t8;
                            else if (i == 9) dtt = AllSessions[EIS.RunningSession].Chrono_t9;
                            else if (i == 10) dtt = AllSessions[EIS.RunningSession].Chrono_t10;
                            tend = tend + dtt;
                        }

                        x1 = 0;
                        x2 = tend;
                    }
                }

                double xm = (x1 + x2) / 2.0;
                x1 = -Math.Abs(x1 - xm);
                x2 = Math.Abs(x2 - xm);

                newfd.MinX = 0.1 * Math.Floor(10 * (1.01 * x1 + xm));
                newfd.MaxX = 0.1 * Math.Floor(10 * (1.01 * x2 + xm)) + 0.1;
                newfd.MinY = -1.1 * IVMaxFineCurrent;
                newfd.MaxY = 1.1 * IVMaxFineCurrent;
                

                /*if (AllSessions[EIS.RunningSession].Mode == 3 && AllSessions[EIS.RunningSession].PGmode == 3)
                {
                    int ISelect = AllSessions[EIS.RunningSession].IVCurrentRangeMode;
                    double convertor = 1;
                    if (ISelect == 0)
                        convertor = 1;
                    else if (ISelect == 1)
                        convertor = 0.001;
                    else if (ISelect == 2)
                        convertor = 0.001;
                    else if (ISelect == 3)
                        convertor = 0.001;
                    else if (ISelect == 4)
                        convertor = 0.000001;
                    else if (ISelect == 5)
                        convertor = 0.000001;
                    else if (ISelect == 6)
                        convertor = 0.000001;
                    else
                        convertor = 0.000000001;

                    newfd.MinY = 0.15 * Math.Floor(10 * (1.01 * x1 + xm)) * convertor;
                    newfd.MaxY = (0.15 * Math.Floor(10 * (1.01 * x2 + xm)) + 0.15) * convertor;
                }*/

                if (AllSessions[EIS.RunningSession].PGmode == 3)
                {
                    newfd.MinY = -1.2;
                    newfd.MaxY = 1.2;
                }

                newfd.SessionName.Visible = false;
                newfd.SessionName_SelectedIndexChanged(null, null);
                newfd.label1.Text = AllSessions[EIS.RunningSession].name;
                newfd.label1.Font = new Font("", 14);
                newfd.Show();

                if (AllSessions[EIS.RunningSession].Mode == 3)
                {
                    if (!AllSessions[EIS.RunningSession].isCVEnable)
                    {
                        //int iTimeStep = (int)(AllSessions[EIS.RunningSession].IVTimeStep / 1000 * 32000000 / 1024);
                        int iTimeStep = (int)(AllSessions[EIS.RunningSession].IVTimestep * 31.250) - 1;
                        //int iTimeStep = AllSessions[EIS.RunningSession].IVTimeStep;
                        IVChronoTimeStep = AllSessions[EIS.RunningSession].IVTimestep;
                        DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " iv");
                        DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " vlt From:" + ivltFrom.ToString());
                        DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " vlt To:" + ivltTo.ToString());
                        DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " Number of Steps:" + AllSessions[EIS.RunningSession].IVVoltageNStepp.ToString());
                        DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " Time Step:" + iTimeStep.ToString());

                        int deltaint = (int)((ivltTo - ivltFrom) / (AllSessions[EIS.RunningSession].IVVoltageNStepp - 1));
                        string order = "iv";
                        int startorder = ivltFrom - deltaint;
                        if (startorder < 0) startorder = 0;
                        if (ivltTo > 4095) ivltTo = 4095;
                        order = order + string.Format("{0: 0000}", startorder);
                        order = order + string.Format("{0: 0000}", ivltTo);
                        order = order + string.Format("{0: 0000}", AllSessions[EIS.RunningSession].IVVoltageNStepp + 1);
                        order = order + string.Format("{0: 000000}", iTimeStep);
                        Port.Write(order + WriteReadToChar); //iv 0000 4094 0100 003125
                        for (int d = 0; d < 8; d++) Port.ReadByte();
                    }
                    else
                    {
                        //int iTimeStep = (int)(AllSessions[EIS.RunningSession].IVTimeStep / 1000 * 32000000 / 1024);
                        int iTimeStep = (int)(AllSessions[EIS.RunningSession].IVTimestep * 31.250) -1;
                        //int iTimeStep = AllSessions[EIS.RunningSession].IVTimeStep;
                        IVChronoTimeStep = AllSessions[EIS.RunningSession].IVTimestep;

                        //double delta = (AllSessions[EIS.RunningSession].IVVoltageTo - AllSessions[EIS.RunningSession].IVVoltageFrom) / (AllSessions[EIS.RunningSession].IVVoltageNStepp - 1);
                        //int deltaint = SetDCVConvert(delta, AllSessions[EIS.RunningSession].IVVoltageRangeMode, AllSessions[EIS.RunningSession].IVCurrentRangeMode, AllSessions[EIS.RunningSession].PGmode);

                        double deltadouble = ((ivvltto - ivvltfrom) / (AllSessions[EIS.RunningSession].IVVoltageNStepp - 1));
                        Port.Write("ver?" + WriteReadToChar);
                        string Ver = Port.ReadTo(ReadToChar);
                        string[] Parts;
                        char[] delimiterChars = { '.' };
                        Parts = Ver.Split(delimiterChars);
                        int CurrentVer;
                        CurrentVer = Convert.ToInt16(Parts[1]);
                        double deltadouble2 = deltadouble;
                        if (CurrentVer > 1) deltadouble2 = 100.0 * deltadouble;
                        double sign = Math.Sign(deltadouble2);
                        int deltaint = SetDCVConvert_dV(Math.Abs(deltadouble2), AllSessions[EIS.RunningSession].IVVoltageRangeMode, AllSessions[EIS.RunningSession].IVCurrentRangeMode, AllSessions[EIS.RunningSession].PGmode);
                        deltaint -= 2047;
                        deltaint = -(int)(sign * Math.Abs(deltaint));
                        //if (deltaint < 1) deltaint = 1;
                        //if (deltaint > 65535) deltaint = 65535;

                        //int newexact_deltaint = deltaint + 2047;
                        //CV_newExactdelta = Inverse_SetDCVConvert_dV(newexact_deltaint, AllSessions[EIS.RunningSession].IVVoltageRangeMode, AllSessions[EIS.RunningSession].IVCurrentRangeMode, AllSessions[EIS.RunningSession].PGmode);
                        //if (CurrentVer > 1) CV_newExactdelta = CV_newExactdelta / 100.0;
                        //if (AllSessions[EIS.RunningSession].RelRef) CV_newExactdelta = -CV_newExactdelta;
                        //IVChronoDVset = CV_newExactdelta;

                        int CVnFirst = (int)((AllSessions[EIS.RunningSession].IVvoltageTo - AllSessions[EIS.RunningSession].CVStartpoint) / (AllSessions[EIS.RunningSession].IVvoltageTo - AllSessions[EIS.RunningSession].IVVoltageFrom) * (AllSessions[EIS.RunningSession].IVVoltageNStepp - 1));

                        Port.Write("input 00 " + AllSessions[EIS.RunningSession].CVItteration.ToString() + WriteReadToChar);
                        try
                        {
                            Thread.Sleep(100);
                            ans = Port.ReadTo(ReadToChar);
                            if (ans != "OK") throw new Exception("The command OK is not received.\r error number:710001 Command:input 00");
                        }
                        catch (Exception ex) { throw new Exception("error number:710001 Command:input 00"); }
                        Port.Write("input 01 " + deltaint.ToString() + WriteReadToChar);
                        try
                        {
                            Thread.Sleep(100);
                            ans = Port.ReadTo(ReadToChar);
                            if (ans != "OK") throw new Exception("The command OK is not received.\r error number:710002 Command:input 01");
                        }
                        catch (Exception ex) { throw new Exception("error number:710002 Command:input 01"); }
                        Port.Write("input 02 " + CVnFirst.ToString() + WriteReadToChar);
                        try
                        {
                            Thread.Sleep(100);
                            ans = Port.ReadTo(ReadToChar);
                            if (ans != "OK") throw new Exception("The command OK is not received.\r error number:710003 Command:input 02");
                        }
                        catch (Exception ex) { throw new Exception("error number:710003 Command:input 02"); }
                        Port.Write("input 03 " + ivltStart.ToString() + WriteReadToChar);
                        try
                        {
                            Thread.Sleep(100);
                            ans = Port.ReadTo(ReadToChar);
                            if (ans != "OK") throw new Exception("The command OK is not received.\r error number:710004 Command:input 03");
                        }
                        catch (Exception ex) { throw new Exception("error number:710004 Command:input 03"); }
                        Port.Write("input 04 " + AllSessions[EIS.RunningSession].IVVoltageNStepp.ToString() + WriteReadToChar);
                        try
                        {
                            Thread.Sleep(100);
                            ans = Port.ReadTo(ReadToChar);
                            if (ans != "OK") throw new Exception("The command OK is not received.\r error number:710005 Command:input 04");
                        }
                        catch (Exception ex) { throw new Exception("error number:710005 Command:input 04"); }
                        Port.Write("tinput 00 " + iTimeStep.ToString() + WriteReadToChar);
                        try
                        {
                            Thread.Sleep(100);
                            ans = Port.ReadTo(ReadToChar);
                            if (ans != "OK") throw new Exception("The command OK is not received.\r error number:710006 Command:tinput 00");
                        }
                        catch (Exception ex) { throw new Exception("error number:710006 Command:tinput 00"); }

                        DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + "input 00 " + AllSessions[EIS.RunningSession].CVItteration.ToString());
                        DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + "input 01 " + deltaint.ToString());
                        DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + "input 02 " + CVnFirst.ToString());
                        DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + "input 03 " + ivltFrom.ToString());
                        DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + "input 04 " + AllSessions[EIS.RunningSession].IVVoltageNStepp.ToString());
                        DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + "tinput 00 " + iTimeStep.ToString());

                        Port.Write("cv" + WriteReadToChar);
                        DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + "cv");
                    }
                }
                else if (AllSessions[EIS.RunningSession].Mode == 2)
                {
                    //in Chrono AllSessions[EIS.RunningSession].IVVoltageTo is the end time in sec
                SetIVFilter(0, AllSessions[EIS.RunningSession].Chrono_t1/10.0, AllSessions[EIS.RunningSession].IVCurrentRangeMode, AllSessions[EIS.RunningSession].IVVoltageRangeMode);

                    if (AllSessions[Selected].IVChrono_VFilter < 3)
                    {
                        int MyVFilter = AllSessions[Selected].IVChrono_VFilter; //For IV and chrono and pulse
                        if (MyVFilter > 0) MyVFilter += 2;
                        Port.DiscardOutBuffer(); //Clear Buffer
                        Port.DiscardInBuffer(); //Clear Buffer
                        Port.Write("vfilter " + MyVFilter.ToString() + WriteReadToChar);

                        ans = Port.ReadTo(ReadToChar);
                        if (ans != "OK") throw new Exception("The command OK is not received.\r error number:mm200000 Command:vfilter");
                        DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " VFilter: " + MyVFilter.ToString());
                        SetLabel(ref Label_VFilter, MyVFilter);

                    }

                    if (!AllSessions[EIS.RunningSession].Chrono_isfast)
                    {
                        ivvltfrom = AllSessions[EIS.RunningSession].Chrono_v1;
                        if (AllSessions[EIS.RunningSession].RelRef) ivvltfrom = -ivvltfrom;
                        ivltFrom = SetDCVConvert(ivvltfrom, AllSessions[EIS.RunningSession].IVVoltageRangeMode, AllSessions[EIS.RunningSession].IVCurrentRangeMode, AllSessions[EIS.RunningSession].PGmode);
                        
                        double EndTime = AllSessions[EIS.RunningSession].Chrono_t1 * 1000; //ms
                        int nThisStep = (int)(AllSessions[EIS.RunningSession].Chrono_t1 / AllSessions[EIS.RunningSession].Chrono_dt * 1000.0) + 1;
                        IVChronoTimeStep = AllSessions[EIS.RunningSession].Chrono_dt;

                        int iTimeStep = (int)(IVChronoTimeStep * 31.250) - 1;

                        DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " iv");
                        DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " vlt From:" + ivltFrom.ToString());
                        DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " vlt To:" + ivltFrom.ToString());
                        DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " Number of Steps:" + AllSessions[EIS.RunningSession].IVVoltageNStepp.ToString());
                        DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " Time Step:" + iTimeStep.ToString());

                        if (AllSessions[EIS.RunningSession].Chrono_ocp1)
                        {
                            if (isProbOn) SampleOnBtn_Click(null, null);
                        }
                        else
                        {
                            if (!isProbOn) SampleOnBtn_Click(null, null);
                        }

                        //int deltaint = (int)((ivltTo - ivltFrom) / (nThisStep - 1));
                        string order = "iv";
                        int startorder = ivltFrom;
                        if (startorder < 0) startorder = 0;
                        if (ivltTo > 4095) ivltTo = 4095;
                        order = order + string.Format("{0: 0000}", startorder);
                        order = order + string.Format("{0: 0000}", startorder);
                        order = order + string.Format("{0: 0000}", nThisStep + 1);
                        order = order + string.Format("{0: 000000}", iTimeStep);
                        Port.Write(order + WriteReadToChar); //iv 0000 4094 0100 003125
                        for (int d = 0; d < 8; d++) Port.ReadByte();
                    }
                    else
                    {
                        double EndTime = AllSessions[EIS.RunningSession].ChronoEndTime * 1000; //ms
                        IVChronoTimeStep = EndTime / (AllSessions[EIS.RunningSession].IVVoltageNStepp - 1);
                        //0.5 us * (t_get + 1) == t
                        int t_get = (int)(IVChronoTimeStep / 0.0005) - 1;
                        if (t_get > 65565) t_get = 65565;
                        if (t_get < 1) t_get = 1;
                        Port.Write("sn " + AllSessions[EIS.RunningSession].IVVoltageNStepp.ToString() + WriteReadToChar);
                        ans = Port.ReadTo(ReadToChar);
                        if (ans != "OK") throw new Exception("The command OK is not received.\r error number:1710001 Command:tinput 00");
                        Thread.Sleep(100);
                        Port.Write("T_get " + t_get.ToString() + WriteReadToChar);
                        ans = Port.ReadTo(ReadToChar);
                        if (ans != "OK") throw new Exception("The command OK is not received.\r error number:1710002 Command:tinput 00");
                        Thread.Sleep(100);
                        Port.Write("dcset " + ivltFrom.ToString() + WriteReadToChar);
                    }
                }



                if (AllSessions[EIS.RunningSession].IVTimestep > 0)
                {
                    if (!isIVTimerTickSet)
                    {
                        isIVTimerTickSet = true;
                        IVTimer1 = new System.Windows.Forms.Timer();
                        int interval = 0;
                        bool isTimerNeeded = true;
                        if (AllSessions[EIS.RunningSession].Mode == 2)
                        {
                            if (!AllSessions[EIS.RunningSession].Chrono_isfast)
                            {
                                interval = (int)AllSessions[EIS.RunningSession].Chrono_dt;
                            }
                            else
                            {
                                //interval = (int)IVChronoTimeStep;
                                isTimerNeeded = false;
                                for (int istep = 0; istep < AllSessions[EIS.RunningSession].IVVoltageNStepp; istep++)
                                {
                                    IVTimer_Tick(null, null);
                                }
                            }
                        }
                        else
                        {
                            interval = AllSessions[EIS.RunningSession].IVTimestep;
                        }

                        if (isTimerNeeded)
                        {
                            if (interval < 1) interval = 1;
                            IVTimer1.Interval = interval;
                            //AllSessions[Selected].IVTimestep
                            //IVTimer1.Interval = 100;//check
                            IVTimer1.Tick += new System.EventHandler(IVTimer_Tick);
                            IVTimer1.Enabled = true;
                            IVTimer1.Start();
                        }
                    }
                }
                else
                {
                    for (int cnt = 0; cnt < AllSessions[EIS.RunningSession].IVVoltageNStepp; cnt++)
                    {
                        try
                        {
                            byte[] AllBytes1 = new byte[4];
                            byte[] AllBytes2 = new byte[4];

                            AllBytes1[0] = (byte)Port.ReadByte();
                            AllBytes1[1] = (byte)Port.ReadByte();
                            AllBytes1[2] = (byte)Port.ReadByte();
                            AllBytes1[3] = (byte)Port.ReadByte();
                            AllBytes2[0] = (byte)Port.ReadByte();
                            AllBytes2[1] = (byte)Port.ReadByte();
                            AllBytes2[2] = (byte)Port.ReadByte();
                            AllBytes2[3] = (byte)Port.ReadByte();

                            int nData = IVnData;
                            int word;
                            word = AllBytes1[0] | (AllBytes1[1] << 8) | (AllBytes1[2] << 16) | (AllBytes1[3] << 24);
                            double Vmean = (double)word / (double)nData;

                            word = AllBytes2[0] | (AllBytes2[1] << 8) | (AllBytes2[2] << 16) | (AllBytes2[3] << 24);
                            double Imean = (double)word / (double)nData;

                            DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " i=" + cnt.ToString());
                            double volt = GetDCVConvertWithNewOffset(Vmean, AllSessions[EIS.RunningSession].IVVmlp, ThisIV_Voffset, AllSessions[EIS.RunningSession].IVVoltageRangeMode);
                            double current = GetDCIConvertWithNewOffset(Imean, AllSessions[EIS.RunningSession].IVCurrentRangeMode, AllSessions[EIS.RunningSession].IVImlp, ThisIV_Ioffset);

                            if (AllSessions[EIS.RunningSession].RelRef)
                            {
                                volt = -volt;
                                current = -current;
                            }

                            DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " iVmean=" + Vmean.ToString() + " V=" + volt.ToString());
                            DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " iImean=" + Imean.ToString() + " I=" + current.ToString());
                            //FormEISDScope.UpdateIVDiagram(IVnDataTotal, IVtDataTotal, IVVDataTotal, IVIDataTotal);

                            AllSessionsData[EIS.RunningSession].Vlt[cnt] = volt;
                            AllSessionsData[EIS.RunningSession].Amp[cnt] = current;
                        }
                        catch
                        {
                            throw new Exception("Error in reading ivset.\r error number:2000062 Command:ivset cnt=" + cnt.ToString());
                        }
                        
                        AllSessionsData[EIS.RunningSession].ReceivedDataCount++;
                        PBAllSessionsValue++;
                        SetPBAllSessions(PBAllSessionsValue);
                        if (AllSessionsData[EIS.RunningSession].ReceivedDataCount == AllSessions[EIS.RunningSession].IVVoltageNStepp)
                        {
                            AllSessions[EIS.RunningSession].isFinished = true;

                            if (AllSessions[EIS.RunningSession].isChBPostProcProbOff)
                            {
                                if (isProbOn)
                                {
                                    SampleOnBtn_Click(null, null);
                                }
                            }
                            else
                            {
                                try
                                {
                                    int iVlt = SetDCVConvert(AllSessions[EIS.RunningSession].IdealVoltage, AllSessions[EIS.RunningSession].IVVoltageRangeMode, AllSessions[EIS.RunningSession].IVCurrentRangeMode, AllSessions[EIS.RunningSession].PGmode);
                                    Port.DiscardOutBuffer(); //Clear Buffer
                                    Port.DiscardInBuffer(); //Clear Buffer
                                    Port.Write("ivset " + iVlt.ToString() + ReadToChar);
                                    Port.Write(WriteReadToChar);
                                    Thread.Sleep(100);
                                    byte[] AllBytes11 = new byte[4];
                                    byte[] AllBytes22 = new byte[4];
                                    AllBytes11[0] = (byte)Port.ReadByte();
                                    AllBytes11[1] = (byte)Port.ReadByte();
                                    AllBytes11[2] = (byte)Port.ReadByte();
                                    AllBytes11[3] = (byte)Port.ReadByte();
                                    AllBytes22[0] = (byte)Port.ReadByte();
                                    AllBytes22[1] = (byte)Port.ReadByte();
                                    AllBytes22[2] = (byte)Port.ReadByte();
                                    AllBytes22[3] = (byte)Port.ReadByte();
                                }
                                catch
                                {
                                    throw new Exception("Error in reading ivset.\r error number:2000063 Command:ivset cnt=" + cnt.ToString());
                                }
                            }
                            tryNextRun();
                        }

                    }
                }

                isError = false;
            }
            catch (Exception ex)
            {
                isError = true;
                StopRun();
                MessageBox.Show("Run is Stoped because of error:\r" + ex.Message + "\rin Function:Start_IV_Chrono()");
            }
            return isError;
        }

        private int GetGalvanostatZerosetOffset(int CurrentRangeMode)
        {
            int zeroset = 2047;
            if (CurrentRangeMode == 0)
                zeroset = (int)Settings.GalvanostatI_Select0;
            else if (CurrentRangeMode == 1)
                zeroset = (int)Settings.GalvanostatI_Select1;
            else if (CurrentRangeMode == 2)
                zeroset = (int)Settings.GalvanostatI_Select1;
            else if (CurrentRangeMode == 3)
                zeroset = (int)Settings.GalvanostatI_Select1;
            else if (CurrentRangeMode == 4)
                zeroset = (int)Settings.GalvanostatI_Select1;
            else if (CurrentRangeMode == 5)
                zeroset = (int)Settings.GalvanostatI_Select1;
            else if (CurrentRangeMode == 6)
                zeroset = (int)Settings.GalvanostatI_Select1;
            else if (CurrentRangeMode == 7)
                zeroset = (int)Settings.GalvanostatI_Select1;

            return zeroset;
        }

        private bool Start_Pulse()
        {
            bool isError = true;
            try
            {
                if (isDataReceivedSet)
                {
                    Port.DataReceived -= new System.IO.Ports.SerialDataReceivedEventHandler(this.EISPort_DataReceived);
                    isDataReceivedSet = false;
                }

                string ans;
                Port.Write("iacdac 2047" + WriteReadToChar);
                Port.DiscardOutBuffer();
                Port.DiscardInBuffer();
                Thread.Sleep(250);
                ans = Port.ReadTo(ReadToChar);
                Port.Write("iIs 3" + WriteReadToChar);
                Port.DiscardOutBuffer();
                Port.DiscardInBuffer();
                Thread.Sleep(100);
                ans = Port.ReadTo(ReadToChar);
                SetLabel(ref label_iIs, 3);
                Thread.Sleep(10);
                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer
                
                Port.Write("idcselect " + AllSessions[EIS.RunningSession].PulseCurrentRangeMode.ToString() + WriteReadToChar);
                Thread.Sleep(100);
                ans = Port.ReadTo(ReadToChar);
                if (ans != "OK") throw new Exception("The command OK is not received.\r error number:200001 Command:idcselect");
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " Idcselect=" + AllSessions[EIS.RunningSession].PulseCurrentRangeMode.ToString());
                
                if (AllSessions[EIS.RunningSession].PulseCurrentRangeMode <= 1 && AllSessions[EIS.RunningSession].PGmode == 1)
                {
                    Port.DiscardOutBuffer();
                    Port.DiscardInBuffer();
                    Port.Write("PGmode 0" + WriteReadToChar);
                    Thread.Sleep(100);
                    ans = Port.ReadTo(ReadToChar);
                    if (ans != "OK") throw new Exception("The command OK is not received.\r error number:m10001 Command:PGmode");
                }
                

                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer
                Port.Write("setselect " + AllSessions[EIS.RunningSession].PulseVoltageRangeMode.ToString() + WriteReadToChar);
                Thread.Sleep(100);
                ans = Port.ReadTo(ReadToChar);
                if (ans != "OK") throw new Exception("The command OK is not received.\r error number:200002 Command:setselect");
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " Setselect=" + AllSessions[EIS.RunningSession].PulseVoltageRangeMode.ToString());

                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer
                Port.Write("acset 0" + WriteReadToChar);
                Thread.Sleep(100);
                ans = Port.ReadTo(ReadToChar);
                if (ans != "OK") throw new Exception("The command OK is not received.\r error number:200003 Command:acset");
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " acset: 0");
                SetLabel(ref iLabel_vac, 0);
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " Vac: 0.0");
                SetLabel(ref Label_vac, 0, "V");

                int zeroset;
                if (AllSessions[EIS.RunningSession].PulseVoltageRangeMode == 0)
                    zeroset = Settings.Zeroset0;
                else
                    zeroset = Settings.Zeroset1;

                if (AllSessions[EIS.RunningSession].PGmode == 3)
                    zeroset = GetGalvanostatZerosetOffset(AllSessions[EIS.RunningSession].PulseCurrentRangeMode);

                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer
                Port.Write("zeroset " + zeroset.ToString() + WriteReadToChar);
                Thread.Sleep(100);
                ans = Port.ReadTo(ReadToChar);
                isDataReceived = false;
                Thread.Sleep(100);
                isDigitalEISStepCompleted = false;
                AllowToTick = true;
                if (ans != "OK") throw new Exception("The command OK is not received.\r error number:200004 Command:zeroset");
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " zeroset=" + zeroset.ToString());

                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer
                Port.Write("vdcmlp " + AllSessions[EIS.RunningSession].PulseVmlp.ToString() + WriteReadToChar);
                Thread.Sleep(100);
                ans = Port.ReadTo(ReadToChar);
                if (ans != "OK") throw new Exception("The command OK is not received.\r error number:200005 Command:vdcmlp");
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " vdcmlp=" + AllSessions[EIS.RunningSession].PulseVmlp.ToString());

                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer
                Port.Write("idcmlp " + AllSessions[EIS.RunningSession].PulseImlpp.ToString() + WriteReadToChar);
                Thread.Sleep(100);
                ans = Port.ReadTo(ReadToChar);
                if (ans != "OK") throw new Exception("The command OK is not received.\r error number:200006 Command:idcmlp");
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " idcmlp=" + AllSessions[EIS.RunningSession].PulseImlpp.ToString());


                if (isPulseRangesChanged)
                {
                    CalculateSpecificIVOffsets(AllSessions[EIS.RunningSession].PulseCurrentRangeMode, AllSessions[EIS.RunningSession].PulseImlpp, AllSessions[EIS.RunningSession].PulseVmlp, ref ThisPulse_Ioffset, ref ThisPulse_Voffset);
                    GetVOffsetFromSettings(AllSessions[EIS.RunningSession].PulseVmlp, ref ThisPulse_Voffset);
                    isPulseRangesChanged = false;
                }

                double setvolt0 = AllSessions[EIS.RunningSession].Chrono_Pulse_Level;
                /*if (Form1.AllSessions[Form1.Selected].PulseVoltammetryMode == 2)
                {
                    double amplitude0 = AllSessions[EIS.RunningSession].Chrono_Pulse_Amplitude;
                    amplitude0 = -amplitude0;
                    double sw = amplitude0 / 2;
                    setvolt0 = setvolt0 - sw;
                }*/

                if (AllSessions[EIS.RunningSession].RelRef) setvolt0 = -setvolt0;

                

                int ivlt = SetDCVConvert(setvolt0, AllSessions[EIS.RunningSession].PulseVoltageRangeMode, AllSessions[EIS.RunningSession].PulseCurrentRangeMode, AllSessions[EIS.RunningSession].PGmode);
                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " ivset=" + ivlt.ToString() + " vset=" + setvolt0.ToString());
                Port.Write("ivset " + ivlt.ToString() + ReadToChar);
                Port.Write(WriteReadToChar);
                Thread.Sleep(100);

                try
                {
                    byte[] AllBytes1 = new byte[4];
                    byte[] AllBytes2 = new byte[4];
                    int word;

                    AllBytes1[0] = (byte)Port.ReadByte();
                    AllBytes1[1] = (byte)Port.ReadByte();
                    AllBytes1[2] = (byte)Port.ReadByte();
                    AllBytes1[3] = (byte)Port.ReadByte();
                    AllBytes2[0] = (byte)Port.ReadByte();
                    AllBytes2[1] = (byte)Port.ReadByte();
                    AllBytes2[2] = (byte)Port.ReadByte();
                    AllBytes2[3] = (byte)Port.ReadByte();

                    int nData = IVnData;
                    word = AllBytes1[0] | (AllBytes1[1] << 8) | (AllBytes1[2] << 16) | (AllBytes1[3] << 24);
                    double Vmean = (double)word / (double)nData;

                    word = AllBytes2[0] | (AllBytes2[1] << 8) | (AllBytes2[2] << 16) | (AllBytes2[3] << 24);
                    double Imean = (double)word / (double)nData;

                    //FormEISDScope.UpdateIVDiagram(IVnDataTotal, IVtDataTotal, IVVDataTotal, IVIDataTotal);

                    double TheVoltageisset = GetDCVConvertWithNewOffset(Vmean, AllSessions[EIS.RunningSession].PulseVmlp, ThisPulse_Voffset, AllSessions[EIS.RunningSession].PulseVoltageRangeMode);
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " The Voltage is set:" + TheVoltageisset.ToString());

                }
                catch
                {
                    throw new Exception("Error in reading ivset.\r error number:2000061 Command:ivset");
                }

                if (AllSessions[EIS.RunningSession].isOCP && AllSessions[EIS.RunningSession].isOCPAutoStart)
                {
                    BtnFindOCP_Click(null, null);
                    BtnUseSuggestedVOCP_Click(null, null);
                }
                else
                {
                    if (AllSessions[EIS.RunningSession].EqTime > 0)
                    {
                        DebugListBox.Items.Add("stp: Wait " + AllSessions[EIS.RunningSession].EqTime.ToString() + "(s)" + " " + AllSessions[EIS.RunningSession].DataAndTime);
                        FWaitTime = AllSessions[EIS.RunningSession].EqTime;
                        FormWait fw = new FormWait();
                        fw.ShowDialog();
                    }
                }

                PulsenDataTotal = AllSessions[EIS.RunningSession].Chrono_n * (PulsenData - 1);
                PulseVDataTotal = new double[IVnDataTotal];
                PulseIDataTotal = new double[IVnDataTotal];
                PulsetDataTotal = new double[IVnDataTotal];
                double dt = 1.0 * AllSessions[EIS.RunningSession].Chrono_Total_Period / (PulsenData - 2);
                for (int it = 0; it < IVnDataTotal; it++)
                {
                    PulseVDataTotal[it] = 0;
                    PulseIDataTotal[it] = 0;
                    PulsetDataTotal[it] = it * dt;
                }

                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer

                double ivvltfrom = AllSessions[EIS.RunningSession].Chrono_Pulse_Level;
                //if (AllSessions[EIS.RunningSession].isCVEnable && AllSessions[EIS.RunningSession].Mode == 3) ivvltfrom = AllSessions[EIS.RunningSession].CVStartpoint;
                //double ivvltto = AllSessions[EIS.RunningSession].IVvoltageTo;
                if (AllSessions[EIS.RunningSession].RelRef)
                {
                    ivvltfrom = -ivvltfrom;
                    //ivvltto = -ivvltto;
                }

                int ivltFrom = SetDCVConvert(ivvltfrom, AllSessions[EIS.RunningSession].PulseVoltageRangeMode, AllSessions[EIS.RunningSession].PulseCurrentRangeMode, AllSessions[EIS.RunningSession].PGmode);
                //int ivltTo = SetDCVConvert(ivvltto, AllSessions[EIS.RunningSession].IVvoltageRangeMode, AllSessions[EIS.RunningSession].IVCurrentRangeMode, AllSessions[EIS.RunningSession].PGmode);

                
                //if (AllSessions[EIS.RunningSession].Mode == 2)
                {
                    
                    int Total_Period = (int)AllSessions[EIS.RunningSession].Chrono_Total_Period;
                    int Pulse_Period = (int)AllSessions[EIS.RunningSession].Chrono_Pulse_Period;

                    int iPulse_Period = (int)((Pulse_Period * 31.250 - 1)/2.0);
                    int iLevelPeriod = (int)(((Total_Period - Pulse_Period) * 31.250 - 1)/2.0);
                    if (iLevelPeriod < 1) iLevelPeriod = 1;
                    PulseTimeStep = Total_Period;
                    SetIVFilter(0,((double)Pulse_Period)/1000.0, AllSessions[EIS.RunningSession].PulseCurrentRangeMode, AllSessions[EIS.RunningSession].PulseVoltageRangeMode);

                    if (AllSessions[Selected].Pulse_VFilter < 3)
                    {
                        int MyVFilter = AllSessions[Selected].Pulse_VFilter; //For IV and chrono and pulse

                        Port.DiscardOutBuffer(); //Clear Buffer
                        Port.DiscardInBuffer(); //Clear Buffer
                        Port.Write("vfilter " + MyVFilter.ToString() + WriteReadToChar);

                        ans = Port.ReadTo(ReadToChar);
                        if (ans != "OK") throw new Exception("The command OK is not received.\r error number:mm200000 Command:vfilter");
                        DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " VFilter: " + MyVFilter.ToString());
                        SetLabel(ref Label_VFilter, MyVFilter);

                    }


                    double PulseRelRef = 1.0;
                    if (AllSessions[EIS.RunningSession].RelRef) PulseRelRef = -1.0;
                    
                    //int Pulse_Level = SetDCVConvert(PulseRelRef * AllSessions[EIS.RunningSession].Chrono_Pulse_Level, AllSessions[EIS.RunningSession].PulseVoltageRangeMode, AllSessions[EIS.RunningSession].PulseCurrentRangeMode, AllSessions[EIS.RunningSession].PGmode);
                    //int Pulse_Amplitude = SetDCVConvert(PulseRelRef * AllSessions[EIS.RunningSession].Chrono_Pulse_Level + PulseRelRef * AllSessions[EIS.RunningSession].Chrono_Pulse_Amplitude, AllSessions[EIS.RunningSession].PulseVoltageRangeMode, AllSessions[EIS.RunningSession].PulseCurrentRangeMode, AllSessions[EIS.RunningSession].PGmode);
                    //int Level_Step = SetDCVConvert(PulseRelRef * AllSessions[EIS.RunningSession].Chrono_Level_Step, AllSessions[EIS.RunningSession].PulseVoltageRangeMode, AllSessions[EIS.RunningSession].PulseCurrentRangeMode, AllSessions[EIS.RunningSession].PGmode) - 2047;
                    //int Amplitude_Step = SetDCVConvert(PulseRelRef * AllSessions[EIS.RunningSession].Chrono_Amplitude_step, AllSessions[EIS.RunningSession].PulseVoltageRangeMode, AllSessions[EIS.RunningSession].PulseCurrentRangeMode, AllSessions[EIS.RunningSession].PGmode) - 2047;

                    double pulselevel= PulseRelRef * AllSessions[EIS.RunningSession].Chrono_Pulse_Level;
                    double amplitude = PulseRelRef * AllSessions[EIS.RunningSession].Chrono_Pulse_Amplitude;

                    if (Form1.AllSessions[Form1.Selected].PulseVoltammetryMode == 2)
                    {
                        amplitude = -amplitude;
                        double sw = amplitude / 2;
                        pulselevel = pulselevel - sw;
                    }

                    int Pulse_Level = SetDCVConvert(pulselevel, AllSessions[EIS.RunningSession].PulseVoltageRangeMode, AllSessions[EIS.RunningSession].PulseCurrentRangeMode, AllSessions[EIS.RunningSession].PGmode);
                    int Pulse_Amplitude = SetDCVConvert(pulselevel + amplitude, AllSessions[EIS.RunningSession].PulseVoltageRangeMode, AllSessions[EIS.RunningSession].PulseCurrentRangeMode, AllSessions[EIS.RunningSession].PGmode);
                    int Level_Step = SetDCVConvert(PulseRelRef * AllSessions[EIS.RunningSession].Chrono_Level_Step, AllSessions[EIS.RunningSession].PulseVoltageRangeMode, AllSessions[EIS.RunningSession].PulseCurrentRangeMode, AllSessions[EIS.RunningSession].PGmode) - 2047;
                    int Amplitude_Step = SetDCVConvert(PulseRelRef * AllSessions[EIS.RunningSession].Chrono_Amplitude_step, AllSessions[EIS.RunningSession].PulseVoltageRangeMode, AllSessions[EIS.RunningSession].PulseCurrentRangeMode, AllSessions[EIS.RunningSession].PGmode) - 2047;
                    

                    Port.DiscardOutBuffer(); Port.DiscardInBuffer();
                    Port.Write("input 00 " + AllSessions[EIS.RunningSession].Chrono_n.ToString() + WriteReadToChar); Thread.Sleep(100);
                    ans = Port.ReadTo(ReadToChar);
                    if (ans != "OK") throw new Exception("Undefined command received from device. error number 300001 Command: input");
                    
                    Port.DiscardOutBuffer(); Port.DiscardInBuffer();
                    Port.Write("input 01 " + Pulse_Level.ToString() + WriteReadToChar); Thread.Sleep(100);
                    ans = Port.ReadTo(ReadToChar);
                    if (ans != "OK") throw new Exception("Undefined command received from device. error number 300002 Command: input");

                    Port.DiscardOutBuffer(); Port.DiscardInBuffer();
                    Port.Write("input 02 " + Pulse_Amplitude.ToString() + WriteReadToChar); Thread.Sleep(100);
                    ans = Port.ReadTo(ReadToChar);
                    if (ans != "OK") throw new Exception("Undefined command received from device. error number 300003 Command: input");

                    Port.DiscardOutBuffer(); Port.DiscardInBuffer();
                    Port.Write("tinput 00 " + iPulse_Period.ToString() + WriteReadToChar); Thread.Sleep(100);
                    ans = Port.ReadTo(ReadToChar);
                    if (ans != "OK") throw new Exception("Undefined command received from device. error number 300004 Command: input");

                    Port.DiscardOutBuffer(); Port.DiscardInBuffer();
                    Port.Write("tinput 01 " + iLevelPeriod.ToString() + WriteReadToChar); Thread.Sleep(100);
                    ans = Port.ReadTo(ReadToChar);
                    if (ans != "OK") throw new Exception("Undefined command received from device. error number 300005 Command: input");

                    Port.DiscardOutBuffer(); Port.DiscardInBuffer();
                    Port.Write("input 03 " + Level_Step.ToString() + WriteReadToChar); Thread.Sleep(100);
                    ans = Port.ReadTo(ReadToChar);
                    if (ans != "OK") throw new Exception("Undefined command received from device. error number 300006 Command: input");

                    Port.DiscardOutBuffer(); Port.DiscardInBuffer();
                    Port.Write("input 04 " + Amplitude_Step.ToString() + WriteReadToChar); Thread.Sleep(100);
                    ans = Port.ReadTo(ReadToChar);
                    if (ans != "OK") throw new Exception("Undefined command received from device. error number 300007 Command: input");

                    Port.DiscardOutBuffer(); Port.DiscardInBuffer();
                }

                FormDiagram newfd = new FormDiagram();
                //newfd.MdiParent = this;
                newfd.PlotIndex = EIS.RunningSession;
                newfd.isSelfStanding = true;
                double x1 = PulseMinVoltage;
                double x2 = PulseMaxVoltage;
                /*if (AllSessions[EIS.RunningSession].Mode == 3)
                {
                    x1 = AllSessions[EIS.RunningSession].IVVoltageFrom;
                    x2 = AllSessions[EIS.RunningSession].IVvoltageTo;
                }
                else if (AllSessions[EIS.RunningSession].Mode == 2)
                {
                    x1 = 0;
                    x2 = AllSessions[EIS.RunningSession].ChronoEndTime;
                }*/

                double xm = (x1 + x2) / 2.0;
                x1 = -Math.Abs(x1 - xm);
                x2 = Math.Abs(x2 - xm);

                newfd.MinX = 0.1 * Math.Floor(10 * (1.01 * x1 + xm));
                newfd.MaxX = 0.1 * Math.Floor(10 * (1.01 * x2 + xm)) + 0.1;
                newfd.MinY = -1.1 * PulseMaxFineCurrent;
                newfd.MaxY = 1.1 * PulseMaxFineCurrent;

                /*if (AllSessions[EIS.RunningSession].PGmode == 3)
                {
                    int ISelect = AllSessions[EIS.RunningSession].PulseCurrentRangeMode;
                    double convertor = 1;
                    if (ISelect == 0)
                        convertor = 1;
                    else if (ISelect == 1)
                        convertor = 0.001;
                    else if (ISelect == 2)
                        convertor = 0.001;
                    else if (ISelect == 3)
                        convertor = 0.001;
                    else if (ISelect == 4)
                        convertor = 0.000001;
                    else if (ISelect == 5)
                        convertor = 0.000001;
                    else if (ISelect == 6)
                        convertor = 0.000001;
                    else
                        convertor = 0.000000001;

                    newfd.MinY = 0.15 * Math.Floor(10 * (1.01 * x1 + xm)) * convertor;
                    newfd.MaxY = (0.15 * Math.Floor(10 * (1.01 * x2 + xm)) + 0.15) * convertor;
                }*/

                if (AllSessions[EIS.RunningSession].PGmode == 3)
                {
                    newfd.MinY = -1.2;
                    newfd.MaxY = 1.2;
                }

                newfd.SessionName.Visible = false;
                newfd.SessionName_SelectedIndexChanged(null, null);
                newfd.label1.Text = AllSessions[EIS.RunningSession].name;
                newfd.label1.Font = new Font("", 14);
                newfd.Show();

                PulseiDataAchieved = 0;

                Port.DiscardOutBuffer(); Port.DiscardInBuffer();
                Port.Write("pulse" + WriteReadToChar); Thread.Sleep(100);
                
                //if (AllSessions[EIS.RunningSession].Chrono_Total_Period > 0)
                {
                    if (!isPulseTimerTickSet)
                    {
                        isPulseTimerTickSet = true;
                        PulseTimer1 = new System.Windows.Forms.Timer();
                        int interval = 0;
                        interval = (int)(AllSessions[EIS.RunningSession].Chrono_Total_Period);
                        if (interval < 1) interval = 1;
                        PulseTimer1.Interval = interval;
                        //PulseTimer1.Interval = 50;//check
                        isPulseTimerTickInProcess = false;
                        PulseTimer1.Tick += new System.EventHandler(PulseTimer_Tick);
                        PulseTimer1.Enabled = true;
                        PulseTimer1.Start();
                    }
                }
                
                isError = false;
            }
            catch (Exception ex)
            {
                isError = true;
                StopRun();
                MessageBox.Show("Run is Stoped because of error:\r" + ex.Message + "\rin Function:Start_Pulse()");
            }
            return isError;
        }




        private void SetPreTreatmentVoltage()
        {
            try
            {
                Port.DiscardOutBuffer();Port.DiscardInBuffer();
                Port.Write("idcselect " + AllSessions[EIS.RunningSession].IVCurrentRangeMode.ToString() + WriteReadToChar);
                Thread.Sleep(100);
                string ans = Port.ReadTo(ReadToChar);
                if (ans != "OK") throw new Exception("The command OK is not received.\r error number:400001 Command:idcselect");
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " Idcselect=" + AllSessions[EIS.RunningSession].IVCurrentRangeMode.ToString());
                
                if (AllSessions[EIS.RunningSession].IVCurrentRangeMode <= 1 && AllSessions[EIS.RunningSession].PGmode == 1)
                {
                    Port.DiscardOutBuffer();
                    Port.DiscardInBuffer();
                    Port.Write("PGmode 0" + WriteReadToChar);
                    pgmode = 0;
                    Thread.Sleep(100);
                    ans = Port.ReadTo(ReadToChar);
                    if (ans != "OK") throw new Exception("The command OK is not received.\r error number:m10001 Command:PGmode");
                }
                
                Port.DiscardOutBuffer(); Port.DiscardInBuffer();
                Port.Write("setselect " + AllSessions[EIS.RunningSession].IVVoltageRangeMode.ToString() + WriteReadToChar);
                Thread.Sleep(100);
                ans = Port.ReadTo(ReadToChar);
                if (ans != "OK") throw new Exception("The command OK is not received.\r error number:400002 Command:setselect");
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " Setselect=" + AllSessions[EIS.RunningSession].IVVoltageRangeMode.ToString());

                Port.DiscardOutBuffer(); Port.DiscardInBuffer();
                Port.Write("acset 0" + WriteReadToChar);
                Thread.Sleep(100);
                ans = Port.ReadTo(ReadToChar);
                if (ans != "OK") throw new Exception("The command OK is not received.\r error number:400003 Command:acset");
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " acset: 0");
                SetLabel(ref iLabel_vac, 0);
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " Vac: 0.0");
                SetLabel(ref Label_vac, 0, "V");

                int zeroset;
                if (AllSessions[EIS.RunningSession].IVVoltageRangeMode == 0)
                    zeroset = Settings.Zeroset0;
                else
                    zeroset = Settings.Zeroset1;

                Port.DiscardOutBuffer(); Port.DiscardInBuffer();
                Port.Write("zeroset " + zeroset.ToString() + WriteReadToChar);
                Thread.Sleep(100);
                ans = Port.ReadTo(ReadToChar);
                if (ans != "OK") throw new Exception("The command OK is not received.\r error number:400004 Command:zeroset");
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " zeroset=" + zeroset.ToString());
                isDataReceived = false;
                Thread.Sleep(100);
                isDigitalEISStepCompleted = false;
                AllowToTick = true;

                Port.DiscardOutBuffer(); Port.DiscardInBuffer();
                Port.Write("vdcmlp " + AllSessions[EIS.RunningSession].IVVmlp.ToString() + WriteReadToChar);
                Thread.Sleep(100);
                ans = Port.ReadTo(ReadToChar);
                if (ans != "OK") throw new Exception("The command OK is not received.\r error number:400005 Command:vdcmlp");
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " vdcmlp=" + AllSessions[EIS.RunningSession].IVVmlp.ToString());

                Port.DiscardOutBuffer(); Port.DiscardInBuffer();
                Port.Write("idcmlp " + AllSessions[EIS.RunningSession].IVImlp.ToString() + WriteReadToChar);
                Thread.Sleep(100);
                ans = Port.ReadTo(ReadToChar);
                if (ans != "OK") throw new Exception("The command OK is not received.\r error number:400006 Command:idcmlp");
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " idcmlp=" + AllSessions[EIS.RunningSession].IVImlp.ToString());

                if (isIVRangesChanged)
                {
                    CalculateSpecificIVOffsets(AllSessions[EIS.RunningSession].IVCurrentRangeMode, AllSessions[EIS.RunningSession].IVImlp, AllSessions[EIS.RunningSession].IVVmlp, ref ThisIV_Ioffset, ref ThisIV_Voffset);
                    GetVOffsetFromSettings(AllSessions[EIS.RunningSession].IVVmlp, ref ThisIV_Voffset);
                    isIVRangesChanged = false;
                }

                double setvolt0 = AllSessions[EIS.RunningSession].PretreatmentVoltage;
                if (AllSessions[EIS.RunningSession].RelRef) setvolt0 = -setvolt0;
                int ivlt = SetDCVConvert(setvolt0, AllSessions[EIS.RunningSession].IVVoltageRangeMode, AllSessions[EIS.RunningSession].IVCurrentRangeMode, AllSessions[EIS.RunningSession].PGmode);

                Port.DiscardOutBuffer();Port.DiscardInBuffer();
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " ivset=" + ivlt.ToString() + " vset=" + setvolt0.ToString());
                Port.Write("ivset " + ivlt.ToString() + ReadToChar);
                Port.Write(WriteReadToChar);
                Thread.Sleep(100);

                try
                {
                    byte[] AllBytes1 = new byte[4];
                    byte[] AllBytes2 = new byte[4];
                    int word;

                    AllBytes1[0] = (byte)Port.ReadByte();
                    AllBytes1[1] = (byte)Port.ReadByte();
                    AllBytes1[2] = (byte)Port.ReadByte();
                    AllBytes1[3] = (byte)Port.ReadByte();
                    AllBytes2[0] = (byte)Port.ReadByte();
                    AllBytes2[1] = (byte)Port.ReadByte();
                    AllBytes2[2] = (byte)Port.ReadByte();
                    AllBytes2[3] = (byte)Port.ReadByte();

                    int nData = IVnData;
                    word = AllBytes1[0] | (AllBytes1[1] << 8) | (AllBytes1[2] << 16) | (AllBytes1[3] << 24);
                    double Vmean = (double)word / (double)nData;

                    word = AllBytes2[0] | (AllBytes2[1] << 8) | (AllBytes2[2] << 16) | (AllBytes2[3] << 24);
                    double Imean = (double)word / (double)nData;
                    //FormEISDScope.UpdateIVDiagram(IVnDataTotal, IVtDataTotal, IVVDataTotal, IVIDataTotal);

                    double TheVoltageisset = GetDCVConvertWithNewOffset(Vmean, AllSessions[EIS.RunningSession].IVVmlp, ThisIV_Voffset, AllSessions[EIS.RunningSession].IVVoltageRangeMode);
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " The Voltage is set:" + TheVoltageisset.ToString());

                }
                catch { throw new Exception("Error in reading ivset.\r error number:2000063 Command:ivset"); }
            }
            catch (Exception ex)
            {
                StopRun();
                MessageBox.Show("Run is Stoped because of error:\r" + ex.Message + "\rin Function:SetPreTreatmentVoltage()");
            }
        }


        private void EISInitializeAutoMaximumIDCSelectFinder(ref int Max)
        {
            bool isBreak = false;
            int Tester = 0;
            int BoardISelectMax = 3;
            if (BoardType >= 2) BoardISelectMax = 7;
            if (BoardType < 2) BoardISelectMax = 2;
            BoardISelectMax = 7;
            for (Tester = 2; Tester <= BoardISelectMax; Tester++)
            {
                try
                {
                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    Port.Write("idcselect " + Tester.ToString() + WriteReadToChar);
                    Thread.Sleep(1000);
                    string ans = Port.ReadTo(ReadToChar);
                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    if (ans == "OK")
                    {
                        if (ans == "OK") DebugListBox.Items.Add("stp: Finder " + DebugListBox.Items.Count.ToString() + " idcselect " + Tester.ToString());
                        SetLabel(ref Label_ISelect, AllSessions[EIS.RunningSession].EISDCCurrentRangeModea);
                    }
                    else
                        StopRun();
                }
                catch
                {
                    StopRun();
                    MessageBox.Show("Run is Stoped because of error: 101221367 ...");
                }

                double vlt =- AllSessions[EIS.RunningSession].DCVoltageConstant;
                if (AllSessions[EIS.RunningSession].Mode == 1)
                    vlt = AllSessions[EIS.RunningSession].DCVoltageFrom;

                int ivlt = SetDCVConvert(vlt, AllSessions[EIS.RunningSession].EISVoltageRangeMode, AllSessions[EIS.RunningSession].EISDCCurrentRangeModea, AllSessions[EIS.RunningSession].PGmode);
                Port.DiscardOutBuffer();
                Port.DiscardInBuffer();
                Port.Write("ivset " + ivlt.ToString() + ReadToChar);
                DebugListBox.Items.Add("stp: Finder" + DebugListBox.Items.Count.ToString() + " ivset:" + ivlt.ToString());
                Port.Write(WriteReadToChar);
                Thread.Sleep(300);

                try
                {
                    byte[] AllBytes1 = new byte[4];
                    byte[] AllBytes2 = new byte[4];
                    int word;

                    AllBytes1[0] = (byte)Port.ReadByte();
                    AllBytes1[1] = (byte)Port.ReadByte();
                    AllBytes1[2] = (byte)Port.ReadByte();
                    AllBytes1[3] = (byte)Port.ReadByte();
                    AllBytes2[0] = (byte)Port.ReadByte();
                    AllBytes2[1] = (byte)Port.ReadByte();
                    AllBytes2[2] = (byte)Port.ReadByte();
                    AllBytes2[3] = (byte)Port.ReadByte();

                    int nData = IVnData;
                    word = AllBytes1[0] | (AllBytes1[1] << 8) | (AllBytes1[2] << 16) | (AllBytes1[3] << 24);
                    double Vmean = (double)word / (double)nData;

                    word = AllBytes2[0] | (AllBytes2[1] << 8) | (AllBytes2[2] << 16) | (AllBytes2[3] << 24);
                    double Imean = (double)word / (double)nData;

                    //FormEISDScope.UpdateIVDiagram(IVnDataTotal, IVtDataTotal, IVVDataTotal, IVIDataTotal);
                    DebugListBox.Items.Add("stp: Finder " + DebugListBox.Items.Count.ToString() + " Vmean:" + Vmean.ToString());
                    DebugListBox.Items.Add("stp: Finder " + DebugListBox.Items.Count.ToString() + " Imean:" + Imean.ToString());

                    if ((Imean > (2000)) || (Imean < -2000))
                    {
                        isBreak = true;
                        break;
                    }
                }
                catch { }
            }

            if (isBreak)
                Max = Tester - 1;
            else
                Max = Tester;

        }
        
        private void IVTimer_Tick(object sender, EventArgs e)
        {
            if (Port.BytesToRead==0) return;
            bool[] ocp = new bool[10]; 
            double[] t = new double[10];
            double[] v = new double[10];
            double[] dt = new double[10];
            int[] n = new int[10];
            int[] ntot = new int[10];
            int nSteps = AllSessions[Selected].Chrono_nsteps;
            int ipart = 0;
            bool isChrono = false;
            bool isChronoNextStep = false;
            if (AllSessions[EIS.RunningSession].Mode == 2) isChrono = true;

            if (isChrono && !AllSessions[EIS.RunningSession].Chrono_isfast)
            {

                for (int i = 1; i <= 10; i++)
                {
                    if (i == 1) t[i - 1] = AllSessions[Selected].Chrono_t1;
                    else if (i == 2) t[i - 1] = AllSessions[Selected].Chrono_t2;
                    else if (i == 3) t[i - 1] = AllSessions[Selected].Chrono_t3;
                    else if (i == 4) t[i - 1] = AllSessions[Selected].Chrono_t4;
                    else if (i == 5) t[i - 1] = AllSessions[Selected].Chrono_t5;
                    else if (i == 6) t[i - 1] = AllSessions[Selected].Chrono_t6;
                    else if (i == 7) t[i - 1] = AllSessions[Selected].Chrono_t7;
                    else if (i == 8) t[i - 1] = AllSessions[Selected].Chrono_t8;
                    else if (i == 9) t[i - 1] = AllSessions[Selected].Chrono_t9;
                    else if (i == 10) t[i - 1] = AllSessions[Selected].Chrono_t10;

                    if (i == 1) v[i - 1] = AllSessions[Selected].Chrono_v1;
                    else if (i == 2) v[i - 1] = AllSessions[Selected].Chrono_v2;
                    else if (i == 3) v[i - 1] = AllSessions[Selected].Chrono_v3;
                    else if (i == 4) v[i - 1] = AllSessions[Selected].Chrono_v4;
                    else if (i == 5) v[i - 1] = AllSessions[Selected].Chrono_v5;
                    else if (i == 6) v[i - 1] = AllSessions[Selected].Chrono_v6;
                    else if (i == 7) v[i - 1] = AllSessions[Selected].Chrono_v7;
                    else if (i == 8) v[i - 1] = AllSessions[Selected].Chrono_v8;
                    else if (i == 9) v[i - 1] = AllSessions[Selected].Chrono_v9;
                    else if (i == 10) v[i - 1] = AllSessions[Selected].Chrono_v10;

                    if (i == 1) ocp[i - 1] = AllSessions[Selected].Chrono_ocp1;
                    else if (i == 2) ocp[i - 1] = AllSessions[Selected].Chrono_ocp2;
                    else if (i == 3) ocp[i - 1] = AllSessions[Selected].Chrono_ocp3;
                    else if (i == 4) ocp[i - 1] = AllSessions[Selected].Chrono_ocp4;
                    else if (i == 5) ocp[i - 1] = AllSessions[Selected].Chrono_ocp5;
                    else if (i == 6) ocp[i - 1] = AllSessions[Selected].Chrono_ocp6;
                    else if (i == 7) ocp[i - 1] = AllSessions[Selected].Chrono_ocp7;
                    else if (i == 8) ocp[i - 1] = AllSessions[Selected].Chrono_ocp8;
                    else if (i == 9) ocp[i - 1] = AllSessions[Selected].Chrono_ocp9;
                    else if (i == 10) ocp[i - 1] = AllSessions[Selected].Chrono_ocp10;


                    dt[i - 1] = AllSessions[Selected].Chrono_dt/1000.0;
                    
                    n[i - 1] = (int)(t[i - 1] / dt[i - 1]) + 1;
                    ntot[i - 1] = 0;
                    for (int j = 0; j < i; j++) ntot[i - 1] = ntot[i - 1] + n[j];
                }
                
            }

            int  cnt = AllSessionsData[EIS.RunningSession].ReceivedDataCount;
            int cntMax = AllSessions[EIS.RunningSession].IVVoltageNStepp;
            if (AllSessions[EIS.RunningSession].Mode == 2) cntMax = ntot[nSteps - 1];
            int CVnFirst = (int)((AllSessions[EIS.RunningSession].IVvoltageTo - AllSessions[EIS.RunningSession].CVStartpoint) / (AllSessions[EIS.RunningSession].IVvoltageTo - AllSessions[EIS.RunningSession].IVVoltageFrom) * (AllSessions[EIS.RunningSession].IVVoltageNStepp - 1));
            if ((AllSessions[EIS.RunningSession].isCVEnable) && (AllSessions[EIS.RunningSession].Mode == 3)) cntMax = cntMax * (AllSessions[EIS.RunningSession].CVItteration * 2 - 1) + CVnFirst;
            //if (cnt < cntMax)
            {
                try
                {
                    double Vmean = 0;
                    double Imean = 0;
                    if ((AllSessions[EIS.RunningSession].Mode == 2 && (!AllSessions[EIS.RunningSession].Chrono_isfast)) || AllSessions[EIS.RunningSession].Mode == 3)
                    {
                        byte[] AllBytes1 = new byte[4];
                        byte[] AllBytes2 = new byte[4];

                        AllBytes1[0] = (byte)Port.ReadByte();
                        AllBytes1[1] = (byte)Port.ReadByte();
                        AllBytes1[2] = (byte)Port.ReadByte();
                        AllBytes1[3] = (byte)Port.ReadByte();
                        AllBytes2[0] = (byte)Port.ReadByte();
                        AllBytes2[1] = (byte)Port.ReadByte();
                        AllBytes2[2] = (byte)Port.ReadByte();
                        AllBytes2[3] = (byte)Port.ReadByte();

                        int nData = IVnData;
                        int word;
                        word = AllBytes1[0] | (AllBytes1[1] << 8) | (AllBytes1[2] << 16) | (AllBytes1[3] << 24);
                        Vmean = (double)word / (double)nData;

                        word = AllBytes2[0] | (AllBytes2[1] << 8) | (AllBytes2[2] << 16) | (AllBytes2[3] << 24);
                        Imean = (double)word / (double)nData;
                    }
                    else
                    {
                        byte[] AllBytes1 = new byte[2];
                        byte[] AllBytes2 = new byte[2];

                        AllBytes1[0] = (byte)Port.ReadByte();
                        AllBytes1[1] = (byte)Port.ReadByte();
                        AllBytes2[0] = (byte)Port.ReadByte();
                        AllBytes2[1] = (byte)Port.ReadByte();

                        int nData = IVnData;
                        int word;
                        word = AllBytes1[0] + AllBytes1[1] * 256;
                        if (word >= 0 && word < 2048)
                            word = word + 2048;
                        else
                            word = word - 2048 - 61440;
                        Vmean = (double)word - 2047;

                        word = AllBytes2[0] + AllBytes2[1] * 256;
                        if (word >= 0 && word < 2048)
                            word = word + 2048;
                        else
                            word = word - 2048 - 61440;
                        Imean = (double)word - 2047;
                    }
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " i=" + cnt.ToString());

                    
                    double volt = GetDCVConvertWithNewOffset(Vmean, AllSessions[EIS.RunningSession].IVVmlp, ThisIV_Voffset, AllSessions[EIS.RunningSession].IVVoltageRangeMode);
                    double current = GetDCIConvertWithNewOffset(Imean, AllSessions[EIS.RunningSession].IVCurrentRangeMode, AllSessions[EIS.RunningSession].IVImlp, ThisIV_Ioffset);

                    //if (AllSessions[EIS.RunningSession].Mode == 2)
                    //{
                    //    current = volt;
                    //    volt = ChronoTimeStep * cnt / 1000.0;
                    //}

                    
                    if (AllSessions[EIS.RunningSession].RelRef)
                    {
                        volt = -volt;
                        current = -current;
                    }

                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " iVmean=" + Vmean.ToString() + " V=" + volt.ToString());
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " iImean=" + Imean.ToString() + " I=" + current.ToString());

                    //FormEISDScope.UpdateIVDiagram(IVnDataTotal, IVtDataTotal, IVVDataTotal, IVIDataTotal);
                    
                    AllSessionsData[EIS.RunningSession].Vlt[cnt] = IVChronoVset + IVVsetcnt * IVChronoDVset;
                    AllSessionsData[EIS.RunningSession].Amp[cnt] = current;
                    AllSessionsData[EIS.RunningSession].ReZ[cnt] = IVChronoTimeStep * cnt / 1000.0;
                    AllSessionsData[EIS.RunningSession].Imz[cnt] = volt;

                    AllSessionsData[EIS.RunningSession].ReZ[0] = 0;
                    AllSessionsData[EIS.RunningSession].ReZ[cntMax - 1] = IVChronoTimeStep * (cntMax - 1) / 1000.0;

                    try
                    {
                        AllSessionsData[EIS.RunningSession].ReceivedDataCount++;
                        IVVsetcnt++;
                        PBAllSessionsValue++;
                        SetPBAllSessions(PBAllSessionsValue);
                        
                        if (isChrono && !AllSessions[EIS.RunningSession].Chrono_isfast)
                        {
                            ipart = 0;
                            for (int i = 0; i < 10; i++)
                            {
                                if (AllSessionsData[EIS.RunningSession].ReceivedDataCount == ntot[i])
                                {
                                    isChronoNextStep = true;
                                    ipart = i + 1;
                                    break;
                                }
                            }

                        }

                        if (!((AllSessions[EIS.RunningSession].isCVEnable && AllSessions[EIS.RunningSession].Mode == 3) || (!AllSessions[EIS.RunningSession].Chrono_isfast && AllSessions[EIS.RunningSession].Mode == 2)))
                        {
                            if (AllSessionsData[EIS.RunningSession].ReceivedDataCount == AllSessions[EIS.RunningSession].IVVoltageNStepp)
                            {
                                if (isIVTimerTickSet)
                                {
                                    IVTimer1.Stop();
                                    IVTimer1.Dispose();
                                    isIVTimerTickSet = false;
                                }
                                AllSessions[EIS.RunningSession].isFinished = true;

                                if (AllSessions[EIS.RunningSession].isChBPostProcProbOff)
                                {
                                    if (isProbOn)
                                    {
                                        SampleOnBtn_Click(null, null);
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        int iVlt = SetDCVConvert(AllSessions[EIS.RunningSession].IdealVoltage, AllSessions[EIS.RunningSession].IVVoltageRangeMode, AllSessions[EIS.RunningSession].IVCurrentRangeMode, AllSessions[EIS.RunningSession].PGmode);
                                        Port.DiscardOutBuffer(); //Clear Buffer
                                        Port.DiscardInBuffer(); //Clear Buffer
                                        Port.Write("ivset " + iVlt.ToString() + ReadToChar);
                                        Port.Write(WriteReadToChar);
                                        Thread.Sleep(100);
                                        byte[] AllBytes11 = new byte[4];
                                        byte[] AllBytes22 = new byte[4];
                                        AllBytes11[0] = (byte)Port.ReadByte();
                                        AllBytes11[1] = (byte)Port.ReadByte();
                                        AllBytes11[2] = (byte)Port.ReadByte();
                                        AllBytes11[3] = (byte)Port.ReadByte();
                                        AllBytes22[0] = (byte)Port.ReadByte();
                                        AllBytes22[1] = (byte)Port.ReadByte();
                                        AllBytes22[2] = (byte)Port.ReadByte();
                                        AllBytes22[3] = (byte)Port.ReadByte();
                                    }
                                    catch { }
                                }
                                tryNextRun();
                            }
                        }
                        else //if (AllSessions[EIS.RunningSession].isCVEnable)
                        {
                            
                            if ((AllSessions[EIS.RunningSession].Mode == 3 && AllSessionsData[EIS.RunningSession].ReceivedDataCount == AllSessions[EIS.RunningSession].IVVoltageNStepp * (AllSessions[EIS.RunningSession].CVItteration * 2 - 1) + CVnFirst) || (isChrono && isChronoNextStep && ipart== AllSessions[EIS.RunningSession].Chrono_nsteps))
                            {
                                if (isIVTimerTickSet)
                                {
                                    IVTimer1.Stop();
                                    IVTimer1.Dispose();
                                    isIVTimerTickSet = false;
                                }
                                AllSessions[EIS.RunningSession].isFinished = true;
                                //cnt = cnt;

                                if (AllSessions[EIS.RunningSession].isChBPostProcProbOff)
                                {
                                    if (isProbOn)
                                    {
                                        SampleOnBtn_Click(null, null);
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        int iVlt = SetDCVConvert(AllSessions[EIS.RunningSession].IdealVoltage, AllSessions[EIS.RunningSession].IVVoltageRangeMode, AllSessions[EIS.RunningSession].IVCurrentRangeMode, AllSessions[EIS.RunningSession].PGmode);
                                        Port.DiscardOutBuffer(); //Clear Buffer
                                        Port.DiscardInBuffer(); //Clear Buffer
                                        Port.Write("ivset " + iVlt.ToString() + ReadToChar);
                                        Port.Write(WriteReadToChar);
                                        Thread.Sleep(100);
                                        byte[] AllBytes11 = new byte[4];
                                        byte[] AllBytes22 = new byte[4];
                                        AllBytes11[0] = (byte)Port.ReadByte();
                                        AllBytes11[1] = (byte)Port.ReadByte();
                                        AllBytes11[2] = (byte)Port.ReadByte();
                                        AllBytes11[3] = (byte)Port.ReadByte();
                                        AllBytes22[0] = (byte)Port.ReadByte();
                                        AllBytes22[1] = (byte)Port.ReadByte();
                                        AllBytes22[2] = (byte)Port.ReadByte();
                                        AllBytes22[3] = (byte)Port.ReadByte();
                                    }
                                    catch { }
                                }

                                tryNextRun();
                            }
                            else
                            {
                                if (AllSessions[EIS.RunningSession].Mode == 3)
                                {
                                    
                                    if ((AllSessionsData[EIS.RunningSession].ReceivedDataCount - CVnFirst) % AllSessions[EIS.RunningSession].IVVoltageNStepp == 0 && AllSessionsData[EIS.RunningSession].ReceivedDataCount >= CVnFirst)
                                    {
                                        double ivvltfrom = AllSessions[EIS.RunningSession].IVVoltageFrom;
                                        double ivvltto = AllSessions[EIS.RunningSession].IVvoltageTo;
                                        if (((int)((double)(AllSessionsData[EIS.RunningSession].ReceivedDataCount- CVnFirst) / AllSessions[EIS.RunningSession].IVVoltageNStepp)) % 2 == 0)
                                        {
                                            double ddummy = ivvltfrom;
                                            ivvltfrom = ivvltto;
                                            ivvltto = ddummy;
                                        }

                                        ivvltfrom = IVChronoVset + (IVVsetcnt - 1) * IVChronoDVset;

                                        IVChronoDVset = (ivvltto - ivvltfrom) / (AllSessions[EIS.RunningSession].IVVoltageNStepp - 1);

                                        if (AllSessions[EIS.RunningSession].isCVEnable)
                                        {
                                            IVVsetcnt = 0;
                                            IVChronoVset = ivvltfrom;
                                            double IVChronoDVsetSign = Math.Sign((ivvltto - ivvltfrom) / (AllSessions[EIS.RunningSession].IVVoltageNStepp - 1));
                                            IVChronoDVset = IVChronoDVsetSign * Math.Abs(IVChronoDVset);
                                        }

                                        if (AllSessions[EIS.RunningSession].RelRef)
                                        {
                                            ivvltfrom = -ivvltfrom;
                                            ivvltto = -ivvltto;
                                        }
                                        
                                        int ivltFrom = SetDCVConvert(ivvltfrom, AllSessions[EIS.RunningSession].IVVoltageRangeMode, AllSessions[EIS.RunningSession].IVCurrentRangeMode, AllSessions[EIS.RunningSession].PGmode);
                                        int ivltTo = SetDCVConvert(ivvltto, AllSessions[EIS.RunningSession].IVVoltageRangeMode, AllSessions[EIS.RunningSession].IVCurrentRangeMode, AllSessions[EIS.RunningSession].PGmode);
                                        int iTimeStep = (int)(AllSessions[EIS.RunningSession].IVTimestep * 31.250) - 1;
                                        int deltaint = (int)((ivltTo - ivltFrom) / (AllSessions[EIS.RunningSession].IVVoltageNStepp - 1));
                                        string order = "iv";
                                        int startorder = ivltFrom - deltaint;
                                        if (startorder < 0) startorder = 0;
                                        if (ivltTo > 4095) ivltTo = 4095;
                                        order = order + string.Format("{0: 0000}", startorder);
                                        order = order + string.Format("{0: 0000}", ivltTo);
                                        order = order + string.Format("{0: 0000}", AllSessions[EIS.RunningSession].IVVoltageNStepp + 1);
                                        order = order + string.Format("{0: 000000}", iTimeStep);
                                        //Port.Write(order + WriteReadToChar); //iv 0000 4094 0100 003125

                                        //for (int d = 0; d < 8; d++) Port.ReadByte();
                                    }
                                }
                                else
                                {
                                    if (isChrono && isChronoNextStep && AllSessionsData[EIS.RunningSession].ReceivedDataCount > 0)
                                    {
                                        double ivvltfrom = v[ipart];
                                        IVChronoVset = ivvltfrom;
                                        IVChronoDVset = 0;
                                        IVVsetcnt = 0;

                                        if (AllSessions[EIS.RunningSession].RelRef) ivvltfrom = -ivvltfrom;
                                        int ivltFrom = SetDCVConvert(ivvltfrom, AllSessions[EIS.RunningSession].IVVoltageRangeMode, AllSessions[EIS.RunningSession].IVCurrentRangeMode, AllSessions[EIS.RunningSession].PGmode);
                                        int ivltTo = ivltFrom;
                                        
                                        double EndTime = t[ipart] * 1000; //ms
                                        int nThisStep = n[ipart];
                                        IVChronoTimeStep = dt[ipart] * 1000;
                                        SetIVFilter(0, t[ipart]/10.0, AllSessions[EIS.RunningSession].IVCurrentRangeMode, AllSessions[EIS.RunningSession].IVVoltageRangeMode);

                                        if (AllSessions[Selected].IVChrono_VFilter < 3)
                                        {
                                            int MyVFilter = AllSessions[Selected].IVChrono_VFilter; //For IV and chrono and pulse
                                            if (MyVFilter > 0) MyVFilter += 2;
                                            Port.DiscardOutBuffer(); //Clear Buffer
                                            Port.DiscardInBuffer(); //Clear Buffer
                                            Port.Write("vfilter " + MyVFilter.ToString() + WriteReadToChar);

                                            string ans = Port.ReadTo(ReadToChar);
                                            if (ans != "OK") throw new Exception("The command OK is not received.\r error number:mm200000 Command:vfilter");
                                            DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " VFilter: " + MyVFilter.ToString());
                                            SetLabel(ref Label_VFilter, MyVFilter);

                                        }


                                        int iTimeStep = (int)(IVChronoTimeStep * 31.250) - 1;

                                        DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " iv");
                                        DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " vlt From:" + ivltFrom.ToString());
                                        DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " vlt To:" + ivltFrom.ToString());
                                        DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " Number of Steps:" + AllSessions[EIS.RunningSession].IVVoltageNStepp.ToString());
                                        DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " Time Step:" + iTimeStep.ToString());

                                        if (ocp[ipart])
                                        {
                                            if (isProbOn) SampleOnBtn_Click(null, null);
                                        }
                                        else
                                        {
                                            if (!isProbOn) SampleOnBtn_Click(null, null);
                                        }

                                        //int deltaint = (int)((ivltTo - ivltFrom) / (nThisStep - 1));
                                        string order = "iv";
                                        int startorder = ivltFrom;
                                        if (startorder < 0) startorder = 0;
                                        if (ivltTo > 4095) ivltTo = 4095;
                                        order = order + string.Format("{0: 0000}", startorder);
                                        order = order + string.Format("{0: 0000}", startorder);
                                        order = order + string.Format("{0: 0000}", nThisStep + 1);
                                        order = order + string.Format("{0: 000000}", iTimeStep);
                                        Port.Write(order + WriteReadToChar); //iv 0000 4094 0100 003125
                                        for (int d = 0; d < 8; d++) Port.ReadByte();
                                        
                                    }
                                }
                            }
                        }
                    }
                    catch { }
                }
                catch { }
            }
        }


        private void PulseTimer_Tick(object sender, EventArgs e)
        {
            if (isPulseTimerTickInProcess) return;
            isPulseTimerTickInProcess = true;
            int cnt = AllSessionsData[EIS.RunningSession].ReceivedDataCount;
            int cntMax = AllSessions[EIS.RunningSession].Chrono_n;
            //int CVnFirst = (int)((AllSessions[EIS.RunningSession].IVvoltageTo - AllSessions[EIS.RunningSession].CVStartpoint) / (AllSessions[EIS.RunningSession].IVvoltageTo - AllSessions[EIS.RunningSession].IVVoltageFrom) * (AllSessions[EIS.RunningSession].IVVoltageNStepp - 1));
            //if ((AllSessions[EIS.RunningSession].isCVEnable) && (AllSessions[EIS.RunningSession].Mode == 3)) cntMax = cntMax * (AllSessions[EIS.RunningSession].CVItteration * 2) + CVnFirst;
            if (cnt < cntMax)
            {

                int nData = 2*PulsenData;
                //int[,] AllBytes = new int[nData, 4];
                int word = 0;
                int word0 = 0;
                if (Port.BytesToRead == 0)
                {
                    isPulseTimerTickInProcess = false;
                    return;
                }

                for (int iData = 0; iData < nData; iData++)
                {
                PulseAllBytesAchieved[iData, 0] = Port.ReadByte();
                PulseAllBytesAchieved[iData, 1] = Port.ReadByte();
                PulseAllBytesAchieved[iData, 2] = Port.ReadByte();
                PulseAllBytesAchieved[iData, 3] = Port.ReadByte();
                }
                
                PulseiDataAchieved = 0;
                /*
                if (PulseiDataAchieved == nData - 1)
                {
                    PulseiDataAchieved = 0;
                }
                else
                {
                    PulseiDataAchieved++;
                    isPulseTimerTickInProcess = false;
                    return;
                }
                */

                try
                {
                    //DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " Waiting for command e");
                    //string ans2 = Port.ReadTo(ReadToChar);
                    //if (ans2 != "e") throw (new Exception("Error in end of data ...\n Command: eisd"));

                    //double[] Vdata = new double[PulsenData - 0];
                    //double[] Idata = new double[PulsenData - 0];
                    double Vmean = 0;
                    double Imean = 0;

                    double Vmean0 = 0;
                    double Imean0 = 0;

                    bool isDiff = false;
                    int StartPoint = 0;
                    if (AllSessions[EIS.RunningSession].PulseReadingEdgemode == 1 || AllSessions[EIS.RunningSession].PulseReadingEdgemode == 2) StartPoint = PulsenData;
                    if (AllSessions[EIS.RunningSession].PulseReadingEdgemode == 2) isDiff = true;

                    double volt = 0;
                    double current = 0;
                    double volt0 = 0;
                    double current0 = 0;
                    for (int iData = StartPoint; iData < PulsenData + StartPoint; iData++)
                    {
                        // In the case of differensial data first read the second data (iData = StartPoint)
                        word = PulseAllBytesAchieved[iData + 0, 0] + PulseAllBytesAchieved[iData + 0, 1] * 256;

                        if (Settings.isDigitalEISReceiverUnsigned) // In Pulse we read data as the same as EIS
                            word = 0;
                        else
                        {
                            if (word >= 0 && word < 2048)
                                word = word + 2048;
                            else
                                word = word - 2048 - 61440;
                        }
                        Vmean = Vmean + (double)word;

                        word = PulseAllBytesAchieved[iData + 0, 2] + PulseAllBytesAchieved[iData + 0, 3] * 256;
                        if (Settings.isDigitalEISReceiverUnsigned)
                            word = 0;
                        else
                        {
                            if (word >= 0 && word < 2048)
                                word = word + 2048;
                            else
                                word = word - 2048 - 61440;
                        }
                        Imean = Imean + (double)word;

                        if (isDiff)
                        {
                            // In the case of differensial data first read the second data (iData = StartPoint)
                            word0 = PulseAllBytesAchieved[iData - StartPoint, 0] + PulseAllBytesAchieved[iData - StartPoint, 1] * 256;

                            if (Settings.isDigitalEISReceiverUnsigned) // In Pulse we read data as the same as EIS
                                word0 = 0;
                            else
                            {
                                if (word0 >= 0 && word0 < 2048)
                                    word0 = word0 + 2048;
                                else
                                    word0 = word0 - 2048 - 61440;
                            }
                            Vmean0 = Vmean0 + (double)word0;

                            word0 = PulseAllBytesAchieved[iData - StartPoint, 2] + PulseAllBytesAchieved[iData - StartPoint, 3] * 256;
                            if (Settings.isDigitalEISReceiverUnsigned)
                                word0 = 0;
                            else
                            {
                                if (word0 >= 0 && word0 < 2048)
                                    word0 = word0 + 2048;
                                else
                                    word0 = word0 - 2048 - 61440;
                            }
                            Imean0 = Imean0 + (double)word0;

                        }
                    }


                    volt = GetDCVConvertWithNewOffset(Vmean / PulsenData - 2047, AllSessions[EIS.RunningSession].PulseVmlp, ThisPulse_Voffset, AllSessions[EIS.RunningSession].PulseVoltageRangeMode);
                    current = GetDCIConvertWithNewOffset(Imean / PulsenData - 2047, AllSessions[EIS.RunningSession].PulseCurrentRangeMode, AllSessions[EIS.RunningSession].PulseImlpp, ThisPulse_Ioffset);

                    if (isDiff)
                    {
                        volt0 = GetDCVConvertWithNewOffset(Vmean0 / PulsenData - 2047, AllSessions[EIS.RunningSession].PulseVmlp, ThisPulse_Voffset, AllSessions[EIS.RunningSession].PulseVoltageRangeMode);
                        current0 = GetDCIConvertWithNewOffset(Imean0 / PulsenData - 2047, AllSessions[EIS.RunningSession].PulseCurrentRangeMode, AllSessions[EIS.RunningSession].PulseImlpp, ThisPulse_Ioffset);
                    }

                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " i=" + cnt.ToString());



                    if (AllSessions[EIS.RunningSession].RelRef)
                    {
                        volt = -volt;
                        current = -current;
                        if (isDiff)
                        {
                            volt0 = -volt0;
                            current0 = -current0;
                        }
                    }

                    if (isDiff)
                    {
                        volt = volt0;
                        current = (current - current0);

                        if (AllSessions[EIS.RunningSession].PulseVoltammetryMode == 2)
                        {
                            volt = (volt + volt0) / 2.0;
                            current = (current0 - current);
                        }
                    }

                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " iVmean=" + Vmean.ToString() + " V=" + volt.ToString());
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " iImean=" + Imean.ToString() + " I=" + current.ToString());

                    //FormEISDScope.UpdateIVDiagram(IVnDataTotal, IVtDataTotal, IVVDataTotal, IVIDataTotal);

                    AllSessionsData[EIS.RunningSession].Vlt[cnt] = volt;
                    AllSessionsData[EIS.RunningSession].Amp[cnt] = current;
                    AllSessionsData[EIS.RunningSession].ReZ[cnt] = PulseTimeStep * cnt / 1000.0;
                    AllSessionsData[EIS.RunningSession].Imz[cnt] = volt;

                    AllSessionsData[EIS.RunningSession].ReZ[0] = 0;
                    AllSessionsData[EIS.RunningSession].ReZ[cntMax - 1] = PulseTimeStep * (cntMax - 1) / 1000.0;
                    //Corrected till This line
                    try
                    {
                        AllSessionsData[EIS.RunningSession].ReceivedDataCount++;
                        PBAllSessionsValue++;
                        SetPBAllSessions(PBAllSessionsValue);
                        if (AllSessionsData[EIS.RunningSession].ReceivedDataCount == AllSessions[EIS.RunningSession].Chrono_n)
                        {
                            if (isPulseTimerTickSet)
                            {
                                PulseTimer1.Stop();
                                PulseTimer1.Dispose();
                                isPulseTimerTickSet = false;
                            }
                            AllSessions[EIS.RunningSession].isFinished = true;

                            if (AllSessions[EIS.RunningSession].isChBPostProcProbOff)
                            {
                                if (isProbOn)
                                {
                                    SampleOnBtn_Click(null, null);
                                }
                            }
                            else
                            {
                                try
                                {
                                    int iVlt = SetDCVConvert(AllSessions[EIS.RunningSession].IdealVoltage, AllSessions[EIS.RunningSession].PulseVoltageRangeMode, AllSessions[EIS.RunningSession].PulseCurrentRangeMode, AllSessions[EIS.RunningSession].PGmode);
                                    Port.DiscardOutBuffer(); //Clear Buffer
                                    Port.DiscardInBuffer(); //Clear Buffer
                                    Port.Write("ivset " + iVlt.ToString() + ReadToChar);
                                    Port.Write(WriteReadToChar);
                                    Thread.Sleep(100);
                                    byte[] AllBytes11 = new byte[4];
                                    byte[] AllBytes22 = new byte[4];
                                    AllBytes11[0] = (byte)Port.ReadByte();
                                    AllBytes11[1] = (byte)Port.ReadByte();
                                    AllBytes11[2] = (byte)Port.ReadByte();
                                    AllBytes11[3] = (byte)Port.ReadByte();
                                    AllBytes22[0] = (byte)Port.ReadByte();
                                    AllBytes22[1] = (byte)Port.ReadByte();
                                    AllBytes22[2] = (byte)Port.ReadByte();
                                    AllBytes22[3] = (byte)Port.ReadByte();
                                }
                                catch { }
                            }
                            tryNextRun();
                        }

                    }
                    catch { }
                }
                catch { }
            }
            isPulseTimerTickInProcess = false;
        }


        public static void resetdevice()
        {
            try
            {
                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer
                Port.Write("ddsclk 0" + WriteReadToChar);
                Thread.Sleep(10);
                //string ans = Port.ReadTo(ReadToChar);
                //Thread.Sleep(10);
            }
            catch { }

            try
            {
                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer
                Port.Write("dds 0" + WriteReadToChar);
                Thread.Sleep(10);
                //string ans = Port.ReadTo(ReadToChar);
                //Thread.Sleep(10);
            }
            catch { }
            try
            {
                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer
                Port.Write("acset 0"+ WriteReadToChar);
                Thread.Sleep(10);
                //string ans = Port.ReadTo(ReadToChar);
                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer
                //if (ans == "OK")
                //{
                
                //}
                //else
                //StopRun();
            }
            catch { }
            try
            {
                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer
                Port.Write("vac " + ((Int16)Settings.GalvanostatI_Select3).ToString() + WriteReadToChar);
                Thread.Sleep(10);
                //string ans = Port.ReadTo(ReadToChar);
                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer
                //if (ans == "OK")
                //{

                //}
                //else
                //StopRun();
            }
            catch { }
            try
            {
                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer
                Port.Write("zeroset " + Settings.Zeroset0.ToString() + WriteReadToChar);
                Thread.Sleep(10);
                //string ans = Port.ReadTo(ReadToChar);
                isDataReceived = false;
                Thread.Sleep(10);
                isDigitalEISStepCompleted = false;
                AllowToTick = true;
            }
            catch { }
            try
            {
                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer
                Port.Write("DCpreget" + WriteReadToChar);
                Thread.Sleep(10);
                //string ans = Port.ReadTo(ReadToChar);
                isDataReceived = false;
                Thread.Sleep(10);
                isDigitalEISStepCompleted = false;
                AllowToTick = true;
            }
            catch { }
        }

        private void DigitalEISTimer_Tick(object sender, EventArgs e)
        {
            if (IsReconnectingMode) return;
            try
            {
                
                if (AllowToTick)
                {
                    string ans = "";
                    AllowToTick = false;
                    if (isDigitalEISStepCompleted)
                    {
                        if (!isRunPause)
                        {
                            if (isProbOn)
                                ProbWarningLabel.Visible = false;
                            else
                                ProbWarningLabel.Visible = true;
                            int cnt = AllSessionsData[EIS.RunningSession].ReceivedDataCount;
                            int nItteration = AllSessions[EIS.RunningSession].ACFrqNStep;
                            if (AllSessions[EIS.RunningSession].Mode == 1) nItteration = AllSessions[EIS.RunningSession].DCVoltageStep;

                            if (cnt < nItteration)
                            {
                                double frq = AllSessions[EIS.RunningSession].ACFrqConstant;

                                if (AllSessions[EIS.RunningSession].Mode == 0)
                                {
                                    frq = AllSessions[EIS.RunningSession].ACFrqFrom * Math.Pow(frqMultStep, cnt);
                                    if (frq >= 100000.0)
                                    {
                                        double n = 2000000 / frq;
                                        double nchain = 512 / n;
                                        double deltat = 500e-9 / nchain;
                                        frq = 1.0 / (1.0 / frq + deltat);
                                    }
                                }

                                int nClock = 0;
                                int ddsClock = 0;
                                int ddsDiv = 1;
                                SetFrqConvert(ref frq, ref ddsClock, ref nClock, ref ddsDiv);
                                if (AllSessions[EIS.RunningSession].Mode == 0) 
                                    AllSessionsData[EIS.RunningSession].Frq[cnt] = GetFrqConvert(nClock, ddsClock);
                                DigitalEISTimer.Interval = DigitalEISTimerMinInterval;

                                Port.DiscardOutBuffer(); Port.DiscardInBuffer();
                                Port.Write("ddsclk " + ddsClock.ToString() + WriteReadToChar);
                                //Thread.Sleep(100);
                                ans = Port.ReadTo(ReadToChar);
                                if (ans != "OK") throw new Exception("The command OK is not received.\r error number:800001 Command:ddsclk");
                                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " ddsclk:" + ddsClock.ToString());
                                isDataReceived = false;
                                Thread.Sleep(100);
                                isDigitalEISStepCompleted = false;
                                SetIVFilter(AllSessions[EIS.RunningSession].EISfilterMode, 1 / frq, AllSessions[EIS.RunningSession].EISDCCurrentRangeModea, AllSessions[EIS.RunningSession].EISVoltageRangeMode);

                               
                                Port.DiscardOutBuffer();
                                Port.DiscardInBuffer();
                                isDataReceived = false;
                                isDigitalEISStepCompleted = false;
                                EISfalseCounter = 0;
                                Port.Write("eisd " + nClock.ToString() + WriteReadToChar);
                                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " eisd " + nClock.ToString());

                                Thread.Sleep(100);
                                SetLabel(ref Label_frq, frq, "Hz");
                                SetLabel(ref iLabel_frq, nClock);
                                if (isFrequencyChanged)
                                {
                                    isNeedToCorrect = true;
                                    isFrequencyChanged = false;
                                    isThisTheBestImlp = 0;
                                    isThisTheBestVmlp = 0;
                                }
                                //DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " Received = " + isDataReceived.ToString() + " Completed = " + isDigitalEISStepCompleted.ToString());
                                //AllowToTick = true;
                            }
                        }
                    }
                    else
                    {
                        if (isDataReceived) DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " Received = " + isDataReceived.ToString() + " Completed = " + isDigitalEISStepCompleted.ToString());
                        EISfalseCounter++;
                        if (EISfalseCounter > 1500) isDigitalEISStepCompleted = true;
                        if (isDataReceived)
                        {
                            isDigitalEISStepCompleted = true;
                            isDataReceived = false;
                            EISfalseCounter = 0;
                            bool isIvalidtofit = true;
                            bool isINeedToAmp = false;
                            bool isVvalidtofit = true;
                            bool isVNeedToAmp = false;

                            int cnt = AllSessionsData[EIS.RunningSession].ReceivedDataCount;
                            int SampleRateByte1, SampleRateByte2;
                            double DigitalTimeInterval = 0;
                            int nData = DigitalEISReceivernData;
                            int[,] AllBytes = new int[nData, 4];
                            double Frequency;
                            if (AllSessions[EIS.RunningSession].Mode == 0)
                                Frequency = AllSessionsData[EIS.RunningSession].Frq[cnt];
                            else
                                Frequency = AllSessions[EIS.RunningSession].ACFrqConstant;
                            double tPeriod = 1.0 / Frequency;
                            SampleRateByte1 = Port.ReadByte();
                            SampleRateByte2 = Port.ReadByte();

                            int word = SampleRateByte1 + SampleRateByte2 * 256 + 1;
                            DigitalTimeInterval = (double)word / 2000000.0;
                            if (DigitalTimeInterval * 511.0 * Frequency < 0.5) DigitalTimeInterval = DigitalTimeInterval * 16;
                            for (int iData = 0; iData < nData; iData++)
                            {
                                AllBytes[iData, 0] = Port.ReadByte();
                                AllBytes[iData, 1] = Port.ReadByte();
                                AllBytes[iData, 2] = Port.ReadByte();
                                AllBytes[iData, 3] = Port.ReadByte();
                            }

                            //DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " Waiting for command e");
                            string ans2 = Port.ReadTo(ReadToChar);
                            if (ans2 != "e") throw (new Exception("Error in end of data ...\n Command: eisd"));

                            double[] Vdata = new double[nData - 0];
                            double[] Idata = new double[nData - 0];
                            double[] IntVdata = new double[nData - 0];
                            double[] IntIdata = new double[nData - 0];
                            double[] FittedtArray = new double[nData - 0];
                            double[] FittedVdata = new double[nData - 0];
                            double[] FittedIdata = new double[nData - 0];
                            double[] FittedIntVdata = new double[nData - 0];
                            double[] FittedIntIdata = new double[nData - 0];
                            double iacmean=0;
                            for (int iData = 0; iData < nData - 0; iData++)
                            {
                                word = AllBytes[iData + 0, 0] + AllBytes[iData + 0, 1] * 256;
                                if (Settings.isDigitalEISReceiverUnsigned)
                                    Vdata[iData] = word;
                                else
                                {
                                    if (word >= 0 && word < 2048)
                                        word = word + 2048;
                                    else
                                        word = word - 2048 - 61440;
                                }
                                IntVdata[iData] = word;
                                Vdata[iData] = EISGetVConvert(word, DEISCurrentVmlp, AllSessions[EIS.RunningSession].EISVoltageRangeMode);//GetDCVConvert(word, DEISCurrentVmlp);


                                word = AllBytes[iData + 0, 2] + AllBytes[iData + 0, 3] * 256;
                                if (Settings.isDigitalEISReceiverUnsigned)
                                    Idata[iData] = GetDigitalVConvert(word) / Math.Pow(10, AllSessions[EIS.RunningSession].EISACCurrentRangeMode);
                                else
                                {
                                    if (word >= 0 && word < 2048)
                                        word = word + 2048;
                                    else
                                        word = word - 2048 - 61440;
                                }
                                IntIdata[iData] = word;
                                iacmean += word/ nData;
                                
                                //EISGetIConvert(double iamp, int ISelect, int Imlp)
                                double ACRange = 1;          //Added
                                if (AllSessions[EIS.RunningSession].EISACCurrentRangeMode == 0) //Added
                                    ACRange = Settings.GalvanostatI_Select0; //Added
                                if (AllSessions[EIS.RunningSession].EISACCurrentRangeMode == 1) //Added
                                    ACRange = Settings.GalvanostatI_Select1; //Added
                                if (AllSessions[EIS.RunningSession].EISACCurrentRangeMode == 2) //Added
                                    ACRange = Settings.GalvanostatI_Select2; //Added
                                if (AllSessions[EIS.RunningSession].EISACCurrentRangeMode == 3) //Added
                                    ACRange = Settings.GalvanostatI_Select3; //Added
                                Idata[iData] = EISGetIConvert(word, AllSessions[EIS.RunningSession].EISDCCurrentRangeModea, DEISCurrentImlp) / ACRange; //changed
                                
                                // Idata[iData] = EISGetIConvert(word, AllSessions[EIS.RunningSession].EISDCCurrentRangeMode, DEISCurrentImlp)/Math.Pow(11,AllSessions[EIS.RunningSession].EISACCurrentRangeMode);
                            }
                            iacmean = EISGetIConvert(iacmean, AllSessions[EIS.RunningSession].EISDCCurrentRangeModea, DEISCurrentImlp); //changed
                            
                            double[] Vparameters4 = new double[4];
                            double[] Iparameters4 = new double[4];
                            double[] IntVparameters4 = new double[4];
                            double[] IntIparameters4 = new double[4];
                            double RealI = 0, ImagI = 0, RealV = 0, ImagV = 0;
                            double[] tArray = new double[nData - 0];
                            double[] tArrayOriginal = new double[nData - 0];
                            int nFirstZone = 0;
                            double[] FirstZonetArray = new double[nData - 0];
                            double[] FirstZoneIData = new double[nData - 0];
                            double[] FirstZoneVData = new double[nData - 0];
                            double[] FirstZoneIntIData = new double[nData - 0];
                            double[] FirstZoneIntVData = new double[nData - 0];
                            // FindFittedImReImp(nData - 0, tPeriod, DigitalTimeInterval, Frequency, Vdata, ref Vparameters4, ref tArray, ref FittedtArray, ref FittedVdata, ref nFirstZone, ref FirstZonetArray, ref FirstZoneVData);
                            // FindFittedImReImp(nData - 0, tPeriod, DigitalTimeInterval, Frequency, Idata, ref Iparameters4, ref tArray, ref FittedtArray, ref FittedIdata, ref nFirstZone, ref FirstZonetArray, ref FirstZoneIData);
                            FindFittedImReImp(nData - 0, tPeriod, DigitalTimeInterval, Frequency, IntIdata, ref IntIparameters4, ref tArray, ref FittedtArray, ref FittedIntIdata, ref nFirstZone, ref FirstZonetArray, ref FirstZoneIntIData);
                            FindFittedImReImp(nData - 0, tPeriod, DigitalTimeInterval, Frequency, IntVdata, ref IntVparameters4, ref tArray, ref FittedtArray, ref FittedIntVdata, ref nFirstZone, ref FirstZonetArray, ref FirstZoneIntVData);
                            
                            if (((IntVparameters4[2] < 1900) || (IntVparameters4[2] > 2194)) && ((Math.Abs(IntVparameters4[0]) < 2000) && (Math.Abs(IntVparameters4[1]) < 2000)))
                            {
                               // System.Media.SystemSounds.Exclamation.Play();
                                Thread.Sleep(10);
                                Port.DiscardOutBuffer(); //Clear Buffer
                                Port.DiscardInBuffer(); //Clear Buffer
                                Port.Write("vaczero" + WriteReadToChar);
                                //Thread.Sleep(10);
                                ans = Port.ReadTo(ReadToChar);
                                if (ans != "OK") throw new Exception("The command OK is not received.\r error number:800002 Command:vaczero");
                                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " V_AC_zero ");
                                SetLabel(ref Label_ISelect, AllSessions[EIS.RunningSession].EISDCCurrentRangeModea);
                                Thread.Sleep(10);
                            }

                            if (((IntIparameters4[2] < 1900) || (IntIparameters4[2] > 2194)) && ((Math.Abs(IntIparameters4[0]) < 2000) && (Math.Abs(IntIparameters4[1]) < 2000)))
                            {
                                //  System.Media.SystemSounds.Question.Play();
                                //Izero(IntIparameters4[2]);
                                /*   Thread.Sleep(10);
                                   Port.DiscardOutBuffer();
                                   Port.DiscardInBuffer();
                                   Port.Write("aczero" + WriteReadToChar);
                                   //Thread.Sleep(10);
                                   ans = Port.ReadTo(ReadToChar);
                                   if (ans != "OK") throw new Exception("The command OK is not received.\r error number:800003 Command:aczero");*/
                                //DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " I_AC_zero ");
                                //     SetLabel(ref Label_ISelect, AllSessions[EIS.RunningSession].EISDCCurrentRangeModea);
                                //     Thread.Sleep(10);
                                Izero(iacmean);
                            }

                            double[] fztArray = new double[nData - 0];
                            double[] fzVdata = new double[nData - 0];
                            double[] fzIdata = new double[nData - 0];
                            double[] fzIntVdata = new double[nData - 0];
                            double[] fzIntIdata = new double[nData - 0];

                            DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " frq=" + Frequency.ToString() + " nFZ=" + nFirstZone.ToString());

                            FormEISDScope.UpdateEISDiagram(nData - 0, tArray, FittedtArray, IntVdata, IntIdata, FittedIntVdata, FittedIntIdata,
                                nFirstZone, FirstZonetArray, FirstZoneIntVData, FirstZoneIntIData);

                            for (int iData = 0; iData < nData - 0; iData++) tArrayOriginal[iData] = iData * DigitalTimeInterval;

                            FormEISDScope2.UpdateEISDiagram(nData - 0, tArrayOriginal, FittedtArray, IntVdata, IntIdata, FittedIntVdata, FittedIntIdata,
                                nFirstZone, FirstZonetArray, FirstZoneIntVData, FirstZoneIntIData);


                            RealV = EISGetVConvert(IntVparameters4[0] + 2047, DEISCurrentVmlp, AllSessions[EIS.RunningSession].EISVoltageRangeMode);
                            ImagV = EISGetVConvert(IntVparameters4[1] + 2047, DEISCurrentVmlp, AllSessions[EIS.RunningSession].EISVoltageRangeMode);

                            if (AllSessions[EIS.RunningSession].RelRef)
                            {
                                RealV = -RealV;
                                ImagV = -ImagV;
                            }

                            RealI = EISGetIConvert(IntIparameters4[0] + 2047, AllSessions[EIS.RunningSession].EISDCCurrentRangeModea, DEISCurrentImlp) / 1; //changed
                            ImagI = EISGetIConvert(IntIparameters4[1] + 2047, AllSessions[EIS.RunningSession].EISDCCurrentRangeModea, DEISCurrentImlp) / 1; //changed

                            if (AllSessions[EIS.RunningSession].RelRef)
                            {
                                RealI = -RealI;
                                ImagI = -ImagI;
                            }
                            //CorrectACIModeSelection(ref ImagI, AllSessions[EIS.RunningSession].EISACCurrentRangeMode);
                            //CorrectACIModeSelection(ref RealI, AllSessions[EIS.RunningSession].EISACCurrentRangeMode);

                            double abs = Math.Pow(RealI, 2) + Math.Pow(ImagI, 2);
                            double RealImp = (ImagI * ImagV + RealI * RealV) / abs;
                            double ImagImp = (RealI * ImagV - RealV * ImagI) / abs;

                            double SettingsITau_L = 0;
                            double SettingsITau_H = 0;

                            if (AllSessions[EIS.RunningSession].EISDCCurrentRangeModea == 0)
                            {
                                SettingsITau_L = 10;// Settings.ITau_L0;
                                SettingsITau_H = 0;// Settings.ITau_H0;
                            }
                            else if (AllSessions[EIS.RunningSession].EISDCCurrentRangeModea == 1)
                            {
                                SettingsITau_L = Settings.ITau_L1;
                                SettingsITau_H = Settings.ITau_H1;
                            }
                            else if (AllSessions[EIS.RunningSession].EISDCCurrentRangeModea == 2)
                            {
                                SettingsITau_L = Settings.ITau_L2;
                                SettingsITau_H = Settings.ITau_H2;
                            }
                            else if (AllSessions[EIS.RunningSession].EISDCCurrentRangeModea == 3)
                            {
                                SettingsITau_L = Settings.ITau_L0;
                                SettingsITau_H = Settings.ITau_H0;
                            }
                            double omega = 2 * Math.Acos(-1.0) * Frequency;
                            double CF0 = SettingsITau_L / Settings.VTau_L;

                            double absL = Math.Pow(SettingsITau_L * omega, 2) + 1;
                            double RealL = (1.0 + Settings.VTau_L * omega * SettingsITau_L * omega) / absL;
                            double ImagL = omega * (Settings.VTau_L - SettingsITau_L) / absL;

                            double absH = Math.Pow(SettingsITau_H * omega, 2) + 1;
                            double RealH = (1.0 + Settings.VTau_H * omega * SettingsITau_H * omega) / absH;
                            double ImagH = omega * (Settings.VTau_H - SettingsITau_H) / absH;

                            isIvalidtofit = isValidToFit(nData - 0, IntIdata, Settings.DEISMeanPercent + 10, Settings.DEISNOverFlow0, ref isINeedToAmp);
                            isVvalidtofit = isValidToFit(nData - 0, IntVdata, Settings.DEISMeanPercent, Settings.DEISNOverFlow0, ref isVNeedToAmp, ref TheLastAmplitude);
                            {
                                TheLastAmplitude = EISGetVConvert(TheLastAmplitude + 2047, DEISCurrentVmlp, AllSessions[EIS.RunningSession].EISVoltageRangeMode);
                                double VAmplitudeRMS = TheLastAmplitude / Math.Sqrt(2); //For show
                                SetLabel(ref Label_vac, VAmplitudeRMS, "V");

                                if (Ecount<5 && cnt > 0 && VAmplitudeRMS < EISVAmplitudeRMS/2)
                                {
                                    Ecount++;
                                    AllowToTick = true;
                                    ScrollToEnd();
                                   return;
                                }
                                Ecount = 0;
                                EISVAmplitudeRMS = VAmplitudeRMS;
                            }
                            //validity
                            if ((isIvalidtofit && isVvalidtofit && (!isNeedToCorrect && AllSessions[EIS.RunningSession].EISACRegulatorMode == 0)) ||
                                (isIvalidtofit && isVvalidtofit && (AllSessions[EIS.RunningSession].EISACRegulatorMode == 1)))
                            {
                                ///////////////
                                EISAverageNumberCounter++;
                                if ((EISAverageNumberCounter >= AllSessions[EIS.RunningSession].EISAverageNumberL && (Frequency <= 10.0)) ||
                                    (EISAverageNumberCounter >= AllSessions[EIS.RunningSession].EISAverageNumberH && (Frequency > 10.0)))
                                {

                                    EISRealImpMean = EISRealImpMean + RealImp / EISAverageNumberCounter;
                                    EISImagImpMean = EISImagImpMean + ImagImp / EISAverageNumberCounter;
                                    AllSessionsData[EIS.RunningSession].ReZ[cnt] = EISRealImpMean;
                                    AllSessionsData[EIS.RunningSession].Imz[cnt] = EISImagImpMean;
                                    //AllSessionsData[EIS.RunningSession].overflow[cnt] = false;

                                    EISAverageNumberCounter = 0;
                                    EISRealImpMean = 0;
                                    EISImagImpMean = 0;

                                    //  UpdateOutputsVAndI(DEISCurrentVmlp, DEISCurrentImlp, AllSessions[EIS.RunningSession].EISDCCurrentRangeMode);

                                    AllSessionsData[EIS.RunningSession].ReceivedDataCount++;
                                    PBAllSessionsValue++;
                                    SetPBAllSessions(PBAllSessionsValue);
                                    isDigitalEISStepCompleted = true;
                                    isFrequencyChanged = true;
                                    DigitalEISTimer.Interval = DigitalEISTimerMinInterval;
                                    int NItteration = AllSessions[EIS.RunningSession].ACFrqNStep;
                                    ////////////////////////// mott-shotkey
                                    if (AllSessions[EIS.RunningSession].Mode == 1)
                                    {
                                        NItteration = AllSessions[EIS.RunningSession].DCVoltageStep;
                                        double vlt = AllSessions[EIS.RunningSession].DCVoltageFrom + cnt * frqMultStep;
                                        if (AllSessions[EIS.RunningSession].RelRef) vlt = -vlt;
                                        double readcurrent=0, readvoltage=0;
                                        mottnextvoltage(vlt,ref readvoltage,ref readcurrent);
                                        AllSessionsData[EIS.RunningSession].Vlt[cnt] = -vlt;
                                        AllSessionsData[EIS.RunningSession].Amp[cnt] = readcurrent;
                                        SetLabel(ref Label_idc, readcurrent, "A");
                                        SetLabelJustForVoltage(ref Label_vdc, readvoltage, "V");
                                        SetLabelJustForVoltage(ref Label_vdc_real,-vlt , "V");
                                    }
                                    ////////////////////////////////////////
                                    if (AllSessionsData[EIS.RunningSession].ReceivedDataCount == NItteration)
                                    {
                                        if (isDigitalEISTimerTickSet)
                                        {
                                            DigitalEISTimer.Stop();
                                            DigitalEISTimer.Dispose();
                                            isDigitalEISTimerTickSet = false;
                                        }
                                        AllSessions[EIS.RunningSession].isFinished = true;

                                        if (AllSessions[EIS.RunningSession].isChBPostProcProbOff)
                                        {
                                            if (isProbOn)
                                            {
                                                SampleOnBtn_Click(null, null);
                                            }
                                        }
                                        else
                                        {
                                            try
                                            {
                                                int iVlt = SetDCVConvert(AllSessions[EIS.RunningSession].IdealVoltage, AllSessions[EIS.RunningSession].IVVoltageRangeMode, AllSessions[EIS.RunningSession].IVCurrentRangeMode, AllSessions[EIS.RunningSession].PGmode);
                                                Port.DiscardOutBuffer(); //Clear Buffer
                                                Port.DiscardInBuffer(); //Clear Buffer
                                                Port.Write("ivset " + iVlt.ToString() + ReadToChar);
                                                Port.Write(WriteReadToChar);
                                                //Thread.Sleep(100);
                                                byte[] AllBytes11 = new byte[4];
                                                byte[] AllBytes22 = new byte[4];
                                                AllBytes11[0] = (byte)Port.ReadByte();
                                                AllBytes11[1] = (byte)Port.ReadByte();
                                                AllBytes11[2] = (byte)Port.ReadByte();
                                                AllBytes11[3] = (byte)Port.ReadByte();
                                                AllBytes22[0] = (byte)Port.ReadByte();
                                                AllBytes22[1] = (byte)Port.ReadByte();
                                                AllBytes22[2] = (byte)Port.ReadByte();
                                                AllBytes22[3] = (byte)Port.ReadByte();
                                            }
                                            catch { if (ans != "OK") throw new Exception("The command OK is not received.\r error number:800003 Command:ivset"); }
                                        }
                                        tryNextRun();
                                    }

                                }
                                else
                                {
                                    if (Frequency <= 10.0)
                                    {
                                        EISRealImpMean = EISRealImpMean + RealImp / AllSessions[EIS.RunningSession].EISAverageNumberL;
                                        EISImagImpMean = EISImagImpMean + ImagImp / AllSessions[EIS.RunningSession].EISAverageNumberL;
                                    }
                                    else
                                    {
                                        EISRealImpMean = EISRealImpMean + RealImp / AllSessions[EIS.RunningSession].EISAverageNumberH;
                                        EISImagImpMean = EISImagImpMean + ImagImp / AllSessions[EIS.RunningSession].EISAverageNumberH;
                                    }
                                    isDigitalEISStepCompleted = true;
                                    //isFrequencyChanged = true;
                                }
                            }
                            else
                            {//validity_I !(isThisTheBestImlp>=2) &&
                                if (!isIvalidtofit)
                                {
                                    int Newmlp = -2;
                                    if (isINeedToAmp)
                                    {
                                        if (DEISCurrentImlp < AllSessions[EIS.RunningSession].EISImlpMax)
                                        {
                                            Newmlp = DEISCurrentImlp + 1;
                                            isIAmpApplyed = true;
                                        }
                                        else
                                        {
                                            int IDCSelectMax = EISMaxIDCSelect;
                                            //changed
                                            if (Frequency > 1000000.0)
                                            {
                                                IDCSelectMax = Math.Min(2, EISMaxIDCSelect);
                                                if (AllSessions[EIS.RunningSession].EISDCCurrentRangeModea > IDCSelectMax) AllSessions[EIS.RunningSession].EISDCCurrentRangeModea = IDCSelectMax;
                                            }

                                            if (AllSessions[EIS.RunningSession].EISDCCurrentRangeModea < IDCSelectMax)
                                            {
                                                Newmlp = 0;

                                                int PreviuseDCISelect = AllSessions[EIS.RunningSession].EISDCCurrentRangeModea;
                                                AllSessions[EIS.RunningSession].EISDCCurrentRangeModea++;
                                                Port.DiscardOutBuffer();
                                                Port.DiscardInBuffer();
                                                Port.Write("idcmlp " + Newmlp.ToString() + WriteReadToChar);
                                                ans = Port.ReadTo(ReadToChar);
                                                if (ans != "OK") throw new Exception("The command OK is not received.\r error number:800004 Command:idcmlp");
                                                EISMotLast_idcmlp = Newmlp;

                                                Port.DiscardOutBuffer();
                                                Port.DiscardInBuffer();
                                                Port.Write("idcselect " + AllSessions[EIS.RunningSession].EISDCCurrentRangeModea.ToString() + WriteReadToChar);
                                                //Thread.Sleep(20);
                                                ans = Port.ReadTo(ReadToChar);
                                                if (ans != "OK") throw new Exception("The command OK is not received.\r error number:800005 Command:idcselect");
                                                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " change idcselect from " + PreviuseDCISelect.ToString() + " to " + AllSessions[EIS.RunningSession].EISDCCurrentRangeModea.ToString());
                                                SetLabel(ref Label_ISelect, AllSessions[EIS.RunningSession].EISDCCurrentRangeModea);
                                                Thread.Sleep(100);

                                                SetIVFilter(AllSessions[EIS.RunningSession].EISfilterMode, tPeriod, AllSessions[EIS.RunningSession].EISDCCurrentRangeModea, AllSessions[EIS.RunningSession].EISVoltageRangeMode);
                                                isIAmpApplyed = true;

                                            }
                                            else
                                                Newmlp = 8;
                                            /*if (DEISCurrentImlp == 7)
                                            {
                                                Newmlp = 0;
                                                isIAmpApplyed = true;
                                            }
                                            else
                                                Newmlp = 8;*/
                                        }

                                        //   isThisTheBestImlp = 0;
                                    }
                                    else
                                    {
                                        if (isIAmpApplyed) isThisTheBestImlp += 1;

                                        if (DEISCurrentImlp > 0)
                                            Newmlp = DEISCurrentImlp - 1;
                                        else
                                        {
                                            if (AllSessions[EIS.RunningSession].EISDCCurrentRangeModea > 0)
                                            {
                                                Newmlp = AllSessions[EIS.RunningSession].EISImlpMax;

                                                int PreviuseDCISelect = AllSessions[EIS.RunningSession].EISDCCurrentRangeModea;
                                                AllSessions[EIS.RunningSession].EISDCCurrentRangeModea--;
                                                Port.DiscardOutBuffer(); //Clear Buffer
                                                Port.DiscardInBuffer(); //Clear Buffer
                                                Port.Write("idcselect " + AllSessions[EIS.RunningSession].EISDCCurrentRangeModea.ToString() + WriteReadToChar);
                                                Thread.Sleep(10);
                                                ans = Port.ReadTo(ReadToChar);
                                                if (ans != "OK") throw new Exception("The command OK is not received.\r error number:800006 Command:idcselect");
                                                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " change idcselect from " + PreviuseDCISelect.ToString() + " to " + AllSessions[EIS.RunningSession].EISDCCurrentRangeModea.ToString());
                                                SetLabel(ref Label_ISelect, AllSessions[EIS.RunningSession].EISDCCurrentRangeModea);

                                                SetIVFilter(AllSessions[EIS.RunningSession].EISfilterMode, tPeriod, AllSessions[EIS.RunningSession].EISDCCurrentRangeModea, AllSessions[EIS.RunningSession].EISVoltageRangeMode);
                                                isIAmpApplyed = true;
                                            }
                                            else
                                                Newmlp = -1;
                                            /*if (DEISCurrentImlp == 0)
                                                Newmlp = 7;
                                            else
                                                Newmlp = -1;*/
                                        }

                                        isIAmpApplyed = false;
                                    }

                                    if (Newmlp > -1 && Newmlp != 8)
                                    {
                                        LabelIwar.Visible = false;

                                        Port.DiscardOutBuffer(); //Clear Buffer
                                        Port.DiscardInBuffer(); //Clear Buffer
                                        Port.Write("idcmlp " + Newmlp.ToString() + WriteReadToChar);
                                        //Thread.Sleep(10);
                                        ans = Port.ReadTo(ReadToChar);
                                        if (ans != "OK") throw new Exception("The command OK is not received.\r error number:800007 Command:idcmlp");
                                        SetLabel(ref Label_Imlp, Newmlp);
                                        EISMotLast_idcmlp = Newmlp;

                                        OldDEISCurrentImlp = DEISCurrentImlp;
                                        DEISCurrentImlp = Newmlp;
                                        if (Newmlp == 0)
                                        {
                                            Port.DiscardOutBuffer(); //Clear Buffer
                                            Port.DiscardInBuffer(); //Clear Buffer
                                            Port.Write("aczero" + WriteReadToChar);
                                            //Thread.Sleep(10);
                                            ans = Port.ReadTo(ReadToChar);
                                            if (ans != "OK") throw new Exception("The command OK is not received.\r error number:800008 Command:aczero");
                                            DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " I_AC_zero ");
                                            SetLabel(ref Label_ISelect, AllSessions[EIS.RunningSession].EISDCCurrentRangeModea);
                                        }
                                    }
                                    else
                                    {
                                        if (Newmlp == 8) LabelIwar.Text = "Warning: Weak Signal detected in I(t)...";
                                        if (Newmlp == -1) LabelIwar.Text = "Warning: Overflow detected in I(t) ...";
                                        AllSessionsData[EIS.RunningSession].overflow[cnt] = true;
                                        LabelIwar.Visible = true;
                                        isThisTheBestImlp = 2;
                                    }
                                }

                                if (!isVvalidtofit)
                                {
                                    int Newmlp = -2;
                                    if (isVNeedToAmp)
                                    {
                                        if (DEISCurrentVmlp < AllSessions[EIS.RunningSession].EISVmlpMax)
                                        {
                                            Newmlp = DEISCurrentVmlp + 1;
                                            isVAmpApplyed = true;
                                        }
                                        else
                                        {
                                            if (DEISCurrentVmlp == 7)
                                            {
                                                Newmlp = 0;
                                                isVAmpApplyed = true;
                                            }
                                            else
                                                Newmlp = 8;
                                        }
                                        //   isThisTheBestVmlp = 0;
                                    }
                                    else
                                    {
                                        if (isVAmpApplyed) isThisTheBestVmlp += 1;
                                        if (DEISCurrentVmlp > 0 && DEISCurrentVmlp != 7)
                                            Newmlp = DEISCurrentVmlp - 1;
                                        else
                                        {
                                            if (DEISCurrentVmlp == 0)
                                                Newmlp = 7;
                                            else
                                                Newmlp = -1;

                                        }
                                        isVAmpApplyed = false;
                                    }

                                    if (Newmlp > -1 && Newmlp != 8)
                                    {
                                        LabelVwar.Visible = false;

                                        Port.DiscardOutBuffer();
                                        Port.DiscardInBuffer();
                                        Port.Write("vdcmlp " + Newmlp.ToString() + WriteReadToChar);
                                        //Thread.Sleep(100);
                                        ans = Port.ReadTo(ReadToChar);
                                        if (ans != "OK") throw new Exception("The command OK is not received.\r error number:800009 Command:vdcmlp");
                                        SetLabel(ref Label_Vmlp, Newmlp);
                                        EISMotLast_vdcmlp = Newmlp;

                                        OldDEISCurrentVmlp = DEISCurrentVmlp;
                                        DEISCurrentVmlp = Newmlp;
                                    }
                                    else
                                    {
                                        if (Newmlp == 8) LabelVwar.Text = "Warning: Weak Signal detected in V(t)...";
                                        if (Newmlp == -1) LabelVwar.Text = "Warning: Overflow detected in V(t) ...";
                                        AllSessionsData[EIS.RunningSession].overflow[cnt] = true;
                                        LabelVwar.Visible = true;
                                        isThisTheBestVmlp = 2;
                                    }
                                }

                                if (isVvalidtofit && isNeedToCorrect && (AllSessions[EIS.RunningSession].EISACRegulatorMode == 0))
                                {
                                    double VAmplitude = Math.Abs(TheLastAmplitude);
                                    double VAmplitudeRMS = VAmplitude / Math.Sqrt(2); //For show
                                    if (VAmplitude == 0) VAmplitude = 0.00001;
                                    double NeedVAmplitude = AllSessions[EIS.RunningSession].ACAmpConstant * Math.Sqrt(2);
                                    double CurrentDigitalEIS_VAC_amp = CurrentDigitalEIS_VAC_RMS * Math.Sqrt(2);
                                    double NewSetVAmplitude = CurrentDigitalEIS_VAC_amp * NeedVAmplitude / VAmplitude;
                                    CurrentDigitalEIS_VAC_RMS = NewSetVAmplitude / Math.Sqrt(2);
                                    int iCurrentDigitalEIS_VAC_RMS = SetACVoltageConvert(CurrentDigitalEIS_VAC_RMS * 5.0 / 4.0, AllSessions[EIS.RunningSession].EISVoltageRangeMode);

                                    //if (iCurrentDigitalEIS_VAC_RMS != oldiCurrentDigitalEIS_VAC_RMS && (VAmplitude < 0.7 * NeedVAmplitude || VAmplitude > 1.3 * NeedVAmplitude))
                                    if (iCurrentDigitalEIS_VAC_RMS != oldiCurrentDigitalEIS_VAC_RMS)
                                    {
                                        Port.DiscardOutBuffer(); //Clear Buffer
                                        Port.DiscardInBuffer(); //Clear Buffer
                                        Port.Write("acset " + iCurrentDigitalEIS_VAC_RMS.ToString() + WriteReadToChar);
                                        //Thread.Sleep(100);
                                        ans = Port.ReadTo(ReadToChar);
                                        if (ans != "OK") throw new Exception("The command OK is not received.\r error number:800010 Command:acset");
                                        oldiCurrentDigitalEIS_VAC_RMS = iCurrentDigitalEIS_VAC_RMS;
                                        DebugListBox.Items.Add("stp: " + DebugListBox.Items.Count.ToString() + " Regulator Changed the Voltage ...");
                                        //SetLabel(ref iLabel_vac, iCurrentDigitalEIS_VAC_RMS);
                                        //SetLabel(ref Label_vac, VAmplitudeRMS, "V");
                                    }
                                    isThisTheBestVmlp = 0;
                                    isNeedToCorrect = false;
                                }

                                isDigitalEISStepCompleted = true;
                            }

                            if (!isDigitalEISStepCompleted)
                            {
                                if (isIvalidtofit) DigitalEISStepUnSuccessCounter++;
                                if (DigitalEISStepUnSuccessCounter > 50) StopRun();
                            }
                            else
                            {
                                DigitalEISStepUnSuccessCounter = 0;
                            }

                        }
                        else
                        {

                        }
                    }
                }
                AllowToTick = true;
                ScrollToEnd();
            }
            catch (Exception ex)
            {
                //StopRun();
                //MessageBox.Show("Run is Stoped because of error:\r" + ex.Message + "\rin Function:DigitalEISTimer_Tick()");
            }
        }
        private void mottnextvoltage(double volt,ref double TheVoltageisset, ref double current)
        {
            string ans;
            int iselect;
            iselect = AllSessions[EIS.RunningSession].EISDCCurrentRangeModea;
            {
               // try
                {
                       Port.DiscardOutBuffer();
                       Port.DiscardInBuffer();
                       Port.Write("vdcmlp 0" + WriteReadToChar);
                       Thread.Sleep(100);
                       ans = Port.ReadTo(ReadToChar);
                   ////    if (ans != "OK") throw new Exception("The command OK is not received.\r error number:800009 Command:vdcmlp");

                       Port.DiscardOutBuffer();
                       Port.DiscardInBuffer();
                       Port.Write("idcmlp 0" + WriteReadToChar);
                       ans = Port.ReadTo(ReadToChar);
                    //    if (ans != "OK") throw new Exception("The command OK is not received.\r error number:800004 Command:idcmlp");

                    Port.DiscardOutBuffer();
                    Port.DiscardInBuffer();
                    Port.Write("idcselect 2"+ WriteReadToChar);
                    ans = Port.ReadTo(ReadToChar);
                    Thread.Sleep(200);
                    /*    Port.Write("DCpreset" + ReadToChar);
                        Port.ReadLine();
                        Port.DiscardOutBuffer();
                        Port.DiscardInBuffer();*/
                    // EISMaxIDCSelect = FindTheBestIDCSelectForChrono(vlt, AllSessions[EIS.RunningSession].EISVoltageRangeMode, AllSessions[EIS.RunningSession].EISDCCurrentRangeModea, AllSessions[EIS.RunningSession].PGmode);
                    int iVlt = SetDCVConvert(volt, AllSessions[EIS.RunningSession].EISVoltageRangeMode, AllSessions[EIS.RunningSession].EISDCCurrentRangeModea, AllSessions[EIS.RunningSession].PGmode);
                    byte[] AllBytes1 = new byte[4];
                    byte[] AllBytes2 = new byte[4]; int word;
                    Port.DiscardOutBuffer();
                    Port.DiscardInBuffer();
                    Port.Write("ivset " + iVlt.ToString() + ReadToChar);
                    Port.Write(WriteReadToChar);
                    Thread.Sleep(200);


                    AllBytes1[0] = (byte)Port.ReadByte();
                    AllBytes1[1] = (byte)Port.ReadByte();
                    AllBytes1[2] = (byte)Port.ReadByte();
                    AllBytes1[3] = (byte)Port.ReadByte();
                    AllBytes2[0] = (byte)Port.ReadByte();
                    AllBytes2[1] = (byte)Port.ReadByte();
                    AllBytes2[2] = (byte)Port.ReadByte();
                    AllBytes2[3] = (byte)Port.ReadByte();

                    //Thread.Sleep(400);

                    Port.DiscardOutBuffer();
                    Port.DiscardInBuffer();
                    Port.Write("ivset " + iVlt.ToString() + ReadToChar);
                    Port.Write(WriteReadToChar);
                    //Thread.Sleep(200);
                    AllBytes1[0] = (byte)Port.ReadByte();
                    AllBytes1[1] = (byte)Port.ReadByte();
                    AllBytes1[2] = (byte)Port.ReadByte();
                    AllBytes1[3] = (byte)Port.ReadByte();
                    AllBytes2[0] = (byte)Port.ReadByte();
                    AllBytes2[1] = (byte)Port.ReadByte();
                    AllBytes2[2] = (byte)Port.ReadByte();
                    AllBytes2[3] = (byte)Port.ReadByte();
                    Thread.Sleep(50);
                    Port.Write("ACpreset" + ReadToChar);
                    Port.ReadLine();
                    Port.DiscardOutBuffer();
                    Port.DiscardInBuffer();
                    Port.Write("iacdac " + iacdac.ToString() + WriteReadToChar);
                    Port.DiscardOutBuffer();
                    Port.DiscardInBuffer();
                    Thread.Sleep(250);
                    ans = Port.ReadTo(ReadToChar);
                    //Izero(0);
                    /*   Port.Write("aczero" + WriteReadToChar);
                       Thread.Sleep(100);
                       ans = Port.ReadTo(ReadToChar);
                       if (ans != "OK") throw new Exception("The command OK is not received.\r error number:100009 Command:aczero");
                       DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " AC_zero ");
                       Thread.Sleep(10);
                       Port.DiscardOutBuffer(); //Clear Buffer
                       Port.DiscardInBuffer(); //Clear Buffer
                       Port.Write("aczero" + WriteReadToChar);
                       Thread.Sleep(100);
                       ans = Port.ReadTo(ReadToChar);
                       if (ans != "OK") throw new Exception("The command OK is not received.\r error number:100009 Command:aczero");
                       DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " AC_zero ");*/
                    //Thread.Sleep(100);
                    int nData = IVnData;
                    word = AllBytes1[0] | (AllBytes1[1] << 8) | (AllBytes1[2] << 16) | (AllBytes1[3] << 24);
                    double Vmean = (double)word / (double)nData;

                    word = AllBytes2[0] | (AllBytes2[1] << 8) | (AllBytes2[2] << 16) | (AllBytes2[3] << 24);
                    double Imean = (double)word / (double)nData; 
                    //FormEISDScope.UpdateIVDiagram(IVnDataTotal, IVtDataTotal, IVVDataTotal, IVIDataTotal);

                    TheVoltageisset = GetDCVConvertWithNewOffset(Vmean, 0, ThisIV_Voffset, AllSessions[EIS.RunningSession].EISVoltageRangeMode);

                    current = GetDCIConvertWithNewOffset(Imean, 2, 0, ThisIV_Ioffset);
                    //GetDCIConvert(Imean, 2, 0);
                    if (AllSessions[EIS.RunningSession].RelRef)
                    {
                        TheVoltageisset = -TheVoltageisset;
                        current = -current;
                    }

                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " The Voltage is set:" + TheVoltageisset.ToString());
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " iImean=" + Imean.ToString() + " I=" + current.ToString());

                   
                   
                                                            Port.DiscardOutBuffer();
                                                            Port.DiscardInBuffer();
                                                            Port.Write("vdcmlp " + EISMotLast_vdcmlp.ToString() + WriteReadToChar);
                                                            Thread.Sleep(100);
                                                            ans = Port.ReadTo(ReadToChar);
                                                            if (ans != "OK") throw new Exception("The command OK is not received.\r error number:800009 Command:vdcmlp");

                                                            Port.DiscardOutBuffer();
                                                            Port.DiscardInBuffer();
                                                            Port.Write("idcmlp " + EISMotLast_idcmlp.ToString() + WriteReadToChar);
                                                            ans = Port.ReadTo(ReadToChar);
                                                            if (ans != "OK") throw new Exception("The command OK is not received.\r error number:800004 Command:idcmlp");

                    Port.DiscardOutBuffer();
                    Port.DiscardInBuffer();
                    Port.Write("idcselect " + iselect.ToString() + WriteReadToChar);
                    ans = Port.ReadTo(ReadToChar);
                    Thread.Sleep(200);
                    //iselect = AllSessions[EIS.RunningSession].EISDCCurrentRangeModea;
                    //  Thread.Sleep(1000);
                }
             //   catch { if (ans != "OK") throw new Exception("The command OK is not received.\r error number:8000011 Command:ivset"); }
            }

        }//
        private void Izero(double i)
        {

            int iIsv=iIs;
            double domain,domain5;
            domain5 = 4.5 + iIschanged/3.0;
            string ans;
            i_zero += i;
            if (Math.Abs(i_zero) < (domain5 / 10000000))
            {
                iIs = 3;
                domain = 4096.0 * 1000000;
            }
            else if (Math.Abs(i_zero) < (domain5 / 100000))
            {
                iIs = 2;
                domain = 4096.0 * 10000;
            }
            else if (Math.Abs(i_zero) < (domain5 / 1000))
            {
                iIs = 1;
                domain = 4096.0 * 100;
            }
            else
            {
                iIs = 0;
                domain = 4096.0 * 2.2;
            }

            iacdac = (int)(i_zero * domain + 2047);
            if (iacdac > 4095) iacdac = 4095;
            if (iacdac < 0) iacdac = 0;

            if (iIs == iIsv) iIschanged = 0;
            else if (iIs > iIsv) iIschanged = 1;
            else if (iIs < iIsv) iIschanged = -1;
            Port.DiscardOutBuffer();
            Port.DiscardInBuffer();
            Port.Write("iacdac " + iacdac.ToString() + WriteReadToChar);
            Thread.Sleep(100);
            ans = Port.ReadTo(ReadToChar);
             Port.DiscardOutBuffer();
             Port.DiscardInBuffer();
            Port.Write("iIs " + iIs.ToString() + WriteReadToChar);
            Thread.Sleep(100);
            ans = Port.ReadTo(ReadToChar);
            SetLabel(ref label_iIs, iIs);
            Thread.Sleep(10);
        }
        private void SetIVFilter(int EISfilterMode, double tPeriod, int EISDCCurrentRangeMode, int EISVoltageRangeMode)
        {
            //return;
            int IFilter;
            int VFilter;
            int postfilter;
            double tPeriodMicro = 1000000.0 * tPeriod;
            double tPeriodMicroPF = tPeriodMicro/100;
            if (tPeriodMicroPF <= 1000)
                postfilter = 0;
            else if (tPeriodMicroPF > 1000 && tPeriodMicroPF <= 10000)
                postfilter = 1;
            else if (tPeriodMicroPF > 10000 && tPeriodMicroPF <= 100000)
                postfilter = 2;
            else
                postfilter = 3;
           // postfilter = 0;
            if (EISfilterMode == 0)
            {
                double R;
                if (EISVoltageRangeMode == 0) R = 5.0; //5 k
                else R = 1.0; //1 k
                double C_V = tPeriodMicro / Math.Acos(-1.0) / R / 20;
                if (C_V <= Form1.Settings.FilterC_V1)
                    VFilter = 0;
                else if (C_V > Form1.Settings.FilterC_V1 && C_V <= (Form1.Settings.FilterC_V1 * 10))
                    VFilter = 1;
                else if (C_V > (Form1.Settings.FilterC_V1 * 10) && C_V <= (Form1.Settings.FilterC_V1 * 100))
                    VFilter = 2;
                else if (C_V > (Form1.Settings.FilterC_V1 * 100) && C_V <= (Form1.Settings.FilterC_V1 * 1000))
                    VFilter = 3;
                else
                    VFilter = 4;
               // VFilter = 0;
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " idcmlp:0");

                if (EISDCCurrentRangeMode == 0) R = Settings.GetDCI_Select0;
                else if (EISDCCurrentRangeMode == 1) R = Settings.GetDCI_Select1;
                else if (EISDCCurrentRangeMode == 2) R = Settings.GetDCI_select2;
                else if (EISDCCurrentRangeMode == 3) R = Settings.GetDCI_Select3;
                else if (EISDCCurrentRangeMode == 4) R = Settings.GetDCI_Select4;
                else if (EISDCCurrentRangeMode == 5) R = Settings.GetDCI_Select5;
                else if (EISDCCurrentRangeMode == 6) R = Settings.GetDCI_Select6;
                else if (EISDCCurrentRangeMode == 7) R = Settings.GetDCI_Select7;
                double C_I = 100.0 * (tPeriodMicro-0.1) / R /100; //1000.0 * tPeriodMicro / R / 10;
                if (C_I <= Form1.Settings.FilterC_I1)
                    IFilter = 0;
                else if (C_I > Form1.Settings.FilterC_I1 && C_I < Form1.Settings.FilterC_I2)
                    IFilter = 1;
                else
                    IFilter = 2;
                SetLabel(ref Label_Filter_C_V, C_V, "nF");
                SetLabel(ref Label_Filter_C_I, C_I, "nF");

            }
            else
            {
                IFilter = 0;
                VFilter = 1;
                Label_Filter_C_V.Text = "-------";
                Label_Filter_C_I.Text = "-------";
            }
            
            Port.DiscardOutBuffer(); //Clear Buffer
            Port.DiscardInBuffer(); //Clear Buffer
            Port.Write("vfilter " + VFilter.ToString() + WriteReadToChar);
            Thread.Sleep(100);
            string ans = Port.ReadTo(ReadToChar);
            Port.DiscardOutBuffer(); //Clear Buffer
            Port.DiscardInBuffer(); //Clear Buffer
            if (ans == "OK")
            {
                if (ans == "OK") DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " VFilter: " + VFilter.ToString());
                SetLabel(ref Label_VFilter, VFilter);
            }
            else
                StopRun();

            Port.DiscardOutBuffer(); //Clear Buffer
            Port.DiscardInBuffer(); //Clear Buffer
            Port.Write("postfilter " + postfilter.ToString() + WriteReadToChar);
            Thread.Sleep(100);
             ans = Port.ReadTo(ReadToChar);
            Port.DiscardOutBuffer(); //Clear Buffer
            Port.DiscardInBuffer(); //Clear Buffer
            if (ans == "OK")
            {
                if (ans == "OK") DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " postfilter: " + postfilter.ToString());
                SetLabel(ref label_postfilter, postfilter);
            }
            else
                StopRun();

            Port.DiscardOutBuffer(); //Clear Buffer
            Port.DiscardInBuffer(); //Clear Buffer
            Port.Write("idcfilter " + IFilter.ToString() + WriteReadToChar);
            Thread.Sleep(100);
            ans = Port.ReadTo(ReadToChar);
            Port.DiscardOutBuffer(); //Clear Buffer
            Port.DiscardInBuffer(); //Clear Buffer
            if (ans == "OK")
            {
                if (ans == "OK") DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " IFilter: " + IFilter.ToString());
                SetLabel(ref Label_IFilter, IFilter);
            }
            else
                StopRun();
        }

        private void ScrollToEnd()
        {
            DebugListBox.SelectedIndex = DebugListBox.Items.Count - 1;
        }

        private void UpdateOutputsVAndI(int ThisVmlp, int ThisImlp, int ThisCurrentRangeMode)
        {
            try
            {
                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer
                Port.Write("dcget" + ReadToChar);
                Port.Write(WriteReadToChar);
                Thread.Sleep(100);

                try
                {
                    int nData = IVnData;
                    int[,] AllBytes = new int[nData, 4];
                    int word;

                    for (int iData = 0; iData < nData; iData++)
                    {
                        AllBytes[iData, 0] = Port.ReadByte();
                        AllBytes[iData, 1] = Port.ReadByte();
                        AllBytes[iData, 2] = Port.ReadByte();
                        AllBytes[iData, 3] = Port.ReadByte();
                    }

                    double Vmean = 0;
                    double Imean = 0;

                    //skip first data
                    for (int iData = 1; iData < nData; iData++)
                    {
                        word = AllBytes[iData, 0] + AllBytes[iData, 1] * 256;
                        if (!Settings.IsIVReceiverUnsigned)
                        {
                            if (word >= 0 && word < 2048)
                                word = word + 2048;
                            else
                                word = word - 2048 - 61440;
                        }
                        double newV = GetDCVConvert(word, ThisVmlp, AllSessions[EIS.RunningSession].EISVoltageRangeMode);
                        Vmean = Vmean + newV;
                        
                        word = AllBytes[iData, 2] + AllBytes[iData, 3] * 256;
                        if (!Settings.IsIVReceiverUnsigned)
                        {
                            if (word >= 0 && word < 2048)
                                word = word + 2048;
                            else
                                word = word - 2048 - 61440;
                        }
                        double newI = GetDCIConvert(word, ThisCurrentRangeMode, ThisImlp);
                        Imean = Imean + newI;
                    }

                    double DCV = Vmean / (nData - 1);
                    double DCI = Imean / (nData - 1);
                    SetLabelJustForVoltage(ref Label_vdc, DCV, "V");
                    SetLabel(ref Label_idc, DCI, "A");
                }
                catch { }
            }
            catch { }

        }

        private bool isValidToFit(int nData, double[] IntIdata, double MeanPercent, int NOverFlow, ref bool isNeedToAmp)
        {
            bool isvalid = true;
            double[] IntIdataS = new double[nData];
            
            int nOver1 = 0;
            //for (int iData = 0; iData < nData; iData++) if (IntIdata[iData] == 0) nOver1++;
            int nOver2 = 0;
            for (int iData = 0; iData < nData; iData++)
            {
                IntIdataS[iData] = IntIdata[iData];
                if (IntIdata[iData] == 0) nOver1++;
                if (IntIdata[iData] == 4095) nOver2++;
            }

            if (nOver1 > NOverFlow || nOver2 > NOverFlow)
            {
                isNeedToAmp = false;
                isvalid = false;
            }
            
            if (isvalid)
            {
                Array.Sort(IntIdataS);
                double meanval = 0.0;
                for (int iData = 0; iData < nData; iData++) meanval = meanval + (double)IntIdata[iData] / (double)nData;
                double minval = (double)IntIdataS[9];
             //   for (int iData = 1; iData < nData; iData++) if (minval > IntIdata[iData]) minval = IntIdata[iData];

                double maxval = (double)IntIdataS[nData - 9];
               // for (int iData = 1; iData < nData; iData++) if (maxval < IntIdata[iData]) maxval = IntIdata[iData];
                double DataAmp = Math.Max(maxval - meanval, meanval - minval);
                double MaxAmp = Math.Min(4095.0 - meanval, meanval);
                if (DataAmp < MeanPercent * MaxAmp / 100.0)
                {
                    isvalid = false;
                    isNeedToAmp = true;
                    if (isThisTheBestImlp >= 2) isvalid = true;
                }
            }

            return isvalid;
        }


        private bool isValidToFit(int nData, double[] IntIdata, double MeanPercent, int NOverFlow, ref bool isNeedToAmp, ref double amplitude)
        {
            bool isvalid = true;
            double[] IntIdataS = new double[nData];
            
            int nOver1 = 0;int nOver2 = 0;
            for (int iData = 0; iData < nData; iData++)
            {
                IntIdataS[iData] = IntIdata[iData];
                if (IntIdata[iData] == 0) nOver1++;
                if (IntIdata[iData] == 4095) nOver2++;
            }
            //for (int iData = 0; iData < nData; iData++) 

            if (nOver1 > NOverFlow || nOver2 > NOverFlow)
            {
                isNeedToAmp = false;
                isvalid = false;
            }
            Array.Sort(IntIdataS);
            double meanval = 0.0;
            for (int iData = 0; iData < nData; iData++) meanval = meanval + (double)IntIdata[iData] / (double)nData;
            double minval = (double)IntIdataS[9];
          //  for (int iData = 1; iData < nData; iData++) if (minval > IntIdata[iData]) minval = IntIdata[iData];
            double maxval = (double)IntIdataS[nData - 9];
          //  for (int iData = 1; iData < nData; iData++) if (maxval < IntIdata[iData]) maxval = IntIdata[iData];
            double DataAmp = Math.Max(maxval - meanval, meanval - minval);
            amplitude = DataAmp;

            if (isvalid)
            {
                double MaxAmp = Math.Min(4095.0 - meanval, meanval);
                if (DataAmp < MeanPercent * MaxAmp / 100.0)
                {
                    isvalid = false;
                    isNeedToAmp = true;
                    if (isThisTheBestVmlp >= 2) isvalid = true;
                }
            }

            return isvalid;
        }


        private void FindFittedImReImp(int nData, double tPeriod, double DigitalTimeInterval, double Frequency, double[] data, ref double[] parameters4, ref double[] tArrayforplot, ref double[] FittedtArray, ref double[] FittedData, ref int nFirstZone, ref double[] FirstZonetArray, ref double[] FirstZoneData)
        {
            int nParameters=3,iData_valid=0;
            double[,] X = new double[nData, nParameters];
            double[] data_valid = new double[nData];
            nFirstZone = 0;

            for (int iData = 0; iData < nData; iData++)
            {
                double t = iData * DigitalTimeInterval;
                tArrayforplot[iData] = t;
                if ((data[iData] < 4095) && (data[iData] > 1))
                {
                    X[iData_valid, 0] = Math.Sin(6.283185307179586476925286766559 * Frequency * t);
                    X[iData_valid, 1] = Math.Cos(6.283185307179586476925286766559 * Frequency * t);
                    //    X[iData, 3] = t;
                    X[iData_valid, 2] = 1.0;
                    data_valid[iData_valid++] = data[iData];
                }
                int nz = (int)(t / tPeriod);
                if (nz == 0) nFirstZone++;
                tArrayforplot[iData] = t - nz * tPeriod;
            }
            
            LinearFit(iData_valid, nParameters, X, data_valid, ref parameters4);

            for (int iData = 0; iData < nFirstZone; iData++)
            {
                FirstZonetArray[iData] = iData * DigitalTimeInterval;
                FirstZoneData[iData] = data[iData];
            }

            

            double dt = tPeriod / (nData - 1);

            for (int iData = 0; iData < nData; iData++)
            {
                double t = iData * dt;
                FittedtArray[iData] = t;
                FittedData[iData] = parameters4[0] * Math.Sin(6.283185307179586476925286766559 * Frequency * t) +
                    parameters4[1] * Math.Cos(6.283185307179586476925286766559 * Frequency * t) +
                    parameters4[2];// +parameters4[3] * t;
            }
        }

        private void LinearFit(int nData, int nParameters, double[,] X, double[] Y, ref double[] FittedParameters)
        {
            double[,] Xd = new double[nParameters, nData];
            for (int iData = 0; iData < nData; iData++)
                for (int iParameters = 0; iParameters < nParameters; iParameters++)
                    Xd[iParameters,iData]=X[iData,iParameters];

            double[,] M = new double[nParameters, nParameters];
            for (int iParameters = 0; iParameters < nParameters; iParameters++)
                for (int jParameters = 0; jParameters < nParameters; jParameters++)
                {
                    double s=0;
                    for (int kData = 0; kData < nData; kData++)
                    {
                        s = s + Xd[iParameters, kData] * X[kData, jParameters];
                    }
                    M[iParameters,jParameters]=s;
                }

            int info;
            alglib.matinvreport rep;
            alglib.rmatrixinverse( ref M, out info, out rep);

            double[] XdY = new double[nParameters];
            for (int iParameters = 0; iParameters < nParameters; iParameters++)
            {
                double s = 0;
                for (int kData = 0; kData < nData; kData++)
                {
                    s = s + Xd[iParameters, kData] * Y[kData];
                }
                XdY[iParameters] = s;
            }

            for (int iParameters = 0; iParameters < nParameters; iParameters++)
            {
                double s = 0;
                for (int kParameters = 0; kParameters < nParameters; kParameters++)
                {
                    s = s + M[iParameters, kParameters] * XdY[kParameters];
                }
                FittedParameters[iParameters] = s;
            }
        }

        public static int SetDCVConvert(double VltOrCurrentInGalvanostat, int VSelect, int ISelect, int PGMode)
        {
            int ivlt;
            if (PGMode != 3)
            {
                double vlt = VltOrCurrentInGalvanostat;
                if (VSelect == 0)
                    vlt = vlt / Settings.SetDCV_Select0;
                else
                    vlt = vlt / Settings.SetDCV_Select1;
                ivlt = (int)(vlt / Settings.SetDCV_Domain * 2047) + Settings.SetDCV_Offset;
                if (ivlt > 4095) ivlt = 4095;
                if (ivlt < 0) ivlt = 0;
            }
            else
            {
                double GetDCI_Domain = Settings.SetDCV_Domain/(-5);
                double amp = -VltOrCurrentInGalvanostat;
                if (ISelect == 0)
                    ivlt = (int)(amp * 2047 * Settings.GetDCI_Select0 / GetDCI_Domain + Settings.SetDCV_Offset);
                else if (ISelect == 1)
                    ivlt = (int)(0.001 * amp * 2047 * Settings.GetDCI_Select1 / GetDCI_Domain + Settings.SetDCV_Offset);
                else if (ISelect == 2)
                    ivlt = (int)(0.001 * amp * 2047 * Settings.GetDCI_select2 / GetDCI_Domain + Settings.SetDCV_Offset);
                else if (ISelect == 3)
                    ivlt = (int)(0.001 * amp * 2047 * Settings.GetDCI_Select3 / GetDCI_Domain + Settings.SetDCV_Offset);
                else if (ISelect == 4)
                    ivlt = (int)(0.000001 * amp * 2047 * Settings.GetDCI_Select4 / GetDCI_Domain + Settings.SetDCV_Offset);
                else if (ISelect == 5)
                    ivlt = (int)(0.000001 * amp * 2047 * Settings.GetDCI_Select5 / GetDCI_Domain + Settings.SetDCV_Offset);
                else if (ISelect == 6)
                    ivlt = (int)(0.000001 * amp * 2047 * Settings.GetDCI_Select6 / GetDCI_Domain + Settings.SetDCV_Offset);
                else
                    ivlt = (int)(0.000000001 * amp * 2047 * Settings.GetDCI_Select7 / GetDCI_Domain + Settings.SetDCV_Offset);


                if (ivlt > 4095) ivlt = 4095;
                if (ivlt < 0) ivlt = 0;
            }
            return ivlt;
        }

        public static int SetDCVConvert_dV(double VltOrCurrentInGalvanostat, int VSelect, int ISelect, int PGMode)
        {
            int ivlt;
            if (PGMode != 3)
            {
                double vlt = VltOrCurrentInGalvanostat;
                if (VSelect == 0)
                    vlt = vlt / Settings.SetDCV_Select0;
                else
                    vlt = vlt / Settings.SetDCV_Select1;
                ivlt = (int)(vlt / Settings.SetDCV_Domain * 2047) + Settings.SetDCV_Offset;
            }
            else
            {
                double GetDCI_Domain = Settings.SetDCV_Domain / (-5);
                double amp = -VltOrCurrentInGalvanostat;
                if (ISelect == 0)
                    ivlt = (int)(amp * 2047 * Settings.GetDCI_Select0 / GetDCI_Domain + Settings.SetDCV_Offset);
                else if (ISelect == 1)
                    ivlt = (int)(0.001 * amp * 2047 * Settings.GetDCI_Select1 / GetDCI_Domain + Settings.SetDCV_Offset);
                else if (ISelect == 2)
                    ivlt = (int)(0.001 * amp * 2047 * Settings.GetDCI_select2 / GetDCI_Domain + Settings.SetDCV_Offset);
                else if (ISelect == 3)
                    ivlt = (int)(0.001 * amp * 2047 * Settings.GetDCI_Select3 / GetDCI_Domain + Settings.SetDCV_Offset);
                else if (ISelect == 4)
                    ivlt = (int)(0.000001 * amp * 2047 * Settings.GetDCI_Select4 / GetDCI_Domain + Settings.SetDCV_Offset);
                else if (ISelect == 5)
                    ivlt = (int)(0.000001 * amp * 2047 * Settings.GetDCI_Select5 / GetDCI_Domain + Settings.SetDCV_Offset);
                else if (ISelect == 6)
                    ivlt = (int)(0.000001 * amp * 2047 * Settings.GetDCI_Select6 / GetDCI_Domain + Settings.SetDCV_Offset);
                else
                    ivlt = (int)(0.000000001 * amp * 2047 * Settings.GetDCI_Select7 / GetDCI_Domain + Settings.SetDCV_Offset);
            }
            return ivlt;
        }

        public static double Inverse_SetDCVConvert_dV(int VltOrCurrentInGalvanostat_Int, int VSelect, int ISelect, int PGMode)
        {
            double vlt;
            if (PGMode != 3)
            {
                int ivlt = VltOrCurrentInGalvanostat_Int;
                vlt = (ivlt - Settings.SetDCV_Offset) * Settings.SetDCV_Domain / 2047;

                if (VSelect == 0)
                    vlt = vlt * Settings.SetDCV_Select0;
                else
                    vlt = vlt * Settings.SetDCV_Select1;
                
            }
            else
            {
                double GetDCI_Domain = Settings.SetDCV_Domain / (-5);
                int iamp = VltOrCurrentInGalvanostat_Int;

                if (ISelect == 0)
                    vlt = (iamp - Settings.SetDCV_Offset) * GetDCI_Domain / Settings.GetDCI_Select0 / 2047;
                else if (ISelect == 1)
                    vlt = (iamp - Settings.SetDCV_Offset) * GetDCI_Domain / Settings.GetDCI_Select1 / 2047 / 0.001;
                else if (ISelect == 2)
                    vlt = (iamp - Settings.SetDCV_Offset) * GetDCI_Domain / Settings.GetDCI_select2 / 2047 / 0.001;
                else if (ISelect == 3)
                    vlt = (iamp - Settings.SetDCV_Offset) * GetDCI_Domain / Settings.GetDCI_Select3 / 2047 / 0.001;
                else if (ISelect == 4)
                    vlt = (iamp - Settings.SetDCV_Offset) * GetDCI_Domain / Settings.GetDCI_Select4 / 2047 / 0.000001;
                else if (ISelect == 5)
                    vlt = (iamp - Settings.SetDCV_Offset) * GetDCI_Domain / Settings.GetDCI_Select5 / 2047 / 0.000001;
                else if (ISelect == 6)
                    vlt = (iamp - Settings.SetDCV_Offset) * GetDCI_Domain / Settings.GetDCI_Select6 / 2047 / 0.000001;
                else
                    vlt = (iamp - Settings.SetDCV_Offset) * GetDCI_Domain / Settings.GetDCI_Select7 / 2047 / 0.000000001;

                vlt = -vlt;
            }
            return vlt;
        }

        public static double EISGetVConvert(double ivlt, int Vmlp, int SetSelect)
        {
            double vlt;
            vlt = (ivlt - 2047) * Settings.SetACVMaxS0 / 2047;

            if (Vmlp < 7)
                vlt = vlt / Math.Pow(2, Vmlp);
            else
                vlt = vlt * 2;

            float ACMultFactor;
            if (SetSelect==0)
                ACMultFactor = Form1.Settings.ACMultFactor_Select0;
            else
                ACMultFactor = Form1.Settings.ACMultFactor_Select1;

            return vlt / ACMultFactor;
        }

        public static double GetDCVConvert(double ivlt, int Vmlp , int SetSelect)
        {
            double domain = Settings.GetDCV_Domain * Math.Pow(5.55, 1 - SetSelect);
            double vlt = (ivlt - Settings.GetDCV_OffsetMLP0) * domain / 2047;

            if (Vmlp == 1)
                vlt = (ivlt - Settings.GetDCV_OffsetMLP1) * domain / 2047;
            else if (Vmlp == 2)
                vlt = (ivlt - Settings.GetDCV_OffsetMLP2) * domain / 2047;
            else if (Vmlp == 3)
                vlt = (ivlt - Settings.GetDCV_OffsetMLP3) * domain / 2047;
            else if (Vmlp == 4)
                vlt = (ivlt - Settings.GetDCV_OffsetMLP4) * domain / 2047;
            else if (Vmlp == 5)
                vlt = (ivlt - Settings.GetDCV_offsetMLP5) * domain / 2047;
            else if (Vmlp == 6)
                vlt = (ivlt - Settings.GetDCV_OffsetMLP6) * domain / 2047;

            if (Vmlp < 7)
                vlt = vlt / Math.Pow(2, Vmlp);
            else
                vlt = vlt * 2;

            return vlt;
        }

        public static double GetDCVConvertWithNewOffset(double ivlt, int Vmlp, double Offset,int SetSelect)
        {
            //return GetDCVConvert(ivlt, Vmlp, SetSelect);
            double vlt;
            double domain = Settings.GetDCV_Domain * Math.Pow(5.55, 1 - SetSelect);
            vlt = (ivlt - Offset) * domain / 2047;

            if (Vmlp < 7)
                vlt = vlt / Math.Pow(2, Vmlp);
            else
                vlt = vlt * 2;

            return vlt;
        }

        public static double EISGetIConvert(double iamp, int ISelect, int Imlp)
        {
            double amp;
            amp = (iamp - 2047) * Settings.SetACVMaxS0 / 2047;
            if (ISelect == 0)
                amp = amp / Settings.GetDCI_Select0;
            else if (ISelect == 1)
                amp = amp / Settings.GetDCI_Select1;
            else if (ISelect == 2)
                amp = amp / Settings.GetDCI_select2;
            else if (ISelect == 3)
                amp = amp / Settings.GetDCI_Select3;
            else if (ISelect == 4)
                amp = amp / Settings.GetDCI_Select4;
            else if (ISelect == 5)
                amp = amp / Settings.GetDCI_Select5;
            else if (ISelect == 6)
                amp = amp / Settings.GetDCI_Select6;
            else if (ISelect == 7)
                amp = amp / Settings.GetDCI_Select7;

            if (Imlp < 7)
                amp = amp / Math.Pow(2, Imlp);
            else
                amp = amp * 2;

            return -amp;
        }

        public static double GetDCIConvert(double iamp, int ISelect, int Imlp)
        {
            double amp;
            if (ISelect == 0)
            {
                amp = (iamp - Settings.GetDCI_Offset0d) * Settings.GetDCI_Domain / 2047;
                amp = amp / Settings.GetDCI_Select0;
            }
            else if (ISelect == 1)
            {
                amp = (iamp - Settings.GetDCI_Offset1d) * Settings.GetDCI_Domain / 2047;
                amp = amp / Settings.GetDCI_Select1;
            }
            else if (ISelect == 2)
            {
                amp = (iamp - Settings.GetDCI_Offset2) * Settings.GetDCI_Domain / 2047;
                amp = amp / Settings.GetDCI_select2;
            }
            else if (ISelect == 3)
            {
                amp = (iamp - Settings.GetDCI_Offset3d) * Settings.GetDCI_Domain / 2047;
                amp = amp / Settings.GetDCI_Select3;
            }
            else if (ISelect == 4)
            {
                amp = (iamp - Settings.GetDCI_Offset4d) * Settings.GetDCI_Domain / 2047;
                amp = amp / Settings.GetDCI_Select4;
            }
            else if (ISelect == 5)
            {
                amp = (iamp - Settings.GetDCI_Offset5d) * Settings.GetDCI_Domain / 2047;
                amp = amp / Settings.GetDCI_Select5;
            }
            else if (ISelect == 6)
            {
                amp = (iamp - Settings.GetDCI_Offset6d) * Settings.GetDCI_Domain / 2047;
                amp = amp / Settings.GetDCI_Select6;
            }
            else
            {
                amp = (iamp - Settings.GetDCI_Offset7d) * Settings.GetDCI_Domain / 2047;
                amp = amp / Settings.GetDCI_Select7;
            }

            if (Imlp<7)
                amp = amp / Math.Pow(2, Imlp);
            else
                amp = amp * 2;

            return -amp;
        }

        public static double GetDCIConvertWithNewOffset(double iamp, int ISelect, int Imlp, double Offset)
        {
            //return GetDCIConvert(iamp, ISelect, Imlp);//moosa
            double amp;
            amp = (iamp - Offset) * Settings.GetDCI_Domain / 2047;
            if (ISelect == 0)
                amp = amp / Settings.GetDCI_Select0;
            else if (ISelect == 1)
                amp = amp / Settings.GetDCI_Select1;
            else if (ISelect == 2)
                amp = amp / Settings.GetDCI_select2;
            else if (ISelect == 3)
                amp = amp / Settings.GetDCI_Select3;
            else if (ISelect == 4)
                amp = amp / Settings.GetDCI_Select4;
            else if (ISelect == 5)
                amp = amp / Settings.GetDCI_Select5;
            else if (ISelect == 6)
                amp = amp / Settings.GetDCI_Select6;
            else
                amp = amp / Settings.GetDCI_Select7;

            if (Imlp < 7)
                amp = amp / Math.Pow(2, Imlp);
            else
                amp = amp * 2;

            return -amp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="frq"></param>
        /// <param name="ddsClock"></param>
        /// <param name="nClock"></param>
        /// <param name="ddsDiv"></param>
        public static void SetFrqConvert(ref double frq, ref int ddsClock, ref int nClock, ref int ddsDiv)
        {
            //int k = (int)(8000000.0 / frq / 1000);
            //int k = (int)(65535.0 / frq);
            int k = 1;

            if (frq < 2000)
                k = (int)(2000.0 / frq); 
            int odd = 2 * k - 1;
            if (odd > 32767)
                ddsClock = 65535;
            else
                ddsClock = odd;

            double topfrq = 32000000.0 / (ddsClock + 1);

  /*          if (frq < 2000.0)
            {
                ddsDiv = 1;
                nClock = (int)(Math.Pow(2, 28) / topfrq * frq * 1);
            }
            else   */
            {
               
                nClock = (int)(Math.Pow(2, 28) / topfrq * frq);
                frq = topfrq * nClock / Math.Pow(2, 28);
                ddsDiv = 1;
            }

        }

        public static double GetFrqConvert(int nClock, int ddsClock)
        {
            double topfrq = 32000000.0 / (ddsClock + 1);
            double frq = topfrq * nClock / Math.Pow(2, 28);
            return frq;
        }

        public static int SetAnalogeConvert(double p)
        {
            int ip = (int)(p / Settings.AnalogCommon_Domain * 8388607.0) + Settings.AnalogCommon_intOffset;
            return ip;
        }

        private double GetAnalogeConvert(int ip)
        {
            double p = (ip - Settings.AnalogCommon_intOffset) * Settings.AnalogCommon_Domain / 8388607.0;
            return p;
        }

        public static int SetACVoltageConvert(double ACV, int VSelect)
        {
            int iACV;
            if (BoardType>1)
            {
                if (VSelect == 0)
                    iACV = (int)(((Settings.SetACVResoloution + 1) * (- 0.052 + 5*100.0 / ACV)) / 10000.0);
                else
                    iACV = (int)(((Settings.SetACVResoloution + 1) * (- 0.052 + 100.0 / ACV)) / 10000.0);

                if (iACV < 1) iACV = 1;
                if (iACV > Settings.SetACVResoloution) iACV = Settings.SetACVResoloution;
                iACV = Settings.SetACVResoloution - iACV;
            }
            else
            {
                if (VSelect == 0)
                    iACV = (int)((Settings.SetACVResoloution) * ACV / Settings.SetACVMaxS0 / Settings.SetDCV_Select0);
                else
                    iACV = (int)((Settings.SetACVResoloution) * ACV / Settings.SetACVMaxS0 / Settings.SetDCV_Select1);

                if (iACV < 1) iACV = 1;
                if (iACV > Settings.SetACVResoloution) iACV = Settings.SetACVResoloution;
                iACV = Settings.SetACVResoloution - iACV;
            }

            return iACV;
        }

        

        public static int SetDigitalVConvert(double vlt)
        {
            int ivlt = (int)(Settings.GetDCV_OffsetMLP0 + vlt / Settings.GetDCV_Domain * 2047);
            return ivlt;
        }

        public static double GetDigitalVConvert(int ivlt)
        {
            double vlt;
                vlt = (ivlt - Settings.GetDCV_OffsetMLP0) * Settings.GetDCV_Domain / 2047;
            return vlt;
        }

        private double GetDigitalIConvert(double iamp, int ISelect)
        {
            double amp;
            if (ISelect==0)
                amp = (iamp - Settings.GetDCI_Offset0d) * Settings.GetDCI_Domain / 2047;
            else if (ISelect == 1)
                amp = (iamp - Settings.GetDCI_Offset1d) * Settings.GetDCI_Domain / 2047;
            else if (ISelect == 2)
                amp = (iamp - Settings.GetDCI_Offset2) * Settings.GetDCI_Domain / 2047;
            else if (ISelect == 3)
                amp = (iamp - Settings.GetDCI_Offset3d) * Settings.GetDCI_Domain / 2047;
            else if (ISelect == 4)
                amp = (iamp - Settings.GetDCI_Offset4d) * Settings.GetDCI_Domain / 2047;
            else if (ISelect == 5)
                amp = (iamp - Settings.GetDCI_Offset5d) * Settings.GetDCI_Domain / 2047;
            else if (ISelect == 6)
                amp = (iamp - Settings.GetDCI_Offset6d) * Settings.GetDCI_Domain / 2047;
            else
                amp = (iamp - Settings.GetDCI_Offset7d) * Settings.GetDCI_Domain / 2047;
            return amp;
        }

        public void EISPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            isDataReceived = true;
        }

        delegate void SetTextCallback(string text);

        private void tryNextRun()
        {
            if (isIVTimerTickSet)
            {
                IVTimer1.Stop();
                IVTimer1.Dispose();
                isIVTimerTickSet = false;
            }

            if (isAnalogEISTimerTickSet)
            {
                AnalogEISTimer.Stop();
                AnalogEISTimer.Dispose();
                isAnalogEISTimerTickSet = false;
            }
            

            if (Form1.AllSessions[EIS.RunningSession].Mode == 0 && FormFitting.FitSelectedSession == EIS.RunningSession) UpdateFormFit("");

            if (AllSessions[EIS.RunningSession].isExportAtFinal && AllSessions[EIS.RunningSession].ExportAtFinalDIR != "")
                ExportData(AllSessions[EIS.RunningSession], AllSessionsData[EIS.RunningSession], AllSessions[EIS.RunningSession].ExportAtFinalDIR);
            if (GoToNext)
            {
                int i;
                for (i = EIS.RunningSession + 1; i < EIS.nSsn; i++)
                {
                    if (AllSessions[i].active && EIS.ready)
                    {
                        EIS.RunningSession = i;
                        AllSessions[EIS.RunningSession].isStarted = true;
                        RunSession(AllSessions[i]);
                        break;
                    }
                }

                if (i == EIS.nSsn)
                {
                    StopRun();
                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    SetStatus("All sessions are completed.");
                }
            }
            else
            {
                StopRun();
                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer
                SetStatus("session is completed.");
            }
        }


        private void SetStatus(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (Status.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetStatus);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                Status.Text = text;
            }
        }

        //private void StopRun()
        //{
        //    isRunPause = false;
        //    BtnPauseContinue.Text = "Pause";
        //    BtnPauseContinue.Font = new Font(BtnPauseContinue.Font.FontFamily, 8.0F);
        //    BtnPauseContinue.Enabled = false;
        //    isRunStart = false;
        //    BtnRun.Text = "Start";
        //    PBAllSessionsValue = 1;
        //    SetPBAllSessions(PBAllSessionsValue);
        //    SetStatus("Run is stoped.");
        //}

        private void DisableBtnPauseContinue(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (BtnPauseContinue.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(DisableBtnPauseContinue);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                BtnPauseContinue.Text = text;
                BtnPauseContinue.Font = new Font(BtnPauseContinue.Font.FontFamily, 8.0F);
                BtnPauseContinue.Enabled = false;
            }
        }

        private void ActiveBtnCreateSession(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (BtnCreateSession.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(ActiveBtnCreateSession);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                BtnCreateSession.Enabled = true;
            }
        }

        private void RestartBtnRun(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (BtnRun.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(RestartBtnRun);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                BtnRun.Text = text;
            }
        }
        

        private void UpdateFormFit(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (FormFit.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(UpdateFormFit);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                FormFit.UpdateDiagrams();
                FormFit.LabelError.Text = text;
            }
        }

        delegate void SetIntCallback(int value);

        private void SetPBAllSessions(int value)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.PBAllSessions.InvokeRequired)
            {
                SetIntCallback d = new SetIntCallback(SetPBAllSessions);
                this.Invoke(d, new object[] { value });
            }
            else
            {
                this.PBAllSessions.Value = value;
            }
        }

        private void BtnVirtualMachine_Click(object sender, EventArgs e)
        {
            if (isVM)
            {
                VM.Hide();
                isVM = false;
            }
            else
            {
                VM.Show(this);
                isVM = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void BtnFitt_Click(object sender, EventArgs e)
        {
            if (isFormFit)
            {
                FormFit.Hide();
                isFormFit = false;
            }
            else
            {
                FormFit.Show(this);
                isFormFit = true;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (EIS.isFile)
            {
                WriteAllDataToFile(EIS.FileName);
            }
            else
            {
                saveFileDialog1.Title = "Save File";
                saveFileDialog1.ShowDialog();
            }
        }

        private void BtnSaveAs_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "Save As File";
            saveFileDialog1.ShowDialog();
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Open File";
            isOpenNewFile = true;
            openFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            this.Activate();
            WriteAllDataToFile(saveFileDialog1.FileName);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            this.Activate();
            if (isOpenNewFile) ClearAll();
            ReadAllDataFromFile(openFileDialog1.FileName);
        }

        private void WriteAllDataToFile(string FileName)
        {
            try
            {
                FileStream FileProtocol = new FileStream(FileName, FileMode.Create);

                BinaryWriter bw = new BinaryWriter(FileProtocol);
                bw.Write(Version);

                bw.Write(EIS.nSsn);

                foreach (Sessions S in AllSessions)
                {
                    bw.Write(S.Mode);
                    bw.Write(S.ACAmpConstant);
                    bw.Write(S.ACAmpFrom);
                    bw.Write(S.ACAmpStep);
                    bw.Write(S.ACAmpTo);
                    bw.Write(S.ACFrqConstant);
                    bw.Write(S.ACFrqFrom);
                    bw.Write(S.ACFrqNStep);
                    bw.Write(S.ACFrqTo);
                    bw.Write(S.active);
                    bw.Write(S.isCVEnable);
                    bw.Write(S.V_OCT);
                    bw.Write(S.IdealVoltage);
                    bw.Write(S.isOCP);
                    bw.Write(S.isOCPAutoStart);
                    bw.Write(S.PGmode);
                    bw.Write(S.RelRef);
                    bw.Write(S.EqTime);
                    bw.Write(S.EISDCCurrentRangeModea);
                    bw.Write(S.EISACRegulatorMode);
                    bw.Write(S.EISACCurrentRangeMode);
                    bw.Write(S.EISVmlpMax);
                    bw.Write(S.EISImlpMax);
                    bw.Write(S.EISfilterMode);
                    bw.Write(S.EISAverageNumberL);
                    bw.Write(S.EISAverageNumberH);
                    bw.Write(S.EISMode);
                    bw.Write(S.EISOCMode);
                    bw.Write(S.EISVoltageRangeMode);
                    bw.Write(S.IVVoltageRangeMode);
                    bw.Write(S.IVChrono_VFilter);
                    bw.Write(S.Pulse_VFilter);
                    bw.Write(S.PulseVoltageRangeMode);
                    bw.Write(S.PulseCurrentRangeMode);
                    bw.Write(S.PulseVmlp);
                    bw.Write(S.PulseImlpp);
                    bw.Write(S.PulseReadingEdgemode);
                    bw.Write(S.PulseVoltammetryMode);
                    bw.Write(S.DCVoltageConstant);
                    bw.Write(S.DCVoltageFrom);
                    bw.Write(S.DCVoltageStep);
                    bw.Write(S.DCVoltageTo);
                    bw.Write(S.IVCurrentRangeMode);
                    bw.Write(S.IVVmlp);
                    bw.Write(S.IVImlp);
                    bw.Write(S.IVVoltageFrom);
                    bw.Write(S.IVVoltageNStepp);
                    bw.Write(S.CVStartpoint);
                    bw.Write(S.PretreatmentVoltage);
                    bw.Write(S.isPreProcProbOn);
                    bw.Write(S.isChBPostProcProbOff);
                    bw.Write(S.CVItteration);
                    bw.Write(S.IVvoltageTo);
                    bw.Write(S.ChronoEndTime);
                    bw.Write(S.IVTimestep);
                    bw.Write(S.Chrono_n);
                    bw.Write(S.Chrono_Total_Period);
                    bw.Write(S.Chrono_Pulse_Period);
                    bw.Write(S.Chrono_Pulse_Level);
                    bw.Write(S.Chrono_Pulse_Amplitude);
                    bw.Write(S.Chrono_Level_Step);
                    bw.Write(S.Chrono_Amplitude_step);
                    bw.Write(S.Chrono_isfast);
                    bw.Write(S.Chrono_nsteps);
                    bw.Write(S.Chrono_t1);
                    bw.Write(S.Chrono_t2);
                    bw.Write(S.Chrono_t3);
                    bw.Write(S.Chrono_t4);
                    bw.Write(S.Chrono_t5);
                    bw.Write(S.Chrono_t6);
                    bw.Write(S.Chrono_t7);
                    bw.Write(S.Chrono_t8);
                    bw.Write(S.Chrono_t9);
                    bw.Write(S.Chrono_t10);
                    bw.Write(S.Chrono_v1);
                    bw.Write(S.Chrono_v2);
                    bw.Write(S.Chrono_v3);
                    bw.Write(S.Chrono_v4);
                    bw.Write(S.Chrono_v5);
                    bw.Write(S.Chrono_v6);
                    bw.Write(S.Chrono_v7);
                    bw.Write(S.Chrono_v8);
                    bw.Write(S.Chrono_v9);
                    bw.Write(S.Chrono_v10);
                    bw.Write(S.Chrono_dt);
                    bw.Write(S.Chrono_ocp1);
                    bw.Write(S.Chrono_ocp2);
                    bw.Write(S.Chrono_ocp3);
                    bw.Write(S.Chrono_ocp4);
                    bw.Write(S.Chrono_ocp5);
                    bw.Write(S.Chrono_ocp6);
                    bw.Write(S.Chrono_ocp7);
                    bw.Write(S.Chrono_ocp8);
                    bw.Write(S.Chrono_ocp9);
                    bw.Write(S.Chrono_ocp10);
                    bw.Write(S.index);
                    bw.Write(S.isACAmpConstant);
                    bw.Write(S.isACFrqConstant);
                    bw.Write(S.isDCVoltageConstant);
                    bw.Write(S.isFinished);
                    bw.Write(S.isStarted);
                    bw.Write(S.name);
                    bw.Write(S.DataAndTime);
                    bw.Write(S.nCircuits);

                    foreach (Circuit C in S.Circuits)
                    {
                        bw.Write(C.FitMethod);
                        bw.Write(C.FitMethodName);
                        bw.Write(C.Input);
                        bw.Write(C.isFitted);
                        bw.Write(C.isReadyToFit);
                        bw.Write(C.isTrue);
                        bw.Write(C.name);
                        bw.Write(C.nElements);
                        bw.Write(C.nGraphPoint);
                        bw.Write(C.nLinks);
                        bw.Write(C.Output);

                        int nSameGraph = 0;
                        foreach (SameGraphPoints SG in C.AllSameGraph) nSameGraph++;
                        bw.Write(nSameGraph);

                        foreach (SameGraphPoints SG in C.AllSameGraph)
                        {
                            int nSGP = 0;
                            foreach (int SGP in SG.Points) nSGP++;
                            bw.Write(nSGP);

                            foreach (int SGP in SG.Points)
                            {
                                bw.Write(SGP);
                            }
                        }

                        foreach (Element E in C.Elements)
                        {
                            bw.Write(E.Input);
                            bw.Write(E.InputGraph);
                            bw.Write(E.Mode);
                            bw.Write(E.name);
                            bw.Write(E.Output);
                            bw.Write(E.OutputGraph);
                            bw.Write(E.Val);
                            bw.Write(E.Val2);
                            bw.Write(E.X);
                            bw.Write(E.Y);
                        }

                        foreach (Link L in C.Links)
                        {
                            bw.Write(L.i);
                            bw.Write(L.iElement);
                            bw.Write(L.j);
                            bw.Write(L.jElement);
                        }
                       
                    }


                }

                int nAllSessionsData = 0;
                foreach (SessionOutputData SD in AllSessionsData) nAllSessionsData++;
                bw.Write(nAllSessionsData);

                int iSD=-1;
                foreach (SessionOutputData SD in AllSessionsData)
                {
                    iSD++;
                    bw.Write(SD.ACAmpDim);
                    bw.Write(SD.ACFrqDim);
                    bw.Write(SD.DCVltDim);
                    bw.Write(SD.IVAmpDim);
                    bw.Write(SD.ReceivedDataCount);

                    if (AllSessions[iSD].Mode==0)
                        for (int i = 0; i < SD.ReceivedDataCount; i++)
                            bw.Write(SD.Frq[i]);

                    //if (AllSessions[iSD].Mode == 2)
                    //    for (int i = 0; i < SD.ReceivedDataCount; i++)
                    //        bw.Write(SD.Amp[i]);
                    if (AllSessions[iSD].Mode == 1 || AllSessions[iSD].Mode == 2 || AllSessions[iSD].Mode == 3)
                    {
                        for (int i = 0; i < SD.ReceivedDataCount; i++)
                            bw.Write(SD.Vlt[i]);
                        for (int i = 0; i < SD.ReceivedDataCount; i++)
                            bw.Write(SD.Amp[i]);
                    }

                    if (AllSessions[iSD].Mode == 0 || AllSessions[iSD].Mode == 1)
                        for (int i = 0; i < SD.ReceivedDataCount; i++)
                        {
                            bw.Write(SD.Imz[i]);
                            bw.Write(SD.overflow[i]);
                            bw.Write(SD.ReZ[i]);
                        }

                }

                FileProtocol.Close();
                bw.Close();

                SetStatus("File is saved successfully.");

                EIS.FileName = FileName;
                EIS.isFile = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Unknown error. File is not saved.");
                SetStatus("Unknown error during writting File ...");
            }
        }

        private void ReadAllDataFromFile(string FileName)
        {
            try
            {
                FileStream FileProtocol = new FileStream(FileName, FileMode.Open);

                BinaryReader br = new BinaryReader(FileProtocol);
                Version = br.ReadInt32();
                
                int nSessions = br.ReadInt32();

                //if (isMustClear) EIS.nSsn = 0;
                int StartIndex = EIS.nSsn;
                for (int s = StartIndex; s < StartIndex + nSessions; s++)
                {
                    int ns = EIS.nSsn + 1;
                    DeSelectAll();
                    Sessions NewSession = new Sessions();

                    NewSession.Mode = br.ReadInt32();
                    NewSession.ACAmpConstant = br.ReadDouble();
                    NewSession.ACAmpFrom = br.ReadDouble();
                    NewSession.ACAmpStep = br.ReadDouble();
                    NewSession.ACAmpTo = br.ReadDouble();
                    NewSession.ACFrqConstant = br.ReadDouble();
                    NewSession.ACFrqFrom = br.ReadDouble();
                    NewSession.ACFrqNStep = br.ReadInt32();
                    NewSession.ACFrqTo = br.ReadDouble();
                    NewSession.active = br.ReadBoolean();
                    if (Version >= 1016) NewSession.isCVEnable = br.ReadBoolean();
                    NewSession.V_OCT = br.ReadDouble();
                    if (Version >= 1012) NewSession.IdealVoltage = br.ReadDouble(); else NewSession.IdealVoltage = FactoryDefault.IdealVoltage;
                    NewSession.isOCP = br.ReadBoolean();
                    if (Version >= 1015) NewSession.isOCPAutoStart = br.ReadBoolean();
                    if (Version >= 1014) NewSession.PGmode = br.ReadInt32();
                    NewSession.RelRef = br.ReadBoolean();
                    NewSession.EqTime = br.ReadInt32();
                    NewSession.EISDCCurrentRangeModea = br.ReadInt32();
                    NewSession.EISDCCurrentRangeModea = 0; // from version 2013 it changes to auto mode
                    NewSession.EISACRegulatorMode = br.ReadInt32();
                    if (Version >= 1011) NewSession.EISACCurrentRangeMode = br.ReadInt32(); else NewSession.EISACCurrentRangeMode = FactoryDefault.EISACCurrentRangeMode;
                    if (Version >= 1011) NewSession.EISVmlpMax = br.ReadInt32(); else NewSession.EISVmlpMax = FactoryDefault.EISVmlpMax;
                    if (Version >= 1011) NewSession.EISImlpMax = br.ReadInt32(); else NewSession.EISImlpMax = FactoryDefault.EISImlpMax;
                    NewSession.EISfilterMode = br.ReadInt32();
                    NewSession.EISAverageNumberL = br.ReadInt32();
                    if (Version >= 1011) NewSession.EISAverageNumberH = br.ReadInt32(); else NewSession.EISAverageNumberH = FactoryDefault.EISAverageNumberH;
                    NewSession.EISMode = br.ReadInt32();
                    NewSession.EISOCMode = br.ReadInt32();
                    NewSession.EISVoltageRangeMode = br.ReadInt32();
                    NewSession.IVVoltageRangeMode = br.ReadInt32();
                    if (Version >= 1024) NewSession.IVChrono_VFilter = br.ReadInt32();
                    if (Version >= 1024) NewSession.Pulse_VFilter = br.ReadInt32();
                    if (Version >= 1020) NewSession.PulseVoltageRangeMode = br.ReadInt32();
                    if (Version >= 1020) NewSession.PulseCurrentRangeMode = br.ReadInt32();
                    if (Version >= 1020) NewSession.PulseVmlp = br.ReadInt32();
                    if (Version >= 1020) NewSession.PulseImlpp = br.ReadInt32();
                    if (Version >= 1021) NewSession.PulseReadingEdgemode = br.ReadInt32();
                    if (Version >= 1022) NewSession.PulseVoltammetryMode = br.ReadInt32();
                    NewSession.DCVoltageConstant = br.ReadDouble();
                    NewSession.DCVoltageFrom = br.ReadDouble();
                    NewSession.DCVoltageStep = br.ReadInt32();
                    NewSession.DCVoltageTo = br.ReadDouble();
                    NewSession.IVCurrentRangeMode = br.ReadInt32();
                    NewSession.IVVmlp = br.ReadInt32();
                    NewSession.IVImlp = br.ReadInt32();
                    NewSession.IVVoltageFrom = br.ReadDouble();
                    NewSession.IVVoltageNStepp = br.ReadInt32();
                    if (Version >= 1016) NewSession.CVStartpoint = br.ReadDouble();
                    if (Version >= 1017) NewSession.PretreatmentVoltage = br.ReadDouble();
                    if (Version >= 1017) NewSession.isPreProcProbOn = br.ReadBoolean();
                    if (Version >= 1017) NewSession.isChBPostProcProbOff = br.ReadBoolean();
                    if (Version >= 1016) NewSession.CVItteration = br.ReadInt32();
                    NewSession.IVvoltageTo = br.ReadDouble();
                    if (Version >= 1019) NewSession.ChronoEndTime = br.ReadDouble();
                    NewSession.IVTimestep = br.ReadInt32();

                    if (Version >= 1018) NewSession.Chrono_n = br.ReadInt32();
                    if (Version >= 1018) NewSession.Chrono_Total_Period = br.ReadDouble();
                    if (Version >= 1018) NewSession.Chrono_Pulse_Period = br.ReadDouble();
                    if (Version >= 1018) NewSession.Chrono_Pulse_Level = br.ReadDouble();
                    if (Version >= 1018) NewSession.Chrono_Pulse_Amplitude = br.ReadDouble();
                    if (Version >= 1018) NewSession.Chrono_Level_Step = br.ReadDouble();
                    if (Version >= 1018) NewSession.Chrono_Amplitude_step = br.ReadDouble();
                    if (Version >= 1019) NewSession.Chrono_isfast = br.ReadBoolean();

                    if (Version >= 1023) NewSession.Chrono_nsteps = br.ReadInt32();
                    if (Version >= 1023) NewSession.Chrono_t1 = br.ReadDouble();
                    if (Version >= 1023) NewSession.Chrono_t2 = br.ReadDouble();
                    if (Version >= 1023) NewSession.Chrono_t3 = br.ReadDouble();
                    if (Version >= 1023) NewSession.Chrono_t4 = br.ReadDouble();
                    if (Version >= 1023) NewSession.Chrono_t5 = br.ReadDouble();
                    if (Version >= 1023) NewSession.Chrono_t6 = br.ReadDouble();
                    if (Version >= 1023) NewSession.Chrono_t7 = br.ReadDouble();
                    if (Version >= 1023) NewSession.Chrono_t8 = br.ReadDouble();
                    if (Version >= 1023) NewSession.Chrono_t9 = br.ReadDouble();
                    if (Version >= 1023) NewSession.Chrono_t10 = br.ReadDouble();
                    if (Version >= 1023) NewSession.Chrono_v1 = br.ReadDouble();
                    if (Version >= 1023) NewSession.Chrono_v2 = br.ReadDouble();
                    if (Version >= 1023) NewSession.Chrono_v3 = br.ReadDouble();
                    if (Version >= 1023) NewSession.Chrono_v4 = br.ReadDouble();
                    if (Version >= 1023) NewSession.Chrono_v5 = br.ReadDouble();
                    if (Version >= 1023) NewSession.Chrono_v6 = br.ReadDouble();
                    if (Version >= 1023) NewSession.Chrono_v7 = br.ReadDouble();
                    if (Version >= 1023) NewSession.Chrono_v8 = br.ReadDouble();
                    if (Version >= 1023) NewSession.Chrono_v9 = br.ReadDouble();
                    if (Version >= 1023) NewSession.Chrono_v10 = br.ReadDouble();
                    if (Version >= 1023) NewSession.Chrono_dt = br.ReadDouble();
                    if (Version >= 1023) NewSession.Chrono_ocp1 = br.ReadBoolean();
                    if (Version >= 1023) NewSession.Chrono_ocp2 = br.ReadBoolean();
                    if (Version >= 1023) NewSession.Chrono_ocp3 = br.ReadBoolean();
                    if (Version >= 1023) NewSession.Chrono_ocp4 = br.ReadBoolean();
                    if (Version >= 1023) NewSession.Chrono_ocp5 = br.ReadBoolean();
                    if (Version >= 1023) NewSession.Chrono_ocp6 = br.ReadBoolean();
                    if (Version >= 1023) NewSession.Chrono_ocp7 = br.ReadBoolean();
                    if (Version >= 1023) NewSession.Chrono_ocp8 = br.ReadBoolean();
                    if (Version >= 1023) NewSession.Chrono_ocp9 = br.ReadBoolean();
                    if (Version >= 1023) NewSession.Chrono_ocp10 = br.ReadBoolean();
                    NewSession.index = br.ReadInt32(); NewSession.index = EIS.nSsn;
                    NewSession.isACAmpConstant = br.ReadBoolean();
                    NewSession.isACFrqConstant = br.ReadBoolean();
                    NewSession.isDCVoltageConstant = br.ReadBoolean();
                    NewSession.isFinished = br.ReadBoolean();
                    NewSession.isStarted = br.ReadBoolean();
                    NewSession.name = br.ReadString();
                    if (Version >= 1017) NewSession.DataAndTime = br.ReadString();
                    NewSession.nCircuits = br.ReadInt32();

                    AllSessions.Add(NewSession);

                    RichTextBox NewSessionGUI = new RichTextBox();
                    NewSessionGUI.Location = new Point(0, EIS.nSsn * 37);
                    NewSessionGUI.Size = new Size(1000, 35);
                    NewSessionGUI.BorderStyle = BorderStyle.Fixed3D;
                    AllSessionsGUI.Add(NewSessionGUI);
                    AllSessionsGUI[EIS.nSsn].Parent = Desktop;
                    AllSessionsGUI[EIS.nSsn].Show();
                    AllSessionsGUI[EIS.nSsn].MouseDown += new System.Windows.Forms.MouseEventHandler(this.SessionsGUI_MouseDown);
                    AllSessionsGUI[EIS.nSsn].BackColor = SelectedColor;
                    AllSessionsGUI[EIS.nSsn].ReadOnly = true;
                    AllSessionsGUI[EIS.nSsn].Cursor = Cursor.Current;
                    AllSessionsGUI[EIS.nSsn].Text = "Session Name: " + NewSession.name + " " + NewSession.DataAndTime;
                    if (!NewSession.active) AllSessionsGUI[EIS.nSsn].ForeColor = Color.Red;

                    Selected = EIS.nSsn;
                    FormDiagram.SessionName.Items.Add(AllSessions[Selected].name);
                    FormFit.SessionName.Items.Add(AllSessions[Selected].name);
                    FormDG.SessionName.Items.Add(AllSessions[Selected].name);
                    if (s == nSessions-1) LoadSelectedProperties();


                    for (int c = 0; c < NewSession.nCircuits; c++)
                    {
                        Circuit Crct = new Circuit();
                        Crct.FitMethod = br.ReadInt32();
                        Crct.FitMethodName = br.ReadString();
                        Crct.Input = br.ReadInt32();
                        Crct.isFitted = br.ReadBoolean();
                        Crct.isReadyToFit = br.ReadBoolean();
                        Crct.isTrue = br.ReadBoolean();
                        Crct.name = br.ReadString();
                        Crct.nElements = br.ReadInt32();
                        Crct.nGraphPoint = br.ReadInt32();
                        Crct.nLinks = br.ReadInt32();
                        Crct.Output = br.ReadInt32();
                        AllSessions[s].Circuits.Add(Crct);

                        int nSameGroup = 0;
                        int nSameGroupPoints = 0;

                        nSameGroup = br.ReadInt32();
                        for (int sg = 0; sg < nSameGroup; sg++)
                        {
                            SameGraphPoints SGP = new SameGraphPoints();
                            nSameGroupPoints = br.ReadInt32();
                            for (int sgp = 0; sgp < nSameGroupPoints; sgp++)
                            {
                                int point=0;
                                point = br.ReadInt32();
                                SGP.Points.Add(point);
                            }
                            AllSessions[s].Circuits[c].AllSameGraph.Add(SGP);
                        }

                        for (int E = 0; E < AllSessions[s].Circuits[c].nElements; E++)
                        {
                            Element Elmnt = new Element();

                            Elmnt.Input = br.ReadInt32();
                            Elmnt.InputGraph = br.ReadInt32();
                            Elmnt.Mode = br.ReadInt32();
                            Elmnt.name = br.ReadString();
                            Elmnt.Output = br.ReadInt32();
                            Elmnt.OutputGraph = br.ReadInt32();
                            Elmnt.Val = br.ReadDouble();
                            Elmnt.Val2 = br.ReadDouble();
                            Elmnt.X = br.ReadInt32();
                            Elmnt.Y = br.ReadInt32();
                            AllSessions[s].Circuits[c].Elements.Add(Elmnt);
                        }

                        for (int L = 0; L < AllSessions[s].Circuits[c].nLinks; L++)
                        {
                            Link lnk = new Link();

                            lnk.i = br.ReadInt32();
                            lnk.iElement = br.ReadInt32();
                            lnk.j = br.ReadInt32();
                            lnk.jElement = br.ReadInt32();
                            AllSessions[s].Circuits[c].Links.Add(lnk);
                        }

                    }

                    EIS.nSsn++;
                }

                int nAllSessionsData = br.ReadInt32();

                for (int iSD = 0; iSD < nAllSessionsData; iSD++)
                {
                    SessionOutputData SD = new SessionOutputData();

                    SD.ACAmpDim = br.ReadInt32();
                    SD.ACFrqDim = br.ReadInt32();
                    SD.DCVltDim = br.ReadInt32();
                    SD.IVAmpDim = br.ReadInt32();
                    SD.ReceivedDataCount = br.ReadInt32();

                    if (AllSessions[iSD].Mode == 0)
                    {
                        SD.Frq = new double[SD.ReceivedDataCount];
                        for (int i = 0; i < SD.ReceivedDataCount; i++) SD.Frq[i] = br.ReadDouble();
                    }

                    //if (AllSessions[iSD].Mode == 90)
                    //{
                    //    SD.Amp = new double[SD.ReceivedDataCount];
                    //    for (int i = 0; i < SD.ReceivedDataCount; i++) SD.Amp[i] = br.ReadDouble();
                    //}

                    if (AllSessions[iSD].Mode == 1 || AllSessions[iSD].Mode == 2 || AllSessions[iSD].Mode == 3)
                    {
                        SD.Vlt = new double[SD.ReceivedDataCount];
                        for (int i = 0; i < SD.ReceivedDataCount; i++) SD.Vlt[i] = br.ReadDouble();
                        SD.Amp = new double[SD.ReceivedDataCount];
                        for (int i = 0; i < SD.ReceivedDataCount; i++) SD.Amp[i] = br.ReadDouble();
                    }

                    if (AllSessions[iSD].Mode == 0 || AllSessions[iSD].Mode == 1)
                    {
                        SD.Imz = new double[SD.ReceivedDataCount];
                        SD.overflow = new bool[SD.ReceivedDataCount];
                        SD.ReZ = new double[SD.ReceivedDataCount];
                        for (int i = 0; i < SD.ReceivedDataCount; i++)
                        {
                            SD.Imz[i] = br.ReadDouble();
                            SD.overflow[i] = br.ReadBoolean();
                            SD.ReZ[i] = br.ReadDouble();
                        }
                    }

                    AllSessionsData.Add(SD);
                }

                FileProtocol.Close();
                br.Close();

                SetStatus("File is opened successfully ...");
                if (isOpenNewFile)
                {
                    EIS.FileName = FileName;
                    EIS.isFile = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unknown error. File is not read ...");
                SetStatus("Unknown error during reading File ...");
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void ClearAll()
        {
            if (EIS.nSsn > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to save project?", "save", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    if (EIS.FileName == "")
                        BtnSaveAs_Click(null, null);
                    else
                        BtnSave_Click(null, null);
                }
                else if (dialogResult == DialogResult.No)
                {
                }
                else
                {
                    return;
                }
            }
            else
            {
            }

            AllSessions.Clear();
            AllSessionsData.Clear();
            foreach (RichTextBox gui in AllSessionsGUI)
            {
                gui.Dispose();
            }
            AllSessionsGUI.Clear();

            PanelProperties.Visible = false;

            EIS.nSsn = 0;
            EIS.Connected = false;
            EIS.FileName = "";
            EIS.ready = true;
            EIS.ReceiveMode = false;
            EIS.ReScaleFactor = FactoryDefault.ReScaleFactor;
            EIS.RunCompleted = false;
            EIS.RunningSession = -1;
            EIS.isFile = false;

            FormDiagram.Dispose();
            FormDiagram = new FormDiagram();
            isFormDiagram = false;
            FormFit.Dispose();
            FormFit = new FormFitting();
            isFormFit = false;
            FormDG.Dispose();
            FormDG = new FormDataGrid();
            isFormDG = false;
        }

        private void BtnAppend_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Append File";
            isOpenNewFile = false;
            openFileDialog1.ShowDialog();
        }

        private void BtnSsnExpLocation_Click(object sender, EventArgs e)
        {
            saveFileDialogSSnExp.Title = "Export File";
            saveFileDialogSSnExp.ShowDialog();
        }

        private void saveFileDialogSSnExp_FileOk(object sender, CancelEventArgs e)
        {
            if (isDataToExport)
            {
                ExportData(AllSessions[EIS.RunningSession], AllSessionsData[EIS.RunningSession], saveFileDialogSSnExp.FileName);
                isDataToExport = false;
            }
            else
            {
                AllSessions[Selected].ExportAtFinalDIR = saveFileDialogSSnExp.FileName;
                LoadSelectedProperties();
            }
        }

        private void ChBExport_CheckedChanged(object sender, EventArgs e)
        {
            AllSessions[Selected].isExportAtFinal = ChBExport.Checked;
            LoadSelectedProperties();
            //ChBExport.Focus();
        }

        private void ExportData(Sessions S, SessionOutputData SD, string Path)
        {
            try
            {
                StreamWriter FileProtocol = new StreamWriter(Path);

                for (int i = 0; i < SD.ReceivedDataCount; i++)
                {
                    if (S.Mode==0) FileProtocol.Write(SD.Frq[i].ToString() + "   " + SD.ReZ[i].ToString() + "   " + SD.Imz[i].ToString() + "\n");
                    if (S.Mode == 1) FileProtocol.Write(SD.Vlt[i].ToString() + "   " + SD.ReZ[i].ToString() + "   " + SD.Imz[i].ToString() + "\n");
                    //if (S.Mode == 2) FileProtocol.Write(SD.Amp[i].ToString() + "   " + SD.ReZ[i].ToString() + "   " + SD.Imz[i].ToString() + "\n");
                    if (S.Mode == 2 || S.Mode == 3) FileProtocol.Write(SD.Vlt[i].ToString() + "   " + SD.Amp[i].ToString() + "\n");
                }

                FileProtocol.Close();
                SetStatus("successfully exported ...");
            }
            catch (Exception)
            {
                MessageBox.Show("Unknown error. File is not writen ...");
                SetStatus("Unknown error during exporting data ...");
            }
        }

        private void CBMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((CBMode.SelectedIndex == 0 && Settings.isEIS) || (CBMode.SelectedIndex == 1 && Settings.isMSH) || (CBMode.SelectedIndex == 2 && Settings.isChrono) || (CBMode.SelectedIndex == 3 && (Settings.isIV0 || Settings.isCV)) || (CBMode.SelectedIndex == 4 && Settings.isPulse))
            {
                AllSessions[Selected].Mode = CBMode.SelectedIndex;
            }
            else
            {
                MessageBox.Show("This feature is not available ...");
                CBMode.SelectedIndex = AllSessions[Selected].Mode;
            }
            LoadSelectedProperties();
            //CBMode.Focus();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DeleteSession(Selected);
            Selected = -1;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteSession(Selected);
            Selected = -1;
        }

        private void DeleteSession(int Index)
        {
            if (Selected > -1 && EIS.nSsn>0)
            {
                AllSessions.RemoveAt(Index);
                AllSessionsData.RemoveAt(Index);
                AllSessionsGUI[Index].Dispose();
                AllSessionsGUI.RemoveAt(Index);
                DeSelectAll();
                PanelProperties.Visible = false;
                EIS.nSsn--;
                if (FormFit.SessionName.SelectedIndex == Index) FormFit.SessionName.SelectedIndex = -1;
                FormFit.SessionName.Items.RemoveAt(Index);
                FormFitting.FitSelectedSession = FormFit.SessionName.SelectedIndex;

                if (FormDiagram.SessionName.SelectedIndex == Index) FormDiagram.SessionName.SelectedIndex = -1;
                FormDiagram.SessionName.Items.RemoveAt(Index);
                FormDiagram.PlotIndex = FormDiagram.SessionName.SelectedIndex;

                if (FormDG.SessionName.SelectedIndex == Index) FormDG.SessionName.SelectedIndex = -1;
                FormDG.SessionName.Items.RemoveAt(Index);
                FormDataGrid.DGSelectedSession = FormDG.SessionName.SelectedIndex;

                for (int i = Index; i < EIS.nSsn; i++)
                {
                    int OldX = AllSessionsGUI[i].Location.X;
                    int OldY = AllSessionsGUI[i].Location.Y;
                    AllSessionsGUI[i].Location = new Point(OldX, OldY - 37);
                }
            }

        }

        private void BtnDuplicate_Click(object sender, EventArgs e)
        {
            if (Selected != -1 && EIS.nSsn>0) Duplicate(Selected);
        }

        private void duplicateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Duplicate(Selected);
        }

        private void Duplicate(int Index)
        {
            int ns = EIS.nSsn + 1;
            DeSelectAll();
            Sessions NewSession = new Sessions();
            NewSession.active = AllSessions[Index].active;
            NewSession.isCVEnable = AllSessions[Index].isCVEnable;
            NewSession.V_OCT = AllSessions[Index].V_OCT;
            NewSession.IdealVoltage = AllSessions[Index].IdealVoltage;
            NewSession.isOCP = AllSessions[Index].isOCP;
            NewSession.isOCPAutoStart = AllSessions[Index].isOCPAutoStart;
            NewSession.PGmode = AllSessions[Index].PGmode;
            NewSession.RelRef = AllSessions[Index].RelRef;
            NewSession.EqTime = AllSessions[Index].EqTime;
            NewSession.Mode = AllSessions[Index].Mode;

            NewSession.EISDCCurrentRangeModea = AllSessions[Index].EISDCCurrentRangeModea;
            NewSession.EISACRegulatorMode = AllSessions[Index].EISACRegulatorMode;
            NewSession.EISACCurrentRangeMode = AllSessions[Index].EISACCurrentRangeMode;
            NewSession.EISVmlpMax = AllSessions[Index].EISVmlpMax;
            NewSession.EISImlpMax = AllSessions[Index].EISImlpMax;
            NewSession.EISfilterMode = AllSessions[Index].EISfilterMode;
            NewSession.EISAverageNumberL = AllSessions[Index].EISAverageNumberL;
            NewSession.EISAverageNumberH = AllSessions[Index].EISAverageNumberH;
            NewSession.EISMode = AllSessions[Index].EISMode;
            NewSession.EISOCMode = AllSessions[Index].EISOCMode;
            NewSession.EISVoltageRangeMode = AllSessions[Index].EISVoltageRangeMode;
            NewSession.IVVoltageRangeMode = AllSessions[Index].IVVoltageRangeMode;
            NewSession.IVChrono_VFilter = AllSessions[Index].IVChrono_VFilter;
            NewSession.Pulse_VFilter = AllSessions[Index].Pulse_VFilter;
            NewSession.PulseVoltageRangeMode = AllSessions[Index].PulseVoltageRangeMode;
            NewSession.PulseCurrentRangeMode = AllSessions[Index].PulseCurrentRangeMode;
            NewSession.PulseVmlp = AllSessions[Index].PulseVmlp;
            NewSession.PulseImlpp = AllSessions[Index].PulseImlpp;
            NewSession.PulseReadingEdgemode = AllSessions[Index].PulseReadingEdgemode;
            NewSession.PulseVoltammetryMode = AllSessions[Index].PulseVoltammetryMode;
            
            NewSession.DCVoltageConstant = AllSessions[Index].DCVoltageConstant;
            NewSession.DCVoltageFrom = AllSessions[Index].DCVoltageFrom;
            NewSession.DCVoltageTo = AllSessions[Index].DCVoltageTo;
            NewSession.DCVoltageStep = AllSessions[Index].DCVoltageStep;

            NewSession.ACAmpConstant = AllSessions[Index].ACAmpConstant;
            NewSession.ACAmpFrom = AllSessions[Index].ACAmpFrom;
            NewSession.ACAmpTo = AllSessions[Index].ACAmpTo;
            NewSession.ACAmpStep = AllSessions[Index].ACAmpStep;

            NewSession.ACFrqConstant = AllSessions[Index].ACFrqConstant;
            NewSession.ACFrqFrom = AllSessions[Index].ACFrqFrom;
            NewSession.ACFrqTo = AllSessions[Index].ACFrqTo;
            NewSession.ACFrqNStep = AllSessions[Index].ACFrqNStep;

            NewSession.IVCurrentRangeMode = AllSessions[Index].IVCurrentRangeMode;
            NewSession.IVVmlp = AllSessions[Index].IVVmlp;
            NewSession.IVImlp = AllSessions[Index].IVImlp;
            NewSession.IVVoltageFrom = AllSessions[Index].IVVoltageFrom;
            NewSession.IVVoltageNStepp = AllSessions[Index].IVVoltageNStepp;
            NewSession.CVStartpoint = AllSessions[Index].CVStartpoint;

            NewSession.PretreatmentVoltage = AllSessions[Index].PretreatmentVoltage;
            NewSession.isPreProcProbOn = AllSessions[Index].isPreProcProbOn;
            NewSession.isChBPostProcProbOff = AllSessions[Index].isChBPostProcProbOff;

            NewSession.CVItteration = AllSessions[Index].CVItteration;
            NewSession.IVvoltageTo = AllSessions[Index].IVvoltageTo;
            NewSession.ChronoEndTime = AllSessions[Index].ChronoEndTime;
            NewSession.IVTimestep = AllSessions[Index].IVTimestep;

            NewSession.Chrono_n = AllSessions[Index].Chrono_n;
            NewSession.Chrono_Total_Period = AllSessions[Index].Chrono_Total_Period;
            NewSession.Chrono_Pulse_Period = AllSessions[Index].Chrono_Pulse_Period;
            NewSession.Chrono_Pulse_Level = AllSessions[Index].Chrono_Pulse_Level;
            NewSession.Chrono_Pulse_Amplitude = AllSessions[Index].Chrono_Pulse_Amplitude;
            NewSession.Chrono_Level_Step = AllSessions[Index].Chrono_Level_Step;
            NewSession.Chrono_Amplitude_step = AllSessions[Index].Chrono_Amplitude_step;
            NewSession.Chrono_isfast = AllSessions[Index].Chrono_isfast;
            NewSession.Chrono_nsteps = AllSessions[Index].Chrono_nsteps;
            NewSession.Chrono_t1 = AllSessions[Index].Chrono_t1;
            NewSession.Chrono_t2 = AllSessions[Index].Chrono_t2;
            NewSession.Chrono_t3 = AllSessions[Index].Chrono_t3;
            NewSession.Chrono_t4 = AllSessions[Index].Chrono_t4;
            NewSession.Chrono_t5 = AllSessions[Index].Chrono_t5;
            NewSession.Chrono_t6 = AllSessions[Index].Chrono_t6;
            NewSession.Chrono_t7 = AllSessions[Index].Chrono_t7;
            NewSession.Chrono_t8 = AllSessions[Index].Chrono_t8;
            NewSession.Chrono_t9 = AllSessions[Index].Chrono_t9;
            NewSession.Chrono_t10 = AllSessions[Index].Chrono_t10;
            NewSession.Chrono_v1 = AllSessions[Index].Chrono_v1;
            NewSession.Chrono_v2 = AllSessions[Index].Chrono_v2;
            NewSession.Chrono_v3 = AllSessions[Index].Chrono_v3;
            NewSession.Chrono_v4 = AllSessions[Index].Chrono_v4;
            NewSession.Chrono_v5 = AllSessions[Index].Chrono_v5;
            NewSession.Chrono_v6 = AllSessions[Index].Chrono_v6;
            NewSession.Chrono_v7 = AllSessions[Index].Chrono_v7;
            NewSession.Chrono_v8 = AllSessions[Index].Chrono_v8;
            NewSession.Chrono_v9 = AllSessions[Index].Chrono_v9;
            NewSession.Chrono_v10 = AllSessions[Index].Chrono_v10;
            NewSession.Chrono_dt = AllSessions[Index].Chrono_dt;
            NewSession.Chrono_ocp1 = AllSessions[Index].Chrono_ocp1;
            NewSession.Chrono_ocp2 = AllSessions[Index].Chrono_ocp2;
            NewSession.Chrono_ocp3 = AllSessions[Index].Chrono_ocp3;
            NewSession.Chrono_ocp4 = AllSessions[Index].Chrono_ocp4;
            NewSession.Chrono_ocp5 = AllSessions[Index].Chrono_ocp5;
            NewSession.Chrono_ocp6 = AllSessions[Index].Chrono_ocp6;
            NewSession.Chrono_ocp7 = AllSessions[Index].Chrono_ocp7;
            NewSession.Chrono_ocp8 = AllSessions[Index].Chrono_ocp8;
            NewSession.Chrono_ocp9 = AllSessions[Index].Chrono_ocp9;
            NewSession.Chrono_ocp10 = AllSessions[Index].Chrono_ocp10;
            NewSession.ExportAtFinalDIR = AllSessions[Index].ExportAtFinalDIR;
            NewSession.isExportAtFinal = AllSessions[Index].isExportAtFinal;
            NewSession.isStarted = AllSessions[Index].isStarted;
            NewSession.isFinished = AllSessions[Index].isFinished;
            NewSession.isACAmpConstant = AllSessions[Index].isACAmpConstant;
            NewSession.isACFrqConstant = AllSessions[Index].isACFrqConstant;
            NewSession.isDCVoltageConstant = AllSessions[Index].isDCVoltageConstant;
            

            NewSession.name = "Session " + ns.ToString();
            NewSession.index = EIS.nSsn;
            AllSessions.Add(NewSession);

            RichTextBox NewSessionGUI = new RichTextBox();
            NewSessionGUI.Location = new Point(0, EIS.nSsn * 37);
            NewSessionGUI.Size = new Size(1000, 35);
            NewSessionGUI.BorderStyle = BorderStyle.Fixed3D;
            AllSessionsGUI.Add(NewSessionGUI);
            AllSessionsGUI[EIS.nSsn].Parent = Desktop;
            AllSessionsGUI[EIS.nSsn].Show();
            AllSessionsGUI[EIS.nSsn].MouseDown += new System.Windows.Forms.MouseEventHandler(this.SessionsGUI_MouseDown);
            AllSessionsGUI[EIS.nSsn].BackColor = SelectedColor;
            AllSessionsGUI[EIS.nSsn].ReadOnly = true;
            AllSessionsGUI[EIS.nSsn].Cursor = Cursor.Current;
            AllSessionsGUI[EIS.nSsn].ForeColor = AllSessionsGUI[Index].ForeColor;
            AllSessionsGUI[EIS.nSsn].Text = "Session Name: " + NewSession.name + " " + AllSessions[Index].DataAndTime;

            Selected = EIS.nSsn;
            FormDiagram.SessionName.Items.Add(AllSessions[Selected].name);
            FormFit.SessionName.Items.Add(AllSessions[Selected].name);
            FormDG.SessionName.Items.Add(AllSessions[Selected].name);
            LoadSelectedProperties();

            SessionOutputData EmptyData = new SessionOutputData();
            EmptyData.ACAmpDim = AllSessionsData[Index].ACAmpDim;
            EmptyData.ACFrqDim = AllSessionsData[Index].ACFrqDim;
            EmptyData.DCVltDim = AllSessionsData[Index].DCVltDim;
            EmptyData.IVAmpDim = AllSessionsData[Index].IVAmpDim;
            EmptyData.ReceivedDataCount = AllSessionsData[Index].ReceivedDataCount;

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
                        EmptyData.Frq[i] = AllSessionsData[Index].Frq[i];
                    else
                    {
                        EmptyData.Vlt[i] = AllSessionsData[Index].Vlt[i];
                        EmptyData.Amp[i] = AllSessionsData[Index].Amp[i];
                    }
                    EmptyData.ReZ[i] = AllSessionsData[Index].ReZ[i];
                    EmptyData.Imz[i] = AllSessionsData[Index].Imz[i];
                    EmptyData.overflow[i] = AllSessionsData[Index].overflow[i];
                }
            }

            if (NewSession.Mode == 2 || NewSession.Mode == 3)   //IV mode
            {
                EmptyData.Vlt = new double[EmptyData.ReceivedDataCount];
                EmptyData.Amp = new double[EmptyData.ReceivedDataCount];
                for (int i = 0; i < EmptyData.ReceivedDataCount; i++)
                {
                    EmptyData.Vlt[i] = AllSessionsData[Index].Vlt[i];
                    EmptyData.Amp[i] = AllSessionsData[Index].Amp[i];
                }
            }

            AllSessionsData.Add(EmptyData);


            //FormFit.SFits=new FormFit.
            EIS.nSsn++;
        }

        private void exportDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AllSessions[Selected].isStarted)
            {
                if (AllSessions[Selected].isFinished)
                {
                    isDataToExport = true;
                    saveFileDialogSSnExp.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Session doesn't competed ...");
                }
            }
            else
            {
                MessageBox.Show("There is no data to export ...");
            }
        }

        private void BtnPauseContinue_Click(object sender, EventArgs e)
        {
            if (isRunStart)
            {
                if (isRunPause)
                {
                    BtnPauseContinue.Text = "Pause";
                    BtnPauseContinue.Font = new Font(BtnPauseContinue.Font.FontFamily, 8.0F);

                    SampleOnBtn.Enabled = false;
                    DummyOnBtn.Enabled = false;

                    isRunPause = false;
                }
                else
                {
                    isRunPause = true;
                    if (!isProbOn && !isDummyOn)
                    {
                        SampleOnBtn.Enabled = true;
                        DummyOnBtn.Enabled = true;
                    }
                    else
                    {
                        if (isProbOn) SampleOnBtn.Enabled = true;
                        if (isDummyOn) DummyOnBtn.Enabled = true;
                    }
                    BtnPauseContinue.Text = "Continue";
                    BtnPauseContinue.Font = new Font(BtnPauseContinue.Font.FontFamily, 6.7F);
                }

            }
        }

        private void BtnShowData_Click(object sender, EventArgs e)
        {
            if (isFormDG)
            {
                FormDG.Hide();
                isFormDG = false;
            }
            else
            {
                FormDG.Show(this);
                isFormDG = true;
            }
        }

        private void TBIVVoltageFrom_TextChanged(object sender, EventArgs e)
        {
            if (!(AllSessions[Selected].PGmode == 3))
                DigitTextChange(ref AllSessions[Selected].IVVoltageFrom, TBIVVoltageFrom, -5, 5);
            else
                DigitTextChange(ref AllSessions[Selected].IVVoltageFrom, TBIVVoltageFrom, -5000000, 5000000);
            TBIVVelosity_Validated(null, null);
            TBIVVoltageFrom.Text = AllSessions[Selected].IVVoltageFrom.ToString();

            double max = AllSessions[Selected].IVvoltageTo;
            double min = AllSessions[Selected].IVVoltageFrom;
            if (AllSessions[Selected].Mode != 2)
            {
                double dV = (double)((max - min) / (AllSessions[Selected].IVVoltageNStepp - 1));
                this.TBIVVoltagedV.Validated -= new System.EventHandler(this.TBIVVoltagedV_Validated);
                TBIVVoltagedV.Text = dV.ToString("0.00000000");
                this.TBIVVoltagedV.Validated += new System.EventHandler(this.TBIVVoltagedV_Validated);
            }

            if (AllSessions[Selected].Mode == 3 && AllSessions[Selected].isCVEnable)
            {
                int isValid = 0;
                double newStep = 0;
                int newNStep = 0;
                CheckCVStep(max, min, ref isValid, ref newStep, ref newNStep);
                if (isValid != 0)
                {
                    this.TBIVVoltagedV.Validated -= new System.EventHandler(this.TBIVVoltagedV_Validated);
                    TBIVVoltagedV.Text = newStep.ToString("0.00000000");
                    //this.TBIVVoltagedV_Validated(null,null);
                    this.TBIVVoltagedV.Validated += new System.EventHandler(this.TBIVVoltagedV_Validated);

                    this.TBIVVoltageStep.Validated -= new System.EventHandler(this.TBIVVoltageStep_TextChanged);
                    TBIVVoltageStep.Text = newNStep.ToString();
                    this.TBIVVoltageStep.Validated += new System.EventHandler(this.TBIVVoltageStep_TextChanged);
                }
            }

        }

        private void TBIVVoltageTo_TextChanged(object sender, EventArgs e)
        {
            if (AllSessions[Selected].Mode == 3) //I-V & C-V
            {
                if (!(AllSessions[Selected].PGmode == 3))
                    DigitTextChange(ref AllSessions[Selected].IVvoltageTo, TBIVVoltageTo, -5, 5);
                else
                    DigitTextChange(ref AllSessions[Selected].IVvoltageTo, TBIVVoltageTo, -5000000, 5000000);
            }
            else if (AllSessions[Selected].Mode == 2)  //Chrono
                DigitTextChange(ref AllSessions[Selected].ChronoEndTime, TBIVVoltageTo, 0.00001, 100000);

            TBIVVelosity_Validated(null, null);

            if (AllSessions[Selected].Mode == 3)
                TBIVVoltageTo.Text = AllSessions[Selected].IVvoltageTo.ToString();
            else if (AllSessions[Selected].Mode == 2)
                TBIVVoltageTo.Text = AllSessions[Selected].ChronoEndTime.ToString();

            double max = AllSessions[Selected].IVvoltageTo;
            double min = AllSessions[Selected].IVVoltageFrom;
            if (AllSessions[Selected].Mode == 2)
            {
                min = 0;
                max = AllSessions[Selected].ChronoEndTime;
            }
            double dV = (double)((max - min) / (AllSessions[Selected].IVVoltageNStepp - 1));
            this.TBIVVoltagedV.Validated -= new System.EventHandler(this.TBIVVoltagedV_Validated);
            TBIVVoltagedV.Text = dV.ToString("0.00000000");
            this.TBIVVoltagedV.Validated += new System.EventHandler(this.TBIVVoltagedV_Validated);

            if (AllSessions[Selected].Mode == 3 && AllSessions[Selected].isCVEnable)
            {
                int isValid = 0;
                double newStep = 0;
                int newNStep = 0;
                CheckCVStep(max, min, ref isValid, ref newStep, ref newNStep);
                if (isValid != 0)
                {
                    this.TBIVVoltagedV.Validated -= new System.EventHandler(this.TBIVVoltagedV_Validated);
                    TBIVVoltagedV.Text = newStep.ToString("0.00000000");
                    //this.TBIVVoltagedV_Validated(null,null);
                    this.TBIVVoltagedV.Validated += new System.EventHandler(this.TBIVVoltagedV_Validated);

                    this.TBIVVoltageStep.Validated -= new System.EventHandler(this.TBIVVoltageStep_TextChanged);
                    TBIVVoltageStep.Text = newNStep.ToString();
                    this.TBIVVoltageStep.Validated += new System.EventHandler(this.TBIVVoltageStep_TextChanged);


                }
            }
        }

        private void TBIVVoltageStep_TextChanged(object sender, EventArgs e)
        {
            int Maxim = 9999;
            if (AllSessions[Selected].Mode == 2 && AllSessions[Selected].Chrono_isfast) Maxim = 512;
            IntDigitTextChange(ref AllSessions[Selected].IVVoltageNStepp, TBIVVoltageStep, 2, Maxim);
            TBIVVelosity_Validated(null, null);
            TBIVVoltageStep.Text = AllSessions[Selected].IVVoltageNStepp.ToString();

            double max = AllSessions[Selected].IVvoltageTo;
            double min = AllSessions[Selected].IVVoltageFrom;
            if (AllSessions[Selected].Mode == 2)
            {
                min = 0;
                max = AllSessions[Selected].ChronoEndTime;
            }
            double dV = (double)((max - min) / (AllSessions[Selected].IVVoltageNStepp - 1));
            this.TBIVVoltagedV.Validated -= new System.EventHandler(this.TBIVVoltagedV_Validated);
            TBIVVoltagedV.Text = dV.ToString("0.00000000");
            this.TBIVVoltagedV.Validated += new System.EventHandler(this.TBIVVoltagedV_Validated);
            //LoadSelectedProperties();
            //TBIVVoltageStep.Focus();

            if (AllSessions[Selected].Mode == 3 && AllSessions[Selected].isCVEnable)
            {
                int isValid = 0;
                double newStep = 0;
                int newNStep = 0;
                CheckCVStep(max, min, ref isValid, ref newStep, ref newNStep);
                if (isValid !=0)
                {
                    this.TBIVVoltagedV.Validated -= new System.EventHandler(this.TBIVVoltagedV_Validated);
                    TBIVVoltagedV.Text = newStep.ToString("0.00000000");
                    //this.TBIVVoltagedV_Validated(null,null);
                    this.TBIVVoltagedV.Validated += new System.EventHandler(this.TBIVVoltagedV_Validated);

                    this.TBIVVoltageStep.Validated -= new System.EventHandler(this.TBIVVoltageStep_TextChanged);
                    TBIVVoltageStep.Text = newNStep.ToString();
                    this.TBIVVoltageStep.Validated += new System.EventHandler(this.TBIVVoltageStep_TextChanged);

                    
                }
            }

            
        }

        private void CBIVRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (BoardType==1 && CBIVRange.SelectedIndex > 2)    //Added in EISProject66
            //{
            //    MessageBox.Show("This Item is not available in this version of device.");
            //    CBIVRange.SelectedIndex = AllSessions[Selected].IVCurrentRangeMode;
            //    return;
            //}

            if (isCBIVRangeCompleted && AllSessions[Selected].IVCurrentRangeMode != CBIVRange.SelectedIndex)
            {
                isCBIVRangeCompleted = false;
                /*if (CBIVRange.SelectedIndex < 2)
                {
                    AllSessions[Selected].IVCurrentRangeMode = CBIVRange.SelectedIndex;
                }
                else
                {
                    MessageBox.Show("You are not allowed to change to this range manually ...");
                }*/
                AllSessions[Selected].IVCurrentRangeMode = CBIVRange.SelectedIndex;
                //LoadSelectedProperties();


                isVmlpCompleted = false;
                isImlpCompleted = false;

                VMLP.Items.Clear();
                IMLP.Items.Clear();

                int pow2mlp = 1;
                for (int mlp = 0; mlp < 7; mlp++)
                {
                    double Vmax = Settings.GetDCV_Domain;
                    double Imax = 0;

                    if (CBIVRange.SelectedIndex == 0)
                        Imax = 1;
                    else if (CBIVRange.SelectedIndex == 1)
                        Imax = 100;
                    else if (CBIVRange.SelectedIndex == 2)
                        Imax = 10;
                    else if (CBIVRange.SelectedIndex == 3)  //Added in EISProject66
                        Imax = 1;
                    else if (CBIVRange.SelectedIndex == 4)  //Added in EISProject71
                        Imax = 100;
                    else if (CBIVRange.SelectedIndex == 5)  //Added in EISProject71
                        Imax = 10;
                    else if (CBIVRange.SelectedIndex == 6)  //Added in EISProject71
                        Imax = 1;
                    else if (CBIVRange.SelectedIndex == 7)  //Added in EISProject71
                        Imax = 100;

                    double dImax = 1.0 * Imax / pow2mlp;
                    double dVmax = 1.0 * Vmax / pow2mlp;

                    double Ifact = Math.Pow(10, Math.Floor(Math.Log10(dImax)));
                    double Vfact = Math.Pow(10, Math.Floor(Math.Log10(dVmax)));
                    dImax = Math.Floor(dImax / Ifact) * Ifact;
                    dVmax = Math.Floor(dVmax / Vfact) * Vfact;

                    
                    VMLP.Items.Add("[-" + dVmax.ToString() + "(V)  ..  " + dVmax.ToString() + "(V)]");
                    //inja to halghe tekrare
                    if (CBIVRange.SelectedIndex <= 0)
                    {
                        IMLP.Items.Add("[-" + dImax.ToString() + "(A)  ..  " + dImax.ToString() + "(A)]");
                        if (AllSessions[Selected].IVImlp == mlp) IVMaxFineCurrent = dImax;
                    }
                    else if (CBIVRange.SelectedIndex == 1)
                    {
                        IMLP.Items.Add("[-" + dImax.ToString() + "(mA)  ..  " + dImax.ToString() + "(mA)]");
                        if (AllSessions[Selected].IVImlp == mlp) IVMaxFineCurrent = dImax * 0.001;
                    }
                    else if (CBIVRange.SelectedIndex == 2)
                    {
                        IMLP.Items.Add("[-" + dImax.ToString() + "(mA)  ..  " + dImax.ToString() + "(mA)]");
                        if (AllSessions[Selected].IVImlp == mlp) IVMaxFineCurrent = dImax * 0.001;
                    }
                    else if (CBIVRange.SelectedIndex == 3)                                                          //Added in EISProject66
                    {
                        IMLP.Items.Add("[-" + dImax.ToString() + "(mA)  ..  " + dImax.ToString() + "(mA)]");
                        if (AllSessions[Selected].IVImlp == mlp)
                            IVMaxFineCurrent = dImax * 0.001;
                    }
                    else if (CBIVRange.SelectedIndex == 4)                                                          //Added in EISProject71
                    {
                        IMLP.Items.Add("[-" + dImax.ToString() + "(uA)  ..  " + dImax.ToString() + "(uA)]");
                        if (AllSessions[Selected].IVImlp == mlp) IVMaxFineCurrent = dImax * 0.000001;
                    }
                    else if (CBIVRange.SelectedIndex == 5)                                                          //Added in EISProject71
                    {
                        IMLP.Items.Add("[-" + dImax.ToString() + "(uA)  ..  " + dImax.ToString() + "(uA)]");
                        if (AllSessions[Selected].IVImlp == mlp) IVMaxFineCurrent = dImax * 0.000001;
                    }
                    else if (CBIVRange.SelectedIndex == 6)                                                          //Added in EISProject71
                    {
                        IMLP.Items.Add("[-" + dImax.ToString() + "(uA)  ..  " + dImax.ToString() + "(uA)]");
                        if (AllSessions[Selected].IVImlp == mlp) IVMaxFineCurrent = dImax * 0.000001;
                    }
                    else if (CBIVRange.SelectedIndex == 7)                                                          //Added in EISProject71
                    {
                        IMLP.Items.Add("[-" + dImax.ToString() + "(nA)  ..  " + dImax.ToString() + "(nA)]");
                        if (AllSessions[Selected].IVImlp == mlp) IVMaxFineCurrent = dImax * 0.000000001;
                    }
                    
                    pow2mlp = pow2mlp * 2;
                }

                
                isVmlpCompleted = true;
                isImlpCompleted = true;

                VMLP.SelectedIndex = AllSessions[Selected].IVVmlp;
                IMLP.SelectedIndex = AllSessions[Selected].IVImlp;

                isIVRangesChanged = true;
                isCBIVRangeCompleted = true;
                //CBIVRange.Focus();
                LoadSelectedProperties();
            }
        }

        private void BtnSetting_Click(object sender, EventArgs e)
        {
            if (!isFormSetting)
            {
                FormSettings FormSetting = new FormSettings();
                FormSetting.Show(this);
                isFormSetting = true;
            }
        }

        public static void saveSetting(ref SettingsData Settings, string FileName)
        {
            try
            {
                FileStream FileProtocol = new FileStream(FileName, FileMode.Create);
                BinaryWriter bw = new BinaryWriter(FileProtocol);
                byte counter = 0;
                bw.Write(++counter); bw.Write(Settings.Version);

                bw.Write(++counter); bw.Write(Settings.IsIVReceiverUnsigned);
                bw.Write(++counter); bw.Write(Settings.isDigitalEISReceiverUnsigned);

                bw.Write(++counter); bw.Write(Settings.SetDCV_Offset);
                bw.Write(++counter); bw.Write(Settings.SetDCV_Domain);
                bw.Write(++counter); bw.Write(Settings.SetDCV_factor);

                bw.Write(++counter); bw.Write(Settings.GetDCV_OffsetMLP0);
                bw.Write(++counter); bw.Write(Settings.GetDCV_OffsetMLP1);
                bw.Write(++counter); bw.Write(Settings.GetDCV_OffsetMLP2);
                bw.Write(++counter); bw.Write(Settings.GetDCV_OffsetMLP3);
                bw.Write(++counter); bw.Write(Settings.GetDCV_OffsetMLP4);
                bw.Write(++counter); bw.Write(Settings.GetDCV_offsetMLP5);
                bw.Write(++counter); bw.Write(Settings.GetDCV_OffsetMLP6);
                bw.Write(++counter); bw.Write(Settings.GetDCV_Domain);
                bw.Write(++counter); bw.Write(Settings.GetDCV_factor);

                bw.Write(++counter); bw.Write(Settings.SetDCI_Offset);
                bw.Write(++counter); bw.Write(Settings.SetDCI_Domain);
                bw.Write(++counter); bw.Write(Settings.SetDCI_Select0);
                bw.Write(++counter); bw.Write(Settings.SetDCI_Select1);
                bw.Write(++counter); bw.Write(Settings.SetDCI_Select2);
                bw.Write(++counter); bw.Write(Settings.SetDCI_factor);

                bw.Write(++counter); bw.Write(Settings.GetDCI_Offset0d);
                bw.Write(++counter); bw.Write(Settings.GetDCI_Offset1d);
                bw.Write(++counter); bw.Write(Settings.GetDCI_Offset2);
                bw.Write(++counter); bw.Write(Settings.GetDCI_Offset3d);
                bw.Write(++counter); bw.Write(Settings.GetDCI_Offset4d);
                bw.Write(++counter); bw.Write(Settings.GetDCI_Offset5d);
                bw.Write(++counter); bw.Write(Settings.GetDCI_Offset6d);
                bw.Write(++counter); bw.Write(Settings.GetDCI_Offset7d);
                bw.Write(++counter); bw.Write(Settings.GetDCI_Domain);
                bw.Write(++counter); bw.Write(Settings.GetDCI_Select0);
                bw.Write(++counter); bw.Write(Settings.GetDCI_Select1);
                bw.Write(++counter); bw.Write(Settings.GetDCI_select2);
                bw.Write(++counter); bw.Write(Settings.GetDCI_Select3);
                bw.Write(++counter); bw.Write(Settings.GetDCI_Select4);
                bw.Write(++counter); bw.Write(Settings.GetDCI_Select5);
                bw.Write(++counter); bw.Write(Settings.GetDCI_Select6);
                bw.Write(++counter); bw.Write(Settings.GetDCI_Select7);
                bw.Write(++counter); bw.Write(Settings.GetDCI_factor);

                bw.Write(++counter); bw.Write(Settings.SetDigitalACV_Offset);
                bw.Write(++counter); bw.Write(Settings.SetDigitalACV_Domain);
                bw.Write(++counter); bw.Write(Settings.SetDigitalACV_factor);

                bw.Write(++counter); bw.Write(Settings.GetDigitalACV_Offset);
                bw.Write(++counter); bw.Write(Settings.GetDigitalACV_Domain);
                bw.Write(++counter); bw.Write(Settings.GetDigitalACV_factor);

                bw.Write(++counter); bw.Write(Settings.SetDigitalf_Min);
                bw.Write(++counter); bw.Write(Settings.SetDigitalf_Max);
                bw.Write(++counter); bw.Write(Settings.SetDigitalf_clock);
                bw.Write(++counter); bw.Write(Settings.SetDigitalf_factor);

                bw.Write(++counter); bw.Write(Settings.GetDigitalf_Min);
                bw.Write(++counter); bw.Write(Settings.GetDigitalf_Max);
                bw.Write(++counter); bw.Write(Settings.GetDigitalf_clock);
                bw.Write(++counter); bw.Write(Settings.GetDigitalf_factor);

                bw.Write(++counter); bw.Write(Settings.AnalogCommon_intOffset);
                bw.Write(++counter); bw.Write(Settings.AnalogCommon_Domain);
                bw.Write(++counter); bw.Write(Settings.AnalogCommon_factor);

                bw.Write(++counter); bw.Write(Settings.Zeroset0);
                bw.Write(++counter); bw.Write(Settings.Zeroset1);
                bw.Write(++counter); bw.Write(Settings.isEIS);
                bw.Write(++counter); bw.Write(Settings.isMSH);
                bw.Write(++counter); bw.Write(Settings.isCV);
                bw.Write(++counter); bw.Write(Settings.isIV0);
                bw.Write(++counter); bw.Write(Settings.isChrono);
                bw.Write(++counter); bw.Write(Settings.isPulse);

                bw.Write(++counter); bw.Write(Settings.GalvanostatI_Select4);
                bw.Write(++counter); bw.Write(Settings.GalvanostatI_Select5);
                bw.Write(++counter); bw.Write(Settings.GalvanostatI_Select6);
                bw.Write(++counter); bw.Write(Settings.GalvanostatI_Select7);

                bw.Write(++counter); bw.Write(Settings.GalvanostatI_Select0);
                bw.Write(++counter); bw.Write(Settings.GalvanostatI_Select1);
                bw.Write(++counter); bw.Write(Settings.GalvanostatI_Select2);
                bw.Write(++counter); bw.Write(Settings.GalvanostatI_Select3);

                bw.Write(++counter); bw.Write(Settings.SetDCV_Select0);
                bw.Write(++counter); bw.Write(Settings.SetDCV_Select1);

                bw.Write(++counter); bw.Write(Settings.GetDCV_Select0);
                bw.Write(++counter); bw.Write(Settings.GetDCV_Select1);

                bw.Write(++counter); bw.Write(Settings.ACMultFactor_Select0);
                bw.Write(++counter); bw.Write(Settings.ACMultFactor_Select1);

                bw.Write(++counter); bw.Write(Settings.FilterC_V1);
                bw.Write(++counter); bw.Write(Settings.FilterC_V2);
                bw.Write(++counter); bw.Write(Settings.FilterC_I1);
                bw.Write(++counter); bw.Write(Settings.FilterC_I2);

                bw.Write(++counter); bw.Write(Settings.SetACVMaxS0);
                bw.Write(++counter); bw.Write(Settings.SetACVResoloution);

                bw.Write(++counter); bw.Write(Settings.GetACVMaxS0);
                bw.Write(++counter); bw.Write(Settings.GetACVResoloution0);

                bw.Write(++counter); bw.Write(Settings.VTau_L);
                bw.Write(++counter); bw.Write(Settings.VTau_H);
                bw.Write(++counter); bw.Write(Settings.ITau_L0);
                bw.Write(++counter); bw.Write(Settings.ITau_H0);
                bw.Write(++counter); bw.Write(Settings.ITau_L1);
                bw.Write(++counter); bw.Write(Settings.ITau_H1);
                bw.Write(++counter); bw.Write(Settings.ITau_L2);
                bw.Write(++counter); bw.Write(Settings.ITau_H2);

                bw.Close();
            }
            catch
            {
            }
        }

        public static void FillSettingDefault(ref SettingsData Settings)
        {
            Settings.IsIVReceiverUnsigned = Form1.FactoryDefault.isIVReceiverUnsigned;
            Settings.isDigitalEISReceiverUnsigned = Form1.FactoryDefault.isDigitalEISReceiverUnsigned;

            Settings.SetDCV_Offset = Form1.FactoryDefault.SetDCV_Offset;
            Settings.SetDCV_Domain = Form1.FactoryDefault.SetDCV_Domain;
            Settings.SetDCV_factor = Form1.FactoryDefault.SetDCV_factor;

            Settings.GetDCV_OffsetMLP0 = Form1.FactoryDefault.GetDCV_OffsetMLP0;
            Settings.GetDCV_OffsetMLP1 = Form1.FactoryDefault.GetDCV_OffsetMLP1;
            Settings.GetDCV_OffsetMLP2 = Form1.FactoryDefault.GetDCV_OffsetMLP2;
            Settings.GetDCV_OffsetMLP3 = Form1.FactoryDefault.GetDCV_OffsetMLP3;
            Settings.GetDCV_OffsetMLP4 = Form1.FactoryDefault.GetDCV_OffsetMLP4;
            Settings.GetDCV_offsetMLP5 = Form1.FactoryDefault.GetDCV_offsetMLP5;
            Settings.GetDCV_OffsetMLP6 = Form1.FactoryDefault.GetDCV_OffsetMLP6;
            Settings.GetDCV_Domain = Form1.FactoryDefault.GetDCV_Domain;
            Settings.GetDCV_factor = Form1.FactoryDefault.GetDCV_factor;

            Settings.SetDCI_Offset = Form1.FactoryDefault.SetDCI_Offset;
            Settings.SetDCI_Domain = Form1.FactoryDefault.SetDCI_Domain;
            Settings.SetDCI_Select0 = Form1.FactoryDefault.SetDCI_Select0;
            Settings.SetDCI_Select1 = Form1.FactoryDefault.SetDCI_Select1;
            Settings.SetDCI_Select2 = Form1.FactoryDefault.SetDCI_Select2;
            Settings.SetDCI_factor = Form1.FactoryDefault.SetDCI_factor;

            Settings.GetDCI_Offset0d = Form1.FactoryDefault.GetDCI_Offset0d;
            Settings.GetDCI_Offset1d = Form1.FactoryDefault.GetDCI_Offset1d;
            Settings.GetDCI_Offset2 = Form1.FactoryDefault.GetDCI_Offset2;
            Settings.GetDCI_Offset3d = Form1.FactoryDefault.GetDCI_Offset3d;
            Settings.GetDCI_Offset4d = Form1.FactoryDefault.GetDCI_Offset4d;
            Settings.GetDCI_Offset5d = Form1.FactoryDefault.GetDCI_Offset5d;
            Settings.GetDCI_Offset6d = Form1.FactoryDefault.GetDCI_Offset6d;
            Settings.GetDCI_Offset7d = Form1.FactoryDefault.GetDCI_Offset7d;
            Settings.GetDCI_Domain = Form1.FactoryDefault.GetDCI_Domain;
            Settings.GetDCI_Select0 = Form1.FactoryDefault.GetDCI_Select0;
            Settings.GetDCI_Select1 = Form1.FactoryDefault.GetDCI_Select1;
            Settings.GetDCI_select2 = Form1.FactoryDefault.GetDCI_select2;
            Settings.GetDCI_Select3 = Form1.FactoryDefault.GetDCI_Select3;
            Settings.GetDCI_Select4 = Form1.FactoryDefault.GetDCI_Select4;
            Settings.GetDCI_Select5 = Form1.FactoryDefault.GetDCI_Select5;
            Settings.GetDCI_Select6 = Form1.FactoryDefault.GetDCI_Select6;
            Settings.GetDCI_Select7 = Form1.FactoryDefault.GetDCI_Select7;
            Settings.GetDCI_factor = Form1.FactoryDefault.GetDCI_factor;

            Settings.SetDigitalACV_Offset = Form1.FactoryDefault.SetDigitalACV_Offset;
            Settings.SetDigitalACV_Domain = Form1.FactoryDefault.SetDigitalACV_Domain;
            Settings.SetDigitalACV_factor = Form1.FactoryDefault.SetDigitalACV_factor;

            Settings.GetDigitalACV_Offset = Form1.FactoryDefault.GetDigitalACV_Offset;
            Settings.GetDigitalACV_Domain = Form1.FactoryDefault.GetDigitalACV_Domain;
            Settings.GetDigitalACV_factor = Form1.FactoryDefault.GetDigitalACV_factor;

            Settings.SetDigitalf_Min = Form1.FactoryDefault.SetDigitalf_Min;
            Settings.SetDigitalf_Max = Form1.FactoryDefault.SetDigitalf_Max;
            Settings.SetDigitalf_clock = Form1.FactoryDefault.SetDigitalf_clock;
            Settings.SetDigitalf_factor = Form1.FactoryDefault.SetDigitalf_factor;

            Settings.GetDigitalf_Min = Form1.FactoryDefault.GetDigitalf_Min;
            Settings.GetDigitalf_Max = Form1.FactoryDefault.GetDigitalf_Max;
            Settings.GetDigitalf_clock = Form1.FactoryDefault.GetDigitalf_clock;
            Settings.GetDigitalf_factor = Form1.FactoryDefault.GetDigitalf_factor;

            Settings.AnalogCommon_intOffset = Form1.FactoryDefault.AnalogCommon_intOffset;
            Settings.AnalogCommon_Domain = Form1.FactoryDefault.AnalogCommon_Domain;
            Settings.AnalogCommon_factor = Form1.FactoryDefault.AnalogCommon_factor;

            Settings.Zeroset0 = Form1.FactoryDefault.Zeroset0;
            Settings.Zeroset1 = Form1.FactoryDefault.Zeroset1;
            Settings.isEIS = Form1.FactoryDefault.isEIS;
            Settings.isMSH = Form1.FactoryDefault.isMSH;
            Settings.isChrono = Form1.FactoryDefault.isChrono;
            Settings.isIV0 = Form1.FactoryDefault.isIV0;
            Settings.isCV = Form1.FactoryDefault.isCV;
            Settings.isPulse = Form1.FactoryDefault.isPulse;

            Settings.GalvanostatI_Select4 = Form1.FactoryDefault.GalvanostatI_Select4;
            Settings.GalvanostatI_Select5 = Form1.FactoryDefault.GalvanostatI_Select5;
            Settings.GalvanostatI_Select6 = Form1.FactoryDefault.GalvanostatI_Select6;
            Settings.GalvanostatI_Select7 = Form1.FactoryDefault.GalvanostatI_Select7;

            Settings.GalvanostatI_Select0 = Form1.FactoryDefault.GalvanostatI_Select0;
            Settings.GalvanostatI_Select1 = Form1.FactoryDefault.GalvanostatI_Select1;
            Settings.GalvanostatI_Select2 = Form1.FactoryDefault.GalvanostatI_Select2;
            Settings.GalvanostatI_Select3 = Form1.FactoryDefault.GalvanostatI_Select3;

            Settings.SetDCV_Select0 = Form1.FactoryDefault.SetDCV_Select0;
            Settings.SetDCV_Select1 = Form1.FactoryDefault.SetDCV_Select1;

            Settings.GetDCV_Select0 = Form1.FactoryDefault.GetDCV_Select0;
            Settings.GetDCV_Select1 = Form1.FactoryDefault.GetDCV_Select1;

            Settings.ACMultFactor_Select0 = Form1.FactoryDefault.ACMultFactor_Select0;
            Settings.ACMultFactor_Select1 = Form1.FactoryDefault.ACMultFactor_Select1;

            Settings.FilterC_V1 = Form1.FactoryDefault.FilterC_V1;
            Settings.FilterC_V2 = Form1.FactoryDefault.FilterC_V2;
            Settings.FilterC_I1 = Form1.FactoryDefault.FilterC_I1;
            Settings.FilterC_I2 = Form1.FactoryDefault.FilterC_I2;

            Settings.SetACVMaxS0 = Form1.FactoryDefault.SetACVMaxS0;
            Settings.SetACVResoloution = Form1.FactoryDefault.SetACVResoloution;

            Settings.GetACVMaxS0 = Form1.FactoryDefault.GetACVMaxS0;
            Settings.GetACVResoloution0 = Form1.FactoryDefault.GetACVResoloution0;

            Settings.VTau_L = Form1.FactoryDefault.VTau_L;
            Settings.VTau_H = Form1.FactoryDefault.VTau_H;
            Settings.ITau_L0 = Form1.FactoryDefault.ITau_L0;
            Settings.ITau_H0 = Form1.FactoryDefault.ITau_H0;
            Settings.ITau_L1 = Form1.FactoryDefault.ITau_L1;
            Settings.ITau_H1 = Form1.FactoryDefault.ITau_H1;
            Settings.ITau_L2 = Form1.FactoryDefault.ITau_L2;
            Settings.ITau_H2 = Form1.FactoryDefault.ITau_H2;
        }

        public static int GetVersionSetting(string FileName)
        {
            int Ver=-1;

            bool isloadDone;

            if (File.Exists(FileName))
            {
                FileStream FileProtocol = new FileStream(FileName, FileMode.Open);
                BinaryReader br = new BinaryReader(FileProtocol);

                try
                {
                    br.ReadByte();
                    Ver = br.ReadInt32();
                    isloadDone = true;
                }
                catch
                {
                    isloadDone = false;
                }

                br.Close();
            }
            else
            {
                isloadDone = false;
            }


            if (!isloadDone)
            {
                Ver = -1;
            }
            else
            {
                if (Ver > 255) Ver = -1; ;
            }

            return Ver;
        }

        public static void loadSetting(ref SettingsData Settings)
        {
            FillSettingDefault(ref Settings);

            string FileName = "../settings.bin";

            bool isloadDone;
            int FileVer = 0;

            if (File.Exists(FileName))
            {
                FileStream FileProtocol = new FileStream(FileName, FileMode.Open);
                BinaryReader br = new BinaryReader(FileProtocol);
                
                try
                {
                    br.ReadByte(); FileVer = br.ReadInt32();

                    br.ReadByte(); Settings.IsIVReceiverUnsigned = br.ReadBoolean();
                    br.ReadByte(); Settings.isDigitalEISReceiverUnsigned = br.ReadBoolean();

                    br.ReadByte(); Settings.SetDCV_Offset = br.ReadInt32();
                    br.ReadByte(); Settings.SetDCV_Domain = br.ReadSingle();
                    br.ReadByte(); Settings.SetDCV_factor = br.ReadSingle();

                    br.ReadByte(); Settings.GetDCV_OffsetMLP0 = br.ReadSingle();
                    br.ReadByte(); Settings.GetDCV_OffsetMLP1 = br.ReadSingle();
                    br.ReadByte(); Settings.GetDCV_OffsetMLP2 = br.ReadSingle();
                    br.ReadByte(); Settings.GetDCV_OffsetMLP3 = br.ReadSingle();
                    br.ReadByte(); Settings.GetDCV_OffsetMLP4 = br.ReadSingle();
                    br.ReadByte(); Settings.GetDCV_offsetMLP5 = br.ReadSingle();
                    br.ReadByte(); Settings.GetDCV_OffsetMLP6 = br.ReadSingle();
                    br.ReadByte(); Settings.GetDCV_Domain = br.ReadSingle();
                    br.ReadByte(); Settings.GetDCV_factor = br.ReadSingle();

                    br.ReadByte(); Settings.SetDCI_Offset = br.ReadInt32();
                    br.ReadByte(); Settings.SetDCI_Domain = br.ReadSingle();
                    br.ReadByte(); Settings.SetDCI_Select0 = br.ReadSingle();
                    br.ReadByte(); Settings.SetDCI_Select1 = br.ReadSingle();
                    br.ReadByte(); Settings.SetDCI_Select2 = br.ReadSingle();
                    br.ReadByte(); Settings.SetDCI_factor = br.ReadSingle();

                    br.ReadByte(); Settings.GetDCI_Offset0d = br.ReadSingle();
                    br.ReadByte(); Settings.GetDCI_Offset1d = br.ReadSingle();
                    br.ReadByte(); Settings.GetDCI_Offset2 = br.ReadSingle();
                    br.ReadByte(); Settings.GetDCI_Offset3d = br.ReadSingle();
                    br.ReadByte(); Settings.GetDCI_Offset4d = br.ReadSingle();
                    br.ReadByte(); Settings.GetDCI_Offset5d = br.ReadSingle();
                    br.ReadByte(); Settings.GetDCI_Offset6d = br.ReadSingle();
                    br.ReadByte(); Settings.GetDCI_Offset7d = br.ReadSingle();
                    br.ReadByte(); Settings.GetDCI_Domain = br.ReadSingle();
                    br.ReadByte(); Settings.GetDCI_Select0 = br.ReadSingle();
                    br.ReadByte(); Settings.GetDCI_Select1 = br.ReadSingle();
                    br.ReadByte(); Settings.GetDCI_select2 = br.ReadSingle();
                    br.ReadByte(); Settings.GetDCI_Select3 = br.ReadSingle();
                    br.ReadByte(); Settings.GetDCI_Select4 = br.ReadSingle();
                    br.ReadByte(); Settings.GetDCI_Select5 = br.ReadSingle();
                    br.ReadByte(); Settings.GetDCI_Select6 = br.ReadSingle();
                    br.ReadByte(); Settings.GetDCI_Select7 = br.ReadSingle();
                    br.ReadByte(); Settings.GetDCI_factor = br.ReadSingle();

                    br.ReadByte(); Settings.SetDigitalACV_Offset = br.ReadInt32();
                    br.ReadByte(); Settings.SetDigitalACV_Domain = br.ReadSingle();
                    br.ReadByte(); Settings.SetDigitalACV_factor = br.ReadSingle();

                    br.ReadByte(); Settings.GetDigitalACV_Offset = br.ReadInt32();
                    br.ReadByte(); Settings.GetDigitalACV_Domain = br.ReadSingle();
                    br.ReadByte(); Settings.GetDigitalACV_factor = br.ReadSingle();

                    br.ReadByte(); Settings.SetDigitalf_Min = br.ReadSingle();
                    br.ReadByte(); Settings.SetDigitalf_Max = br.ReadSingle();
                    br.ReadByte(); Settings.SetDigitalf_clock = br.ReadInt32();
                    br.ReadByte(); Settings.SetDigitalf_factor = br.ReadSingle();

                    br.ReadByte(); Settings.GetDigitalf_Min = br.ReadSingle();
                    br.ReadByte(); Settings.GetDigitalf_Max = br.ReadSingle();
                    br.ReadByte(); Settings.GetDigitalf_clock = br.ReadInt32();
                    br.ReadByte(); Settings.GetDigitalf_factor = br.ReadSingle();

                    br.ReadByte(); Settings.AnalogCommon_intOffset = br.ReadInt32();
                    br.ReadByte(); Settings.AnalogCommon_Domain = br.ReadSingle();
                    br.ReadByte(); Settings.AnalogCommon_factor = br.ReadSingle();

                    br.ReadByte(); Settings.Zeroset0 = br.ReadInt32();
                    br.ReadByte(); Settings.Zeroset1 = br.ReadInt32();
                    br.ReadByte(); Settings.isEIS = br.ReadBoolean();
                    br.ReadByte(); Settings.isMSH = br.ReadBoolean();
                    br.ReadByte(); Settings.isCV = br.ReadBoolean();
                    br.ReadByte(); Settings.isIV0 = br.ReadBoolean();
                    br.ReadByte(); Settings.isChrono = br.ReadBoolean();
                    br.ReadByte(); Settings.isPulse = br.ReadBoolean();

                    br.ReadByte(); Settings.GalvanostatI_Select4 = br.ReadSingle();
                    br.ReadByte(); Settings.GalvanostatI_Select5 = br.ReadSingle();
                    br.ReadByte(); Settings.GalvanostatI_Select6 = br.ReadSingle();
                    br.ReadByte(); Settings.GalvanostatI_Select7 = br.ReadSingle();

                    br.ReadByte(); Settings.GalvanostatI_Select0 = br.ReadSingle();
                    br.ReadByte(); Settings.GalvanostatI_Select1 = br.ReadSingle();
                    br.ReadByte(); Settings.GalvanostatI_Select2 = br.ReadSingle();
                    br.ReadByte(); Settings.GalvanostatI_Select3 = br.ReadSingle();

                    br.ReadByte(); Settings.SetDCV_Select0 = br.ReadSingle();
                    br.ReadByte(); Settings.SetDCV_Select1 = br.ReadSingle();

                    br.ReadByte(); Settings.GetDCV_Select0 = br.ReadSingle();
                    br.ReadByte(); Settings.GetDCV_Select1 = br.ReadSingle();

                    if (FileVer >= 6) br.ReadByte(); Settings.ACMultFactor_Select0 = br.ReadSingle();
                    if (FileVer >= 6) br.ReadByte(); Settings.ACMultFactor_Select1 = br.ReadSingle();

                    if (FileVer >= 7) br.ReadByte(); Settings.FilterC_V1 = br.ReadSingle();
                    if (FileVer >= 7) br.ReadByte(); Settings.FilterC_V2 = br.ReadSingle();
                    if (FileVer >= 7) br.ReadByte(); Settings.FilterC_I1 = br.ReadSingle();
                    if (FileVer >= 7) br.ReadByte(); Settings.FilterC_I2 = br.ReadSingle();

                    br.ReadByte(); Settings.SetACVMaxS0 = br.ReadSingle();
                    br.ReadByte(); Settings.SetACVResoloution = br.ReadInt32();

                    br.ReadByte(); Settings.GetACVMaxS0 = br.ReadSingle();
                    br.ReadByte(); Settings.GetACVResoloution0 = br.ReadInt32();

                    br.ReadByte(); Settings.VTau_L = br.ReadSingle();
                    br.ReadByte(); Settings.VTau_H = br.ReadSingle();
                    br.ReadByte(); Settings.ITau_L0 = br.ReadSingle();
                    br.ReadByte(); Settings.ITau_H0 = br.ReadSingle();
                    br.ReadByte(); Settings.ITau_L1 = br.ReadSingle();
                    br.ReadByte(); Settings.ITau_H1 = br.ReadSingle();
                    br.ReadByte(); Settings.ITau_L2 = br.ReadSingle();
                    br.ReadByte(); Settings.ITau_H2 = br.ReadSingle();

                    isloadDone = true;
                }
                catch
                {
                    isloadDone = false;
                }

                br.Close();
            }
            else
            {
                isloadDone = false;
            }


            if (!isloadDone || SettingsVersion!=FileVer)
            {
                //FillSettingDefault(ref Settings);
                saveSetting(ref Settings, "../settings.bin");
            }
        }

        public static bool microloadSetting()
        {
            bool isdone = false;
            string FileName = "../microsettings.bin";
            FileStream myStream = new FileStream(FileName, FileMode.Create);
            //BinaryReader bw = new BinaryReader(myStream);

            try
            {
                String ans = null;
                Port.DiscardInBuffer();
                Port.DiscardOutBuffer();
                Port.WriteLine("load");
                Thread.Sleep(100);
                ans = Port.ReadLine();
                Thread.Sleep(100);
                //if (ans != "ready") throw(L"Undefined command received from device ...");
                UInt16 n = Convert.ToUInt16(ans);
                if (n < 1)
                {
                    myStream.Close();
                    return isdone;
                }

                if (n <= 1586)
                {
                    myStream.Position = 0;
                    // Serialize the object, and close the TextWriter
                    for (int i = 0; i < n; i++)
                    {
                        byte b = (byte)Port.ReadByte();
                        myStream.WriteByte(b);
                        // Thread::Sleep(10);
                    }
                    Thread.Sleep(100);
                    ans = Port.ReadLine();
                    if (ans != "finish")
                    {
                        myStream.Close();
                        throw (new Exception("MicroLoadSetting error. Undefined command received from device ..."));
                    }
                    else
                    {
                        //XmlSerializer^ serializer=gcnew XmlSerializer(Settings::typeid);
                        myStream.Position = 0;
                        //sett=(Settings)(serializer->Deserialize(myStream));
                        myStream.Close();
                        isdone = true;
                    }
                }
                else
                {
                    myStream.Close();
                    MessageBox.Show("micro save number 1");
                    microsaveSetting("../settings.bin");
                }
            }
            catch (Exception e) { myStream.Close(); MessageBox.Show("Falied!\r" + e.Message); }

            return isdone;
        }

        public static bool microsaveSetting(string FileName)
        {
            bool done = false;
            FileStream myStream = new FileStream(FileName, FileMode.Open);
            //BinaryReader br = new BinaryReader(myStream);

            //XmlSerializer^ serializer=gcnew XmlSerializer(Settings::typeid);
            //IO::Stream^ myStream;
            try
            {
                //myStream = gcnew FileStream(Directory::GetCurrentDirectory()+"\\"+ "settings",FileMode::Create );
                // Serialize the object, and close the TextWriter
                //serializer->Serialize( myStream, sett );

                String ans = null;
                Port.DiscardInBuffer();
                Port.DiscardOutBuffer();
                Port.WriteLine("save " + myStream.Length.ToString());
                Thread.Sleep(500);
                ans = Port.ReadLine();
                if (ans != "ready") throw (new Exception("Undefined command received from device ..."));
                byte[] b = new byte[myStream.Length];
                myStream.Position = 0;
                myStream.Read(b, 0, (int)myStream.Length);
                for (int i = 0; i < myStream.Length; i++)
                {
                    Port.Write(b, i, 1);
                    Thread.Sleep(50);
                }
                Thread.Sleep(500);
                ans = Port.ReadLine(); myStream.Close();
                if (ans != "finish") throw (new Exception("Undefined command received from device ..."));
                done = true;
            }
            catch (Exception e) { myStream.Close(); MessageBox.Show("Falied!\r" + e.Message); }


            FileStream s = new FileStream(FileName, FileMode.Open);
            FileStream ms = new FileStream("../microsettings.bin", FileMode.Create);
            for (int i = 0; i < s.Length; i++) ms.WriteByte((byte)s.ReadByte());
            ms.Close();
            s.Close();

            if (done) Form1.Status.Text = "Device Settings are updated ... ver=" + Settings.Version.ToString();
            return done;
        }

        private void TBTimeStep_TextChanged(object sender, EventArgs e)
        {
            IntDigitTextChange(ref AllSessions[Selected].IVTimestep, TBTimeStep,1,60000);
            //LoadSelectedProperties();
        }

        private void CBEISMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBEISMode.SelectedIndex == 1)
                AllSessions[Selected].EISMode = CBEISMode.SelectedIndex;
            else
            {
                MessageBox.Show("This feature is not available ...");
                CBEISMode.SelectedIndex = AllSessions[Selected].EISMode;
            }

            LoadSelectedProperties();
            //BtnEISAveNum.Focus();
        }

        private void CBEISFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            AllSessions[Selected].EISfilterMode = CBEISFilterMode.SelectedIndex;
            LoadSelectedProperties();
            //BtnEISAveNum.Focus();
        }

        private void CBEISOCMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            AllSessions[Selected].EISOCMode = CBEISOCMode.SelectedIndex;
            //LoadSelectedProperties();
            //TBVOCP.Focus();
            //CBEISOCMode.Focus();
        }

        private void CBEISVoltageRangeMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            AllSessions[Selected].EISVoltageRangeMode = CBEISVoltageRangeMode.SelectedIndex;
            //LoadSelectedProperties();
            //TBDCVoltageConstant.Focus();
            //CBEISVoltageRangeMode.Focus();
        }

        private void CBEISCurrentRangeMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBEISACRegulatorMode.SelectedIndex < 2)
            {
                AllSessions[Selected].EISACRegulatorMode = CBEISACRegulatorMode.SelectedIndex;
            }
            else
            {
                MessageBox.Show("This feature is not available ...");
                CBEISACRegulatorMode.SelectedIndex = AllSessions[Selected].EISACRegulatorMode;
            }
            //LoadSelectedProperties();
            //TBACAmpConstant.Focus();

            //CBEISACRegulatorMode.Focus();
        }

        private void CBIVVoltageRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isCBIVVoltageRangeCompleted)
            {
                isCBIVVoltageRangeCompleted = false;
                AllSessions[Selected].IVVoltageRangeMode = CBIVVoltageRangeMode.SelectedIndex;
                //LoadSelectedProperties();
                isCBIVVoltageRangeCompleted = true;
                //TBIVVoltageFrom.Focus();
                //CBIVVoltageRangeMode.Focus();
            }
        }

        private void CBEISDCCurrentRangeMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if (CBEISDCCurrentRangeMode.SelectedIndex < 2)
            {
                AllSessions[Selected].EISDCCurrentRangeMode = CBEISDCCurrentRangeMode.SelectedIndex;
            }
            else
            {
                MessageBox.Show("You are not allowed to change to this range manually ...");
            }*/
            AllSessions[Selected].EISDCCurrentRangeModea = CBEISDCCurrentRangeMode.SelectedIndex;
            //LoadSelectedProperties();
            //TBDCVoltageConstant.Focus();
            //CBEISDCCurrentRangeMode.Focus();
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isFormEISDScope)
            {
                FormEISDScope.Hide();
                isFormEISDScope = false;
            }
            else
            {
                FormEISDScope.Show(this);
                isFormEISDScope = true;
            }
        }

        private void SampleOnBtn_Click(object sender, EventArgs e)
        {
            if (EIS.Connected)
            {
                if (isProbOn)
                {
                    try
                    {
                        Port.DiscardOutBuffer(); //Clear Buffer
                        Port.DiscardInBuffer(); //Clear Buffer
                        Port.Write("sampleon 0" + WriteReadToChar);
                        Thread.Sleep(100);
                        string ans = Port.ReadTo(ReadToChar);
                        Port.DiscardOutBuffer(); //Clear Buffer
                        Port.DiscardInBuffer(); //Clear Buffer
                        if (ans == "OK")
                        {
                            isIVRangesChanged = true;
                            isProbOn = false;
                            SampleOnBtn.Text = "Probe On";
                            SampleOnBtn.ForeColor = Color.Red;
                            DummyOnBtn.Enabled = true;
                        }
                    }
                    catch { }
                }
                else
                {
                    //Thread.Sleep(700);
                    //CalculateIVOffsets();
                    //Thread.Sleep(700);
                    try
                    {
                        Port.DiscardOutBuffer(); //Clear Buffer
                        Port.DiscardInBuffer(); //Clear Buffer
                        Port.Write("sampleon 1" + WriteReadToChar);
                        Thread.Sleep(100);
                        string ans = Port.ReadTo(ReadToChar);
                        Thread.Sleep(100);
                        Port.DiscardOutBuffer(); //Clear Buffer
                        Port.DiscardInBuffer(); //Clear Buffer
                        if (ans == "OK")
                        {
                            isIVRangesChanged = true;
                            isProbOn = true;
                            SampleOnBtn.Text = "Probe Off";
                            SampleOnBtn.ForeColor = Color.Green;
                            DummyOnBtn.Enabled = false;
                        }
                    }
                    catch { }
                }
            }
            else
                MessageBox.Show("Application is not connected to any device. Go to following path and check connections and ports ...\n\nMeasurement->Connect");
        }

        private bool CalculateIVOffsets()
        {
            bool err = true;
            string ans;
            try
            {
                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer
                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer
                Port.Write("sampleon 0" + ReadToChar);
                Port.Write(WriteReadToChar);
                Thread.Sleep(100);
                ans = Port.ReadTo(ReadToChar);
                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer
                if (ans == "OK")
                {
                    try
                    {
                        Port.DiscardOutBuffer(); //Clear Buffer
                        Port.DiscardInBuffer(); //Clear Buffer
                        Port.Write("vdcmlp 0" + WriteReadToChar);
                        Thread.Sleep(100);
                        ans = Port.ReadTo(ReadToChar);
                        Port.DiscardOutBuffer(); //Clear Buffer
                        Port.DiscardInBuffer(); //Clear Buffer
                        if (ans != "OK") err = true;
                    }
                    catch { err = true; }

                    try
                    {
                        Port.DiscardOutBuffer(); //Clear Buffer
                        Port.DiscardInBuffer(); //Clear Buffer
                        Port.Write("idcmlp 0" + WriteReadToChar);
                        Thread.Sleep(100);
                        ans = Port.ReadTo(ReadToChar);
                        Port.DiscardOutBuffer(); //Clear Buffer
                        Port.DiscardInBuffer(); //Clear Buffer
                        if (ans != "OK") err = true;
                    }
                    catch { err = true; }

                    Thread.Sleep(100);
                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    Port.Write("idcselect 0" + ReadToChar);
                    Port.Write(WriteReadToChar);
                    Thread.Sleep(100);
                    ans = Port.ReadTo(ReadToChar);
                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    if (ans != "OK") err = true;
                    Thread.Sleep(100);

                    try
                    {
                        Port.DiscardOutBuffer(); //Clear Buffer
                        Port.DiscardInBuffer(); //Clear Buffer
                        Port.Write("ivset 2047" + ReadToChar);
                        Port.Write(WriteReadToChar);
                        Thread.Sleep(100);
                        try
                        {
                            byte[] AllBytes1 = new byte[4];
                            byte[] AllBytes2 = new byte[4];
                            AllBytes1[0] = (byte)Port.ReadByte();
                            AllBytes1[1] = (byte)Port.ReadByte();
                            AllBytes1[2] = (byte)Port.ReadByte();
                            AllBytes1[3] = (byte)Port.ReadByte();
                            AllBytes2[0] = (byte)Port.ReadByte();
                            AllBytes2[1] = (byte)Port.ReadByte();
                            AllBytes2[2] = (byte)Port.ReadByte();
                            AllBytes2[3] = (byte)Port.ReadByte();
                            err = false;
                        }
                        catch { }
                    }
                    catch { }

                    Thread.Sleep(200);

                    try
                    {
                        Port.DiscardOutBuffer(); //Clear Buffer
                        Port.DiscardInBuffer(); //Clear Buffer
                        Port.Write("ivset 2047" + ReadToChar);
                        Port.Write(WriteReadToChar);
                        Thread.Sleep(100);

                        try
                        {
                            byte[] AllBytes1 = new byte[4];
                            byte[] AllBytes2 = new byte[4];
                            int word;

                            AllBytes1[0] = (byte)Port.ReadByte();
                            AllBytes1[1] = (byte)Port.ReadByte();
                            AllBytes1[2] = (byte)Port.ReadByte();
                            AllBytes1[3] = (byte)Port.ReadByte();
                            AllBytes2[0] = (byte)Port.ReadByte();
                            AllBytes2[1] = (byte)Port.ReadByte();
                            AllBytes2[2] = (byte)Port.ReadByte();
                            AllBytes2[3] = (byte)Port.ReadByte();

                            loadSetting(ref Settings);

                            int nData = IVnData;
                            word = AllBytes1[0] | (AllBytes1[1] << 8) | (AllBytes1[2] << 16) | (AllBytes1[3] << 24);
                            //Settings.GetDCV_Offset = (float)((double)word / (double)nData);

                            word = AllBytes2[0] | (AllBytes2[1] << 8) | (AllBytes2[2] << 16) | (AllBytes2[3] << 24);
                            //Settings.GetDCI_Offset0d = (float)((double)word / (double)nData);

                            err = false;
                        }
                        catch { }
                    }
                    catch { }



                    Thread.Sleep(1000);

                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    Port.Write("idcselect 1" + ReadToChar);
                    Port.Write(WriteReadToChar);
                    Thread.Sleep(100);
                    ans = Port.ReadTo(ReadToChar);
                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    if (ans == "OK")
                    { }
                    Thread.Sleep(500);

                    try
                    {
                        Port.DiscardOutBuffer(); //Clear Buffer
                        Port.DiscardInBuffer(); //Clear Buffer
                        Port.Write("ivset 2047" + ReadToChar);
                        Port.Write(WriteReadToChar);
                        Thread.Sleep(100);
                        try
                        {
                            byte[] AllBytes1 = new byte[4];
                            byte[] AllBytes2 = new byte[4];
                            AllBytes1[0] = (byte)Port.ReadByte();
                            AllBytes1[1] = (byte)Port.ReadByte();
                            AllBytes1[2] = (byte)Port.ReadByte();
                            AllBytes1[3] = (byte)Port.ReadByte();
                            AllBytes2[0] = (byte)Port.ReadByte();
                            AllBytes2[1] = (byte)Port.ReadByte();
                            AllBytes2[2] = (byte)Port.ReadByte();
                            AllBytes2[3] = (byte)Port.ReadByte();
                            err = false;
                        }
                        catch { }
                    }
                    catch { }

                    Thread.Sleep(200);

                    try
                    {
                        Port.DiscardOutBuffer(); //Clear Buffer
                        Port.DiscardInBuffer(); //Clear Buffer
                        Port.Write("ivset 2047" + ReadToChar);
                        Port.Write(WriteReadToChar);
                        Thread.Sleep(100);

                        try
                        {
                            byte[] AllBytes1 = new byte[4];
                            byte[] AllBytes2 = new byte[4];
                            int word;

                            AllBytes1[0] = (byte)Port.ReadByte();
                            AllBytes1[1] = (byte)Port.ReadByte();
                            AllBytes1[2] = (byte)Port.ReadByte();
                            AllBytes1[3] = (byte)Port.ReadByte();
                            AllBytes2[0] = (byte)Port.ReadByte();
                            AllBytes2[1] = (byte)Port.ReadByte();
                            AllBytes2[2] = (byte)Port.ReadByte();
                            AllBytes2[3] = (byte)Port.ReadByte();

                            int nData = IVnData;

                            word = AllBytes2[0] | (AllBytes2[1] << 8) | (AllBytes2[2] << 16) | (AllBytes2[3] << 24);
                            Settings.GetDCI_Offset1d = (float)((double)word / (double)nData);

                            ///////////////////////////////////////////////////////////////////////////////////////
                            Thread.Sleep(100);
                            Port.DiscardOutBuffer(); //Clear Buffer
                            Port.DiscardInBuffer(); //Clear Buffer
                            Port.DiscardOutBuffer(); //Clear Buffer
                            Port.DiscardInBuffer(); //Clear Buffer
                            Port.Write("idcselect 2" + ReadToChar);
                            Port.Write(WriteReadToChar);
                            Thread.Sleep(100);
                            ans = Port.ReadTo(ReadToChar);
                            Port.DiscardOutBuffer(); //Clear Buffer
                            Port.DiscardInBuffer(); //Clear Buffer
                            if (ans != "OK") err = true;
                            Thread.Sleep(100);

                            try
                            {
                                Port.DiscardOutBuffer(); //Clear Buffer
                                Port.DiscardInBuffer(); //Clear Buffer
                                Port.Write("ivset 2047" + ReadToChar);
                                Port.Write(WriteReadToChar);
                                Thread.Sleep(100);
                                try
                                {
                                    AllBytes1 = new byte[4];
                                    AllBytes2 = new byte[4];
                                    AllBytes1[0] = (byte)Port.ReadByte();
                                    AllBytes1[1] = (byte)Port.ReadByte();
                                    AllBytes1[2] = (byte)Port.ReadByte();
                                    AllBytes1[3] = (byte)Port.ReadByte();
                                    AllBytes2[0] = (byte)Port.ReadByte();
                                    AllBytes2[1] = (byte)Port.ReadByte();
                                    AllBytes2[2] = (byte)Port.ReadByte();
                                    AllBytes2[3] = (byte)Port.ReadByte();
                                    err = false;
                                }
                                catch { }
                            }
                            catch { }

                            Thread.Sleep(200);

                            try
                            {
                                Port.DiscardOutBuffer(); //Clear Buffer
                                Port.DiscardInBuffer(); //Clear Buffer
                                Port.Write("ivset 2047" + ReadToChar);
                                Port.Write(WriteReadToChar);
                                Thread.Sleep(100);

                                try
                                {
                                    AllBytes1 = new byte[4];
                                    AllBytes2 = new byte[4];

                                    AllBytes1[0] = (byte)Port.ReadByte();
                                    AllBytes1[1] = (byte)Port.ReadByte();
                                    AllBytes1[2] = (byte)Port.ReadByte();
                                    AllBytes1[3] = (byte)Port.ReadByte();
                                    AllBytes2[0] = (byte)Port.ReadByte();
                                    AllBytes2[1] = (byte)Port.ReadByte();
                                    AllBytes2[2] = (byte)Port.ReadByte();
                                    AllBytes2[3] = (byte)Port.ReadByte();

                                    loadSetting(ref Settings);

                                    nData = IVnData;
                                    word = AllBytes1[0] | (AllBytes1[1] << 8) | (AllBytes1[2] << 16) | (AllBytes1[3] << 24);
                                    //Settings.GetDCV_Offset = (float)((double)word / (double)nData);

                                    word = AllBytes2[0] | (AllBytes2[1] << 8) | (AllBytes2[2] << 16) | (AllBytes2[3] << 24);
                                    Settings.GetDCI_Offset2 = (float)((double)word / (double)nData);

                                    err = false;
                                }
                                catch { }
                            }
                            catch { }



                            Thread.Sleep(1000);

                            Port.DiscardOutBuffer(); //Clear Buffer
                            Port.DiscardInBuffer(); //Clear Buffer
                            Port.DiscardOutBuffer(); //Clear Buffer
                            Port.DiscardInBuffer(); //Clear Buffer
                            Port.Write("idcselect 3" + ReadToChar);
                            Port.Write(WriteReadToChar);
                            Thread.Sleep(100);
                            ans = Port.ReadTo(ReadToChar);
                            Port.DiscardOutBuffer(); //Clear Buffer
                            Port.DiscardInBuffer(); //Clear Buffer
                            if (ans != "OK") err = true;
                            Thread.Sleep(100);

                            try
                            {
                                Port.DiscardOutBuffer(); //Clear Buffer
                                Port.DiscardInBuffer(); //Clear Buffer
                                Port.Write("ivset 2047" + ReadToChar);
                                Port.Write(WriteReadToChar);
                                Thread.Sleep(100);
                                try
                                {
                                    AllBytes1 = new byte[4];
                                    AllBytes2 = new byte[4];
                                    AllBytes1[0] = (byte)Port.ReadByte();
                                    AllBytes1[1] = (byte)Port.ReadByte();
                                    AllBytes1[2] = (byte)Port.ReadByte();
                                    AllBytes1[3] = (byte)Port.ReadByte();
                                    AllBytes2[0] = (byte)Port.ReadByte();
                                    AllBytes2[1] = (byte)Port.ReadByte();
                                    AllBytes2[2] = (byte)Port.ReadByte();
                                    AllBytes2[3] = (byte)Port.ReadByte();
                                    err = false;
                                }
                                catch { }
                            }
                            catch { }

                            Thread.Sleep(200);

                            try
                            {
                                Port.DiscardOutBuffer(); //Clear Buffer
                                Port.DiscardInBuffer(); //Clear Buffer
                                Port.Write("ivset 2047" + ReadToChar);
                                Port.Write(WriteReadToChar);
                                Thread.Sleep(100);

                                try
                                {
                                    AllBytes1 = new byte[4];
                                    AllBytes2 = new byte[4];

                                    AllBytes1[0] = (byte)Port.ReadByte();
                                    AllBytes1[1] = (byte)Port.ReadByte();
                                    AllBytes1[2] = (byte)Port.ReadByte();
                                    AllBytes1[3] = (byte)Port.ReadByte();
                                    AllBytes2[0] = (byte)Port.ReadByte();
                                    AllBytes2[1] = (byte)Port.ReadByte();
                                    AllBytes2[2] = (byte)Port.ReadByte();
                                    AllBytes2[3] = (byte)Port.ReadByte();

                                    loadSetting(ref Settings);

                                    nData = IVnData;
                                    word = AllBytes1[0] | (AllBytes1[1] << 8) | (AllBytes1[2] << 16) | (AllBytes1[3] << 24);
                                    //Settings.GetDCV_Offset = (float)((double)word / (double)nData);

                                    word = AllBytes2[0] | (AllBytes2[1] << 8) | (AllBytes2[2] << 16) | (AllBytes2[3] << 24);
                                    Settings.GetDCI_Offset3d = (float)((double)word / (double)nData);

                                    err = false;
                                }
                                catch { }
                            }
                            catch { }


                            ///////////////////////////////////////////////////////////////////////////////////////
                            //Settings.GetDCI_Offset2d = Settings.GetDCI_Offset1d;

                            saveSetting(ref Settings, "../settings.bin");

                            err = false;
                        }
                        catch { }
                    }
                    catch { }


                }
            }
            catch { }
            return err;
        }

        private void GetVOffsetFromSettings(int vmlp, ref double Voffset)
        {
            Voffset = Settings.GetDCV_OffsetMLP0;
            if (vmlp == 1)
                Voffset = Settings.GetDCV_OffsetMLP1;
            else if (vmlp == 2)
                Voffset = Settings.GetDCV_OffsetMLP2;
            else if (vmlp == 3)
                Voffset = Settings.GetDCV_OffsetMLP3;
            else if (vmlp == 4)
                Voffset = Settings.GetDCV_OffsetMLP4;
            else if (vmlp == 5)
                Voffset = Settings.GetDCV_offsetMLP5;
            else if (vmlp == 6)
                Voffset = Settings.GetDCV_OffsetMLP6;
        }

        private bool CalculateSpecificIVOffsets(int ISelect, int Imlt, int Vmlt, ref double Ioffset, ref double Voffset)
        {
            bool err = true;
            string ans;
            try
            {
                if (BoardType > 1)
                {
                    try
                    {
                        Port.DiscardOutBuffer(); //Clear Buffer
                        Port.DiscardInBuffer(); //Clear Buffer
                        if(ISelect==0)
                        Port.Write("dummyon 1" + WriteReadToChar);
                        else
                        Port.Write("dummyon 0" + WriteReadToChar);
                        Thread.Sleep(100);
                        ans = Port.ReadTo(ReadToChar);
                        Port.DiscardOutBuffer(); //Clear Buffer
                        Port.DiscardInBuffer(); //Clear Buffer
                    }
                    catch { return true; }
                }
                else
                {
                    try
                    {
                        Port.DiscardOutBuffer(); //Clear Buffer
                        Port.DiscardInBuffer(); //Clear Buffer
                        Port.Write("dummyon 0" + WriteReadToChar);
                        Thread.Sleep(100);
                        ans = Port.ReadTo(ReadToChar);
                        Port.DiscardOutBuffer(); //Clear Buffer
                        Port.DiscardInBuffer(); //Clear Buffer
                    }
                    catch { return true; }
                }

                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer
                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer
                Port.Write("sampleon 0" + ReadToChar);
                //Port.Write(WriteReadToChar);
                Thread.Sleep(100);
                ans = Port.ReadTo(ReadToChar);
                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer
                if (ans == "OK")
                {
                    try
                    {
                        Port.DiscardOutBuffer(); //Clear Buffer
                        Port.DiscardInBuffer(); //Clear Buffer
                        Port.Write("vdcmlp " + Vmlt.ToString() + WriteReadToChar);
                        Thread.Sleep(100);
                        ans = Port.ReadTo(ReadToChar);
                        Port.DiscardOutBuffer(); //Clear Buffer
                        Port.DiscardInBuffer(); //Clear Buffer
                        if (ans != "OK") return true; 
                    }
                    catch { return true; }

                    try
                    {
                        Port.DiscardOutBuffer(); //Clear Buffer
                        Port.DiscardInBuffer(); //Clear Buffer
                        Port.Write("idcmlp " + Imlt.ToString() + ReadToChar);
                        Thread.Sleep(100);
                        ans = Port.ReadTo(ReadToChar);
                        Port.DiscardOutBuffer(); //Clear Buffer
                        Port.DiscardInBuffer(); //Clear Buffer
                        if (ans != "OK") return true; 
                    }
                    catch { return true; }

                    Thread.Sleep(100);
                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    Port.Write("idcselect " + ISelect.ToString() + ReadToChar);
                    Thread.Sleep(100);
                    ans = Port.ReadTo(ReadToChar);
                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    if (ans != "OK") return true;
                    Thread.Sleep(200);
                    if (ISelect > 4) Thread.Sleep(1000);


                    try
                    {
                        Port.DiscardOutBuffer(); //Clear Buffer
                        Port.DiscardInBuffer(); //Clear Buffer
                        Port.Write("ivset 2047" + ReadToChar);

                        Thread.Sleep(100);
                        try
                        {
                            byte[] AllBytes1 = new byte[4];
                            byte[] AllBytes2 = new byte[4];
                            AllBytes1[0] = (byte)Port.ReadByte();
                            AllBytes1[1] = (byte)Port.ReadByte();
                            AllBytes1[2] = (byte)Port.ReadByte();
                            AllBytes1[3] = (byte)Port.ReadByte();
                            AllBytes2[0] = (byte)Port.ReadByte();
                            AllBytes2[1] = (byte)Port.ReadByte();
                            AllBytes2[2] = (byte)Port.ReadByte();
                            AllBytes2[3] = (byte)Port.ReadByte();
                            err = false;
                        }
                        catch { return true; }
                    }
                    catch { return true; }

                    Thread.Sleep(1000);

                    try
                    {
                        Port.DiscardOutBuffer(); //Clear Buffer
                        Port.DiscardInBuffer(); //Clear Buffer
                        Port.Write("ivset 2047" + ReadToChar);
                        //Port.Write(WriteReadToChar);
                        Thread.Sleep(100);

                        try
                        {
                            byte[] AllBytes1 = new byte[4];
                            byte[] AllBytes2 = new byte[4];
                            int word;

                            AllBytes1[0] = (byte)Port.ReadByte();
                            AllBytes1[1] = (byte)Port.ReadByte();
                            AllBytes1[2] = (byte)Port.ReadByte();
                            AllBytes1[3] = (byte)Port.ReadByte();
                            AllBytes2[0] = (byte)Port.ReadByte();
                            AllBytes2[1] = (byte)Port.ReadByte();
                            AllBytes2[2] = (byte)Port.ReadByte();
                            AllBytes2[3] = (byte)Port.ReadByte();

                            int nData = IVnData;
                            word = AllBytes1[0] | (AllBytes1[1] << 8) | (AllBytes1[2] << 16) | (AllBytes1[3] << 24);
                            Voffset = (double)word / (double)nData;

                            word = AllBytes2[0] | (AllBytes2[1] << 8) | (AllBytes2[2] << 16) | (AllBytes2[3] << 24);
                            Ioffset = (double)word / (double)nData;

                            err = false;
                        }
                        catch { return true; }
                    }
                    catch { return true; }

                    if (isDummyOn)
                    {
                        try
                        {
                            Port.DiscardOutBuffer(); //Clear Buffer
                            Port.DiscardInBuffer(); //Clear Buffer
                            Port.Write("dummyon 1" + WriteReadToChar);
                            Thread.Sleep(100);
                            ans = Port.ReadTo(ReadToChar);
                            Thread.Sleep(100);
                            Port.DiscardOutBuffer(); //Clear Buffer
                            Port.DiscardInBuffer(); //Clear Buffer
                        }
                        catch { return true; }
                    }
                    else
                    {
                        try
                        {
                            Port.DiscardOutBuffer(); //Clear Buffer
                            Port.DiscardInBuffer(); //Clear Buffer
                            Port.Write("dummyon 0" + WriteReadToChar);
                            Thread.Sleep(100);
                            ans = Port.ReadTo(ReadToChar);
                            Thread.Sleep(100);
                            Port.DiscardOutBuffer(); //Clear Buffer
                            Port.DiscardInBuffer(); //Clear Buffer
                        }
                        catch { return true; }
                    }

                    if (isProbOn)
                    {
                        try
                        {
                            Port.DiscardOutBuffer(); //Clear Buffer
                            Port.DiscardInBuffer(); //Clear Buffer
                            Port.Write("sampleon 1" + WriteReadToChar);
                            Thread.Sleep(100);
                            ans = Port.ReadTo(ReadToChar);
                            Thread.Sleep(100);
                            Port.DiscardOutBuffer(); //Clear Buffer
                            Port.DiscardInBuffer(); //Clear Buffer
                        }
                        catch { return true; }
                    }

                    Thread.Sleep(500);
                }
                else
                {
                    return true; 
                }
            }
            catch { }
            return err;
        }

        private bool CalculateGalvanostatSetSelectZeroset()
        {
            loadSetting(ref Settings);
            bool err = true;
            string ans;

            try
            {
                Port.DiscardOutBuffer();
                Port.DiscardInBuffer();
                Port.Write("PGmode 3" + WriteReadToChar);//?in chand bayad bashe?
                Thread.Sleep(100);
                ans = Port.ReadTo(ReadToChar);
                if (ans != "OK") throw new Exception("The command OK is not received.\r error number:mm10001 Command:PGmode");

                int MyVFilter = 4; //For IV and chrono and pulse
                
                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer
                Port.Write("vfilter " + MyVFilter.ToString() + WriteReadToChar);
                Thread.Sleep(40);
                ans = Port.ReadTo(ReadToChar);
                if (ans != "OK") throw new Exception("The command OK is not received.\r error number:mm200000 Command:vfilter");
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " VFilter: " + MyVFilter.ToString());
                SetLabel(ref Label_VFilter, MyVFilter);
                
                
               // if (BoardType > 1)
                {
                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    Port.Write("dummyon 1" + WriteReadToChar);
                    Thread.Sleep(100);
                    ans = Port.ReadTo(ReadToChar);
                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    if (ans != "OK") throw (new Exception("error:123211 Command:dummyon"));
                }
             /*   else
                {
                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    Port.Write("dummyon 0" + WriteReadToChar);
                    Thread.Sleep(100);
                    ans = Port.ReadTo(ReadToChar);
                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    if (ans != "OK") throw (new Exception("error:123212 Command:dummyon"));
                }*/

                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer
                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer
                Port.Write("sampleon 1" + ReadToChar);//?chera sefre   man eyne offsetremoval voltage copy kardam       voltage khob madar ghat kar mikone na vasl   
                //mage mishe ham sample on bashe ham dummy
                //alan hanooz tekoon nemikhore
                //Port.Write(WriteReadToChar);
                Thread.Sleep(100);
                ans = Port.ReadTo(ReadToChar);
                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer
                if (ans != "OK") throw (new Exception("error:no OK Command:sampleon"));
                
                for (int iselect = 0; iselect < 8; iselect++)
                {
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + iselect.ToString());

                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    Port.Write("idcselect " + iselect.ToString() + WriteReadToChar);
                    Thread.Sleep(100);
                    ans = Port.ReadTo(ReadToChar);
                    if (ans != "OK") throw new Exception("The command OK is not received.\r error number:200001 Command:idcselect");
                    //DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " Idcselect=" + AllSessions[EIS.RunningSession].IVCurrentRangeMode.ToString());

                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    Port.Write("setselect 1" + WriteReadToChar);
                    Thread.Sleep(100);
                    ans = Port.ReadTo(ReadToChar);
                    if (ans != "OK") throw new Exception("The command OK is not received.\r error number:200002 Command:setselect");
                    //DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " Setselect=" + AllSessions[EIS.RunningSession].IVvoltageRangeMode.ToString());

                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    Port.Write("acset 0" + WriteReadToChar);
                    Thread.Sleep(100);
                    ans = Port.ReadTo(ReadToChar);
                    if (ans != "OK") throw new Exception("The command OK is not received.\r error number:200003 Command:acset");
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " acset: 0");
                    SetLabel(ref iLabel_vac, 0);
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " Vac: 0.0");
                    SetLabel(ref Label_vac, 0, "V");



                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    Port.Write("vdcmlp 0" + WriteReadToChar);
                    Thread.Sleep(100);
                    ans = Port.ReadTo(ReadToChar);
                    if (ans != "OK") throw new Exception("The command OK is not received.\r error number:200005 Command:vdcmlp");
                    //DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " vdcmlp=" + AllSessions[EIS.RunningSession].IVVmlp.ToString());

                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    Port.Write("idcmlp 0" + WriteReadToChar);
                    Thread.Sleep(100);
                    ans = Port.ReadTo(ReadToChar);
                    if (ans != "OK") throw new Exception("The command OK is not received.\r error number:200006 Command:idcmlp");
                    //DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " idcmlp=" + AllSessions[EIS.RunningSession].IVImlp.ToString());



                    
                    
                    double Z0 = 2047;
                    
                    double OldI = 0;

                    for (int zeroset = 0; zeroset < 4095; zeroset+=10)
                    {
                        Port.DiscardOutBuffer(); //Clear Buffer
                        Port.DiscardInBuffer(); //Clear Buffer
                        Port.Write("zeroset " + zeroset.ToString() + WriteReadToChar);
                        Thread.Sleep(10);
                        ans = Port.ReadTo(ReadToChar);
                        isDataReceived = false;
                        Thread.Sleep(1);
                        isDigitalEISStepCompleted = false;
                        AllowToTick = true;
                        if (ans != "OK") throw new Exception("The command OK is not received.\r error number:200004 Command:zeroset");
                        //DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " zeroset=" + zeroset.ToString());


                        Port.DiscardOutBuffer(); //Clear Buffer
                        Port.DiscardInBuffer(); //Clear Buffer
                        Port.Write("ivset 2047" + ReadToChar);
                        Port.Write(WriteReadToChar);
                        Thread.Sleep(10);

                        byte[] AllBytes1 = new byte[4];
                        byte[] AllBytes2 = new byte[4];

                        AllBytes1[0] = (byte)Port.ReadByte();
                        AllBytes1[1] = (byte)Port.ReadByte();
                        AllBytes1[2] = (byte)Port.ReadByte();
                        AllBytes1[3] = (byte)Port.ReadByte();
                        AllBytes2[0] = (byte)Port.ReadByte();
                        AllBytes2[1] = (byte)Port.ReadByte();
                        AllBytes2[2] = (byte)Port.ReadByte();
                        AllBytes2[3] = (byte)Port.ReadByte();
                        
                    

                        int word;
                        
                        word = AllBytes2[0] | (AllBytes2[1] << 8) | (AllBytes2[2] << 16) | (AllBytes2[3] << 24);
                        double Imean = (double)word / (double)IVnData;
                        //DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " zeroset=" + zeroset.ToString() +" I= " + Imean.ToString());


                        if ((OldI * Imean <= 0) && (zeroset > 0))//in hamoon aval break mikone.
                        {
                            Z0 = zeroset;
                            DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " zeroset=" + zeroset.ToString() + " I= " + Imean.ToString());

                            break;
                        }
                        OldI = Imean;
                    }
                    

                    if (iselect == 0)
                        Settings.GalvanostatI_Select0 = (int)Z0;
                    else if (iselect == 1)
                        Settings.GalvanostatI_Select1 = (int)Z0;
                    else if (iselect == 2)
                        Settings.GalvanostatI_Select2 = (int)Z0;
                    else if (iselect == 3)
                        Settings.GalvanostatI_Select3 = (int)Z0;
                    else if (iselect == 4)
                        Settings.GalvanostatI_Select4 = (int)Z0;
                    else if (iselect == 5)
                        Settings.GalvanostatI_Select5 = (int)Z0;
                    else if (iselect == 6)
                        Settings.GalvanostatI_Select6 = (int)Z0;
                    else if (iselect == 7)
                        Settings.GalvanostatI_Select7 = (int)Z0;

                }

                if (isDummyOn)
                {
                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    Port.Write("dummyon 1" + WriteReadToChar);
                    Thread.Sleep(100);
                    ans = Port.ReadTo(ReadToChar);
                    Thread.Sleep(100);
                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    if (ans != "OK") throw (new Exception("error:123213 Command:dummyon"));
                }
                else
                {
                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    Port.Write("dummyon 0" + WriteReadToChar);
                    Thread.Sleep(100);
                    ans = Port.ReadTo(ReadToChar);
                    Thread.Sleep(100);
                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    if (ans != "OK") throw (new Exception("error:123214 Command:dummyon"));
                }

                if (isProbOn)
                {
                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    Port.Write("sampleon 1" + WriteReadToChar);
                    Thread.Sleep(100);
                    ans = Port.ReadTo(ReadToChar);
                    Thread.Sleep(100);
                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    if (ans != "OK") throw (new Exception("error:no OK 2 Command:sampleon"));
                }


                Thread.Sleep(200);

                saveSetting(ref Settings, "../settings.bin");
                SetStatus("Done ...");

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return true;
            }
        }

        private bool CalculateSetSelectZeroset()
        {
            loadSetting(ref Settings);
            bool err = true;
            string ans;
            int iVoltChecker = 2047;
            int VmlpChecker = 2;
            double VoltRead=2047;
            double Ioffset = 0;
            double Voffset = 0;

            try
            {
                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer
                Port.Write("acset 0" + WriteReadToChar);
                Thread.Sleep(100);
                ans = Port.ReadTo(ReadToChar);
                if (ans != "OK") throw (new Exception("error:f1-999 Command:acset"));
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " acset: 0");
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " Vac: 0.0");
                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer
                Port.Write("zeroset " + Settings.Zeroset0.ToString() + WriteReadToChar);
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " zeroset: " + Settings.Zeroset0.ToString());
                Thread.Sleep(100);
                ans = Port.ReadTo(ReadToChar);
                Thread.Sleep(100);
                if (ans != "OK") throw (new Exception("error:f1-1000 Command:zeroset"));
                Thread.Sleep(1000);
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " OK");
                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer
                Port.Write("setselect 0"+ WriteReadToChar);
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " setselect: 0");
                Thread.Sleep(100);
                ans = Port.ReadTo(ReadToChar);
                Thread.Sleep(100);
                if (ans != "OK") throw (new Exception("error:f1-1001 Command:setselect"));
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " OK");
                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer
                Port.Write("idcmlp 0" + WriteReadToChar);
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " idcmlp 0");
                Thread.Sleep(100);
                ans = Port.ReadTo(ReadToChar);
                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer
                if (ans != "OK") throw (new Exception("error:f1-1003 Command:idcmlp"));
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " OK");
                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer
                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer
                Port.Write("idcselect 0" + ReadToChar);
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " idcselect 0");
                Port.Write(WriteReadToChar);
                Thread.Sleep(100);
                ans = Port.ReadTo(ReadToChar);
                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer
                if (ans != "OK") throw (new Exception("error:f1-1004 Command:idcselect"));
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " OK");
                for (int ivmlp = 2; ivmlp >= 0; ivmlp--)
                {
                    CalculateSpecificIVOffsets(0, 0, VmlpChecker, ref Ioffset, ref Voffset);
                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    Port.Write("sampleon 1" + ReadToChar);
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " sampleon 0");
                    Port.Write(WriteReadToChar);
                    Thread.Sleep(100);
                    ans = Port.ReadTo(ReadToChar);
                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    if (ans != "OK") throw (new Exception("error:f1-1001 Command:sampleon"));
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " OK");
                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    Port.Write("dummyon 1" + ReadToChar);
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " dummyon 1");
                    Port.Write(WriteReadToChar);
                    Thread.Sleep(100);
                    ans = Port.ReadTo(ReadToChar);
                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    if (ans != "OK") throw (new Exception("error:f1-1001-2 Command:dummyon"));
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " OK");
                    VmlpChecker = ivmlp;
                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    Port.Write("vdcmlp " + VmlpChecker.ToString() + WriteReadToChar);
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " vdcmlp:" + VmlpChecker.ToString());
                    Thread.Sleep(100);
                    ans = Port.ReadTo(ReadToChar);
                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    if (ans != "OK") throw (new Exception("error:f1-1002 Command:vdcmlp"));
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " OK");
                    Thread.Sleep(100);
                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    Port.Write("ivset " + iVoltChecker.ToString() + ReadToChar);
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " ivset:" + iVoltChecker.ToString());
                    Port.Write(WriteReadToChar);
                    Thread.Sleep(500);
                    try
                    {
                        byte[] AllBytes1 = new byte[4];
                        byte[] AllBytes2 = new byte[4];
                        AllBytes1[0] = (byte)Port.ReadByte();
                        AllBytes1[1] = (byte)Port.ReadByte();
                        AllBytes1[2] = (byte)Port.ReadByte();
                        AllBytes1[3] = (byte)Port.ReadByte();
                        AllBytes2[0] = (byte)Port.ReadByte();
                        AllBytes2[1] = (byte)Port.ReadByte();
                        AllBytes2[2] = (byte)Port.ReadByte();
                        AllBytes2[3] = (byte)Port.ReadByte();
                        err = false;
                    }
                    catch { }

                    DebugListBox.Items.Add("stp: Wait 3(s)");
                    FWaitTime = 3;
                    FormWait fw = new FormWait();
                    fw.ShowDialog();

                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    Port.Write("ivset " + iVoltChecker.ToString() + ReadToChar);
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " ivset:" + iVoltChecker.ToString());
                    Port.Write(WriteReadToChar);
                    Thread.Sleep(500);

                    try
                    {
                        byte[] AllBytes1 = new byte[4];
                        byte[] AllBytes2 = new byte[4];
                        int word;

                        AllBytes1[0] = (byte)Port.ReadByte();
                        AllBytes1[1] = (byte)Port.ReadByte();
                        AllBytes1[2] = (byte)Port.ReadByte();
                        AllBytes1[3] = (byte)Port.ReadByte();
                        AllBytes2[0] = (byte)Port.ReadByte();
                        AllBytes2[1] = (byte)Port.ReadByte();
                        AllBytes2[2] = (byte)Port.ReadByte();
                        AllBytes2[3] = (byte)Port.ReadByte();

                        int nData = IVnData;
                        word = AllBytes1[0] | (AllBytes1[1] << 8) | (AllBytes1[2] << 16) | (AllBytes1[3] << 24);
                        double Vmean = (double)word / (double)nData;
                        if (Vmean < 1000 && Vmean > -1000 || VmlpChecker==0)
                        {
                            VoltRead = GetDCVConvertWithNewOffset(Vmean, VmlpChecker, Voffset,0);
                            DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " iVmean=" + Vmean.ToString() + " V=" + VoltRead.ToString());
                            DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString()+"offset=" + Voffset.ToString());

                            break;
                        }
                                           }
                    catch { }

                }


                int ideltaV = SetDCVConvert(VoltRead, 0,0,0) - Settings.SetDCV_Offset;
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " ideltaV=" + ideltaV.ToString());
                 
                double OldVoltRead = 0;
                int approximatelyZero = Settings.Zeroset0;
                if (Math.Abs(ideltaV ) < 100)
                    approximatelyZero = approximatelyZero - 5 * ideltaV ;
                int checkmin = 0;// approximatelyZero - 500;
                int checkmax = 4000;// approximatelyZero + 500;
                if (checkmin < 0) checkmin = 0;
                if (checkmax > 4095) checkmax = 4095;
                for (int zset = checkmin; zset <= checkmax; zset+=1)
                {
                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    Port.Write("zeroset " + zset.ToString() + WriteReadToChar);
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " zeroset: " + zset.ToString());
                    Thread.Sleep(10);
                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    Port.Write("ivset " + iVoltChecker.ToString() + ReadToChar);
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " ivset:" + iVoltChecker.ToString());
                    Port.Write(WriteReadToChar);
                    Thread.Sleep(10);

                    try
                    {
                        byte[] AllBytes1 = new byte[4];
                        byte[] AllBytes2 = new byte[4];
                        int word;

                        AllBytes1[0] = (byte)Port.ReadByte();
                        AllBytes1[1] = (byte)Port.ReadByte();
                        AllBytes1[2] = (byte)Port.ReadByte();
                        AllBytes1[3] = (byte)Port.ReadByte();
                        AllBytes2[0] = (byte)Port.ReadByte();
                        AllBytes2[1] = (byte)Port.ReadByte();
                        AllBytes2[2] = (byte)Port.ReadByte();
                        AllBytes2[3] = (byte)Port.ReadByte();

                        int nData = IVnData;
                        word = AllBytes1[0] | (AllBytes1[1] << 8) | (AllBytes1[2] << 16) | (AllBytes1[3] << 24);
                        double Vmean = (double)word / (double)nData;
                        VoltRead = GetDCVConvertWithNewOffset(Vmean, VmlpChecker, Voffset ,  0);
                        if (VoltRead * OldVoltRead < 0 && zset > checkmin)
                        {
                            Settings.Zeroset0 = zset;
                            break;
                        }
                        OldVoltRead = VoltRead;
                    }
                    catch { }

                }

                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " Zeroset0=" + Settings.Zeroset0.ToString());

                iVoltChecker = 2047;
                VmlpChecker = 2;
                VoltRead = 2047;


                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer
                Port.Write("zeroset " + Settings.Zeroset1.ToString() + WriteReadToChar);
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " zeroset: " + Settings.Zeroset1.ToString());
                Thread.Sleep(100);
                ans = Port.ReadTo(ReadToChar);
                Thread.Sleep(100);
                if (ans != "OK") throw (new Exception("error:f1-1002 Command:zeroset"));
                Thread.Sleep(1000);
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " OK");
                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer
                Port.Write("setselect 1" + WriteReadToChar);
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " setselect: 1");
                Thread.Sleep(100);
                ans = Port.ReadTo(ReadToChar);
                Thread.Sleep(100);
                if (ans != "OK") throw (new Exception("error:f1-1003 Command:setselect"));
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " OK");
                for (int ivmlp = 2; ivmlp >= 0; ivmlp--)
                {
                    CalculateSpecificIVOffsets(0, 0, VmlpChecker, ref Ioffset, ref Voffset);
                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    Port.Write("sampleon 1" + ReadToChar);
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " sampleon 0");
                    Port.Write(WriteReadToChar);
                    Thread.Sleep(100);
                    ans = Port.ReadTo(ReadToChar);
                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    if (ans != "OK") throw (new Exception("error:f1-1001 Command:sampleon"));
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " OK");
                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    Port.Write("dummyon 1" + ReadToChar);
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " dummyon 1");
                    Port.Write(WriteReadToChar);
                    Thread.Sleep(100);
                    ans = Port.ReadTo(ReadToChar);
                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    if (ans != "OK") throw (new Exception("error:f1-1001-2 Command:dummyon"));
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " OK");
                    VmlpChecker = ivmlp;
                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    Port.Write("vdcmlp " + VmlpChecker.ToString() + WriteReadToChar);
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " vdcmlp:" + VmlpChecker.ToString());
                    Thread.Sleep(100);
                    ans = Port.ReadTo(ReadToChar);
                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    if (ans != "OK") throw (new Exception("error:f1-1002 Command:vdcmlp"));
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " OK");
                    Thread.Sleep(100);
                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    Port.Write("ivset " + iVoltChecker.ToString() + ReadToChar);
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " ivset:" + iVoltChecker.ToString());
                    Port.Write(WriteReadToChar);
                    Thread.Sleep(500);
                    try
                    {
                        byte[] AllBytes1 = new byte[4];
                        byte[] AllBytes2 = new byte[4];
                        AllBytes1[0] = (byte)Port.ReadByte();
                        AllBytes1[1] = (byte)Port.ReadByte();
                        AllBytes1[2] = (byte)Port.ReadByte();
                        AllBytes1[3] = (byte)Port.ReadByte();
                        AllBytes2[0] = (byte)Port.ReadByte();
                        AllBytes2[1] = (byte)Port.ReadByte();
                        AllBytes2[2] = (byte)Port.ReadByte();
                        AllBytes2[3] = (byte)Port.ReadByte();
                        err = false;
                    }
                    catch { }

                    DebugListBox.Items.Add("stp: Wait 3(s)");
                    FWaitTime = 3;
                    FormWait fw = new FormWait();
                    fw.ShowDialog();

                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    Port.Write("ivset " + iVoltChecker.ToString() + ReadToChar);
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " ivset:" + iVoltChecker.ToString());
                    Port.Write(WriteReadToChar);
                    Thread.Sleep(500);

                    try
                    {
                        byte[] AllBytes1 = new byte[4];
                        byte[] AllBytes2 = new byte[4];
                        int word;

                        AllBytes1[0] = (byte)Port.ReadByte();
                        AllBytes1[1] = (byte)Port.ReadByte();
                        AllBytes1[2] = (byte)Port.ReadByte();
                        AllBytes1[3] = (byte)Port.ReadByte();
                        AllBytes2[0] = (byte)Port.ReadByte();
                        AllBytes2[1] = (byte)Port.ReadByte();
                        AllBytes2[2] = (byte)Port.ReadByte();
                        AllBytes2[3] = (byte)Port.ReadByte();

                        int nData = IVnData;
                        word = AllBytes1[0] | (AllBytes1[1] << 8) | (AllBytes1[2] << 16) | (AllBytes1[3] << 24);
                        double Vmean = (double)word / (double)nData;
                        if (Vmean < 1000 && Vmean > -1000 || VmlpChecker == 0)
                        {
                            VoltRead = GetDCVConvertWithNewOffset(Vmean, VmlpChecker, Voffset,1);
                            DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " iVmean=" + Vmean.ToString() + " V=" + VoltRead.ToString());
                            DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + "offset=" + Voffset.ToString());

                            break;
                        }
                                            }
                    catch { }

                }

                
                int ideltaV1 = SetDCVConvert(VoltRead, 1,0,0) - Settings.SetDCV_Offset;
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " ideltaV1=" + ideltaV1.ToString());
                OldVoltRead = 0;
                approximatelyZero = Settings.Zeroset1;
                if (Math.Abs(ideltaV1)<100)
                    approximatelyZero = approximatelyZero - 5 * ideltaV1;
                checkmin = 0;// approximatelyZero - 500;
                checkmax = 4000;//approximatelyZero + 500;
                if (checkmin < 0) checkmin = 0;
                if (checkmax > 4095) checkmax = 4095;
                for (int zset = checkmin; zset <= checkmax; zset++)
                {
                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    Port.Write("zeroset " + zset.ToString() + WriteReadToChar);
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " zeroset: " + zset.ToString());
                    Thread.Sleep(10);
                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    Port.Write("ivset " + iVoltChecker.ToString() + ReadToChar);
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " ivset:" + iVoltChecker.ToString());
                    Port.Write(WriteReadToChar);
                    Thread.Sleep(10);

                    try
                    {
                        byte[] AllBytes1 = new byte[4];
                        byte[] AllBytes2 = new byte[4];
                        int word;

                        AllBytes1[0] = (byte)Port.ReadByte();
                        AllBytes1[1] = (byte)Port.ReadByte();
                        AllBytes1[2] = (byte)Port.ReadByte();
                        AllBytes1[3] = (byte)Port.ReadByte();
                        AllBytes2[0] = (byte)Port.ReadByte();
                        AllBytes2[1] = (byte)Port.ReadByte();
                        AllBytes2[2] = (byte)Port.ReadByte();
                        AllBytes2[3] = (byte)Port.ReadByte();

                        int nData = IVnData;
                        word = AllBytes1[0] | (AllBytes1[1] << 8) | (AllBytes1[2] << 16) | (AllBytes1[3] << 24);
                        double Vmean = (double)word / (double)nData;
                        VoltRead = GetDCVConvertWithNewOffset(Vmean, VmlpChecker, Voffset , 1);
                        if (VoltRead * OldVoltRead < 0 && zset > checkmin)
                        {
                            Settings.Zeroset1 = zset;
                            break;
                        }
                        OldVoltRead = VoltRead;
                    }
                    catch { }

                }

                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " Zeroset1=" + Settings.Zeroset1.ToString());

                saveSetting(ref Settings, "../settings.bin");
                SetStatus("Done ...");

                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer
                Port.Write("vdcmlp 0" + WriteReadToChar);
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " vdcmlp 0");
                Thread.Sleep(100);
                ans = Port.ReadTo(ReadToChar);
                Port.DiscardOutBuffer(); //Clear Buffer
                Port.DiscardInBuffer(); //Clear Buffer
                if (ans != "OK") throw (new Exception("error:f1-1011 Command:vdcmlp"));
                DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " OK");

                if (isProbOn)
                {
                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    Port.Write("sampleon 1" + ReadToChar);
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " sampleon 1");
                    Port.Write(WriteReadToChar);
                    Thread.Sleep(100);
                    ans = Port.ReadTo(ReadToChar);
                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    if (ans != "OK") throw (new Exception("error:f1-2012 Command:sampleon"));
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " OK");
                }

                if (isDummyOn)
                {
                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    Port.Write("dummyon 1" + ReadToChar);
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + " dummyon 1");
                    Port.Write(WriteReadToChar);
                    Thread.Sleep(100);
                    ans = Port.ReadTo(ReadToChar);
                    Port.DiscardOutBuffer(); //Clear Buffer
                    Port.DiscardInBuffer(); //Clear Buffer
                    if (ans != "OK") throw (new Exception("error:f1-2001 Command:dummyon"));
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + "Offset Removal Done ...");
                }

            }
            catch (Exception e)
            { MessageBox.Show(e.Message); SetStatus("Failed ..."); }

            return err;
        }

        public void SetSampleOff()
        {
            isProbOn = false;
            isDummyOn = false;
            SampleOnBtn.Text = "Probe On";
            SampleOnBtn.Enabled = true;
            SampleOnBtn.ForeColor = Color.Red;
            DummyOnBtn.Text = "Dummy On";
            DummyOnBtn.Enabled = true;
            DummyOnBtn.ForeColor = Color.Red;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isVmlpCompleted && AllSessions[Selected].IVVmlp != VMLP.SelectedIndex)
            {
                isVmlpCompleted = false;
                AllSessions[Selected].IVVmlp = VMLP.SelectedIndex;
                //LoadSelectedProperties();
                isIVRangesChanged = true;
                isVmlpCompleted = true;
                //VMLP.Focus();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isImlpCompleted && AllSessions[Selected].IVImlp != IMLP.SelectedIndex)
            {
                isImlpCompleted = false;
                AllSessions[Selected].IVImlp = IMLP.SelectedIndex;
                //LoadSelectedProperties();
                isIVRangesChanged = true;
                isImlpCompleted = true;
                //IMLP.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (EIS.Connected)
            {
                if (isDummyOn)
                {
                    try
                    {
                        Port.DiscardOutBuffer(); //Clear Buffer
                        Port.DiscardInBuffer(); //Clear Buffer
                        Port.Write("dummyon 0" + WriteReadToChar);
                        Thread.Sleep(100);
                        string ans = Port.ReadTo(ReadToChar);
                        Port.DiscardOutBuffer(); //Clear Buffer
                        Port.DiscardInBuffer(); //Clear Buffer
                        if (ans == "OK")
                        {
                            isIVRangesChanged = true;
                            isDummyOn = false;
                            DummyOnBtn.Text = "Dummy On";
                            DummyOnBtn.ForeColor = Color.Red;
                            SampleOnBtn.Enabled = true;
                        }


                    }
                    catch { }
                }
                else
                {
                    //Thread.Sleep(700);
                    //CalculateIVOffsets();
                    //Thread.Sleep(700);
                    try
                    {
                        Port.DiscardOutBuffer(); //Clear Buffer
                        Port.DiscardInBuffer(); //Clear Buffer
                        Port.Write("dummyon 1" + WriteReadToChar);
                        Thread.Sleep(100);
                        string ans = Port.ReadTo(ReadToChar);
                        Thread.Sleep(100);
                        Port.DiscardOutBuffer(); //Clear Buffer
                        Port.DiscardInBuffer(); //Clear Buffer
                        if (ans == "OK")
                        {
                            isIVRangesChanged = true;
                            isDummyOn = true;
                            DummyOnBtn.Text = "Dummy Off";
                            DummyOnBtn.ForeColor = Color.Green;
                            SampleOnBtn.Enabled = false;
                        }
                    }
                    catch { }
                }
            }
            else
                MessageBox.Show("Application is not connected to any device. Go to following path and check connections and ports ...\n\nMeasurement->Connect");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (isFormEISDScope2)
            {
                FormEISDScope2.Hide();
                isFormEISDScope2 = false;
            }
            else
            {
                FormEISDScope2.Show(this);
                isFormEISDScope2 = true;
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Text = String.Empty;
            EnterFullScreenMode();
            loadSetting(ref Settings);
            checkmethods();

#if DEBUG
          textBox1_TextChanged(null, null);
          BtnPort_Click(null, null);
#endif
        }

        private void checkmethods()
        {
            int nMethods = 0;
            if (Settings.isEIS) nMethods++;
            if (Settings.isMSH) nMethods++;
            if (Settings.isCV) nMethods++;
            if (Settings.isIV0) nMethods++;
            if (Settings.isChrono) nMethods++;
            if (Settings.isPulse) nMethods++;

            if (nMethods < 2)
            {
                CBMode.Enabled = false;
            }
            else if (nMethods < 3)
            {
                if (Settings.isCV && Settings.isIV0)
                {
                    CBMode.Enabled = false;
                }
            }
        }

        private void TBIVVelosity_Validated(object sender, EventArgs e)
        {
            try
            {
                if (AllSessions[Selected].Mode == 3)
                {
                    if (AllSessions[Selected].PGmode != 3)
                    {
                        double vel = Convert.ToDouble(TBIVVelosity.Text) / 1000.0;
                        int timestep = (int)(Math.Abs(AllSessions[Selected].IVvoltageTo - AllSessions[Selected].IVVoltageFrom) / AllSessions[Selected].IVVoltageNStepp / vel);
                        TBTimeStep.Text = timestep.ToString();
                        TBTimeStep_TextChanged(TBTimeStep, null);
                    }
                    else
                    {
                        int ISelect = AllSessions[EIS.RunningSession].IVCurrentRangeMode;
                        double convertor = 1;
                        if (ISelect == 0)
                            convertor = 1;
                        else if (ISelect == 1)
                            convertor = 0.001;
                        else if (ISelect == 2)
                            convertor = 0.001;
                        else if (ISelect == 3)
                            convertor = 0.001;
                        else if (ISelect == 4)
                            convertor = 0.000001;
                        else if (ISelect == 5)
                            convertor = 0.000001;
                        else if (ISelect == 6)
                            convertor = 0.000001;
                        else
                            convertor = 0.000000001;

                        double vel = Convert.ToDouble(TBIVVelosity.Text) / 1000.0;
                        int timestep = (int)(convertor * Math.Abs(AllSessions[Selected].IVvoltageTo - AllSessions[Selected].IVVoltageFrom) / AllSessions[Selected].IVVoltageNStepp / vel);
                        TBTimeStep.Text = timestep.ToString();
                        TBTimeStep_TextChanged(TBTimeStep, null);
                    }
                }
                else
                {
                    double EndTime = AllSessions[Selected].ChronoEndTime * 1000; //ms
                    double vel = Convert.ToDouble(TBIVVelosity.Text) / 1000.0;
                    int timestep = (int)(Math.Abs(EndTime) / AllSessions[Selected].IVVoltageNStepp / vel);
                    TBTimeStep.Text = timestep.ToString();
                    TBTimeStep_TextChanged(TBTimeStep, null);
                }
                //TBTimeStep.Text = AllSessions[Selected].IVTimeStep.ToString();
                //double vel = Math.Abs(AllSessions[Selected].IVVoltageTo - AllSessions[Selected].IVVoltageFrom) / AllSessions[Selected].IVVoltageNStep / AllSessions[Selected].IVTimeStep * 1000.0;
                //TBIVVelosity.Text = vel.ToString();

                //LoadSelectedProperties();
                //TBIVVelosity.Focus();
            }
            catch
            {
            }
        }

        private void TBIVVelosity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) TBIVVelosity_Validated((object)sender, (EventArgs)e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //FormAdminPass f = new FormAdminPass();
            //f.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (TBLogin.Text == "admin001" || TBLogin.Text == "advancedadmin")
            {
                if (TBLogin.Text == "advancedadmin")
                    FormSettings.isAdvanced = true;
                else
                    FormSettings.isAdvanced = false;

                BtnVirtualMachine.Visible = true;
                BtnFitt.Visible = true;
                BtnTerminal.Visible = true;
                button2.Visible = true;
                BtnSetting.Visible = true;
                
                Size s = GBAdminLog.Size;
                s.Height = 240;
                GBAdminLog.Size = s;
                BtnLogout.Enabled = true;
                TBLogin.Text = "";
                TBLogin.Enabled = false;
                labellogedin.Visible = true;
                isAdminLoged = true;
            }
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            BtnVirtualMachine.Visible = false;
            BtnFitt.Visible = false;
            BtnTerminal.Visible = false;
            button2.Visible = false;
            BtnSetting.Visible = false;
            
            Size s = GBAdminLog.Size;
            s.Height = 20;
            GBAdminLog.Size = s;
            BtnLogout.Enabled = false;
            TBLogin.Text = "";
            TBLogin.Enabled = true;
            labellogedin.Visible = false;
            isAdminLoged = false;
        }

        private void TBEqTime_Validated(object sender, EventArgs e)
        {
            IntDigitTextChange(ref AllSessions[Selected].EqTime, TBEqTime, 0, 1000);
        }

        private void ChBOCT_CheckedChanged(object sender, EventArgs e)
        {
            AllSessions[Selected].isOCP = ChBOCT.Checked;
            //CBEISOCMode.Enabled = ChBOCT.Checked;
            LoadSelectedProperties();
            //TBVOCP.Focus();
            //ChBOCT.Focus();
        }

        private void ChBRelRef_CheckedChanged(object sender, EventArgs e)
        {
            AllSessions[Selected].RelRef = ChBRelRef.Checked;
            //ChBRelRef.Focus();
        }

        private void PreproccessingTimer_Tick(object sender, EventArgs e)
        {
            if (AllSessions[EIS.RunningSession].isPreProcProbOn)
            {
                if (!isProbOn)
                {
                    SampleOnBtn_Click(null, null);
                }
            }

            if (!(AllSessions[EIS.RunningSession].Mode == 0 && AllSessions[EIS.RunningSession].Mode == 3))
            {
                SetPreTreatmentVoltage();
            }



            TotalTime = TotalTime + PreproccessingTimer.Interval;
            int sectime = (int)((double)TotalTime/1000.0);
            int tEnd = 1 - sectime;
            AllSessionsGUI[Selected].Text = "Session Name: " + AllSessions[EIS.RunningSession].name + "  " + tEnd.ToString() + "(s)" + " " + AllSessions[EIS.RunningSession].DataAndTime;
            if (sectime >= 1)
            {
                AllSessionsGUI[Selected].Text = "Session Name: " + AllSessions[EIS.RunningSession].name + " " + AllSessions[EIS.RunningSession].DataAndTime;
                TotalTime = 0;
                PreproccessingTimer.Stop();
                isPreProccessingCompleted = true;
                RunSession(AllSessions[EIS.RunningSession]);
            }
        }

        private void CheckPID_Click(object sender, EventArgs e)
        {
            FormPID pid = new FormPID();
            pid.ShowDialog();
        }

        private void OCTTimer_Tick(object sender, EventArgs e)
        {
            
        }

        private void CBEISACCurrentRangeMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBEISACCurrentRangeMode.SelectedIndex < 3)
            {
                AllSessions[Selected].EISACCurrentRangeMode = CBEISACCurrentRangeMode.SelectedIndex;
            }
            else
            {
                MessageBox.Show("This feature is not available ...");
                CBEISACCurrentRangeMode.SelectedIndex = AllSessions[Selected].EISACCurrentRangeMode;
            }
        }

        private void TBEqTime_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void TBEqTime_TextChanged(object sender, EventArgs e)
        {
            //IntDigitTextChange(ref AllSessions[Selected].EqTime, TBEqTime, 0, 10000);
            //LoadSelectedProperties();
            //TBEqTime.Focus();
        }

        private void BtnFindOCP_Click(object sender, EventArgs e)
        {
            if (EIS.Connected)
            {
                if (BoardType > 1)
                {
                    try
                    {
                        Port.DiscardOutBuffer(); //Clear Buffer
                        Port.DiscardInBuffer(); //Clear Buffer
                        Port.Write("sampleon 0" + WriteReadToChar);
                        Thread.Sleep(100);
                        string ans = Port.ReadTo(ReadToChar);
                        Port.DiscardOutBuffer(); //Clear Buffer
                        Port.DiscardInBuffer(); //Clear Buffer
                        if (ans == "OK")
                        {
                            isIVRangesChanged = true;
                            isProbOn = false;
                            SampleOnBtn.Text = "Probe On";
                            SampleOnBtn.ForeColor = Color.Red;
                            DummyOnBtn.Enabled = true;
                        }
                    }
                    catch { }
                }

                if (!isformPID)
                {
                    isformPID = true;
                    FormPID pid = new FormPID();
                    //OCTTimer.Start();
                    pid.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Application is not connected to any device. Go to following path and check connections and ports ...\n\nMeasurement->Connect");
            }
        }

        private void BtnUseSuggestedVOCP_Click(object sender, EventArgs e)
        {
            AllSessions[Selected].V_OCT = SugestedVOCP;
            TBVOCP.Text = AllSessions[Selected].V_OCT.ToString();
        }

        private void TBVOCP_Validating(object sender, CancelEventArgs e)
        {
            DigitTextChange(ref AllSessions[Selected].V_OCT, TBVOCP, -100, 100);
        }

        private void PanelProperties_MouseEnter(object sender, EventArgs e)
        {
            LabelSuggestedVOCP.Text = SugestedVOCP.ToString();
        }

        private void label51_MouseEnter(object sender, EventArgs e)
        {
            LabelSuggestedVOCP.Text = SugestedVOCP.ToString();
        }

        private void CBEISOCMode_MouseEnter(object sender, EventArgs e)
        {
            LabelSuggestedVOCP.Text = SugestedVOCP.ToString();
        }

        private void ChBOCT_MouseEnter(object sender, EventArgs e)
        {
            LabelSuggestedVOCP.Text = SugestedVOCP.ToString();
        }

        private void label52_MouseEnter(object sender, EventArgs e)
        {
            LabelSuggestedVOCP.Text = SugestedVOCP.ToString();
        }

        private void LabelSuggestedVOCP_MouseEnter(object sender, EventArgs e)
        {
            LabelSuggestedVOCP.Text = SugestedVOCP.ToString();
        }

        private void label50_MouseEnter(object sender, EventArgs e)
        {
            LabelSuggestedVOCP.Text = SugestedVOCP.ToString();
        }

        private void TBVOCP_MouseEnter(object sender, EventArgs e)
        {
            LabelSuggestedVOCP.Text = SugestedVOCP.ToString();
        }

        private void BtnUseSuggestedVOCP_MouseEnter(object sender, EventArgs e)
        {
            LabelSuggestedVOCP.Text = SugestedVOCP.ToString();
        }

        private void Desktop_MouseEnter(object sender, EventArgs e)
        {
            LabelSuggestedVOCP.Text = SugestedVOCP.ToString();
        }

        private void Desktop_MouseLeave(object sender, EventArgs e)
        {
            LabelSuggestedVOCP.Text = SugestedVOCP.ToString();
        }

        private void BtnEISAveNum_Validated(object sender, EventArgs e)
        {
            IntDigitTextChange(ref AllSessions[Selected].EISAverageNumberL, BtnEISAveNum, 1, 10);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //FormPdf fpdf = new FormPdf();
            //fpdf.Show();
            process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            process.StartInfo = startInfo;
            startInfo.FileName = @"..\Help\Tutorial.pdf";
            process.Start();
            if (!string.IsNullOrWhiteSpace(@"..\Help\Tutorial.pdf"))
            {
                webBrowser1.Navigate(@"..\Help\Tutorial.pdf");
            }
        }

        private void BtnOffsetRemoval_Click(object sender, EventArgs e)
        {
            if (EIS.Connected)
            {
                try
                {
                    // listbox.SelectedIndex = listbox.Items.Count - 1;
                  //  DebugListBox.AutoScrollOffset = 1;
                    DebugListBox.Items.Clear();
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + "Offset Removal starting ...");
                    CalculateSetSelectZeroset();
                }
                catch
                {

                }
            }
            else
            {
                MessageBox.Show("Application is not connected to any device. Go to following path and check connections and ports ...\n\nMeasurement->Connect");
            }
        }

        private void BtnTerminal_Click(object sender, EventArgs e)
        {
            if (!isFormTerminal)
            {

                if (EIS.Connected)
                {
                    if (!isRunStart)
                    {
                        isFormTerminal = true;
                        formTerminal.ShowDialog(this);
                    }
                    else
                        MessageBox.Show("Application is Running. First Stop Run ...\n\nTools->Stop");
                }
                else
                    MessageBox.Show("Application is not connected to any device. Go to following path and check connections and ports ...\n\nMeasurement->Connect");

            }

        }

        private void BtnEISAveNumH_Validated(object sender, EventArgs e)
        {
            IntDigitTextChange(ref AllSessions[Selected].EISAverageNumberH, BtnEISAveNumH, 1, 10);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SetLabel(ref Label_vdc, 200020, "Hz");
            SetLabel(ref Label_idc, 2000200, "Hz");
            SetLabel(ref Label_vac, 20002000, "Hz");
            SetLabel(ref Label_frq, 2000200000, "Hz");
            //9373872524
        }

        private void CBEISMaxVmlp_SelectedIndexChanged(object sender, EventArgs e)
        {
            AllSessions[Selected].EISVmlpMax = CBEISMaxVmlp.SelectedIndex;
        }

        private void CBEISMaxImlp_SelectedIndexChanged(object sender, EventArgs e)
        {
            AllSessions[Selected].EISImlpMax = CBEISMaxImlp.SelectedIndex;
        }

        private void BtnRunS_Click(object sender, EventArgs e)
        {
            if (EIS.Connected)
            {
                if (Selected > -1 && EIS.nSsn > 0)
                {
                    loadSetting(ref Settings);
                    if (AllSessions[Selected].isFinished && !isRunStart)
                    {
                        //FormRunWarning FormRunWarn = new FormRunWarning();
                        //FormRunWarn.listBox1.Items.Add(AllSessions[Selected].Name);
                        //FormRunWarn.ShowDialog();
                        //FormRunWarn.Dispose();
                        //if (!isRunCanseled)
                        //{
                            StartRunningSelected();
                        //}
                    }
                    else
                    {
                        StartRunningSelected();
                    }
                }
                else
                    MessageBox.Show("Select a session to run ...");
            }
            else
                MessageBox.Show("Application is not connected to any device. Go to following path and check connections and ports ...\n\nMeasurement->Connect");
        }

        private void StartRunningSelected()
        {
            if (isRunStart)
            {
                StopRun();
            }
            else
            {

                if (EIS.Connected)
                {
                    if (EIS.nSsn == 0)
                        MessageBox.Show("There is no session to run! Create new session by following path ...\n\nTools->New Session");
                    else
                    {
                        Port.DiscardOutBuffer(); //Clear Buffer
                        Port.DiscardInBuffer(); //Clear Buffer
                        //AllSessionsData.Clear();
                        SessionsDim = new int[EIS.nSsn];
                        nPBAllSessions = 0;
                        AllSessions[Selected].isStarted = false;
                        AllSessions[Selected].isFinished = false;
                        SessionsDim[Selected] = Dim(AllSessions[Selected]);
                        nPBAllSessions = nPBAllSessions + SessionsDim[Selected];

                        PBAllSessionsValue = 0;
                        PBAllSessions.Minimum = 1;
                        PBAllSessions.Maximum = nPBAllSessions;

                        //////////////////////////////////////////////////////////////////////
                        //Finding the first Active Session
                        EIS.RunningSession = Selected;
                        AllSessions[EIS.RunningSession].isStarted = true;
                        GoToNext = false;
                        RunSession(AllSessions[EIS.RunningSession]);
                        //////////////////////////////////////////////////////////////////////

                        EIS.RunCompleted = false;
                        
                    }
                }
                else
                {
                    MessageBox.Show("Application is not connected to any device. Go to following path and check connections and ports ...\n\nMeasurement->Connect");
                }
            }
        }

        private void BtnSaveOffsetSettings_Click(object sender, EventArgs e)
        {
            if (EIS.Connected)
            {
                try
                {
                    MessageBox.Show("micro save number 2");
                    if (microsaveSetting("../settings.bin"))
                        MessageBox.Show("Done.\nDevice settings are updated ...");
                    else
                        MessageBox.Show("Failed.\nDevice settings are not updated ...");
                }
                catch
                {

                }
            }
            else
            {
                MessageBox.Show("Application is not connected to any device. Go to following path and check connections and ports ...\n\nMeasurement->Connect");
            }
        }

        private void TBVOCP_TextChanged(object sender, EventArgs e)
        {

        }

        private void TBIdealVoltage_Validated(object sender, EventArgs e)
        {
            DigitTextChange(ref AllSessions[Selected].IdealVoltage, TBIdealVoltage, -1000.0, 1000.0);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            isIVRangesChanged = true;
          //  MessageBox.Show("done.");
        }

        private void TBIVVoltageFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) TBIVVoltageFrom_TextChanged(null, null);
        }

        private void TBIVVoltageTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) TBIVVoltageTo_TextChanged(null, null);
        }

        private void TBIVVoltageStep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) TBIVVoltageStep_TextChanged(null, null);
        }

        private void BtnVoltageOffsetRemoval_Click(object sender, EventArgs e)
        {
            if (EIS.Connected)
            {
                MessageBox.Show("You are going to change voltage offset settings.\nPlease disconnect any sample which is connected to device.");
                try
                {
                    DebugListBox.Items.Clear();
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + "Voltage Offset Removal starting ...");
                    for (int vmlp = 0; vmlp < 6; vmlp++)
                    {
                        double Ioffset=0;
                        double Voffset=0;
                        CalculateSpecificIVOffsets(0, 0, vmlp, ref Ioffset, ref Voffset);
                        DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + "VMLP=" + vmlp.ToString() + " Voffset=" + Voffset.ToString() + " done.");
                        if (vmlp == 0)
                            Settings.GetDCV_OffsetMLP0 = (float)Voffset;
                        else if (vmlp == 1)
                            Settings.GetDCV_OffsetMLP1 = (float)Voffset;
                        else if (vmlp == 2)
                            Settings.GetDCV_OffsetMLP2 = (float)Voffset;
                        else if (vmlp == 3)
                            Settings.GetDCV_OffsetMLP3 = (float)Voffset;
                        else if (vmlp == 4)
                            Settings.GetDCV_OffsetMLP4 = (float)Voffset;
                        else if (vmlp == 5)
                            Settings.GetDCV_offsetMLP5 = (float)Voffset;
                        else if (vmlp == 6)
                            Settings.GetDCV_OffsetMLP6 = (float)Voffset;
                    }
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + "Voltage Offset Removal finished ...");
                    //saveSetting(ref Settings);
                    //MessageBox.Show("Voltage Offset Removal is done.\nYou should save settings to device via following path.\n\nTools>Save Offset Settings button");
                }
                catch
                {

                }


                try
                {
                    DebugListBox.Items.Clear();
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + "Current Offset Removal starting ...");
                    int BoardISelectMax = 3;
                    if (BoardType >= 2) BoardISelectMax = 7;
                    if (BoardType < 2) BoardISelectMax = 2;
                    for (int isel = 0; isel <= BoardISelectMax; isel++)
                    {
                        double Ioffset = 0;
                        double Voffset = 0;
                        CalculateSpecificIVOffsets(isel, 0, 0, ref Ioffset, ref Voffset);
                        DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + "isel=" + isel.ToString() + " Ioffset=" + Ioffset.ToString() + " done.");
                        if (isel == 0)
                            Settings.GetDCI_Offset0d = (float)Ioffset;
                        else if (isel == 1)
                            Settings.GetDCI_Offset1d = (float)Ioffset;
                        else if (isel == 2)
                            Settings.GetDCI_Offset2 = (float)Ioffset;
                        else if (isel == 3)
                            Settings.GetDCI_Offset3d = (float)Ioffset;
                        else if (isel == 4)
                            Settings.GetDCI_Offset4d = (float)Ioffset;
                        else if (isel == 5)
                            Settings.GetDCI_Offset5d = (float)Ioffset;
                        else if (isel == 6)
                            Settings.GetDCI_Offset6d = (float)Ioffset;
                        else if (isel == 7)
                            Settings.GetDCI_Offset7d = (float)Ioffset;
                    }
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + "Current Offset Removal finished ...");
                    saveSetting(ref Settings, "../settings.bin");
                    MessageBox.Show("Current Offset Removal is done.\nYou should save settings to device via following path.\n\nTools>Save Offset Settings button");
                }
                catch
                {

                }

            }
            else
            {
                MessageBox.Show("Application is not connected to any device. Go to following path and check connections and ports ...\n\nMeasurement->Connect");
            }
        }

        private void CB_PGMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_PGMode.SelectedIndex != 2)
                AllSessions[Selected].PGmode = CB_PGMode.SelectedIndex;
            else
            {
                MessageBox.Show("This option is not available in this version.");
                CB_PGMode.SelectedIndex = AllSessions[Selected].PGmode;
            }
            LoadSelectedProperties();
        }

        private void ChBOCPAutoStart_CheckedChanged(object sender, EventArgs e)
        {
            AllSessions[Selected].isOCPAutoStart = ChBOCPAutoStart.Checked;
            //CBEISOCMode.Enabled = ChBOCT.Checked;
            LoadSelectedProperties();
        }

        private void BtnBackupSettings_Click(object sender, EventArgs e)
        {
            saveSetting(ref Settings, "../settings_Backup.bin");
            MessageBox.Show("Settings backup is created.");
        }

        private void BtnRecoverSettings_Click(object sender, EventArgs e)
        {
            if (EIS.Connected)
            {
                try
                {
                    MessageBox.Show("save number 3");
                    if (microsaveSetting("../settings_Backup.bin"))
                    {
                        FileStream s = new FileStream("../settings_Backup.bin", FileMode.Open);
                        FileStream ms = new FileStream("../settings.bin", FileMode.Create);
                        for (int i = 0; i < s.Length; i++) ms.WriteByte((byte)s.ReadByte());
                        ms.Close();
                        s.Close();
                        MessageBox.Show("Done.\nDevice settings are updated ...");
                    }
                    else
                        MessageBox.Show("Failed.\nDevice settings are not updated ...");
                }
                catch
                {

                }
            }
            else
            {
                MessageBox.Show("Application is not connected to any device. Go to following path and check connections and ports ...\n\nMeasurement->Connect");
            }
        }

        private void ChBisCVEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (Settings.isCV)
            {
                AllSessions[Selected].isCVEnable = ChBisCVEnable.Checked;
                GBCV.Enabled = AllSessions[Selected].isCVEnable;
                this.TBIVVoltagedV_Validated(null, null);
            }
            else
            {
                MessageBox.Show("This feature is not available to your account.");
                this.ChBisCVEnable.CheckedChanged -= new System.EventHandler(this.ChBisCVEnable_CheckedChanged);
                ChBisCVEnable.Checked = AllSessions[Selected].isCVEnable;
                this.ChBisCVEnable.CheckedChanged += new System.EventHandler(this.ChBisCVEnable_CheckedChanged);
            }
            //LoadSelectedProperties();
        }

        private void TB_CV_StartPoint_Validated(object sender, EventArgs e)
        {
            DigitTextChange(ref AllSessions[Selected].CVStartpoint, TB_CV_StartPoint, -10000, 10000);
        }

        private void TB_CV_StartPoint_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) TB_CV_StartPoint_Validated(null, null);
        }

        private void TB_CV_Itteration_Validated(object sender, EventArgs e)
        {
            IntDigitTextChange(ref AllSessions[Selected].CVItteration, TB_CV_Itteration, 1, 50);
        }

        private void TB_CV_Itteration_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) TB_CV_Itteration_Validated(null, null);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void TBPretreatmentVoltage_Validated(object sender, EventArgs e)
        {
            DigitTextChange(ref AllSessions[Selected].PretreatmentVoltage, TBPretreatmentVoltage, -5, 5);
        }

        private void ChBPreProcProbOn_CheckedChanged(object sender, EventArgs e)
        {
            AllSessions[Selected].isPreProcProbOn = ChBPreProcProbOn.Checked;
            LoadSelectedProperties();
        }

        private void ChBPostProcProbOff_CheckedChanged(object sender, EventArgs e)
        {
            AllSessions[Selected].isChBPostProcProbOff = ChBPostProcProbOff.Checked;
            LoadSelectedProperties();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
            LoadSelectedProperties();
            //UpdatePulse();
        }

        private void ChBChronoFastMode_CheckedChanged(object sender, EventArgs e)
        {
            AllSessions[Selected].Chrono_isfast = ChBChronoFastMode.Checked;
            LoadSelectedProperties();
        }

        private void UpdatePulse()
        {
            PulseMaxVoltage = -100000000.0;
            PulseMinVoltage = 100000000.0;
            try{chart1.Series[0].Points.Clear();}catch { }
            try{chart1.Series[1].Points.Clear();}catch { }
            try { chart1.Series[2].Points.Clear(); }catch { }
            try { chart1.Series[3].Points.Clear(); }catch { }
            int n = AllSessions[Selected].Chrono_n;
            double TotalPeriod = AllSessions[Selected].Chrono_Total_Period;
            double PulsePeriod = AllSessions[Selected].Chrono_Pulse_Period;
            double PulseLevel = AllSessions[Selected].Chrono_Pulse_Level;
            double PulseAmp = AllSessions[Selected].Chrono_Pulse_Amplitude;
            double LevelStep = AllSessions[Selected].Chrono_Level_Step;
            double AmpStep = AllSessions[Selected].Chrono_Amplitude_step;

            if (Form1.AllSessions[Form1.Selected].PulseVoltammetryMode == 2) PulseAmp = -PulseAmp;
            double sw = PulseAmp / 2;
            if (Form1.AllSessions[Form1.Selected].PulseVoltammetryMode == 2) PulseLevel = PulseLevel - sw;
            double t2 = (TotalPeriod - PulsePeriod);
            if (Form1.AllSessions[Form1.Selected].PulseVoltammetryMode == 2) AddPoint(0, -t2, PulseLevel + sw);

            AddPoint(0, -t2, PulseLevel);
            for (int i = 0; i < n; i++)
            {

                double vvv = PulseLevel + i * LevelStep;
                if (PulseMaxVoltage < vvv) PulseMaxVoltage = vvv;
                if (PulseMinVoltage > vvv) PulseMinVoltage = vvv;
                AddPoint(0, 0 + i * TotalPeriod, vvv);
                vvv = PulseLevel + PulseAmp + i * AmpStep;
                if (PulseMaxVoltage < vvv) PulseMaxVoltage = vvv;
                if (PulseMinVoltage > vvv) PulseMinVoltage = vvv;
                AddPoint(0, 0 + i * TotalPeriod, vvv);
                vvv = PulseLevel + PulseAmp + i * AmpStep;
                if (PulseMaxVoltage < vvv) PulseMaxVoltage = vvv;
                if (PulseMinVoltage > vvv) PulseMinVoltage = vvv;
                AddPoint(0, PulsePeriod + i * TotalPeriod, vvv);
                vvv = PulseLevel + (i + 1) * LevelStep;
                if (PulseMaxVoltage < vvv) PulseMaxVoltage = vvv;
                if (PulseMinVoltage > vvv) PulseMinVoltage = vvv;

                if (i == n - 1 && Form1.AllSessions[Form1.Selected].PulseVoltammetryMode == 2)
                    AddPoint(0, PulsePeriod + i * TotalPeriod, vvv + sw - LevelStep);
                else
                    AddPoint(0, PulsePeriod + i * TotalPeriod, vvv);

                if (AllSessions[Selected].PulseReadingEdgemode == 0)
                {
                    AddPoint(1, 0 + i * TotalPeriod + 0.00001, PulseLevel + i * LevelStep + 0.00001);
                }
                else if (AllSessions[Selected].PulseReadingEdgemode == 1)
                {
                    AddPoint(1, PulsePeriod + i * TotalPeriod + 0.00001, PulseLevel + PulseAmp + i * AmpStep + 0.00001);
                }
                else if (AllSessions[Selected].PulseReadingEdgemode == 2)
                {
                    AddPoint(1, 0 + i * TotalPeriod + 0.00001, PulseLevel + i * LevelStep + 0.00001);
                    AddPoint(1, PulsePeriod + i * TotalPeriod + 0.00001, PulseLevel + PulseAmp + i * AmpStep + 0.00001);
                }

            }
            if (Form1.AllSessions[Form1.Selected].PulseVoltammetryMode != 2) AddPoint(0, TotalPeriod + (n - 1) * TotalPeriod, PulseLevel + n * LevelStep);

            double Thereshold = 0;
            if (AllSessions[Selected].PulseVoltageRangeMode == 0) Thereshold = 5;
            if (AllSessions[Selected].PulseVoltageRangeMode == 1) Thereshold = 1;

            double xmin = -t2;
            double xmax = TotalPeriod + (n - 1) * TotalPeriod;
            WarnLabel.Visible = false;
            if (PulseMinVoltage < -Thereshold)
            {
                WarnLabel.Visible = true;
                AddPoint(2, xmin, -Thereshold);
                AddPoint(2, xmax, -Thereshold);
            }

            if (PulseMaxVoltage > Thereshold)
            {
                WarnLabel.Visible = true;
                AddPoint(3, xmin, Thereshold);
                AddPoint(3, xmax, Thereshold);
            }
        }

        private void AddPoint(int SeriesIndex, double x, double y)
        {
            chart1.Series[SeriesIndex].Points.AddXY(x, y);
        }

        private void AddSeries(string legend, string xAxis, string yAxis, Color color)
        {
            chart1.Series.Add(legend);
            int Index = -1;
            foreach (System.Windows.Forms.DataVisualization.Charting.Series S in chart1.Series) Index++;
            chart1.Series[Index].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[Index].Color = color;
            chart1.Series[Index].BorderWidth = 2;
            chart1.Series[Index].LegendText = legend;
            chart1.ChartAreas[0].Axes[0].Title = xAxis;
            chart1.ChartAreas[0].Axes[1].Title = yAxis;
            chart1.Series[Index].IsVisibleInLegend = false;
        }

        private void AddSeriesPoint(string legend, string xAxis, string yAxis, Color color)
        {
            chart1.Series.Add(legend);
            int Index = -1;
            foreach (System.Windows.Forms.DataVisualization.Charting.Series S in chart1.Series) Index++;
            chart1.Series[Index].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chart1.Series[Index].Color = color;
            chart1.Series[Index].BorderWidth = 10;
            chart1.Series[Index].LegendText = legend;
            chart1.ChartAreas[0].Axes[0].Title = xAxis;
            chart1.ChartAreas[0].Axes[1].Title = yAxis;
            chart1.Series[Index].IsVisibleInLegend = false;
        }

        private void CBPulseVoltageRangeMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isCBPulseVoltageRangeCompleted)
            {
                isCBPulseVoltageRangeCompleted = false;
                AllSessions[Selected].PulseVoltageRangeMode = CBPulseVoltageRangeMode.SelectedIndex;
                //LoadSelectedProperties();
                UpdatePulse();
                isCBPulseVoltageRangeCompleted = true;
                //TBIVVoltageFrom.Focus();
                //CBIVVoltageRangeMode.Focus();
                
            }
        }

        private void CBPulseVmlp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isPulseVmlpCompleted && AllSessions[Selected].PulseVmlp != CBPulseVmlp.SelectedIndex)
            {
                isPulseVmlpCompleted = false;
                AllSessions[Selected].IVVmlp = CBPulseVmlp.SelectedIndex;
                //LoadSelectedProperties();
                isPulseRangesChanged = true;
                isPulseVmlpCompleted = true;
                //VMLP.Focus();
            }
        }

        private void CBPulseCurrentRangeMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isCBPulseRangeCompleted && AllSessions[Selected].PulseCurrentRangeMode != CBPulseCurrentRangeMode.SelectedIndex)
            {
                isCBPulseRangeCompleted = false;
                /*if (CBIVRange.SelectedIndex < 2)
                {
                    AllSessions[Selected].IVCurrentRangeMode = CBIVRange.SelectedIndex;
                }
                else
                {
                    MessageBox.Show("You are not allowed to change to this range manually ...");
                }*/
                AllSessions[Selected].PulseCurrentRangeMode = CBPulseCurrentRangeMode.SelectedIndex;
                //LoadSelectedProperties();


                isPulseVmlpCompleted = false;
                isPulseImlpCompleted = false;

                CBPulseVmlp.Items.Clear();
                CBPulseImlp.Items.Clear();

                int pow2mlp = 1;
                for (int mlp = 0; mlp < 7; mlp++)
                {
                    double Vmax = Settings.GetDCV_Domain;
                    double Imax = 0;

                    if (CBPulseCurrentRangeMode.SelectedIndex == 0)
                        Imax = 1;
                    else if (CBPulseCurrentRangeMode.SelectedIndex == 1)
                        Imax = 100;
                    else if (CBPulseCurrentRangeMode.SelectedIndex == 2)
                        Imax = 10;
                    else if (CBPulseCurrentRangeMode.SelectedIndex == 3)  //Added in EISProject66
                        Imax = 1;
                    else if (CBPulseCurrentRangeMode.SelectedIndex == 4)  //Added in EISProject71
                        Imax = 100;
                    else if (CBPulseCurrentRangeMode.SelectedIndex == 5)  //Added in EISProject71
                        Imax = 10;
                    else if (CBPulseCurrentRangeMode.SelectedIndex == 6)  //Added in EISProject71
                        Imax = 1;
                    else if (CBPulseCurrentRangeMode.SelectedIndex == 7)  //Added in EISProject71
                        Imax = 100;

                    double dImax = 1.0 * Imax / pow2mlp;
                    double dVmax = 1.0 * Vmax / pow2mlp;

                    double Ifact = Math.Pow(10, Math.Floor(Math.Log10(dImax)));
                    double Vfact = Math.Pow(10, Math.Floor(Math.Log10(dVmax)));
                    dImax = Math.Floor(dImax / Ifact) * Ifact;
                    dVmax = Math.Floor(dVmax / Vfact) * Vfact;

                    CBPulseVmlp.Items.Add("[-" + dVmax.ToString() + "(V)  ..  " + dVmax.ToString() + "(V)]");

                    if (CBPulseCurrentRangeMode.SelectedIndex <= 0)
                    {
                        CBPulseImlp.Items.Add("[-" + dImax.ToString() + "(A)  ..  " + dImax.ToString() + "(A)]");
                        if (AllSessions[Selected].PulseImlpp == mlp) PulseMaxFineCurrent = dImax;
                    }
                    else if (CBPulseCurrentRangeMode.SelectedIndex == 1)
                    {
                        CBPulseImlp.Items.Add("[-" + dImax.ToString() + "(mA)  ..  " + dImax.ToString() + "(mA)]");
                        if (AllSessions[Selected].PulseImlpp == mlp) PulseMaxFineCurrent = dImax * 0.001;
                    }
                    else if (CBPulseCurrentRangeMode.SelectedIndex == 2)
                    {
                        CBPulseImlp.Items.Add("[-" + dImax.ToString() + "(mA)  ..  " + dImax.ToString() + "(mA)]");
                        if (AllSessions[Selected].PulseImlpp == mlp) PulseMaxFineCurrent = dImax * 0.001;
                    }
                    else if (CBPulseCurrentRangeMode.SelectedIndex == 3)                                                          //Added in EISProject66
                    {
                        CBPulseImlp.Items.Add("[-" + dImax.ToString() + "(mA)  ..  " + dImax.ToString() + "(mA)]");
                        if (AllSessions[Selected].PulseImlpp == mlp) PulseMaxFineCurrent = dImax * 0.001;
                    }
                    else if (CBPulseCurrentRangeMode.SelectedIndex == 4)                                                          //Added in EISProject71
                    {
                        CBPulseImlp.Items.Add("[-" + dImax.ToString() + "(uA)  ..  " + dImax.ToString() + "(uA)]");
                        if (AllSessions[Selected].PulseImlpp == mlp) PulseMaxFineCurrent = dImax * 0.000001;
                    }
                    else if (CBPulseCurrentRangeMode.SelectedIndex == 5)                                                          //Added in EISProject71
                    {
                        CBPulseImlp.Items.Add("[-" + dImax.ToString() + "(uA)  ..  " + dImax.ToString() + "(uA)]");
                        if (AllSessions[Selected].PulseImlpp == mlp) PulseMaxFineCurrent = dImax * 0.000001;
                    }
                    else if (CBPulseCurrentRangeMode.SelectedIndex == 6)                                                          //Added in EISProject71
                    {
                        CBPulseImlp.Items.Add("[-" + dImax.ToString() + "(uA)  ..  " + dImax.ToString() + "(uA)]");
                        if (AllSessions[Selected].PulseImlpp == mlp) PulseMaxFineCurrent = dImax * 0.000001;
                    }
                    else if (CBPulseCurrentRangeMode.SelectedIndex == 7)                                                          //Added in EISProject71
                    {
                        CBPulseImlp.Items.Add("[-" + dImax.ToString() + "(nA)  ..  " + dImax.ToString() + "(nA)]");
                        if (AllSessions[Selected].PulseImlpp == mlp) PulseMaxFineCurrent = dImax * 0.000000001;
                    }

                    pow2mlp = pow2mlp * 2;
                }

                CBPulseVmlp.SelectedIndex = AllSessions[Selected].PulseVmlp;
                CBPulseImlp.SelectedIndex = AllSessions[Selected].PulseImlpp;

                isPulseVmlpCompleted = true;
                isPulseImlpCompleted = true;


                isPulseRangesChanged = true;
                isCBPulseRangeCompleted = true;
                //CBIVRange.Focus();
                LoadSelectedProperties();
            }
        }

        private void CBPulseImlp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isPulseImlpCompleted && AllSessions[Selected].PulseImlpp != CBPulseImlp.SelectedIndex)
            {
                isPulseImlpCompleted = false;
                AllSessions[Selected].PulseImlpp = CBPulseImlp.SelectedIndex;
                //LoadSelectedProperties();
                isPulseRangesChanged = true;
                isPulseImlpCompleted = true;
                //IMLP.Focus();
            }
        }

        private void RB_Trailing_CheckedChanged(object sender, EventArgs e)
        {
            if (RB_Trailing.Checked)
            {
                AllSessions[Selected].PulseReadingEdgemode = 0;
                UpdatePulse();
            }
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            if (EIS.Connected)
            {
                try
                {
                    DebugListBox.Items.Clear();
                    DebugListBox.Items.Add("stp:" + DebugListBox.Items.Count.ToString() + "Offset Removal starting ...");
                    CalculateGalvanostatSetSelectZeroset();
                }
                catch
                {

                }
            }
            else
            {
                MessageBox.Show("Application is not connected to any device. Go to following path and check connections and ports ...\n\nMeasurement->Connect");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ChronoTimingForm f = new ChronoTimingForm();
            f.ShowDialog();
        }

        private void TBIVVoltagedV_Validated(object sender, EventArgs e)
        {
            double dV = 0;
            DigitTextChange(ref dV, TBIVVoltagedV, -10000, 10000);
            int n=0;
            double max = AllSessions[Selected].IVvoltageTo;
            double min = AllSessions[Selected].IVVoltageFrom;
            if (AllSessions[Selected].Mode == 2)
            {
                min = 0;
                max = AllSessions[Selected].ChronoEndTime;
            }
            if (Math.Abs(dV) < Math.Abs((max - min) / (9999-1))) dV = (max - min) / (9999 - 1);
            this.TBIVVoltagedV.Validated -= new System.EventHandler(this.TBIVVoltagedV_Validated);
            TBIVVoltagedV.Text = dV.ToString("0.00000000");
            this.TBIVVoltagedV.Validated += new System.EventHandler(this.TBIVVoltagedV_Validated);
            n = (int)Math.Round((max - min) / dV);
            n++;
            if (n < 2) n = 2;
            if (n > 9999) n = 9999;
            TBIVVoltageStep.Text = n.ToString();
            TBIVVoltageStep_TextChanged(null,null);
            
            //double newdV = (max - min) / (n - 1);
            double newmax = min + (n - 1) * dV;
            TBIVVoltageTo.Text = newmax.ToString();
            TBIVVoltageTo_TextChanged(null, null);

            if (AllSessions[Selected].Mode == 3 && AllSessions[Selected].isCVEnable)
            {
                int isValid = 0;
                double newStep=0;
                int newNStep=0;
                CheckCVStep(max,min, ref isValid, ref newStep, ref newNStep);
                if (isValid != 0)
                {
                    TBIVVoltageStep.Text = newNStep.ToString();
                    TBIVVoltageStep_TextChanged(null, null);
                }
            }
        }

        private void CheckCVStep(double max, double min, ref int isValid, ref double newStep, ref int newNStep)
        {
            isValid = 0;
            double deltadouble = ((max - min) / (AllSessions[Selected].IVVoltageNStepp - 1));
            if (!EIS.Connected) { MessageBox.Show("Please check the connection. We are not able to check the step value.\nPlease make sure the software is connected to the device and set the value again."); return; }
            Port.Write("ver?" + WriteReadToChar);
            string Ver = Port.ReadTo(ReadToChar);
            string[] Parts;
            char[] delimiterChars = { '.' };
            Parts = Ver.Split(delimiterChars);
            int CurrentVer;
            CurrentVer = Convert.ToInt16(Parts[1]);
            double deltadouble2 = deltadouble;
            if (CurrentVer > 1) deltadouble2 = 100.0 * deltadouble;
            double sign = Math.Sign(deltadouble2);
            int deltaint = SetDCVConvert_dV(Math.Abs(deltadouble2), AllSessions[Selected].IVVoltageRangeMode, AllSessions[Selected].IVCurrentRangeMode, AllSessions[Selected].PGmode);
            deltaint -= 2047;
            deltaint = -deltaint;
            if (deltaint < 1)
            {
                isValid = -1;
                deltaint = 1;
            }
            if (deltaint > 65535)
            {
                isValid = 1;
                deltaint = 65535;
            }
            int newexact_deltaint = -deltaint + 2047;
            CV_newExactdelta = Inverse_SetDCVConvert_dV(newexact_deltaint, AllSessions[Selected].IVVoltageRangeMode, AllSessions[Selected].IVCurrentRangeMode, AllSessions[Selected].PGmode);
            if (CurrentVer > 1) CV_newExactdelta = CV_newExactdelta / 100.0;
            CV_newExactdelta = sign * Math.Abs(CV_newExactdelta);
            IVChronoDVset = CV_newExactdelta;
            int newN = (int)((max - min) / IVChronoDVset) + 1;
            newNStep = newN;
            newStep = CV_newExactdelta;
        }

        private void TBIVVoltagedV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) TBIVVoltagedV_Validated(null, null);
        }

        private void TBIVVoltagedV_TextChanged(object sender, EventArgs e)
        {

        }

        private void TBIVVoltageStep_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void TBACAmpConstant_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            Form scope = new FormEISDigital();
            scope.Show();
        }

        private void button_notch_Click(object sender, EventArgs e)
        {
            if (EIS.Connected)
            {
                if (button_notch.BackColor == Color.Green)
                {
                    try
                    {
                        Port.DiscardOutBuffer(); //Clear Buffer
                        Port.DiscardInBuffer(); //Clear Buffer
                        Port.Write("notch 0" + WriteReadToChar);
                        Thread.Sleep(100);
                        string ans = Port.ReadTo(ReadToChar);
                        Port.DiscardOutBuffer(); //Clear Buffer
                        Port.DiscardInBuffer(); //Clear Buffer
                        if (ans == "OK")
                        {
                            button_notch.BackColor = Color.Transparent;
                        }
                    }
                    catch { }

                }
                else
                {
                    try
                    {
                        Port.DiscardOutBuffer(); //Clear Buffer
                        Port.DiscardInBuffer(); //Clear Buffer
                        Port.Write("notch 1" + WriteReadToChar);
                        Thread.Sleep(100);
                        string ans = Port.ReadTo(ReadToChar);
                        Port.DiscardOutBuffer(); //Clear Buffer
                        Port.DiscardInBuffer(); //Clear Buffer
                        if (ans == "OK")
                        {
                            button_notch.BackColor = Color.Green;
                        }
                    }
                    catch { }

                }
            }
            else
            MessageBox.Show("Application is not connected to any device. Go to following path and check connections and ports ...\n\nMeasurement->Connect");
        }

        private void button_earth_Click(object sender, EventArgs e)
        {
            if (EIS.Connected)
            {
                if (button_earth.BackColor == Color.Green)
                {
                    try
                    {
                        Port.DiscardOutBuffer(); //Clear Buffer
                        Port.DiscardInBuffer(); //Clear Buffer
                        Port.Write("earth 1" + WriteReadToChar);
                        Thread.Sleep(100);
                        string ans = Port.ReadTo(ReadToChar);
                        Port.DiscardOutBuffer(); //Clear Buffer
                        Port.DiscardInBuffer(); //Clear Buffer
                        if (ans == "OK")
                        {
                            button_earth.BackColor = Color.Transparent;
                        }
                    }
                    catch { }

                }
                else
                {
                    try
                    {
                        Port.DiscardOutBuffer(); //Clear Buffer
                        Port.DiscardInBuffer(); //Clear Buffer
                        Port.Write("earth 0" + WriteReadToChar);
                        Thread.Sleep(100);
                        string ans = Port.ReadTo(ReadToChar);
                        Port.DiscardOutBuffer(); //Clear Buffer
                        Port.DiscardInBuffer(); //Clear Buffer
                        if (ans == "OK")
                        {
                            button_earth.BackColor = Color.Green;
                        }
                    }
                    catch { }

                }
            }
            else
                MessageBox.Show("Application is not connected to any device. Go to following path and check connections and ports ...\n\nMeasurement->Connect");

        }

        private void IVChronoVFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            AllSessions[Selected].IVChrono_VFilter = IVChronoVFilter.SelectedIndex;
        }

        private void PlseVFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            AllSessions[Selected].Pulse_VFilter = PlseVFilter.SelectedIndex;
        }

        private void RB_Leading_CheckedChanged(object sender, EventArgs e)
        {
            if (RB_Leading.Checked)
            {
                Form1.AllSessions[Form1.Selected].PulseReadingEdgemode = 1;
                UpdatePulse();
            }
        }

        private void RB_Differential_CheckedChanged(object sender, EventArgs e)
        {
            if (RB_Differential.Checked)
            {
                Form1.AllSessions[Form1.Selected].PulseReadingEdgemode = 2;
                UpdatePulse();
            }
        }
















    }
}
