namespace EISProjects
{
    partial class FormEISDigital
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button1 = new System.Windows.Forms.Button();
            this.GBVoltage = new System.Windows.Forms.GroupBox();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.GBCurrent = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBox_notch = new System.Windows.Forms.CheckBox();
            this.checkBox_float = new System.Windows.Forms.CheckBox();
            this.checkBox_clm = new System.Windows.Forms.CheckBox();
            this.checkBox_AC = new System.Windows.Forms.CheckBox();
            this.numericUpDown_dac = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_vacdac = new System.Windows.Forms.NumericUpDown();
            this.comboBox_iIs = new System.Windows.Forms.ComboBox();
            this.numericUpDown_iacdac = new System.Windows.Forms.NumericUpDown();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.GBVoltage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.GBCurrent.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_dac)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_vacdac)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_iacdac)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Right;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(807, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(73, 472);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(60, 19);
            this.toolsToolStripMenuItem.Text = "    Tools   ";
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // chart1
            // 
            this.chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.Enabled = false;
            chartArea1.AxisY.LabelStyle.Enabled = false;
            chartArea1.AxisY.Maximum = 4096D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.CursorX.IsUserEnabled = true;
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.CursorY.IsUserEnabled = true;
            chartArea1.CursorY.IsUserSelectionEnabled = true;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.Location = new System.Drawing.Point(3, 20);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(801, 196);
            this.chart1.TabIndex = 4;
            this.chart1.Text = "chart1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 365);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(55, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GBVoltage
            // 
            this.GBVoltage.Controls.Add(this.chart1);
            this.GBVoltage.Dock = System.Windows.Forms.DockStyle.Top;
            this.GBVoltage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GBVoltage.Location = new System.Drawing.Point(0, 0);
            this.GBVoltage.Name = "GBVoltage";
            this.GBVoltage.Size = new System.Drawing.Size(807, 219);
            this.GBVoltage.TabIndex = 1;
            this.GBVoltage.TabStop = false;
            this.GBVoltage.Text = "V(t)    Voltage";
            // 
            // chart2
            // 
            this.chart2.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea2.AxisX.LabelStyle.Enabled = false;
            chartArea2.AxisY.LabelStyle.Enabled = false;
            chartArea2.AxisY.Maximum = 4096D;
            chartArea2.AxisY.Minimum = 0D;
            chartArea2.CursorX.IsUserEnabled = true;
            chartArea2.CursorX.IsUserSelectionEnabled = true;
            chartArea2.CursorY.IsUserEnabled = true;
            chartArea2.CursorY.IsUserSelectionEnabled = true;
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            this.chart2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart2.Location = new System.Drawing.Point(3, 20);
            this.chart2.Name = "chart2";
            this.chart2.Size = new System.Drawing.Size(801, 196);
            this.chart2.TabIndex = 5;
            this.chart2.Text = "chart2";
            // 
            // GBCurrent
            // 
            this.GBCurrent.Controls.Add(this.chart2);
            this.GBCurrent.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GBCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GBCurrent.Location = new System.Drawing.Point(0, 253);
            this.GBCurrent.Name = "GBCurrent";
            this.GBCurrent.Size = new System.Drawing.Size(807, 219);
            this.GBCurrent.TabIndex = 2;
            this.GBCurrent.TabStop = false;
            this.GBCurrent.Text = "I(t)      Current";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(2, 2);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 19);
            this.button2.TabIndex = 6;
            this.button2.Text = "start";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1A",
            "100mA",
            "10mA",
            "1mA",
            "100uA",
            "10uA",
            "1uA",
            "100nA"});
            this.comboBox1.Location = new System.Drawing.Point(2, 159);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(41, 21);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.refresh);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "V0",
            "V1",
            "V2",
            "V3"});
            this.comboBox2.Location = new System.Drawing.Point(2, 184);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(41, 21);
            this.comboBox2.TabIndex = 8;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.refresh);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "if0",
            "if1",
            "if2"});
            this.comboBox3.Location = new System.Drawing.Point(2, 209);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(41, 21);
            this.comboBox3.TabIndex = 9;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.refresh);
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "vf0",
            "vf1",
            "vf2"});
            this.comboBox4.Location = new System.Drawing.Point(2, 234);
            this.comboBox4.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(41, 21);
            this.comboBox4.TabIndex = 10;
            this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.refresh);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(2, 46);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(53, 17);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "probe";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.refresh);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(2, 25);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(59, 17);
            this.checkBox2.TabIndex = 12;
            this.checkBox2.Text = "dummy";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.refresh);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Controls.Add(this.checkBox2);
            this.flowLayoutPanel1.Controls.Add(this.checkBox1);
            this.flowLayoutPanel1.Controls.Add(this.checkBox_notch);
            this.flowLayoutPanel1.Controls.Add(this.checkBox_float);
            this.flowLayoutPanel1.Controls.Add(this.checkBox_clm);
            this.flowLayoutPanel1.Controls.Add(this.checkBox_AC);
            this.flowLayoutPanel1.Controls.Add(this.comboBox1);
            this.flowLayoutPanel1.Controls.Add(this.comboBox2);
            this.flowLayoutPanel1.Controls.Add(this.comboBox3);
            this.flowLayoutPanel1.Controls.Add(this.comboBox4);
            this.flowLayoutPanel1.Controls.Add(this.numericUpDown_dac);
            this.flowLayoutPanel1.Controls.Add(this.numericUpDown_vacdac);
            this.flowLayoutPanel1.Controls.Add(this.comboBox_iIs);
            this.flowLayoutPanel1.Controls.Add(this.numericUpDown_iacdac);
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(813, 20);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(64, 393);
            this.flowLayoutPanel1.TabIndex = 14;
            // 
            // checkBox_notch
            // 
            this.checkBox_notch.AutoSize = true;
            this.checkBox_notch.Location = new System.Drawing.Point(3, 68);
            this.checkBox_notch.Name = "checkBox_notch";
            this.checkBox_notch.Size = new System.Drawing.Size(53, 17);
            this.checkBox_notch.TabIndex = 13;
            this.checkBox_notch.Text = "notch";
            this.checkBox_notch.UseVisualStyleBackColor = true;
            this.checkBox_notch.CheckedChanged += new System.EventHandler(this.refresh);
            // 
            // checkBox_float
            // 
            this.checkBox_float.AutoSize = true;
            this.checkBox_float.Location = new System.Drawing.Point(3, 91);
            this.checkBox_float.Name = "checkBox_float";
            this.checkBox_float.Size = new System.Drawing.Size(46, 17);
            this.checkBox_float.TabIndex = 14;
            this.checkBox_float.Text = "float";
            this.checkBox_float.UseVisualStyleBackColor = true;
            this.checkBox_float.CheckedChanged += new System.EventHandler(this.refresh);
            // 
            // checkBox_clm
            // 
            this.checkBox_clm.AutoSize = true;
            this.checkBox_clm.Location = new System.Drawing.Point(3, 114);
            this.checkBox_clm.Name = "checkBox_clm";
            this.checkBox_clm.Size = new System.Drawing.Size(50, 17);
            this.checkBox_clm.TabIndex = 15;
            this.checkBox_clm.Text = "Climit";
            this.checkBox_clm.UseVisualStyleBackColor = true;
            this.checkBox_clm.CheckedChanged += new System.EventHandler(this.refresh);
            // 
            // checkBox_AC
            // 
            this.checkBox_AC.AutoSize = true;
            this.checkBox_AC.Location = new System.Drawing.Point(3, 137);
            this.checkBox_AC.Name = "checkBox_AC";
            this.checkBox_AC.Size = new System.Drawing.Size(40, 17);
            this.checkBox_AC.TabIndex = 16;
            this.checkBox_AC.Text = "AC";
            this.checkBox_AC.UseVisualStyleBackColor = true;
            this.checkBox_AC.CheckedChanged += new System.EventHandler(this.refresh);
            // 
            // numericUpDown_dac
            // 
            this.numericUpDown_dac.Location = new System.Drawing.Point(3, 260);
            this.numericUpDown_dac.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDown_dac.Name = "numericUpDown_dac";
            this.numericUpDown_dac.Size = new System.Drawing.Size(40, 20);
            this.numericUpDown_dac.TabIndex = 17;
            this.numericUpDown_dac.ValueChanged += new System.EventHandler(this.refresh);
            // 
            // numericUpDown_vacdac
            // 
            this.numericUpDown_vacdac.Location = new System.Drawing.Point(3, 286);
            this.numericUpDown_vacdac.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDown_vacdac.Name = "numericUpDown_vacdac";
            this.numericUpDown_vacdac.Size = new System.Drawing.Size(40, 20);
            this.numericUpDown_vacdac.TabIndex = 18;
            this.numericUpDown_vacdac.ValueChanged += new System.EventHandler(this.refresh);
            // 
            // comboBox_iIs
            // 
            this.comboBox_iIs.FormattingEnabled = true;
            this.comboBox_iIs.Items.AddRange(new object[] {
            "iIs0",
            "iIs1",
            "iIs2",
            "iIs3"});
            this.comboBox_iIs.Location = new System.Drawing.Point(3, 312);
            this.comboBox_iIs.Name = "comboBox_iIs";
            this.comboBox_iIs.Size = new System.Drawing.Size(40, 21);
            this.comboBox_iIs.TabIndex = 20;
            this.comboBox_iIs.SelectedIndexChanged += new System.EventHandler(this.refresh);
            // 
            // numericUpDown_iacdac
            // 
            this.numericUpDown_iacdac.Location = new System.Drawing.Point(3, 339);
            this.numericUpDown_iacdac.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDown_iacdac.Name = "numericUpDown_iacdac";
            this.numericUpDown_iacdac.Size = new System.Drawing.Size(40, 20);
            this.numericUpDown_iacdac.TabIndex = 19;
            this.numericUpDown_iacdac.ValueChanged += new System.EventHandler(this.refresh);
            // 
            // FormEISDigital
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 472);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.GBCurrent);
            this.Controls.Add(this.GBVoltage);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormEISDigital";
            this.Text = "Scope";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEISDigital_FormClosing);
            this.Resize += new System.EventHandler(this.FormEISDigital_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.GBVoltage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.GBCurrent.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_dac)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_vacdac)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_iacdac)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox GBVoltage;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.GroupBox GBCurrent;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox_notch;
        private System.Windows.Forms.CheckBox checkBox_float;
        private System.Windows.Forms.CheckBox checkBox_clm;
        private System.Windows.Forms.CheckBox checkBox_AC;
        private System.Windows.Forms.NumericUpDown numericUpDown_dac;
        private System.Windows.Forms.NumericUpDown numericUpDown_vacdac;
        private System.Windows.Forms.ComboBox comboBox_iIs;
        private System.Windows.Forms.NumericUpDown numericUpDown_iacdac;
        internal System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        internal System.Windows.Forms.MenuStrip menuStrip1;
    }
}