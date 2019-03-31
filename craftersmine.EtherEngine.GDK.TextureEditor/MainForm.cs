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
    public partial class MainForm : Form
    {
        private bool isFileOpened = false;
        private bool isFileSaved = false;
        private bool isFileCreated = false;
        private string filePath = "";

        public MainForm(string[] args)
        {
            InitializeComponent();
            if (args.Length > 0)
            {
                OpenImage(args[0]);
            }
        }

        private void OpenImage(string filepath)
        {
            imageContainer.Image = FileHelper.LoadImage(filepath);
            isFileOpened = true;
            isFileSaved = true;
            filePath = filepath;
            UpdateUI();
        }

        private void UpdateUI()
        {
            saveTool.Enabled = isFileOpened || isFileCreated;
            saveToolStripMenuItem.Enabled = isFileOpened || isFileCreated;
            zoomInTool.Enabled = isFileOpened || isFileCreated;
            zoomInToolStripMenuItem.Enabled = isFileOpened || isFileCreated;
            zoomOutTool.Enabled = isFileOpened || isFileCreated;
            zoomOutToolStripMenuItem.Enabled = isFileOpened || isFileCreated;
            zoom11ToolStripMenuItem.Enabled = isFileOpened || isFileCreated;
            resetZoom.Enabled = isFileOpened || isFileCreated;
            clearTextureToolStripMenuItem.Enabled = isFileOpened || isFileCreated;
        }

        private void DrawMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                imageContainer.DrawPixel(rgbColorSelector.SelectedColor, e.X, e.Y);
            }
        }

        private void NewClick(object sender, EventArgs e)
        {
            if (isFileOpened)
            {
                if (imageContainer.IsImageEdited)
                    switch (MessageBox.Show("You have unsaved changes. Save changes before creating a new file?", "Unsaved changes!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information))
                    {
                        case DialogResult.Cancel:
                            return;
                        case DialogResult.Yes:
                            SaveClick(sender, e);
                            CreateImage();
                            break;
                        case DialogResult.No:
                            CreateImage();
                            break;
                    }
                else CreateImage();
            }
            else CreateImage();
        }

        private void CreateImage()
        {
            CreateImageDialog createImageDialog = new CreateImageDialog();
            switch (createImageDialog.ShowDialog())
            {
                case DialogResult.OK:
                    imageContainer.CreateImage(createImageDialog.ImageWidth, createImageDialog.ImageHeight);
                    isFileCreated = true;
                    break;
                case DialogResult.Cancel:
                    imageContainer.RemoveImage();
                    isFileCreated = false;
                    break;
            }
            UpdateUI();
        }

        private void SaveClick(object sender, EventArgs e)
        {
            if (isFileOpened)
            {
                if (!isFileSaved)
                {
                    FileHelper.SaveImage(filePath, imageContainer.EditedImage);
                    isFileSaved = true;
                }
            }
            else
            {
                SaveAsClick(sender, e);
            }
        }

        private void SaveAsClick(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog() {
                Filter = "All Supported Image Formats (*.etx; *.png; *.jpeg; *.jpg; *.gif; *.bmp)|*.etx;*.png;*.jpeg;*.jpg;*.gif;*.bmp|craftersmine EtherEngine Texture File (*.etx)|*.etx|Portable Network Graphics (*.png)|*.png|Joint Photographic Experts Group Image (*.jpg, *.jpeg)|*.jpg;*.jpeg|Graphical Interchange Format File (*.gif)|*.gif|Windows Bitmap Image (*.bmp)|*.bmp|All Files (*.*)|*.*",
                DefaultExt = ".etx",
                FileName = "Unnamed.etx",
                FilterIndex = 1,
                Title = "Select directory and enter filename of saving file"
            };
            switch (dialog.ShowDialog())
            {
                case DialogResult.OK:
                    try
                    {
                        FileHelper.SaveImage(dialog.FileName, imageContainer.EditedImage);
                        isFileSaved = true;
                        OpenImage(dialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Unable to save image to file! Message: " + ex.Message, "Error while saving!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        isFileSaved = false;
                    }
                    break;
            }
        }

        private void ImageEdited(object sender, EventArgs e)
        {
            isFileSaved = false;
        }

        private void OpenClick(object sender, EventArgs e)
        {
            if (isFileOpened)
            {
                if (imageContainer.IsImageEdited)
                    switch (MessageBox.Show("You have unsaved changes. Save changes before opening a file?", "Unsaved changes!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information))
                    {
                        case DialogResult.Cancel:
                            return;
                        case DialogResult.Yes:
                            SaveClick(sender, e);
                            PerformOpen();
                            break;
                        case DialogResult.No:
                            PerformOpen();
                            break;
                    }
                else PerformOpen();
            }
            else PerformOpen();
        }

        private void PerformOpen()
        {
            isFileOpened = false;
            isFileSaved = false;
            filePath = "";
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All Supported Image Formats (*.etx; *.png; *.jpeg; *.jpg; *.gif; *.bmp)|*.etx;*.png;*.jpeg;*.jpg;*.gif;*.bmp|craftersmine EtherEngine Texture File (*.etx)|*.etx|Portable Network Graphics (*.png)|*.png|Joint Photographic Experts Group Image (*.jpg, *.jpeg)|*.jpg;*.jpeg|Graphical Interchange Format File (*.gif)|*.gif|Windows Bitmap Image (*.bmp)|*.bmp|All Files (*.*)|*.*";
            dialog.Title = "Select image file to open";
            dialog.Multiselect = false;
            switch (dialog.ShowDialog())
            {
                case DialogResult.OK:
                    filePath = dialog.FileName;
                    OpenImage(dialog.FileName);
                    break;
                case DialogResult.Cancel:
                    imageContainer.RemoveImage();
                    break;
            }
        }
    }
}
