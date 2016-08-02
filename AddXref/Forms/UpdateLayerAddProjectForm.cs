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
    public partial class UpdateLayerAddProjectForm : Form
    {
        public UpdateLayerAddProjectForm()
        {
            InitializeComponent();
        }

        private void ConfigPath_button_Click(object sender, EventArgs e)
        {
            var ConfigPathDialog = new OpenFileDialog();
            ConfigPathDialog.DefaultExt = "Text Files | *.txt";
            ConfigPathDialog.CheckFileExists = true;
            ConfigPathDialog.ShowDialog();
            configPath = ConfigPathDialog.FileName;
        }

        private void RootFolder_button_Click(object sender, EventArgs e)
        {
            var rootFolderDialog = new FolderBrowserDialog();
            rootFolderDialog.ShowDialog();
            rootFolder = rootFolderDialog.SelectedPath;
        }

        public string ProjectName
        {
            get { return ProjectName_textBox.Text; }
            set { ProjectName_textBox.Text = value; }
        }

        public string configPath
        {
            get { return ConfigPath_textBox.Text; }
            set { ConfigPath_textBox.Text = value; }
        }

        public string rootFolder
        {
            get { return RootFolder_listBox.Text; }
            set { RootFolder_listBox.Text = value; }
        }

        private void AddProject_button_Click(object sender, EventArgs e)
        {

        }
    }
}
