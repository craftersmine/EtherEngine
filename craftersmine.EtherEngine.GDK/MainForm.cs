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
using craftersmine.EtherEngine.GDK.Core;

namespace craftersmine.EtherEngine.GDK
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void SaveEventHandler(object sender, EventArgs e)
        {
            if (StaticData.CurrentProject != null)
            {
                StaticData.CurrentProject.Save();
            }
        }

        private void OpenEventHandler(object sender, EventArgs e)
        {
            if (StaticData.CurrentProject == null)
            {
                _openProject();
            }
            else
                switch (MessageBox.Show("You have opened project yet! Do you want to save it before opening another?", "Saving before opening", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information))
                {
                    case DialogResult.Yes:
                        StaticData.CurrentProject.Save();
                        _openProject();
                        break;
                    case DialogResult.No:
                        _closeProject(false);
                        _openProject();
                        break;
                    case DialogResult.Cancel:
                        break;
                }
        }

        private void _openProject()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "craftersmine EtherEngine GDK Project File (*.gdkproj)|*.gdkproj|All Files|*.*";
            dialog.Title = "Select file to open";
            dialog.Multiselect = false;
            dialog.FileOk += Dialog_FileOk;
            dialog.ShowDialog();
        }

        private void _closeProject(bool askForSave)
        {
            if (askForSave)
            {
                switch (MessageBox.Show("You have opened project yet! Do you want to save it before closing?", "Saving before opening", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information))
                {
                    case DialogResult.Yes:
                        StaticData.CurrentProject.Save();
                        _closeProject(false);
                        break;
                    case DialogResult.No:
                        _closeProject(false);
                        break;
                    case DialogResult.Cancel:
                        break;
                }
            }
            else StaticData.CurrentProject = null;
            _switchEnabledOpen(false);
        }

        private void Dialog_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                StaticData.CurrentProject = Project.Open((sender as OpenFileDialog).FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open selected file! File might be corrupted, moved or deleted!", "Error while opening project!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                StaticData.CurrentProject = null;
            }

            if (StaticData.CurrentProject != null)
            {
                PrepareEnvironment();
                _switchEnabledOpen(true);
            }
        }

        private void PrepareEnvironment()
        {
            projectTree.Nodes.Add(new TreeNode("Project Root", 3, 3));
            _populateTreeView(projectTree.Nodes[0], StaticData.CurrentProject.ProjectFiles);
        }

        private void _switchEnabledOpen(bool state)
        {
            saveMenu.Enabled = state;
            saveTool.Enabled = state;
            projectMenu.Enabled = state;
            closeMenu.Enabled = state;
            splitContainer1.Panel1.Enabled = state;
        }

        private static void _populateTreeView(TreeNode rootNode, IEnumerable<string> paths)
        {
            TreeNode lastNode = null;
            string subPathAgg;
            foreach (string path in paths)
            {
                string tempPath = path.Replace('/', '\\');
                subPathAgg = string.Empty;
                foreach (string subPath in tempPath.Split('\\'))
                {
                    subPathAgg += subPath + '\\';
                    TreeNode[] nodes = rootNode.Nodes.Find(subPathAgg, true);
                    if (nodes.Length == 0)
                    {
                        TreeNode node = new TreeNode(subPathAgg, 0, 1);
                        switch (Path.GetExtension(subPathAgg))
                        {
                            case "etx":
                                node.SelectedImageIndex = 5;
                                node.ImageIndex = 5;
                                break;
                            case "epm":
                                node.SelectedImageIndex = 2;
                                node.ImageIndex = 2;
                                break;
                            case "eam":
                                node.SelectedImageIndex = 4;
                                node.ImageIndex = 4;
                                break;
                            default:
                                node.SelectedImageIndex = 2;
                                node.ImageIndex = 2;
                                break;
                        }
                        if (lastNode == null)
                        {
                            lastNode = node;
                            rootNode.Nodes.Add(node);
                        }
                        else
                        {
                            lastNode = node;
                            lastNode.Nodes.Add(node);
                        }
                    }
                    else
                        lastNode = nodes[0];
                }
                lastNode = null;

            }
        }
    }
}
