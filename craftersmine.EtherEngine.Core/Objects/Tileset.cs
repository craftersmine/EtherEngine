using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using craftersmine.EtherEngine.Content;

namespace craftersmine.EtherEngine.Core
{
    public sealed class Tileset : GameObject
    {
        private List<Tile> _tiles = new List<Tile>();
        private Dictionary<string, Tile> _tilesPresets = new Dictionary<string, Tile>();

        public TextureSet TilesTextures { get; private set; }
        public int TileWidth { get; private set; }
        public int TileHeight { get; private set; }
        public TileOnUpdateAction TileOnUpdateAction { get; set; }

        public Tileset(TextureSet tilesTextures, int tileWidth, int tileHeight)
        {
            TilesTextures = tilesTextures;
        }

        public override void OnUpdate()
        {
            foreach (Tile tile in _tiles)
            {
                TileOnUpdateAction?.Invoke(tile);
            }
        }

        public Tile CheckTile(int x, int y)
        {
            throw new NotImplementedException("[WIP] CheckTile is not implemented yet");
        }
        
        public void AddTile(string tilePresetId, int x, int y)
        {
            try
            {
                Tile clonedTile = _tilesPresets[tilePresetId].Clone<Tile>();
                clonedTile.TilesetX = x;
                clonedTile.TilesetY = y;
                _tiles.Add(clonedTile);
            }
            catch { }
        }

        /// <summary>
        /// Tries to add preset of tile and returns true if success, otherwise false
        /// </summary>
        /// <param name="tile"></param>
        /// <returns></returns>
        public bool AddTilePreset(Tile tile)
        {
            if (!_tilesPresets.ContainsKey(tile.TileId))
            {
                _tilesPresets.Add(tile.TileId, tile);
                return true;
            }
            else return false;
        }
    }

    public delegate void TileOnUpdateAction(Tile updatingTile);
}
