﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ComponentOwl.BetterListView;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Linq;

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
        private Rectangle paintSelection;
        private bool isSelecting = false;

        public int MapIndex { get; private set; } = -1;
        public int LayerIndex { get; private set; } = -1;
        public int PaintIndex { get; private set; } = -1;

        public Size paintPalletGrid  = new Size(16, 16);
        public int paintPalletMargin = 6;
        public int selectionColour = 1;

        public List<Tile> selectedTiles = new List<Tile>();
        public Point selectedGrid = new Point(0, 0);

        string deleteText = "Are you sure you want to delete ";
        private int MapCount = 0;

        public Bitmap displayBase = new Bitmap(50, 50);
        public Image displayImage;
        public Image previewImage = new Bitmap(100, 100);
        public Image paintImage;

        public MapTools(MapEditorParent ToolParent)
        {
            InitializeComponent();

            panel1.HorizontalScroll.Enabled = true;
            picturePaintPallet.SizeMode = PictureBoxSizeMode.AutoSize;
            panel1.Controls.Add(picturePaintPallet);
            previewImage = new Bitmap(pictureBoxPreview.Width, pictureBoxPreview.Height);
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

            if (MapIndex != -1)
                listViewMap.Items[MapIndex].Selected = false;
            listViewMap.Items[NewIndex].Selected = true;

            ed.SetPictureBox(MapSize, GridSize);
            AddLayer(NewIndex);
        }

        public void AddLayer(int Map_Index)
        {
            MapList[Map_Index].layers.Add(new Layer(MapList[Map_Index].gridSize, MapList[Map_Index].mapSize));
            listViewLayers.Items.Add("Layer " + MapList[Map_Index].layers.Count);

            if (LayerIndex != -1)
                listViewLayers.Items[LayerIndex].Selected = false;
            listViewLayers.Items[MapList[Map_Index].layers.Count - 1].Selected = true;
        }

        public void AddTileToPallet(Image TileImage, Point TileLocation)
        {
            paintTiles.Add(new Tile(TileImage, true, new Rectangle(TileLocation, TileImage.Size)));
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
            for (int x = 0; x < displayImage.Width; x += (paintPalletGrid.Width + paintPalletMargin))
                for (int y = 0; y < displayImage.Height; y += (paintPalletGrid.Height + paintPalletMargin))
                    g.DrawRectangle(new Pen(Brushes.Black), new Rectangle(x, y, paintPalletGrid.Width, paintPalletGrid.Height));

            if (paintSelection != null)
            {
                if (selectionColour == 1)
                    g.DrawRectangle(new Pen(Brushes.Tomato, 2), paintSelection);

                if (selectionColour == 2)
                    g.DrawRectangle(new Pen(Brushes.Orange, 2), paintSelection);

                if (selectionColour == 3)
                    g.DrawRectangle(new Pen(Brushes.Yellow, 2), paintSelection);

                if (selectionColour == 4)
                    g.DrawRectangle(new Pen(Brushes.SpringGreen, 2), paintSelection);

                if (selectionColour == 5)
                    g.DrawRectangle(new Pen(Brushes.Cyan, 2), paintSelection);

                if (selectionColour == 6)
                    g.DrawRectangle(new Pen(Brushes.Fuchsia, 2), paintSelection);
            }

            g.Dispose();
            picturePaintPallet.Image = displayBase;

            if (selectedTiles.Count > 0)
            {
                GraphicsUnit U = GraphicsUnit.Pixel;
                RectangleF ImageBounds = selectedTiles[0].image.GetBounds(ref U);
                RectangleF previewBounds = previewImage.GetBounds(ref U);

                Graphics gr = Graphics.FromImage(previewImage);
                gr.InterpolationMode = InterpolationMode.NearestNeighbor;
                gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                gr.Clear(Color.White);
                gr.DrawImage(selectedTiles[0].image, previewBounds, ImageBounds, GraphicsUnit.Pixel);
                gr.Dispose();

                pictureBoxPreview.Image = previewImage;
            }
        }

        public void SetSelectedImage(Image DestImage, Image SourceImage, int xPoint, int yPoint, Rectangle PaintFromRect)
        {
            using (Graphics g = Graphics.FromImage(DestImage))
            {
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                g.DrawImage(SourceImage, xPoint, yPoint, PaintFromRect, GraphicsUnit.Pixel);
                g.Dispose();
            }
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

            if (MapList[MapIndex].layers.Count > 0)
                listViewLayers.Items[0].Selected = true;

            ed.redrawAllTiles = true;
            ed.SetPictureBox(MapList[MapIndex].mapSize, MapList[MapIndex].gridSize);
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

            ed.redrawAllTiles = true;
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

                ed.redrawAllTiles = true;
                ed.Draw();
            }
        }

        private void ButtonDeleteLayer_Click(object sender, EventArgs e)
        {
            if (MapIndex == -1 || LayerIndex == -1 || MapList[MapIndex].layers.Count == 1) { return; }

            MapList[MapIndex].layers.RemoveAt(LayerIndex);
            listViewLayers.Items.RemoveAt(LayerIndex);
            listViewLayers.Items[MapList[MapIndex].layers.Count - 1].Selected = true;
            ed.redrawAllTiles = true;
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
            {
                buttonViewGrid.Text = "Show Grid";
                ed.redrawAllTiles = true;
            }
            else
                buttonViewGrid.Text = "Hide Grid";

            ed.drawGrid = !ed.drawGrid;
            ed.Draw();
        }
        #endregion

        private void ButtonColourCycle_Click(object sender, EventArgs e)
        {
            if (selectionColour < 6)
                selectionColour++;
            else
                selectionColour = 1;

            Draw();
        }

        private void PicturePaintPallet_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isSelecting || displayImage == null) { return; }

            for (int i = 0; i < paintTiles.Count; i++)
            {
                if (paintTiles[i].tileRect.Contains(e.Location))
                {
                    Point Location = new Point(Math.Min(paintSelection.Location.X, paintTiles[i].tileRect.X), Math.Min(paintSelection.Location.Y, paintTiles[i].tileRect.Y));
                    Point Extents = new Point(Math.Max(paintSelection.Location.X, paintTiles[i].tileRect.X), Math.Max(paintSelection.Location.Y, paintTiles[i].tileRect.Y));

                    paintSelection.Location = Location;
                    paintSelection.Size = new Size(paintPalletGrid.Width + (Extents.X - Location.X), paintPalletGrid.Height + (Extents.Y - Location.Y));
                }
            }

            Draw();
        }

        private void PicturePaintPallet_MouseDown(object sender, MouseEventArgs e)
        {
            if (displayImage == null) { return; }

            isSelecting = true;
            PaintIndex = 1;

            for (int i = 0; i < paintTiles.Count; i++)
            {
                if (paintTiles[i].tileRect.Contains(e.Location))
                {
                    paintSelection.Location = paintTiles[i].tileRect.Location;
                    paintSelection.Size = paintTiles[i].tileRect.Size;
                }
            }
        }

        private void PicturePaintPallet_MouseUp(object sender, MouseEventArgs e)
        {
            if (displayImage == null || isSelecting == false) { return; }

            isSelecting = false;
            selectedTiles.Clear();

            for (int i = 0; i < paintTiles.Count; i++)
                if (paintSelection.Contains(new Point(paintTiles[i].tileRect.X + 2, paintTiles[i].tileRect.Y + 2)))
                    selectedTiles.Add(paintTiles[i]);

            //int row = 1, col = 1;

            //List<int> R = new List<int>();
            //List<int> C = new List<int>();

            //R.Add(selectedTiles[0].tileRect.X);
            //C.Add(selectedTiles[0].tileRect.Y);

            //for (int i = 1; i < selectedTiles.Count; i++)
            //{
            //    if (!R.Contains(selectedTiles[i].tileRect.X))
            //        row++;
            //    if (!C.Contains(selectedTiles[i].tileRect.Y))
            //        col++;

            //    R.Add(selectedTiles[i].tileRect.X);
            //    C.Add(selectedTiles[i].tileRect.Y);
            //}

            Draw();
        }
    }
}
