using System;
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
        private bool areaSelected;

        private SizeF grid = new SizeF(16, 16);
        private float margin = 1;

        private PointF mousePos;
        private PointF startPos;
        private RectangleF selectedArea;

        private Bitmap mainBit;
        private Bitmap previewBit;
        public Image image;
        #endregion

        #region Functions
        public ImageSelection()
        {
            InitializeComponent();
            SwitchToGrid();
            areaSelected = false;
            panel2.Controls.Add(pictureBoxImage);

            //Make picturesize workingspace size on maximize
        }

        //Used by UploadBox on closing to bring ImageSelection to front and draw selected file
        public void OnUploadBoxClose(Image GivenImage)
        {
            image = GivenImage;
            mainBit = new Bitmap(image);
            previewBit = new Bitmap(pictureBoxPreview.Width, pictureBoxPreview.Height);
            BringToFront();

            panel2.AutoScroll = true;
            pictureBoxImage.SizeMode = PictureBoxSizeMode.AutoSize;

            SetUpDownBox(numericUpDown_Left, 0, image.Width -1, numericUpDown_Left.Value);
            SetUpDownBox(numericUpDown_Top, 0, image.Height -1, numericUpDown_Top.Value);
            SetUpDownBox(numericUpDown_Right, 1, image.Width, numericUpDown_Right.Value);
            SetUpDownBox(numericUpDown_Bottom, 1, image.Height, numericUpDown_Bottom.Value);

            Draw();
        }

        private Graphics SetGraphics(Bitmap bitmap)
        {
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            return graphics;
        }

        //
        private void SetUpDownBox(NumericUpDown UpDownBox, decimal Minimum, decimal Maximum, decimal value)
        {
            UpDownBox.Minimum = Minimum;
            UpDownBox.Maximum = Maximum;
            UpDownBox.Value = (value < Minimum) ? Minimum : ((value > Maximum ? Maximum : value));
            UpDownBox.Tag = value;
        }

        //
        private void ChangeValue(NumericUpDown Box, NumericUpDown Box2, bool Corner)
        {
            if (Box.Value == Box2.Value)
                Box.Value = (Corner == false) ? Box.Value + 1 : Box.Value - 1;

            if (Corner == false)
                Box2.Minimum = Box.Value + 1;
            else
                Box2.Maximum = Box.Value - 1;
        }

        //Draw Grid/Custom Selection to PictureBoxImage. Takes an EventArgs parameter
        private void Draw()
        {
            if (image == null) { return; }

            Graphics g = SetGraphics(mainBit);
            Graphics gP = SetGraphics(previewBit);
            g.Clear(Color.White);
            g.DrawImage(image, 0, 0);


            Pen highlighter = new Pen(Brushes.Red);
            Pen gridPen = new Pen(Brushes.Black);


            if (usingGrid == true)
            {
                for (float x = 0; x < image.Width; x += (grid.Width + margin))
                {
                    for (float y = 0; y < image.Height; y += (grid.Height + margin))
                    {
                        g.DrawRectangle(gridPen, x, y, grid.Width, grid.Height);

                        RectangleF area = new RectangleF(new PointF(x, y), grid);
                        if (area.Contains(mousePos) == true)
                            selectedArea = area;
                    }
                }
            }
            else
            {
                PointF location = new PointF(Math.Min(mousePos.X, startPos.X), Math.Min(mousePos.Y, startPos.Y));
                PointF extents = new PointF(Math.Max(mousePos.X, startPos.X), Math.Max(mousePos.Y, startPos.Y));

                extents = new PointF(extents.X - location.X, extents.Y - location.Y);

                selectedArea.Location = location;
                selectedArea.Width = (extents.X < image.Width - 2) ? extents.X : image.Width;
                selectedArea.Height = (extents.Y < image.Height - 2) ? extents.Y : image.Height;
            }


            g.DrawRectangle(highlighter, selectedArea.X, selectedArea.Y, selectedArea.Width, selectedArea.Height);
            gP.Clear(Color.White);
            if (usingGrid == true || areaSelected == true)
                gP.DrawImage(image, new RectangleF(new PointF(0, 0), previewBit.Size), selectedArea, GraphicsUnit.Pixel);

            g.Dispose();
            gP.Dispose();

            pictureBoxImage.Image = mainBit;
            pictureBoxPreview.Image = previewBit;
        }

        //Change variables to set up Grid Mode
        private void SwitchToGrid()
        {
            buttonCustom.BackColor = SystemColors.ControlLightLight;
            buttonGrid.BackColor = SystemColors.ActiveBorder;
            panelGridOptions.Visible = true;
            panelCustomOptions.Visible = false;
            selectedArea = new RectangleF(new PointF(0, 0), grid);

            usingGrid = true;
        }

        //Change variables to set up Custom Selection Mode
        private void SwitchToCustom()
        {
            buttonGrid.BackColor = SystemColors.ControlLightLight;
            buttonCustom.BackColor = SystemColors.ActiveBorder;
            panelGridOptions.Visible = false;
            panelCustomOptions.Visible = true;

            usingGrid = false;
        }
        #endregion


        #region Actions & Behaviours
        //Open the UploadBox to select an image
        private void ButtonNewImage_Click(object sender, EventArgs e)
        {
            if (usingGrid == false)
                ButtonGrid_Click(sender, e);

            uploadBox = new UploadBox
            {
                Owner = this
            };
            uploadBox.Show();
        }

        //
        private void PictureBoxImage_Click(object sender, EventArgs e)
        {
            if (usingGrid == false || e.GetType() != typeof(MouseEventArgs)) { return; }

            mousePos = (e as MouseEventArgs).Location;
            Draw();
        }

        //
        private void NumericUpDownWidth_ValueChanged(object sender, EventArgs e)
        {
            grid.Width = (float)numericUpDownWidth.Value;
            Draw();
        }

        //
        private void NumericUpDownHeight_ValueChanged(object sender, EventArgs e)
        {
            grid.Height = (float)numericUpDownHeight.Value;
            Draw();
        }

        //
        private void NumericUpDownMargin_ValueChanged(object sender, EventArgs e)
        {
            margin = (float)numericUpDownMargin.Value;
            Draw();
        }

        //
        private void ButtonGrid_Click(object sender, EventArgs e)
        {
            SwitchToGrid();
            Draw();
        }

        //
        private void ButtonCustom_Click(object sender, EventArgs e)
        {
            SwitchToCustom();
            Draw();
        }

        //
        private void PictureBoxImage_MouseDown(object sender, MouseEventArgs e)
        {
            if (usingGrid == true) { return; }

            startPos = (e as MouseEventArgs).Location;
            pictureBoxImage.Invalidate();
            areaSelected = false;
            Draw();
        }

        //
        private void PictureBoxImage_MouseUp(object sender, MouseEventArgs e)
        {
            if (usingGrid == true) { return; }

            mousePos = (e as MouseEventArgs).Location;
            pictureBoxImage.Invalidate();

            //Set NumericUpDown Min/Max to image size to avoid issues with setting the value and set the Value to the correct float.
            SetUpDownBox(numericUpDown_Left, 0, image.Width, (decimal)Math.Min(mousePos.X, startPos.X));
            SetUpDownBox(numericUpDown_Top, 0, image.Height, (decimal)Math.Min(mousePos.Y, startPos.Y));
            SetUpDownBox(numericUpDown_Right, 0, image.Width, (decimal)Math.Max(mousePos.X, startPos.X));
            SetUpDownBox(numericUpDown_Bottom, 0, image.Height, (decimal)Math.Max(mousePos.Y, startPos.Y));

            //Reset Min/Max to the proper values.
            SetUpDownBox(numericUpDown_Left, 0, numericUpDown_Right.Value - 1, numericUpDown_Left.Value);
            SetUpDownBox(numericUpDown_Top, 0, numericUpDown_Bottom.Value - 1, numericUpDown_Top.Value);
            SetUpDownBox(numericUpDown_Right, numericUpDown_Left.Value + 1, image.Width, numericUpDown_Right.Value);
            SetUpDownBox(numericUpDown_Bottom, numericUpDown_Top.Value + 1, image.Height, numericUpDown_Bottom.Value);

            areaSelected = true;
            Draw();
        }

        //
        private void PictureBoxImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (usingGrid == true || e.Button != MouseButtons.Left) { return; }

            mousePos = (e as MouseEventArgs).Location;
            pictureBoxImage.Invalidate();
            Draw();
        }

        private void ButtonAddItem_Click(object sender, EventArgs e)
        {
            if (image == null) { return; }

            RectangleF dest = new RectangleF(0, 0, selectedArea.Width, selectedArea.Height);
            Bitmap bitmap = new Bitmap((int)dest.Width, (int)dest.Height);
            Graphics g = Graphics.FromImage(bitmap);
            g.DrawImage(image, dest, selectedArea, GraphicsUnit.Pixel);
            g.Dispose();

            (Owner as MapTools).AddItem(bitmap);
        }

        private void NumericUpDown_Left_ValueChanged(object sender, EventArgs e)
        {
            if (areaSelected == false) { return; }

            ChangeValue(numericUpDown_Left, numericUpDown_Right, false);

            if (startPos.X < mousePos.X)
                startPos.X = (float)numericUpDown_Left.Value;
            else
                mousePos.X = (float)numericUpDown_Left.Value;

            numericUpDown_Left.Tag = numericUpDown_Left.Value;

            Draw();
        }

        private void NumericUpDown_Top_ValueChanged(object sender, EventArgs e)
        {
            if (areaSelected == false) { return; }

            ChangeValue(numericUpDown_Top, numericUpDown_Bottom, false);

            if (startPos.Y < mousePos.Y)
                startPos.Y = (float)numericUpDown_Top.Value;
            else
                mousePos.Y = (float)numericUpDown_Top.Value;

            numericUpDown_Top.Tag = numericUpDown_Top.Value;

            Draw();
        }

        private void NumericUpDown_Right_ValueChanged(object sender, EventArgs e)
        {
            if (areaSelected == false) { return; }

            ChangeValue(numericUpDown_Right, numericUpDown_Left, true);

            if (mousePos.X > startPos.X)
                mousePos.X = (float)numericUpDown_Right.Value;
            else
                startPos.X = (float)numericUpDown_Right.Value;

            numericUpDown_Right.Tag = numericUpDown_Right.Value;

            Draw();
        }

        private void NumericUpDown_Bottom_ValueChanged(object sender, EventArgs e)
        {
            if (areaSelected == false) { return; }

            ChangeValue(numericUpDown_Bottom, numericUpDown_Top, true);

            if (mousePos.Y > startPos.Y)
                mousePos.Y = (float)numericUpDown_Bottom.Value;
            else
                startPos.Y = (float)numericUpDown_Bottom.Value;

            numericUpDown_Bottom.Tag = numericUpDown_Bottom.Value;

            Draw();
        }
        #endregion
    }
}