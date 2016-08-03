using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using XrefManager.Models;

namespace XrefManager.Workers
{
    public class ReadXml
    {
        public List<ProjectData> readProjectXml()
        {
            var projectDataList = new List<ProjectData>();
            var settings = AppSettings.Default;
            var xmlReader = new ReadXml();

            if (xmlReader.checkXmlPath())
            {
                try
                {
                    var xEle  = XElement.Load(settings.ProjectsXmlPath);

                    foreach (var xProj in xEle.Elements("Project"))
                    {
                        var projectData = new ProjectData();

                        projectData.ProjectName = xProj.Element("ProjectName").Value.ToString();
                        projectData.ConfigPath = xProj.Element("ConfigPath").Value.ToString();
                        projectData.RootPath = xProj.Element("RootPath").Value.ToString();

                        projectDataList.Add(projectData);
                    }
                }

                catch (Exception)
                {
                }                
            }
            return projectDataList;
        }
        public bool checkXmlPath()
        {
            var appSettings = AppSettings.Default;

            var createNewProjectFile = false;

            if (File.Exists(appSettings.ProjectsXmlPath))
            {
                return true;
            }
            else
            {
                var res = System.Windows.Forms.MessageBox.Show("Project file not created or has been moved. Click \"Yes\" to create a new one and \"No\" to select a existing project file", "Select or create a project file", System.Windows.Forms.MessageBoxButtons.YesNo);
                if (res == System.Windows.Forms.DialogResult.Yes)
                {
                    switch (res)
                    {
                        case (System.Windows.Forms.DialogResult.Yes):
                            return browseNewFileFolder(appSettings);
                        case (System.Windows.Forms.DialogResult.No):
                            return selectExistingProjectFile(appSettings);
                    }
                }
            }

            switch (createNewProjectFile)
            {
                case (true):
                    return browseNewFileFolder(appSettings);
                case (false):
                    return selectExistingProjectFile(appSettings);
            }
            return false;

        }
        private bool browseNewFileFolder(AppSettings appSettings)
        {
            var res = System.Windows.Forms.DialogResult.Yes;
            var browser = new System.Windows.Forms.FolderBrowserDialog();
            var projectFileOK = false;

            while (!projectFileOK && res == System.Windows.Forms.DialogResult.Yes)
            {
                browser.Description = "Specify a folder to store the project file";
                browser.ShowDialog();

                if (!Directory.Exists(browser.SelectedPath) || string.IsNullOrEmpty(browser.SelectedPath))
                {
                    res = System.Windows.Forms.MessageBox.Show("Selected path is invalid, do you want to specify a new one?", "Error", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question);
                    if (res == System.Windows.Forms.DialogResult.No)
                    {
                        return false;
                    }
                }
                else
                {
                    projectFileOK = true;
                }
            }

            var fileName = browser.SelectedPath + "\\Projects.xml";
            var file = File.Create(fileName);
            file.Close();
            appSettings.ProjectsXmlPath = fileName;
            appSettings.Save();
            return true;
        }

        private bool selectExistingProjectFile(AppSettings appSettings)
        {
            var res = System.Windows.Forms.DialogResult.Yes;
            var dialog = new OpenFileDialog();

            while (!dialog.CheckFileExists || res == System.Windows.Forms.DialogResult.Yes)
            {
                dialog.Filter = "XML File | *.xml";
                dialog.ShowDialog();
                res = System.Windows.Forms.MessageBox.Show("Selected file is invalid, do you want to specify a new one?", "Error", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question);
                if (res == System.Windows.Forms.DialogResult.No)
                {
                    return false;
                }
            }

            appSettings.ProjectsXmlPath = dialog.FileName;
            appSettings.Save();
            return true;
        }
    }
}
