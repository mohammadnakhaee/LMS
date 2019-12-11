namespace EISProjects
{
    partial class FormDiagram
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.SessionName = new System.Windows.Forms.ComboBox();
            this.FigureTimer = new System.Windows.Forms.Timer(this.components);
            this.CheckStartTimer = new System.Windows.Forms.Timer(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CBYAxis = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CBXAxis = new System.Windows.Forms.ComboBox();
            this.Ypanel = new System.Windows.Forms.Panel();
            this.OpenInExcel = new System.Windows.Forms.Button();
            this.ChSeries = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.CBIUnit = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnMakeReport = new System.Windows.Forms.Button();
            this.Xpanel = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel4.SuspendLayout();
            this.Ypanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.Xpanel.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // SessionName
            // 
            this.SessionName.FormattingEnabled = true;
            this.SessionName.Location = new System.Drawing.Point(55, 8);
            this.SessionName.Name = "SessionName";
            this.SessionName.Size = new System.Drawing.Size(116, 21);
            this.SessionName.TabIndex = 0;
            this.SessionName.SelectedIndexChanged += new System.EventHandler(this.SessionName_SelectedIndexChanged);
            // 
            // FigureTimer
            // 
            this.FigureTimer.Interval = 200;
            this.FigureTimer.Tick += new System.EventHandler(this.FigureTimer_Tick);
            // 
            // CheckStartTimer
            // 
            this.CheckStartTimer.Interval = 500;
            this.CheckStartTimer.Tick += new System.EventHandler(this.CheckStartTimer_Tick);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.SessionName);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(986, 37);
            this.panel4.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Session:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Y Axis:";
            // 
            // CBYAxis
            // 
            this.CBYAxis.FormattingEnabled = true;
            this.CBYAxis.Items.AddRange(new object[] {
            "Re(Z) & Im(Z)",
            "Re(Z)",
            "Im(Z)"});
            this.CBYAxis.Location = new System.Drawing.Point(46, 16);
            this.CBYAxis.Name = "CBYAxis";
            this.CBYAxis.Size = new System.Drawing.Size(116, 21);
            this.CBYAxis.TabIndex = 2;
            this.CBYAxis.SelectedIndexChanged += new System.EventHandler(this.CBYAxis_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "X Axis:";
            // 
            // CBXAxis
            // 
            this.CBXAxis.FormattingEnabled = true;
            this.CBXAxis.Items.AddRange(new object[] {
            "Variable",
            "Re(Z)",
            "Im(Z)"});
            this.CBXAxis.Location = new System.Drawing.Point(48, 6);
            this.CBXAxis.Name = "CBXAxis";
            this.CBXAxis.Size = new System.Drawing.Size(116, 21);
            this.CBXAxis.TabIndex = 4;
            this.CBXAxis.SelectedIndexChanged += new System.EventHandler(this.CBXAxis_SelectedIndexChanged);
            // 
            // Ypanel
            // 
            this.Ypanel.Controls.Add(this.OpenInExcel);
            this.Ypanel.Controls.Add(this.ChSeries);
            this.Ypanel.Controls.Add(this.groupBox1);
            this.Ypanel.Controls.Add(this.BtnMakeReport);
            this.Ypanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.Ypanel.Enabled = false;
            this.Ypanel.Location = new System.Drawing.Point(0, 37);
            this.Ypanel.Name = "Ypanel";
            this.Ypanel.Size = new System.Drawing.Size(183, 490);
            this.Ypanel.TabIndex = 4;
            // 
            // OpenInExcel
            // 
            this.OpenInExcel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.OpenInExcel.Location = new System.Drawing.Point(0, 441);
            this.OpenInExcel.Margin = new System.Windows.Forms.Padding(2);
            this.OpenInExcel.Name = "OpenInExcel";
            this.OpenInExcel.Size = new System.Drawing.Size(183, 24);
            this.OpenInExcel.TabIndex = 8;
            this.OpenInExcel.Text = "Open in external editor";
            this.OpenInExcel.UseVisualStyleBackColor = true;
            this.OpenInExcel.Click += new System.EventHandler(this.OpenInExcel_Click);
            // 
            // ChSeries
            // 
            this.ChSeries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChSeries.FormattingEnabled = true;
            this.ChSeries.Location = new System.Drawing.Point(0, 103);
            this.ChSeries.Margin = new System.Windows.Forms.Padding(2);
            this.ChSeries.Name = "ChSeries";
            this.ChSeries.Size = new System.Drawing.Size(183, 362);
            this.ChSeries.TabIndex = 6;
            this.ChSeries.Visible = false;
            this.ChSeries.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ChSeries_ItemCheck);
            this.ChSeries.SelectedIndexChanged += new System.EventHandler(this.ChSeries_SelectedIndexChanged);
            this.ChSeries.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ChSeries_KeyUp);
            this.ChSeries.Validated += new System.EventHandler(this.ChSeries_Validated);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.CBIUnit);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.CBYAxis);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(183, 103);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(28, 73);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 19);
            this.button1.TabIndex = 6;
            this.button1.Text = "Customize";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CBIUnit
            // 
            this.CBIUnit.FormattingEnabled = true;
            this.CBIUnit.Items.AddRange(new object[] {
            "10^-6",
            "10^-3",
            "1",
            "10^3",
            "10^6"});
            this.CBIUnit.Location = new System.Drawing.Point(46, 44);
            this.CBIUnit.Name = "CBIUnit";
            this.CBIUnit.Size = new System.Drawing.Size(116, 21);
            this.CBIUnit.TabIndex = 4;
            this.CBIUnit.SelectedIndexChanged += new System.EventHandler(this.CBIUnit_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Y Unit:";
            // 
            // BtnMakeReport
            // 
            this.BtnMakeReport.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnMakeReport.Location = new System.Drawing.Point(0, 465);
            this.BtnMakeReport.Name = "BtnMakeReport";
            this.BtnMakeReport.Size = new System.Drawing.Size(183, 25);
            this.BtnMakeReport.TabIndex = 7;
            this.BtnMakeReport.Text = "Export Data";
            this.BtnMakeReport.UseVisualStyleBackColor = true;
            this.BtnMakeReport.Click += new System.EventHandler(this.BtnMakeReport_Click);
            // 
            // Xpanel
            // 
            this.Xpanel.Controls.Add(this.label3);
            this.Xpanel.Controls.Add(this.CBXAxis);
            this.Xpanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Xpanel.Enabled = false;
            this.Xpanel.Location = new System.Drawing.Point(183, 466);
            this.Xpanel.Name = "Xpanel";
            this.Xpanel.Size = new System.Drawing.Size(803, 61);
            this.Xpanel.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.chart1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(183, 37);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(803, 429);
            this.panel3.TabIndex = 6;
            // 
            // chart1
            // 
            this.chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea2.AxisX.LabelStyle.Format = "{0:0.00}";
            chartArea2.AxisX.LabelStyle.TruncatedLabels = true;
            chartArea2.AxisX.MajorGrid.Interval = 0D;
            chartArea2.AxisX.MajorGrid.IntervalOffset = 0D;
            chartArea2.AxisX.MajorGrid.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea2.AxisX.MajorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.DimGray;
            chartArea2.AxisX.MajorTickMark.Interval = 0D;
            chartArea2.AxisX.MajorTickMark.IntervalOffset = 0D;
            chartArea2.AxisX.MajorTickMark.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea2.AxisX.MajorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea2.AxisX.MinorGrid.Enabled = true;
            chartArea2.AxisX.MinorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea2.AxisX.MinorTickMark.Enabled = true;
            chartArea2.AxisY.LabelStyle.Format = "{0:0.00}";
            chartArea2.AxisY.LabelStyle.TruncatedLabels = true;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.DimGray;
            chartArea2.AxisY.MinorGrid.Enabled = true;
            chartArea2.AxisY.MinorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea2.AxisY.MinorTickMark.Enabled = true;
            chartArea2.CursorX.Interval = 1E-08D;
            chartArea2.CursorX.IsUserEnabled = true;
            chartArea2.CursorX.IsUserSelectionEnabled = true;
            chartArea2.CursorY.Interval = 1E-08D;
            chartArea2.CursorY.IsUserEnabled = true;
            chartArea2.CursorY.IsUserSelectionEnabled = true;
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(799, 425);
            this.chart1.TabIndex = 3;
            this.chart1.Text = "chart1";
            // 
            // FormDiagram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 527);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.Xpanel);
            this.Controls.Add(this.Ypanel);
            this.Controls.Add(this.panel4);
            this.Name = "FormDiagram";
            this.Text = "Diagram";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDiagram_FormClosing);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.Ypanel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Xpanel.ResumeLayout(false);
            this.Xpanel.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ComboBox SessionName;
        private System.Windows.Forms.Timer FigureTimer;
        private System.Windows.Forms.Timer CheckStartTimer;
        private System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox CBYAxis;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox CBXAxis;
        private System.Windows.Forms.Panel Ypanel;
        private System.Windows.Forms.Panel Xpanel;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.ComboBox CBIUnit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.CheckedListBox ChSeries;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BtnMakeReport;
        private System.Windows.Forms.Button OpenInExcel;

    }
}