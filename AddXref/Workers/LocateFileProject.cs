using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrefManager.Workers
{
    public class LocateFileProject
    {
        public bool FileExists(string rootpath, string filename)
        {
            var replaceString = @"\\cowi.net\projects";

            var adjustedFilename = filename.Replace(replaceString, "O:");
            var adjustedRootpath = rootpath.Replace(replaceString, "O:");

            if (adjustedFilename.Contains(adjustedRootpath))
            {
                return true;
            }
            return false;
        }
    }
}
