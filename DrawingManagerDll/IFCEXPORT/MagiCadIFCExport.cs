using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MAGICOMSRVLib;
using Microsoft.VisualBasic;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Interop;
using System.Runtime.InteropServices;
using System.IO;
using DrawingManagerDll.Methods;
using System.Configuration;
using System.Xml.Linq;
using System.Collections.ObjectModel;
using DrawingManagerDll.Models;

namespace DrawingManagerDll.MAGIIFC
{
    public class MagiCadIFCExport
    {
        private Document acDoc;
        private Database acCurDb;
        private DrawingManager DM = new DrawingManager();

        public MagiCadIFCExport()
        {
            acDoc = Application.DocumentManager.MdiActiveDocument;
            acCurDb = acDoc.Database;
        }

        [CommandMethod("IFCEXPORTALLDWG")]
        public void IFCEXPORT()
        {
            string StoredProjectsFolder = "C:\\IFCEXPORT\\XML";
            string SelectedProject = "MH2";
            string SelectedProjectPath = getSelectedProjectPath(SelectedProject, Directory.GetFiles(StoredProjectsFolder));
            var ProjectInfo = GetprojectInfo(SelectedProjectPath);
            CopyDetails IFCInfo = GetIFCFileData(ProjectInfo);

            foreach (var StartFile in ProjectInfo.StartFiles)
            {

                foreach (var Folder in ProjectInfo.Folders)
                {
                    if (Folder.Discipline == StartFile.Discipline)
                    {
                        copyProject(ProjectInfo, Folder.Export, IFCInfo);
                    }
                }

                DM.OPENDRAWING(StartFile.Path);
                DM.ACTIVATEDRAWING(StartFile.Path);
                acDoc = Application.DocumentManager.MdiActiveDocument;
                
                foreach (var Folder in ProjectInfo.Folders)
                {
                    if (Folder.Discipline == StartFile.Discipline)
                    {
                        acDoc.Editor.Command(new object[] { "._circle", "2,2,0", 4 });
                        acDoc.Editor.Command(new object[] { "_-MAGIIFCEXPORT", Folder.Export });
                        //acDoc.SendStringToExecute("-MAGIIFC" + " ", true, false, true);
                        //acDoc.SendStringToExecute(Folder.Export + "\n", true, false, true);
                        FileInfo file = new FileInfo(IFCInfo.To + "\\" + Folder.Export + ".ifc");
                        file.CopyTo(Path.GetDirectoryName(IFCInfo.From) + "\\" + Folder.Export + ".ifc", true);
                        System.Windows.MessageBox.Show(acDoc.Name);
                    }
                }
                DM.CLOSEDRAWING(StartFile.Path);
            }

        }

        public string getSelectedProjectPath(string projectName, string[] AviliableProjects)
        {
            string ProjectPath = "";

            foreach (var Project in AviliableProjects)
            {
                if (Path.GetFileName(Project) == projectName + ".xml")
                {
                    ProjectPath = Project;
                }
            }

            return ProjectPath;
        }

        public IFCProjectInfo GetprojectInfo(string _XMLPath)
        {
            XDocument xDoc = XDocument.Load(_XMLPath);

            var ProjectInfo = new IFCProjectInfo { Files = new List<CopyDetails>(), Folders = new List<CopyDetails>(), StartFiles = new List<StartFile>() };
            var Folders = xDoc.Element("Project").Element("Folders").Elements("Folder");
            var Files = xDoc.Element("Project").Element("Files").Elements("File");
            var StartFiles = xDoc.Element("Project").Element("StartFiles").Elements("StartFile");

            foreach (var Folder in Folders)
            {
                ProjectInfo.Folders.Add(new CopyDetails
                {
                    From = Folder.Attribute("From").Value,
                    To = Folder.Attribute("To").Value,
                    Export = Folder.Attribute("Export").Value,
                    Discipline = Folder.Attribute("Discipline").Value
                });
            }

            foreach (var File in Files)
            {
                ProjectInfo.Files.Add(new CopyDetails
                {
                    From = File.Attribute("From").Value,
                    To = File.Attribute("To").Value,
                    Export = File.Attribute("Export").Value
                });
            }

            foreach (var StartFile in StartFiles)
            {
                ProjectInfo.StartFiles.Add(new StartFile
                {
                    Path = StartFile.Attribute("Path").Value,
                    Discipline = StartFile.Attribute("Discipline").Value
                });
            }

            return ProjectInfo;
        }

        public CopyDetails GetIFCFileData(IFCProjectInfo ProjectInfo)
        {
            CopyDetails currentIFC = new CopyDetails();

            foreach (var File in ProjectInfo.Files)
            {
                if (File.Export == "tomIFC")
                {
                    currentIFC = File;
                }
            }
            return currentIFC;
        }

        public void copyProject(IFCProjectInfo ProjectInfo, string Export, CopyDetails IFCInfo)
        {
            foreach (var Folder in ProjectInfo.Folders)
            {
                if (Folder.Export == Export || Folder.Export == "")
                {
                    string IFCPath = IFCInfo.To + "\\" + Export + ".ifc";

                    //Sjekker om det er en eksisterende ifc og sletter den
                    if (File.Exists(IFCPath))
                    {
                        File.Delete(IFCPath);
                    }

                    //Kopierer inn ny tom.ifc
                    FileInfo file = new FileInfo(IFCInfo.From);
                    file.CopyTo(IFCPath, true);

                    //Kopierer Modellfilene for gjeldende fag
                    DirectoryCopy(Folder.From, Folder.To, true);

                }
            }

            //Kopierer eventuelle enkeltstående filer som f.eks. mep- og QPD-filer. Hvis "Export" attributten står tom skal denne kopieres hver gang.
            foreach (var File in ProjectInfo.Files)
            {
                if (File.Export == Export || File.Export == "")
                {
                    FileInfo file = new FileInfo(File.From);
                    file.CopyTo(File.To, true);
                }
            }
        }

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {

            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, true);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }

    }

}
