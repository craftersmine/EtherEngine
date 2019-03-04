using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using craftersmine.EtherEngine.Core.Forms;
using craftersmine.EtherEngine.Utilities;

namespace craftersmine.EtherEngine.Core
{
    public sealed class CrashHandler
    {
        public static void Handle(Exception ex)
        {
            Debugging.LogException(LogEntryType.Crash, ex);
            new CrashHandlerForm(ex).ShowDialog();
            Game.Exit(ex.HResult);
        }
    }
}
