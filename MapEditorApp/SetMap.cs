using System;
using System.Windows.Forms;

namespace MapEditorApp
{
    public partial class SetMap : Form
    {
        MapTools t;
        private const int CP_NOCLOSE_BUTTON = 0x200;

        public SetMap(MapTools tools)
        {
            InitializeComponent();
            t = tools;
        }

        private void ButtonConfirm_Click(object sender, EventArgs e)
        {

            t.MapSetup((int)MWidth.Value * (int)GWidth.Value, (int)MHeight.Value * (int)GHeight.Value, (int)GWidth.Value, (int)GHeight.Value);
            t.setMap = null;
            Close();
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
    }
}
