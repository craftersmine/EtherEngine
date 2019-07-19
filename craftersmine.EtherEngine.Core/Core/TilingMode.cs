using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace craftersmine.EtherEngine.Core
{
    /// <summary>
    /// Contains all possible texture tiling modes
    /// </summary>
    public enum TilingMode
    {
        /// <summary>
        /// Stretches texture on whole bounding box
        /// </summary>
        Stretch,
        /// <summary>
        /// Centers texture within bounding box
        /// </summary>
        Center,
        /// <summary>
        /// Tiles texture within bounding box
        /// </summary>
        Tile
    }
}
