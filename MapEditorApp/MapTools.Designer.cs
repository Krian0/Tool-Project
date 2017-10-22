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
            this.buttonFromGrid = new System.Windows.Forms.Button();
            this.buttonFromFile = new System.Windows.Forms.Button();
            this.MoveUp = new System.Windows.Forms.Button();
            this.MoveDown = new System.Windows.Forms.Button();
            this.buttonDeleteMap = new System.Windows.Forms.Button();
            this.buttonNewMap = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonDeleteItem = new System.Windows.Forms.Button();
            this.listViewMap = new ComponentOwl.BetterListView.BetterListView();
            this.betterListViewColumnHeader1 = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.betterListViewColumnHeader2 = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.listViewItem = new ComponentOwl.BetterListView.BetterListView();
            this.betterListViewColumnHeader3 = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.betterListViewColumnHeader4 = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.betterListViewColumnHeader5 = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            ((System.ComponentModel.ISupportInitialize)(this.listViewMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listViewItem)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonFromGrid
            // 
            this.buttonFromGrid.Location = new System.Drawing.Point(9, 457);
            this.buttonFromGrid.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonFromGrid.Name = "buttonFromGrid";
            this.buttonFromGrid.Size = new System.Drawing.Size(94, 19);
            this.buttonFromGrid.TabIndex = 3;
            this.buttonFromGrid.Text = "Add From Grid";
            this.toolTip.SetToolTip(this.buttonFromGrid, "Add an item (image) from a grid or custom area");
            this.buttonFromGrid.UseVisualStyleBackColor = true;
            this.buttonFromGrid.Click += new System.EventHandler(this.ButtonFromGrid_Click);
            // 
            // buttonFromFile
            // 
            this.buttonFromFile.Location = new System.Drawing.Point(9, 481);
            this.buttonFromFile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonFromFile.Name = "buttonFromFile";
            this.buttonFromFile.Size = new System.Drawing.Size(94, 19);
            this.buttonFromFile.TabIndex = 4;
            this.buttonFromFile.Text = "Add From File";
            this.toolTip.SetToolTip(this.buttonFromFile, "Add an item (image) from a file");
            this.buttonFromFile.UseVisualStyleBackColor = true;
            this.buttonFromFile.Click += new System.EventHandler(this.ButtonFromFile_Click);
            // 
            // MoveUp
            // 
            this.MoveUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveUp.Location = new System.Drawing.Point(195, 457);
            this.MoveUp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MoveUp.Name = "MoveUp";
            this.MoveUp.Size = new System.Drawing.Size(22, 19);
            this.MoveUp.TabIndex = 5;
            this.MoveUp.Text = "▲";
            this.toolTip.SetToolTip(this.MoveUp, "Move item up");
            this.MoveUp.UseVisualStyleBackColor = true;
            // 
            // MoveDown
            // 
            this.MoveDown.Location = new System.Drawing.Point(195, 481);
            this.MoveDown.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MoveDown.Name = "MoveDown";
            this.MoveDown.Size = new System.Drawing.Size(22, 19);
            this.MoveDown.TabIndex = 6;
            this.MoveDown.Text = "▼";
            this.toolTip.SetToolTip(this.MoveDown, "Move item down");
            this.MoveDown.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteMap
            // 
            this.buttonDeleteMap.Location = new System.Drawing.Point(146, 10);
            this.buttonDeleteMap.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonDeleteMap.Name = "buttonDeleteMap";
            this.buttonDeleteMap.Size = new System.Drawing.Size(72, 20);
            this.buttonDeleteMap.TabIndex = 7;
            this.buttonDeleteMap.Text = "Delete Map";
            this.toolTip.SetToolTip(this.buttonDeleteMap, "Delete selected map");
            this.buttonDeleteMap.UseVisualStyleBackColor = true;
            this.buttonDeleteMap.Click += new System.EventHandler(this.ButtonDeleteMap_Click);
            // 
            // buttonNewMap
            // 
            this.buttonNewMap.Location = new System.Drawing.Point(9, 10);
            this.buttonNewMap.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonNewMap.Name = "buttonNewMap";
            this.buttonNewMap.Size = new System.Drawing.Size(72, 20);
            this.buttonNewMap.TabIndex = 8;
            this.buttonNewMap.Text = "New Map";
            this.toolTip.SetToolTip(this.buttonNewMap, "Add new map");
            this.buttonNewMap.UseVisualStyleBackColor = true;
            this.buttonNewMap.Click += new System.EventHandler(this.ButtonNewMap_Click);
            // 
            // buttonDeleteItem
            // 
            this.buttonDeleteItem.Location = new System.Drawing.Point(107, 457);
            this.buttonDeleteItem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonDeleteItem.Name = "buttonDeleteItem";
            this.buttonDeleteItem.Size = new System.Drawing.Size(83, 19);
            this.buttonDeleteItem.TabIndex = 9;
            this.buttonDeleteItem.Text = "Delete Item";
            this.buttonDeleteItem.UseVisualStyleBackColor = true;
            this.buttonDeleteItem.Click += new System.EventHandler(this.ButtonDeleteItem_Click);
            // 
            // listViewMap
            // 
            this.listViewMap.Columns.Add(this.betterListViewColumnHeader1);
            this.listViewMap.Columns.Add(this.betterListViewColumnHeader2);
            this.listViewMap.HideSelectionMode = ComponentOwl.BetterListView.BetterListViewHideSelectionMode.KeepSelection;
            this.listViewMap.LabelEditActivation = ComponentOwl.BetterListView.BetterListViewLabelEditActivation.SingleClick;
            this.listViewMap.LabelEditModeItems = ComponentOwl.BetterListView.BetterListViewLabelEditMode.Text;
            this.listViewMap.Location = new System.Drawing.Point(9, 36);
            this.listViewMap.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listViewMap.Name = "listViewMap";
            this.listViewMap.Size = new System.Drawing.Size(208, 137);
            this.listViewMap.TabIndex = 10;
            this.listViewMap.AfterLabelEdit += new ComponentOwl.BetterListView.BetterListViewLabelEditEventHandler(this.ListViewMaps_AfterLabelEdit);
            this.listViewMap.SelectedIndexChanged += new System.EventHandler(this.ListViewMaps_SelectedIndexChanged);
            this.listViewMap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListViewMaps_KeyDown);
            // 
            // betterListViewColumnHeader1
            // 
            this.betterListViewColumnHeader1.Name = "betterListViewColumnHeader1";
            this.betterListViewColumnHeader1.Text = "Map Name";
            this.betterListViewColumnHeader1.Width = 155;
            // 
            // betterListViewColumnHeader2
            // 
            this.betterListViewColumnHeader2.Name = "betterListViewColumnHeader2";
            this.betterListViewColumnHeader2.Text = "Saved";
            this.betterListViewColumnHeader2.Width = 50;
            // 
            // listViewItem
            // 
            this.listViewItem.Columns.Add(this.betterListViewColumnHeader3);
            this.listViewItem.Columns.Add(this.betterListViewColumnHeader4);
            this.listViewItem.Columns.Add(this.betterListViewColumnHeader5);
            this.listViewItem.HideSelectionMode = ComponentOwl.BetterListView.BetterListViewHideSelectionMode.KeepSelection;
            this.listViewItem.LabelEditActivation = ComponentOwl.BetterListView.BetterListViewLabelEditActivation.SingleClick;
            this.listViewItem.LabelEditModeItems = ComponentOwl.BetterListView.BetterListViewLabelEditMode.Text;
            this.listViewItem.Location = new System.Drawing.Point(9, 177);
            this.listViewItem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listViewItem.Name = "listViewItem";
            this.listViewItem.Size = new System.Drawing.Size(209, 277);
            this.listViewItem.TabIndex = 11;
            this.listViewItem.AfterLabelEdit += new ComponentOwl.BetterListView.BetterListViewLabelEditEventHandler(this.ListViewItem_AfterLabelEdit);
            this.listViewItem.SelectedIndexChanged += new System.EventHandler(this.ListViewItem_SelectedIndexChanged);
            // 
            // betterListViewColumnHeader3
            // 
            this.betterListViewColumnHeader3.Name = "betterListViewColumnHeader3";
            this.betterListViewColumnHeader3.Text = "Name";
            this.betterListViewColumnHeader3.Width = 87;
            // 
            // betterListViewColumnHeader4
            // 
            this.betterListViewColumnHeader4.Name = "betterListViewColumnHeader4";
            this.betterListViewColumnHeader4.Text = "X/Y Position";
            this.betterListViewColumnHeader4.Width = 75;
            // 
            // betterListViewColumnHeader5
            // 
            this.betterListViewColumnHeader5.Name = "betterListViewColumnHeader5";
            this.betterListViewColumnHeader5.Text = "Layer";
            this.betterListViewColumnHeader5.Width = 43;
            // 
            // MapTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(226, 527);
            this.Controls.Add(this.listViewItem);
            this.Controls.Add(this.listViewMap);
            this.Controls.Add(this.buttonDeleteItem);
            this.Controls.Add(this.buttonNewMap);
            this.Controls.Add(this.buttonDeleteMap);
            this.Controls.Add(this.MoveDown);
            this.Controls.Add(this.MoveUp);
            this.Controls.Add(this.buttonFromFile);
            this.Controls.Add(this.buttonFromGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MapTools";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MapTools";
            ((System.ComponentModel.ISupportInitialize)(this.listViewMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listViewItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonFromGrid;
        private System.Windows.Forms.Button buttonFromFile;
        private System.Windows.Forms.Button MoveUp;
        private System.Windows.Forms.Button MoveDown;
        private System.Windows.Forms.Button buttonDeleteMap;
        private System.Windows.Forms.Button buttonNewMap;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button buttonDeleteItem;
        private ComponentOwl.BetterListView.BetterListView listViewMap;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader betterListViewColumnHeader1;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader betterListViewColumnHeader2;
        private ComponentOwl.BetterListView.BetterListView listViewItem;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader betterListViewColumnHeader3;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader betterListViewColumnHeader4;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader betterListViewColumnHeader5;
    }
}