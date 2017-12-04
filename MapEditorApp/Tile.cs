using System.Drawing;

namespace MapEditorApp
{
    public class Tile
    {
        public Image image = null;
        public bool isFilled = false;
        public Rectangle tileRect;

        public Tile(Image TileImage, bool IsTileFilled, bool IsTileSelected, Rectangle TileBounds)
        {
            image = TileImage;
            isFilled = IsTileFilled;
            tileRect = TileBounds;
        }
    }
}
