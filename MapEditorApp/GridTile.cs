using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditorApp
{
    class GridTile
    {
        public Rectangle tile;
        public Image image;

        public GridTile(Point TilePosition, Size TileSize)
        {
            tile.Location = TilePosition;
            tile.Size = TileSize;
        }
    }
}
