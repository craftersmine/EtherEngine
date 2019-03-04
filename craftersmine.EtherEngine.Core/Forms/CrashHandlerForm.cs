using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using craftersmine.EtherEngine.Utilities;

namespace craftersmine.EtherEngine.Core.Forms
{
    internal partial class CrashHandlerForm : Form
    {
        public CrashHandlerForm(Exception ex)
        {
            InitializeComponent();
            icon.Image = SystemIcons.Error.ToBitmap();
            msg.Text = msg.Text.Replace("{message}", ex.Message);
            hres.Text = hres.Text.Replace("{hres}", "0x" + ex.HResult.ToString("X"));
            stacktrace.Text = ex.StackTrace;
            stacktrace.DeselectAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                File.Copy(Debugging.Logger.LogFile, Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), Path.GetFileName(Debugging.Logger.LogFile)));
                MessageBox.Show("Log file has successfully copied to Desktop. It named as " + Path.GetFileName(Debugging.Logger.LogFile), "Log file copied!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Unable to copy log file to Desktop", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
