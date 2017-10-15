using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapEditorApp
{
    public partial class ImageSelection : Form
    {
        Form uploadBox;

        float gridWidth = 30;
        float gridHeight = 30;
        float margin = 8;

        private PointF mousePos;
        private RectangleF selectedArea;

        public Bitmap bitmap;
        public Image image;
        public string path;

        public ImageSelection()
        {
            InitializeComponent();
            bitmap = new Bitmap(pictureBoxImage.Width, pictureBoxImage.Height);
        }

        private void buttonNewImage_Click(object sender, EventArgs e)
        {
            uploadBox = new UploadBox(this);
            uploadBox.Show();

            drawGrid();
        }

        private void drawGrid()
        {
            if (image == null)
                return;

            pictureBoxImage.DrawToBitmap(bitmap, pictureBoxImage.Bounds);

            Graphics graphics;
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
            graphics.DrawImage(image, 0, 0);

            Pen pen = new Pen(Brushes.Black);
            Pen highlight = new Pen(Brushes.Red);


            float height = pictureBoxImage.Height;
            float width = pictureBoxImage.Width;

            for (float x = 0; x < width; x += gridWidth)
            {
                for (float y = 0; y < height; y += gridHeight)
                {
                    graphics.DrawRectangle(pen, x, y, gridWidth, gridHeight);
                    graphics.DrawRectangle(pen, x + gridWidth, y + gridHeight, margin, margin);


                    if (mousePos.X > x && mousePos.X < (x + gridWidth) && mousePos.Y > y && mousePos.Y < (y + gridHeight))
                        selectedArea.Location = new PointF(x, y);

                    y += margin;
                }
                    x += margin;
            }


            graphics.DrawRectangle(highlight, selectedArea.X, selectedArea.Y, gridWidth, gridHeight);
            graphics.Dispose();

            pictureBoxImage.Image = bitmap;
        }

        private void ImageSelection_Enter(object sender, EventArgs e)
        {
            drawGrid();
        }

        private void ImageSelection_Shown(object sender, EventArgs e)
        {
            drawGrid();
        }

        private void pictureBoxImage_Click(object sender, EventArgs e)
        {
            if (pictureBoxImage == null)
                return;

            if (e.GetType() == typeof(MouseEventArgs))
            {
                mousePos = (e as MouseEventArgs).Location;
                drawGrid();
            }
        }

        private void numericUpDownWidth_ValueChanged(object sender, EventArgs e)
        {
            gridWidth = (float)numericUpDownWidth.Value;
            drawGrid();
        }

        private void numericUpDownHeight_ValueChanged(object sender, EventArgs e)
        {
            gridHeight = (float)numericUpDownHeight.Value;
            drawGrid();
        }

        private void numericUpDownMargin_ValueChanged(object sender, EventArgs e)
        {
            margin = (float)numericUpDownMargin.Value;
            drawGrid();
        }
    }
}
