using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MapEditorApp
{
    public class Map
    {
        //Remove use of itemlist in maptools, provide methods here!!!

        public string Name { get; private set; }
        public bool Saved { get; private set; }
        public List<Item> ItemList { get; set; } = new List<Item>();

        public Map(string mapName)
        {
            Name = mapName;
            Saved = false;
        }

        public void ChangeName(string name)
        {
            Name = name;
        }

        public void ChangeSaveStatus(bool saved)
        {
            Saved = saved;
        }

        public void AddItem(Bitmap bitmap)
        {
            ItemList.Add(new Item("Item ", ItemList.Count, bitmap));
        }

        public void ChangeItemName()
        {

        }

        public ComponentOwl.BetterListView.BetterListViewItem ListViewMap
        {
            get
            {
                ComponentOwl.BetterListView.BetterListViewItem MapListItem = new ComponentOwl.BetterListView.BetterListViewItem(Name);
                if (Saved == false)
                    MapListItem.SubItems.Add("No");
                else
                    MapListItem.SubItems.Add("Yes");

                return MapListItem;
            }
        }
    }
}
