namespace MapEditorApp
{
    partial class ImageSelection
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.panelGridOptions = new System.Windows.Forms.Panel();
            this.numericUpDownWidth = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownHeight = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMargin = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonCustom = new System.Windows.Forms.Button();
            this.buttonGrid = new System.Windows.Forms.Button();
            this.buttonNewImage = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            this.panelGridOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMargin)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.pictureBoxPreview);
            this.panel1.Controls.Add(this.panelGridOptions);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.buttonCustom);
            this.panel1.Controls.Add(this.buttonGrid);
            this.panel1.Controls.Add(this.buttonNewImage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1011, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 629);
            this.panel1.TabIndex = 0;
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBoxPreview.Location = new System.Drawing.Point(16, 205);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(208, 198);
            this.pictureBoxPreview.TabIndex = 12;
            this.pictureBoxPreview.TabStop = false;
            // 
            // panelGridOptions
            // 
            this.panelGridOptions.Controls.Add(this.numericUpDownWidth);
            this.panelGridOptions.Controls.Add(this.label2);
            this.panelGridOptions.Controls.Add(this.label3);
            this.panelGridOptions.Controls.Add(this.numericUpDownHeight);
            this.panelGridOptions.Controls.Add(this.numericUpDownMargin);
            this.panelGridOptions.Controls.Add(this.label1);
            this.panelGridOptions.Location = new System.Drawing.Point(2, 66);
            this.panelGridOptions.Name = "panelGridOptions";
            this.panelGridOptions.Size = new System.Drawing.Size(222, 75);
            this.panelGridOptions.TabIndex = 11;
            // 
            // numericUpDownWidth
            // 
            this.numericUpDownWidth.DecimalPlaces = 2;
            this.numericUpDownWidth.Location = new System.Drawing.Point(14, 2);
            this.numericUpDownWidth.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownWidth.Name = "numericUpDownWidth";
            this.numericUpDownWidth.Size = new System.Drawing.Size(96, 20);
            this.numericUpDownWidth.TabIndex = 4;
            this.numericUpDownWidth.ValueChanged += new System.EventHandler(this.NumericUpDownWidth_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(122, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Height";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(122, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Margin";
            // 
            // numericUpDownHeight
            // 
            this.numericUpDownHeight.DecimalPlaces = 2;
            this.numericUpDownHeight.Location = new System.Drawing.Point(14, 26);
            this.numericUpDownHeight.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownHeight.Name = "numericUpDownHeight";
            this.numericUpDownHeight.Size = new System.Drawing.Size(96, 20);
            this.numericUpDownHeight.TabIndex = 3;
            this.numericUpDownHeight.ValueChanged += new System.EventHandler(this.NumericUpDownHeight_ValueChanged);
            // 
            // numericUpDownMargin
            // 
            this.numericUpDownMargin.DecimalPlaces = 2;
            this.numericUpDownMargin.Location = new System.Drawing.Point(14, 51);
            this.numericUpDownMargin.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownMargin.Name = "numericUpDownMargin";
            this.numericUpDownMargin.Size = new System.Drawing.Size(96, 20);
            this.numericUpDownMargin.TabIndex = 2;
            this.numericUpDownMargin.ValueChanged += new System.EventHandler(this.NumericUpDownMargin_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(122, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Width";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 176);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Add Selected Tile";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonCustom
            // 
            this.buttonCustom.Location = new System.Drawing.Point(127, 22);
            this.buttonCustom.Name = "buttonCustom";
            this.buttonCustom.Size = new System.Drawing.Size(96, 23);
            this.buttonCustom.TabIndex = 6;
            this.buttonCustom.Text = "Custom";
            this.buttonCustom.UseVisualStyleBackColor = true;
            this.buttonCustom.Click += new System.EventHandler(this.ButtonCustom_Click);
            // 
            // buttonGrid
            // 
            this.buttonGrid.Location = new System.Drawing.Point(15, 22);
            this.buttonGrid.Name = "buttonGrid";
            this.buttonGrid.Size = new System.Drawing.Size(96, 23);
            this.buttonGrid.TabIndex = 5;
            this.buttonGrid.Text = "Grid";
            this.buttonGrid.UseVisualStyleBackColor = true;
            this.buttonGrid.Click += new System.EventHandler(this.ButtonGrid_Click);
            // 
            // buttonNewImage
            // 
            this.buttonNewImage.Location = new System.Drawing.Point(153, 176);
            this.buttonNewImage.Margin = new System.Windows.Forms.Padding(2);
            this.buttonNewImage.Name = "buttonNewImage";
            this.buttonNewImage.Size = new System.Drawing.Size(71, 23);
            this.buttonNewImage.TabIndex = 0;
            this.buttonNewImage.Text = "New Image";
            this.buttonNewImage.UseVisualStyleBackColor = true;
            this.buttonNewImage.Click += new System.EventHandler(this.ButtonNewImage_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.pictureBoxImage);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1007, 629);
            this.panel2.TabIndex = 1;
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBoxImage.Location = new System.Drawing.Point(3, 2);
            this.pictureBoxImage.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(1005, 627);
            this.pictureBoxImage.TabIndex = 0;
            this.pictureBoxImage.TabStop = false;
            this.pictureBoxImage.Click += new System.EventHandler(this.PictureBoxImage_Click);
            this.pictureBoxImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBoxImage_MouseDown);
            this.pictureBoxImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBoxImage_MouseMove);
            this.pictureBoxImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBoxImage_MouseUp);
            // 
            // ImageSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1251, 629);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ImageSelection";
            this.Text = "ImageSelection";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            this.panelGridOptions.ResumeLayout(false);
            this.panelGridOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMargin)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonNewImage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.NumericUpDown numericUpDownWidth;
        private System.Windows.Forms.NumericUpDown numericUpDownHeight;
        private System.Windows.Forms.NumericUpDown numericUpDownMargin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonCustom;
        private System.Windows.Forms.Button buttonGrid;
        private System.Windows.Forms.Panel panelGridOptions;
        private System.Windows.Forms.PictureBox pictureBoxPreview;
    }
}