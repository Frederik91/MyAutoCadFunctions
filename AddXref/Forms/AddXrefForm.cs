using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XrefManager.Forms
{
    public partial class AddXrefForm : Form
    {
        public string xrefFile { get; set; }
        public List<string> AddXrefDrawingList { get; set; }
        public List<string> UnloadXrefDrawingList { get; set; }
        public List<string> DetachXrefDrawingList { get; set; }

        public AddXrefForm()
        {
            InitializeComponent();
        }

        private void AddXrefForm_Load(object sender, EventArgs e)
        {
            Visible = true;
        }

        private void AddxRefBrowse_button_Click(object sender, EventArgs e)
        {
            var UX = new UnloadXref();

            xrefFile = UX.getFileToXref();

            AddXref_textBox.Text = xrefFile;
        }

        private void AddXrefBrowseDrawings_button_Click(object sender, EventArgs e)
        {
            var UX = new UnloadXref();
            AddXrefDrawingList = UX.getDrawingList();
            AddXref_listBox.DataSource = AddXrefDrawingList;
        }

        private void AddXrefStart_button_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(xrefFile) || AddXrefDrawingList.Count == 0)
            {
                DialogResult = DialogResult.None;
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
          
            Close();
        }

        private void UnloadXrefBrowse_button_Click(object sender, EventArgs e)
        {
            var UX = new UnloadXref();
            UnloadXrefDrawingList = UX.getDrawingList();
            UnloadXref_listBox.DataSource = UnloadXrefDrawingList;
        }

        private void UnloadXrefStart_button_Click(object sender, EventArgs e)
        {
            if (UnloadXrefDrawingList.Count == 0)
            {
                DialogResult = DialogResult.None;
            }
            else
            {
                DialogResult = DialogResult.OK;
            }

            Close();
        }

        public void SetTab(int index)
        {
            TabControl.SelectTab(index);
        }

        private void DetachXrefBrowse_button_Click(object sender, EventArgs e)
        {
            var UX = new UnloadXref();
            DetachXrefDrawingList = UX.getDrawingList();
            DetachXref_listBox.DataSource = DetachXrefDrawingList;
        }

        private void DetachXrefStart_button_Click(object sender, EventArgs e)
        {
            if (DetachXrefDrawingList.Count == 0)
            {
                DialogResult = DialogResult.None;
            }
            else
            {
                DialogResult = DialogResult.OK;
            }

            Close();
        }
    }
}
