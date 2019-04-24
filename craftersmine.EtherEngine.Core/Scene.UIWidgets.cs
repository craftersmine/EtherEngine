using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.EtherEngine.Core
{
    public partial class Scene
    {
        internal List<UIWidget> UIWidgets = new List<UIWidget>();

        public void AddUIWidget(UIWidget widget)
        {
            UIWidgets.Add(widget);
            widget.InternalCreate();
        }

        public void RemoveUIWidget(UIWidget widget)
        {
            UIWidgets.Remove(widget);
        }
    }
}
