namespace EISProjects
{
    partial class Form3
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.CBVoltammetryMode = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RB_Differential = new System.Windows.Forms.RadioButton();
            this.RB_Leading = new System.Windows.Forms.RadioButton();
            this.RB_Trailing = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.El = new System.Windows.Forms.Label();
            this.swcolon = new System.Windows.Forms.Label();
            this.swl = new System.Windows.Forms.Label();
            this.HzLabel = new System.Windows.Forms.Label();
            this.NUD_Frequency = new System.Windows.Forms.NumericUpDown();
            this.frql = new System.Windows.Forms.Label();
            this.u5 = new System.Windows.Forms.Label();
            this.u4 = new System.Windows.Forms.Label();
            this.u3 = new System.Windows.Forms.Label();
            this.u2 = new System.Windows.Forms.Label();
            this.u1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.u6 = new System.Windows.Forms.Label();
            this.NUD_TotalPeriod = new System.Windows.Forms.NumericUpDown();
            this.NUD_ScanRate = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.NUD_FinalPotential = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.NUD_pulsenumber = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.NUD_PulsePeriod = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.NUD_PulseAmp = new System.Windows.Forms.NumericUpDown();
            this.NUD_AmpStep = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.NUD_PulseLevel = new System.Windows.Forms.NumericUpDown();
            this.NUD_LevelStep = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.WarnLabel = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.u7 = new System.Windows.Forms.Label();
            this.NUD_Esw = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Frequency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_TotalPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_ScanRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_FinalPotential)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_pulsenumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_PulsePeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_PulseAmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_AmpStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_PulseLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_LevelStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Esw)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.CBVoltammetryMode);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(329, 479);
            this.panel1.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(63, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 17);
            this.label8.TabIndex = 18;
            this.label8.Text = "Mode:";
            // 
            // CBVoltammetryMode
            // 
            this.CBVoltammetryMode.FormattingEnabled = true;
            this.CBVoltammetryMode.Items.AddRange(new object[] {
            "Normal Pulse",
            "Differential Pulse",
            "Square Wave",
            "Custum"});
            this.CBVoltammetryMode.Location = new System.Drawing.Point(117, 14);
            this.CBVoltammetryMode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CBVoltammetryMode.Name = "CBVoltammetryMode";
            this.CBVoltammetryMode.Size = new System.Drawing.Size(140, 24);
            this.CBVoltammetryMode.TabIndex = 21;
            this.CBVoltammetryMode.SelectedIndexChanged += new System.EventHandler(this.CBVoltammetryMode_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RB_Differential);
            this.groupBox2.Controls.Add(this.RB_Leading);
            this.groupBox2.Controls.Add(this.RB_Trailing);
            this.groupBox2.Location = new System.Drawing.Point(8, 384);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(311, 87);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Measurment";
            // 
            // RB_Differential
            // 
            this.RB_Differential.AutoSize = true;
            this.RB_Differential.Location = new System.Drawing.Point(95, 58);
            this.RB_Differential.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RB_Differential.Name = "RB_Differential";
            this.RB_Differential.Size = new System.Drawing.Size(97, 21);
            this.RB_Differential.TabIndex = 19;
            this.RB_Differential.Text = "Differential";
            this.RB_Differential.UseVisualStyleBackColor = true;
            this.RB_Differential.CheckedChanged += new System.EventHandler(this.RB_Differential_CheckedChanged);
            // 
            // RB_Leading
            // 
            this.RB_Leading.AutoSize = true;
            this.RB_Leading.Location = new System.Drawing.Point(168, 26);
            this.RB_Leading.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RB_Leading.Name = "RB_Leading";
            this.RB_Leading.Size = new System.Drawing.Size(106, 21);
            this.RB_Leading.TabIndex = 18;
            this.RB_Leading.Text = "Falling edge";
            this.RB_Leading.UseVisualStyleBackColor = true;
            this.RB_Leading.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // RB_Trailing
            // 
            this.RB_Trailing.AutoSize = true;
            this.RB_Trailing.Checked = true;
            this.RB_Trailing.Location = new System.Drawing.Point(15, 26);
            this.RB_Trailing.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RB_Trailing.Name = "RB_Trailing";
            this.RB_Trailing.Size = new System.Drawing.Size(112, 21);
            this.RB_Trailing.TabIndex = 17;
            this.RB_Trailing.TabStop = true;
            this.RB_Trailing.Text = "Raising edge";
            this.RB_Trailing.UseVisualStyleBackColor = true;
            this.RB_Trailing.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.NUD_Esw);
            this.groupBox1.Controls.Add(this.u7);
            this.groupBox1.Controls.Add(this.El);
            this.groupBox1.Controls.Add(this.swcolon);
            this.groupBox1.Controls.Add(this.swl);
            this.groupBox1.Controls.Add(this.HzLabel);
            this.groupBox1.Controls.Add(this.NUD_Frequency);
            this.groupBox1.Controls.Add(this.frql);
            this.groupBox1.Controls.Add(this.u5);
            this.groupBox1.Controls.Add(this.u4);
            this.groupBox1.Controls.Add(this.u3);
            this.groupBox1.Controls.Add(this.u2);
            this.groupBox1.Controls.Add(this.u1);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.u6);
            this.groupBox1.Controls.Add(this.NUD_TotalPeriod);
            this.groupBox1.Controls.Add(this.NUD_ScanRate);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.NUD_FinalPotential);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.NUD_pulsenumber);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.NUD_PulsePeriod);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.NUD_PulseAmp);
            this.groupBox1.Controls.Add(this.NUD_AmpStep);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.NUD_PulseLevel);
            this.groupBox1.Controls.Add(this.NUD_LevelStep);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(8, 42);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(311, 337);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pulse Customization";
            // 
            // El
            // 
            this.El.AutoSize = true;
            this.El.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.El.Location = new System.Drawing.Point(93, 308);
            this.El.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.El.Name = "El";
            this.El.Size = new System.Drawing.Size(18, 18);
            this.El.TabIndex = 33;
            this.El.Text = "E";
            // 
            // swcolon
            // 
            this.swcolon.AutoSize = true;
            this.swcolon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.swcolon.Location = new System.Drawing.Point(129, 308);
            this.swcolon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.swcolon.Name = "swcolon";
            this.swcolon.Size = new System.Drawing.Size(12, 18);
            this.swcolon.TabIndex = 40;
            this.swcolon.Text = ":";
            // 
            // swl
            // 
            this.swl.AutoSize = true;
            this.swl.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.swl.Location = new System.Drawing.Point(110, 320);
            this.swl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.swl.Name = "swl";
            this.swl.Size = new System.Drawing.Size(23, 13);
            this.swl.TabIndex = 39;
            this.swl.Text = "SW";
            // 
            // HzLabel
            // 
            this.HzLabel.AutoSize = true;
            this.HzLabel.Location = new System.Drawing.Point(256, 283);
            this.HzLabel.Name = "HzLabel";
            this.HzLabel.Size = new System.Drawing.Size(35, 17);
            this.HzLabel.TabIndex = 38;
            this.HzLabel.Text = "(Hz)";
            // 
            // NUD_Frequency
            // 
            this.NUD_Frequency.DecimalPlaces = 6;
            this.NUD_Frequency.Location = new System.Drawing.Point(149, 279);
            this.NUD_Frequency.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NUD_Frequency.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.NUD_Frequency.Name = "NUD_Frequency";
            this.NUD_Frequency.Size = new System.Drawing.Size(99, 22);
            this.NUD_Frequency.TabIndex = 37;
            this.NUD_Frequency.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_Frequency.ValueChanged += new System.EventHandler(this.NUD_Frequency_ValueChanged);
            // 
            // frql
            // 
            this.frql.AutoSize = true;
            this.frql.Location = new System.Drawing.Point(60, 283);
            this.frql.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.frql.Name = "frql";
            this.frql.Size = new System.Drawing.Size(79, 17);
            this.frql.TabIndex = 32;
            this.frql.Text = "Frequency:";
            // 
            // u5
            // 
            this.u5.AutoSize = true;
            this.u5.Location = new System.Drawing.Point(256, 224);
            this.u5.Name = "u5";
            this.u5.Size = new System.Drawing.Size(36, 17);
            this.u5.TabIndex = 31;
            this.u5.Text = "(ms)";
            // 
            // u4
            // 
            this.u4.AutoSize = true;
            this.u4.Location = new System.Drawing.Point(256, 194);
            this.u4.Name = "u4";
            this.u4.Size = new System.Drawing.Size(36, 17);
            this.u4.TabIndex = 30;
            this.u4.Text = "(ms)";
            // 
            // u3
            // 
            this.u3.AutoSize = true;
            this.u3.Location = new System.Drawing.Point(256, 166);
            this.u3.Name = "u3";
            this.u3.Size = new System.Drawing.Size(36, 17);
            this.u3.TabIndex = 29;
            this.u3.Text = "(ms)";
            // 
            // u2
            // 
            this.u2.AutoSize = true;
            this.u2.Location = new System.Drawing.Point(256, 137);
            this.u2.Name = "u2";
            this.u2.Size = new System.Drawing.Size(36, 17);
            this.u2.TabIndex = 28;
            this.u2.Text = "(ms)";
            // 
            // u1
            // 
            this.u1.AutoSize = true;
            this.u1.Location = new System.Drawing.Point(256, 107);
            this.u1.Name = "u1";
            this.u1.Size = new System.Drawing.Size(36, 17);
            this.u1.TabIndex = 27;
            this.u1.Text = "(ms)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(256, 81);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 17);
            this.label10.TabIndex = 17;
            this.label10.Text = "(ms)";
            // 
            // u6
            // 
            this.u6.AutoSize = true;
            this.u6.Location = new System.Drawing.Point(256, 254);
            this.u6.Name = "u6";
            this.u6.Size = new System.Drawing.Size(36, 17);
            this.u6.TabIndex = 26;
            this.u6.Text = "(ms)";
            // 
            // NUD_TotalPeriod
            // 
            this.NUD_TotalPeriod.Location = new System.Drawing.Point(149, 52);
            this.NUD_TotalPeriod.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NUD_TotalPeriod.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.NUD_TotalPeriod.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NUD_TotalPeriod.Name = "NUD_TotalPeriod";
            this.NUD_TotalPeriod.Size = new System.Drawing.Size(99, 22);
            this.NUD_TotalPeriod.TabIndex = 0;
            this.NUD_TotalPeriod.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NUD_TotalPeriod.ValueChanged += new System.EventHandler(this.NUD_TotalPeriod_ValueChanged);
            // 
            // NUD_ScanRate
            // 
            this.NUD_ScanRate.DecimalPlaces = 3;
            this.NUD_ScanRate.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.NUD_ScanRate.Location = new System.Drawing.Point(149, 251);
            this.NUD_ScanRate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NUD_ScanRate.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.NUD_ScanRate.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.NUD_ScanRate.Name = "NUD_ScanRate";
            this.NUD_ScanRate.Size = new System.Drawing.Size(99, 22);
            this.NUD_ScanRate.TabIndex = 22;
            this.NUD_ScanRate.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_ScanRate.ValueChanged += new System.EventHandler(this.NUD_ScanRate_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(57, 254);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 17);
            this.label11.TabIndex = 23;
            this.label11.Text = "Scan Rate:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pulse Period:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(256, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 17);
            this.label9.TabIndex = 16;
            this.label9.Text = "(ms)";
            // 
            // NUD_FinalPotential
            // 
            this.NUD_FinalPotential.DecimalPlaces = 3;
            this.NUD_FinalPotential.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NUD_FinalPotential.Location = new System.Drawing.Point(149, 222);
            this.NUD_FinalPotential.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NUD_FinalPotential.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NUD_FinalPotential.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.NUD_FinalPotential.Name = "NUD_FinalPotential";
            this.NUD_FinalPotential.Size = new System.Drawing.Size(99, 22);
            this.NUD_FinalPotential.TabIndex = 20;
            this.NUD_FinalPotential.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_FinalPotential.ValueChanged += new System.EventHandler(this.NUD_FinalPotential_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(56, 224);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 17);
            this.label12.TabIndex = 21;
            this.label12.Text = "Final Value:";
            // 
            // NUD_pulsenumber
            // 
            this.NUD_pulsenumber.Location = new System.Drawing.Point(149, 22);
            this.NUD_pulsenumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NUD_pulsenumber.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.NUD_pulsenumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_pulsenumber.Name = "NUD_pulsenumber";
            this.NUD_pulsenumber.Size = new System.Drawing.Size(99, 22);
            this.NUD_pulsenumber.TabIndex = 12;
            this.NUD_pulsenumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_pulsenumber.ValueChanged += new System.EventHandler(this.NUD_pulsenumber_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "Number of Pulses:";
            // 
            // NUD_PulsePeriod
            // 
            this.NUD_PulsePeriod.Location = new System.Drawing.Point(149, 80);
            this.NUD_PulsePeriod.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NUD_PulsePeriod.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.NUD_PulsePeriod.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.NUD_PulsePeriod.Name = "NUD_PulsePeriod";
            this.NUD_PulsePeriod.Size = new System.Drawing.Size(99, 22);
            this.NUD_PulsePeriod.TabIndex = 2;
            this.NUD_PulsePeriod.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.NUD_PulsePeriod.ValueChanged += new System.EventHandler(this.NUD_PulsePeriod_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Pulse Width:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Amplitude Step:";
            // 
            // NUD_PulseAmp
            // 
            this.NUD_PulseAmp.DecimalPlaces = 3;
            this.NUD_PulseAmp.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NUD_PulseAmp.Location = new System.Drawing.Point(149, 135);
            this.NUD_PulseAmp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NUD_PulseAmp.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NUD_PulseAmp.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.NUD_PulseAmp.Name = "NUD_PulseAmp";
            this.NUD_PulseAmp.Size = new System.Drawing.Size(99, 22);
            this.NUD_PulseAmp.TabIndex = 4;
            this.NUD_PulseAmp.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_PulseAmp.ValueChanged += new System.EventHandler(this.NUD_PulseAmp_ValueChanged);
            // 
            // NUD_AmpStep
            // 
            this.NUD_AmpStep.DecimalPlaces = 3;
            this.NUD_AmpStep.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.NUD_AmpStep.Location = new System.Drawing.Point(149, 192);
            this.NUD_AmpStep.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NUD_AmpStep.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NUD_AmpStep.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.NUD_AmpStep.Name = "NUD_AmpStep";
            this.NUD_AmpStep.Size = new System.Drawing.Size(99, 22);
            this.NUD_AmpStep.TabIndex = 10;
            this.NUD_AmpStep.ValueChanged += new System.EventHandler(this.NUD_AmpStep_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Amplitude:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Level Step:";
            // 
            // NUD_PulseLevel
            // 
            this.NUD_PulseLevel.DecimalPlaces = 3;
            this.NUD_PulseLevel.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NUD_PulseLevel.Location = new System.Drawing.Point(149, 107);
            this.NUD_PulseLevel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NUD_PulseLevel.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NUD_PulseLevel.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.NUD_PulseLevel.Name = "NUD_PulseLevel";
            this.NUD_PulseLevel.Size = new System.Drawing.Size(99, 22);
            this.NUD_PulseLevel.TabIndex = 6;
            this.NUD_PulseLevel.ValueChanged += new System.EventHandler(this.NUD_PulseLevel_ValueChanged);
            // 
            // NUD_LevelStep
            // 
            this.NUD_LevelStep.DecimalPlaces = 3;
            this.NUD_LevelStep.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NUD_LevelStep.Location = new System.Drawing.Point(149, 164);
            this.NUD_LevelStep.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NUD_LevelStep.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NUD_LevelStep.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.NUD_LevelStep.Name = "NUD_LevelStep";
            this.NUD_LevelStep.Size = new System.Drawing.Size(99, 22);
            this.NUD_LevelStep.TabIndex = 8;
            this.NUD_LevelStep.ValueChanged += new System.EventHandler(this.NUD_LevelStep_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Initial Level:";
            // 
            // WarnLabel
            // 
            this.WarnLabel.AutoSize = true;
            this.WarnLabel.BackColor = System.Drawing.Color.White;
            this.WarnLabel.ForeColor = System.Drawing.Color.Red;
            this.WarnLabel.Location = new System.Drawing.Point(429, 4);
            this.WarnLabel.Name = "WarnLabel";
            this.WarnLabel.Size = new System.Drawing.Size(184, 17);
            this.WarnLabel.TabIndex = 20;
            this.WarnLabel.Text = "Warning: Over load in pulse";
            this.WarnLabel.Visible = false;
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(329, 0);
            this.chart1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(1114, 479);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // u7
            // 
            this.u7.AutoSize = true;
            this.u7.Location = new System.Drawing.Point(256, 310);
            this.u7.Name = "u7";
            this.u7.Size = new System.Drawing.Size(36, 17);
            this.u7.TabIndex = 42;
            this.u7.Text = "(ms)";
            this.u7.Visible = false;
            // 
            // NUD_Esw
            // 
            this.NUD_Esw.DecimalPlaces = 3;
            this.NUD_Esw.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NUD_Esw.Location = new System.Drawing.Point(149, 307);
            this.NUD_Esw.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NUD_Esw.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NUD_Esw.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            -2147483648});
            this.NUD_Esw.Name = "NUD_Esw";
            this.NUD_Esw.Size = new System.Drawing.Size(99, 22);
            this.NUD_Esw.TabIndex = 43;
            this.NUD_Esw.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_Esw.Visible = false;
            this.NUD_Esw.ValueChanged += new System.EventHandler(this.NUD_Esw_ValueChanged);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1443, 479);
            this.Controls.Add(this.WarnLabel);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form3";
            this.Text = "Pulse";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Frequency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_TotalPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_ScanRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_FinalPotential)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_pulsenumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_PulsePeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_PulseAmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_AmpStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_PulseLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_LevelStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Esw)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown NUD_AmpStep;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown NUD_LevelStep;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown NUD_PulseLevel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown NUD_PulseAmp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown NUD_PulsePeriod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NUD_TotalPeriod;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown NUD_pulsenumber;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton RB_Leading;
        private System.Windows.Forms.RadioButton RB_Trailing;
        private System.Windows.Forms.RadioButton RB_Differential;
        private System.Windows.Forms.Label WarnLabel;
        private System.Windows.Forms.ComboBox CBVoltammetryMode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown NUD_FinalPotential;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label u6;
        private System.Windows.Forms.NumericUpDown NUD_ScanRate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label u5;
        private System.Windows.Forms.Label u4;
        private System.Windows.Forms.Label u3;
        private System.Windows.Forms.Label u2;
        private System.Windows.Forms.Label u1;
        private System.Windows.Forms.Label El;
        private System.Windows.Forms.Label frql;
        private System.Windows.Forms.Label HzLabel;
        private System.Windows.Forms.NumericUpDown NUD_Frequency;
        private System.Windows.Forms.Label swl;
        private System.Windows.Forms.Label swcolon;
        private System.Windows.Forms.NumericUpDown NUD_Esw;
        private System.Windows.Forms.Label u7;
    }
}