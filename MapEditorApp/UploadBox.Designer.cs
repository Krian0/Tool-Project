namespace MapEditorApp
{
    partial class UploadBox
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
            this.buttonUpload = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonConfirmSelection = new System.Windows.Forms.Button();
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Controls.Add(this.pictureBoxPreview);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1049, 579);
            this.panel1.TabIndex = 0;
            // 
            // buttonUpload
            // 
            this.buttonUpload.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonUpload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonUpload.Location = new System.Drawing.Point(12, 618);
            this.buttonUpload.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonUpload.Name = "buttonUpload";
            this.buttonUpload.Size = new System.Drawing.Size(156, 34);
            this.buttonUpload.TabIndex = 1;
            this.buttonUpload.Text = "Upload";
            this.buttonUpload.UseVisualStyleBackColor = false;
            this.buttonUpload.Click += new System.EventHandler(this.ButtonUpload_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(9, 598);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Or";
            // 
            // buttonConfirmSelection
            // 
            this.buttonConfirmSelection.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonConfirmSelection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonConfirmSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonConfirmSelection.Location = new System.Drawing.Point(905, 619);
            this.buttonConfirmSelection.Name = "buttonConfirmSelection";
            this.buttonConfirmSelection.Size = new System.Drawing.Size(156, 34);
            this.buttonConfirmSelection.TabIndex = 3;
            this.buttonConfirmSelection.Text = "Confirm Selection";
            this.buttonConfirmSelection.UseVisualStyleBackColor = false;
            this.buttonConfirmSelection.Click += new System.EventHandler(this.ButtonConfirmSelection_Click);
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.FileDropBanner;
            this.pictureBoxPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxPreview.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(1043, 573);
            this.pictureBoxPreview.TabIndex = 0;
            this.pictureBoxPreview.TabStop = false;
            // 
            // UploadBox
            // 
            this.AcceptButton = this.buttonConfirmSelection;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1077, 663);
            this.Controls.Add(this.buttonUpload);
            this.Controls.Add(this.buttonConfirmSelection);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(1095, 710);
            this.Name = "UploadBox";
            this.Text = "UploadBox";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.UploadBox_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.UploadBox_DragEnter);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonUpload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonConfirmSelection;
        private System.Windows.Forms.PictureBox pictureBoxPreview;
    }
}