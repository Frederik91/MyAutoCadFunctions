using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XrefManager.Models;

namespace XrefManager.Forms
{
    public partial class PurgeAttributeForm : Form
    {
        public List<string> purgeDrawingList { get; set; }
        public List<string> attributeDrawingList { get; set; }
        public BlockData blockData { get; set; }

        AppSettings attSettings = AppSettings.Default;


        public PurgeAttributeForm()
        {
            InitializeComponent();

            attBlockname = attSettings.BlockName;
            attAttributeName = attSettings.AttributeName;
            attOldValue = attSettings.OldValue;
            attNewValue = attSettings.NewValue;

            blockData = new BlockData();
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

                attSettings.BlockName = attBlockname;
                attSettings.AttributeName = attAttributeName;
                attSettings.OldValue = attOldValue;
                attSettings.NewValue = attNewValue;

                attSettings.Save();
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

        private void SelectBlock_button_Click(object sender, EventArgs e)
        {

        }

        private void Attributes_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            attAttributeName = blockData.AttNameAndvalue[Attributes_comboBox.SelectedIndex].attName;
            attOldValue = blockData.AttNameAndvalue[Attributes_comboBox.SelectedIndex].attValue;
        }

        public void setValueFromInput()
        {
            attBlockname = blockData.BlockName;

            var attributeNames = new List<string>();

            foreach (var att in blockData.AttNameAndvalue)
            {
                Attributes_comboBox.Items.Add(att.attName);
            }
        }

        private void SelectBlock_button_Click_1(object sender, EventArgs e)
        {
            var RV = new ReplaceValue();
            RV.getBlockData(this);
        }
    }
}
