using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapEditorApp
{
    public partial class UploadBox : Form
    {
        ImageSelection parent;
        
        public UploadBox(ImageSelection parentForm)
        {
            InitializeComponent();
            parent = parentForm;
        }

        private void buttonUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.CheckFileExists == true)
                {
                    parent.path = dlg.FileName;
                    parent.image = Image.FromFile(dlg.FileName);

                    this.Close();
                }
            }
        }
    }
}
