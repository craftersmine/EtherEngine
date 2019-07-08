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

namespace craftersmine.EtherEngine.Core
{
    internal partial class CrashHandlerForm : Form
    {
        public CrashHandlerForm(Exception ex)
        {
            InitializeComponent();
            icon.Image = SystemIcons.Error.ToBitmap();
            Icon = SystemIcons.Error;
            msg.Text = msg.Text.Replace("{message}", ex.Message.Replace("\r\n", " ").Replace("\r", " ").Replace("\n", " ").Replace(Environment.NewLine, " "));
            hres.Text = hres.Text.Replace("{hres}", "0x" + ex.HResult.ToString("X"));
            exception.Text = exception.Text.Replace("{exception}", ex.GetType().ToString());
            CollectRecursiveStacktrace(ex);
            stacktrace.DeselectAll();
        }

        private void CollectRecursiveStacktrace(Exception ex)
        {
            stacktrace.Text = "An exception has occured!" + Environment.NewLine + Environment.NewLine;
            stacktrace.Text += "Exception: " + ex.GetType().ToString() + Environment.NewLine;
            stacktrace.Text += "Error Message: " + ex.Message + Environment.NewLine;
            stacktrace.Text += "Stacktrace: " + Environment.NewLine;
            if (ex.StackTrace != null)
                stacktrace.Text += ex.StackTrace + Environment.NewLine;
            else stacktrace.Text += "No stacktrace collected!" + Environment.NewLine;
            if (ex.InnerException != null)
            {
                stacktrace.Text += Environment.NewLine;
                CollectRecursiveStacktrace(ex.InnerException);
            }
            else stacktrace.Text += Environment.NewLine + "End of collected exception data.";
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
