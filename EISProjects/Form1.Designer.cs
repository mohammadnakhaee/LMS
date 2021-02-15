using System;
using System.Collections.Generic;
using System.Drawing;

namespace EISProjects
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TabFile = new System.Windows.Forms.TabPage();
            this.BtnImport = new System.Windows.Forms.Button();
            this.BtnAppend = new System.Windows.Forms.Button();
            this.CheckPID = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.BtnSaveAs = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnOpen = new System.Windows.Forms.Button();
            this.BtnNew = new System.Windows.Forms.Button();
            this.TabEdit = new System.Windows.Forms.TabPage();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnDuplicate = new System.Windows.Forms.Button();
            this.TabWindow = new System.Windows.Forms.TabPage();
            this.BtnVirtualMachine = new System.Windows.Forms.Button();
            this.BtnFitt = new System.Windows.Forms.Button();
            this.BtnTerminal = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.BtnSetting = new System.Windows.Forms.Button();
            this.BtnShowData = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.BtnDiagram = new System.Windows.Forms.Button();
            this.TabTools = new System.Windows.Forms.TabPage();
            this.button_clm = new System.Windows.Forms.Button();
            this.button_earth = new System.Windows.Forms.Button();
            this.button_notch = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.BtnFindOCP = new System.Windows.Forms.Button();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.BtnRunS = new System.Windows.Forms.Button();
            this.BtnRun = new System.Windows.Forms.Button();
            this.BtnPauseContinue = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.DummyOnBtn = new System.Windows.Forms.Button();
            this.SampleOnBtn = new System.Windows.Forms.Button();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.BtnCreateSession = new System.Windows.Forms.Button();
            this.BtnPort = new System.Windows.Forms.Button();
            this.TabOffset = new System.Windows.Forms.TabPage();
            this.BtnRecoverSettings = new System.Windows.Forms.Button();
            this.BtnBackupSettings = new System.Windows.Forms.Button();
            this.BtnSaveOffsetSettings = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.BtnOffsetRemoval = new System.Windows.Forms.Button();
            this.TabHelp = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.BtnAbout = new System.Windows.Forms.Button();
            this.TabLogin = new System.Windows.Forms.TabPage();
            this.labellogedin = new System.Windows.Forms.Label();
            this.BtnLogout = new System.Windows.Forms.Button();
            this.label46 = new System.Windows.Forms.Label();
            this.TBLogin = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.StatusPanel = new System.Windows.Forms.Panel();
            this.label_per = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.LabelIwar = new System.Windows.Forms.Label();
            this.LabelVwar = new System.Windows.Forms.Label();
            this.ProbWarningLabel = new System.Windows.Forms.Label();
            this.PBAllSessions = new System.Windows.Forms.ProgressBar();
            this.Panel101 = new System.Windows.Forms.Panel();
            this.PanelProperties = new System.Windows.Forms.Panel();
            this.GBPostprocessing = new System.Windows.Forms.GroupBox();
            this.ChBPostProcProbOff = new System.Windows.Forms.CheckBox();
            this.label65 = new System.Windows.Forms.Label();
            this.TBIdealVoltage = new System.Windows.Forms.TextBox();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.label53 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
            this.label54 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.GBExport = new System.Windows.Forms.GroupBox();
            this.ExpWarningLable = new System.Windows.Forms.Label();
            this.BtnSsnExpLocation = new System.Windows.Forms.Button();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.ChBExport = new System.Windows.Forms.CheckBox();
            this.GBPulse = new System.Windows.Forms.GroupBox();
            this.WarnLabel = new System.Windows.Forms.Label();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.RB_Differential = new System.Windows.Forms.RadioButton();
            this.RB_Leading = new System.Windows.Forms.RadioButton();
            this.RB_Trailing = new System.Windows.Forms.RadioButton();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.label47 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.CBPulseCurrentRangeMode = new System.Windows.Forms.ComboBox();
            this.CBPulseImlp = new System.Windows.Forms.ComboBox();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.PlseVFilter = new System.Windows.Forms.ComboBox();
            this.label78 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.CBPulseVoltageRangeMode = new System.Windows.Forms.ComboBox();
            this.CBPulseVmlp = new System.Windows.Forms.ComboBox();
            this.label75 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button10 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TBMSCHACAmpCnst = new System.Windows.Forms.TextBox();
            this.TBMSCHACFrqCnst = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TBMSCHDCVStp = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TBMSCHDCVTo = new System.Windows.Forms.TextBox();
            this.TBMSCHDCVFrm = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CBMode = new System.Windows.Forms.ComboBox();
            this.ChBActive = new System.Windows.Forms.CheckBox();
            this.TBSsnName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.GBEIS = new System.Windows.Forms.GroupBox();
            this.BtnEISAveNumH = new System.Windows.Forms.TextBox();
            this.label55 = new System.Windows.Forms.Label();
            this.BtnEISAveNum = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.CBEISFilterMode = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.CBEISMode = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.GBVoltages = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label61 = new System.Windows.Forms.Label();
            this.CBEISMaxImlp = new System.Windows.Forms.ComboBox();
            this.CBEISMaxVmlp = new System.Windows.Forms.ComboBox();
            this.label43 = new System.Windows.Forms.Label();
            this.CBEISACCurrentRangeMode = new System.Windows.Forms.ComboBox();
            this.TBACAmpConstant = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.CBEISACRegulatorMode = new System.Windows.Forms.ComboBox();
            this.label60 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TBDCVoltageConstant = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CBEISDCCurrentRangeMode = new System.Windows.Forms.ComboBox();
            this.label31 = new System.Windows.Forms.Label();
            this.CBEISVoltageRangeMode = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.GBFrequency = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.TBACFrqNStep = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TBACFrqTo = new System.Windows.Forms.TextBox();
            this.TBACFrqFrom = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.GBIV = new System.Windows.Forms.GroupBox();
            this.ChBisCVEnable = new System.Windows.Forms.CheckBox();
            this.button7 = new System.Windows.Forms.Button();
            this.GBCV = new System.Windows.Forms.GroupBox();
            this.TB_CV_Itteration = new System.Windows.Forms.TextBox();
            this.TB_CV_StartPoint = new System.Windows.Forms.TextBox();
            this.TBCVACAmpFrm = new System.Windows.Forms.TextBox();
            this.TBCVACAmpStp = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.TBCVACFrqCnst = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.TBCVDCVltCnst = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.TBCVACAmpTo = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.label34 = new System.Windows.Forms.Label();
            this.TBIVVelosity = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.TBTimeStep = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.TBIVVoltagedV = new System.Windows.Forms.TextBox();
            this.label76 = new System.Windows.Forms.Label();
            this.btnChronoTiming = new System.Windows.Forms.Button();
            this.ChBChronoFastMode = new System.Windows.Forms.CheckBox();
            this.MinUnitLabel = new System.Windows.Forms.Label();
            this.MaxUnitLabel = new System.Windows.Forms.Label();
            this.TBIVVoltageStep = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.TBIVVoltageTo = new System.Windows.Forms.TextBox();
            this.TBIVVoltageFrom = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.StepUnitLabel = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.label36 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.CBIVRange = new System.Windows.Forms.ComboBox();
            this.IMLP = new System.Windows.Forms.ComboBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.IVChronoVFilter = new System.Windows.Forms.ComboBox();
            this.label77 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.CBIVVoltageRangeMode = new System.Windows.Forms.ComboBox();
            this.VMLP = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.GBPreprocessing = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.ChBPreProcProbOn = new System.Windows.Forms.CheckBox();
            this.label71 = new System.Windows.Forms.Label();
            this.TBEqTime = new System.Windows.Forms.TextBox();
            this.label69 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.TBPretreatmentVoltage = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.ChBOCPAutoStart = new System.Windows.Forms.CheckBox();
            this.CB_PGMode = new System.Windows.Forms.ComboBox();
            this.BtnUseSuggestedVOCP = new System.Windows.Forms.Button();
            this.LabelSuggestedVOCP = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.CBEISOCMode = new System.Windows.Forms.ComboBox();
            this.TBVOCP = new System.Windows.Forms.TextBox();
            this.ChBOCT = new System.Windows.Forms.CheckBox();
            this.label50 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.LabelVOCT = new System.Windows.Forms.Label();
            this.ChBRelRef = new System.Windows.Forms.CheckBox();
            this.Prop = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogSSnExp = new System.Windows.Forms.SaveFileDialog();
            this.CMSSession = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IVTimer = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.GBAdminLog = new System.Windows.Forms.GroupBox();
            this.label_clm = new System.Windows.Forms.Label();
            this.label81 = new System.Windows.Forms.Label();
            this.label_iacdac = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.label_false = new System.Windows.Forms.Label();
            this.label80 = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.label_iIs = new System.Windows.Forms.Label();
            this.label_postfilter = new System.Windows.Forms.Label();
            this.Label_Filter_C_I = new System.Windows.Forms.Label();
            this.Label_IFilter = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.Label_Filter_C_V = new System.Windows.Forms.Label();
            this.Label_VFilter = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.iLabel_frq = new System.Windows.Forms.Label();
            this.iLabel_vac = new System.Windows.Forms.Label();
            this.Label_ISelect = new System.Windows.Forms.Label();
            this.iLabel_vdc = new System.Windows.Forms.Label();
            this.Label_Vmlp = new System.Windows.Forms.Label();
            this.Label_VSelect = new System.Windows.Forms.Label();
            this.Label_Imlp = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.label68 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.Label_vdc_real = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.label59 = new System.Windows.Forms.Label();
            this.Label_idc = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.Label_frq = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.Label_vdc = new System.Windows.Forms.Label();
            this.Label_vac = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.DebugListBox = new System.Windows.Forms.ListBox();
            this.PreproccessingTimer = new System.Windows.Forms.Timer(this.components);
            this.Desktop = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.TabFile.SuspendLayout();
            this.TabEdit.SuspendLayout();
            this.TabWindow.SuspendLayout();
            this.TabTools.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.TabOffset.SuspendLayout();
            this.TabHelp.SuspendLayout();
            this.TabLogin.SuspendLayout();
            this.StatusPanel.SuspendLayout();
            this.Panel101.SuspendLayout();
            this.PanelProperties.SuspendLayout();
            this.GBPostprocessing.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.GBExport.SuspendLayout();
            this.GBPulse.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.groupBox17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.GBEIS.SuspendLayout();
            this.GBVoltages.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.GBFrequency.SuspendLayout();
            this.GBIV.SuspendLayout();
            this.GBCV.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.GBPreprocessing.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.Prop.SuspendLayout();
            this.CMSSession.SuspendLayout();
            this.panel2.SuspendLayout();
            this.GBAdminLog.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TabFile);
            this.tabControl1.Controls.Add(this.TabEdit);
            this.tabControl1.Controls.Add(this.TabWindow);
            this.tabControl1.Controls.Add(this.TabTools);
            this.tabControl1.Controls.Add(this.TabOffset);
            this.tabControl1.Controls.Add(this.TabHelp);
            this.tabControl1.Controls.Add(this.TabLogin);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(80, 24);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1028, 100);
            this.tabControl1.TabIndex = 0;
            // 
            // TabFile
            // 
            this.TabFile.BackColor = System.Drawing.Color.White;
            this.TabFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TabFile.Controls.Add(this.BtnImport);
            this.TabFile.Controls.Add(this.BtnAppend);
            this.TabFile.Controls.Add(this.CheckPID);
            this.TabFile.Controls.Add(this.button3);
            this.TabFile.Controls.Add(this.BtnSaveAs);
            this.TabFile.Controls.Add(this.BtnSave);
            this.TabFile.Controls.Add(this.BtnOpen);
            this.TabFile.Controls.Add(this.BtnNew);
            this.TabFile.Location = new System.Drawing.Point(4, 28);
            this.TabFile.Name = "TabFile";
            this.TabFile.Padding = new System.Windows.Forms.Padding(3);
            this.TabFile.Size = new System.Drawing.Size(1020, 68);
            this.TabFile.TabIndex = 0;
            this.TabFile.Text = "File";
            // 
            // BtnImport
            // 
            this.BtnImport.BackColor = System.Drawing.Color.AliceBlue;
            this.BtnImport.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnImport.Enabled = false;
            this.BtnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnImport.Location = new System.Drawing.Point(703, 3);
            this.BtnImport.Name = "BtnImport";
            this.BtnImport.Size = new System.Drawing.Size(100, 60);
            this.BtnImport.TabIndex = 7;
            this.BtnImport.Text = "Import";
            this.BtnImport.UseVisualStyleBackColor = false;
            this.BtnImport.Visible = false;
            this.BtnImport.Click += new System.EventHandler(this.BtnImport_Click);
            // 
            // BtnAppend
            // 
            this.BtnAppend.BackColor = System.Drawing.Color.AliceBlue;
            this.BtnAppend.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnAppend.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAppend.Location = new System.Drawing.Point(603, 3);
            this.BtnAppend.Name = "BtnAppend";
            this.BtnAppend.Size = new System.Drawing.Size(100, 60);
            this.BtnAppend.TabIndex = 6;
            this.BtnAppend.Text = "Append";
            this.BtnAppend.UseVisualStyleBackColor = false;
            this.BtnAppend.Visible = false;
            this.BtnAppend.Click += new System.EventHandler(this.BtnAppend_Click);
            // 
            // CheckPID
            // 
            this.CheckPID.BackColor = System.Drawing.Color.AliceBlue;
            this.CheckPID.Dock = System.Windows.Forms.DockStyle.Left;
            this.CheckPID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckPID.Location = new System.Drawing.Point(503, 3);
            this.CheckPID.Name = "CheckPID";
            this.CheckPID.Size = new System.Drawing.Size(100, 60);
            this.CheckPID.TabIndex = 9;
            this.CheckPID.Text = "Check PID";
            this.CheckPID.UseVisualStyleBackColor = false;
            this.CheckPID.Visible = false;
            this.CheckPID.Click += new System.EventHandler(this.CheckPID_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.AliceBlue;
            this.button3.Dock = System.Windows.Forms.DockStyle.Left;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(403, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 60);
            this.button3.TabIndex = 8;
            this.button3.Text = "Log in as administrator";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // BtnSaveAs
            // 
            this.BtnSaveAs.BackColor = System.Drawing.Color.AliceBlue;
            this.BtnSaveAs.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnSaveAs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSaveAs.Location = new System.Drawing.Point(303, 3);
            this.BtnSaveAs.Name = "BtnSaveAs";
            this.BtnSaveAs.Size = new System.Drawing.Size(100, 60);
            this.BtnSaveAs.TabIndex = 5;
            this.BtnSaveAs.Text = "Save As";
            this.BtnSaveAs.UseVisualStyleBackColor = false;
            this.BtnSaveAs.Click += new System.EventHandler(this.BtnSaveAs_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.AliceBlue;
            this.BtnSave.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.Location = new System.Drawing.Point(203, 3);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(100, 60);
            this.BtnSave.TabIndex = 4;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnOpen
            // 
            this.BtnOpen.BackColor = System.Drawing.Color.AliceBlue;
            this.BtnOpen.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOpen.Location = new System.Drawing.Point(103, 3);
            this.BtnOpen.Name = "BtnOpen";
            this.BtnOpen.Size = new System.Drawing.Size(100, 60);
            this.BtnOpen.TabIndex = 3;
            this.BtnOpen.Text = "Open";
            this.BtnOpen.UseVisualStyleBackColor = false;
            this.BtnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // BtnNew
            // 
            this.BtnNew.BackColor = System.Drawing.Color.AliceBlue;
            this.BtnNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnNew.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNew.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnNew.Location = new System.Drawing.Point(3, 3);
            this.BtnNew.Margin = new System.Windows.Forms.Padding(0);
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(100, 60);
            this.BtnNew.TabIndex = 2;
            this.BtnNew.Text = "New";
            this.BtnNew.UseVisualStyleBackColor = true;
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // TabEdit
            // 
            this.TabEdit.BackColor = System.Drawing.Color.White;
            this.TabEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TabEdit.Controls.Add(this.BtnDelete);
            this.TabEdit.Controls.Add(this.BtnDuplicate);
            this.TabEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabEdit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TabEdit.Location = new System.Drawing.Point(4, 28);
            this.TabEdit.Name = "TabEdit";
            this.TabEdit.Padding = new System.Windows.Forms.Padding(3);
            this.TabEdit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TabEdit.Size = new System.Drawing.Size(1217, 68);
            this.TabEdit.TabIndex = 1;
            this.TabEdit.Text = "Edit";
            // 
            // BtnDelete
            // 
            this.BtnDelete.BackColor = System.Drawing.Color.AliceBlue;
            this.BtnDelete.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDelete.Location = new System.Drawing.Point(103, 3);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(100, 60);
            this.BtnDelete.TabIndex = 5;
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnDuplicate
            // 
            this.BtnDuplicate.BackColor = System.Drawing.Color.AliceBlue;
            this.BtnDuplicate.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnDuplicate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDuplicate.Location = new System.Drawing.Point(3, 3);
            this.BtnDuplicate.Name = "BtnDuplicate";
            this.BtnDuplicate.Size = new System.Drawing.Size(100, 60);
            this.BtnDuplicate.TabIndex = 6;
            this.BtnDuplicate.Text = "Duplicate";
            this.BtnDuplicate.UseVisualStyleBackColor = false;
            this.BtnDuplicate.Click += new System.EventHandler(this.BtnDuplicate_Click);
            // 
            // TabWindow
            // 
            this.TabWindow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TabWindow.Controls.Add(this.BtnVirtualMachine);
            this.TabWindow.Controls.Add(this.BtnFitt);
            this.TabWindow.Controls.Add(this.BtnTerminal);
            this.TabWindow.Controls.Add(this.button2);
            this.TabWindow.Controls.Add(this.BtnSetting);
            this.TabWindow.Controls.Add(this.BtnShowData);
            this.TabWindow.Controls.Add(this.button1);
            this.TabWindow.Controls.Add(this.BtnDiagram);
            this.TabWindow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.TabWindow.Location = new System.Drawing.Point(4, 28);
            this.TabWindow.Name = "TabWindow";
            this.TabWindow.Padding = new System.Windows.Forms.Padding(3);
            this.TabWindow.Size = new System.Drawing.Size(1217, 68);
            this.TabWindow.TabIndex = 2;
            this.TabWindow.Text = "Window";
            this.TabWindow.UseVisualStyleBackColor = true;
            // 
            // BtnVirtualMachine
            // 
            this.BtnVirtualMachine.BackColor = System.Drawing.Color.AliceBlue;
            this.BtnVirtualMachine.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnVirtualMachine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnVirtualMachine.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.BtnVirtualMachine.Location = new System.Drawing.Point(703, 3);
            this.BtnVirtualMachine.Name = "BtnVirtualMachine";
            this.BtnVirtualMachine.Size = new System.Drawing.Size(100, 60);
            this.BtnVirtualMachine.TabIndex = 2;
            this.BtnVirtualMachine.Text = "Virtual Machine";
            this.BtnVirtualMachine.UseVisualStyleBackColor = false;
            this.BtnVirtualMachine.Visible = false;
            this.BtnVirtualMachine.Click += new System.EventHandler(this.BtnVirtualMachine_Click);
            // 
            // BtnFitt
            // 
            this.BtnFitt.BackColor = System.Drawing.Color.AliceBlue;
            this.BtnFitt.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnFitt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFitt.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtnFitt.Location = new System.Drawing.Point(603, 3);
            this.BtnFitt.Name = "BtnFitt";
            this.BtnFitt.Size = new System.Drawing.Size(100, 60);
            this.BtnFitt.TabIndex = 3;
            this.BtnFitt.Text = "Fitting";
            this.BtnFitt.UseVisualStyleBackColor = false;
            this.BtnFitt.Visible = false;
            this.BtnFitt.Click += new System.EventHandler(this.BtnFitt_Click);
            // 
            // BtnTerminal
            // 
            this.BtnTerminal.BackColor = System.Drawing.Color.AliceBlue;
            this.BtnTerminal.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnTerminal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnTerminal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtnTerminal.Location = new System.Drawing.Point(503, 3);
            this.BtnTerminal.Name = "BtnTerminal";
            this.BtnTerminal.Size = new System.Drawing.Size(100, 60);
            this.BtnTerminal.TabIndex = 8;
            this.BtnTerminal.Text = "Terminal";
            this.BtnTerminal.UseVisualStyleBackColor = false;
            this.BtnTerminal.Visible = false;
            this.BtnTerminal.Click += new System.EventHandler(this.BtnTerminal_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.AliceBlue;
            this.button2.Dock = System.Windows.Forms.DockStyle.Left;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.Location = new System.Drawing.Point(403, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 60);
            this.button2.TabIndex = 7;
            this.button2.Text = "Scope 2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // BtnSetting
            // 
            this.BtnSetting.BackColor = System.Drawing.Color.AliceBlue;
            this.BtnSetting.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnSetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSetting.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtnSetting.Location = new System.Drawing.Point(303, 3);
            this.BtnSetting.Name = "BtnSetting";
            this.BtnSetting.Size = new System.Drawing.Size(100, 60);
            this.BtnSetting.TabIndex = 5;
            this.BtnSetting.Text = "Settings";
            this.BtnSetting.UseVisualStyleBackColor = false;
            this.BtnSetting.Visible = false;
            this.BtnSetting.Click += new System.EventHandler(this.BtnSetting_Click);
            // 
            // BtnShowData
            // 
            this.BtnShowData.BackColor = System.Drawing.Color.AliceBlue;
            this.BtnShowData.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnShowData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShowData.Location = new System.Drawing.Point(203, 3);
            this.BtnShowData.Name = "BtnShowData";
            this.BtnShowData.Size = new System.Drawing.Size(100, 60);
            this.BtnShowData.TabIndex = 4;
            this.BtnShowData.Text = "Show Data";
            this.BtnShowData.UseVisualStyleBackColor = false;
            this.BtnShowData.Click += new System.EventHandler(this.BtnShowData_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.AliceBlue;
            this.button1.Dock = System.Windows.Forms.DockStyle.Left;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(103, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 60);
            this.button1.TabIndex = 6;
            this.button1.Text = "Scope";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BtnDiagram
            // 
            this.BtnDiagram.BackColor = System.Drawing.Color.AliceBlue;
            this.BtnDiagram.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnDiagram.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDiagram.Location = new System.Drawing.Point(3, 3);
            this.BtnDiagram.Name = "BtnDiagram";
            this.BtnDiagram.Size = new System.Drawing.Size(100, 60);
            this.BtnDiagram.TabIndex = 0;
            this.BtnDiagram.Text = "Diagram";
            this.BtnDiagram.UseVisualStyleBackColor = false;
            this.BtnDiagram.Click += new System.EventHandler(this.BtnDiagram_Click);
            // 
            // TabTools
            // 
            this.TabTools.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TabTools.Controls.Add(this.button_clm);
            this.TabTools.Controls.Add(this.button_earth);
            this.TabTools.Controls.Add(this.button_notch);
            this.TabTools.Controls.Add(this.button11);
            this.TabTools.Controls.Add(this.BtnFindOCP);
            this.TabTools.Controls.Add(this.splitter2);
            this.TabTools.Controls.Add(this.groupBox15);
            this.TabTools.Controls.Add(this.splitter1);
            this.TabTools.Controls.Add(this.DummyOnBtn);
            this.TabTools.Controls.Add(this.SampleOnBtn);
            this.TabTools.Controls.Add(this.splitter3);
            this.TabTools.Controls.Add(this.BtnCreateSession);
            this.TabTools.Controls.Add(this.BtnPort);
            this.TabTools.Location = new System.Drawing.Point(4, 28);
            this.TabTools.Name = "TabTools";
            this.TabTools.Padding = new System.Windows.Forms.Padding(3);
            this.TabTools.Size = new System.Drawing.Size(1217, 68);
            this.TabTools.TabIndex = 4;
            this.TabTools.Text = "Measurement";
            this.TabTools.UseVisualStyleBackColor = true;
            // 
            // button_clm
            // 
            this.button_clm.Dock = System.Windows.Forms.DockStyle.Left;
            this.button_clm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button_clm.Location = new System.Drawing.Point(1049, 3);
            this.button_clm.Margin = new System.Windows.Forms.Padding(2);
            this.button_clm.Name = "button_clm";
            this.button_clm.Size = new System.Drawing.Size(100, 60);
            this.button_clm.TabIndex = 19;
            this.button_clm.Text = "Current Limit OFF";
            this.button_clm.UseVisualStyleBackColor = true;
            this.button_clm.Click += new System.EventHandler(this.button12_Click);
            // 
            // button_earth
            // 
            this.button_earth.Dock = System.Windows.Forms.DockStyle.Left;
            this.button_earth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button_earth.Location = new System.Drawing.Point(949, 3);
            this.button_earth.Margin = new System.Windows.Forms.Padding(2);
            this.button_earth.Name = "button_earth";
            this.button_earth.Size = new System.Drawing.Size(100, 60);
            this.button_earth.TabIndex = 14;
            this.button_earth.Text = "Floated Ground";
            this.button_earth.UseVisualStyleBackColor = true;
            this.button_earth.Click += new System.EventHandler(this.button_earth_Click);
            // 
            // button_notch
            // 
            this.button_notch.Dock = System.Windows.Forms.DockStyle.Left;
            this.button_notch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button_notch.Location = new System.Drawing.Point(849, 3);
            this.button_notch.Margin = new System.Windows.Forms.Padding(2);
            this.button_notch.Name = "button_notch";
            this.button_notch.Size = new System.Drawing.Size(100, 60);
            this.button_notch.TabIndex = 13;
            this.button_notch.Text = "50Hz Notch Filter";
            this.button_notch.UseVisualStyleBackColor = true;
            this.button_notch.Click += new System.EventHandler(this.button_notch_Click);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.Transparent;
            this.button11.Dock = System.Windows.Forms.DockStyle.Left;
            this.button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button11.Location = new System.Drawing.Point(749, 3);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(100, 60);
            this.button11.TabIndex = 12;
            this.button11.Text = "Noise Scope";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button11_Click_1);
            // 
            // BtnFindOCP
            // 
            this.BtnFindOCP.BackColor = System.Drawing.Color.SeaShell;
            this.BtnFindOCP.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnFindOCP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFindOCP.ForeColor = System.Drawing.Color.Black;
            this.BtnFindOCP.Location = new System.Drawing.Point(649, 3);
            this.BtnFindOCP.Name = "BtnFindOCP";
            this.BtnFindOCP.Size = new System.Drawing.Size(100, 60);
            this.BtnFindOCP.TabIndex = 8;
            this.BtnFindOCP.Text = "Find OCP";
            this.BtnFindOCP.UseVisualStyleBackColor = false;
            this.BtnFindOCP.Click += new System.EventHandler(this.BtnFindOCP_Click);
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(646, 3);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 60);
            this.splitter2.TabIndex = 17;
            this.splitter2.TabStop = false;
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.BtnRunS);
            this.groupBox15.Controls.Add(this.BtnRun);
            this.groupBox15.Controls.Add(this.BtnPauseContinue);
            this.groupBox15.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox15.Location = new System.Drawing.Point(409, 3);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(237, 60);
            this.groupBox15.TabIndex = 11;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Run";
            // 
            // BtnRunS
            // 
            this.BtnRunS.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BtnRunS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRunS.Location = new System.Drawing.Point(9, 17);
            this.BtnRunS.Name = "BtnRunS";
            this.BtnRunS.Size = new System.Drawing.Size(70, 31);
            this.BtnRunS.TabIndex = 5;
            this.BtnRunS.Text = "Start";
            this.BtnRunS.UseVisualStyleBackColor = false;
            this.BtnRunS.Click += new System.EventHandler(this.BtnRunS_Click);
            // 
            // BtnRun
            // 
            this.BtnRun.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BtnRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRun.Location = new System.Drawing.Point(85, 17);
            this.BtnRun.Name = "BtnRun";
            this.BtnRun.Size = new System.Drawing.Size(70, 31);
            this.BtnRun.TabIndex = 3;
            this.BtnRun.Text = "Start All";
            this.BtnRun.UseVisualStyleBackColor = false;
            this.BtnRun.Click += new System.EventHandler(this.BtnRun_Click);
            // 
            // BtnPauseContinue
            // 
            this.BtnPauseContinue.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BtnPauseContinue.Enabled = false;
            this.BtnPauseContinue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPauseContinue.Location = new System.Drawing.Point(160, 17);
            this.BtnPauseContinue.Name = "BtnPauseContinue";
            this.BtnPauseContinue.Size = new System.Drawing.Size(70, 31);
            this.BtnPauseContinue.TabIndex = 4;
            this.BtnPauseContinue.Text = "Pause";
            this.BtnPauseContinue.UseVisualStyleBackColor = false;
            this.BtnPauseContinue.Click += new System.EventHandler(this.BtnPauseContinue_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(406, 3);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 60);
            this.splitter1.TabIndex = 16;
            this.splitter1.TabStop = false;
            // 
            // DummyOnBtn
            // 
            this.DummyOnBtn.BackColor = System.Drawing.Color.Azure;
            this.DummyOnBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.DummyOnBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DummyOnBtn.ForeColor = System.Drawing.Color.Red;
            this.DummyOnBtn.Location = new System.Drawing.Point(306, 3);
            this.DummyOnBtn.Name = "DummyOnBtn";
            this.DummyOnBtn.Size = new System.Drawing.Size(100, 60);
            this.DummyOnBtn.TabIndex = 7;
            this.DummyOnBtn.Text = "Dummy On";
            this.DummyOnBtn.UseVisualStyleBackColor = false;
            this.DummyOnBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // SampleOnBtn
            // 
            this.SampleOnBtn.BackColor = System.Drawing.Color.Azure;
            this.SampleOnBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.SampleOnBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SampleOnBtn.ForeColor = System.Drawing.Color.Red;
            this.SampleOnBtn.Location = new System.Drawing.Point(206, 3);
            this.SampleOnBtn.Name = "SampleOnBtn";
            this.SampleOnBtn.Size = new System.Drawing.Size(100, 60);
            this.SampleOnBtn.TabIndex = 6;
            this.SampleOnBtn.Text = "Probe On";
            this.SampleOnBtn.UseVisualStyleBackColor = false;
            this.SampleOnBtn.Click += new System.EventHandler(this.SampleOnBtn_Click);
            // 
            // splitter3
            // 
            this.splitter3.Location = new System.Drawing.Point(203, 3);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(3, 60);
            this.splitter3.TabIndex = 18;
            this.splitter3.TabStop = false;
            // 
            // BtnCreateSession
            // 
            this.BtnCreateSession.BackColor = System.Drawing.Color.Lavender;
            this.BtnCreateSession.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnCreateSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCreateSession.ForeColor = System.Drawing.Color.Black;
            this.BtnCreateSession.Location = new System.Drawing.Point(103, 3);
            this.BtnCreateSession.Name = "BtnCreateSession";
            this.BtnCreateSession.Size = new System.Drawing.Size(100, 60);
            this.BtnCreateSession.TabIndex = 2;
            this.BtnCreateSession.Text = "New Session";
            this.BtnCreateSession.UseVisualStyleBackColor = false;
            this.BtnCreateSession.Click += new System.EventHandler(this.BtnCreateSession_Click);
            // 
            // BtnPort
            // 
            this.BtnPort.BackColor = System.Drawing.Color.AliceBlue;
            this.BtnPort.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPort.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnPort.Location = new System.Drawing.Point(3, 3);
            this.BtnPort.Name = "BtnPort";
            this.BtnPort.Size = new System.Drawing.Size(100, 60);
            this.BtnPort.TabIndex = 1;
            this.BtnPort.Text = "Connect";
            this.BtnPort.UseVisualStyleBackColor = false;
            this.BtnPort.Click += new System.EventHandler(this.BtnPort_Click);
            // 
            // TabOffset
            // 
            this.TabOffset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TabOffset.Controls.Add(this.BtnRecoverSettings);
            this.TabOffset.Controls.Add(this.BtnBackupSettings);
            this.TabOffset.Controls.Add(this.BtnSaveOffsetSettings);
            this.TabOffset.Controls.Add(this.button8);
            this.TabOffset.Controls.Add(this.button9);
            this.TabOffset.Controls.Add(this.BtnOffsetRemoval);
            this.TabOffset.Location = new System.Drawing.Point(4, 28);
            this.TabOffset.Name = "TabOffset";
            this.TabOffset.Padding = new System.Windows.Forms.Padding(3);
            this.TabOffset.Size = new System.Drawing.Size(1217, 68);
            this.TabOffset.TabIndex = 6;
            this.TabOffset.Text = "Offset";
            this.TabOffset.UseVisualStyleBackColor = true;
            // 
            // BtnRecoverSettings
            // 
            this.BtnRecoverSettings.BackColor = System.Drawing.Color.SeaShell;
            this.BtnRecoverSettings.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnRecoverSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRecoverSettings.ForeColor = System.Drawing.Color.Black;
            this.BtnRecoverSettings.Location = new System.Drawing.Point(753, 3);
            this.BtnRecoverSettings.Name = "BtnRecoverSettings";
            this.BtnRecoverSettings.Size = new System.Drawing.Size(150, 60);
            this.BtnRecoverSettings.TabIndex = 15;
            this.BtnRecoverSettings.Text = "Recover Settings";
            this.BtnRecoverSettings.UseVisualStyleBackColor = false;
            this.BtnRecoverSettings.Click += new System.EventHandler(this.BtnRecoverSettings_Click);
            // 
            // BtnBackupSettings
            // 
            this.BtnBackupSettings.BackColor = System.Drawing.Color.SeaShell;
            this.BtnBackupSettings.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnBackupSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBackupSettings.ForeColor = System.Drawing.Color.Black;
            this.BtnBackupSettings.Location = new System.Drawing.Point(603, 3);
            this.BtnBackupSettings.Name = "BtnBackupSettings";
            this.BtnBackupSettings.Size = new System.Drawing.Size(150, 60);
            this.BtnBackupSettings.TabIndex = 14;
            this.BtnBackupSettings.Text = "Backup Settings";
            this.BtnBackupSettings.UseVisualStyleBackColor = false;
            this.BtnBackupSettings.Click += new System.EventHandler(this.BtnBackupSettings_Click);
            // 
            // BtnSaveOffsetSettings
            // 
            this.BtnSaveOffsetSettings.BackColor = System.Drawing.Color.SeaShell;
            this.BtnSaveOffsetSettings.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnSaveOffsetSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSaveOffsetSettings.ForeColor = System.Drawing.Color.Black;
            this.BtnSaveOffsetSettings.Location = new System.Drawing.Point(453, 3);
            this.BtnSaveOffsetSettings.Name = "BtnSaveOffsetSettings";
            this.BtnSaveOffsetSettings.Size = new System.Drawing.Size(150, 60);
            this.BtnSaveOffsetSettings.TabIndex = 12;
            this.BtnSaveOffsetSettings.Text = "Save Offset Settings";
            this.BtnSaveOffsetSettings.UseVisualStyleBackColor = false;
            this.BtnSaveOffsetSettings.Click += new System.EventHandler(this.BtnSaveOffsetSettings_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.SeaShell;
            this.button8.Dock = System.Windows.Forms.DockStyle.Left;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.Color.Black;
            this.button8.Location = new System.Drawing.Point(303, 3);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(150, 60);
            this.button8.TabIndex = 13;
            this.button8.Text = "Voltage Offset Removal";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.BtnVoltageOffsetRemoval_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.SeaShell;
            this.button9.Dock = System.Windows.Forms.DockStyle.Left;
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.Color.Black;
            this.button9.Location = new System.Drawing.Point(153, 3);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(150, 60);
            this.button9.TabIndex = 16;
            this.button9.Text = "Galvanostat Offset Removal";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click_1);
            // 
            // BtnOffsetRemoval
            // 
            this.BtnOffsetRemoval.BackColor = System.Drawing.Color.SeaShell;
            this.BtnOffsetRemoval.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnOffsetRemoval.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOffsetRemoval.ForeColor = System.Drawing.Color.Black;
            this.BtnOffsetRemoval.Location = new System.Drawing.Point(3, 3);
            this.BtnOffsetRemoval.Name = "BtnOffsetRemoval";
            this.BtnOffsetRemoval.Size = new System.Drawing.Size(150, 60);
            this.BtnOffsetRemoval.TabIndex = 9;
            this.BtnOffsetRemoval.Text = "Offset Removal";
            this.BtnOffsetRemoval.UseVisualStyleBackColor = false;
            this.BtnOffsetRemoval.Click += new System.EventHandler(this.BtnOffsetRemoval_Click);
            // 
            // TabHelp
            // 
            this.TabHelp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TabHelp.Controls.Add(this.button4);
            this.TabHelp.Controls.Add(this.BtnAbout);
            this.TabHelp.Location = new System.Drawing.Point(4, 28);
            this.TabHelp.Name = "TabHelp";
            this.TabHelp.Padding = new System.Windows.Forms.Padding(3);
            this.TabHelp.Size = new System.Drawing.Size(1217, 68);
            this.TabHelp.TabIndex = 3;
            this.TabHelp.Text = "Help";
            this.TabHelp.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.AliceBlue;
            this.button4.Dock = System.Windows.Forms.DockStyle.Left;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(103, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 60);
            this.button4.TabIndex = 4;
            this.button4.Text = "Tutorial";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // BtnAbout
            // 
            this.BtnAbout.BackColor = System.Drawing.Color.AliceBlue;
            this.BtnAbout.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAbout.Location = new System.Drawing.Point(3, 3);
            this.BtnAbout.Name = "BtnAbout";
            this.BtnAbout.Size = new System.Drawing.Size(100, 60);
            this.BtnAbout.TabIndex = 3;
            this.BtnAbout.Text = "About";
            this.BtnAbout.UseVisualStyleBackColor = false;
            this.BtnAbout.Click += new System.EventHandler(this.BtnAbout_Click);
            // 
            // TabLogin
            // 
            this.TabLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TabLogin.Controls.Add(this.labellogedin);
            this.TabLogin.Controls.Add(this.BtnLogout);
            this.TabLogin.Controls.Add(this.label46);
            this.TabLogin.Controls.Add(this.TBLogin);
            this.TabLogin.Controls.Add(this.label45);
            this.TabLogin.Location = new System.Drawing.Point(4, 28);
            this.TabLogin.Name = "TabLogin";
            this.TabLogin.Padding = new System.Windows.Forms.Padding(3);
            this.TabLogin.Size = new System.Drawing.Size(1217, 68);
            this.TabLogin.TabIndex = 5;
            this.TabLogin.Text = "Log in";
            this.TabLogin.UseVisualStyleBackColor = true;
            // 
            // labellogedin
            // 
            this.labellogedin.AutoSize = true;
            this.labellogedin.ForeColor = System.Drawing.Color.LimeGreen;
            this.labellogedin.Location = new System.Drawing.Point(352, 26);
            this.labellogedin.Name = "labellogedin";
            this.labellogedin.Size = new System.Drawing.Size(120, 13);
            this.labellogedin.TabIndex = 6;
            this.labellogedin.Text = "loged in as administrator";
            this.labellogedin.Visible = false;
            // 
            // BtnLogout
            // 
            this.BtnLogout.Enabled = false;
            this.BtnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLogout.Location = new System.Drawing.Point(702, 17);
            this.BtnLogout.Name = "BtnLogout";
            this.BtnLogout.Size = new System.Drawing.Size(122, 30);
            this.BtnLogout.TabIndex = 5;
            this.BtnLogout.Text = "Log Out";
            this.BtnLogout.UseVisualStyleBackColor = true;
            this.BtnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(500, 26);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(196, 13);
            this.label46.TabIndex = 4;
            this.label46.Text = "Press Log out to close admin features ...";
            // 
            // TBLogin
            // 
            this.TBLogin.Location = new System.Drawing.Point(220, 23);
            this.TBLogin.Name = "TBLogin";
            this.TBLogin.PasswordChar = '*';
            this.TBLogin.Size = new System.Drawing.Size(126, 20);
            this.TBLogin.TabIndex = 3;
            this.TBLogin.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(11, 26);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(203, 13);
            this.label45.TabIndex = 2;
            this.label45.Text = "Enter the password to open all features ...";
            // 
            // StatusPanel
            // 
            this.StatusPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StatusPanel.Controls.Add(this.label_per);
            this.StatusPanel.Controls.Add(this.webBrowser1);
            this.StatusPanel.Controls.Add(this.LabelIwar);
            this.StatusPanel.Controls.Add(this.LabelVwar);
            this.StatusPanel.Controls.Add(this.ProbWarningLabel);
            this.StatusPanel.Controls.Add(this.PBAllSessions);
            this.StatusPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.StatusPanel.Location = new System.Drawing.Point(0, 535);
            this.StatusPanel.Name = "StatusPanel";
            this.StatusPanel.Size = new System.Drawing.Size(1028, 70);
            this.StatusPanel.TabIndex = 1;
            // 
            // label_per
            // 
            this.label_per.AutoSize = true;
            this.label_per.Location = new System.Drawing.Point(414, 7);
            this.label_per.Name = "label_per";
            this.label_per.Size = new System.Drawing.Size(28, 13);
            this.label_per.TabIndex = 33;
            this.label_per.Text = "-------";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(1078, 6);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(23, 20);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.Visible = false;
            // 
            // LabelIwar
            // 
            this.LabelIwar.AutoSize = true;
            this.LabelIwar.ForeColor = System.Drawing.Color.Red;
            this.LabelIwar.Location = new System.Drawing.Point(129, 51);
            this.LabelIwar.Name = "LabelIwar";
            this.LabelIwar.Size = new System.Drawing.Size(194, 13);
            this.LabelIwar.TabIndex = 3;
            this.LabelIwar.Text = "Warning: Weak Signal detected in I(t)...";
            this.LabelIwar.Visible = false;
            // 
            // LabelVwar
            // 
            this.LabelVwar.AutoSize = true;
            this.LabelVwar.ForeColor = System.Drawing.Color.Red;
            this.LabelVwar.Location = new System.Drawing.Point(129, 36);
            this.LabelVwar.Name = "LabelVwar";
            this.LabelVwar.Size = new System.Drawing.Size(198, 13);
            this.LabelVwar.TabIndex = 2;
            this.LabelVwar.Text = "Warning: Weak Signal detected in V(t)...";
            this.LabelVwar.Visible = false;
            // 
            // ProbWarningLabel
            // 
            this.ProbWarningLabel.AutoSize = true;
            this.ProbWarningLabel.ForeColor = System.Drawing.Color.Red;
            this.ProbWarningLabel.Location = new System.Drawing.Point(129, 22);
            this.ProbWarningLabel.Name = "ProbWarningLabel";
            this.ProbWarningLabel.Size = new System.Drawing.Size(430, 13);
            this.ProbWarningLabel.TabIndex = 1;
            this.ProbWarningLabel.Text = "Warning: Probe is not connected to Sample. Maybe you need to turn on Tools-> Prob" +
    "e on";
            this.ProbWarningLabel.Visible = false;
            // 
            // PBAllSessions
            // 
            this.PBAllSessions.Location = new System.Drawing.Point(130, 2);
            this.PBAllSessions.Name = "PBAllSessions";
            this.PBAllSessions.Size = new System.Drawing.Size(267, 18);
            this.PBAllSessions.Step = 1;
            this.PBAllSessions.TabIndex = 0;
            // 
            // Panel101
            // 
            this.Panel101.Controls.Add(this.PanelProperties);
            this.Panel101.Controls.Add(this.Prop);
            this.Panel101.Dock = System.Windows.Forms.DockStyle.Right;
            this.Panel101.Location = new System.Drawing.Point(593, 100);
            this.Panel101.Name = "Panel101";
            this.Panel101.Size = new System.Drawing.Size(435, 435);
            this.Panel101.TabIndex = 3;
            // 
            // PanelProperties
            // 
            this.PanelProperties.AutoScroll = true;
            this.PanelProperties.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanelProperties.Controls.Add(this.GBPostprocessing);
            this.PanelProperties.Controls.Add(this.GBPulse);
            this.PanelProperties.Controls.Add(this.label4);
            this.PanelProperties.Controls.Add(this.CBMode);
            this.PanelProperties.Controls.Add(this.ChBActive);
            this.PanelProperties.Controls.Add(this.TBSsnName);
            this.PanelProperties.Controls.Add(this.label2);
            this.PanelProperties.Controls.Add(this.GBEIS);
            this.PanelProperties.Controls.Add(this.GBIV);
            this.PanelProperties.Controls.Add(this.GBPreprocessing);
            this.PanelProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelProperties.Location = new System.Drawing.Point(0, 22);
            this.PanelProperties.Name = "PanelProperties";
            this.PanelProperties.Size = new System.Drawing.Size(435, 413);
            this.PanelProperties.TabIndex = 1;
            this.PanelProperties.Visible = false;
            this.PanelProperties.MouseEnter += new System.EventHandler(this.PanelProperties_MouseEnter);
            // 
            // GBPostprocessing
            // 
            this.GBPostprocessing.Controls.Add(this.ChBPostProcProbOff);
            this.GBPostprocessing.Controls.Add(this.label65);
            this.GBPostprocessing.Controls.Add(this.TBIdealVoltage);
            this.GBPostprocessing.Controls.Add(this.groupBox13);
            this.GBPostprocessing.Controls.Add(this.GBExport);
            this.GBPostprocessing.Location = new System.Drawing.Point(8, 1894);
            this.GBPostprocessing.Name = "GBPostprocessing";
            this.GBPostprocessing.Size = new System.Drawing.Size(399, 235);
            this.GBPostprocessing.TabIndex = 31;
            this.GBPostprocessing.TabStop = false;
            this.GBPostprocessing.Text = "Postprocessing";
            // 
            // ChBPostProcProbOff
            // 
            this.ChBPostProcProbOff.AutoSize = true;
            this.ChBPostProcProbOff.Location = new System.Drawing.Point(311, 26);
            this.ChBPostProcProbOff.Margin = new System.Windows.Forms.Padding(2);
            this.ChBPostProcProbOff.Name = "ChBPostProcProbOff";
            this.ChBPostProcProbOff.Size = new System.Drawing.Size(65, 17);
            this.ChBPostProcProbOff.TabIndex = 10;
            this.ChBPostProcProbOff.Text = "Prob Off";
            this.ChBPostProcProbOff.UseVisualStyleBackColor = true;
            this.ChBPostProcProbOff.CheckedChanged += new System.EventHandler(this.ChBPostProcProbOff_CheckedChanged);
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(13, 27);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(72, 13);
            this.label65.TabIndex = 9;
            this.label65.Text = "Ideal Voltage:";
            // 
            // TBIdealVoltage
            // 
            this.TBIdealVoltage.Location = new System.Drawing.Point(86, 25);
            this.TBIdealVoltage.Name = "TBIdealVoltage";
            this.TBIdealVoltage.Size = new System.Drawing.Size(66, 20);
            this.TBIdealVoltage.TabIndex = 8;
            this.TBIdealVoltage.Validated += new System.EventHandler(this.TBIdealVoltage_Validated);
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.label53);
            this.groupBox13.Controls.Add(this.button5);
            this.groupBox13.Controls.Add(this.maskedTextBox2);
            this.groupBox13.Controls.Add(this.label54);
            this.groupBox13.Controls.Add(this.checkBox1);
            this.groupBox13.Enabled = false;
            this.groupBox13.Location = new System.Drawing.Point(6, 140);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(387, 88);
            this.groupBox13.TabIndex = 7;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Export Diagrams";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.ForeColor = System.Drawing.Color.Red;
            this.label53.Location = new System.Drawing.Point(238, 29);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(129, 13);
            this.label53.TabIndex = 27;
            this.label53.Text = "Warning: Path is not set...";
            this.label53.Visible = false;
            // 
            // button5
            // 
            this.button5.Enabled = false;
            this.button5.Location = new System.Drawing.Point(357, 56);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(24, 21);
            this.button5.TabIndex = 26;
            this.button5.Text = "...";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // maskedTextBox2
            // 
            this.maskedTextBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.maskedTextBox2.Enabled = false;
            this.maskedTextBox2.Location = new System.Drawing.Point(32, 54);
            this.maskedTextBox2.Name = "maskedTextBox2";
            this.maskedTextBox2.ReadOnly = true;
            this.maskedTextBox2.Size = new System.Drawing.Size(317, 20);
            this.maskedTextBox2.TabIndex = 25;
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(3, 56);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(32, 13);
            this.label54.TabIndex = 24;
            this.label54.Text = "Path:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(6, 28);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(221, 17);
            this.checkBox1.TabIndex = 23;
            this.checkBox1.Text = "Export diagrams at the end of this session";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // GBExport
            // 
            this.GBExport.Controls.Add(this.ExpWarningLable);
            this.GBExport.Controls.Add(this.BtnSsnExpLocation);
            this.GBExport.Controls.Add(this.maskedTextBox1);
            this.GBExport.Controls.Add(this.label15);
            this.GBExport.Controls.Add(this.ChBExport);
            this.GBExport.Location = new System.Drawing.Point(6, 54);
            this.GBExport.Name = "GBExport";
            this.GBExport.Size = new System.Drawing.Size(387, 82);
            this.GBExport.TabIndex = 6;
            this.GBExport.TabStop = false;
            this.GBExport.Text = "Export Data";
            // 
            // ExpWarningLable
            // 
            this.ExpWarningLable.AutoSize = true;
            this.ExpWarningLable.ForeColor = System.Drawing.Color.Red;
            this.ExpWarningLable.Location = new System.Drawing.Point(238, 27);
            this.ExpWarningLable.Name = "ExpWarningLable";
            this.ExpWarningLable.Size = new System.Drawing.Size(129, 13);
            this.ExpWarningLable.TabIndex = 27;
            this.ExpWarningLable.Text = "Warning: Path is not set...";
            this.ExpWarningLable.Visible = false;
            // 
            // BtnSsnExpLocation
            // 
            this.BtnSsnExpLocation.Enabled = false;
            this.BtnSsnExpLocation.Location = new System.Drawing.Point(357, 52);
            this.BtnSsnExpLocation.Name = "BtnSsnExpLocation";
            this.BtnSsnExpLocation.Size = new System.Drawing.Size(24, 21);
            this.BtnSsnExpLocation.TabIndex = 26;
            this.BtnSsnExpLocation.Text = "...";
            this.BtnSsnExpLocation.UseVisualStyleBackColor = true;
            this.BtnSsnExpLocation.Click += new System.EventHandler(this.BtnSsnExpLocation_Click);
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.maskedTextBox1.Enabled = false;
            this.maskedTextBox1.Location = new System.Drawing.Point(32, 54);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.ReadOnly = true;
            this.maskedTextBox1.Size = new System.Drawing.Size(317, 20);
            this.maskedTextBox1.TabIndex = 25;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 56);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 13);
            this.label15.TabIndex = 24;
            this.label15.Text = "Path:";
            // 
            // ChBExport
            // 
            this.ChBExport.AutoSize = true;
            this.ChBExport.Location = new System.Drawing.Point(6, 26);
            this.ChBExport.Name = "ChBExport";
            this.ChBExport.Size = new System.Drawing.Size(200, 17);
            this.ChBExport.TabIndex = 23;
            this.ChBExport.Text = "Export data at the end of this session";
            this.ChBExport.UseVisualStyleBackColor = true;
            this.ChBExport.CheckedChanged += new System.EventHandler(this.ChBExport_CheckedChanged);
            // 
            // GBPulse
            // 
            this.GBPulse.Controls.Add(this.WarnLabel);
            this.GBPulse.Controls.Add(this.groupBox18);
            this.GBPulse.Controls.Add(this.groupBox16);
            this.GBPulse.Controls.Add(this.groupBox17);
            this.GBPulse.Controls.Add(this.chart1);
            this.GBPulse.Controls.Add(this.button10);
            this.GBPulse.Controls.Add(this.groupBox2);
            this.GBPulse.Controls.Add(this.groupBox3);
            this.GBPulse.Location = new System.Drawing.Point(8, 1414);
            this.GBPulse.Name = "GBPulse";
            this.GBPulse.Size = new System.Drawing.Size(399, 474);
            this.GBPulse.TabIndex = 10;
            this.GBPulse.TabStop = false;
            this.GBPulse.Text = "Pulse";
            // 
            // WarnLabel
            // 
            this.WarnLabel.AutoSize = true;
            this.WarnLabel.ForeColor = System.Drawing.Color.Red;
            this.WarnLabel.Location = new System.Drawing.Point(125, 141);
            this.WarnLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.WarnLabel.Name = "WarnLabel";
            this.WarnLabel.Size = new System.Drawing.Size(138, 13);
            this.WarnLabel.TabIndex = 32;
            this.WarnLabel.Text = "Warning: Over load in pulse";
            this.WarnLabel.Visible = false;
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.RB_Differential);
            this.groupBox18.Controls.Add(this.RB_Leading);
            this.groupBox18.Controls.Add(this.RB_Trailing);
            this.groupBox18.Location = new System.Drawing.Point(6, 183);
            this.groupBox18.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox18.Size = new System.Drawing.Size(387, 52);
            this.groupBox18.TabIndex = 31;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "Measurment";
            // 
            // RB_Differential
            // 
            this.RB_Differential.AutoSize = true;
            this.RB_Differential.Location = new System.Drawing.Point(216, 24);
            this.RB_Differential.Margin = new System.Windows.Forms.Padding(2);
            this.RB_Differential.Name = "RB_Differential";
            this.RB_Differential.Size = new System.Drawing.Size(75, 17);
            this.RB_Differential.TabIndex = 20;
            this.RB_Differential.Text = "Differential";
            this.RB_Differential.UseVisualStyleBackColor = true;
            this.RB_Differential.CheckedChanged += new System.EventHandler(this.RB_Differential_CheckedChanged);
            // 
            // RB_Leading
            // 
            this.RB_Leading.AutoSize = true;
            this.RB_Leading.Location = new System.Drawing.Point(106, 24);
            this.RB_Leading.Margin = new System.Windows.Forms.Padding(2);
            this.RB_Leading.Name = "RB_Leading";
            this.RB_Leading.Size = new System.Drawing.Size(82, 17);
            this.RB_Leading.TabIndex = 18;
            this.RB_Leading.Text = "Falling edge";
            this.RB_Leading.UseVisualStyleBackColor = true;
            this.RB_Leading.CheckedChanged += new System.EventHandler(this.RB_Leading_CheckedChanged);
            // 
            // RB_Trailing
            // 
            this.RB_Trailing.AutoSize = true;
            this.RB_Trailing.Checked = true;
            this.RB_Trailing.Location = new System.Drawing.Point(11, 24);
            this.RB_Trailing.Margin = new System.Windows.Forms.Padding(2);
            this.RB_Trailing.Name = "RB_Trailing";
            this.RB_Trailing.Size = new System.Drawing.Size(87, 17);
            this.RB_Trailing.TabIndex = 17;
            this.RB_Trailing.TabStop = true;
            this.RB_Trailing.Text = "Raising edge";
            this.RB_Trailing.UseVisualStyleBackColor = true;
            this.RB_Trailing.CheckedChanged += new System.EventHandler(this.RB_Trailing_CheckedChanged);
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.label47);
            this.groupBox16.Controls.Add(this.label67);
            this.groupBox16.Controls.Add(this.CBPulseCurrentRangeMode);
            this.groupBox16.Controls.Add(this.CBPulseImlp);
            this.groupBox16.Location = new System.Drawing.Point(6, 331);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(387, 76);
            this.groupBox16.TabIndex = 30;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Current Range:";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(44, 49);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(65, 13);
            this.label47.TabIndex = 22;
            this.label47.Text = "Fine Range:";
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(29, 19);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(78, 13);
            this.label67.TabIndex = 24;
            this.label67.Text = "Course Range:";
            // 
            // CBPulseCurrentRangeMode
            // 
            this.CBPulseCurrentRangeMode.FormattingEnabled = true;
            this.CBPulseCurrentRangeMode.Items.AddRange(new object[] {
            "1 ampere",
            "100 miliampere",
            "10 miliampere",
            "1 miliampere",
            "100 microampere",
            "10 microampere",
            "1 micrommpere",
            "100 nanoampere"});
            this.CBPulseCurrentRangeMode.Location = new System.Drawing.Point(116, 16);
            this.CBPulseCurrentRangeMode.Name = "CBPulseCurrentRangeMode";
            this.CBPulseCurrentRangeMode.Size = new System.Drawing.Size(126, 21);
            this.CBPulseCurrentRangeMode.TabIndex = 8;
            this.CBPulseCurrentRangeMode.SelectedIndexChanged += new System.EventHandler(this.CBPulseCurrentRangeMode_SelectedIndexChanged);
            // 
            // CBPulseImlp
            // 
            this.CBPulseImlp.FormattingEnabled = true;
            this.CBPulseImlp.Items.AddRange(new object[] {
            "1",
            "2",
            "4",
            "8",
            "16",
            "32",
            "64"});
            this.CBPulseImlp.Location = new System.Drawing.Point(116, 46);
            this.CBPulseImlp.Name = "CBPulseImlp";
            this.CBPulseImlp.Size = new System.Drawing.Size(126, 21);
            this.CBPulseImlp.TabIndex = 23;
            this.CBPulseImlp.SelectedIndexChanged += new System.EventHandler(this.CBPulseImlp_SelectedIndexChanged);
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.PlseVFilter);
            this.groupBox17.Controls.Add(this.label78);
            this.groupBox17.Controls.Add(this.label72);
            this.groupBox17.Controls.Add(this.CBPulseVoltageRangeMode);
            this.groupBox17.Controls.Add(this.CBPulseVmlp);
            this.groupBox17.Controls.Add(this.label75);
            this.groupBox17.Location = new System.Drawing.Point(6, 240);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(387, 82);
            this.groupBox17.TabIndex = 29;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Voltage Range:";
            // 
            // PlseVFilter
            // 
            this.PlseVFilter.FormattingEnabled = true;
            this.PlseVFilter.Items.AddRange(new object[] {
            "High speed",
            "Medim",
            "Low speed",
            "Auto"});
            this.PlseVFilter.Location = new System.Drawing.Point(289, 20);
            this.PlseVFilter.Name = "PlseVFilter";
            this.PlseVFilter.Size = new System.Drawing.Size(88, 21);
            this.PlseVFilter.TabIndex = 25;
            this.PlseVFilter.SelectedIndexChanged += new System.EventHandler(this.PlseVFilter_SelectedIndexChanged);
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.Location = new System.Drawing.Point(256, 23);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(32, 13);
            this.label78.TabIndex = 24;
            this.label78.Text = "Filter:";
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Location = new System.Drawing.Point(44, 52);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(65, 13);
            this.label72.TabIndex = 20;
            this.label72.Text = "Fine Range:";
            // 
            // CBPulseVoltageRangeMode
            // 
            this.CBPulseVoltageRangeMode.FormattingEnabled = true;
            this.CBPulseVoltageRangeMode.Items.AddRange(new object[] {
            "[-5 (V) .. 5 (V)]",
            "[-1 (V) .. 1 (V)]"});
            this.CBPulseVoltageRangeMode.Location = new System.Drawing.Point(116, 20);
            this.CBPulseVoltageRangeMode.Name = "CBPulseVoltageRangeMode";
            this.CBPulseVoltageRangeMode.Size = new System.Drawing.Size(126, 21);
            this.CBPulseVoltageRangeMode.TabIndex = 17;
            this.CBPulseVoltageRangeMode.SelectedIndexChanged += new System.EventHandler(this.CBPulseVoltageRangeMode_SelectedIndexChanged);
            // 
            // CBPulseVmlp
            // 
            this.CBPulseVmlp.FormattingEnabled = true;
            this.CBPulseVmlp.Items.AddRange(new object[] {
            "[-10 (V) .. 10 (V)]",
            "[-20 (V) .. 20 (V)]",
            "[-40 (V) .. 40 (V)]",
            "[-80 (V) .. 80 (V)]",
            "[-160 (V) .. 160 (V)]",
            "[-320 (V) .. 320 (V)]",
            "[-640 (V) .. 640 (V)]"});
            this.CBPulseVmlp.Location = new System.Drawing.Point(116, 50);
            this.CBPulseVmlp.Name = "CBPulseVmlp";
            this.CBPulseVmlp.Size = new System.Drawing.Size(126, 21);
            this.CBPulseVmlp.TabIndex = 21;
            this.CBPulseVmlp.SelectedIndexChanged += new System.EventHandler(this.CBPulseVmlp_SelectedIndexChanged);
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Location = new System.Drawing.Point(12, 23);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(100, 13);
            this.label75.TabIndex = 18;
            this.label75.Text = "Set Voltage Range:";
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.SystemColors.Control;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(5, 18);
            this.chart1.Margin = new System.Windows.Forms.Padding(2);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(388, 123);
            this.chart1.TabIndex = 28;
            this.chart1.Text = "chart1";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(107, 158);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(181, 23);
            this.button10.TabIndex = 27;
            this.button10.Text = "Customize Pulse";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TBMSCHACAmpCnst);
            this.groupBox2.Controls.Add(this.TBMSCHACFrqCnst);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(6, 422);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(387, 19);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Constants";
            // 
            // TBMSCHACAmpCnst
            // 
            this.TBMSCHACAmpCnst.Location = new System.Drawing.Point(89, 24);
            this.TBMSCHACAmpCnst.Name = "TBMSCHACAmpCnst";
            this.TBMSCHACAmpCnst.Size = new System.Drawing.Size(65, 20);
            this.TBMSCHACAmpCnst.TabIndex = 2;
            this.TBMSCHACAmpCnst.Validated += new System.EventHandler(this.TBMSCHACAmpCnst_TextChanged);
            // 
            // TBMSCHACFrqCnst
            // 
            this.TBMSCHACFrqCnst.Location = new System.Drawing.Point(273, 24);
            this.TBMSCHACFrqCnst.Name = "TBMSCHACFrqCnst";
            this.TBMSCHACFrqCnst.Size = new System.Drawing.Size(65, 20);
            this.TBMSCHACFrqCnst.TabIndex = 3;
            this.TBMSCHACFrqCnst.Validated += new System.EventHandler(this.TBMSCHACFrqCnst_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "AC Amplitoide:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(192, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "AC Frequency:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.TBMSCHDCVStp);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.TBMSCHDCVTo);
            this.groupBox3.Controls.Add(this.TBMSCHDCVFrm);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(6, 444);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(387, 16);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "DC Voltage:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(121, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "To:";
            // 
            // TBMSCHDCVStp
            // 
            this.TBMSCHDCVStp.Location = new System.Drawing.Point(272, 26);
            this.TBMSCHDCVStp.Name = "TBMSCHDCVStp";
            this.TBMSCHDCVStp.Size = new System.Drawing.Size(65, 20);
            this.TBMSCHDCVStp.TabIndex = 18;
            this.TBMSCHDCVStp.Validated += new System.EventHandler(this.TBMSCHDCVStp_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(234, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Step:";
            // 
            // TBMSCHDCVTo
            // 
            this.TBMSCHDCVTo.Location = new System.Drawing.Point(150, 27);
            this.TBMSCHDCVTo.Name = "TBMSCHDCVTo";
            this.TBMSCHDCVTo.Size = new System.Drawing.Size(65, 20);
            this.TBMSCHDCVTo.TabIndex = 16;
            this.TBMSCHDCVTo.Validated += new System.EventHandler(this.TBMSCHDCVTo_TextChanged);
            // 
            // TBMSCHDCVFrm
            // 
            this.TBMSCHDCVFrm.Location = new System.Drawing.Point(45, 27);
            this.TBMSCHDCVFrm.Name = "TBMSCHDCVFrm";
            this.TBMSCHDCVFrm.Size = new System.Drawing.Size(65, 20);
            this.TBMSCHDCVFrm.TabIndex = 15;
            this.TBMSCHDCVFrm.Validated += new System.EventHandler(this.TBMSCHDCVFrm_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "From:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Mode:";
            // 
            // CBMode
            // 
            this.CBMode.FormattingEnabled = true;
            this.CBMode.Items.AddRange(new object[] {
            "EIS",
            "Mott Schottky",
            "Chronoamperometry",
            "I-V and C-V",
            "Pulse"});
            this.CBMode.Location = new System.Drawing.Point(91, 36);
            this.CBMode.Name = "CBMode";
            this.CBMode.Size = new System.Drawing.Size(129, 21);
            this.CBMode.TabIndex = 7;
            this.CBMode.SelectedIndexChanged += new System.EventHandler(this.CBMode_SelectedIndexChanged);
            // 
            // ChBActive
            // 
            this.ChBActive.AutoSize = true;
            this.ChBActive.Location = new System.Drawing.Point(344, 9);
            this.ChBActive.Name = "ChBActive";
            this.ChBActive.Size = new System.Drawing.Size(56, 17);
            this.ChBActive.TabIndex = 3;
            this.ChBActive.Text = "Active";
            this.ChBActive.UseVisualStyleBackColor = true;
            this.ChBActive.CheckedChanged += new System.EventHandler(this.ChBActive_CheckedChanged);
            // 
            // TBSsnName
            // 
            this.TBSsnName.Location = new System.Drawing.Point(91, 10);
            this.TBSsnName.Name = "TBSsnName";
            this.TBSsnName.Size = new System.Drawing.Size(129, 20);
            this.TBSsnName.TabIndex = 2;
            this.TBSsnName.TextChanged += new System.EventHandler(this.TBSsnName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Session Name:";
            // 
            // GBEIS
            // 
            this.GBEIS.Controls.Add(this.BtnEISAveNumH);
            this.GBEIS.Controls.Add(this.label55);
            this.GBEIS.Controls.Add(this.BtnEISAveNum);
            this.GBEIS.Controls.Add(this.label48);
            this.GBEIS.Controls.Add(this.CBEISFilterMode);
            this.GBEIS.Controls.Add(this.label28);
            this.GBEIS.Controls.Add(this.CBEISMode);
            this.GBEIS.Controls.Add(this.label25);
            this.GBEIS.Controls.Add(this.GBVoltages);
            this.GBEIS.Controls.Add(this.GBFrequency);
            this.GBEIS.Location = new System.Drawing.Point(8, 331);
            this.GBEIS.Name = "GBEIS";
            this.GBEIS.Size = new System.Drawing.Size(399, 547);
            this.GBEIS.TabIndex = 9;
            this.GBEIS.TabStop = false;
            this.GBEIS.Text = "EIS";
            // 
            // BtnEISAveNumH
            // 
            this.BtnEISAveNumH.Location = new System.Drawing.Point(164, 97);
            this.BtnEISAveNumH.Name = "BtnEISAveNumH";
            this.BtnEISAveNumH.Size = new System.Drawing.Size(61, 20);
            this.BtnEISAveNumH.TabIndex = 14;
            this.BtnEISAveNumH.Validated += new System.EventHandler(this.BtnEISAveNumH_Validated);
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(27, 99);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(130, 13);
            this.label55.TabIndex = 13;
            this.label55.Text = "Average Number (>10Hz):";
            // 
            // BtnEISAveNum
            // 
            this.BtnEISAveNum.Location = new System.Drawing.Point(164, 71);
            this.BtnEISAveNum.Name = "BtnEISAveNum";
            this.BtnEISAveNum.Size = new System.Drawing.Size(61, 20);
            this.BtnEISAveNum.TabIndex = 12;
            this.BtnEISAveNum.Validated += new System.EventHandler(this.BtnEISAveNum_Validated);
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(27, 73);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(130, 13);
            this.label48.TabIndex = 11;
            this.label48.Text = "Average Number (<10Hz):";
            // 
            // CBEISFilterMode
            // 
            this.CBEISFilterMode.Enabled = false;
            this.CBEISFilterMode.FormattingEnabled = true;
            this.CBEISFilterMode.Items.AddRange(new object[] {
            "Auto",
            "Filter 1",
            "Filter 2"});
            this.CBEISFilterMode.Location = new System.Drawing.Point(271, 25);
            this.CBEISFilterMode.Name = "CBEISFilterMode";
            this.CBEISFilterMode.Size = new System.Drawing.Size(104, 21);
            this.CBEISFilterMode.TabIndex = 10;
            this.CBEISFilterMode.SelectedIndexChanged += new System.EventHandler(this.CBEISFilter_SelectedIndexChanged);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(229, 28);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(32, 13);
            this.label28.TabIndex = 9;
            this.label28.Text = "Filter:";
            // 
            // CBEISMode
            // 
            this.CBEISMode.FormattingEnabled = true;
            this.CBEISMode.Items.AddRange(new object[] {
            "Analog",
            "Digital"});
            this.CBEISMode.Location = new System.Drawing.Point(68, 25);
            this.CBEISMode.Name = "CBEISMode";
            this.CBEISMode.Size = new System.Drawing.Size(104, 21);
            this.CBEISMode.TabIndex = 8;
            this.CBEISMode.SelectedIndexChanged += new System.EventHandler(this.CBEISMode_SelectedIndexChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(27, 28);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(37, 13);
            this.label25.TabIndex = 6;
            this.label25.Text = "Mode:";
            // 
            // GBVoltages
            // 
            this.GBVoltages.Controls.Add(this.groupBox7);
            this.GBVoltages.Controls.Add(this.groupBox1);
            this.GBVoltages.Controls.Add(this.CBEISVoltageRangeMode);
            this.GBVoltages.Controls.Add(this.label26);
            this.GBVoltages.Location = new System.Drawing.Point(6, 130);
            this.GBVoltages.Name = "GBVoltages";
            this.GBVoltages.Size = new System.Drawing.Size(387, 314);
            this.GBVoltages.TabIndex = 4;
            this.GBVoltages.TabStop = false;
            this.GBVoltages.Text = "Constants";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label61);
            this.groupBox7.Controls.Add(this.CBEISMaxImlp);
            this.groupBox7.Controls.Add(this.CBEISMaxVmlp);
            this.groupBox7.Controls.Add(this.label43);
            this.groupBox7.Controls.Add(this.CBEISACCurrentRangeMode);
            this.groupBox7.Controls.Add(this.TBACAmpConstant);
            this.groupBox7.Controls.Add(this.label7);
            this.groupBox7.Controls.Add(this.label30);
            this.groupBox7.Controls.Add(this.CBEISACRegulatorMode);
            this.groupBox7.Controls.Add(this.label60);
            this.groupBox7.Controls.Add(this.label62);
            this.groupBox7.Location = new System.Drawing.Point(9, 134);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(372, 160);
            this.groupBox7.TabIndex = 15;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "AC";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(11, 95);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(121, 13);
            this.label61.TabIndex = 19;
            this.label61.Text = "Maximum I amplification:";
            // 
            // CBEISMaxImlp
            // 
            this.CBEISMaxImlp.FormattingEnabled = true;
            this.CBEISMaxImlp.Items.AddRange(new object[] {
            "x 1",
            "x 2",
            "x 4",
            "x 8"});
            this.CBEISMaxImlp.Location = new System.Drawing.Point(140, 92);
            this.CBEISMaxImlp.Name = "CBEISMaxImlp";
            this.CBEISMaxImlp.Size = new System.Drawing.Size(57, 21);
            this.CBEISMaxImlp.TabIndex = 18;
            this.CBEISMaxImlp.SelectedIndexChanged += new System.EventHandler(this.CBEISMaxImlp_SelectedIndexChanged);
            // 
            // CBEISMaxVmlp
            // 
            this.CBEISMaxVmlp.FormattingEnabled = true;
            this.CBEISMaxVmlp.Items.AddRange(new object[] {
            "x 1",
            "x 2",
            "x 4",
            "x 8",
            "x 16",
            "x 32",
            "x 64"});
            this.CBEISMaxVmlp.Location = new System.Drawing.Point(142, 62);
            this.CBEISMaxVmlp.Name = "CBEISMaxVmlp";
            this.CBEISMaxVmlp.Size = new System.Drawing.Size(56, 21);
            this.CBEISMaxVmlp.TabIndex = 16;
            this.CBEISMaxVmlp.SelectedIndexChanged += new System.EventHandler(this.CBEISMaxVmlp_SelectedIndexChanged);
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(205, 21);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(56, 13);
            this.label43.TabIndex = 15;
            this.label43.Text = "Regulator:";
            // 
            // CBEISACCurrentRangeMode
            // 
            this.CBEISACCurrentRangeMode.FormattingEnabled = true;
            this.CBEISACCurrentRangeMode.Items.AddRange(new object[] {
            "x 1",
            "x 10",
            "x 100",
            "Auto"});
            this.CBEISACCurrentRangeMode.Location = new System.Drawing.Point(94, 19);
            this.CBEISACCurrentRangeMode.Name = "CBEISACCurrentRangeMode";
            this.CBEISACCurrentRangeMode.Size = new System.Drawing.Size(104, 21);
            this.CBEISACCurrentRangeMode.TabIndex = 14;
            this.CBEISACCurrentRangeMode.SelectedIndexChanged += new System.EventHandler(this.CBEISACCurrentRangeMode_SelectedIndexChanged);
            // 
            // TBACAmpConstant
            // 
            this.TBACAmpConstant.Location = new System.Drawing.Point(83, 128);
            this.TBACAmpConstant.Name = "TBACAmpConstant";
            this.TBACAmpConstant.Size = new System.Drawing.Size(76, 20);
            this.TBACAmpConstant.TabIndex = 3;
            this.TBACAmpConstant.TextChanged += new System.EventHandler(this.TBACAmpConstant_TextChanged_1);
            this.TBACAmpConstant.Validated += new System.EventHandler(this.TBACAmpConstant_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "AC Voltage:";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(13, 22);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(79, 13);
            this.label30.TabIndex = 13;
            this.label30.Text = "Current Range:";
            // 
            // CBEISACRegulatorMode
            // 
            this.CBEISACRegulatorMode.FormattingEnabled = true;
            this.CBEISACRegulatorMode.Items.AddRange(new object[] {
            "Auto",
            "Disable",
            "Device"});
            this.CBEISACRegulatorMode.Location = new System.Drawing.Point(263, 19);
            this.CBEISACRegulatorMode.Name = "CBEISACRegulatorMode";
            this.CBEISACRegulatorMode.Size = new System.Drawing.Size(104, 21);
            this.CBEISACRegulatorMode.TabIndex = 12;
            this.CBEISACRegulatorMode.SelectedIndexChanged += new System.EventHandler(this.CBEISCurrentRangeMode_SelectedIndexChanged);
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(13, 65);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(125, 13);
            this.label60.TabIndex = 17;
            this.label60.Text = "Maximum V amplification:";
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(160, 132);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(28, 13);
            this.label62.TabIndex = 20;
            this.label62.Text = "(mV)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TBDCVoltageConstant);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.CBEISDCCurrentRangeMode);
            this.groupBox1.Controls.Add(this.label31);
            this.groupBox1.Location = new System.Drawing.Point(9, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(372, 58);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DC";
            // 
            // TBDCVoltageConstant
            // 
            this.TBDCVoltageConstant.Location = new System.Drawing.Point(72, 27);
            this.TBDCVoltageConstant.Name = "TBDCVoltageConstant";
            this.TBDCVoltageConstant.Size = new System.Drawing.Size(104, 20);
            this.TBDCVoltageConstant.TabIndex = 2;
            this.TBDCVoltageConstant.Validated += new System.EventHandler(this.TBDCVoltageConstant_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "DC Voltage:";
            // 
            // CBEISDCCurrentRangeMode
            // 
            this.CBEISDCCurrentRangeMode.FormattingEnabled = true;
            this.CBEISDCCurrentRangeMode.Items.AddRange(new object[] {
            "Auto"});
            this.CBEISDCCurrentRangeMode.Location = new System.Drawing.Point(262, 25);
            this.CBEISDCCurrentRangeMode.Name = "CBEISDCCurrentRangeMode";
            this.CBEISDCCurrentRangeMode.Size = new System.Drawing.Size(104, 21);
            this.CBEISDCCurrentRangeMode.TabIndex = 16;
            this.CBEISDCCurrentRangeMode.SelectedIndexChanged += new System.EventHandler(this.CBEISDCCurrentRangeMode_SelectedIndexChanged);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(186, 28);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(79, 13);
            this.label31.TabIndex = 17;
            this.label31.Text = "Current Range:";
            // 
            // CBEISVoltageRangeMode
            // 
            this.CBEISVoltageRangeMode.FormattingEnabled = true;
            this.CBEISVoltageRangeMode.Items.AddRange(new object[] {
            "[-5 (V) .. 5 (V)]",
            "[-1 (V) .. 1 (V)]"});
            this.CBEISVoltageRangeMode.Location = new System.Drawing.Point(89, 26);
            this.CBEISVoltageRangeMode.Name = "CBEISVoltageRangeMode";
            this.CBEISVoltageRangeMode.Size = new System.Drawing.Size(104, 21);
            this.CBEISVoltageRangeMode.TabIndex = 10;
            this.CBEISVoltageRangeMode.SelectedIndexChanged += new System.EventHandler(this.CBEISVoltageRangeMode_SelectedIndexChanged);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(8, 28);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(81, 13);
            this.label26.TabIndex = 11;
            this.label26.Text = "Voltage Range:";
            // 
            // GBFrequency
            // 
            this.GBFrequency.Controls.Add(this.label14);
            this.GBFrequency.Controls.Add(this.TBACFrqNStep);
            this.GBFrequency.Controls.Add(this.label11);
            this.GBFrequency.Controls.Add(this.TBACFrqTo);
            this.GBFrequency.Controls.Add(this.TBACFrqFrom);
            this.GBFrequency.Controls.Add(this.label12);
            this.GBFrequency.Location = new System.Drawing.Point(6, 458);
            this.GBFrequency.Name = "GBFrequency";
            this.GBFrequency.Size = new System.Drawing.Size(387, 72);
            this.GBFrequency.TabIndex = 5;
            this.GBFrequency.TabStop = false;
            this.GBFrequency.Text = "AC Frequency";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(123, 30);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(23, 13);
            this.label14.TabIndex = 20;
            this.label14.Text = "To:";
            // 
            // TBACFrqNStep
            // 
            this.TBACFrqNStep.Location = new System.Drawing.Point(317, 28);
            this.TBACFrqNStep.Name = "TBACFrqNStep";
            this.TBACFrqNStep.Size = new System.Drawing.Size(65, 20);
            this.TBACFrqNStep.TabIndex = 18;
            this.TBACFrqNStep.Validated += new System.EventHandler(this.TBACFrqStep_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(223, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Number of Steps:";
            // 
            // TBACFrqTo
            // 
            this.TBACFrqTo.Location = new System.Drawing.Point(149, 28);
            this.TBACFrqTo.Name = "TBACFrqTo";
            this.TBACFrqTo.Size = new System.Drawing.Size(65, 20);
            this.TBACFrqTo.TabIndex = 16;
            this.TBACFrqTo.Validated += new System.EventHandler(this.TBACFrqTo_TextChanged);
            // 
            // TBACFrqFrom
            // 
            this.TBACFrqFrom.Location = new System.Drawing.Point(40, 28);
            this.TBACFrqFrom.Name = "TBACFrqFrom";
            this.TBACFrqFrom.Size = new System.Drawing.Size(65, 20);
            this.TBACFrqFrom.TabIndex = 15;
            this.TBACFrqFrom.Validated += new System.EventHandler(this.TBACFrqFrom_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 30);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(33, 13);
            this.label12.TabIndex = 14;
            this.label12.Text = "From:";
            // 
            // GBIV
            // 
            this.GBIV.Controls.Add(this.ChBisCVEnable);
            this.GBIV.Controls.Add(this.button7);
            this.GBIV.Controls.Add(this.GBCV);
            this.GBIV.Controls.Add(this.groupBox11);
            this.GBIV.Controls.Add(this.groupBox4);
            this.GBIV.Controls.Add(this.groupBox10);
            this.GBIV.Controls.Add(this.groupBox8);
            this.GBIV.Location = new System.Drawing.Point(8, 899);
            this.GBIV.Name = "GBIV";
            this.GBIV.Size = new System.Drawing.Size(399, 506);
            this.GBIV.TabIndex = 12;
            this.GBIV.TabStop = false;
            this.GBIV.Text = "I-V and C-V";
            // 
            // ChBisCVEnable
            // 
            this.ChBisCVEnable.AutoSize = true;
            this.ChBisCVEnable.Location = new System.Drawing.Point(12, 398);
            this.ChBisCVEnable.Name = "ChBisCVEnable";
            this.ChBisCVEnable.Size = new System.Drawing.Size(76, 17);
            this.ChBisCVEnable.TabIndex = 6;
            this.ChBisCVEnable.Text = "Enable CV";
            this.ChBisCVEnable.UseVisualStyleBackColor = true;
            this.ChBisCVEnable.CheckedChanged += new System.EventHandler(this.ChBisCVEnable_CheckedChanged);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(116, 292);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(178, 23);
            this.button7.TabIndex = 21;
            this.button7.Text = "IV Offset Removal";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // GBCV
            // 
            this.GBCV.Controls.Add(this.TB_CV_Itteration);
            this.GBCV.Controls.Add(this.TB_CV_StartPoint);
            this.GBCV.Controls.Add(this.TBCVACAmpFrm);
            this.GBCV.Controls.Add(this.TBCVACAmpStp);
            this.GBCV.Controls.Add(this.label18);
            this.GBCV.Controls.Add(this.groupBox6);
            this.GBCV.Controls.Add(this.label19);
            this.GBCV.Location = new System.Drawing.Point(6, 422);
            this.GBCV.Name = "GBCV";
            this.GBCV.Size = new System.Drawing.Size(387, 76);
            this.GBCV.TabIndex = 11;
            this.GBCV.TabStop = false;
            this.GBCV.Text = "CV";
            // 
            // TB_CV_Itteration
            // 
            this.TB_CV_Itteration.Location = new System.Drawing.Point(107, 45);
            this.TB_CV_Itteration.Name = "TB_CV_Itteration";
            this.TB_CV_Itteration.Size = new System.Drawing.Size(66, 20);
            this.TB_CV_Itteration.TabIndex = 20;
            this.TB_CV_Itteration.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_CV_Itteration_KeyDown);
            this.TB_CV_Itteration.Validated += new System.EventHandler(this.TB_CV_Itteration_Validated);
            // 
            // TB_CV_StartPoint
            // 
            this.TB_CV_StartPoint.Location = new System.Drawing.Point(107, 19);
            this.TB_CV_StartPoint.Name = "TB_CV_StartPoint";
            this.TB_CV_StartPoint.Size = new System.Drawing.Size(66, 20);
            this.TB_CV_StartPoint.TabIndex = 19;
            this.TB_CV_StartPoint.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_CV_StartPoint_KeyDown);
            this.TB_CV_StartPoint.Validated += new System.EventHandler(this.TB_CV_StartPoint_Validated);
            // 
            // TBCVACAmpFrm
            // 
            this.TBCVACAmpFrm.Location = new System.Drawing.Point(372, 22);
            this.TBCVACAmpFrm.Name = "TBCVACAmpFrm";
            this.TBCVACAmpFrm.Size = new System.Drawing.Size(10, 20);
            this.TBCVACAmpFrm.TabIndex = 15;
            this.TBCVACAmpFrm.Visible = false;
            this.TBCVACAmpFrm.Validated += new System.EventHandler(this.TBCVACAmpFrm_TextChanged);
            // 
            // TBCVACAmpStp
            // 
            this.TBCVACAmpStp.Location = new System.Drawing.Point(372, 48);
            this.TBCVACAmpStp.Name = "TBCVACAmpStp";
            this.TBCVACAmpStp.Size = new System.Drawing.Size(10, 20);
            this.TBCVACAmpStp.TabIndex = 18;
            this.TBCVACAmpStp.Visible = false;
            this.TBCVACAmpStp.Validated += new System.EventHandler(this.TBCVACAmpStp_TextChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(10, 48);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(92, 13);
            this.label18.TabIndex = 17;
            this.label18.Text = "Number of Scans:";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.TBCVACFrqCnst);
            this.groupBox6.Controls.Add(this.label16);
            this.groupBox6.Controls.Add(this.TBCVDCVltCnst);
            this.groupBox6.Controls.Add(this.label17);
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Controls.Add(this.TBCVACAmpTo);
            this.groupBox6.Location = new System.Drawing.Point(6, 170);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(223, 19);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "AC Amplitoide:";
            this.groupBox6.Visible = false;
            // 
            // TBCVACFrqCnst
            // 
            this.TBCVACFrqCnst.Location = new System.Drawing.Point(86, 64);
            this.TBCVACFrqCnst.Name = "TBCVACFrqCnst";
            this.TBCVACFrqCnst.Size = new System.Drawing.Size(65, 20);
            this.TBCVACFrqCnst.TabIndex = 3;
            this.TBCVACFrqCnst.Validated += new System.EventHandler(this.TBCVACFrqCnst_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 64);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(77, 13);
            this.label16.TabIndex = 2;
            this.label16.Text = "AC Frequency:";
            // 
            // TBCVDCVltCnst
            // 
            this.TBCVDCVltCnst.Location = new System.Drawing.Point(82, 19);
            this.TBCVDCVltCnst.Name = "TBCVDCVltCnst";
            this.TBCVDCVltCnst.Size = new System.Drawing.Size(65, 20);
            this.TBCVDCVltCnst.TabIndex = 2;
            this.TBCVDCVltCnst.Validated += new System.EventHandler(this.TBCVDCVltCnst_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(53, 44);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(23, 13);
            this.label17.TabIndex = 20;
            this.label17.Text = "To:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "DC Voltage:";
            // 
            // TBCVACAmpTo
            // 
            this.TBCVACAmpTo.Location = new System.Drawing.Point(82, 41);
            this.TBCVACAmpTo.Name = "TBCVACAmpTo";
            this.TBCVACAmpTo.Size = new System.Drawing.Size(65, 20);
            this.TBCVACAmpTo.TabIndex = 16;
            this.TBCVACAmpTo.Validated += new System.EventHandler(this.TBCVACAmpTo_TextChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(44, 22);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(58, 13);
            this.label19.TabIndex = 14;
            this.label19.Text = "Start point:";
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.label34);
            this.groupBox11.Controls.Add(this.TBIVVelosity);
            this.groupBox11.Controls.Add(this.label41);
            this.groupBox11.Controls.Add(this.label24);
            this.groupBox11.Controls.Add(this.TBTimeStep);
            this.groupBox11.Controls.Add(this.label32);
            this.groupBox11.Location = new System.Drawing.Point(6, 327);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(387, 65);
            this.groupBox11.TabIndex = 26;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Timing:";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(16, 29);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(61, 13);
            this.label34.TabIndex = 20;
            this.label34.Text = "Scan Rate:";
            // 
            // TBIVVelosity
            // 
            this.TBIVVelosity.Location = new System.Drawing.Point(81, 27);
            this.TBIVVelosity.Name = "TBIVVelosity";
            this.TBIVVelosity.Size = new System.Drawing.Size(65, 20);
            this.TBIVVelosity.TabIndex = 21;
            this.TBIVVelosity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TBIVVelosity_KeyDown);
            this.TBIVVelosity.Validated += new System.EventHandler(this.TBIVVelosity_Validated);
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label41.Location = new System.Drawing.Point(148, 29);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(30, 13);
            this.label41.TabIndex = 22;
            this.label41.Text = "(V/s)";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(208, 29);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(58, 13);
            this.label24.TabIndex = 9;
            this.label24.Text = "Time Step:";
            // 
            // TBTimeStep
            // 
            this.TBTimeStep.Enabled = false;
            this.TBTimeStep.Location = new System.Drawing.Point(271, 27);
            this.TBTimeStep.Name = "TBTimeStep";
            this.TBTimeStep.Size = new System.Drawing.Size(65, 20);
            this.TBTimeStep.TabIndex = 16;
            this.TBTimeStep.Validated += new System.EventHandler(this.TBTimeStep_TextChanged);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label32.Location = new System.Drawing.Point(340, 29);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(26, 13);
            this.label32.TabIndex = 19;
            this.label32.Text = "(ms)";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.TBIVVoltagedV);
            this.groupBox4.Controls.Add(this.label76);
            this.groupBox4.Controls.Add(this.btnChronoTiming);
            this.groupBox4.Controls.Add(this.ChBChronoFastMode);
            this.groupBox4.Controls.Add(this.MinUnitLabel);
            this.groupBox4.Controls.Add(this.MaxUnitLabel);
            this.groupBox4.Controls.Add(this.TBIVVoltageStep);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.TBIVVoltageTo);
            this.groupBox4.Controls.Add(this.TBIVVoltageFrom);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.StepUnitLabel);
            this.groupBox4.Location = new System.Drawing.Point(6, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(387, 88);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Input";
            // 
            // TBIVVoltagedV
            // 
            this.TBIVVoltagedV.Location = new System.Drawing.Point(226, 21);
            this.TBIVVoltagedV.Name = "TBIVVoltagedV";
            this.TBIVVoltagedV.Size = new System.Drawing.Size(49, 20);
            this.TBIVVoltagedV.TabIndex = 29;
            this.TBIVVoltagedV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TBIVVoltagedV_KeyDown);
            this.TBIVVoltagedV.Validated += new System.EventHandler(this.TBIVVoltagedV_Validated);
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.Location = new System.Drawing.Point(192, 24);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(32, 13);
            this.label76.TabIndex = 28;
            this.label76.Text = "Step:";
            // 
            // btnChronoTiming
            // 
            this.btnChronoTiming.Location = new System.Drawing.Point(305, 21);
            this.btnChronoTiming.Name = "btnChronoTiming";
            this.btnChronoTiming.Size = new System.Drawing.Size(72, 23);
            this.btnChronoTiming.TabIndex = 27;
            this.btnChronoTiming.Text = "Timing";
            this.btnChronoTiming.UseVisualStyleBackColor = true;
            this.btnChronoTiming.Click += new System.EventHandler(this.button11_Click);
            // 
            // ChBChronoFastMode
            // 
            this.ChBChronoFastMode.AutoSize = true;
            this.ChBChronoFastMode.Location = new System.Drawing.Point(305, 52);
            this.ChBChronoFastMode.Margin = new System.Windows.Forms.Padding(2);
            this.ChBChronoFastMode.Name = "ChBChronoFastMode";
            this.ChBChronoFastMode.Size = new System.Drawing.Size(75, 17);
            this.ChBChronoFastMode.TabIndex = 23;
            this.ChBChronoFastMode.Text = "Fast mode";
            this.ChBChronoFastMode.UseVisualStyleBackColor = true;
            this.ChBChronoFastMode.CheckedChanged += new System.EventHandler(this.ChBChronoFastMode_CheckedChanged);
            // 
            // MinUnitLabel
            // 
            this.MinUnitLabel.AutoSize = true;
            this.MinUnitLabel.Location = new System.Drawing.Point(143, 24);
            this.MinUnitLabel.Name = "MinUnitLabel";
            this.MinUnitLabel.Size = new System.Drawing.Size(30, 13);
            this.MinUnitLabel.TabIndex = 22;
            this.MinUnitLabel.Text = "(sec)";
            // 
            // MaxUnitLabel
            // 
            this.MaxUnitLabel.AutoSize = true;
            this.MaxUnitLabel.Location = new System.Drawing.Point(143, 53);
            this.MaxUnitLabel.Name = "MaxUnitLabel";
            this.MaxUnitLabel.Size = new System.Drawing.Size(30, 13);
            this.MaxUnitLabel.TabIndex = 21;
            this.MaxUnitLabel.Text = "(sec)";
            // 
            // TBIVVoltageStep
            // 
            this.TBIVVoltageStep.Location = new System.Drawing.Point(226, 51);
            this.TBIVVoltageStep.Name = "TBIVVoltageStep";
            this.TBIVVoltageStep.ReadOnly = true;
            this.TBIVVoltageStep.Size = new System.Drawing.Size(49, 20);
            this.TBIVVoltageStep.TabIndex = 18;
            this.TBIVVoltageStep.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TBIVVoltageStep_KeyDown);
            this.TBIVVoltageStep.Validated += new System.EventHandler(this.TBIVVoltageStep_TextChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(176, 54);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(48, 13);
            this.label21.TabIndex = 17;
            this.label21.Text = "N Steps:";
            // 
            // TBIVVoltageTo
            // 
            this.TBIVVoltageTo.Location = new System.Drawing.Point(90, 51);
            this.TBIVVoltageTo.Name = "TBIVVoltageTo";
            this.TBIVVoltageTo.Size = new System.Drawing.Size(52, 20);
            this.TBIVVoltageTo.TabIndex = 16;
            this.TBIVVoltageTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TBIVVoltageTo_KeyDown);
            this.TBIVVoltageTo.Validated += new System.EventHandler(this.TBIVVoltageTo_TextChanged);
            // 
            // TBIVVoltageFrom
            // 
            this.TBIVVoltageFrom.Location = new System.Drawing.Point(90, 21);
            this.TBIVVoltageFrom.Name = "TBIVVoltageFrom";
            this.TBIVVoltageFrom.Size = new System.Drawing.Size(52, 20);
            this.TBIVVoltageFrom.TabIndex = 15;
            this.TBIVVoltageFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TBIVVoltageFrom_KeyDown);
            this.TBIVVoltageFrom.Validated += new System.EventHandler(this.TBIVVoltageFrom_TextChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(14, 24);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(77, 13);
            this.label22.TabIndex = 14;
            this.label22.Text = "Initial potential:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(15, 54);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(75, 13);
            this.label20.TabIndex = 20;
            this.label20.Text = "Final potential:";
            // 
            // StepUnitLabel
            // 
            this.StepUnitLabel.AutoSize = true;
            this.StepUnitLabel.Location = new System.Drawing.Point(277, 24);
            this.StepUnitLabel.Name = "StepUnitLabel";
            this.StepUnitLabel.Size = new System.Drawing.Size(30, 13);
            this.StepUnitLabel.TabIndex = 30;
            this.StepUnitLabel.Text = "(sec)";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.label36);
            this.groupBox10.Controls.Add(this.label23);
            this.groupBox10.Controls.Add(this.CBIVRange);
            this.groupBox10.Controls.Add(this.IMLP);
            this.groupBox10.Location = new System.Drawing.Point(6, 202);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(387, 76);
            this.groupBox10.TabIndex = 25;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Current Range:";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(44, 49);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(65, 13);
            this.label36.TabIndex = 22;
            this.label36.Text = "Fine Range:";
            this.label36.Visible = false;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(29, 33);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(78, 13);
            this.label23.TabIndex = 24;
            this.label23.Text = "Course Range:";
            // 
            // CBIVRange
            // 
            this.CBIVRange.FormattingEnabled = true;
            this.CBIVRange.Items.AddRange(new object[] {
            "1 ampere",
            "100 miliampere",
            "10 miliampere",
            "1 miliampere",
            "100 microampere",
            "10 microampere",
            "1 micrommpere",
            "100 nanoampere"});
            this.CBIVRange.Location = new System.Drawing.Point(116, 30);
            this.CBIVRange.Name = "CBIVRange";
            this.CBIVRange.Size = new System.Drawing.Size(126, 21);
            this.CBIVRange.TabIndex = 8;
            this.CBIVRange.SelectedIndexChanged += new System.EventHandler(this.CBIVRange_SelectedIndexChanged);
            // 
            // IMLP
            // 
            this.IMLP.FormattingEnabled = true;
            this.IMLP.Items.AddRange(new object[] {
            "1",
            "2",
            "4",
            "8",
            "16",
            "32",
            "64"});
            this.IMLP.Location = new System.Drawing.Point(116, 46);
            this.IMLP.Name = "IMLP";
            this.IMLP.Size = new System.Drawing.Size(126, 21);
            this.IMLP.TabIndex = 23;
            this.IMLP.Visible = false;
            this.IMLP.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.IVChronoVFilter);
            this.groupBox8.Controls.Add(this.label77);
            this.groupBox8.Controls.Add(this.label33);
            this.groupBox8.Controls.Add(this.CBIVVoltageRangeMode);
            this.groupBox8.Controls.Add(this.VMLP);
            this.groupBox8.Controls.Add(this.label27);
            this.groupBox8.Location = new System.Drawing.Point(6, 112);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(387, 82);
            this.groupBox8.TabIndex = 24;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Voltage Range:";
            // 
            // IVChronoVFilter
            // 
            this.IVChronoVFilter.FormattingEnabled = true;
            this.IVChronoVFilter.Items.AddRange(new object[] {
            "High speed",
            "Medim",
            "Low speed",
            "Auto"});
            this.IVChronoVFilter.Location = new System.Drawing.Point(289, 34);
            this.IVChronoVFilter.Name = "IVChronoVFilter";
            this.IVChronoVFilter.Size = new System.Drawing.Size(88, 21);
            this.IVChronoVFilter.TabIndex = 23;
            this.IVChronoVFilter.SelectedIndexChanged += new System.EventHandler(this.IVChronoVFilter_SelectedIndexChanged);
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.Location = new System.Drawing.Point(256, 37);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(32, 13);
            this.label77.TabIndex = 22;
            this.label77.Text = "Filter:";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(44, 52);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(65, 13);
            this.label33.TabIndex = 20;
            this.label33.Text = "Fine Range:";
            this.label33.Visible = false;
            // 
            // CBIVVoltageRangeMode
            // 
            this.CBIVVoltageRangeMode.FormattingEnabled = true;
            this.CBIVVoltageRangeMode.Items.AddRange(new object[] {
            "[-5 (V) .. 5 (V)]",
            "[-1 (V) .. 1 (V)]"});
            this.CBIVVoltageRangeMode.Location = new System.Drawing.Point(116, 34);
            this.CBIVVoltageRangeMode.Name = "CBIVVoltageRangeMode";
            this.CBIVVoltageRangeMode.Size = new System.Drawing.Size(126, 21);
            this.CBIVVoltageRangeMode.TabIndex = 17;
            this.CBIVVoltageRangeMode.SelectedIndexChanged += new System.EventHandler(this.CBIVVoltageRange_SelectedIndexChanged);
            // 
            // VMLP
            // 
            this.VMLP.FormattingEnabled = true;
            this.VMLP.Items.AddRange(new object[] {
            "[-10 (V) .. 10 (V)]",
            "[-20 (V) .. 20 (V)]",
            "[-40 (V) .. 40 (V)]",
            "[-80 (V) .. 80 (V)]",
            "[-160 (V) .. 160 (V)]",
            "[-320 (V) .. 320 (V)]",
            "[-640 (V) .. 640 (V)]"});
            this.VMLP.Location = new System.Drawing.Point(116, 50);
            this.VMLP.Name = "VMLP";
            this.VMLP.Size = new System.Drawing.Size(126, 21);
            this.VMLP.TabIndex = 21;
            this.VMLP.Visible = false;
            this.VMLP.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(12, 37);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(100, 13);
            this.label27.TabIndex = 18;
            this.label27.Text = "Set Voltage Range:";
            // 
            // GBPreprocessing
            // 
            this.GBPreprocessing.Controls.Add(this.groupBox5);
            this.GBPreprocessing.Controls.Add(this.groupBox12);
            this.GBPreprocessing.Controls.Add(this.LabelVOCT);
            this.GBPreprocessing.Controls.Add(this.ChBRelRef);
            this.GBPreprocessing.Location = new System.Drawing.Point(8, 62);
            this.GBPreprocessing.Name = "GBPreprocessing";
            this.GBPreprocessing.Size = new System.Drawing.Size(399, 263);
            this.GBPreprocessing.TabIndex = 30;
            this.GBPreprocessing.TabStop = false;
            this.GBPreprocessing.Text = "Preprocessing";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ChBPreProcProbOn);
            this.groupBox5.Controls.Add(this.label71);
            this.groupBox5.Controls.Add(this.TBEqTime);
            this.groupBox5.Controls.Add(this.label69);
            this.groupBox5.Controls.Add(this.label49);
            this.groupBox5.Controls.Add(this.TBPretreatmentVoltage);
            this.groupBox5.Controls.Add(this.label29);
            this.groupBox5.Location = new System.Drawing.Point(6, 18);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox5.Size = new System.Drawing.Size(387, 74);
            this.groupBox5.TabIndex = 31;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "General";
            // 
            // ChBPreProcProbOn
            // 
            this.ChBPreProcProbOn.AutoSize = true;
            this.ChBPreProcProbOn.Location = new System.Drawing.Point(10, 22);
            this.ChBPreProcProbOn.Margin = new System.Windows.Forms.Padding(2);
            this.ChBPreProcProbOn.Name = "ChBPreProcProbOn";
            this.ChBPreProcProbOn.Size = new System.Drawing.Size(65, 17);
            this.ChBPreProcProbOn.TabIndex = 11;
            this.ChBPreProcProbOn.Text = "Prob On";
            this.ChBPreProcProbOn.UseVisualStyleBackColor = true;
            this.ChBPreProcProbOn.CheckedChanged += new System.EventHandler(this.ChBPreProcProbOn_CheckedChanged);
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(166, 46);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(20, 13);
            this.label71.TabIndex = 30;
            this.label71.Text = "(V)";
            // 
            // TBEqTime
            // 
            this.TBEqTime.Location = new System.Drawing.Point(283, 46);
            this.TBEqTime.Name = "TBEqTime";
            this.TBEqTime.Size = new System.Drawing.Size(54, 20);
            this.TBEqTime.TabIndex = 13;
            this.TBEqTime.Validated += new System.EventHandler(this.TBEqTime_Validated);
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(8, 47);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(108, 13);
            this.label69.TabIndex = 29;
            this.label69.Text = "Pretreatment voltage:";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(192, 47);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(89, 13);
            this.label49.TabIndex = 14;
            this.label49.Text = "Equilibration time:";
            // 
            // TBPretreatmentVoltage
            // 
            this.TBPretreatmentVoltage.Location = new System.Drawing.Point(116, 46);
            this.TBPretreatmentVoltage.Name = "TBPretreatmentVoltage";
            this.TBPretreatmentVoltage.Size = new System.Drawing.Size(47, 20);
            this.TBPretreatmentVoltage.TabIndex = 28;
            this.TBPretreatmentVoltage.Validated += new System.EventHandler(this.TBPretreatmentVoltage_Validated);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(341, 47);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(30, 13);
            this.label29.TabIndex = 16;
            this.label29.Text = "(sec)";
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.ChBOCPAutoStart);
            this.groupBox12.Controls.Add(this.CB_PGMode);
            this.groupBox12.Controls.Add(this.BtnUseSuggestedVOCP);
            this.groupBox12.Controls.Add(this.LabelSuggestedVOCP);
            this.groupBox12.Controls.Add(this.label52);
            this.groupBox12.Controls.Add(this.label51);
            this.groupBox12.Controls.Add(this.CBEISOCMode);
            this.groupBox12.Controls.Add(this.TBVOCP);
            this.groupBox12.Controls.Add(this.ChBOCT);
            this.groupBox12.Controls.Add(this.label50);
            this.groupBox12.Controls.Add(this.label66);
            this.groupBox12.Location = new System.Drawing.Point(6, 97);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(387, 151);
            this.groupBox12.TabIndex = 20;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "OCP";
            // 
            // ChBOCPAutoStart
            // 
            this.ChBOCPAutoStart.AutoSize = true;
            this.ChBOCPAutoStart.Location = new System.Drawing.Point(246, 47);
            this.ChBOCPAutoStart.Name = "ChBOCPAutoStart";
            this.ChBOCPAutoStart.Size = new System.Drawing.Size(48, 17);
            this.ChBOCPAutoStart.TabIndex = 27;
            this.ChBOCPAutoStart.Text = "Auto";
            this.ChBOCPAutoStart.UseVisualStyleBackColor = true;
            this.ChBOCPAutoStart.CheckedChanged += new System.EventHandler(this.ChBOCPAutoStart_CheckedChanged);
            // 
            // CB_PGMode
            // 
            this.CB_PGMode.FormattingEnabled = true;
            this.CB_PGMode.Items.AddRange(new object[] {
            "4-Probe potentiostat",
            "3-Probe potentiostat",
            "Source meter",
            "Galvanostat"});
            this.CB_PGMode.Location = new System.Drawing.Point(68, 80);
            this.CB_PGMode.Name = "CB_PGMode";
            this.CB_PGMode.Size = new System.Drawing.Size(149, 21);
            this.CB_PGMode.TabIndex = 25;
            this.CB_PGMode.SelectedIndexChanged += new System.EventHandler(this.CB_PGMode_SelectedIndexChanged);
            // 
            // BtnUseSuggestedVOCP
            // 
            this.BtnUseSuggestedVOCP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnUseSuggestedVOCP.Location = new System.Drawing.Point(211, 114);
            this.BtnUseSuggestedVOCP.Name = "BtnUseSuggestedVOCP";
            this.BtnUseSuggestedVOCP.Size = new System.Drawing.Size(133, 23);
            this.BtnUseSuggestedVOCP.TabIndex = 24;
            this.BtnUseSuggestedVOCP.Text = "Use Suggested OCP";
            this.BtnUseSuggestedVOCP.UseVisualStyleBackColor = true;
            this.BtnUseSuggestedVOCP.Click += new System.EventHandler(this.BtnUseSuggestedVOCP_Click);
            this.BtnUseSuggestedVOCP.MouseEnter += new System.EventHandler(this.BtnUseSuggestedVOCP_MouseEnter);
            // 
            // LabelSuggestedVOCP
            // 
            this.LabelSuggestedVOCP.AutoSize = true;
            this.LabelSuggestedVOCP.Location = new System.Drawing.Point(156, 119);
            this.LabelSuggestedVOCP.Name = "LabelSuggestedVOCP";
            this.LabelSuggestedVOCP.Size = new System.Drawing.Size(22, 13);
            this.LabelSuggestedVOCP.TabIndex = 23;
            this.LabelSuggestedVOCP.Text = "0.0";
            this.LabelSuggestedVOCP.MouseEnter += new System.EventHandler(this.LabelSuggestedVOCP_MouseEnter);
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(75, 119);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(86, 13);
            this.label52.TabIndex = 21;
            this.label52.Text = "Suggested OCP:";
            this.label52.MouseEnter += new System.EventHandler(this.label52_MouseEnter);
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(28, 20);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(37, 13);
            this.label51.TabIndex = 20;
            this.label51.Text = "Mode:";
            this.label51.MouseEnter += new System.EventHandler(this.label51_MouseEnter);
            // 
            // CBEISOCMode
            // 
            this.CBEISOCMode.Enabled = false;
            this.CBEISOCMode.FormattingEnabled = true;
            this.CBEISOCMode.Items.AddRange(new object[] {
            "Absolute",
            "Relative"});
            this.CBEISOCMode.Location = new System.Drawing.Point(68, 17);
            this.CBEISOCMode.Name = "CBEISOCMode";
            this.CBEISOCMode.Size = new System.Drawing.Size(149, 21);
            this.CBEISOCMode.TabIndex = 12;
            this.CBEISOCMode.SelectedIndexChanged += new System.EventHandler(this.CBEISOCMode_SelectedIndexChanged);
            this.CBEISOCMode.MouseEnter += new System.EventHandler(this.CBEISOCMode_MouseEnter);
            // 
            // TBVOCP
            // 
            this.TBVOCP.Location = new System.Drawing.Point(68, 47);
            this.TBVOCP.Name = "TBVOCP";
            this.TBVOCP.Size = new System.Drawing.Size(149, 20);
            this.TBVOCP.TabIndex = 19;
            this.TBVOCP.TextChanged += new System.EventHandler(this.TBVOCP_TextChanged);
            this.TBVOCP.MouseEnter += new System.EventHandler(this.TBVOCP_MouseEnter);
            this.TBVOCP.Validating += new System.ComponentModel.CancelEventHandler(this.TBVOCP_Validating);
            // 
            // ChBOCT
            // 
            this.ChBOCT.AutoSize = true;
            this.ChBOCT.Location = new System.Drawing.Point(246, 19);
            this.ChBOCT.Name = "ChBOCT";
            this.ChBOCT.Size = new System.Drawing.Size(56, 17);
            this.ChBOCT.TabIndex = 15;
            this.ChBOCT.Text = "Active";
            this.ChBOCT.UseVisualStyleBackColor = true;
            this.ChBOCT.CheckedChanged += new System.EventHandler(this.ChBOCT_CheckedChanged);
            this.ChBOCT.MouseEnter += new System.EventHandler(this.ChBOCT_MouseEnter);
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(32, 48);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(32, 13);
            this.label50.TabIndex = 18;
            this.label50.Text = "OCP:";
            this.label50.MouseEnter += new System.EventHandler(this.label50_MouseEnter);
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(11, 83);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(55, 13);
            this.label66.TabIndex = 26;
            this.label66.Text = "PG Mode:";
            // 
            // LabelVOCT
            // 
            this.LabelVOCT.AutoSize = true;
            this.LabelVOCT.Location = new System.Drawing.Point(9, 69);
            this.LabelVOCT.Name = "LabelVOCT";
            this.LabelVOCT.Size = new System.Drawing.Size(0, 13);
            this.LabelVOCT.TabIndex = 17;
            // 
            // ChBRelRef
            // 
            this.ChBRelRef.AutoSize = true;
            this.ChBRelRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChBRelRef.Location = new System.Drawing.Point(6, 232);
            this.ChBRelRef.Name = "ChBRelRef";
            this.ChBRelRef.Size = new System.Drawing.Size(391, 16);
            this.ChBRelRef.TabIndex = 27;
            this.ChBRelRef.Text = "Report current and voltage Relative to Reference measurement (3 electrod measurem" +
    "ent)";
            this.ChBRelRef.UseVisualStyleBackColor = true;
            this.ChBRelRef.Visible = false;
            this.ChBRelRef.CheckedChanged += new System.EventHandler(this.ChBRelRef_CheckedChanged);
            // 
            // Prop
            // 
            this.Prop.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Prop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Prop.Controls.Add(this.label1);
            this.Prop.Dock = System.Windows.Forms.DockStyle.Top;
            this.Prop.Location = new System.Drawing.Point(0, 0);
            this.Prop.Name = "Prop";
            this.Prop.Size = new System.Drawing.Size(435, 22);
            this.Prop.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(3, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Session Properties";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // saveFileDialogSSnExp
            // 
            this.saveFileDialogSSnExp.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialogSSnExp_FileOk);
            // 
            // CMSSession
            // 
            this.CMSSession.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CMSSession.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.duplicateToolStripMenuItem,
            this.exportDataToolStripMenuItem});
            this.CMSSession.Name = "CMSSession";
            this.CMSSession.Size = new System.Drawing.Size(136, 70);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // duplicateToolStripMenuItem
            // 
            this.duplicateToolStripMenuItem.Name = "duplicateToolStripMenuItem";
            this.duplicateToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.duplicateToolStripMenuItem.Text = "Duplicate";
            this.duplicateToolStripMenuItem.Click += new System.EventHandler(this.duplicateToolStripMenuItem_Click);
            // 
            // exportDataToolStripMenuItem
            // 
            this.exportDataToolStripMenuItem.Name = "exportDataToolStripMenuItem";
            this.exportDataToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.exportDataToolStripMenuItem.Text = "Export Data";
            this.exportDataToolStripMenuItem.Click += new System.EventHandler(this.exportDataToolStripMenuItem_Click);
            // 
            // IVTimer
            // 
            this.IVTimer.Interval = 1500;
            this.IVTimer.Tick += new System.EventHandler(this.IVTimer_Tick);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.GBAdminLog);
            this.panel2.Controls.Add(this.groupBox14);
            this.panel2.Controls.Add(this.groupBox9);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(286, 435);
            this.panel2.TabIndex = 6;
            // 
            // GBAdminLog
            // 
            this.GBAdminLog.Controls.Add(this.label_clm);
            this.GBAdminLog.Controls.Add(this.label81);
            this.GBAdminLog.Controls.Add(this.label_iacdac);
            this.GBAdminLog.Controls.Add(this.label82);
            this.GBAdminLog.Controls.Add(this.label_false);
            this.GBAdminLog.Controls.Add(this.label80);
            this.GBAdminLog.Controls.Add(this.label79);
            this.GBAdminLog.Controls.Add(this.label_iIs);
            this.GBAdminLog.Controls.Add(this.label_postfilter);
            this.GBAdminLog.Controls.Add(this.Label_Filter_C_I);
            this.GBAdminLog.Controls.Add(this.Label_IFilter);
            this.GBAdminLog.Controls.Add(this.label73);
            this.GBAdminLog.Controls.Add(this.label74);
            this.GBAdminLog.Controls.Add(this.Label_Filter_C_V);
            this.GBAdminLog.Controls.Add(this.Label_VFilter);
            this.GBAdminLog.Controls.Add(this.label63);
            this.GBAdminLog.Controls.Add(this.iLabel_frq);
            this.GBAdminLog.Controls.Add(this.iLabel_vac);
            this.GBAdminLog.Controls.Add(this.Label_ISelect);
            this.GBAdminLog.Controls.Add(this.iLabel_vdc);
            this.GBAdminLog.Controls.Add(this.Label_Vmlp);
            this.GBAdminLog.Controls.Add(this.Label_VSelect);
            this.GBAdminLog.Controls.Add(this.Label_Imlp);
            this.GBAdminLog.Controls.Add(this.label70);
            this.GBAdminLog.Controls.Add(this.label58);
            this.GBAdminLog.Controls.Add(this.label42);
            this.GBAdminLog.Controls.Add(this.label57);
            this.GBAdminLog.Controls.Add(this.label64);
            this.GBAdminLog.Controls.Add(this.label68);
            this.GBAdminLog.Controls.Add(this.label56);
            this.GBAdminLog.Controls.Add(this.label40);
            this.GBAdminLog.Controls.Add(this.label44);
            this.GBAdminLog.Controls.Add(this.label38);
            this.GBAdminLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.GBAdminLog.Location = new System.Drawing.Point(14, 433);
            this.GBAdminLog.Name = "GBAdminLog";
            this.GBAdminLog.Size = new System.Drawing.Size(243, 261);
            this.GBAdminLog.TabIndex = 0;
            this.GBAdminLog.TabStop = false;
            this.GBAdminLog.Text = "Admin Log";
            // 
            // label_clm
            // 
            this.label_clm.AutoSize = true;
            this.label_clm.Location = new System.Drawing.Point(182, 171);
            this.label_clm.Name = "label_clm";
            this.label_clm.Size = new System.Drawing.Size(35, 15);
            this.label_clm.TabIndex = 36;
            this.label_clm.Text = "-------";
            // 
            // label81
            // 
            this.label81.AutoSize = true;
            this.label81.Location = new System.Drawing.Point(108, 167);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(74, 15);
            this.label81.TabIndex = 35;
            this.label81.Text = "current limit:";
            // 
            // label_iacdac
            // 
            this.label_iacdac.AutoSize = true;
            this.label_iacdac.Location = new System.Drawing.Point(126, 192);
            this.label_iacdac.Name = "label_iacdac";
            this.label_iacdac.Size = new System.Drawing.Size(35, 15);
            this.label_iacdac.TabIndex = 34;
            this.label_iacdac.Text = "-------";
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.Location = new System.Drawing.Point(33, 222);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(36, 15);
            this.label82.TabIndex = 33;
            this.label82.Text = "false:";
            // 
            // label_false
            // 
            this.label_false.AutoSize = true;
            this.label_false.Location = new System.Drawing.Point(67, 222);
            this.label_false.Name = "label_false";
            this.label_false.Size = new System.Drawing.Size(35, 15);
            this.label_false.TabIndex = 32;
            this.label_false.Text = "-------";
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.Location = new System.Drawing.Point(43, 190);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(22, 15);
            this.label80.TabIndex = 31;
            this.label80.Text = "iIs:";
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.Location = new System.Drawing.Point(7, 167);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(64, 15);
            this.label79.TabIndex = 30;
            this.label79.Text = "Post Filter:";
            // 
            // label_iIs
            // 
            this.label_iIs.AutoSize = true;
            this.label_iIs.Location = new System.Drawing.Point(67, 192);
            this.label_iIs.Name = "label_iIs";
            this.label_iIs.Size = new System.Drawing.Size(35, 15);
            this.label_iIs.TabIndex = 29;
            this.label_iIs.Text = "-------";
            // 
            // label_postfilter
            // 
            this.label_postfilter.AutoSize = true;
            this.label_postfilter.Location = new System.Drawing.Point(67, 171);
            this.label_postfilter.Name = "label_postfilter";
            this.label_postfilter.Size = new System.Drawing.Size(35, 15);
            this.label_postfilter.TabIndex = 28;
            this.label_postfilter.Text = "-------";
            // 
            // Label_Filter_C_I
            // 
            this.Label_Filter_C_I.AutoSize = true;
            this.Label_Filter_C_I.Location = new System.Drawing.Point(182, 148);
            this.Label_Filter_C_I.Name = "Label_Filter_C_I";
            this.Label_Filter_C_I.Size = new System.Drawing.Size(35, 15);
            this.Label_Filter_C_I.TabIndex = 27;
            this.Label_Filter_C_I.Text = "-------";
            // 
            // Label_IFilter
            // 
            this.Label_IFilter.AutoSize = true;
            this.Label_IFilter.Location = new System.Drawing.Point(67, 145);
            this.Label_IFilter.Name = "Label_IFilter";
            this.Label_IFilter.Size = new System.Drawing.Size(35, 15);
            this.Label_IFilter.TabIndex = 25;
            this.Label_IFilter.Text = "-------";
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(154, 148);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(28, 15);
            this.label73.TabIndex = 26;
            this.label73.Text = "C_I:";
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Location = new System.Drawing.Point(28, 145);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(43, 15);
            this.label74.TabIndex = 24;
            this.label74.Text = "I Filter:";
            // 
            // Label_Filter_C_V
            // 
            this.Label_Filter_C_V.AutoSize = true;
            this.Label_Filter_C_V.Location = new System.Drawing.Point(182, 124);
            this.Label_Filter_C_V.Name = "Label_Filter_C_V";
            this.Label_Filter_C_V.Size = new System.Drawing.Size(35, 15);
            this.Label_Filter_C_V.TabIndex = 23;
            this.Label_Filter_C_V.Text = "-------";
            // 
            // Label_VFilter
            // 
            this.Label_VFilter.AutoSize = true;
            this.Label_VFilter.Location = new System.Drawing.Point(66, 122);
            this.Label_VFilter.Name = "Label_VFilter";
            this.Label_VFilter.Size = new System.Drawing.Size(35, 15);
            this.Label_VFilter.TabIndex = 21;
            this.Label_VFilter.Text = "-------";
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(182, 48);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(35, 15);
            this.label63.TabIndex = 19;
            this.label63.Text = "-------";
            // 
            // iLabel_frq
            // 
            this.iLabel_frq.AutoSize = true;
            this.iLabel_frq.Location = new System.Drawing.Point(182, 95);
            this.iLabel_frq.Name = "iLabel_frq";
            this.iLabel_frq.Size = new System.Drawing.Size(35, 15);
            this.iLabel_frq.TabIndex = 16;
            this.iLabel_frq.Text = "-------";
            // 
            // iLabel_vac
            // 
            this.iLabel_vac.AutoSize = true;
            this.iLabel_vac.Location = new System.Drawing.Point(182, 23);
            this.iLabel_vac.Name = "iLabel_vac";
            this.iLabel_vac.Size = new System.Drawing.Size(35, 15);
            this.iLabel_vac.TabIndex = 13;
            this.iLabel_vac.Text = "-------";
            // 
            // Label_ISelect
            // 
            this.Label_ISelect.AutoSize = true;
            this.Label_ISelect.Location = new System.Drawing.Point(65, 48);
            this.Label_ISelect.Name = "Label_ISelect";
            this.Label_ISelect.Size = new System.Drawing.Size(35, 15);
            this.Label_ISelect.TabIndex = 5;
            this.Label_ISelect.Text = "-------";
            // 
            // iLabel_vdc
            // 
            this.iLabel_vdc.AutoSize = true;
            this.iLabel_vdc.Location = new System.Drawing.Point(64, 23);
            this.iLabel_vdc.Name = "iLabel_vdc";
            this.iLabel_vdc.Size = new System.Drawing.Size(35, 15);
            this.iLabel_vdc.TabIndex = 12;
            this.iLabel_vdc.Text = "-------";
            // 
            // Label_Vmlp
            // 
            this.Label_Vmlp.AutoSize = true;
            this.Label_Vmlp.Location = new System.Drawing.Point(182, 72);
            this.Label_Vmlp.Name = "Label_Vmlp";
            this.Label_Vmlp.Size = new System.Drawing.Size(35, 15);
            this.Label_Vmlp.TabIndex = 11;
            this.Label_Vmlp.Text = "-------";
            // 
            // Label_VSelect
            // 
            this.Label_VSelect.AutoSize = true;
            this.Label_VSelect.Location = new System.Drawing.Point(66, 95);
            this.Label_VSelect.Name = "Label_VSelect";
            this.Label_VSelect.Size = new System.Drawing.Size(35, 15);
            this.Label_VSelect.TabIndex = 7;
            this.Label_VSelect.Text = "-------";
            // 
            // Label_Imlp
            // 
            this.Label_Imlp.AutoSize = true;
            this.Label_Imlp.Location = new System.Drawing.Point(65, 72);
            this.Label_Imlp.Name = "Label_Imlp";
            this.Label_Imlp.Size = new System.Drawing.Size(35, 15);
            this.Label_Imlp.TabIndex = 9;
            this.Label_Imlp.Text = "-------";
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(149, 125);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(32, 15);
            this.label70.TabIndex = 22;
            this.label70.Text = "C_V:";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(105, 95);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(77, 15);
            this.label58.TabIndex = 17;
            this.label58.Text = "(int)       Freq:";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(142, 72);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(41, 15);
            this.label42.TabIndex = 10;
            this.label42.Text = "V mlp:";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(126, 23);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(56, 15);
            this.label57.TabIndex = 4;
            this.label57.Text = "(int)V AC:";
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(115, 47);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(68, 15);
            this.label64.TabIndex = 18;
            this.label64.Text = "AC I Select:";
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(23, 122);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(47, 15);
            this.label68.TabIndex = 20;
            this.label68.Text = "V Filter:";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label56.Location = new System.Drawing.Point(12, 23);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(52, 13);
            this.label56.TabIndex = 4;
            this.label56.Text = "(int)V DC:";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(15, 95);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(54, 15);
            this.label40.TabIndex = 6;
            this.label40.Text = "V Select:";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(33, 72);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(37, 15);
            this.label44.TabIndex = 8;
            this.label44.Text = "I mlp:";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(1, 48);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(70, 15);
            this.label38.TabIndex = 4;
            this.label38.Text = "DC I Select:";
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.Label_vdc_real);
            this.groupBox14.Controls.Add(this.button6);
            this.groupBox14.Controls.Add(this.label59);
            this.groupBox14.Controls.Add(this.Label_idc);
            this.groupBox14.Controls.Add(this.label39);
            this.groupBox14.Controls.Add(this.Label_frq);
            this.groupBox14.Controls.Add(this.label35);
            this.groupBox14.Controls.Add(this.label37);
            this.groupBox14.Controls.Add(this.Label_vdc);
            this.groupBox14.Controls.Add(this.Label_vac);
            this.groupBox14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.groupBox14.Location = new System.Drawing.Point(8, 5);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(246, 140);
            this.groupBox14.TabIndex = 4;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Outputs";
            // 
            // Label_vdc_real
            // 
            this.Label_vdc_real.AutoSize = true;
            this.Label_vdc_real.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_vdc_real.Location = new System.Drawing.Point(158, 18);
            this.Label_vdc_real.Name = "Label_vdc_real";
            this.Label_vdc_real.Size = new System.Drawing.Size(35, 15);
            this.Label_vdc_real.TabIndex = 18;
            this.Label_vdc_real.Text = "-------";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(195, 111);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(48, 23);
            this.button6.TabIndex = 0;
            this.button6.Text = "test";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Visible = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label59.Location = new System.Drawing.Point(20, 48);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(33, 15);
            this.label59.TabIndex = 16;
            this.label59.Text = "I DC:";
            // 
            // Label_idc
            // 
            this.Label_idc.AutoSize = true;
            this.Label_idc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_idc.Location = new System.Drawing.Point(77, 48);
            this.Label_idc.Name = "Label_idc";
            this.Label_idc.Size = new System.Drawing.Size(35, 15);
            this.Label_idc.TabIndex = 17;
            this.Label_idc.Text = "-------";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.Location = new System.Drawing.Point(22, 108);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(67, 15);
            this.label39.TabIndex = 14;
            this.label39.Text = "Frequency:";
            // 
            // Label_frq
            // 
            this.Label_frq.AutoSize = true;
            this.Label_frq.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_frq.Location = new System.Drawing.Point(116, 108);
            this.Label_frq.Name = "Label_frq";
            this.Label_frq.Size = new System.Drawing.Size(35, 15);
            this.Label_frq.TabIndex = 15;
            this.Label_frq.Text = "-------";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(20, 19);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(37, 15);
            this.label35.TabIndex = 0;
            this.label35.Text = "V DC:";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(20, 76);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(35, 15);
            this.label37.TabIndex = 2;
            this.label37.Text = "V AC:";
            // 
            // Label_vdc
            // 
            this.Label_vdc.AutoSize = true;
            this.Label_vdc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_vdc.Location = new System.Drawing.Point(77, 19);
            this.Label_vdc.Name = "Label_vdc";
            this.Label_vdc.Size = new System.Drawing.Size(35, 15);
            this.Label_vdc.TabIndex = 1;
            this.Label_vdc.Text = "-------";
            // 
            // Label_vac
            // 
            this.Label_vac.AutoSize = true;
            this.Label_vac.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_vac.Location = new System.Drawing.Point(77, 76);
            this.Label_vac.Name = "Label_vac";
            this.Label_vac.Size = new System.Drawing.Size(35, 15);
            this.Label_vac.TabIndex = 3;
            this.Label_vac.Text = "-------";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.DebugListBox);
            this.groupBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.groupBox9.Location = new System.Drawing.Point(11, 151);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(243, 276);
            this.groupBox9.TabIndex = 18;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Log file";
            // 
            // DebugListBox
            // 
            this.DebugListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DebugListBox.FormattingEnabled = true;
            this.DebugListBox.ItemHeight = 15;
            this.DebugListBox.Location = new System.Drawing.Point(3, 17);
            this.DebugListBox.Name = "DebugListBox";
            this.DebugListBox.Size = new System.Drawing.Size(237, 256);
            this.DebugListBox.TabIndex = 17;
            this.DebugListBox.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.DebugListBox_MeasureItem);
            this.DebugListBox.SelectedValueChanged += new System.EventHandler(this.DebugListBox_SelectedValueChanged);
            // 
            // PreproccessingTimer
            // 
            this.PreproccessingTimer.Interval = 500;
            this.PreproccessingTimer.Tick += new System.EventHandler(this.PreproccessingTimer_Tick);
            // 
            // Desktop
            // 
            this.Desktop.AutoScroll = true;
            this.Desktop.BackColor = System.Drawing.Color.Lavender;
            this.Desktop.BackgroundImage = global::EISProjects.Properties.Resources.background;
            this.Desktop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Desktop.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Desktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Desktop.Location = new System.Drawing.Point(286, 100);
            this.Desktop.Name = "Desktop";
            this.Desktop.Size = new System.Drawing.Size(307, 435);
            this.Desktop.TabIndex = 4;
            this.Desktop.MouseEnter += new System.EventHandler(this.Desktop_MouseEnter);
            this.Desktop.MouseLeave += new System.EventHandler(this.Desktop_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1028, 100);
            this.panel1.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1028, 605);
            this.Controls.Add(this.Desktop);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Panel101);
            this.Controls.Add(this.StatusPanel);
            this.Controls.Add(this.panel1);
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.Text = "LMS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.tabControl1.ResumeLayout(false);
            this.TabFile.ResumeLayout(false);
            this.TabEdit.ResumeLayout(false);
            this.TabWindow.ResumeLayout(false);
            this.TabTools.ResumeLayout(false);
            this.groupBox15.ResumeLayout(false);
            this.TabOffset.ResumeLayout(false);
            this.TabHelp.ResumeLayout(false);
            this.TabLogin.ResumeLayout(false);
            this.TabLogin.PerformLayout();
            this.StatusPanel.ResumeLayout(false);
            this.StatusPanel.PerformLayout();
            this.Panel101.ResumeLayout(false);
            this.PanelProperties.ResumeLayout(false);
            this.PanelProperties.PerformLayout();
            this.GBPostprocessing.ResumeLayout(false);
            this.GBPostprocessing.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.GBExport.ResumeLayout(false);
            this.GBExport.PerformLayout();
            this.GBPulse.ResumeLayout(false);
            this.GBPulse.PerformLayout();
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.GBEIS.ResumeLayout(false);
            this.GBEIS.PerformLayout();
            this.GBVoltages.ResumeLayout(false);
            this.GBVoltages.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.GBFrequency.ResumeLayout(false);
            this.GBFrequency.PerformLayout();
            this.GBIV.ResumeLayout(false);
            this.GBIV.PerformLayout();
            this.GBCV.ResumeLayout(false);
            this.GBCV.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.GBPreprocessing.ResumeLayout(false);
            this.GBPreprocessing.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.Prop.ResumeLayout(false);
            this.Prop.PerformLayout();
            this.CMSSession.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.GBAdminLog.ResumeLayout(false);
            this.GBAdminLog.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TabFile;
        private System.Windows.Forms.TabPage TabEdit;
        private System.Windows.Forms.TabPage TabWindow;
        private System.Windows.Forms.TabPage TabHelp;
        private System.Windows.Forms.Button BtnDiagram;
        private System.Windows.Forms.Button BtnPort;
        private System.Windows.Forms.Panel StatusPanel;
        private System.Windows.Forms.TabPage TabTools;
        private System.Windows.Forms.Panel Panel101;
        private System.Windows.Forms.Panel PanelProperties;
        private System.Windows.Forms.Panel Prop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnCreateSession;
        private System.Windows.Forms.Panel Desktop;
        private System.Windows.Forms.Button BtnAbout;
        private System.Windows.Forms.TextBox TBSsnName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ChBActive;
        private System.Windows.Forms.GroupBox GBFrequency;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox TBACFrqNStep;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TBACFrqTo;
        private System.Windows.Forms.TextBox TBACFrqFrom;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TBACAmpConstant;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox GBVoltages;
        private System.Windows.Forms.TextBox TBDCVoltageConstant;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnRun;
        private System.Windows.Forms.GroupBox GBExport;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox ChBExport;
        private System.Windows.Forms.ProgressBar PBAllSessions;
        private System.Windows.Forms.Button BtnFitt;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnOpen;
        private System.Windows.Forms.Button BtnNew;
        private System.Windows.Forms.Button BtnSaveAs;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button BtnImport;
        private System.Windows.Forms.Button BtnAppend;
        private System.Windows.Forms.Button BtnSsnExpLocation;
        private System.Windows.Forms.SaveFileDialog saveFileDialogSSnExp;
        private System.Windows.Forms.Label ExpWarningLable;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CBMode;
        private System.Windows.Forms.Button BtnDuplicate;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.ContextMenuStrip CMSSession;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem duplicateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportDataToolStripMenuItem;
        private System.Windows.Forms.Button BtnPauseContinue;
        private System.Windows.Forms.Button BtnShowData;
        private System.Windows.Forms.GroupBox GBCV;
        private System.Windows.Forms.TextBox TBCVDCVltCnst;
        private System.Windows.Forms.TextBox TBCVACFrqCnst;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox TBCVACAmpStp;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox TBCVACAmpTo;
        private System.Windows.Forms.TextBox TBCVACAmpFrm;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.GroupBox GBPulse;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TBMSCHACAmpCnst;
        private System.Windows.Forms.TextBox TBMSCHACFrqCnst;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TBMSCHDCVStp;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TBMSCHDCVTo;
        private System.Windows.Forms.TextBox TBMSCHDCVFrm;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox GBEIS;
        private System.Windows.Forms.GroupBox GBIV;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox TBIVVoltageStep;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox TBIVVoltageTo;
        private System.Windows.Forms.TextBox TBIVVoltageFrom;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox CBIVRange;
        private System.Windows.Forms.TextBox TBTimeStep;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Timer IVTimer;
        private System.Windows.Forms.ComboBox CBEISMode;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.ComboBox CBIVVoltageRangeMode;
        private System.Windows.Forms.ComboBox CBEISOCMode;
        private System.Windows.Forms.ComboBox CBEISFilterMode;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ComboBox CBEISVoltageRangeMode;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.ComboBox CBEISACRegulatorMode;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.ComboBox CBEISDCCurrentRangeMode;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button SampleOnBtn;
        private System.Windows.Forms.Label ProbWarningLabel;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.ComboBox IMLP;
        private System.Windows.Forms.ComboBox VMLP;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label LabelVwar;
        private System.Windows.Forms.Label LabelIwar;
        private System.Windows.Forms.Button DummyOnBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label iLabel_vac;
        private System.Windows.Forms.Label iLabel_vdc;
        private System.Windows.Forms.Label Label_Vmlp;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label Label_Imlp;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label Label_VSelect;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label Label_ISelect;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label Label_vac;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label Label_vdc;
        private System.Windows.Forms.Label iLabel_frq;
        private System.Windows.Forms.Label Label_frq;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.ListBox DebugListBox;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox TBIVVelosity;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.ComboBox CBEISACCurrentRangeMode;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox GBAdminLog;
        public System.Windows.Forms.Button BtnVirtualMachine;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.Button BtnSetting;
        private System.Windows.Forms.TabPage TabLogin;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.TextBox TBLogin;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Button BtnLogout;
        private System.Windows.Forms.Label labellogedin;
        private System.Windows.Forms.CheckBox ChBRelRef;
        private System.Windows.Forms.GroupBox GBPostprocessing;
        private System.Windows.Forms.GroupBox GBPreprocessing;
        private System.Windows.Forms.CheckBox ChBOCT;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.TextBox TBEqTime;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Timer PreproccessingTimer;
        private System.Windows.Forms.Button CheckPID;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label LabelVOCT;
        private System.Windows.Forms.Button BtnFindOCP;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Button BtnUseSuggestedVOCP;
        private System.Windows.Forms.Label LabelSuggestedVOCP;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.TextBox TBVOCP;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.MaskedTextBox maskedTextBox2;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox BtnEISAveNum;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button BtnOffsetRemoval;
        public System.Windows.Forms.Button BtnTerminal;
        private System.Windows.Forms.TextBox BtnEISAveNumH;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Label Label_idc;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.ComboBox CBEISMaxImlp;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.ComboBox CBEISMaxVmlp;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.Button BtnRunS;
        private System.Windows.Forms.Button BtnSaveOffsetSettings;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.TextBox TBIdealVoltage;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.ComboBox CB_PGMode;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.CheckBox ChBOCPAutoStart;
        private System.Windows.Forms.Button BtnRecoverSettings;
        private System.Windows.Forms.Button BtnBackupSettings;
        private System.Windows.Forms.Label Label_Filter_C_I;
        private System.Windows.Forms.Label Label_IFilter;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.Label Label_Filter_C_V;
        private System.Windows.Forms.Label Label_VFilter;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.CheckBox ChBisCVEnable;
        private System.Windows.Forms.TextBox TB_CV_Itteration;
        private System.Windows.Forms.TextBox TB_CV_StartPoint;
        private System.Windows.Forms.CheckBox ChBPostProcProbOff;
        private System.Windows.Forms.CheckBox ChBPreProcProbOn;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.TextBox TBPretreatmentVoltage;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox ChBChronoFastMode;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.ComboBox CBPulseCurrentRangeMode;
        private System.Windows.Forms.ComboBox CBPulseImlp;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.ComboBox CBPulseVoltageRangeMode;
        private System.Windows.Forms.ComboBox CBPulseVmlp;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.GroupBox groupBox18;
        private System.Windows.Forms.RadioButton RB_Leading;
        private System.Windows.Forms.RadioButton RB_Trailing;
        private System.Windows.Forms.RadioButton RB_Differential;
        private System.Windows.Forms.Label WarnLabel;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button btnChronoTiming;
        public System.Windows.Forms.Label MaxUnitLabel;
        public System.Windows.Forms.Label MinUnitLabel;
        private System.Windows.Forms.TabPage TabOffset;
        private System.Windows.Forms.TextBox TBIVVoltagedV;
        private System.Windows.Forms.Label label76;
        public System.Windows.Forms.Label StepUnitLabel;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.ComboBox IVChronoVFilter;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.ComboBox PlseVFilter;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.Label label_iIs;
        private System.Windows.Forms.Label label_postfilter;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.Label Label_vdc_real;
        private System.Windows.Forms.Button button_earth;
        private System.Windows.Forms.Button button_notch;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label82;
        private System.Windows.Forms.Label label_false;
        private System.Windows.Forms.Label label_per;
        private System.Windows.Forms.Label label_iacdac;
        private System.Windows.Forms.Label label_clm;
        private System.Windows.Forms.Label label81;
        private System.Windows.Forms.Button button_clm;
    }


    internal class EIS
    {
        private static bool _ready = true;
        private static bool _Connected = true;
        private static bool _ReceiveMode = false;
        private static bool _RunCompleted = false;
        private static int _nSsn = 0;
        private static int _RunningSession = 0;
        private static int _ReScaleFactor=1000;
        private static bool _isFile = false;
        private static string _FileName = "";

        public static bool ready
        {
            get { return _ready; }
            set { _ready = value; }
        }

        public static bool Connected
        {
            get { return _Connected; }
            set { _Connected = value; }
        }

        public static bool ReceiveMode
        {
            get { return _ReceiveMode; }
            set { _ReceiveMode = value; }
        }

        public static bool RunCompleted
        {
            get { return _RunCompleted; }
            set { _RunCompleted = value; }
        }

        public static int nSsn
        {
            get { return _nSsn; }
            set { _nSsn = value; }
        }

        public static int RunningSession
        {
            get { return _RunningSession; }
            set { _RunningSession = value; }
        }

        public static int ReScaleFactor
        {
            get { return _ReScaleFactor; }
            set { _ReScaleFactor = value; }
        }

        public static bool isFile
        {
            get { return _isFile; }
            set { _isFile = value; }
        }

        public static string FileName
        {
            get { return _FileName; }
            set { _FileName = value; }
        }
    }

    public class SettingsData
    {
        public int SetDCV_Offset;
        public float SetDCV_Domain;
        public float SetDCV_factor;

        public float GetDCV_OffsetMLP0;
        public float GetDCV_OffsetMLP1;
        public float GetDCV_OffsetMLP2;
        public float GetDCV_OffsetMLP3;
        public float GetDCV_OffsetMLP4;
        public float GetDCV_offsetMLP5;
        public float GetDCV_OffsetMLP6;
        public float GetDCV_Domain;
        public float GetDCV_factor;

        public int SetDCI_Offset;
        public float SetDCI_Domain;
        public float SetDCI_Select0;
        public float SetDCI_Select1;
        public float SetDCI_Select2;
        public float SetDCI_factor;

        public float GetDCI_Offset0d;
        public float GetDCI_Offset1d;
        public float GetDCI_Offset2;
        public float GetDCI_Offset3d;
        public float GetDCI_Offset4d;
        public float GetDCI_Offset5d;
        public float GetDCI_Offset6d;
        public float GetDCI_Offset7d;
        public float GetDCI_Domain;
        public float GetDCI_Select0;
        public float GetDCI_Select1;
        public float GetDCI_select2;
        public float GetDCI_Select3;
        public float GetDCI_Select4;
        public float GetDCI_Select5;
        public float GetDCI_Select6;
        public float GetDCI_Select7;
        public float GetDCI_factor;

        public int SetDigitalACV_Offset;
        public float SetDigitalACV_Domain;
        public float SetDigitalACV_factor;

        public int GetDigitalACV_Offset;
        public float GetDigitalACV_Domain;
        public float GetDigitalACV_factor;

        public float SetDigitalf_Min;
        public float SetDigitalf_Max;
        public int SetDigitalf_clock;
        public float SetDigitalf_factor;

        public float GetDigitalf_Min;
        public float GetDigitalf_Max;
        public int GetDigitalf_clock;
        public float GetDigitalf_factor;

        public int AnalogCommon_intOffset;
        public float AnalogCommon_Domain;
        public float AnalogCommon_factor;

        //public int Zeroset;
        public int Zeroset0;
        public int Zeroset1;

        public bool isEIS = false;
        public bool isMSH = false;
        public bool isCV = false;
        public bool isIV0 = false;
        public bool isChrono = false;
        public bool isPulse = false;

        public int Version;
        public bool IsIVReceiverUnsigned;
        public bool isDigitalEISReceiverUnsigned;

        public float GalvanostatI_Select4;
        public float GalvanostatI_Select5;
        public float GalvanostatI_Select6;
        public float GalvanostatI_Select7;

        public float GalvanostatI_Select0;
        public float GalvanostatI_Select1;
        public float GalvanostatI_Select2;
        public float GalvanostatI_Select3;

        public float SetDCV_Select0;
        public float SetDCV_Select1;

        public float GetDCV_Select0;
        public float GetDCV_Select1;

        public float ACMultFactor_Select0;
        public float ACMultFactor_Select1;

        public float FilterC_V1;
        public float FilterC_V2;

        public float FilterC_I1;
        public float FilterC_I2;

        public float SetACVMaxS0;
        public int SetACVResoloution;

        public float GetACVMaxS0;
        public int GetACVResoloution0;

        public float DEISMeanPercent;
        public int DEISNOverFlow0;

        public float VTau_L;
        public float VTau_H;
        public float ITau_L0;
        public float ITau_H0;
        public float ITau_L1;
        public float ITau_H1;
        public float ITau_L2;
        public float ITau_H2;
    }

    public class Sessions
    {
        public string name = "";
        public string DataAndTime = "";
        public bool active = true;
        public bool isCVEnable = false;
        public double V_OCT = 0.0;
        public double IdealVoltage = 0.0;
        public bool isOCP = false;
        public bool isOCPAutoStart = false;
        public int PGmode = 1;
        public bool RelRef = false;
        public int EqTime = 0;

        public int index = 0;

        public int Mode = 0; //Mode=0 Frequency varies

        public bool isDCVoltageConstant = true;
        public double DCVoltageConstant = 0.0;
        public double DCVoltageFrom = 0.0;
        public double DCVoltageTo = 0.0;
        public int DCVoltageStep = 0;

        public bool isACAmpConstant = true;
        public double ACAmpConstant = 0.0;
        public double ACAmpFrom = 0.0;
        public double ACAmpTo = 0.0;
        public double ACAmpStep = 0.0;

        public bool isACFrqConstant = false;
        public double ACFrqConstant = 0.0;
        public double ACFrqFrom = 0.0;
        public double ACFrqTo = 0.0;
        public int ACFrqNStep = 0;


        public int IVCurrentRangeMode = 0;
        public int IVVmlp = 0;
        public int IVImlp = 0;
        public double IVVoltageFrom = 0.0;
        public double IVvoltageTo = 0.0;
        public double ChronoEndTime = 0.0;
        public int IVVoltageNStepp = 0;
        public double CVStartpoint = 0;
        public double PretreatmentVoltage = 0;
        public bool isPreProcProbOn = true;
        public bool isChBPostProcProbOff = true;
        public int CVItteration = 0;
        public int IVTimestep = 0;
        public int Chrono_n = 0;
        public double Chrono_Total_Period = 0;
        public double Chrono_Pulse_Period = 0;
        public double Chrono_Pulse_Level = 0;
        public double Chrono_Pulse_Amplitude = 0;
        public double Chrono_Level_Step = 0;
        public double Chrono_Amplitude_step = 0;
        public bool Chrono_isfast = false;

        public int Chrono_nsteps = 0;

        public double Chrono_t1 = 0;
        public double Chrono_t2 = 0;
        public double Chrono_t3 = 0;
        public double Chrono_t4 = 0;
        public double Chrono_t5 = 0;
        public double Chrono_t6 = 0;
        public double Chrono_t7 = 0;
        public double Chrono_t8 = 0;
        public double Chrono_t9 = 0;
        public double Chrono_t10 = 0;

        public double Chrono_v1 = 0;
        public double Chrono_v2 = 0;
        public double Chrono_v3 = 0;
        public double Chrono_v4 = 0;
        public double Chrono_v5 = 0;
        public double Chrono_v6 = 0;
        public double Chrono_v7 = 0;
        public double Chrono_v8 = 0;
        public double Chrono_v9 = 0;
        public double Chrono_v10 = 0;

        public double Chrono_dt = 0;

        public bool Chrono_ocp1 = false;
        public bool Chrono_ocp2 = false;
        public bool Chrono_ocp3 = false;
        public bool Chrono_ocp4 = false;
        public bool Chrono_ocp5 = false;
        public bool Chrono_ocp6 = false;
        public bool Chrono_ocp7 = false;
        public bool Chrono_ocp8 = false;
        public bool Chrono_ocp9 = false;
        public bool Chrono_ocp10 = false;
        
        public bool isStarted = false;
        public bool isFinished = false;

        public bool isExportAtFinal= false;
        public string ExportAtFinalDIR = "";

        public int EISMode = 0;
        public int EISfilterMode = 0;
        public int EISAverageNumberL = 1;
        public int EISAverageNumberH = 1;
        public int EISOCMode = 0;
        public int EISVoltageRangeMode = 0;
        public int EISDCCurrentRangeModea = 0;
        public int EISACRegulatorMode = 0;
        public int EISACCurrentRangeMode = 0;
        public int EISVmlpMax = 0;
        public int EISImlpMax = 0;
        public int IVVoltageRangeMode = 0;
        public int IVChrono_VFilter = 0;
        public int Pulse_VFilter = 0;

        public int PulseVoltageRangeMode = 0;
        public int PulseCurrentRangeMode = 0;
        public int PulseVmlp = 0;
        public int PulseImlpp = 0;
        public int PulseReadingEdgemode = 0;
        public int PulseVoltammetryMode = 0;

        public int nCircuits = 0;
        public List<Circuit> Circuits = new List<Circuit> { };
    }

    public class FactoryDefaults
    {
        public bool active = true;
        public bool isCVEnable = false;
        public double V_OCT = 0.0;
        public double IdealVoltage = 0.0;
        public bool isOCP = false;
        public bool isOCPAutoStart = false;
        public int PGmode = 1;
        public bool RelRef = true;
        public int EqTime = 3;

        public bool isDCVoltageConstant = true;
        public double DCVoltageConstant = 0.0;
        public double DCVoltageFrom = -0.5;
        public double DCVoltageTo = 0.5;
        public int DCVoltageStep = 100;

        public bool isACAmpConstant = true;
        public double ACAmpConstant = 0.02;
        public double ACAmpFrom = 0.5;
        public double ACAmpTo = 30.0;
        public double ACAmpStep = 0.1;

        public bool isACFrqConstant = false;
        public double ACFrqConstant = 1000;
        public double ACFrqFrom = 1.0;
        public double ACFrqTo = 100000.0;
        public int ACFrqNStep = 100;

        public int IVCurrentRangeMode = 0;
        public int IVVmlp = 0;
        public int IVImlp = 0;
        public double IVVoltageFrom = -0.5;
        public double IVvoltageTo = 0.5;
        public double ChronoEndTime = 1.0;
        public int IVVoltageNStepp = 101;
        public double CVStartpoint = 0;
        public double PretreatmentVoltage = 0;
        public bool isPreProcProbOn = true;
        public bool isChBPostProcProbOff = true;
        public int CVItteration = 2;
        public int IVTimestep = 100;
        public int Chrono_n = 38;
        public double Chrono_Total_Period = 500;
        public double Chrono_Pulse_Period = 250;
        public double Chrono_Pulse_Level = -1.0;
        public double Chrono_Pulse_Amplitude = 0.1;
        public double Chrono_Level_Step = 0;
        public double Chrono_Amplitude_step = 0.05;
        public bool Chrono_isfast = false;

        public int Chrono_nsteps = 1;

        public double Chrono_t1 = 1;
        public double Chrono_t2 = 1;
        public double Chrono_t3 = 1;
        public double Chrono_t4 = 1;
        public double Chrono_t5 = 1;
        public double Chrono_t6 = 1;
        public double Chrono_t7 = 1;
        public double Chrono_t8 = 1;
        public double Chrono_t9 = 1;
        public double Chrono_t10 = 1;

        public double Chrono_v1 = 1;
        public double Chrono_v2 = 1;
        public double Chrono_v3 = 1;
        public double Chrono_v4 = 1;
        public double Chrono_v5 = 1;
        public double Chrono_v6 = 1;
        public double Chrono_v7 = 1;
        public double Chrono_v8 = 1;
        public double Chrono_v9 = 1;
        public double Chrono_v10 = 1;

        public double Chrono_dt = 10.0;

        public bool Chrono_ocp1 = false;
        public bool Chrono_ocp2 = false;
        public bool Chrono_ocp3 = false;
        public bool Chrono_ocp4 = false;
        public bool Chrono_ocp5 = false;
        public bool Chrono_ocp6 = false;
        public bool Chrono_ocp7 = false;
        public bool Chrono_ocp8 = false;
        public bool Chrono_ocp9 = false;
        public bool Chrono_ocp10 = false;

        public int EISMode = 1;
        public int EISfilterMode = 0;
        public int EISAverageNumberL = 1;
        public int EISAverageNumberH = 3;
        public int EISOCMode = 1;
        public int EISVoltageRangeMode = 1;
        public int EISDCCurrentRangeModea = 0;
        public int EISACRegulatorMode = 1;
        public int EISACCurrentRangeMode = 0;
        public int EISVmlpMax = 6;
        public int EISImlpMax = 3;
        public int IVVoltageRangeMode = 1;
        public int IVChrono_VFilter = 3;
        public int Pulse_VFilter = 3;

        public int PulseVoltageRangeMode = 1;
        public int PulseCurrentRangeMode = 0;
        public int PulseVmlp = 0;
        public int PulseImlpp = 0;
        public int PulseReadingEdgemode = 1;
        public int PulseVoltammetryMode = 0;

        public int CheckPortTimeoutSec = 100;
        public int PortTimeout = 5000;
        public int ReScaleFactor = 100;

        //settings
        public int SetDCV_Offset = 2047;
        public float SetDCV_Domain = -5.0f;
        public float SetDCV_factor = 1.0f;

        public float GetDCV_OffsetMLP0 = 0;
        public float GetDCV_OffsetMLP1 = 0;
        public float GetDCV_OffsetMLP2 = 0;
        public float GetDCV_OffsetMLP3 = 0;
        public float GetDCV_OffsetMLP4 = 0;
        public float GetDCV_offsetMLP5 = 0;
        public float GetDCV_OffsetMLP6 = 0;
        public float GetDCV_Domain = 11.0f;
        public float GetDCV_factor = 1.0f;

        public int SetDCI_Offset = 2047;
        public float SetDCI_Domain = 1.0f;
        public float SetDCI_Select0 = 1.0f;
        public float SetDCI_Select1 = 100.0f;
        public float SetDCI_Select2 = 10000.0f;
        public float SetDCI_factor = 1.0f;

        public float GetDCI_Offset0d = 0;
        public float GetDCI_Offset1d = 0;
        public float GetDCI_Offset2 = 0;
        public float GetDCI_Offset3d = 0;
        public float GetDCI_Offset4d = 0;
        public float GetDCI_Offset5d = 0;
        public float GetDCI_Offset6d = 0;
        public float GetDCI_Offset7d = 0;
        public float GetDCI_Domain = 1.0f;
        public float GetDCI_Select0 = 1.0f;
        public float GetDCI_Select1 = 10.0f;
        public float GetDCI_select2 = 100.0f;
        public float GetDCI_Select3 = 1000.0f;
        public float GetDCI_Select4 = 10000.0f;
        public float GetDCI_Select5 = 100000.0f;
        public float GetDCI_Select6 = 1000000.0f;
        public float GetDCI_Select7 = 10000000.0f;
        public float GetDCI_factor = 1.0f;

        public int SetDigitalACV_Offset = 0;
        public float SetDigitalACV_Domain = 100.0f;  //in mV
        public float SetDigitalACV_factor = 1.0f;

        public int GetDigitalACV_Offset = 0;
        public float GetDigitalACV_Domain = 100.0f;
        public float GetDigitalACV_factor = 1.0f;

        public float SetDigitalf_Min = 0.1192093f;
        public float SetDigitalf_Max = 200000.0f;
        public int SetDigitalf_clock = 32000000;
        public float SetDigitalf_factor = 1.0f;

        public float GetDigitalf_Min = 0.1192093f;
        public float GetDigitalf_Max = 200000.0f;
        public int GetDigitalf_clock = 32000000;
        public float GetDigitalf_factor = 1.0f;

        public int AnalogCommon_intOffset = 8388607;
        public float AnalogCommon_Domain = 2.5f;
        public float AnalogCommon_factor = 1.0f;
        //Domain set -5
        //zeroset 1500
        //get v domain 11
        //get I domain 1
        public int Zeroset0 = 1500;
        public int Zeroset1 = 1500;

        public bool isEIS = false;
        public bool isMSH = false;
        public bool isCV = false;
        public bool isIV0 = true;
        public bool isChrono = false;
        public bool isPulse = false;

        public bool isIVReceiverUnsigned = false;
        public bool isDigitalEISReceiverUnsigned = false;

        public float GalvanostatI_Select4 = 2048.0f; //changed
        public float GalvanostatI_Select5 = 2048.0f; //changed
        public float GalvanostatI_Select6 = 2048.0f; //changed
        public float GalvanostatI_Select7 = 2048.0f; //changed

        public float GalvanostatI_Select0 = 2048.0f; //changed
        public float GalvanostatI_Select1 = 2048.0f; //changed
        public float GalvanostatI_Select2 = 2048.0f; //changed
        public float GalvanostatI_Select3 = 2048.0f; //changed

        public float SetDCV_Select0 = 1.0f;
        public float SetDCV_Select1 = 0.2f;

        public float GetDCV_Select0 = 1.0f;
        public float GetDCV_Select1 = 0.2f;

        public float ACMultFactor_Select0 = 5.0f;
        public float ACMultFactor_Select1 = 5.0f;

        public float FilterC_V1 = 1.0f;
        public float FilterC_V2 = 100.0f;

        public float FilterC_I1 = 1.0f;
        public float FilterC_I2 = 100.0f;

        public float SetACVMaxS0 = 1.0f;
        public int SetACVResoloution = 255;

        public float GetACVMaxS0 = 1;
        public int GetACVResoloution0 = 255;

        public float DEISMeanPercent = 35.0f;
        public int DEISNOverFlow0 = 20;

        public float VTau_L = 10.0f;
        public float VTau_H = 0.0f;
        public float ITau_L0 = 10.0f;
        public float ITau_H0 = 0.0f;
        public float ITau_L1 = 10.0f;
        public float ITau_H1 = 0.0f;
        public float ITau_L2 = 10.0f;
        public float ITau_H2 = 0.0f;
    }

    public class SessionOutputData
    {
        public int DCVltDim;
        public int ACAmpDim;
        public int ACFrqDim;
        public int IVAmpDim;

        public int ReceivedDataCount=0;
        public double[] Vlt;
        public double[] Amp;
        public double[] Frq;
        public double[] ReZ;
        public double[] Imz;
        public bool[] overflow;

        public double OpenCircuitVoltage = 0.0;
    }

    public class Element
    {
        public int Mode = 1;//Resistor=1 Capacitor=2 Inductor=3

        public double Val = 1;   //Resistor=R Capacitor=C Inductor=L
        public double Val2 = 1;

        public string name = "";

        public int Input = 0;
        public int Output = 0;

        public int InputGraph = -1;
        public int OutputGraph = -1;

        public int HashCode = 0;

        public int X;
        public int Y;
    }

    public class GraphLine
    {
        public GraphLine(float x1, float y1, float x2, float y2)
        {
            this.StartPoint = new PointF(x1, y1);
            this.EndPoint = new PointF(x2, y2);
        }
        public PointF StartPoint;
        public PointF EndPoint;
    }

    public class Link
    {
        public int i;
        public int j;

        public int iElement;
        public int jElement;
    }

    public class Circuit
    {
        public bool isTrue = false;
        public bool isFitted = false;

        public int Input = 0;
        public int Output = 0;

        public int nElements = 0;
        public List<Element> Elements = new List<Element> { };

        public int nLinks = 0;
        public List<Link> Links = new List<Link>() { };

        public int nGraphPoint = 0;

        public string name = "";

        public int FitMethod = 1;
        public string FitMethodName = "";

        public List<SameGraphPoints> AllSameGraph = new List<SameGraphPoints>() { };

        public bool isReadyToFit = false;
    }

    public class SameGraphPoints
    {
        public List<int> Points = new List<int>() { };
    }
}

