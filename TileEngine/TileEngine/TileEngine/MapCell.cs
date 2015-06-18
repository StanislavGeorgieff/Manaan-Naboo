// This is used to choose a part from a tilesheet with a single integer number.

namespace TileEngine
{
    public class MapCell
    {
        public int TileId { get; set; }

        public MapCell(int tileId)
        {
            this.TileId = tileId;
        }
    }
}
