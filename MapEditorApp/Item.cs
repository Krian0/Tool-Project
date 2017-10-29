using ComponentOwl.BetterListView;
using System.Drawing;
using System.Windows.Forms;

namespace MapEditorApp
{
    public class Item
    {
        public string name;
        public Image image;

        public Item(string ItemName, Image ItemImage)
        {
            name = ItemName;
            image = ItemImage;
        }
    }
}
