namespace EISProjects
{
    partial class FormDataGrid
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.CBUnit = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnExportSsn = new System.Windows.Forms.Button();
            this.SessionName = new System.Windows.Forms.ComboBox();
            this.BtnExportAllSsns = new System.Windows.Forms.Button();
            this.SsnGridView = new System.Windows.Forms.DataGridView();
            this.ExportFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SsnGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.CBUnit);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.BtnExportSsn);
            this.panel1.Controls.Add(this.SessionName);
            this.panel1.Controls.Add(this.BtnExportAllSsns);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(887, 35);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(211, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Unit:";
            this.label2.Visible = false;
            // 
            // CBUnit
            // 
            this.CBUnit.FormattingEnabled = true;
            this.CBUnit.Items.AddRange(new object[] {
            "10^-6",
            "10^-3",
            "1",
            "10^3",
            "10^6"});
            this.CBUnit.Location = new System.Drawing.Point(246, 7);
            this.CBUnit.Name = "CBUnit";
            this.CBUnit.Size = new System.Drawing.Size(130, 21);
            this.CBUnit.TabIndex = 4;
            this.CBUnit.Visible = false;
            this.CBUnit.SelectedIndexChanged += new System.EventHandler(this.CBUnit_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Session:";
            // 
            // BtnExportSsn
            // 
            this.BtnExportSsn.Enabled = false;
            this.BtnExportSsn.Location = new System.Drawing.Point(388, 3);
            this.BtnExportSsn.Name = "BtnExportSsn";
            this.BtnExportSsn.Size = new System.Drawing.Size(123, 27);
            this.BtnExportSsn.TabIndex = 2;
            this.BtnExportSsn.Text = "Export Session";
            this.BtnExportSsn.UseVisualStyleBackColor = true;
            this.BtnExportSsn.Click += new System.EventHandler(this.BtnExportSsn_Click);
            // 
            // SessionName
            // 
            this.SessionName.FormattingEnabled = true;
            this.SessionName.Location = new System.Drawing.Point(65, 6);
            this.SessionName.Name = "SessionName";
            this.SessionName.Size = new System.Drawing.Size(130, 21);
            this.SessionName.TabIndex = 1;
            this.SessionName.SelectedIndexChanged += new System.EventHandler(this.SessionName_SelectedIndexChanged);
            // 
            // BtnExportAllSsns
            // 
            this.BtnExportAllSsns.Location = new System.Drawing.Point(517, 3);
            this.BtnExportAllSsns.Name = "BtnExportAllSsns";
            this.BtnExportAllSsns.Size = new System.Drawing.Size(123, 27);
            this.BtnExportAllSsns.TabIndex = 0;
            this.BtnExportAllSsns.Text = "Export All Sessions";
            this.BtnExportAllSsns.UseVisualStyleBackColor = true;
            this.BtnExportAllSsns.Click += new System.EventHandler(this.BtnExportAllSsns_Click);
            // 
            // SsnGridView
            // 
            this.SsnGridView.AllowUserToAddRows = false;
            this.SsnGridView.AllowUserToDeleteRows = false;
            this.SsnGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SsnGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SsnGridView.Location = new System.Drawing.Point(0, 35);
            this.SsnGridView.Name = "SsnGridView";
            this.SsnGridView.ReadOnly = true;
            this.SsnGridView.Size = new System.Drawing.Size(887, 429);
            this.SsnGridView.TabIndex = 1;
            // 
            // ExportFileDialog
            // 
            this.ExportFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.ExportFileDialog_FileOk);
            // 
            // FormDataGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 464);
            this.Controls.Add(this.SsnGridView);
            this.Controls.Add(this.panel1);
            this.Name = "FormDataGrid";
            this.Text = "Data";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDataGrid_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SsnGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnExportSsn;
        public System.Windows.Forms.ComboBox SessionName;
        private System.Windows.Forms.Button BtnExportAllSsns;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView SsnGridView;
        private System.Windows.Forms.SaveFileDialog ExportFileDialog;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox CBUnit;
    }
}