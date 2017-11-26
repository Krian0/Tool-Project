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
        public Form setMap = null;

        public List<Map> MapList { get; set; } = new List<Map>();
        public List<Tile> paintTiles = new List<Tile>();

        public int MapIndex { get; private set; } = -1;
        public int LayerIndex { get; private set; } = -1;
        public int PaintIndex { get; private set; } = -1;

        public bool PaintTileSelected { get; private set; } = false;
        public Rectangle SelectedTile { get; private set; } = new Rectangle(0, 0, 0, 0);
        private Rectangle TempSelection = new Rectangle(0, 0, 0, 0);
        private Point nextFreeTile = new Point(0, 0);
        private Point paintPreviewSize = new Point(50, 50);

        string deleteText = "Are you sure you want to delete ";
        private int MapCount = 0;

        private Bitmap displayImage;

        public MapTools(MapEditorParent ToolParent)
        {
            InitializeComponent();

            panel1.HorizontalScroll.Enabled = true;
            pictureItems.Size = new Size(panel1.Size.Width + 20, panel1.Size.Height - 21);
            panel1.Controls.Add(pictureItems);

            displayImage = new Bitmap(paintPreviewSize.X * 10, paintPreviewSize.Y * 6);
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

        public void AddItem(Image ItemImage)
        {
            paintTiles.Add(new Tile(ItemImage, true, new Rectangle(nextFreeTile, ItemImage.Size)));
            nextFreeTile.X = nextFreeTile.X + ItemImage.Size.Width;
            Draw();
            ed.Draw();
        }

        public void Draw()
        {
            Graphics g = Graphics.FromImage(displayImage);
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.Clear(Color.Transparent);

            //Draw paintable tiles
            for (int i = 0; i < paintTiles.Count; i++)
                g.DrawImage(paintTiles[i].image, paintTiles[i].tileRect.Location);

            //Draw grid
            for (float x = 0; x < pictureItems.Width; x += paintPreviewSize.X)
                g.DrawLine(new Pen(Brushes.Black), x, 0, x, pictureItems.Height);
            for (float y = 0; y < pictureItems.Height; y += paintPreviewSize.Y)
                g.DrawLine(new Pen(Brushes.Black), 0, y, pictureItems.Width, y);

            //if (PaintTileSelected == true)
                g.DrawRectangle(new Pen(Brushes.LightSeaGreen), SelectedTile);

            g.Dispose();
            pictureItems.Image = displayImage;
        }

        private void DetectPaintTileSelection()
        {
            int X = Math.Min(TempSelection.Location.X, TempSelection.Width);
            int Y = Math.Min(TempSelection.Y, TempSelection.Height);
            int W = Math.Max(TempSelection.Location.X, TempSelection.Width);
            int H = Math.Max(TempSelection.Y, TempSelection.Height);


            SelectedTile = new Rectangle(X, Y, W, H);
            PaintTileSelected = true;
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

            paintPreviewSize = (Point)MapList[MapIndex].gridSize;
            pictureItems.Size = new Size(MapList[MapIndex].gridSize.Width * 10, MapList[MapIndex].gridSize.Height * 6);
            Draw();

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
            if (setMap != null) { return; }

            MapList.Add(new Map("Map " + ++MapCount));
            listViewMap.Items.Add("Map " + MapCount);

            setMap = new SetMap(this);
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
            uploadBox = new UploadBox() { Owner = this };
            uploadBox.ShowDialog();
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

        private void PictureItems_MouseDown(object sender, MouseEventArgs e)
        {
            TempSelection.Location = e.Location;
            PaintIndex = 1;
        }

        private void PictureItems_MouseUp(object sender, MouseEventArgs e)
        {
            if (PaintIndex == -1) { return; }

            TempSelection.Size = (Size)e.Location;
            DetectPaintTileSelection();
            PaintIndex = -1;
            Draw();
        }

        private void pictureItems_MouseMove(object sender, MouseEventArgs e)
        {
            if (PaintIndex == -1) { return; }

            TempSelection.Size = (Size)e.Location;
            DetectPaintTileSelection();
            Draw();
        }
    }
}
