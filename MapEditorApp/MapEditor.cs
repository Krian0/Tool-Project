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
        private PointF midPoint;
        private int lastCount;
        private bool updatePictureBox;

        public MapEditor(MapTools Tools)
        {
            InitializeComponent();
            t = Tools;
            bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            midPoint = new PointF(pictureBox.Width / 2, pictureBox.Height / 2);
        }

        public void ListsChanged()
        {
            updatePictureBox = false;

            if (t.MapIndex == null || t.MapIndex.Count == 0 || t.ItemIndex == null || t.ItemIndex.Count == 0) { return; }

            if (t.MapList[t.ItemIndex[0]].ItemList.Count == lastCount) { return; }

            lastCount = t.MapList[t.ItemIndex[0]].ItemList.Count;
            updatePictureBox = true;
        }

        private Graphics SetGraphics(Bitmap bitmap)
        {
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            return graphics;
        }


        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.GetType() != typeof(MouseEventArgs) || e.Button != MouseButtons.Left || t.ItemIndex.Count == 0) { return; }

            t.MapList[t.MapIndex[0]].ItemList[t.ItemIndex[0]].ChangePos((e as MouseEventArgs).Location);
            pictureBox.Invalidate();
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (t.MapIndex == null || t.MapIndex.Count == 0) { return; }

            Graphics g = SetGraphics(bitmap);
            g.Clear(Color.White);
            foreach (Item item in t.MapList[t.MapIndex[0]].ItemList)
                g.DrawImage(item.Image, item.Pos);

            pictureBox.Image = bitmap;
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (updatePictureBox == false) { return; }

            pictureBox.Invalidate();
        }
    }
}
