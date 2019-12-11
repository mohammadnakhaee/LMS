namespace EISProjects
{
    partial class FormVM
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
            this.label1 = new System.Windows.Forms.Label();
            this.BtnShowPorts = new System.Windows.Forms.Button();
            this.BtnDisconnect = new System.Windows.Forms.Button();
            this.BtnConnect = new System.Windows.Forms.Button();
            this.VMPort = new System.IO.Ports.SerialPort(this.components);
            this.VMStatus = new System.Windows.Forms.RichTextBox();
            this.VMTimer = new System.Windows.Forms.Timer(this.components);
            this.CBMaterial = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PortList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Virtual Machine";
            // 
            // BtnShowPorts
            // 
            this.BtnShowPorts.Location = new System.Drawing.Point(12, 42);
            this.BtnShowPorts.Name = "BtnShowPorts";
            this.BtnShowPorts.Size = new System.Drawing.Size(177, 28);
            this.BtnShowPorts.TabIndex = 13;
            this.BtnShowPorts.Text = "Refresh Ports";
            this.BtnShowPorts.UseVisualStyleBackColor = true;
            this.BtnShowPorts.Click += new System.EventHandler(this.BtnShowPorts_Click);
            // 
            // BtnDisconnect
            // 
            this.BtnDisconnect.Enabled = false;
            this.BtnDisconnect.Location = new System.Drawing.Point(12, 308);
            this.BtnDisconnect.Name = "BtnDisconnect";
            this.BtnDisconnect.Size = new System.Drawing.Size(177, 28);
            this.BtnDisconnect.TabIndex = 11;
            this.BtnDisconnect.Text = "Disconnect";
            this.BtnDisconnect.UseVisualStyleBackColor = true;
            this.BtnDisconnect.Click += new System.EventHandler(this.BtnDisconnect_Click);
            // 
            // BtnConnect
            // 
            this.BtnConnect.Enabled = false;
            this.BtnConnect.Location = new System.Drawing.Point(12, 274);
            this.BtnConnect.Name = "BtnConnect";
            this.BtnConnect.Size = new System.Drawing.Size(177, 28);
            this.BtnConnect.TabIndex = 10;
            this.BtnConnect.Text = "Connect";
            this.BtnConnect.UseVisualStyleBackColor = true;
            this.BtnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // VMPort
            // 
            this.VMPort.BaudRate = 57600;
            this.VMPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.VMPort_DataReceived);
            // 
            // VMStatus
            // 
            this.VMStatus.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.VMStatus.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.VMStatus.Location = new System.Drawing.Point(12, 346);
            this.VMStatus.Name = "VMStatus";
            this.VMStatus.Size = new System.Drawing.Size(176, 68);
            this.VMStatus.TabIndex = 15;
            this.VMStatus.Text = "";
            // 
            // VMTimer
            // 
            this.VMTimer.Tick += new System.EventHandler(this.VMTimer_Tick);
            // 
            // CBMaterial
            // 
            this.CBMaterial.Enabled = false;
            this.CBMaterial.FormattingEnabled = true;
            this.CBMaterial.Items.AddRange(new object[] {
            "Tester",
            "FeCN"});
            this.CBMaterial.Location = new System.Drawing.Point(79, 243);
            this.CBMaterial.Name = "CBMaterial";
            this.CBMaterial.Size = new System.Drawing.Size(89, 21);
            this.CBMaterial.TabIndex = 16;
            this.CBMaterial.SelectedIndexChanged += new System.EventHandler(this.CBMaterial_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 247);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Material:";
            // 
            // PortList
            // 
            this.PortList.FormattingEnabled = true;
            this.PortList.Location = new System.Drawing.Point(26, 76);
            this.PortList.Name = "PortList";
            this.PortList.Size = new System.Drawing.Size(151, 160);
            this.PortList.TabIndex = 18;
            // 
            // FormVM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(201, 427);
            this.Controls.Add(this.PortList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CBMaterial);
            this.Controls.Add(this.VMStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnShowPorts);
            this.Controls.Add(this.BtnDisconnect);
            this.Controls.Add(this.BtnConnect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormVM";
            this.Text = "VM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormVM_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnShowPorts;
        private System.Windows.Forms.Button BtnDisconnect;
        private System.Windows.Forms.Button BtnConnect;
        private System.IO.Ports.SerialPort VMPort;
        private System.Windows.Forms.RichTextBox VMStatus;
        private System.Windows.Forms.Timer VMTimer;
        private System.Windows.Forms.ComboBox CBMaterial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox PortList;





    }





    public class SessionInputs
    {
        public double DCVltFrom = 0;
        public double DCVltTo = 0;
        public double DCVltStep = 0;

        public double ACAmpFrom = 0;
        public double ACAmpTo = 0;
        public double ACAmpStep = 0;

        public double ACFrqFrom = 0;
        public double ACFrqTo = 0;
        public double ACFrqStep = 0;
    }
}