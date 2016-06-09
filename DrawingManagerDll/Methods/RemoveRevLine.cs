using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using DrawingManagerDll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingManagerDll.Methods
{
    class RemoveRevLine
    {

        [CommandMethod("REMOVEREVLINE")]
        public void REMOVEREVLINE(Settings settings, DrawingData drawingData, string RevToDel)
        {
            string attbValue = "";
            int RevIndex = 1;
            var AM = new AttributeManager();
            List<int> revIndexToMove = new List<int>();
            bool revFound = false;


            //Avgjør revisjonsindex i gjeldende tegning.
            for (int i = 1; i < 7; i++)
            {

                if (AM.CHECKATTRIBUTEVALUE(settings.RevBlockName.ToUpper(), "REV" + i) == RevToDel)
                {
                    RevIndex = i;
                    revFound = true;
                    break;
                }
            }

            //Fjerner revisjonslinjen hvis den ble funnet.
            if (revFound)
            {
                foreach (var attributeName in settings.PropertyNameList)
                {
                    AM.UPDATEATTRIBUTESINDATABASE(
                        settings.RevBlockName.ToUpper(),
                        attributeName + RevIndex,
                        attbValue
                        );
                }
            }
        }

    }
}
