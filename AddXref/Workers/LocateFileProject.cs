using System.IO;

namespace XrefManager.Workers
{
    public class LocateFileProject
    {
        public bool FileExists(string rootpath, string filename)
        {
            var replaceString = @"\\cowi.net\projects".ToUpper();
            rootpath = rootpath.ToUpper();
            filename = filename.ToUpper();

            var adjustedFilename = filename.Replace(replaceString, "O:");
            var adjustedRootpath = rootpath.Replace(replaceString, "O:");

            if (adjustedFilename.Contains(adjustedRootpath))
            {
                return true;
            }
            return false;
        }

        public string returnConfigFilePath()
        {
            var doc = Autodesk.AutoCAD.ApplicationServices.Core.Application.DocumentManager.MdiActiveDocument;
            var configPath = string.Empty;
            var reader = new ReadXml();
            var projectDataList = reader.readProjectXml();

            foreach (var project in projectDataList)
            {
                if (FileExists(project.RootPath, doc.Name))
                {
                    configPath = project.ConfigPath;
                }
            }

            if (string.IsNullOrEmpty(configPath) || !File.Exists(configPath))
            {
               configPath = string.Empty;
            }
            return configPath;
        }
       
    }
}
