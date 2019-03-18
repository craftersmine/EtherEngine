namespace craftersmine.EtherEngine.Core
{
    public class Tile : GameObject
    {
        public int TilesetX { get; set; }
        public int TilesetY { get; set; }
        public string TileId { get; set; }

        public Tile(int tilesetX, int tilesetY)
        {
            TilesetX = tilesetX;
            TilesetY = tilesetY;
        }
    }
}