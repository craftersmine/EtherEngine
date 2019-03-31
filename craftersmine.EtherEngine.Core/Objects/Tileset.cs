﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using craftersmine.EtherEngine.Content;
using craftersmine.EtherEngine.Utilities;

namespace craftersmine.EtherEngine.Core
{
    /// <summary>
    /// Represents a world tileset. This class cannot be inherited
    /// </summary>
    public sealed class Tileset : GameObject
    {
        private List<Tile> _tiles = new List<Tile>();

        /// <summary>
        /// Gets current tiles width
        /// </summary>
        public int TileWidth { get; private set; }
        /// <summary>
        /// Gets current tiles height
        /// </summary>
        public int TileHeight { get; private set; }
        /// <summary>
        /// Gets or sets <see cref="Tile"/> OnUpdate action
        /// </summary>
        public TileOnUpdateAction TileOnUpdateAction { get; set; }

        /// <summary>
        /// Creates a new instance of <see cref="Tileset"/> with specific tiles size and global tiles OnUpdate action
        /// </summary>
        /// <param name="tileWidth">Width of adding tiles</param>
        /// <param name="tileHeight">Height of adding tiles</param>
        /// <param name="onTileUpdateAction">Tiles global OnUpdate action</param>
        public Tileset(int tileWidth, int tileHeight, TileOnUpdateAction onTileUpdateAction)
        {
            TileWidth = tileWidth;
            TileHeight = tileHeight;
            TileOnUpdateAction = onTileUpdateAction;
        }

        /// <summary>
        /// Occurs when <see cref="Tileset"/> being updated
        /// </summary>
        public override void OnUpdate()
        {
            for (int i = 0; i < _tiles.Count; i++)
            {
                _tiles[i].OnUpdate();
                TileOnUpdateAction?.Invoke(_tiles[i]);
            }
        }

        /// <summary>
        /// Checks for a tile under specific world coordinates and returns <see cref="Tile"/> if it exists or <code>null</code> if it doesn't exist at this coordinates
        /// </summary>
        /// <param name="x">Coordinate along X axis to check <see cref="Tile"/></param>
        /// <param name="y">Coordinate along Y axis to check <see cref="Tile"/></param>
        /// <returns></returns>
        public Tile CheckTile(int x, int y)
        {
            int tileX = x / TileWidth;
            int tileY = y / TileHeight;

            foreach (var tile in _tiles)
            {
                if (tile.X == tileX && tile.Y == tileY)
                    return tile;
                else continue;
            }
            return null;
        }

        /// <summary>
        /// Adds specific <see cref="Tile"/> at specified location in tileset
        /// </summary>
        /// <param name="tile">Tile to add</param>
        /// <param name="x">Coordinate along X axis (all tiles have coordinates like 1,1; 1,2; 3,10 etc.)</param>
        /// <param name="y">Coordinate along Y axis (all tiles have coordinates like 1,1; 1,2; 3,10 etc.)</param>
        public void AddTile(Tile tile, int x, int y)
        {
            try
            {
                tile.TilesetX = x;
                tile.TilesetY = y;
                _tiles.Add(tile);
            }
            catch (Exception ex)
            {
                Debugging.Log(LogEntryType.Warning, "Unable to add tile " + tile.TileId + " @" + x + "," + y);
                Debugging.LogException(LogEntryType.Warning, ex);
            }
        }
    }

    /// <summary>
    /// Represents <see cref="Tile"/> OnUpdate behaviour
    /// </summary>
    /// <param name="updatingTile"></param>
    public delegate void TileOnUpdateAction(Tile updatingTile);
}
