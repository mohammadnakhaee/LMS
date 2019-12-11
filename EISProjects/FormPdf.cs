using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;


namespace EISProjects
{
    public partial class FormPdf : Form
    {
        Process process;
        public FormPdf()
        {
            InitializeComponent();
        }

        private void FormPdf_Shown(object sender, EventArgs e)
        {
            process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            process.StartInfo = startInfo;
            startInfo.FileName = @"..\Help\Tutorial.pdf";
            process.Start();
            if (!string.IsNullOrWhiteSpace(@"..\Help\Tutorial.pdf"))
            {
                webBrowser1.Navigate(@"..\Help\Tutorial.pdf");
            }

        }

        private void FormPdf_FormClosing(object sender, FormClosingEventArgs e)
        {
            process.Dispose();
        }
    }
}