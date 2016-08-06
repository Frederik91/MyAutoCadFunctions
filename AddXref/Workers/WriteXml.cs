using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using XrefManager.Models;

namespace XrefManager.Workers
{
    public class WriteXml
    {
        public void writeProjectXml(List<ProjectData> projectDataList)
        {
            var settings = AppSettings.Default;

            var xDoc = new XDocument(mapProjectXml(projectDataList));

            xDoc.Save(settings.ProjectsXmlPath);            
        }

        private XElement mapProjectXml(List<ProjectData> projectDataList) 
        {
            var root = new XElement("Projects");

            foreach (var project in projectDataList)
            {
                var ProjectElement = new XElement("Project", new XElement("ProjectName", project.ProjectName), new XElement("ConfigPath", project.ConfigPath), new XElement("RootPath", project.RootPath));

                root.Add(ProjectElement);
            }

            return root;
        }

        public void UpdateConfigPath(string newPath)
        {
            var doc = Autodesk.AutoCAD.ApplicationServices.Core.Application.DocumentManager.MdiActiveDocument;
            var reader = new ReadXml();
            var projectDataList = reader.readProjectXml();
            var locateProjectFile = new LocateFileProject();

            foreach (var project in projectDataList)
            {
                if (locateProjectFile.FileExists(project.RootPath, doc.Name))
                {
                    project.ConfigPath = newPath;
                }
            }
            writeProjectXml(projectDataList);
        }
    }
}
