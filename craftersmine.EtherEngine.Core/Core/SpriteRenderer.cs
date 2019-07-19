using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using craftersmine.EtherEngine.Renderer;
using SharpDX.Direct2D1;

namespace craftersmine.EtherEngine.Core
{
    /// <summary>
    /// Represents game object renderer
    /// </summary>
    public class SpriteRenderer : BaseRenderer
    {
        /// <summary>
        /// Gets or sets game object material
        /// </summary>
        public Material Material { get; set; }

        /// <summary>
        /// Called when renderer performs drawings
        /// </summary>
        /// <param name="renderFrame">Render frame where you can draw</param>
        public override void OnRender(RenderFrame renderFrame)
        {
            if (IsCreated)
            {
                if (Material.Texture != null)
                {
                    ParentGameObject.Transform.UpdateBoundsRectangle();
                    renderFrame.DrawTexture(Material.Texture, ParentGameObject.Transform.DrawingBoundings, Material.Opacity, Game.Renderer.InterpolationMode);
                }
            }
        }
    }
}
