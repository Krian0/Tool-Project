using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapEditorApp
{
    public partial class MapEditor : Form
    {
        private MapTools t;
        private Bitmap bitmap;
        private RectangleF position;
        private GridObject Grid;
        public bool drawGrid;

        public MapEditor(MapTools Tools)
        {
            InitializeComponent();
            t = Tools;
            bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            drawGrid = false;
        }

        public void Draw()
        {
            if (t.MapIndex == -1) { pictureBox.Image = null; return; }

            Graphics g = SetGraphics(bitmap);
            g.Clear(Color.White);

            //Map map = t.CurrentMap();
            //for (int i = 0; i < map.GetItemCount(); i++)
            //    g.DrawImage(map.GetItemImage(i), map.GetItemPos(i));

            //if (t.CurrentMap().ItemIndex > -1)
            //    g.DrawRectangle(new Pen(Brushes.LightSeaGreen, 2), position);

            Size Grid = t.CurrentMap().gridSize;
            



            if (drawGrid == true)
            {
                for (int x = 0; x < pictureBox.Width; x += Grid.Width)
                    for (int y = 0; y < pictureBox.Height; y += Grid.Height)
                        g.DrawRectangle(new Pen(Brushes.Gray), x, y, Grid.Width, Grid.Height);
            }

            g.Dispose();
            pictureBox.Image = bitmap;
        }

        private Graphics SetGraphics(Bitmap bitmap)
        {
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            return graphics;
        }

        public void SetupMap(Size MapSize, Size GridSize)
        {
            pictureBox.Size = MapSize;
            Grid = new GridObject(GridSize, pictureBox.Size);
        }

        public Point GetClickedGrid()
        {
            Size Grid = t.CurrentMap().gridSize;

            int x = (int)Math.Floor(position.X / Grid.Width);
            int y = (int)Math.Floor(position.Y / Grid.Height);
            x *= Grid.Width;
            y *= Grid.Height;

            return new Point(x, y);
        }


        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (t.MapIndex == -1 || t.ItemIndex == -1) { return; }
            if (e.Button != MouseButtons.Left || position.Contains((e as MouseEventArgs).Location) == false) { return; }



            //for (int x = 0; x < pictureBox.Width; x += Grid.Width)
            //{
            //    for (int y = 0; y < pictureBox.Height; y += Grid.Height)
            //    {
            //        Rectangle R = new Rectangle(x, y, Grid.Width, Grid.Height);
            //        if (R.Contains((int)position.X, (int)position.Y) == true)
            //            ;
            //    }
            //}
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (t.MapIndex == -1 || t.ItemIndex == -1) { return; }

            position.X = (position.X < 0) ? 0 : position.X;
            position.Y = (position.Y < 0) ? 0 : position.Y;
            position.X = (position.Right > pictureBox.Width) ? pictureBox.Width - position.Width : position.X;
            position.Y = (position.Bottom > pictureBox.Height) ? pictureBox.Height - position.Height : position.Y;

            //t.CurrentMap().SetItemPos(position.Location);
            Draw();
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (t.MapIndex == -1 || t.ItemIndex == -1 || e.Button != MouseButtons.Left) { return; }

            position.Location = (e as MouseEventArgs).Location;

            //t.CurrentMap().SetItemPos(position.Location);
            Draw();
        }
    }
}
