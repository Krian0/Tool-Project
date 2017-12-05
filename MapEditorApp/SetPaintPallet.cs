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
            int GridWidth = (int)numericWidth.Value;
            int GridHeight = (int)numericHeight.Value;
            int GridMargin = (int)numericMargin.Value;

            t.paintPalletGrid = new Size(GridWidth, GridHeight);
            t.paintPalletMargin = GridMargin;


            t.paintTiles.Clear();

            for (int x = 0; x < t.displayImage.Width; x += (GridWidth + GridMargin))
            {
                for (int y = 0; y < t.displayImage.Height; y += (GridHeight + GridMargin))
                {
                    Bitmap TileImage = new Bitmap(GridWidth, GridHeight);

                    Graphics g = Graphics.FromImage(TileImage);
                    g.Clear(Color.Transparent);
                    g.DrawImage(t.displayImage, 0, 0, new Rectangle(x, y, GridWidth, GridHeight), GraphicsUnit.Pixel);

                    t.AddTileToPallet(TileImage, new Point(x, y));
                    g.Dispose();
                }
            }

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
