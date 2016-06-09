using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestProj
{
    public class Program
    {
        static void Main(string[] args)
        {
        }

        public void test()
        {
            var xRefFiles = getFilesToXrefMH2();
            if (xRefFiles.Count == 0 || xRefFiles == null)
            {
                return;
            }

            var DrawingList = getDrawingList();
            if (DrawingList.Count == 0 || DrawingList == null)
            {
                return;
            }


            foreach (var drawing in DrawingList)
            {
                var xRefFile = "";
                var drawingFloor = drawing.Split('-')[2];
                foreach (var file in xRefFiles)
                {
                    var fileName = Path.GetFileNameWithoutExtension(file);
                    var fileFloor = fileName.Substring(1, 2);

                    if (fileFloor == drawingFloor)
                    {
                        xRefFile = file;
                        break;
                    }
                }
                if (xRefFile == "")
                {
                    continue;
                }
            }
        }

        private List<string> getFilesToXrefMH2()
        {
            var FD = new OpenFileDialog();

            FD.Filter = "AutoCAD Files | *.dwg";
            FD.Multiselect = true;
            FD.ShowDialog();

            return FD.FileNames.ToList();
        }

        private List<string> getDrawingList()
        {
            var FD = new OpenFileDialog();

            FD.Filter = "AutoCAD Files | *.dwg";
            FD.Multiselect = true;
            FD.ShowDialog();


            return FD.FileNames.ToList();
        }

    }
}
