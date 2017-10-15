using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapEditorApp
{
    public partial class MapTools : Form
    {
        List<Map> mapList = new List<Map>();


        public MapTools()
        {
            InitializeComponent();
        }

        private void addMap()
        {
            mapList.Add(new Map("Map " + mapList.Count.ToString()));
            listViewMap.Items.Add(mapList.Last().GetListViewMap());
        }

        private void deleteMap()
        {
            if (listViewMap.SelectedIndices.Count <= 0)
                return;

            mapList.RemoveAt(listViewMap.SelectedIndices[0]);

            listViewMap.Items.Clear();
            foreach (Map map in mapList)
                listViewMap.Items.Add(map.GetListViewMap());
        }

        public void addItem()
        {

        }

        private void deleteItem()
        {

        }

        private void addItemListing(Item ItemToList)
        {
            
        }

        private void listViewMap_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            mapList[e.Item].Name = e.Label;
        }

        private void listViewItem_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {

        }

        private void buttonNewMap_Click(object sender, EventArgs e)
        {
            addMap();
        }

        private void buttonDeleteMap_Click(object sender, EventArgs e)
        {
            deleteMap();
        }



        private void listViewMap_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listViewMap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                deleteMap();
        }

        private void listViewMap_ItemActivate(object sender, EventArgs e)
        {
            //could be the wrong trigger
            listViewItem.Clear();

            foreach (Item item in mapList[listViewMap.SelectedIndices[0]].itemList)
                listViewItem.Items.Add(item.GetListViewItem());
        }

        private void buttonFromGrid_Click(object sender, EventArgs e)
        {
            Form imageSelection = new ImageSelection();
            imageSelection.MdiParent = Parent as MapEditorParent;
            imageSelection.Show();
        }
    }
}
