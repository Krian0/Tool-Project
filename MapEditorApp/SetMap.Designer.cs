namespace MapEditorApp
{
    partial class SetMap
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
            this.MWidth = new System.Windows.Forms.NumericUpDown();
            this.MHeight = new System.Windows.Forms.NumericUpDown();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GWidth = new System.Windows.Forms.NumericUpDown();
            this.GHeight = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // MWidth
            // 
            this.MWidth.Location = new System.Drawing.Point(187, 55);
            this.MWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MWidth.Name = "MWidth";
            this.MWidth.Size = new System.Drawing.Size(80, 22);
            this.MWidth.TabIndex = 0;
            this.MWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // MHeight
            // 
            this.MHeight.Location = new System.Drawing.Point(187, 85);
            this.MHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MHeight.Name = "MHeight";
            this.MHeight.Size = new System.Drawing.Size(80, 22);
            this.MHeight.TabIndex = 1;
            this.MHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonConfirm.Location = new System.Drawing.Point(0, 128);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(352, 33);
            this.buttonConfirm.TabIndex = 2;
            this.buttonConfirm.Text = "Confirm";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.ButtonConfirm_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(273, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tiles Wide";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(273, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tiles High";
            // 
            // GWidth
            // 
            this.GWidth.Location = new System.Drawing.Point(12, 55);
            this.GWidth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.GWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.GWidth.Name = "GWidth";
            this.GWidth.Size = new System.Drawing.Size(80, 22);
            this.GWidth.TabIndex = 6;
            this.GWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // GHeight
            // 
            this.GHeight.Location = new System.Drawing.Point(12, 85);
            this.GHeight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.GHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.GHeight.Name = "GHeight";
            this.GHeight.Size = new System.Drawing.Size(80, 22);
            this.GHeight.TabIndex = 7;
            this.GHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Grid";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(184, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Map";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(98, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Pixels Wide";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(98, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "Pixels High";
            // 
            // SetMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 161);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.GHeight);
            this.Controls.Add(this.GWidth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.MHeight);
            this.Controls.Add(this.MWidth);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SetMap";
            this.Text = "Map Properties";
            ((System.ComponentModel.ISupportInitialize)(this.MWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown MWidth;
        private System.Windows.Forms.NumericUpDown MHeight;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown GWidth;
        private System.Windows.Forms.NumericUpDown GHeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}