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
        public static Texture2D TileSetTexture { set; get; }

        public static Rectangle GetSourceRectangle(int tileIndex)
        {
            return new Rectangle(tileIndex * 32, 0, 32, 32);
        }
    }
}
