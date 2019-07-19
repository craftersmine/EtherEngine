using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.Direct2D1;

namespace craftersmine.EtherEngine.Renderer
{
    /// <summary>
    /// Represents a renderable object
    /// </summary>
    interface IRenderable
    {
        /// <summary>
        /// Called when renderer performs frame draw
        /// </summary>
        /// <param name="renderFrame">Render frame where you can draw</param>
        void OnRender(RenderFrame renderFrame);
    }
}
