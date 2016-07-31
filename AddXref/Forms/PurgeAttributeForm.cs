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
    public partial class PurgeAttributeForm : Form
    {
        public List<string> purgeDrawingList { get; set; }
        public List<string> attributeDrawingList { get; set; }

        public PurgeAttributeForm()
        {
            InitializeComponent();
        }

        private void PurgeBrowse_button_Click(object sender, EventArgs e)
        {
            var PU = new PurgeDrawings();
            purgeDrawingList = PU.getDrawingsToPurge();
            Purge_listBox.DataSource = purgeDrawingList;
        }


        public void SetTabIndex(int index)
        {
            tabControl.SelectedIndex = index;
        }

        private void PurgeStart_button_Click(object sender, EventArgs e)
        {
            if (purgeDrawingList.Count == 0)
            {
                DialogResult = DialogResult.None;
            }
            else
            {
                DialogResult = DialogResult.OK;
            }

            Close();
        }

        private void attributeStart_button_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(attBlockname) || string.IsNullOrEmpty(attAttributeName) || string.IsNullOrEmpty(attOldValue) || string.IsNullOrEmpty(attNewValue) || attributeDrawingList.Count == 0)
            {
                DialogResult = DialogResult.None;
            }
            else
            {
                DialogResult = DialogResult.OK;
            }

            Close();
        }

        public string attBlockname
        {
            get { return attributeBlockname_textBox.Text; }
            set { attributeBlockname_textBox.Text = value; }
        }

        public string attAttributeName
        {
            get { return attributeAttributeName_textBox.Text; }
            set { attributeAttributeName_textBox.Text = value; }
        }

        public string attOldValue
        {
            get { return attributeOldValue_textBox.Text; }
            set { attributeOldValue_textBox.Text = value; }
        }

        public string attNewValue
        {
            get { return attributeNewValue_textBox.Text; }
            set { attributeNewValue_textBox.Text = value; }
        }

        private void attributeBrowse_button_Click(object sender, EventArgs e)
        {
            var UX = new UnloadXref();
            attributeDrawingList = UX.getDrawingList();
            attributeDrawingList_listBox.DataSource = attributeDrawingList;
        }
    }
}
