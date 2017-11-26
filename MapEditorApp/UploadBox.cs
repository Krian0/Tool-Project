using System;
using System.Drawing;
using System.Windows.Forms;

namespace MapEditorApp
{
    public partial class UploadBox : Form
    {
        private string path;
        private bool validData;
        private const int CP_NOCLOSE_BUTTON = 0x200;

        public UploadBox()
        {
            InitializeComponent();
            validData = false;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        //Sets pictureBoxPreview to show the selected file
        private void ShowImage()
        {
            pictureBoxPreview.BackgroundImage = null;
            pictureBoxPreview.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBoxPreview.Image = Image.FromFile(path);
        }

        //Return the folder containing example images, else
        private string GetImageDirectory()
        {
            string Dir = System.IO.Directory.GetCurrentDirectory();
            string TextToFind = "bin\\";
            int index = Dir.LastIndexOf(TextToFind);

            if (index > 0)
                return Dir.Substring(0, index + TextToFind.Length) + "Sprites and Images";
            else
                return Dir;
        }


        private void ButtonUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                Filter = "Image Files|*.BMP;*.GIF;*.JPG;*.JPEG;*.PNG|All files (*.*)|*.*",
                InitialDirectory = GetImageDirectory()
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.CheckFileExists == false) { return; }

                path = dlg.FileName;
                validData = true;

                ShowImage();
            }
        }

        private void ButtonConfirmSelection_Click(object sender, EventArgs e)
        {
            if (validData == false) { return; }

            if (Owner.GetType() == typeof(ImageSelection))
                (Owner as ImageSelection).OnUploadBoxClose(Image.FromFile(path));
            else if(Owner.GetType() == typeof(MapTools))
            {
                (Owner as MapTools).AddItem(new Bitmap(Image.FromFile(path)));
                (Owner as MapTools).uploadBox = null;
            }

            Close();
        }

        private void UploadBox_DragEnter(object sender, DragEventArgs e)
        {
            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                Array data = (e.Data).GetData("FileName") as Array;

                if (data != null && data.Length == 1 && data.GetValue(0) is String)
                {
                    string type = System.IO.Path.GetExtension(((string[])data)[0]).ToLower();

                    if (type == ".jpg" || type == ".png" || type == ".bmp")
                    {
                        validData = true;
                        e.Effect = DragDropEffects.Copy;
                    }
                }
            }
            else
            {
                validData = false;
                e.Effect = DragDropEffects.None;
            }
        }

        private void UploadBox_DragDrop(object sender, DragEventArgs e)
        {
            if (validData == false) { return; }

            path = ((string[])((e.Data).GetData("FileName") as Array))[0];
            ShowImage();
        }
    }
}
