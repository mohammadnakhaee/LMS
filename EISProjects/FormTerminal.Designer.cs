namespace EISProjects
{
    partial class FormTerminal
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TBWaitTime = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RBSlashn = new System.Windows.Forms.RadioButton();
            this.RBExact = new System.Windows.Forms.RadioButton();
            this.RBSlashr = new System.Windows.Forms.RadioButton();
            this.BtnClear = new System.Windows.Forms.Button();
            this.TBOrder = new System.Windows.Forms.TextBox();
            this.TBOutput = new System.Windows.Forms.RichTextBox();
            this.TimerReceiver = new System.Windows.Forms.Timer(this.components);
            this.History = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.BtnClear);
            this.panel1.Controls.Add(this.TBOrder);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 419);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(718, 86);
            this.panel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.TBWaitTime);
            this.groupBox2.Location = new System.Drawing.Point(545, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(157, 48);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Receiver Options";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "(Sec)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Wait:";
            // 
            // TBWaitTime
            // 
            this.TBWaitTime.Location = new System.Drawing.Point(52, 18);
            this.TBWaitTime.Name = "TBWaitTime";
            this.TBWaitTime.Size = new System.Drawing.Size(43, 20);
            this.TBWaitTime.TabIndex = 0;
            this.TBWaitTime.Text = "5";
            this.TBWaitTime.TextChanged += new System.EventHandler(this.TBWaitTime_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RBSlashn);
            this.groupBox1.Controls.Add(this.RBExact);
            this.groupBox1.Controls.Add(this.RBSlashr);
            this.groupBox1.Location = new System.Drawing.Point(205, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(322, 49);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sender Option";
            // 
            // RBSlashn
            // 
            this.RBSlashn.AutoSize = true;
            this.RBSlashn.Location = new System.Drawing.Point(229, 19);
            this.RBSlashn.Name = "RBSlashn";
            this.RBSlashn.Size = new System.Drawing.Size(77, 17);
            this.RBSlashn.TabIndex = 4;
            this.RBSlashn.TabStop = true;
            this.RBSlashn.Text = "Word + \\ n";
            this.RBSlashn.UseVisualStyleBackColor = true;
            // 
            // RBExact
            // 
            this.RBExact.AutoSize = true;
            this.RBExact.Location = new System.Drawing.Point(15, 19);
            this.RBExact.Name = "RBExact";
            this.RBExact.Size = new System.Drawing.Size(78, 17);
            this.RBExact.TabIndex = 2;
            this.RBExact.TabStop = true;
            this.RBExact.Text = "Exact word";
            this.RBExact.UseVisualStyleBackColor = true;
            // 
            // RBSlashr
            // 
            this.RBSlashr.AutoSize = true;
            this.RBSlashr.Location = new System.Drawing.Point(123, 19);
            this.RBSlashr.Name = "RBSlashr";
            this.RBSlashr.Size = new System.Drawing.Size(74, 17);
            this.RBSlashr.TabIndex = 3;
            this.RBSlashr.TabStop = true;
            this.RBSlashr.Text = "Word + \\ r";
            this.RBSlashr.UseVisualStyleBackColor = true;
            // 
            // BtnClear
            // 
            this.BtnClear.Location = new System.Drawing.Point(10, 42);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(172, 23);
            this.BtnClear.TabIndex = 1;
            this.BtnClear.Text = "Clear Terminal";
            this.BtnClear.UseVisualStyleBackColor = true;
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // TBOrder
            // 
            this.TBOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.TBOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBOrder.Location = new System.Drawing.Point(0, 0);
            this.TBOrder.Name = "TBOrder";
            this.TBOrder.Size = new System.Drawing.Size(714, 23);
            this.TBOrder.TabIndex = 0;
            this.TBOrder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TBOrder_KeyDown);
            // 
            // TBOutput
            // 
            this.TBOutput.BackColor = System.Drawing.Color.White;
            this.TBOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TBOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBOutput.Location = new System.Drawing.Point(0, 0);
            this.TBOutput.Name = "TBOutput";
            this.TBOutput.ReadOnly = true;
            this.TBOutput.Size = new System.Drawing.Size(718, 419);
            this.TBOutput.TabIndex = 1;
            this.TBOutput.Text = "";
            // 
            // TimerReceiver
            // 
            this.TimerReceiver.Tick += new System.EventHandler(this.TimerReceiver_Tick);
            // 
            // History
            // 
            this.History.Dock = System.Windows.Forms.DockStyle.Fill;
            this.History.FormattingEnabled = true;
            this.History.ItemHeight = 18;
            this.History.Location = new System.Drawing.Point(3, 20);
            this.History.Name = "History";
            this.History.Size = new System.Drawing.Size(204, 482);
            this.History.TabIndex = 7;
            this.History.Click += new System.EventHandler(this.History_Click);
            this.History.DoubleClick += new System.EventHandler(this.History_DoubleClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.History);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(718, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(210, 505);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Command History";
            // 
            // FormTerminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 505);
            this.Controls.Add(this.TBOutput);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox3);
            this.Name = "FormTerminal";
            this.Text = "Terminal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTerminal_FormClosing);
            this.Load += new System.EventHandler(this.FormTerminal_Load);
            this.Shown += new System.EventHandler(this.FormTerminal_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormTerminal_Paint);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnClear;
        private System.Windows.Forms.TextBox TBOrder;
        private System.Windows.Forms.RichTextBox TBOutput;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RBSlashn;
        private System.Windows.Forms.RadioButton RBExact;
        private System.Windows.Forms.RadioButton RBSlashr;
        private System.Windows.Forms.Timer TimerReceiver;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TBWaitTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox History;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}