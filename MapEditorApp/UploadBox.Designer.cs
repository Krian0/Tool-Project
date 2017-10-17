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
            this.panel2 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.FileDropBanner;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(9, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(788, 471);
            this.panel1.TabIndex = 0;
            // 
            // buttonUpload
            // 
            this.buttonUpload.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonUpload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonUpload.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonUpload.Location = new System.Drawing.Point(342, 500);
            this.buttonUpload.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonUpload.Name = "buttonUpload";
            this.buttonUpload.Size = new System.Drawing.Size(117, 28);
            this.buttonUpload.TabIndex = 1;
            this.buttonUpload.Text = "Upload";
            this.buttonUpload.UseVisualStyleBackColor = false;
            this.buttonUpload.Click += new System.EventHandler(this.buttonUpload_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(390, 483);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Or";
            // 
            // panel2
            // 
            this.panel2.AllowDrop = true;
            this.panel2.Location = new System.Drawing.Point(10, 10);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(787, 471);
            this.panel2.TabIndex = 3;
            this.panel2.Visible = false;
            // 
            // UploadBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 539);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonUpload);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "UploadBox";
            this.Text = "UploadBox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonUpload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
    }
}