﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapEditorApp
{
    class Item
    {
        public string Name { get; set; }
        public PointF Pos { get; set; }
        public int Layer { get; set; }

        public Item(string ItemName, int ItemNumber)
        {
            Name = ItemName;
            Pos = new PointF(0, 0);
            Layer = ItemNumber;
        }

        public ListViewItem GetListViewItem()
        {
            ListViewItem NewListItem = new ListViewItem(Name);
            NewListItem.SubItems.Add("X: " + Pos.X.ToString() + " Y: " + Pos.Y.ToString());
            NewListItem.SubItems.Add(Layer.ToString());

            return NewListItem;
        }
    }
}
