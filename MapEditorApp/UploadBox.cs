using System;
using System.Drawing;
using System.Windows.Forms;

namespace MapEditorApp
{
    public partial class UploadBox : Form
    {
        private MapTools t;

        private string path;
        private bool validData = false;
        private bool validExtension = false;
        private const int CP_NOCLOSE_BUTTON = 0x200;

        public UploadBox(MapTools Tools)
        {
            InitializeComponent();
            t = Tools;
            pictureBoxPreview.SizeMode = PictureBoxSizeMode.AutoSize;
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
            pictureBoxPreview.Image = Image.FromFile(path);
        }

        //Return the folder containing example images if it exists where it is supposed to be, else return current directory
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
                if (dlg.CheckFileExists == false)
                {
                    validData = false;
                    return;
                }

                path = dlg.FileName;
                validData = true;

                ShowImage();
            }
        }

        private void ButtonConfirmSelection_Click(object sender, EventArgs e)
        {
            if (validData == false) { return; }

            t.displayImage = new Bitmap(Image.FromFile(path));
            t.displayBase = new Bitmap(t.displayImage.Width, t.displayImage.Height);
            t.uploadBox = null;

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
                        validExtension = true;
                        e.Effect = DragDropEffects.Copy;
                    }
                }
            }
            else
            {
                validExtension = false;
                e.Effect = DragDropEffects.None;
            }
        }

        private void UploadBox_DragDrop(object sender, DragEventArgs e)
        {
            if (validExtension == false) { return; }

            path = ((string[])((e.Data).GetData("FileName") as Array))[0];
            ShowImage();
            validData = true;
        }
    }
}
