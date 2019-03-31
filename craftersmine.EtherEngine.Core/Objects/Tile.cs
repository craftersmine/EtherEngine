namespace craftersmine.EtherEngine.Core
{
    /// <summary>
    /// Represents a world tile
    /// </summary>
    public class Tile : GameObject
    {
        /// <summary>
        /// Gets or sets tile position along X axis relative to <see cref="Tileset"/>
        /// </summary>
        public int TilesetX { get; set; }
        /// <summary>
        /// Gets or sets tile position along Y axis relative to <see cref="Tileset"/>
        /// </summary>
        public int TilesetY { get; set; }
        /// <summary>
        /// Gets or sets internal Tile id. May be useful for specific actions
        /// </summary>
        public string TileId { get; set; }

        /// <summary>
        /// Creates a new instance of <see cref="Tile"/>
        /// </summary>
        public Tile()
        {

        }
    }
}