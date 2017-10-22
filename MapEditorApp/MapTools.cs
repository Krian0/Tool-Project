using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ComponentOwl.BetterListView;

namespace MapEditorApp
{
    public partial class MapTools : Form
    {
        private MapEditor editor;
        private Form uploadBox;
        public List<Map> MapList { get; set; } = new List<Map>();

        public BetterListViewSelectedIndexCollection MapIndex { get; private set; }
        public BetterListViewSelectedIndexCollection ItemIndex { get; private set; }

        string deleteConfirm = "Are you sure you want to delete ";


        public MapTools()
        {
            InitializeComponent();
        }

        public void SetEditor(MapEditor Editor)
        {
            editor = Editor;
        }

        private void RefreshMaps()
        {
            listViewMap.Items.Clear();
            foreach (Map map in MapList)
                listViewMap.Items.Add(map.ListViewMap);
        }

        private void RefreshItems()
        {
            listViewItem.Items.Clear();
            foreach (Item item in MapList[MapIndex[0]].ItemList)
                listViewItem.Items.Add(item.ListViewItem);

            editor.ListsChanged();
        }

        public void AddItem(Bitmap bitmap)
        {
            if (MapIndex.Count == 0 || MapIndex == null) { return; }

            MapList[MapIndex[0]].ItemList.Add(new Item("Item ", MapList[MapIndex[0]].ItemList.Count, bitmap));
            RefreshItems();

            editor.ListsChanged();
        }


        private void ListViewMaps_AfterLabelEdit(object sender, BetterListViewLabelEditEventArgs e)
        {
            MapList[MapIndex[0]].ChangeName(e.Label);
        }

        private void ListViewMaps_SelectedIndexChanged(object sender, EventArgs e)
        {
            MapIndex = listViewMap.SelectedIndices;

            if (MapIndex == null || MapIndex.Count == 0) { return; }

            RefreshItems();
        }

        private void ListViewItem_AfterLabelEdit(object sender, BetterListViewLabelEditEventArgs e)
        {
            MapList[MapIndex[0]].ItemList[ItemIndex[0]].ChangeName(e.Label);
        }

        private void ListViewItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            ItemIndex = listViewItem.SelectedIndices;
        }

        private void ButtonNewMap_Click(object sender, EventArgs e)
        {
            MapList.Add(new Map("Map " + (MapList.Count + 1)));
            RefreshMaps();
        }

        private void ButtonDeleteMap_Click(object sender, EventArgs e)
        {
            if (MapIndex == null || MapIndex.Count == 0) { return; }

            string mapName = MapList[listViewMap.SelectedIndices[0]].Name + "?";
            var confirmResult = MessageBox.Show(deleteConfirm + mapName, "Delete " + mapName, MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                MapList.RemoveAt(listViewMap.SelectedIndices[0]);
                RefreshMaps();
            }
        }

        private void ButtonDeleteItem_Click(object sender, EventArgs e)
        {
            if (MapIndex == null || listViewMap.SelectedIndices.Count == 0 || ItemIndex == null || ItemIndex.Count == 0) { return; }

            string ItemName = MapList[MapIndex[0]].ItemList[ItemIndex[0]].Name + "?";
            var confirmResult = MessageBox.Show("Are you sure you want to delete " + ItemName, "Delete " + ItemName, MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                MapList[MapIndex[0]].ItemList.RemoveAt(ItemIndex[0]);

                for (int i = 1; i < MapList.Count; i++)
                    MapList[MapIndex[0]].ItemList[i].ChangeLayer(i);

                RefreshItems();
            }
        }

        private void ListViewMaps_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                ButtonDeleteMap_Click(sender, e);
        }

        private void ButtonFromGrid_Click(object sender, EventArgs e)
        {
            if (MapIndex == null || MapIndex.Count == 0) { return; }

            Form imageSelection = new ImageSelection();
            imageSelection.MdiParent = Parent as MapEditorParent;
            imageSelection.Owner = this;
            imageSelection.Show();
        }

        private void ButtonFromFile_Click(object sender, EventArgs e)
        {
            if (MapIndex == null || MapIndex.Count == 0) { return; }

            uploadBox = new UploadBox();
            uploadBox.Owner = this;
            uploadBox.Show();
        }
    }
}
