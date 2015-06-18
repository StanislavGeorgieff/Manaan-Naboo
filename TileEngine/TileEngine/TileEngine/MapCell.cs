// This is used to choose a part from a tilesheet with a single integer number.

using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TileEngine
{
    public class MapCell
    {
        public MapCell(int tileId)
        {
            this.BaseTiles = new List<int>();
            this.TileId = tileId;

        }

        public List<int> BaseTiles { get; set; }

        public int TileId 
        {
            get
            {
                return this.BaseTiles.Count < 0 ? this.BaseTiles[0] : 0;
            }
            set
            {
                if (this.BaseTiles.Count > 0)
                {
                    this.BaseTiles[0] = value;
                }
                else
                {
                    AddBaseTile(value);
                }
            } 
        }

        public void AddBaseTile(int tileId)
        {
            this.BaseTiles.Add(tileId);
        }
    }
}
