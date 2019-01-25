using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using craftersmine.EtherEngine.Content;

namespace craftersmine.EtherEngine.Core
{
    [Obsolete("Temporary Obsolete")]
    public sealed class Tileset : GameObject
    {
        public bool[,] Tiles;

        public int TileWidth { get; private set; }
        public int TileHeight { get; private set; }

        public Tileset(Texture tileTexture, int tileWidth, int tileHeight, int tilesAlongX, int tilesAlongY)
        {
            Texture = tileTexture;
            Tiles = new bool[tilesAlongX, tilesAlongY];
            for (int x = 0; x < tilesAlongX; x++)
                for (int y = 0; y < tilesAlongY; y++)
                    Tiles[x, y] = false;
        }

        public override void OnUpdate()
        {
            //TiledImage.
        }

        public void AddTile(int x, int y)
        {

        }
    }
}
