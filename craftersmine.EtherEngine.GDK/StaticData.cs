using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using craftersmine.EtherEngine.GDK.Core;
using craftersmine.EtherEngine.GDK.Properties;

namespace craftersmine.EtherEngine.GDK
{
    public sealed class StaticData
    {
        public static LocaleManager LocaleManager { get; set; }
        public static Settings Settings { get; set; }

        public static Project CurrentProject { get; set; }
    }
}
