using System.Drawing;
using System.Windows.Forms;

namespace MapEditorApp
{
    public class Item
    {
        public string Name { get; private set; }
        public PointF Pos { get; private set; }
        public int Layer { get; private set; }

        public Image Image { get; private set; }

        public Item(string ItemName, int ItemLayer, Image image)
        {
            Name = ItemName + (ItemLayer + 1);
            Pos = new PointF(0, 0);
            Layer = ItemLayer;
            Image = image;
        }

        public void ChangeName(string name) => Name = name;
        public void ChangePos(PointF pos) => Pos = pos;
        public void ChangeLayer(int layer) => Layer = layer;

        public ComponentOwl.BetterListView.BetterListViewItem ListViewItem
        {
            get
            {
                ComponentOwl.BetterListView.BetterListViewItem NewListItem = new ComponentOwl.BetterListView.BetterListViewItem(Name);
                NewListItem.SubItems.Add("X: " + Pos.X.ToString() + " Y: " + Pos.Y.ToString());
                NewListItem.SubItems.Add(Layer.ToString());

                return NewListItem;
            }
        }
    }
}
