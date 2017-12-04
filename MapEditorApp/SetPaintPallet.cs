using System;
using System.Drawing;
using System.Windows.Forms;

namespace MapEditorApp
{
    public partial class SetPaintPallet : Form
    {
        MapTools t;
        private const int CP_NOCLOSE_BUTTON = 0x200;

        public SetPaintPallet(MapTools tools)
        {
            InitializeComponent();
            t = tools;
        }

        private void ButtonConfirm_Click(object sender, EventArgs e)
        {
            int Width = (int)numericWidth.Value;
            int Height = (int)numericHeight.Value;
            int Margin = (int)numericMargin.Value;

            t.paintPalletGrid = new Size(Width, Height);
            t.paintPalletMargin = Margin;

            Bitmap TileImage = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(TileImage);

            t.paintTiles.Clear();

            for (int x = 0; x < t.displayImage.Width; x += (Width + Margin))
            {
                for (int y = 0; y < t.displayImage.Height; y += (Height + Margin))
                {
                    g.Clear(Color.Transparent);
                    g.DrawImage(t.displayImage, 0, 0, new Rectangle(x, y, Width, Height), GraphicsUnit.Pixel);
                    t.AddTile(TileImage, new Point(x, y));
                }
            }

            g.Dispose();
            t.Draw();
            Close();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }
    }
}
