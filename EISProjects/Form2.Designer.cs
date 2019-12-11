namespace EISProjects
{
    partial class Form2
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
            this.LVoltage = new System.Windows.Forms.Label();
            this.LCurrent = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnNo = new System.Windows.Forms.Button();
            this.BtnYes = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LVoltage
            // 
            this.LVoltage.AutoSize = true;
            this.LVoltage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LVoltage.Location = new System.Drawing.Point(99, 40);
            this.LVoltage.Name = "LVoltage";
            this.LVoltage.Size = new System.Drawing.Size(39, 20);
            this.LVoltage.TabIndex = 0;
            this.LVoltage.Text = "------";
            // 
            // LCurrent
            // 
            this.LCurrent.AutoSize = true;
            this.LCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LCurrent.Location = new System.Drawing.Point(99, 64);
            this.LCurrent.Name = "LCurrent";
            this.LCurrent.Size = new System.Drawing.Size(39, 20);
            this.LCurrent.TabIndex = 1;
            this.LCurrent.Text = "------";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(30, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(344, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Warning: You are going to get eis in non zero current";
            this.label1.Visible = false;
            // 
            // BtnNo
            // 
            this.BtnNo.Location = new System.Drawing.Point(214, 114);
            this.BtnNo.Name = "BtnNo";
            this.BtnNo.Size = new System.Drawing.Size(75, 23);
            this.BtnNo.TabIndex = 3;
            this.BtnNo.Text = "No";
            this.BtnNo.UseVisualStyleBackColor = true;
            this.BtnNo.Click += new System.EventHandler(this.BtnNo_Click);
            // 
            // BtnYes
            // 
            this.BtnYes.Location = new System.Drawing.Point(295, 114);
            this.BtnYes.Name = "BtnYes";
            this.BtnYes.Size = new System.Drawing.Size(75, 23);
            this.BtnYes.TabIndex = 4;
            this.BtnYes.Text = "Yes";
            this.BtnYes.UseVisualStyleBackColor = true;
            this.BtnYes.Click += new System.EventHandler(this.BtnYes_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(291, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Check voltage and current. Do you want to continue?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Voltage:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Current:";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 147);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnYes);
            this.Controls.Add(this.BtnNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LCurrent);
            this.Controls.Add(this.LVoltage);
            this.Name = "Form2";
            this.Text = "DC voltage and current";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LVoltage;
        private System.Windows.Forms.Label LCurrent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnNo;
        private System.Windows.Forms.Button BtnYes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}