﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MapEditorApp
{
    public partial class ImageSelection : Form
    {

        #region Variables
        private Form uploadBox;

        private bool usingGrid;

        private float gridWidth = 30;
        private float gridHeight = 30;
        private float margin = 8;

        private PointF mousePos;
        private PointF startPos;
        private RectangleF selectedArea;

        private Bitmap bitmap;
        public Image image;
        #endregion

        #region Functions
        public ImageSelection()
        {
            InitializeComponent();
            bitmap = new Bitmap(pictureBoxImage.Width, pictureBoxImage.Height);
            SwitchToGrid();
        }

        //Used by UploadBox on closing to bring ImageSelection to front and draw selected file
        public void OnUploadBoxClose()
        {
            BringToFront();
            Draw(null);
        }

        //Draw Grid/Custom Selection to PictureBoxImage. Takes an EventArgs parameter
        private void Draw(EventArgs e)
        {
            if (image == null)
                return;

            Graphics g;
            g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);
            g.DrawImage(image, 0, 0);
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            Pen highlighter = new Pen(Brushes.Red);
            Pen gridPen = new Pen(Brushes.Black);


            if (usingGrid == false && (e as MouseEventArgs).Button == MouseButtons.Left)
            {
                PointF location = new PointF(Math.Min(mousePos.X, startPos.X), Math.Min(mousePos.Y, startPos.Y));
                PointF extents = new PointF(Math.Max(mousePos.X, startPos.X), Math.Max(mousePos.Y, startPos.Y));

                extents = new PointF(extents.X - location.X, extents.Y - location.Y);

                selectedArea.Location = location;
                selectedArea.Width = (extents.X < pictureBoxImage.Width - 2) ? extents.X : pictureBoxImage.Width;
                selectedArea.Height = (extents.Y < pictureBoxImage.Height - 2) ? extents.Y : pictureBoxImage.Height;
            }
            else
            {
                for (float x = 0; x < pictureBoxImage.Width; x += (gridWidth + margin))
                {
                    for (float y = 0; y < pictureBoxImage.Height; y += (gridHeight + margin))
                    {
                        g.DrawRectangle(gridPen, x, y, gridWidth, gridHeight);
                        g.DrawRectangle(gridPen, x + gridWidth, y + gridHeight, margin, margin);

                        RectangleF area = new RectangleF(x, y, gridWidth, gridHeight);
                        if (area.Contains(mousePos) == true)
                            selectedArea = area;
                    }
                }
            }


            g.DrawRectangle(highlighter, selectedArea.X, selectedArea.Y, selectedArea.Width, selectedArea.Height);
            //

       //
       //Add preview to PictureBoxPreview

            pictureBoxImage.Image = bitmap;
        }

        //Change variables to set up Grid Mode
        private void SwitchToGrid()
        {
            buttonCustom.BackColor = SystemColors.ControlLightLight;
            buttonGrid.BackColor = SystemColors.ActiveBorder;
            panelGridOptions.Visible = true;
            selectedArea = new RectangleF(0, 0, gridWidth, gridHeight);

            usingGrid = true;
        }

        //Change variables to set up Custom Selection Mode
        private void SwitchToCustom()
        {
            buttonGrid.BackColor = SystemColors.ControlLightLight;
            buttonCustom.BackColor = SystemColors.ActiveBorder;
            panelGridOptions.Visible = false;

            usingGrid = false;
        }
        #endregion


        #region Actions & Behaviours
        //Open the UploadBox to select an image
        private void ButtonNewImage_Click(object sender, EventArgs e)
        {
            if (usingGrid == false)
                ButtonGrid_Click(sender, e);

            uploadBox = new UploadBox(this);
            uploadBox.Show();
        }

        //
        private void PictureBoxImage_Click(object sender, EventArgs e)
        {
            if (usingGrid == true && e.GetType() == typeof(MouseEventArgs))
            {
                mousePos = (e as MouseEventArgs).Location;
                Draw(e);
            }
        }

        //
        private void NumericUpDownWidth_ValueChanged(object sender, EventArgs e)
        {
            gridWidth = (float)numericUpDownWidth.Value;
            Draw(e);
        }

        //
        private void NumericUpDownHeight_ValueChanged(object sender, EventArgs e)
        {
            gridHeight = (float)numericUpDownHeight.Value;
            Draw(e);
        }

        //
        private void NumericUpDownMargin_ValueChanged(object sender, EventArgs e)
        {
            margin = (float)numericUpDownMargin.Value;
            Draw(e);
        }

        //
        private void ButtonGrid_Click(object sender, EventArgs e)
        {
            SwitchToGrid();
            Draw(e);
        }

        //
        private void ButtonCustom_Click(object sender, EventArgs e)
        {
            SwitchToCustom();
            Draw(e);
        }

        //
        private void PictureBoxImage_MouseDown(object sender, MouseEventArgs e)
        {
            if (usingGrid == false)
            {
                startPos = (e as MouseEventArgs).Location;
                pictureBoxImage.Invalidate();
                Draw(e);
            }
        }

        //
        private void PictureBoxImage_MouseUp(object sender, MouseEventArgs e)
        {
            if (usingGrid == false)
            {
                mousePos = (e as MouseEventArgs).Location;
                pictureBoxImage.Invalidate();
                Draw(e);
            }
        }

        //
        private void PictureBoxImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (usingGrid == false && e.Button == MouseButtons.Left)
            {
                mousePos = (e as MouseEventArgs).Location;
                pictureBoxImage.Invalidate();
                Draw(e);
            }
        }
        #endregion
    }
}