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
    public partial class UpdateLayerForm : Form
    {
        private List<ProjectData> projectDataList = new List<ProjectData>();
        public List<string> DrawingList = new List<string>();

        public string configPath { get; set; }

        public UpdateLayerForm()
        {
            InitializeComponent();

            var readXml = new Workers.ReadXml();
            projectDataList = readXml.readProjectXml();
            Projects_comboBox.DataSource = createComboboxList();
        }

        private void AddProject_button_Click(object sender, EventArgs e)
        {
            using (var AddProjectForm = new UpdateLayerAddProjectForm())
            {
                AddProjectForm.ProjectDataList = projectDataList;
                AddProjectForm.ShowDialog();
                projectDataList = AddProjectForm.ProjectDataList;
            }
            var writeXml = new Workers.WriteXml();
            writeXml.writeProjectXml(projectDataList);
            Projects_comboBox.DataSource = createComboboxList();
        }

        private List<string> createComboboxList()
        {
            var projectList = new List<string>();

            foreach (var project in projectDataList)
            {
                projectList.Add(project.ProjectName);
            }
            return projectList;
        }

        private void BrowseDrawings_button_Click(object sender, EventArgs e)
        {
            var UX = new UnloadXref();
            Drawings_listBox.DataSource = DrawingList =  UX.getDrawingList();
        }

        private void StartLayerUpdate_button_Click(object sender, EventArgs e)
        {
            if (projectDataList.Count > 0 && Projects_comboBox.SelectedIndex + 1 <= projectDataList.Count)
            {
                if (DrawingList.Count > 0)
                {
                    configPath = projectDataList[Projects_comboBox.SelectedIndex].ConfigPath;
                    Close();
                }
                else
                {
                    MessageBox.Show("No drawings selected");
                }
            }
            else
            {
                MessageBox.Show("No project selected");
            }
        }

        private void UpdateLayerForm_Load(object sender, EventArgs e)
        {
            Visible = true;
        }
    }
}
