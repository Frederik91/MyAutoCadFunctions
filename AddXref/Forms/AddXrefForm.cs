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
        public List<string> drawingList { get; set; }

        public AddXrefForm()
        {
            InitializeComponent();
        }

        private void AddXrefForm_Load(object sender, EventArgs e)
        {
            Visible = true;        }

        private void xRef_Browse_button_Click(object sender, EventArgs e)
        {
            var UX = new UnloadXref();

            xrefFile = UX.getFileToXref();

            AddXref_textBox.Text = xrefFile;
        }

        private void Browse_drawings_button_Click(object sender, EventArgs e)
        {
            var UX = new UnloadXref();
            drawingList = UX.getDrawingList();
            AddXref_listBox.DataSource = drawingList;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(xrefFile) || drawingList.Count == 0)
            {
                DialogResult = DialogResult.None;
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
          
            Close();
        }

        private void BrowseDrawings_button_Click(object sender, EventArgs e)
        {

        }

        private void AddXref_textBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
