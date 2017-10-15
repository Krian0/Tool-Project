namespace MapEditorApp
{
    partial class MapTools
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listViewMap = new System.Windows.Forms.ListView();
            this.MapName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IsSaved = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewItem = new System.Windows.Forms.ListView();
            this.ItemName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.XYPos = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Layer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonFromGrid = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.MoveUp = new System.Windows.Forms.Button();
            this.MoveDown = new System.Windows.Forms.Button();
            this.buttonDeleteMap = new System.Windows.Forms.Button();
            this.buttonNewMap = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // listViewMap
            // 
            this.listViewMap.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MapName,
            this.IsSaved});
            this.listViewMap.FullRowSelect = true;
            this.listViewMap.LabelEdit = true;
            this.listViewMap.Location = new System.Drawing.Point(12, 42);
            this.listViewMap.MultiSelect = false;
            this.listViewMap.Name = "listViewMap";
            this.listViewMap.Size = new System.Drawing.Size(278, 168);
            this.listViewMap.TabIndex = 1;
            this.listViewMap.UseCompatibleStateImageBehavior = false;
            this.listViewMap.View = System.Windows.Forms.View.Details;
            this.listViewMap.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listViewMap_AfterLabelEdit);
            this.listViewMap.ItemActivate += new System.EventHandler(this.listViewMap_ItemActivate);
            this.listViewMap.SelectedIndexChanged += new System.EventHandler(this.listViewMap_SelectedIndexChanged);
            this.listViewMap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewMap_KeyDown);
            // 
            // MapName
            // 
            this.MapName.Text = "Map Name";
            this.MapName.Width = 210;
            // 
            // IsSaved
            // 
            this.IsSaved.Text = "Saved";
            // 
            // listViewItem
            // 
            this.listViewItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ItemName,
            this.XYPos,
            this.Layer});
            this.listViewItem.LabelEdit = true;
            this.listViewItem.Location = new System.Drawing.Point(12, 216);
            this.listViewItem.MultiSelect = false;
            this.listViewItem.Name = "listViewItem";
            this.listViewItem.Size = new System.Drawing.Size(278, 341);
            this.listViewItem.TabIndex = 2;
            this.listViewItem.UseCompatibleStateImageBehavior = false;
            this.listViewItem.View = System.Windows.Forms.View.Details;
            this.listViewItem.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listViewItem_AfterLabelEdit);
            // 
            // ItemName
            // 
            this.ItemName.Text = "Name";
            this.ItemName.Width = 132;
            // 
            // XYPos
            // 
            this.XYPos.Text = "X/Y Position";
            this.XYPos.Width = 88;
            // 
            // Layer
            // 
            this.Layer.Text = "Layer";
            this.Layer.Width = 50;
            // 
            // buttonFromGrid
            // 
            this.buttonFromGrid.Location = new System.Drawing.Point(12, 563);
            this.buttonFromGrid.Name = "buttonFromGrid";
            this.buttonFromGrid.Size = new System.Drawing.Size(125, 23);
            this.buttonFromGrid.TabIndex = 3;
            this.buttonFromGrid.Text = "Add From Grid";
            this.toolTip.SetToolTip(this.buttonFromGrid, "Add an item (image) from a grid or custom area");
            this.buttonFromGrid.UseVisualStyleBackColor = true;
            this.buttonFromGrid.Click += new System.EventHandler(this.buttonFromGrid_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 592);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Add From File";
            this.toolTip.SetToolTip(this.button2, "Add an item (image) from a file");
            this.button2.UseVisualStyleBackColor = true;
            // 
            // MoveUp
            // 
            this.MoveUp.Location = new System.Drawing.Point(260, 563);
            this.MoveUp.Name = "MoveUp";
            this.MoveUp.Size = new System.Drawing.Size(30, 23);
            this.MoveUp.TabIndex = 5;
            this.MoveUp.Text = "▲";
            this.toolTip.SetToolTip(this.MoveUp, "Move item up");
            this.MoveUp.UseVisualStyleBackColor = true;
            // 
            // MoveDown
            // 
            this.MoveDown.Location = new System.Drawing.Point(260, 592);
            this.MoveDown.Name = "MoveDown";
            this.MoveDown.Size = new System.Drawing.Size(30, 23);
            this.MoveDown.TabIndex = 6;
            this.MoveDown.Text = "▼";
            this.toolTip.SetToolTip(this.MoveDown, "Move item down");
            this.MoveDown.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteMap
            // 
            this.buttonDeleteMap.Location = new System.Drawing.Point(194, 12);
            this.buttonDeleteMap.Name = "buttonDeleteMap";
            this.buttonDeleteMap.Size = new System.Drawing.Size(96, 24);
            this.buttonDeleteMap.TabIndex = 7;
            this.buttonDeleteMap.Text = "Delete Map";
            this.toolTip.SetToolTip(this.buttonDeleteMap, "Delete selected map");
            this.buttonDeleteMap.UseVisualStyleBackColor = true;
            this.buttonDeleteMap.Click += new System.EventHandler(this.buttonDeleteMap_Click);
            // 
            // buttonNewMap
            // 
            this.buttonNewMap.Location = new System.Drawing.Point(12, 12);
            this.buttonNewMap.Name = "buttonNewMap";
            this.buttonNewMap.Size = new System.Drawing.Size(96, 24);
            this.buttonNewMap.TabIndex = 8;
            this.buttonNewMap.Text = "New Map";
            this.toolTip.SetToolTip(this.buttonNewMap, "Add new map");
            this.buttonNewMap.UseVisualStyleBackColor = true;
            this.buttonNewMap.Click += new System.EventHandler(this.buttonNewMap_Click);
            // 
            // MapTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(302, 649);
            this.Controls.Add(this.buttonNewMap);
            this.Controls.Add(this.buttonDeleteMap);
            this.Controls.Add(this.MoveDown);
            this.Controls.Add(this.MoveUp);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonFromGrid);
            this.Controls.Add(this.listViewItem);
            this.Controls.Add(this.listViewMap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MapTools";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MapTools";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewMap;
        private System.Windows.Forms.ColumnHeader MapName;
        private System.Windows.Forms.ColumnHeader IsSaved;
        private System.Windows.Forms.ListView listViewItem;
        private System.Windows.Forms.ColumnHeader ItemName;
        private System.Windows.Forms.ColumnHeader XYPos;
        private System.Windows.Forms.ColumnHeader Layer;
        private System.Windows.Forms.Button buttonFromGrid;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button MoveUp;
        private System.Windows.Forms.Button MoveDown;
        private System.Windows.Forms.Button buttonDeleteMap;
        private System.Windows.Forms.Button buttonNewMap;
        private System.Windows.Forms.ToolTip toolTip;
    }
}