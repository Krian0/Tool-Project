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
        public List<Item> Items { get; set; } = new List<Item>();

        public int MapIndex { get; private set; } = -1;
        public int ItemIndex { get; private set; } = -1;

        string deleteText = "Are you sure you want to delete ";

        public MapTools(MapEditorParent ToolParent)
        {
            InitializeComponent();
        }


#region MapTool Functions
        public void SetEditor(MapEditor Editor)
        {
            ed = Editor;
        }

        public Map CurrentMap()
        {
            if (MapIndex == -1) { return null; }
            return MapList[MapIndex];
        }

        public void MapSetup(int MWidth, int MHeight, int GWidth, int GHeight)
        {
            Size M = new Size(MWidth, MHeight);
            Size G = new Size(GWidth, GHeight);

            MapList[MapIndex].mapSize = M;
            MapList[MapIndex].gridSize = G;
            numericUpDownWidth.Value = GWidth;
            numericUpDownHeight.Value = GHeight;

            ed.SetupMap(M, G);
        }

        public void AddItem(Image ItemImage)
        {
            int newItemIndex = Items.Count;

            Items.Add(new Item("Item ", ItemImage));
            listViewItem.Items.Add(new BetterListViewItem(Items[newItemIndex].name, newItemIndex));

            listViewItem.Items[newItemIndex].Selected = true;

            ImageList ImageList = new ImageList { ImageSize = new Size(50, 50) };

            for (int i = 0; i < newItemIndex + 1; i++)
                ImageList.Images.Add(GetThumbnail(Items[i].image));

            listViewItem.ImageList = ImageList;
            ed.Draw();
        }

        public Bitmap GetThumbnail(Image Image, int Size = 50)
        {
            int Width, Height, X, Y;

            if (Image.Width >= Image.Height)
            {
                Width = Size;
                Height = (int)(Width / ((double)Image.Width / Image.Height));
            }
            else
            {
                Height = Size;
                Width = (int)(Height * ((double)Image.Width / Image.Height));
            }

            X = (Size - Width) / 2;
            Y = (Size - Height) / 2;

            Bitmap thumb = new Bitmap(Size, Size, PixelFormat.Format24bppRgb);

            Graphics g = Graphics.FromImage(thumb);
            g.Clear(Color.White);
            g.InterpolationMode = InterpolationMode.High;
            g.DrawImage(Image, new Rectangle(X, Y, Width, Height), new Rectangle(0, 0, Image.Width, Image.Height), GraphicsUnit.Pixel);

            return thumb;
        }
        #endregion


#region MapTools Actions
        private void ListViewMaps_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewMap.SelectedIndices.Count < 1) { MapIndex = -1; return; }

            MapIndex = listViewMap.SelectedIndices[0];
            ed.Draw();
        }

        private void ListViewItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewItem.SelectedIndices.Count < 1) { ItemIndex = -1; return; }

            ItemIndex = listViewItem.SelectedIndices[0];
            ed.Draw();
        }

        private void ListViewMaps_AfterLabelEdit(object sender, BetterListViewLabelEditEventArgs e)
        {
            MapList[MapIndex].name = e.Label;
        }

        private void ListViewItem_AfterLabelEdit(object sender, BetterListViewLabelEditEventArgs e)
        {
            Items[ItemIndex].name = e.Label;
        }

        private void ListViewMaps_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                ButtonDeleteMap_Click(sender, e);
        }

        private void ButtonNewMap_Click(object sender, EventArgs e)
        {
            if (setMap != null) { return; }

            MapList.Add(new Map("Map " + (MapList.Count + 1)));
            listViewMap.Items.Add("Map " + (MapList.Count));
            listViewMap.Items[(MapList.Count - 1)].Selected = true;

            setMap = new SetMap(this);
            setMap.Show();
            ed.Draw();
        }

        private void ButtonDeleteMap_Click(object sender, EventArgs e)
        {
            if (MapIndex == -1) { return; }

            int Count = MapList.Count;

            string Name = MapList[MapIndex].name + "?";
            var confirmResult = MessageBox.Show(Parent, deleteText + Name, "Delete " + Name, MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                MapList.RemoveAt(MapIndex);
                listViewMap.Items.RemoveAt(MapIndex);
                if (Count > 1)
                    listViewMap.Items[Count - 1].Selected = true;
                else
                    MapIndex = -1;
                ed.Draw();
            }
        }

        private void ButtonDeleteItem_Click(object sender, EventArgs e)
        {
            if (ItemIndex == -1) { return; }

            int Count = Items.Count;

            string Name = Items[ItemIndex].name + "?";
            var confirmResult = MessageBox.Show(Parent, deleteText + Name, "Delete " + Name, MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                Items.RemoveAt(ItemIndex);
                listViewItem.Items.RemoveAt(ItemIndex);
                if (Count > 1)
                    listViewItem.Items[Count - 1].Selected = true;
                else
                    ItemIndex = -1;
            }
        }

        private void ButtonFromFile_Click(object sender, EventArgs e)
        {
            if (uploadBox != null) { return; }
            uploadBox = new UploadBox() { Owner = this };
            uploadBox.Show();
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
    }
}
