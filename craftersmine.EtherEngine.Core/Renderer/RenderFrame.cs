using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using craftersmine.EtherEngine.Content;
using craftersmine.EtherEngine.Core;
using SharpDX;
using SharpDX.Direct2D1;

namespace craftersmine.EtherEngine.Renderer
{
    /// <summary>
    /// Represents a render target where you can draw. This class cannot be inherited
    /// </summary>
    public sealed class RenderFrame
    {
        private RenderTarget RenderTarget { get; set; }

        private RenderFrame() { }

        internal RenderFrame(RenderTarget renderTarget)
        {
            RenderTarget = renderTarget;
        }

        /// <summary>
        /// Draws texture in specified location, within specified boundings
        /// </summary>
        /// <param name="texture">Texture to draw</param>
        /// <param name="x">Position to draw along X axis</param>
        /// <param name="y">Position to draw along Y axis</param>
        /// <param name="width">Width of drawing boundings</param>
        /// <param name="height">Height of drawing boundings</param>
        /// <param name="interpolationMode">Overriden texture interpolation mode</param>
        /// <param name="opacity">Opacity of texture</param>
        public void DrawTexture(Texture texture, float x, float y, float width, float height, float opacity, Core.InterpolationMode interpolationMode)
        {
            DrawTexture(texture, new Core.Rectangle(x, y, width, height), opacity, interpolationMode);
        }
        
        /// <summary>
        /// Draws texture within specified drawing boundings
        /// </summary>
        /// <param name="texture">Texture to draw</param>
        /// <param name="drawingBoundings">Drawing boundings, including position</param>
        /// <param name="opacity">Opacity of texture</param>
        /// <param name="interpolationMode">Overriden texture interpolation mode</param>
        public void DrawTexture(Texture texture, Core.Rectangle drawingBoundings, float opacity, Core.InterpolationMode interpolationMode)
        {
            RenderTarget.DrawBitmap(texture.Bitmap, drawingBoundings.RawRectangle, opacity, (BitmapInterpolationMode)interpolationMode);
        }

        /// <summary>
        /// Draws texture within specified drawing boundings
        /// </summary>
        /// <param name="texture">Texture to draw</param>
        /// <param name="drawingBoundings">Drawing boundings, including position</param>
        /// <param name="opacity">Opacity of texture</param>
        public void DrawTexture(Texture texture, Core.Rectangle drawingBoundings, float opacity)
        {
            DrawTexture(texture, drawingBoundings, opacity, Game.Renderer.InterpolationMode);
        }

        /// <summary>
        /// Draws texture within specified drawing boundings
        /// </summary>
        /// <param name="texture">Texture to draw</param>
        /// <param name="drawingBoundings">Drawing boundings, including position</param>
        public void DrawTexture(Texture texture, Core.Rectangle drawingBoundings)
        {
            DrawTexture(texture, drawingBoundings, 1f);
        }

        /// <summary>
        /// Draws texture within specified drawing boundings
        /// </summary>
        /// <param name="texture">Texture to draw</param>
        /// <param name="drawingBoundings">Drawing boundings, including position</param>
        /// <param name="interpolationMode">Overriden texture interpolation mode</param>
        public void DrawTexture(Texture texture, Core.Rectangle drawingBoundings, Core.InterpolationMode interpolationMode)
        {
            DrawTexture(texture, drawingBoundings, 1f, interpolationMode);
        }

        /// <summary>
        /// Draws texture at specified location, within specified boundings
        /// </summary>
        /// <param name="texture">Texture to draw</param>
        /// <param name="x">Position along X axis</param>
        /// <param name="y">Position along Y axis</param>
        /// <param name="width">Width of drawing boudings</param>
        /// <param name="height">Height of drawing boundings</param>
        /// <param name="opacity">Opacity of texture</param>
        public void DrawTexture(Texture texture, float x, float y, float width, float height, float opacity)
        {
            DrawTexture(texture, x, y, width, height, opacity, Game.Renderer.InterpolationMode);
        }

        /// <summary>
        /// Draws texture at specified location, within specified boundings
        /// </summary>
        /// <param name="texture">Texture to draw</param>
        /// <param name="x">Position along X axis</param>
        /// <param name="y">Position along Y axis</param>
        /// <param name="width">Width of drawing boundings</param>
        /// <param name="height">Height of drawing boundings</param>
        /// <param name="interpolationMode">Overriden texture interpolation mode</param>
        public void DrawTexture(Texture texture, float x, float y, float width, float height, Core.InterpolationMode interpolationMode)
        {
            DrawTexture(texture, x, y, width, height, 1f, interpolationMode);
        }
    }
}
