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
            this.buttonAddLayer = new System.Windows.Forms.Button();
            this.buttonDeleteLayer = new System.Windows.Forms.Button();
            this.listViewMap = new ComponentOwl.BetterListView.BetterListView();
            this.betterListViewColumnHeader1 = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.betterListViewColumnHeader2 = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.buttonViewGrid = new System.Windows.Forms.Button();
            this.listViewLayers = new ComponentOwl.BetterListView.BetterListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picturePaintPallet = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.listViewMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listViewLayers)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturePaintPallet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonFromFile
            // 
            this.buttonFromFile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonFromFile.Location = new System.Drawing.Point(12, 461);
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
            this.buttonDeleteMap.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonDeleteMap.Location = new System.Drawing.Point(180, 12);
            this.buttonDeleteMap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDeleteMap.Name = "buttonDeleteMap";
            this.buttonDeleteMap.Size = new System.Drawing.Size(111, 25);
            this.buttonDeleteMap.TabIndex = 7;
            this.buttonDeleteMap.Text = "Delete Map";
            this.toolTip.SetToolTip(this.buttonDeleteMap, "Delete selected map");
            this.buttonDeleteMap.UseVisualStyleBackColor = true;
            this.buttonDeleteMap.Click += new System.EventHandler(this.ButtonDeleteMap_Click);
            // 
            // buttonNewMap
            // 
            this.buttonNewMap.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonNewMap.Location = new System.Drawing.Point(12, 12);
            this.buttonNewMap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonNewMap.Name = "buttonNewMap";
            this.buttonNewMap.Size = new System.Drawing.Size(111, 25);
            this.buttonNewMap.TabIndex = 8;
            this.buttonNewMap.Text = "New Map";
            this.toolTip.SetToolTip(this.buttonNewMap, "Add new map");
            this.buttonNewMap.UseVisualStyleBackColor = true;
            this.buttonNewMap.Click += new System.EventHandler(this.ButtonNewMap_Click);
            // 
            // buttonAddLayer
            // 
            this.buttonAddLayer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonAddLayer.Location = new System.Drawing.Point(12, 227);
            this.buttonAddLayer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAddLayer.Name = "buttonAddLayer";
            this.buttonAddLayer.Size = new System.Drawing.Size(111, 25);
            this.buttonAddLayer.TabIndex = 19;
            this.buttonAddLayer.Text = "Add Layer";
            this.toolTip.SetToolTip(this.buttonAddLayer, "Add new map");
            this.buttonAddLayer.UseVisualStyleBackColor = true;
            this.buttonAddLayer.Click += new System.EventHandler(this.ButtonAddLayer_Click);
            // 
            // buttonDeleteLayer
            // 
            this.buttonDeleteLayer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonDeleteLayer.Location = new System.Drawing.Point(180, 227);
            this.buttonDeleteLayer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDeleteLayer.Name = "buttonDeleteLayer";
            this.buttonDeleteLayer.Size = new System.Drawing.Size(111, 25);
            this.buttonDeleteLayer.TabIndex = 20;
            this.buttonDeleteLayer.Text = "Delete Layer";
            this.toolTip.SetToolTip(this.buttonDeleteLayer, "Delete selected map");
            this.buttonDeleteLayer.UseVisualStyleBackColor = true;
            this.buttonDeleteLayer.Click += new System.EventHandler(this.ButtonDeleteLayer_Click);
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
            // buttonViewGrid
            // 
            this.buttonViewGrid.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonViewGrid.Location = new System.Drawing.Point(180, 461);
            this.buttonViewGrid.Name = "buttonViewGrid";
            this.buttonViewGrid.Size = new System.Drawing.Size(111, 23);
            this.buttonViewGrid.TabIndex = 15;
            this.buttonViewGrid.Text = "Show Grid";
            this.buttonViewGrid.UseVisualStyleBackColor = true;
            this.buttonViewGrid.Click += new System.EventHandler(this.ButtonViewGrid_Click);
            // 
            // listViewLayers
            // 
            this.listViewLayers.HideSelectionMode = ComponentOwl.BetterListView.BetterListViewHideSelectionMode.KeepSelection;
            this.listViewLayers.LabelEditActivation = ComponentOwl.BetterListView.BetterListViewLabelEditActivation.Immediate;
            this.listViewLayers.LabelEditModeItems = ComponentOwl.BetterListView.BetterListViewLabelEditMode.Text;
            this.listViewLayers.Location = new System.Drawing.Point(12, 258);
            this.listViewLayers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listViewLayers.MultiSelect = false;
            this.listViewLayers.Name = "listViewLayers";
            this.listViewLayers.Size = new System.Drawing.Size(279, 185);
            this.listViewLayers.TabIndex = 21;
            this.listViewLayers.SelectedIndexChanged += new System.EventHandler(this.ListViewLayers_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.picturePaintPallet);
            this.panel1.Location = new System.Drawing.Point(12, 490);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(279, 329);
            this.panel1.TabIndex = 22;
            // 
            // picturePaintPallet
            // 
            this.picturePaintPallet.Location = new System.Drawing.Point(0, 0);
            this.picturePaintPallet.Name = "picturePaintPallet";
            this.picturePaintPallet.Size = new System.Drawing.Size(278, 326);
            this.picturePaintPallet.TabIndex = 0;
            this.picturePaintPallet.TabStop = false;
            this.picturePaintPallet.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PicturePaintPallet_MouseClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 825);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(277, 227);
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // MapTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(301, 1102);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listViewLayers);
            this.Controls.Add(this.buttonDeleteLayer);
            this.Controls.Add(this.buttonAddLayer);
            this.Controls.Add(this.buttonViewGrid);
            this.Controls.Add(this.listViewMap);
            this.Controls.Add(this.buttonNewMap);
            this.Controls.Add(this.buttonDeleteMap);
            this.Controls.Add(this.buttonFromFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MapTools";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MapTools";
            ((System.ComponentModel.ISupportInitialize)(this.listViewMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listViewLayers)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picturePaintPallet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonFromFile;
        private System.Windows.Forms.Button buttonDeleteMap;
        private System.Windows.Forms.Button buttonNewMap;
        private System.Windows.Forms.ToolTip toolTip;
        private ComponentOwl.BetterListView.BetterListView listViewMap;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader betterListViewColumnHeader1;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader betterListViewColumnHeader2;
        private System.Windows.Forms.Button buttonViewGrid;
        private System.Windows.Forms.Button buttonAddLayer;
        private System.Windows.Forms.Button buttonDeleteLayer;
        private ComponentOwl.BetterListView.BetterListView listViewLayers;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picturePaintPallet;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}