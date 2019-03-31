using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace craftersmine.EtherEngine.GDK.TextureEditor
{
    public partial class CreateImageDialog : Form
    {
        private bool isDimensionsCorrect = false;

        public int ImageWidth { get; private set; }
        public int ImageHeight { get; private set; }

        public CreateImageDialog()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            if (int.TryParse(width.Text, out int wid))
            {
                ImageWidth = wid;
                isDimensionsCorrect = true;
            }
            else
            {
                MessageBox.Show("Width must be a numeric value!", "Invalid value!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isDimensionsCorrect = false;
            }
            if (int.TryParse(width.Text, out int hei))
            {
                ImageHeight = hei;
                isDimensionsCorrect = true;
            }
            else
            {
                MessageBox.Show("Height must be a numeric value!", "Invalid value!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isDimensionsCorrect = false;
            }
            if (isDimensionsCorrect)
                this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
