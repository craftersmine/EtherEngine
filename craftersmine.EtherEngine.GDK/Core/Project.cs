using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace craftersmine.EtherEngine.GDK.Core
{
    [Serializable]
    public sealed class Project
    {
        public string ProjectFilePath { get; set; }
        public string ProjectRoot { get; set; }
        public List<string> ProjectFiles { get; set; } = new List<string>();

        public void Save()
        {
            try
            {
                if (!File.Exists(ProjectFilePath))
                {
                    switch (MessageBox.Show(
                        "Unable to find loaded project path at \"" + ProjectFilePath + "\" path!" +
                        " It may be removed or moved to another location!" +
                        " Save it at this location anyway?", "Unable to locate loaded project!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning))
                    {
                        case DialogResult.Yes:
                            _save();
                            break;
                        case DialogResult.No:
                            SaveFileDialog dialog = new SaveFileDialog();
                            dialog.Filter = "craftersmine EtherEngine GDK Project File (*.gdkproj)|*.gdkproj|All Files|*.*";
                            dialog.Title = "Select project save destination location";
                            dialog.FileName = "Unnamed_Project.gdkproj";
                            dialog.FileOk += Dialog_FileOk;
                            dialog.ShowDialog();
                            break;
                        case DialogResult.Cancel:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void Dialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ProjectFilePath = ((SaveFileDialog)sender).FileName;
            _save();
        }

        private void _save()
        {
            var serializer = new XmlSerializer(typeof(Project));
            using (var writer = XmlWriter.Create(ProjectFilePath))
            {
                serializer.Serialize(writer, this);
            }
        }

        public static Project Open(string filename)
        {
            try
            {
                var deserializer = new XmlSerializer(typeof(Project));
                using (var reader = XmlReader.Create(filename))
                    return deserializer.Deserialize(reader) as Project;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
