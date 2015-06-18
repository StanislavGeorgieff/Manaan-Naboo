//A tilemap is nothing more than a collection of map cells.

using System.Collections.Generic;

namespace TileEngine
{
    public class TileMap
    {
        private const int MapWidthInCells = 50;
        private const int MapHeightInCells = 50;

        public List<MapRow> Rows { get; set; }

        public int MapWidth { get; set; }

        public int MapHeight { get; set; }

        public TileMap()
        {
            // The Constructor initialise a map by filling our map matrix with default values (in this case: index 0 in tilesheet.

            this.MapWidth = MapWidthInCells;
            this.MapHeight = MapHeightInCells;

            Rows = new List<MapRow>();

            for (int y = 0; y < MapHeight; y++)
            {
                MapRow thisRow = new MapRow();
                for (int x = 0; x < MapWidth; x++)
                {
                    thisRow.Columns.Add(new MapCell(0));
                }
                this.Rows.Add(thisRow);
            }

            // Create Sample Map Data
            Rows[0].Columns[3].TileId = 3;
            Rows[0].Columns[4].TileId = 3;
            Rows[0].Columns[5].TileId = 1;
            Rows[0].Columns[6].TileId = 1;
            Rows[0].Columns[7].TileId = 1;
                                    
            Rows[1].Columns[3].TileId = 3;
            Rows[1].Columns[4].TileId = 1;
            Rows[1].Columns[5].TileId = 1;
            Rows[1].Columns[6].TileId = 1;
            Rows[1].Columns[7].TileId = 1;
                                    
            Rows[2].Columns[2].TileId = 3;
            Rows[2].Columns[3].TileId = 1;
            Rows[2].Columns[4].TileId = 1;
            Rows[2].Columns[5].TileId = 1;
            Rows[2].Columns[6].TileId = 1;
            Rows[2].Columns[7].TileId = 1;
                                    
            Rows[3].Columns[2].TileId = 3;
            Rows[3].Columns[3].TileId = 1;
            Rows[3].Columns[4].TileId = 1;
            Rows[3].Columns[5].TileId = 2;
            Rows[3].Columns[6].TileId = 2;
            Rows[3].Columns[7].TileId = 2;
                                    
            Rows[4].Columns[2].TileId = 3;
            Rows[4].Columns[3].TileId = 1;
            Rows[4].Columns[4].TileId = 1;
            Rows[4].Columns[5].TileId = 2;
            Rows[4].Columns[6].TileId = 2;
            Rows[4].Columns[7].TileId = 2;
                                    
            Rows[5].Columns[2].TileId = 3;
            Rows[5].Columns[3].TileId = 1;
            Rows[5].Columns[4].TileId = 1;
            Rows[5].Columns[5].TileId = 2;
            Rows[5].Columns[6].TileId = 2;
            Rows[5].Columns[7].TileId = 2;





            //Rows[3].Columns[5].AddBaseTile(30);
            //Rows[4].Columns[5].AddBaseTile(27);
            //Rows[5].Columns[5].AddBaseTile(28);

            //Rows[3].Columns[6].AddBaseTile(25);
            //Rows[5].Columns[6].AddBaseTile(24);

            //Rows[3].Columns[7].AddBaseTile(31);
            //Rows[4].Columns[7].AddBaseTile(26);
            //Rows[5].Columns[7].AddBaseTile(29);

            //Rows[4].Columns[6].AddBaseTile(104);

        }
    }
}
