using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using craftersmine.EtherEngine.Rendering;

namespace craftersmine.EtherEngine.Core
{
    public sealed class SettingsController
    {
        public static float MasterVolume { get; set; }

        public static VSyncMode VSyncMode { get { return Window.CurrentWindow.VSyncMode; } set { Window.CurrentWindow.VSyncMode = value; } }
        
        public static bool IsFullscreen { get { return Window.CurrentWindow.IsFullscreen; } set { Window.CurrentWindow.ChangeFullscreenMode(value); } }

        public static WindowSize Resolution { get { return Window.CurrentWindow.WindowSize; } set { Window.CurrentWindow.ChangeResolution(value); } }
    }
}
