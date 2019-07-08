using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.Direct2D1;

namespace craftersmine.EtherEngine.Renderer
{
    interface IRenderable
    {
        void OnRender(RenderTarget renderTarget);
    }
}
