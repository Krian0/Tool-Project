using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MapEditorApp
{
    public partial class ImageSelection : Form
    {

        #region Variables
        private MapTools t = null;
        private UploadBox u = null;

        private bool usingGrid;
        private bool areaSelected;

        private Size grid = new Size(16, 16);
        private int margin = 1;

        private Point mousePos;
        private Point startPos;
        private Rectangle selectedArea;

        private Bitmap mainBit;
        private Bitmap previewBit;
        private Image image;
        #endregion

        #region Functions
        public ImageSelection(MapTools tools)
        {
            InitializeComponent();
            t = tools;
            SwitchToGrid();
            areaSelected = false;

            pictureBoxImage.Dock = DockStyle.Fill;
            panel2.AutoScroll = true;
            panel2.Controls.Add(pictureBoxImage);
        }

        //Used by UploadBox on closing to bring ImageSelection to front and draw selected file
        public void OnUploadBoxClose(Image GivenImage)
        {
            image = GivenImage;
            mainBit = new Bitmap(image);
            previewBit = new Bitmap(pictureBoxPreview.Width, pictureBoxPreview.Height);

            panel2.Size = mainBit.Size;

            SetUpDownBox(numericUpDown_Left, 0, image.Width -1, numericUpDown_Left.Value);
            SetUpDownBox(numericUpDown_Top, 0, image.Height -1, numericUpDown_Top.Value);
            SetUpDownBox(numericUpDown_Right, 1, image.Width, numericUpDown_Right.Value);
            SetUpDownBox(numericUpDown_Bottom, 1, image.Height, numericUpDown_Bottom.Value);

            u = null;
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


            if (usingGrid == true)
            {
                for (int x = 0; x < image.Width; x += (grid.Width + margin))
                {
                    for (int y = 0; y < image.Height; y += (grid.Height + margin))
                    {
                        Rectangle area = new Rectangle(x, y, grid.Width, grid.Height);
                        g.DrawRectangle(new Pen(Brushes.Black), area);

                        if (area.Contains(mousePos) == true)
                            selectedArea = area;
                    }
                }
            }
            else
            {
                Point location = new Point(Math.Min(mousePos.X, startPos.X), Math.Min(mousePos.Y, startPos.Y));
                Point extents = new Point(Math.Max(mousePos.X, startPos.X), Math.Max(mousePos.Y, startPos.Y));

                //Clamp to image dimension
                location.X = (location.X < 0 && areaSelected == true) ? 0 : location.X;
                location.Y = (location.Y < 0 && areaSelected == true) ? 0 : location.Y;
                extents.X = (extents.X > image.Width && areaSelected == true) ? image.Width : extents.X;
                extents.Y = (extents.Y > image.Height && areaSelected == true) ? image.Height : extents.Y;

                extents = new Point(extents.X - location.X, extents.Y - location.Y);

                selectedArea.Location = location;
                selectedArea.Width = extents.X;
                selectedArea.Height = extents.Y;
            }


            g.DrawRectangle(new Pen(Brushes.Red), selectedArea);
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
            selectedArea = new Rectangle(0, 0, grid.Width, grid.Height);

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
            if (u != null) { return; }
            if (usingGrid == false)
                ButtonGrid_Click(sender, e);

            //u = new UploadBox(this);
            //u.ShowDialog();
        }

        //
        private void PictureBoxImage_Click(object sender, EventArgs e)
        {
            if (usingGrid == false || e.GetType() != typeof(MouseEventArgs)) { return; }

            mousePos = (e as MouseEventArgs).Location;
            Draw();
        }

        private void NumericUpDownWidth_ValueChanged(object sender, EventArgs e)
        {
            grid.Width = (int)numericUpDownWidth.Value;
            Draw();
        }

        private void NumericUpDownHeight_ValueChanged(object sender, EventArgs e)
        {
            grid.Height = (int)numericUpDownHeight.Value;
            Draw();
        }

        private void NumericUpDownMargin_ValueChanged(object sender, EventArgs e)
        {
            margin = (int)numericUpDownMargin.Value;
            Draw();
        }

        private void ButtonGrid_Click(object sender, EventArgs e)
        {
            SwitchToGrid();
            Draw();
        }

        private void ButtonCustom_Click(object sender, EventArgs e)
        {
            SwitchToCustom();
            Draw();
        }

        private void PictureBoxImage_MouseDown(object sender, MouseEventArgs e)
        {
            if (usingGrid == true) { return; }

            startPos = (e as MouseEventArgs).Location;
            areaSelected = false;
            Draw();
        }

        //
        private void PictureBoxImage_MouseUp(object sender, MouseEventArgs e)
        {
            if (usingGrid == true) { areaSelected = true; return; }

            mousePos = (e as MouseEventArgs).Location;
            pictureBoxImage.Update();

            //Set NumericUpDown Min/Max to image size to avoid issues with setting the value and set the Value to the correct float.
            SetUpDownBox(numericUpDown_Left, 0, image.Width, Math.Min(mousePos.X, startPos.X));
            SetUpDownBox(numericUpDown_Top, 0, image.Height, Math.Min(mousePos.Y, startPos.Y));
            SetUpDownBox(numericUpDown_Right, 0, image.Width, Math.Max(mousePos.X, startPos.X));
            SetUpDownBox(numericUpDown_Bottom, 0, image.Height, Math.Max(mousePos.Y, startPos.Y));

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
            pictureBoxImage.Update();
            Draw();
        }

        private void ButtonAddItem_Click(object sender, EventArgs e)
        {
            if (image == null) { return; }

            RectangleF dest = new RectangleF(0, 0, selectedArea.Width, selectedArea.Height);
            Bitmap bitmap = new Bitmap((int)dest.Width, (int)dest.Height);
            Graphics g = Graphics.FromImage(bitmap);
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.DrawImage(image, dest, selectedArea, GraphicsUnit.Pixel);
            g.Dispose();

            //t.AddItem(bitmap);
        }

        private void NumericUpDown_Left_ValueChanged(object sender, EventArgs e)
        {
            if (areaSelected == false) { return; }

            ChangeValue(numericUpDown_Left, numericUpDown_Right, false);

            if (startPos.X < mousePos.X)
                startPos.X = (int)numericUpDown_Left.Value;
            else
                mousePos.X = (int)numericUpDown_Left.Value;

            Draw();
        }

        private void NumericUpDown_Top_ValueChanged(object sender, EventArgs e)
        {
            if (areaSelected == false) { return; }

            ChangeValue(numericUpDown_Top, numericUpDown_Bottom, false);

            if (startPos.Y < mousePos.Y)
                startPos.Y = (int)numericUpDown_Top.Value;
            else
                mousePos.Y = (int)numericUpDown_Top.Value;

            Draw();
        }

        private void NumericUpDown_Right_ValueChanged(object sender, EventArgs e)
        {
            if (areaSelected == false) { return; }

            ChangeValue(numericUpDown_Right, numericUpDown_Left, true);

            if (mousePos.X > startPos.X)
                mousePos.X = (int)numericUpDown_Right.Value;
            else
                startPos.X = (int)numericUpDown_Right.Value;

            Draw();
        }

        private void NumericUpDown_Bottom_ValueChanged(object sender, EventArgs e)
        {
            if (areaSelected == false) { return; }

            ChangeValue(numericUpDown_Bottom, numericUpDown_Top, true);

            if (mousePos.Y > startPos.Y)
                mousePos.Y = (int)numericUpDown_Bottom.Value;
            else
                startPos.Y = (int)numericUpDown_Bottom.Value;

            Draw();
        }
        #endregion
    }
}