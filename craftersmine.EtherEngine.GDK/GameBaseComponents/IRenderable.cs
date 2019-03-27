using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using craftersmine.EtherEngine.Content;
using craftersmine.EtherEngine.Rendering;

namespace craftersmine.EtherEngine.GDK.GameBaseComponents
{
    /// <summary>
    /// Provides functionality to render game object
    /// </summary>
    public interface IRenderable
    {
        /// <summary>
        /// Gets of sets texture to render
        /// </summary>
        Texture Texture { get; set; }
        /// <summary>
        /// Gets or sets transformation properties to render
        /// </summary>
        Transform Transform { get; set; }

        /// <summary>
        /// Calls when game object is being rendered
        /// </summary>
        /// <param name="renderer"></param>
        void OnRender(GLGDI renderer);
    }
}
