using System.Collections.Generic;
using System.Drawing;

namespace MapEditorApp
{
    public class Layer
    {
        public List<Tile> tiles = new List<Tile>();

        public Layer(Size Grid, Size Map)
        {
            SetTiles(Grid, Map);
        }

        public void SetTiles(Size Grid, Size Map)
        {
            if (tiles.Count > 0)
                tiles.Clear();

            for (int x = 0; x < Map.Width; x += Grid.Width)
                for (int y = 0; y < Map.Height; y += Grid.Height)
                    tiles.Add(new Tile(new Bitmap(Grid.Width, Grid.Height), false, new Rectangle(x, y, Grid.Width, Grid.Height)));
        }

        public void ClearAllTiles()
        {
            Image ClearedImage = new Bitmap(tiles[0].image.Size.Width, tiles[0].image.Size.Height);
            Graphics g = Graphics.FromImage(ClearedImage);
            g.Clear(Color.Transparent);
            g.Dispose();

            for (int i = 0; i < tiles.Count; i++)
            {
                if (tiles[i].isFilled)
                {
                    tiles[i].image = ClearedImage;
                    tiles[i].isFilled = false;
                }
            }
        }

        public void FillAllTiles(Image ImageToPaint)
        {
            Image FillImage = new Bitmap(tiles[0].image.Size.Width, tiles[0].image.Size.Height);

            Graphics g = Graphics.FromImage(FillImage);
            g.Clear(Color.Transparent);
            g.DrawImage(ImageToPaint, 0, 0);
            g.Dispose();

            for (int i = 0; i < tiles.Count; i++)
            {
                tiles[i].image = FillImage;
                tiles[i].isFilled = true;
            }
        }
    }
}
