using ComponentOwl.BetterListView;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MapEditorApp
{
    public class Map
    {
        public string name;
        public bool saved;

        public Size mapSize;
        public Size gridSize;

        public List<Layer> layers = new List<Layer>();

        public BetterListViewItem ListViewMap { get { return ListMap(new BetterListViewItem(name)); } }


        #region Map List Functions
        public Map(string mapName)
        {
            name = mapName;
            saved = false;
        }

        private BetterListViewItem ListMap(BetterListViewItem Item)
        {
            if (saved == false)
                Item.SubItems.Add("No");
            else
                Item.SubItems.Add("Yes");

            return Item;
        }
        #endregion
    }
}
