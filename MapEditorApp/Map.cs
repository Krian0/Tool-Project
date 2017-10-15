using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapEditorApp
{
    class Map
    {
        public string Name { get; set; }
        public bool Saved { get; set; }
        public List<Item> itemList;

        public Map(string MapName)
        {
            Name = MapName;
            Saved = false;
        }

        public ListViewItem GetListViewMap()
        {
            ListViewItem MapListItem = new ListViewItem(Name);
            if (Saved == false)
                MapListItem.SubItems.Add("No");
            else
                MapListItem.SubItems.Add("Yes");

            return MapListItem;
        }
    }
}
