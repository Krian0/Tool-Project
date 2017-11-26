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
    public partial class MapEditorParent : Form
    {
        Form tool;
        Form editor;
        Form selector;

        public MapEditorParent()
        {
            InitializeComponent();

            tool = new MapTools(this)
            {
                MdiParent = this,
                TopLevel = false,
                AutoScroll = true,
                Dock = DockStyle.Fill
            };
            panelTools.Controls.Add(tool);
            tool.Show();

            editor = new MapEditor(tool as MapTools)
            {
                MdiParent = this,
                TopLevel = false,
                AutoScroll = true,
                Dock = DockStyle.Fill,
            };
            editor.Dock = DockStyle.Fill;
            AddNewTab(editor);
            editor.Show();

            selector = new ImageSelection(tool as MapTools)
            {
                MdiParent = Parent as MapEditorParent,
                TopLevel = false,
                AutoScroll = true,
                Dock = DockStyle.Fill
            };
            AddNewTab(selector);
            selector.Show();

            (tool as MapTools).SetEditor(editor as MapEditor);
            tabControl.SelectedTab = tabControl.TabPages[0];
        }

        public void AddNewTab(Form form)
        {
            TabPage tab = new TabPage(form.Text);

            form.TopLevel = false;
            form.Parent = tab;
            form.Visible = true;

            tabControl.TabPages.Add(tab);
            form.Location = new Point((tab.Width - form.Width) / 2, (tab.Height - form.Height) / 2);

            tabControl.SelectedTab = tab;
        }

        private void OpenFile(object sender, EventArgs e)
        {
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            //openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            //if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            //{
            //    string FileName = openFileDialog.FileName;
            //}
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            //saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            //if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            //{
            //    string FileName = saveFileDialog.FileName;
            //}
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
                childForm.Close();
        }

        private void ToolErase_Click(object sender, EventArgs e)
        {
            (editor as MapEditor).eraseTiles = !(editor as MapEditor).eraseTiles;
            (editor as MapEditor).copyTiles = false;
            (editor as MapEditor).fillTiles = false;

            toolCopy.Checked = false;
            toolFill.Checked = false;
        }

        private void ToolCopy_Click(object sender, EventArgs e)
        {
            (editor as MapEditor).eraseTiles = false;
            (editor as MapEditor).copyTiles = !(editor as MapEditor).copyTiles;
            (editor as MapEditor).fillTiles = false;

            toolErase.Checked = false;
            toolFill.Checked = false;
        }

        private void ToolFill_Click(object sender, EventArgs e)
        {
            (editor as MapEditor).eraseTiles = false;
            (editor as MapEditor).copyTiles = false;
            (editor as MapEditor).fillTiles = !(editor as MapEditor).fillTiles;

            toolErase.Checked = false;
            toolCopy.Checked = false;
        }


        private void MapEditorParent_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized && editor != null)
                tabControl.Width = Screen.GetWorkingArea(this).Width - (tool.Width + 4);

            if (WindowState == FormWindowState.Normal)
                tabControl.Width = Width - (tool.Width + 22);
        }
    }
}
