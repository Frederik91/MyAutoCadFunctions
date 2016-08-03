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
    class WriteXml
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
    }
}
