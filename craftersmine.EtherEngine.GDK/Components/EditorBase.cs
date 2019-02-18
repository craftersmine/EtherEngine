using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace craftersmine.EtherEngine.GDK.Components
{
    public partial class EditorBase : UserControl
    {
        public EditorBase()
        {
            InitializeComponent();
        }

        public virtual void OnSave()
        { }

        public virtual void UpdateLocales()
        { }
    }
}
