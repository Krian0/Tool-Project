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
            this.buttonFromFile = new System.Windows.Forms.Button();
            this.buttonDeleteMap = new System.Windows.Forms.Button();
            this.buttonNewMap = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonDeleteItem = new System.Windows.Forms.Button();
            this.listViewMap = new ComponentOwl.BetterListView.BetterListView();
            this.betterListViewColumnHeader1 = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.betterListViewColumnHeader2 = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.listViewItem = new ComponentOwl.BetterListView.BetterListView();
            this.numericUpDownWidth = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownHeight = new System.Windows.Forms.NumericUpDown();
            this.buttonViewGrid = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.listViewMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listViewItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonFromFile
            // 
            this.buttonFromFile.Location = new System.Drawing.Point(12, 563);
            this.buttonFromFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonFromFile.Name = "buttonFromFile";
            this.buttonFromFile.Size = new System.Drawing.Size(111, 23);
            this.buttonFromFile.TabIndex = 4;
            this.buttonFromFile.Text = "Add From File";
            this.toolTip.SetToolTip(this.buttonFromFile, "Add an item (image) from a file");
            this.buttonFromFile.UseVisualStyleBackColor = true;
            this.buttonFromFile.Click += new System.EventHandler(this.ButtonFromFile_Click);
            // 
            // buttonDeleteMap
            // 
            this.buttonDeleteMap.Location = new System.Drawing.Point(195, 12);
            this.buttonDeleteMap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDeleteMap.Name = "buttonDeleteMap";
            this.buttonDeleteMap.Size = new System.Drawing.Size(96, 25);
            this.buttonDeleteMap.TabIndex = 7;
            this.buttonDeleteMap.Text = "Delete Map";
            this.toolTip.SetToolTip(this.buttonDeleteMap, "Delete selected map");
            this.buttonDeleteMap.UseVisualStyleBackColor = true;
            this.buttonDeleteMap.Click += new System.EventHandler(this.ButtonDeleteMap_Click);
            // 
            // buttonNewMap
            // 
            this.buttonNewMap.Location = new System.Drawing.Point(12, 12);
            this.buttonNewMap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonNewMap.Name = "buttonNewMap";
            this.buttonNewMap.Size = new System.Drawing.Size(96, 25);
            this.buttonNewMap.TabIndex = 8;
            this.buttonNewMap.Text = "New Map";
            this.toolTip.SetToolTip(this.buttonNewMap, "Add new map");
            this.buttonNewMap.UseVisualStyleBackColor = true;
            this.buttonNewMap.Click += new System.EventHandler(this.ButtonNewMap_Click);
            // 
            // buttonDeleteItem
            // 
            this.buttonDeleteItem.Location = new System.Drawing.Point(180, 563);
            this.buttonDeleteItem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDeleteItem.Name = "buttonDeleteItem";
            this.buttonDeleteItem.Size = new System.Drawing.Size(111, 23);
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
            this.listViewMap.LabelEditActivation = ComponentOwl.BetterListView.BetterListViewLabelEditActivation.Immediate;
            this.listViewMap.LabelEditModeItems = ComponentOwl.BetterListView.BetterListViewLabelEditMode.Text;
            this.listViewMap.Location = new System.Drawing.Point(12, 44);
            this.listViewMap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listViewMap.MultiSelect = false;
            this.listViewMap.Name = "listViewMap";
            this.listViewMap.Size = new System.Drawing.Size(279, 169);
            this.listViewMap.TabIndex = 10;
            this.listViewMap.AfterLabelEdit += new ComponentOwl.BetterListView.BetterListViewLabelEditEventHandler(this.ListViewMaps_AfterLabelEdit);
            this.listViewMap.SelectedIndexChanged += new System.EventHandler(this.ListViewMaps_SelectedIndexChanged);
            this.listViewMap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListViewMaps_KeyDown);
            // 
            // betterListViewColumnHeader1
            // 
            this.betterListViewColumnHeader1.Name = "betterListViewColumnHeader1";
            this.betterListViewColumnHeader1.Text = "Map Name";
            this.betterListViewColumnHeader1.Width = 207;
            // 
            // betterListViewColumnHeader2
            // 
            this.betterListViewColumnHeader2.Name = "betterListViewColumnHeader2";
            this.betterListViewColumnHeader2.Text = "Saved";
            this.betterListViewColumnHeader2.Width = 65;
            // 
            // listViewItem
            // 
            this.listViewItem.AutoSizeItemsInDetailsView = true;
            this.listViewItem.HeaderStyle = ComponentOwl.BetterListView.BetterListViewHeaderStyle.Nonclickable;
            this.listViewItem.HideSelectionMode = ComponentOwl.BetterListView.BetterListViewHideSelectionMode.KeepSelection;
            this.listViewItem.LabelEditActivation = ComponentOwl.BetterListView.BetterListViewLabelEditActivation.Immediate;
            this.listViewItem.LabelEditModeItems = ComponentOwl.BetterListView.BetterListViewLabelEditMode.Text;
            this.listViewItem.Location = new System.Drawing.Point(12, 218);
            this.listViewItem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listViewItem.MultiSelect = false;
            this.listViewItem.Name = "listViewItem";
            this.listViewItem.Size = new System.Drawing.Size(279, 341);
            this.listViewItem.TabIndex = 11;
            this.listViewItem.View = ComponentOwl.BetterListView.BetterListViewView.LargeIcon;
            this.listViewItem.AfterLabelEdit += new ComponentOwl.BetterListView.BetterListViewLabelEditEventHandler(this.ListViewItem_AfterLabelEdit);
            this.listViewItem.SelectedIndexChanged += new System.EventHandler(this.ListViewItem_SelectedIndexChanged);
            // 
            // numericUpDownWidth
            // 
            this.numericUpDownWidth.Location = new System.Drawing.Point(12, 607);
            this.numericUpDownWidth.Name = "numericUpDownWidth";
            this.numericUpDownWidth.Size = new System.Drawing.Size(96, 22);
            this.numericUpDownWidth.TabIndex = 12;
            // 
            // numericUpDownHeight
            // 
            this.numericUpDownHeight.Location = new System.Drawing.Point(12, 635);
            this.numericUpDownHeight.Name = "numericUpDownHeight";
            this.numericUpDownHeight.Size = new System.Drawing.Size(96, 22);
            this.numericUpDownHeight.TabIndex = 13;
            // 
            // buttonViewGrid
            // 
            this.buttonViewGrid.Location = new System.Drawing.Point(12, 663);
            this.buttonViewGrid.Name = "buttonViewGrid";
            this.buttonViewGrid.Size = new System.Drawing.Size(96, 27);
            this.buttonViewGrid.TabIndex = 15;
            this.buttonViewGrid.Text = "Show Grid";
            this.buttonViewGrid.UseVisualStyleBackColor = true;
            this.buttonViewGrid.Click += new System.EventHandler(this.ButtonViewGrid_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(114, 612);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "Grid Width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 640);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "Grid Height";
            // 
            // MapTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(301, 816);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonViewGrid);
            this.Controls.Add(this.numericUpDownHeight);
            this.Controls.Add(this.numericUpDownWidth);
            this.Controls.Add(this.listViewItem);
            this.Controls.Add(this.listViewMap);
            this.Controls.Add(this.buttonDeleteItem);
            this.Controls.Add(this.buttonNewMap);
            this.Controls.Add(this.buttonDeleteMap);
            this.Controls.Add(this.buttonFromFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MapTools";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MapTools";
            ((System.ComponentModel.ISupportInitialize)(this.listViewMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listViewItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonFromFile;
        private System.Windows.Forms.Button buttonDeleteMap;
        private System.Windows.Forms.Button buttonNewMap;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button buttonDeleteItem;
        private ComponentOwl.BetterListView.BetterListView listViewMap;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader betterListViewColumnHeader1;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader betterListViewColumnHeader2;
        private ComponentOwl.BetterListView.BetterListView listViewItem;
        private System.Windows.Forms.NumericUpDown numericUpDownWidth;
        private System.Windows.Forms.NumericUpDown numericUpDownHeight;
        private System.Windows.Forms.Button buttonViewGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}