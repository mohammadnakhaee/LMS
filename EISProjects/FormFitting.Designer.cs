namespace EISProjects
{
    partial class FormFitting
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.GBFitting = new System.Windows.Forms.GroupBox();
            this.BtnFindFit = new System.Windows.Forms.Button();
            this.CBFitMethod = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.GBElement = new System.Windows.Forms.GroupBox();
            this.TBElementVal2 = new System.Windows.Forms.TextBox();
            this.ElementVal2Name = new System.Windows.Forms.Label();
            this.TBElementVal1 = new System.Windows.Forms.TextBox();
            this.ElementVal1Name = new System.Windows.Forms.Label();
            this.TBElementKind = new System.Windows.Forms.TextBox();
            this.TBElementName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LabelError = new System.Windows.Forms.Label();
            this.GBContents = new System.Windows.Forms.GroupBox();
            this.BtnNewCircuit = new System.Windows.Forms.Button();
            this.CBCircuitName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SessionName = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.CircuitDeskTop = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TSBSelMod = new System.Windows.Forms.ToolStripButton();
            this.TSBResMod = new System.Windows.Forms.ToolStripButton();
            this.TSBCapMod = new System.Windows.Forms.ToolStripButton();
            this.TSBIndMod = new System.Windows.Forms.ToolStripButton();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.CMElements = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.GBFitting.SuspendLayout();
            this.GBElement.SuspendLayout();
            this.GBContents.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.CMElements.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.SessionName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(730, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 581);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.AutoScroll = true;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.GBFitting);
            this.panel4.Controls.Add(this.GBElement);
            this.panel4.Controls.Add(this.LabelError);
            this.panel4.Controls.Add(this.GBContents);
            this.panel4.Location = new System.Drawing.Point(-2, 36);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(260, 543);
            this.panel4.TabIndex = 11;
            // 
            // GBFitting
            // 
            this.GBFitting.Controls.Add(this.BtnFindFit);
            this.GBFitting.Controls.Add(this.CBFitMethod);
            this.GBFitting.Controls.Add(this.label3);
            this.GBFitting.Enabled = false;
            this.GBFitting.Location = new System.Drawing.Point(8, 244);
            this.GBFitting.Name = "GBFitting";
            this.GBFitting.Size = new System.Drawing.Size(228, 86);
            this.GBFitting.TabIndex = 12;
            this.GBFitting.TabStop = false;
            this.GBFitting.Text = "Fitting";
            // 
            // BtnFindFit
            // 
            this.BtnFindFit.Location = new System.Drawing.Point(35, 54);
            this.BtnFindFit.Name = "BtnFindFit";
            this.BtnFindFit.Size = new System.Drawing.Size(155, 26);
            this.BtnFindFit.TabIndex = 12;
            this.BtnFindFit.Text = "10 Itt";
            this.BtnFindFit.UseVisualStyleBackColor = true;
            this.BtnFindFit.Click += new System.EventHandler(this.BtnFindFit_Click);
            // 
            // CBFitMethod
            // 
            this.CBFitMethod.Enabled = false;
            this.CBFitMethod.FormattingEnabled = true;
            this.CBFitMethod.Items.AddRange(new object[] {
            "Polar Least Square"});
            this.CBFitMethod.Location = new System.Drawing.Point(85, 19);
            this.CBFitMethod.Name = "CBFitMethod";
            this.CBFitMethod.Size = new System.Drawing.Size(137, 21);
            this.CBFitMethod.TabIndex = 9;
            this.CBFitMethod.SelectedIndexChanged += new System.EventHandler(this.CBFitMethod_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Fitting Method:";
            // 
            // GBElement
            // 
            this.GBElement.Controls.Add(this.TBElementVal2);
            this.GBElement.Controls.Add(this.ElementVal2Name);
            this.GBElement.Controls.Add(this.TBElementVal1);
            this.GBElement.Controls.Add(this.ElementVal1Name);
            this.GBElement.Controls.Add(this.TBElementKind);
            this.GBElement.Controls.Add(this.TBElementName);
            this.GBElement.Controls.Add(this.label5);
            this.GBElement.Controls.Add(this.label4);
            this.GBElement.Enabled = false;
            this.GBElement.Location = new System.Drawing.Point(8, 115);
            this.GBElement.Name = "GBElement";
            this.GBElement.Size = new System.Drawing.Size(228, 123);
            this.GBElement.TabIndex = 11;
            this.GBElement.TabStop = false;
            this.GBElement.Text = "Element Data";
            // 
            // TBElementVal2
            // 
            this.TBElementVal2.Location = new System.Drawing.Point(93, 96);
            this.TBElementVal2.Name = "TBElementVal2";
            this.TBElementVal2.Size = new System.Drawing.Size(127, 20);
            this.TBElementVal2.TabIndex = 7;
            this.TBElementVal2.Visible = false;
            this.TBElementVal2.TextChanged += new System.EventHandler(this.TBElementVal2_TextChanged);
            // 
            // ElementVal2Name
            // 
            this.ElementVal2Name.AutoSize = true;
            this.ElementVal2Name.Location = new System.Drawing.Point(71, 99);
            this.ElementVal2Name.Name = "ElementVal2Name";
            this.ElementVal2Name.Size = new System.Drawing.Size(18, 13);
            this.ElementVal2Name.TabIndex = 6;
            this.ElementVal2Name.Text = "R:";
            this.ElementVal2Name.Visible = false;
            // 
            // TBElementVal1
            // 
            this.TBElementVal1.Location = new System.Drawing.Point(93, 70);
            this.TBElementVal1.Name = "TBElementVal1";
            this.TBElementVal1.Size = new System.Drawing.Size(127, 20);
            this.TBElementVal1.TabIndex = 5;
            this.TBElementVal1.Visible = false;
            this.TBElementVal1.TextChanged += new System.EventHandler(this.TBElementVal1_TextChanged);
            // 
            // ElementVal1Name
            // 
            this.ElementVal1Name.AutoSize = true;
            this.ElementVal1Name.Location = new System.Drawing.Point(71, 73);
            this.ElementVal1Name.Name = "ElementVal1Name";
            this.ElementVal1Name.Size = new System.Drawing.Size(18, 13);
            this.ElementVal1Name.TabIndex = 4;
            this.ElementVal1Name.Text = "R:";
            this.ElementVal1Name.Visible = false;
            // 
            // TBElementKind
            // 
            this.TBElementKind.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TBElementKind.Location = new System.Drawing.Point(93, 44);
            this.TBElementKind.Name = "TBElementKind";
            this.TBElementKind.ReadOnly = true;
            this.TBElementKind.Size = new System.Drawing.Size(127, 20);
            this.TBElementKind.TabIndex = 3;
            // 
            // TBElementName
            // 
            this.TBElementName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TBElementName.Location = new System.Drawing.Point(93, 19);
            this.TBElementName.Name = "TBElementName";
            this.TBElementName.ReadOnly = true;
            this.TBElementName.Size = new System.Drawing.Size(127, 20);
            this.TBElementName.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(58, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Kind:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Element Name:";
            // 
            // LabelError
            // 
            this.LabelError.AutoSize = true;
            this.LabelError.Location = new System.Drawing.Point(7, 2);
            this.LabelError.Name = "LabelError";
            this.LabelError.Size = new System.Drawing.Size(0, 13);
            this.LabelError.TabIndex = 5;
            // 
            // GBContents
            // 
            this.GBContents.Controls.Add(this.BtnNewCircuit);
            this.GBContents.Controls.Add(this.CBCircuitName);
            this.GBContents.Controls.Add(this.label2);
            this.GBContents.Enabled = false;
            this.GBContents.Location = new System.Drawing.Point(8, 15);
            this.GBContents.Name = "GBContents";
            this.GBContents.Size = new System.Drawing.Size(228, 94);
            this.GBContents.TabIndex = 9;
            this.GBContents.TabStop = false;
            this.GBContents.Text = "Session Contents";
            // 
            // BtnNewCircuit
            // 
            this.BtnNewCircuit.Location = new System.Drawing.Point(35, 21);
            this.BtnNewCircuit.Name = "BtnNewCircuit";
            this.BtnNewCircuit.Size = new System.Drawing.Size(155, 25);
            this.BtnNewCircuit.TabIndex = 11;
            this.BtnNewCircuit.Text = "New Equivalent Circuit";
            this.BtnNewCircuit.UseVisualStyleBackColor = true;
            this.BtnNewCircuit.Click += new System.EventHandler(this.BtnNewCircuit_Click);
            // 
            // CBCircuitName
            // 
            this.CBCircuitName.FormattingEnabled = true;
            this.CBCircuitName.Location = new System.Drawing.Point(93, 52);
            this.CBCircuitName.Name = "CBCircuitName";
            this.CBCircuitName.Size = new System.Drawing.Size(127, 21);
            this.CBCircuitName.TabIndex = 7;
            this.CBCircuitName.SelectedIndexChanged += new System.EventHandler(this.CBCircuitName_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Equivalent Circuit:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Session name:";
            // 
            // SessionName
            // 
            this.SessionName.FormattingEnabled = true;
            this.SessionName.Location = new System.Drawing.Point(81, 12);
            this.SessionName.Name = "SessionName";
            this.SessionName.Size = new System.Drawing.Size(153, 21);
            this.SessionName.TabIndex = 3;
            this.SessionName.SelectedIndexChanged += new System.EventHandler(this.SessionName_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.CircuitDeskTop);
            this.panel2.Controls.Add(this.toolStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 191);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(730, 390);
            this.panel2.TabIndex = 1;
            // 
            // CircuitDeskTop
            // 
            this.CircuitDeskTop.AutoScroll = true;
            this.CircuitDeskTop.BackColor = System.Drawing.SystemColors.Info;
            this.CircuitDeskTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CircuitDeskTop.Location = new System.Drawing.Point(0, 40);
            this.CircuitDeskTop.Name = "CircuitDeskTop";
            this.CircuitDeskTop.Size = new System.Drawing.Size(726, 346);
            this.CircuitDeskTop.TabIndex = 4;
            this.CircuitDeskTop.Click += new System.EventHandler(this.CircuitDeskTop_Click);
            this.CircuitDeskTop.Paint += new System.Windows.Forms.PaintEventHandler(this.CircuitDeskTop_Paint);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Enabled = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSBSelMod,
            this.TSBResMod,
            this.TSBCapMod,
            this.TSBIndMod});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(726, 40);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // TSBSelMod
            // 
            this.TSBSelMod.AutoSize = false;
            this.TSBSelMod.BackgroundImage = global::EISProjects.Properties.Resources.sel;
            this.TSBSelMod.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TSBSelMod.Checked = true;
            this.TSBSelMod.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TSBSelMod.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSBSelMod.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBSelMod.Margin = new System.Windows.Forms.Padding(3);
            this.TSBSelMod.Name = "TSBSelMod";
            this.TSBSelMod.Size = new System.Drawing.Size(30, 30);
            this.TSBSelMod.Text = "toolStripButton1";
            this.TSBSelMod.Click += new System.EventHandler(this.TSBSelMod_Click);
            // 
            // TSBResMod
            // 
            this.TSBResMod.AutoSize = false;
            this.TSBResMod.BackgroundImage = global::EISProjects.Properties.Resources.res2;
            this.TSBResMod.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TSBResMod.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSBResMod.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBResMod.Margin = new System.Windows.Forms.Padding(3);
            this.TSBResMod.Name = "TSBResMod";
            this.TSBResMod.Size = new System.Drawing.Size(30, 30);
            this.TSBResMod.Text = "toolStripButton2";
            this.TSBResMod.Click += new System.EventHandler(this.TSBResMod_Click);
            // 
            // TSBCapMod
            // 
            this.TSBCapMod.AutoSize = false;
            this.TSBCapMod.BackgroundImage = global::EISProjects.Properties.Resources.cap;
            this.TSBCapMod.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TSBCapMod.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSBCapMod.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBCapMod.Margin = new System.Windows.Forms.Padding(3);
            this.TSBCapMod.Name = "TSBCapMod";
            this.TSBCapMod.Size = new System.Drawing.Size(30, 30);
            this.TSBCapMod.Text = "toolStripButton3";
            this.TSBCapMod.Click += new System.EventHandler(this.TSBCapMod_Click);
            // 
            // TSBIndMod
            // 
            this.TSBIndMod.AutoSize = false;
            this.TSBIndMod.BackgroundImage = global::EISProjects.Properties.Resources.ind;
            this.TSBIndMod.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TSBIndMod.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSBIndMod.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBIndMod.Margin = new System.Windows.Forms.Padding(3);
            this.TSBIndMod.Name = "TSBIndMod";
            this.TSBIndMod.Size = new System.Drawing.Size(30, 30);
            this.TSBIndMod.Text = "toolStripButton1";
            this.TSBIndMod.Click += new System.EventHandler(this.TSBIndMod_Click);
            // 
            // chart1
            // 
            this.chart1.BackImageTransparentColor = System.Drawing.Color.Maroon;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(730, 191);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // CMElements
            // 
            this.CMElements.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.CMElements.Name = "CMElements";
            this.CMElements.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // FormFitting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 581);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormFitting";
            this.Text = "Fitting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormFitting_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.GBFitting.ResumeLayout(false);
            this.GBFitting.PerformLayout();
            this.GBElement.ResumeLayout(false);
            this.GBElement.PerformLayout();
            this.GBContents.ResumeLayout(false);
            this.GBContents.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.CMElements.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox SessionName;
        public System.Windows.Forms.Label LabelError;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton TSBSelMod;
        private System.Windows.Forms.ToolStripButton TSBResMod;
        private System.Windows.Forms.ToolStripButton TSBCapMod;
        private System.Windows.Forms.ToolStripButton TSBIndMod;
        private System.Windows.Forms.GroupBox GBContents;
        public System.Windows.Forms.ComboBox CBCircuitName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnNewCircuit;
        private System.Windows.Forms.Panel CircuitDeskTop;
        private System.Windows.Forms.ContextMenuStrip CMElements;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox GBFitting;
        private System.Windows.Forms.Button BtnFindFit;
        public System.Windows.Forms.ComboBox CBFitMethod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox GBElement;
        private System.Windows.Forms.TextBox TBElementKind;
        private System.Windows.Forms.TextBox TBElementName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TBElementVal1;
        private System.Windows.Forms.Label ElementVal1Name;
        private System.Windows.Forms.TextBox TBElementVal2;
        private System.Windows.Forms.Label ElementVal2Name;
    }




}