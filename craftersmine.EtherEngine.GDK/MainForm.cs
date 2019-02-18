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
using craftersmine.EtherEngine.Utilities;

namespace craftersmine.EtherEngine.GDK
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            StaticData.LocaleManager.LocaleLoaded += LocaleManager_LocaleLoaded;
            Program.Log(LogEntryType.Info, "Applying locale...");
            ApplyLocale();
            Program.Log(LogEntryType.Done, "GDK Loaded!");
        }

        private void LocaleManager_LocaleLoaded(object sender, EventArgs e)
        {
            ApplyLocale();
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
            projectTree.Nodes[0].Expand();
        }

        private void _switchEnabledOpen(bool state)
        {
            saveMenu.Enabled = state;
            mainToolSave.Enabled = state;
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
                string fixedPath = path.Replace('/', Path.DirectorySeparatorChar);
                subPathAgg = string.Empty;
                foreach (string subPath in fixedPath.Split(Path.DirectorySeparatorChar))
                {
                    subPathAgg += subPath + Path.DirectorySeparatorChar;
                    TreeNode[] nodes = rootNode.Nodes.Find(subPathAgg, true);
                    if (nodes.Length == 0)
                        if (lastNode == null)
                            lastNode = rootNode.Nodes.Add(subPathAgg, subPath);
                        else
                            lastNode = lastNode.Nodes.Add(subPathAgg, subPath);
                    else
                        lastNode = nodes[0];
                }
                if (Path.HasExtension(lastNode.Text))
                {
                    string ext = Path.GetExtension(lastNode.Text);
                    switch (ext)
                    {
                        case ".eam":
                            lastNode.ImageIndex = 4;
                            lastNode.SelectedImageIndex = 4;
                            break;
                        case ".etx":
                            lastNode.ImageIndex = 5;
                            lastNode.SelectedImageIndex = 5;
                            break;
                        case ".epm":
                            lastNode.ImageIndex = 2;
                            lastNode.SelectedImageIndex = 2;
                            break;
                        case ".cs":
                            lastNode.ImageIndex = 6;
                            lastNode.SelectedImageIndex = 6;
                            break;
                        default:
                            lastNode.ImageIndex = 2;
                            lastNode.SelectedImageIndex = 2;
                            break;
                    }
                }
                else
                {
                    lastNode.ImageIndex = 0;
                    lastNode.SelectedImageIndex = 1;
                }
                lastNode = null;

            }
        }

        private void projectTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (Path.HasExtension(e.Node.Text))
            {
                switch (Path.GetExtension(e.Node.Text))
                {
                    case ".etx":
                        string treePath = e.Node.FullPath.Replace("Project Root\\", "");
                        string texturePath = Path.Combine(StaticData.CurrentProject.ProjectRoot, treePath);
                        previewBox.BackgroundImage = Image.FromFile(texturePath);
                        break;
                    case ".eam":
                        break;
                    case ".epm":
                        break;
                    case ".cs":
                        break;
                    default:
                        break;
                }
            }
        }

        private void ApplyLocale()
        {
            fileMainMenu.Text = StaticData.LocaleManager.GetLocalizedString((string)fileMainMenu.Tag);
            createMenu.Text = StaticData.LocaleManager.GetLocalizedString((string)createMenu.Tag);
            openMenu.Text = StaticData.LocaleManager.GetLocalizedString((string)openMenu.Tag);
            saveMenu.Text = StaticData.LocaleManager.GetLocalizedString((string)saveMenu.Tag);
            closeMenu.Text = StaticData.LocaleManager.GetLocalizedString((string)closeMenu.Tag);
            exitMenu.Text = StaticData.LocaleManager.GetLocalizedString((string)exitMenu.Tag);

            //.Text = StaticData.LocaleManager.GetLocalizedString((string).Tag);

            editMenu.Text = StaticData.LocaleManager.GetLocalizedString((string)editMenu.Tag);
            duplicateMenu.Text = StaticData.LocaleManager.GetLocalizedString((string)duplicateMenu.Tag);
            deleteToolStripMenuItem.Text = StaticData.LocaleManager.GetLocalizedString((string)deleteToolStripMenuItem.Tag);
            resetToolStripMenuItem.Text = StaticData.LocaleManager.GetLocalizedString((string)resetToolStripMenuItem.Tag);
            editSourceToolStripMenuItem.Text = StaticData.LocaleManager.GetLocalizedString((string)editSourceToolStripMenuItem.Tag);
            
            projectMenu.Text = StaticData.LocaleManager.GetLocalizedString((string)projectMenu.Tag);
            projectCreateToolStripMenuItem.Text = StaticData.LocaleManager.GetLocalizedString((string)projectCreateToolStripMenuItem.Tag);
            sceneToolStripMenuItem.Text = StaticData.LocaleManager.GetLocalizedString((string)sceneToolStripMenuItem.Tag);
            gameObjectToolStripMenuItem.Text = StaticData.LocaleManager.GetLocalizedString((string)gameObjectToolStripMenuItem.Tag);
            textureToolStripMenuItem.Text = StaticData.LocaleManager.GetLocalizedString((string)textureToolStripMenuItem.Tag);
            animationToolStripMenuItem.Text = StaticData.LocaleManager.GetLocalizedString((string)animationToolStripMenuItem.Tag);
            contentPackageToolStripMenuItem.Text = StaticData.LocaleManager.GetLocalizedString((string)contentPackageToolStripMenuItem.Tag);
            buildToolStripMenuItem.Text = StaticData.LocaleManager.GetLocalizedString((string)buildToolStripMenuItem.Tag);
            buildLaunchToolStripMenuItem.Text = StaticData.LocaleManager.GetLocalizedString((string)buildLaunchToolStripMenuItem.Tag);
            projectPropertiesToolStripMenuItem.Text = StaticData.LocaleManager.GetLocalizedString((string)projectPropertiesToolStripMenuItem.Tag);

            serviceToolStripMenuItem.Text = StaticData.LocaleManager.GetLocalizedString((string)serviceToolStripMenuItem.Tag);
            gDKSettingsToolStripMenuItem.Text = StaticData.LocaleManager.GetLocalizedString((string)gDKSettingsToolStripMenuItem.Tag);
        }
    }
}
