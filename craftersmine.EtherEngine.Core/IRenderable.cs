using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using craftersmine.EtherEngine.Content;
using craftersmine.EtherEngine.Rendering;

namespace craftersmine.EtherEngine.Core
{
    public interface IRenderable
    {
        Texture Texture { get; set; }
        Transform Transform { get; set; }

        void OnRender(GLGDI renderer);
    }
}
