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
        public List<string> PurgeDrawingList { get; set; }
        public List<string> AttributeDrawingList { get; set; }
        public BlockData BlockData { get; set; }

        AppSettings attSettings = AppSettings.Default;


        public PurgeAttributeForm()
        {
            InitializeComponent();

            AttBlockname = attSettings.BlockName;
            LinkattAttributeName = attSettings.LinkAttributeName;
            LinkAttValue = attSettings.LinkValue;
            ChangeAttValue = attSettings.ChangeValue;            

            BlockData = new BlockData();
        }

        private void PurgeBrowse_button_Click(object sender, EventArgs e)
        {
            var PU = new PurgeDrawings();
            PurgeDrawingList = PU.getDrawingsToPurge();
            Purge_listBox.DataSource = PurgeDrawingList;
        }


        public void SetTabIndex(int index)
        {
            tabControl.SelectedIndex = index;
        }

        private void PurgeStart_button_Click(object sender, EventArgs e)
        {
            if (PurgeDrawingList.Count == 0)
            {
                DialogResult = DialogResult.None;
            }
            else
            {
                DialogResult = DialogResult.OK;
            }

            Close();
        }

        private void AttributeStart_button_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(AttBlockname) || string.IsNullOrEmpty(LinkattAttributeName) || string.IsNullOrEmpty(LinkAttValue) || string.IsNullOrEmpty(ChangeAttValue) || AttributeDrawingList.Count == 0)
            {
                DialogResult = DialogResult.None;
            }
            else
            {
                DialogResult = DialogResult.OK;

                attSettings.BlockName = AttBlockname;
                attSettings.LinkAttributeName = LinkattAttributeName;
                attSettings.LinkValue = LinkAttValue;
                attSettings.ChangeValue = ChangeAttValue;

                attSettings.ChangeAttributeName = ChangeattAttributeName;

                attSettings.Save();
            }

            Close();
        }


        public string AttBlockname
        {
            get { return attributeBlockname_textBox.Text; }
            set { attributeBlockname_textBox.Text = value; }
        }

        public string LinkattAttributeName
        {
            get { return attributeLinkAttributeName_textBox.Text; }
            set { attributeLinkAttributeName_textBox.Text = value; }
        }

        public string LinkAttValue
        {
            get { return LinkAttributeValue_textBox.Text; }
            set { LinkAttributeValue_textBox.Text = value; }
        }

        public string ChangeattAttributeName
        {
            get { return ChangeAttributeName_textBox.Text; }
            set { ChangeAttributeName_textBox.Text = value; }
        }

        public string ChangeAttValue
        {
            get { return ChangeAttributeValue_textBox.Text; }
            set { ChangeAttributeValue_textBox.Text = value; }
        }

        private void AttributeBrowse_button_Click(object sender, EventArgs e)
        {
            var UX = new UnloadXref();
            AttributeDrawingList = UX.getDrawingList();
            attributeDrawingList_listBox.DataSource = AttributeDrawingList;
        }

        private void SelectBlock_button_Click(object sender, EventArgs e)
        {

        }

        private void LinkAttributes_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LinkattAttributeName = BlockData.AttNameAndvalue[LinkAttributes_comboBox.SelectedIndex].attName;
            LinkAttValue = BlockData.AttNameAndvalue[LinkAttributes_comboBox.SelectedIndex].attValue;
        }

        public void SetValueFromInput()
        {
            AttBlockname = BlockData.BlockName;

            var attributeNames = new List<string>();

            foreach (var att in BlockData.AttNameAndvalue)
            {
                LinkAttributes_comboBox.Items.Add(att.attName);
                ChangeAttribute_comboBox.Items.Add(att.attName);
            }
        }

        private void SelectBlock_button_Click_1(object sender, EventArgs e)
        {
            var RV = new ReplaceValue();
            RV.GetBlockData(this);
        }

        private void AttributeLinkAttributeName_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void LinkattributeOldValue_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ChangeAttribute_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeattAttributeName = BlockData.AttNameAndvalue[ChangeAttribute_comboBox.SelectedIndex].attName;
            ChangeAttValue = BlockData.AttNameAndvalue[ChangeAttribute_comboBox.SelectedIndex].attValue;
        }

        private void ChangeAttributeName_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ChangeAttributeValue_textBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
