using LayerConfigEditor;
using System;
using System.IO;
using System.Windows.Forms;
using XrefManager.Functions;
using XrefManager.Models;
using XrefManager.Workers;

namespace XrefManager.Forms
{
    public partial class UpdateLayerAddProjectForm : Form
    {
        public ProjectData projectData { get; set; }

        public UpdateLayerAddProjectForm()
        {
            InitializeComponent();
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
            if (!string.IsNullOrEmpty(ProjectName) && File.Exists(configPath) && Directory.Exists(rootFolder))
            {
                var projData = new ProjectData();
                projData.ProjectName = ProjectName;
                projData.ConfigPath = configPath;
                projData.RootPath = rootFolder;
                projectData = projData;
                Close();
                return;
            }
            var res = MessageBox.Show("The data you entered contains errors, please check that all file paths entered exists.\nDo you want to try again?", "Warning", MessageBoxButtons.YesNo);
            if (res == DialogResult.No)
            {
                projectData = null;
                Close();
            }
        }

        private void openConfigTool_button_Click(object sender, EventArgs e)
        {
            var openConfigTool = new OpenConfigTool();
            openConfigTool.openConfigTool();
            configPath = openConfigTool.configPath;          
        }
    }
}
