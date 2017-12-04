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

        public bool drawGrid = false;
        public bool eraseTiles = false;
        public bool copyTiles = false;
        public bool fillTiles = false;

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
            g.Clear(Color.Transparent);

            for (int i = 0; i < t.MapList[t.MapIndex].layers.Count; i++)
                g.DrawImage(t.MapList[t.MapIndex].layers[i], 0, 0);

            if (drawGrid == true)
                g.DrawImage(gridDisplay, 0, 0);

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

        private void PaintTile(Point MousePos)
        {
            if (t.selectedTiles.Count == 0 || t.PaintIndex == -1) { return; }

            //int x = MousePos.X / position.Size.Width;
            //int y = MousePos.Y / position.Size.Height;
            //position.Location = new Point(x * position.Size.Width, y * position.Size.Height);

            //if (position.X < 0) position.X = 0;
            //else if (position.Right > pictureBox.Width) position.X = pictureBox.Width - position.Width;
            //if (position.Y < 0) position.Y = 0;
            //else if (position.Bottom > pictureBox.Height) position.Y = pictureBox.Height - position.Height;

            //Graphics g = Graphics.FromImage(t.MapList[t.MapIndex].layers[t.LayerIndex]);
            //g.SetClip(position);
            //g.Clear(Color.Transparent);
            //g.ResetClip();

            for ()

            if (eraseTiles == false)
            {
                for (int row = 0; row < t.selectedGrid.X; row++)
                    for (int col = 0; col < t.selectedGrid.Y; col++)
                        ;


                //g.DrawImage(t.paintImage, position.Location);
            }

            //g.Dispose();
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

            PaintTile((e as MouseEventArgs).Location);
            Draw();
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (t.MapIndex == -1 || t.LayerIndex == -1 || t.PaintIndex == -1 || e.Button != MouseButtons.Left) { return; }

            PaintTile((e as MouseEventArgs).Location);
            Draw();
        }
        #endregion
    }
}