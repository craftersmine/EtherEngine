using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using craftersmine.EtherEngine.Content;

namespace craftersmine.EtherEngine.Core
{
    /// <summary>
    /// Represents an material
    /// </summary>
    public sealed class Material
    {
        /// <summary>
        /// Gets or sets texture blend mode
        /// </summary>
        public BlendMode BlendMode { get; set; }
        /// <summary>
        /// Gets or sets texture tiling mode
        /// </summary>
        public TilingMode TilingMode { get; set; }
        /// <summary>
        /// Gets or sets material texture
        /// </summary>
        public Texture Texture { get; set; }
        /// <summary>
        /// Gets or sets material opacity
        /// </summary>
        public float Opacity { get; set; }

        /// <summary>
        /// Creates new instance of <see cref="Material"/> with default texture
        /// </summary>
        public Material()
        {
            Opacity = 1f;
            TilingMode = TilingMode.Stretch;
            BlendMode = BlendMode.None;
        }

        /// <summary>
        /// Creates new instance of <see cref="Material"/> with specified texture
        /// </summary>
        /// <param name="texture"></param>
        public Material(Texture texture)
        {
            Texture = texture;
            Opacity = 1f;
            TilingMode = TilingMode.Stretch;
            BlendMode = BlendMode.None;
        }
    }
}
