using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace MapEditorApp
{
    public partial class MapEditor : Form
    {
        private MapTools t;
        private Bitmap display;
        private Bitmap gridDisplay;
        private Rectangle position;

        private int invalidatedTileIndex;

        public bool drawGrid = false;
        public bool eraseTiles = false;
        public bool copyTiles = false;
        public bool fillTiles = false;
        public bool redrawAllTiles = false;

        Tile copiedTile = null;

        public MapEditor(MapTools Tools)
        {
            InitializeComponent();
            t = Tools;
            display = new Bitmap(pictureBox.Width, pictureBox.Height);
        }

#region MapEditor Functions
        public void Draw()
        {
            if (t.MapIndex == -1) { pictureBox.Image = null; return; }

            Graphics g = SetGraphics(display);

            if (fillTiles || redrawAllTiles)
                g.Clear(Color.Transparent);

            if (t.LayerIndex != -1)
            {
                if (!fillTiles && t.MapList[t.MapIndex].layers[t.LayerIndex].tiles.Count > invalidatedTileIndex)
                {
                    GraphicsPath path = new GraphicsPath();
                    path.AddRectangle(t.MapList[t.MapIndex].layers[t.LayerIndex].tiles[invalidatedTileIndex].tileRect);
                    g.SetClip(path);
                    g.Clear(Color.Transparent);
                    g.ResetClip();
                }


                for (int layerIndex = 0; layerIndex < t.MapList[t.MapIndex].layers.Count; layerIndex++)
                {
                    Layer CurrentLayer = t.MapList[t.MapIndex].layers[layerIndex];

                    if (fillTiles || redrawAllTiles)
                        for (int tileIndex = 0; tileIndex < CurrentLayer.tiles.Count; tileIndex++)
                            g.DrawImage(CurrentLayer.tiles[tileIndex].image, CurrentLayer.tiles[tileIndex].tileRect.Location);

                    else if (t.MapList[t.MapIndex].layers[t.LayerIndex].tiles.Count > invalidatedTileIndex)
                        g.DrawImage(CurrentLayer.tiles[invalidatedTileIndex].image, CurrentLayer.tiles[invalidatedTileIndex].tileRect.Location);
                }
            }

            if (drawGrid == true)
                g.DrawImage(gridDisplay, 0, 0);
            if (redrawAllTiles)
                redrawAllTiles = false;

            g.Dispose();
            pictureBox.Image = display;
        }

        private Graphics SetGraphics(Bitmap bitmap)
        {
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            return graphics;
        }

        public void SetPictureBox(Size MapSize, Size GridSize)
        {
            position.Size = GridSize;
            pictureBox.Size = new Size(MapSize.Width, MapSize.Height);
            display = new Bitmap(MapSize.Width, MapSize.Height);

            if (t.MapIndex == -1) { return; }

            Size Grid = t.MapList[t.MapIndex].gridSize;

            gridDisplay = new Bitmap(MapSize.Width, MapSize.Height);
            Graphics g = SetGraphics(gridDisplay);
            g.Clear(Color.Transparent);

            for (int x = 0; x < MapSize.Width; x += Grid.Width)
                for (int y = 0; y < MapSize.Height; y += Grid.Height)
                    g.DrawRectangle(new Pen(Brushes.Black), x, y, Grid.Width, Grid.Height);

            g.Dispose();

            Draw();
        }

        private void PaintTile(Point MousePos, Tile ClickedTile, int ClickedTileIndex)
        {
            if (t.selectedTiles.Count == 0 || t.PaintIndex == -1) { return; }
       

            if (eraseTiles)
            {
                if (fillTiles)
                {
                    t.MapList[t.MapIndex].layers[t.LayerIndex].ClearAllTiles();
                }

                else
                {
                    if (ClickedTile.isFilled)
                    {
                        Graphics g = Graphics.FromImage(ClickedTile.image);
                        g.Clear(Color.Transparent);
                        g.Dispose();

                        ClickedTile.isFilled = false;

                        invalidatedTileIndex = ClickedTileIndex;
                    }
                }
            }

            else if (copyTiles)
            {
                copiedTile = ClickedTile;
            }

            else
            {
                if (fillTiles)
                {
                    t.MapList[t.MapIndex].layers[t.LayerIndex].FillAllTiles(t.selectedTiles[0].image);
                }

                else
                {
                    if (!ClickedTile.isFilled)
                    {
                        Graphics g = Graphics.FromImage(ClickedTile.image);
                        g.DrawImage(t.selectedTiles[0].image, 0, 0);
                        g.Dispose();

                       ClickedTile.isFilled = true;

                       invalidatedTileIndex = ClickedTileIndex;
                    }
                }
            }
        }

        public Tile GetClickedTile(Point MouseLocation, ref int TileIndex)
        {
            for (int i = 0; i < t.MapList[t.MapIndex].layers[t.LayerIndex].tiles.Count; i++)
            {
                if (t.MapList[t.MapIndex].layers[t.LayerIndex].tiles[i].tileRect.Contains(MouseLocation))
                {
                    TileIndex = i;
                    return t.MapList[t.MapIndex].layers[t.LayerIndex].tiles[i];
                }
            }

            return null;
        }

        //public void ResizeAndSetImage(Image TileImage, Size MapSize)
        //{
        //    var destRect = new Rectangle(0, 0, MapSize.Width, MapSize.Height);
        //    var destImage = new Bitmap(MapSize.Width, MapSize.Height);

        //    destImage.SetResolution(TileImage.HorizontalResolution, TileImage.VerticalResolution);

        //    using (var graphics = Graphics.FromImage(destImage))
        //    {
        //        graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
        //        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

        //        using (var wrapMode = new ImageAttributes())
        //        {
        //            wrapMode.SetWrapMode(WrapMode.TileFlipXY);
        //            graphics.DrawImage(TileImage, destRect, 0, 0, TileImage.Width, TileImage.Height, GraphicsUnit.Pixel, wrapMode);
        //        }
        //    }

        //    currentTileImage = destImage;
        //}
#endregion


        #region MapEditor Actions
        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (t.MapIndex == -1 || t.LayerIndex == -1 || t.PaintIndex == -1 || e.Button != MouseButtons.Left) { return; }

            int TileIndex = 0;

            Tile ClickedTile = GetClickedTile((e as MouseEventArgs).Location, ref TileIndex);
            if (ClickedTile != null)
                PaintTile(ClickedTile.tileRect.Location, ClickedTile, TileIndex);

            Draw();
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (t.MapIndex == -1 || t.LayerIndex == -1 || t.PaintIndex == -1 || e.Button != MouseButtons.Left) { return; }

            int TileIndex = 0;

            Tile ClickedTile = GetClickedTile((e as MouseEventArgs).Location, ref TileIndex);
            if (ClickedTile != null)
                PaintTile((e as MouseEventArgs).Location, ClickedTile, TileIndex);
            Draw();
        }
        #endregion
    }
}