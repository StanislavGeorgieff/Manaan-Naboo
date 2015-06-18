using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// This simply creates a Tile Rectangle, from a texture. We can choose which part of the tilesheet to be returned.

namespace TileEngine
{
    public static class Tile
    {
        public static int TileWidth = 64;
        public static int TileHeight = 64;

        public static int TileStepX = 64;
        public static int TileStepY = 64 / 4;

        public static int OddRowXOffset = 64 / 2;
        public static int HeightTileOffset = 64 / 2;
        

        public static Texture2D TileSetTexture { set; get; }

        public static Rectangle GetSourceRectangle(int tileIndex)
        {
            int tileY = tileIndex / (TileSetTexture.Width / TileWidth);
            int tileX = tileIndex % (TileSetTexture.Width / TileWidth);

            return new Rectangle(tileX * TileWidth, tileY * TileHeight, TileWidth, TileHeight);
        }
    }
}
