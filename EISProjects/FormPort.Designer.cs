namespace EISProjects
{
    partial class FormPort
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPort));
            this.BtnDisconnect = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.BtnShowPorts = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.PortprogressBar = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.firmWareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateProgressbar = new System.Windows.Forms.ProgressBar();
            this.UpdatePageProgressbar = new System.Windows.Forms.ProgressBar();
            this.notification1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnDisconnect
            // 
            this.BtnDisconnect.Location = new System.Drawing.Point(312, 156);
            this.BtnDisconnect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnDisconnect.Name = "BtnDisconnect";
            this.BtnDisconnect.Size = new System.Drawing.Size(236, 34);
            this.BtnDisconnect.TabIndex = 1;
            this.BtnDisconnect.Text = "Disconnect";
            this.BtnDisconnect.UseVisualStyleBackColor = true;
            this.BtnDisconnect.Click += new System.EventHandler(this.BtnDisconnect_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(8, 28);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(211, 11);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            this.richTextBox1.Visible = false;
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // BtnShowPorts
            // 
            this.BtnShowPorts.Location = new System.Drawing.Point(33, 156);
            this.BtnShowPorts.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnShowPorts.Name = "BtnShowPorts";
            this.BtnShowPorts.Size = new System.Drawing.Size(236, 34);
            this.BtnShowPorts.TabIndex = 3;
            this.BtnShowPorts.Text = "Detect and Connect";
            this.BtnShowPorts.UseVisualStyleBackColor = true;
            this.BtnShowPorts.Click += new System.EventHandler(this.BtnShowPorts_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(109, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "SH.S.";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(157, 111);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(75, 22);
            this.textBox1.TabIndex = 10;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 114);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Checking time out:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Location = new System.Drawing.Point(317, 31);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(231, 105);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "List of devices:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 48);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(212, 28);
            this.button1.TabIndex = 17;
            this.button1.Text = "Test Update";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(233, 114);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "(ms)";
            // 
            // PortprogressBar
            // 
            this.PortprogressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PortprogressBar.Location = new System.Drawing.Point(0, 197);
            this.PortprogressBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PortprogressBar.Name = "PortprogressBar";
            this.PortprogressBar.Size = new System.Drawing.Size(584, 25);
            this.PortprogressBar.Step = 1;
            this.PortprogressBar.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(88, 59);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 25);
            this.label4.TabIndex = 16;
            this.label4.Text = "Application";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(584, 28);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.firmWareToolStripMenuItem});
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.updateToolStripMenuItem.Text = "Update";
            // 
            // firmWareToolStripMenuItem
            // 
            this.firmWareToolStripMenuItem.Name = "firmWareToolStripMenuItem";
            this.firmWareToolStripMenuItem.Size = new System.Drawing.Size(188, 24);
            this.firmWareToolStripMenuItem.Text = "update firmware";
            this.firmWareToolStripMenuItem.Click += new System.EventHandler(this.firmWareToolStripMenuItem_Click);
            // 
            // UpdateProgressbar
            // 
            this.UpdateProgressbar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.UpdateProgressbar.Location = new System.Drawing.Point(0, 222);
            this.UpdateProgressbar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.UpdateProgressbar.Name = "UpdateProgressbar";
            this.UpdateProgressbar.Size = new System.Drawing.Size(584, 12);
            this.UpdateProgressbar.Step = 1;
            this.UpdateProgressbar.TabIndex = 18;
            // 
            // UpdatePageProgressbar
            // 
            this.UpdatePageProgressbar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.UpdatePageProgressbar.Location = new System.Drawing.Point(0, 234);
            this.UpdatePageProgressbar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.UpdatePageProgressbar.Name = "UpdatePageProgressbar";
            this.UpdatePageProgressbar.Size = new System.Drawing.Size(584, 12);
            this.UpdatePageProgressbar.Step = 1;
            this.UpdatePageProgressbar.TabIndex = 19;
            // 
            // notification1
            // 
            this.notification1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notification1.BalloonTipText = "reconnecting ...";
            this.notification1.BalloonTipTitle = "Connection issue";
            this.notification1.Icon = ((System.Drawing.Icon)(resources.GetObject("notification1.Icon")));
            this.notification1.Text = "Notification";
            this.notification1.Visible = true;
            // 
            // FormPort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 246);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PortprogressBar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnShowPorts);
            this.Controls.Add(this.BtnDisconnect);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.UpdateProgressbar);
            this.Controls.Add(this.UpdatePageProgressbar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormPort";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Connection";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPort_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnDisconnect;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button BtnShowPorts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar PortprogressBar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem firmWareToolStripMenuItem;
        private System.Windows.Forms.ProgressBar UpdateProgressbar;
        private System.Windows.Forms.ProgressBar UpdatePageProgressbar;
        private System.Windows.Forms.NotifyIcon notification1;
    }
}