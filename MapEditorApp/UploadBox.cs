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
        public UploadBox()
        {
            InitializeComponent();
        }

        private void buttonUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.CheckFileExists == true)
                {
                    (Owner as ImageSelection).image = Image.FromFile(dlg.FileName);
                    (Owner as ImageSelection).OnUploadBoxClose();

                    this.Close();
                }
            }
        }
    }
}
