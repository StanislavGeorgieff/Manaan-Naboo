//A tilemap is nothing more than a collection of map cells.

using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TileEngine
{
    public class TileMap
    {
        private const int MapWidthInCells = 50;
        private const int MapHeightInCells = 50;

        private Texture2D mouseMap;

        public List<MapRow> Rows { get; set; }

        public int MapWidth { get; set; }

        public int MapHeight { get; set; }

        public TileMap(Texture2D mouseMap)
        {
            this.mouseMap = mouseMap;
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

            //Adding some Height Tiles

            Rows[16].Columns[4].AddHeightTile(54);

            Rows[17].Columns[4].AddHeightTile(54);

            Rows[15].Columns[3].AddHeightTile(54);
            Rows[16].Columns[3].AddHeightTile(53);


            Rows[15].Columns[4].AddHeightTile(54);
            //Rows[15].Columns[4].AddHeightTile(54);
            //Rows[15].Columns[4].AddHeightTile(54);
            Rows[15].Columns[4].AddHeightTile(54);
            Rows[15].Columns[4].AddHeightTile(51);

            Rows[18].Columns[3].AddHeightTile(51);
            Rows[19].Columns[3].AddHeightTile(50);
            Rows[18].Columns[4].AddHeightTile(55);

            Rows[14].Columns[4].AddHeightTile(54);

            Rows[14].Columns[5].AddHeightTile(62);
            Rows[14].Columns[5].AddHeightTile(61);
            Rows[14].Columns[5].AddHeightTile(63);


            // Adding some Topper Tiles.


            Rows[17].Columns[4].AddTopperTile(114);
            Rows[16].Columns[5].AddTopperTile(115);
            Rows[14].Columns[4].AddTopperTile(125);
            Rows[15].Columns[5].AddTopperTile(91);
            Rows[16].Columns[6].AddTopperTile(94);

        }

        // A method to convert a pixel-based location on the map into a map cell refernce.

        public Point WorldToMapCell(Point worldPoint, out Point localPoint)
        {
            Point mapCell = new Point(
                (int)(worldPoint.X / mouseMap.Width),
                ((int)(worldPoint.Y / mouseMap.Height)) * 2);

            int localPointX = worldPoint.X % mouseMap.Width;
            int localPointY = worldPoint.Y % mouseMap.Height;

            int dx = 0;
            int dy = 0;

            uint[] myUint = new uint[1];

            if (new Rectangle(0, 0, mouseMap.Width, mouseMap.Height).Contains(localPointX, localPointY))
            {
                mouseMap.GetData(0, new Rectangle(localPointX, localPointY, 1, 1), myUint, 0, 1);

                if (myUint[0] == 0xFF0000FF) // Red
                {
                    dx = -1;
                    dy = -1;
                    localPointX = localPointX + (mouseMap.Width / 2);
                    localPointY = localPointY + (mouseMap.Height / 2);
                }

                if (myUint[0] == 0xFF00FF00) // Green
                {
                    dx = -1;
                    localPointX = localPointX + (mouseMap.Width / 2);
                    dy = 1;
                    localPointY = localPointY - (mouseMap.Height / 2);
                }

                if (myUint[0] == 0xFF00FFFF) // Yellow
                {
                    dy = -1;
                    localPointX = localPointX - (mouseMap.Width / 2);
                    localPointY = localPointY + (mouseMap.Height / 2);
                }

                if (myUint[0] == 0xFFFF0000) // Blue
                {
                    dy = +1;
                    localPointX = localPointX - (mouseMap.Width / 2);
                    localPointY = localPointY - (mouseMap.Height / 2);
                }    
            }
            mapCell.X += dx;
            mapCell.Y += dy - 2;

            localPoint = new Point(localPointX, localPointY);

            return mapCell;
        }

        // An overload that simply returns the point
        public Point WorldToMapCell(Point worldPoint)
        {
            Point dummy;
            return WorldToMapCell(worldPoint, out dummy);
        }
    }
}
