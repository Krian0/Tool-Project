using System.Collections.Generic;
using System.Drawing;

namespace MapEditorApp
{
    class GridObject
    {
        public Size size;
        public Dictionary<Point, GridTile> Tiles { get; private set; } = new Dictionary<Point, GridTile>();

        public GridObject(Size GridSize, Size PictureBoxSize)
        {
            size = GridSize;

            for (int x = 0; x < PictureBoxSize.Width; x += size.Width)
            {
                for (int y = 0; y < PictureBoxSize.Height; y += size.Height)
                {
                    Point Location = new Point(x, y);
                    Tiles.Add(Location, new GridTile(Location, size));
                }
            }
        }

        public void SetTileImage(Point TilePoint, Image TileImage)
        {
            Tiles.TryGetValue(TilePoint, out GridTile TileToSet);
            TileToSet.image = TileImage;
        }
    }
}
