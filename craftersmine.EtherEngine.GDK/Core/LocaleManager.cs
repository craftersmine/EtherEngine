using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using craftersmine.EtherEngine.Utilities;

namespace craftersmine.EtherEngine.GDK.Core
{
    public sealed class LocaleManager
    {
        private bool isFallbackTried = false;

        public Dictionary<string, string> LocalePairs { get; } = new Dictionary<string, string>();
        public Dictionary<string, string> Locales { get; } = new Dictionary<string, string>();

        public event EventHandler LocaleLoaded;

        public void LoadLocalesList()
        {
            string[] localesPaths = Directory.GetFiles(Path.Combine(Application.StartupPath, "resources", "locales"), "*.lang");
            foreach (var path in localesPaths)
            {
                string id = Path.GetFileNameWithoutExtension(path);
                try
                {
                    string[] file = File.ReadAllLines(path);
                    bool isLocaleNameFound = false;
                    foreach (string line in file)
                    {
                        if (line.StartsWith("locale.name"))
                        {
                            string name = line.Split('=')[1];
                            Locales.Add(name, id);
                            isLocaleNameFound = true;
                            break;
                        }
                        else continue;
                    }
                    if (!isLocaleNameFound)
                        throw new Exception("Unable to find \"locale.name\" parameter! If you made this translation, please add this parameter to make it readable to end-user, add like \"locale.name=English\"");
                }
                catch (Exception ex)
                {
                    Program.Log(LogEntryType.Warning, "Unable to load locale " + id + "! Additional information below:");
                    Program.LogException(LogEntryType.Warning, ex);
                }
            }
        }

        public void LoadLocale(string localeCode)
        {
            string localePath = Path.Combine(Application.StartupPath, "resources", "locales", localeCode + ".lang");
            LocalePairs.Clear();
            try
            {
                string[] lines = File.ReadAllLines(localePath);
                foreach (var line in lines)
                {
                    if (!string.IsNullOrEmpty(line) && !string.IsNullOrWhiteSpace(line))
                    {
                        string[] splitted = line.Split('=');
                        if (splitted.Length > 1)
                            if (!string.IsNullOrEmpty(splitted[1]) && !string.IsNullOrWhiteSpace(splitted[1]))
                                LocalePairs.Add(splitted[0], splitted[1]);
                    }
                }
                LocaleLoaded?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                if (!isFallbackTried)
                {
                    MessageBox.Show("Unable to load locale \"" + localeCode + "\"! Falling back to \"English\"...", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Program.Log(LogEntryType.Warning, "Unable to load locale \"" + localeCode + "\"! Falling back to English...");
                    Program.LogException(LogEntryType.Warning, ex);
                    isFallbackTried = true;
                    LoadLocale("en-US");
                }
                else
                {
                    MessageBox.Show("Unable to fallback back to \"English (en-US)\"! GDK environment may been corrupted! Check logs and try to reinstall GDK!", "Locale fallback error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Program.Log(LogEntryType.Error, "Unable to load locale \"" + localeCode + "\"!");
                    Program.LogException(LogEntryType.Error, ex);
                    Environment.Exit(0);
                }
            }
        }

        public string GetLocalizedString(string id)
        {
            if (LocalePairs.ContainsKey(id))
                return LocalePairs[id];
            else return id;
        }
    }
}
