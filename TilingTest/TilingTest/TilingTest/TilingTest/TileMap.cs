using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TilingTest
{
    class MapRow
    { 
        public List<MapCell> Columns = new List<MapCell>();
    }
    
    class TileMap
    {
        public List<MapRow> Rows = new List<MapRow>();
        public int MapWidth = 39;
        public int MapHeight = 39;

        public TileMap()
        {
            for (int y = 0; y < MapHeight; y++)
            {
                MapRow thisRow = new MapRow();
                for (int x = 0; x < MapWidth; x++)
                {
                    thisRow.Columns.Add(new MapCell(0));
                }
                Rows.Add(thisRow);
            }

        }
    }

    
}
