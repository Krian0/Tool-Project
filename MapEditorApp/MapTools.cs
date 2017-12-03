using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ComponentOwl.BetterListView;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

//NOTE:
//If BetterListView is not working, it can be downloaded at https://visualstudiogallery.msdn.microsoft.com/f46bc2cb-9ba3-4ad6-91fd-55f0eadba6ea/view/Reviews

namespace MapEditorApp
{
    public partial class MapTools : Form
    {
        private MapEditor ed = null;
        public Form uploadBox = null;

        public List<Map> MapList { get; set; } = new List<Map>();
        public List<Tile> paintTiles = new List<Tile>();
        public List<Tile> selectedPaintTiles = new List<Tile>();

        public int MapIndex { get; private set; } = -1;
        public int LayerIndex { get; private set; } = -1;
        public int PaintIndex { get; private set; } = -1;

        public Size paintPalletSize  = new Size(16, 16);
        public int paintPalletMargin = 6;

        string deleteText = "Are you sure you want to delete ";
        private int MapCount = 0;

        public Bitmap displayBase;
        public Image displayImage;

        public MapTools(MapEditorParent ToolParent)
        {
            InitializeComponent();

            panel1.HorizontalScroll.Enabled = true;
            picturePaintPallet.SizeMode = PictureBoxSizeMode.AutoSize;
            panel1.Controls.Add(picturePaintPallet);
        }


        #region MapTool Functions
        public void SetEditor(MapEditor Editor)
        {
            ed = Editor;
            Draw();
        }

        public void MapSetup(Size MapSize, Size GridSize, int TilesWide, int TilesHigh)
        {
            int NewIndex = MapList.Count - 1;

            MapList[NewIndex].mapSize = MapSize;
            MapList[NewIndex].gridSize = GridSize;
            MapList[NewIndex].tiles = new Tile[TilesWide, TilesHigh];

            if (MapIndex != -1)
                listViewMap.Items[MapIndex].Selected = false;
            listViewMap.Items[NewIndex].Selected = true;

            ed.SetPictureBox(MapSize, GridSize);
            AddLayer(MapList.Count - 1);
        }

        public void AddLayer(int Map_Index)
        {
            Size MapSize = MapList[Map_Index].mapSize;
            Bitmap image = new Bitmap(MapSize.Width, MapSize.Height);

            Graphics g = Graphics.FromImage(image);
            g.Clear(Color.Transparent);
            g.Dispose();

            MapList[Map_Index].layers.Add(image);
            listViewLayers.Items.Add("Layer " + MapList[Map_Index].LayerCount++);

            if (LayerIndex != -1)
                listViewLayers.Items[LayerIndex].Selected = false;
            listViewLayers.Items[MapList[Map_Index].layers.Count - 1].Selected = true;
        }

        public void AddTile(Image TileImage, Point TileLocation)
        {
            paintTiles.Add(new Tile(TileImage, true, false, new Rectangle(TileLocation, TileImage.Size)));
            ed.Draw();
        }

        public void Draw()
        {
            if (displayImage == null) { return; }

            Graphics g = Graphics.FromImage(displayBase);
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.Clear(Color.Transparent);
            g.DrawImage(displayImage, 0, 0);

            //Draw grid
            for (int x = 0; x < displayImage.Width; x += (paintPalletSize.Width + paintPalletMargin))
                for (int y = 0; y < displayImage.Height; y += (paintPalletSize.Height + paintPalletMargin))
                    g.DrawRectangle(new Pen(Brushes.Black), new Rectangle(x, y, paintPalletSize.Width, paintPalletSize.Height));

            for (int i = 0; i < selectedPaintTiles.Count; i++)
                g.DrawRectangle(new Pen(Brushes.LightSeaGreen, 2), selectedPaintTiles[i].tileRect);

            g.Dispose();
            picturePaintPallet.Image = displayBase;
        }
        #endregion


        #region MapTools Actions
        private void ListViewMaps_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewMap.SelectedIndices.Count < 1)
            {
                MapIndex = -1;
                Size Temp = new Size(1, 1);
                ed.SetPictureBox(Temp, Temp);
                return;
            }

            MapIndex = listViewMap.SelectedIndices[0];
            listViewLayers.Clear();
            for (int i = 0; i < MapList[MapIndex].layers.Count; i++)
                listViewLayers.Items.Add("Layer " + i);

            ed.SetPictureBox(MapList[MapIndex].mapSize, MapList[MapIndex].gridSize);
            ed.Draw();
        }

        private void ListViewLayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewLayers.SelectedIndices.Count < 1)
            {
                LayerIndex = -1;
                return;
            }

            LayerIndex = listViewLayers.SelectedIndices[0];
        }


        private void ListViewMaps_AfterLabelEdit(object sender, BetterListViewLabelEditEventArgs e)
        {
            MapList[MapIndex].name = e.Label;
        }


        private void ListViewMaps_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                ButtonDeleteMap_Click(sender, e);
        }


        private void ButtonNewMap_Click(object sender, EventArgs e)
        {
            MapList.Add(new Map("Map " + ++MapCount));
            listViewMap.Items.Add("Map " + MapCount);

            SetMap setMap = new SetMap(this);
            setMap.ShowDialog();
        }

        private void ButtonAddLayer_Click(object sender, EventArgs e)
        {
            if (MapIndex == -1) { return; }

            AddLayer(MapIndex);
        }


        private void ButtonDeleteMap_Click(object sender, EventArgs e)
        {
            if (MapIndex == -1) { return; }

            string Name = MapList[MapIndex].name + "?";
            var confirmResult = MessageBox.Show(Parent, deleteText + Name, "Delete " + Name, MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                MapList.RemoveAt(MapIndex);
                listViewMap.Items.RemoveAt(MapIndex);
                if (MapList.Count >= 1)
                    listViewMap.Items[MapList.Count - 1].Selected = true;
                else
                    MapIndex = -1;

                listViewLayers.Clear();
                ed.Draw();
            }
        }

        private void ButtonDeleteLayer_Click(object sender, EventArgs e)
        {
            if (MapIndex == -1 || LayerIndex == -1 || MapList[MapIndex].layers.Count == 1) { return; }

            MapList[MapIndex].layers.RemoveAt(LayerIndex);
            listViewLayers.Items.RemoveAt(LayerIndex);
            listViewLayers.Items[MapList[MapIndex].layers.Count - 1].Selected = true;

            ed.Draw();
        }


        private void ButtonFromFile_Click(object sender, EventArgs e)
        {
            if (uploadBox != null) { return; }
            uploadBox = new UploadBox(this);
            uploadBox.ShowDialog();

            SetPaintPallet setPallet = new SetPaintPallet(this);
            setPallet.ShowDialog();
        }

        private void ButtonViewGrid_Click(object sender, EventArgs e)
        {
            if (MapIndex == -1) { return; }

            if (ed.drawGrid == true)
                buttonViewGrid.Text = "Show Grid";
            else
                buttonViewGrid.Text = "Hide Grid";

            ed.drawGrid = !ed.drawGrid;
            ed.Draw();
        }
        #endregion

        private void PicturePaintPallet_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < paintTiles.Count; i++)
            {
                if (paintTiles[i].tileRect.Contains(e.Location))
                {
                    PaintIndex = 1;

                    if (!paintTiles[i].isSelected)
                    {
                        paintTiles[i].isSelected = true;
                        selectedPaintTiles.Add(paintTiles[i]);
                    }
                    else
                    {
                        selectedPaintTiles.Remove(paintTiles[i]);
                        paintTiles[i].isSelected = false;
                    }
                }
            }

            Draw();
        }
    }
}
