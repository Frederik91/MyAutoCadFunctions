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

    public class ChangeAttributes
    {
        [CommandMethod("UPDATEATTRIBUTES")]
        public void UPDATEATTRIBUTES(Settings settings, DrawingData drawingData)
        {
            string attbName = "";
            string attbValue = "";
            int i = 0;

            var AM = new AttributeManager();


            foreach (var attributeName in settings.PropertyNameList)
            {
                attbName = attributeName;
                attbValue = drawingData.PropertyValueList[i];

                //Update TitleBlock
                if (i < settings.StartRevlinje && i >= settings.StartMerkeskilt)
                {                   
                    AM.UPDATEATTRIBUTESINDATABASE(
                        settings.TitleBlockName.ToUpper(),
                        attbName,
                        attbValue
                        );
                }

                //UpdateRevBlock
                if (i >= settings.StartRevlinje)
                {
                    //Avgjør revisjonsindex og plassering
                    int RevIndex = 1;
                    for (int x = 1; x < 7; x++)
                    {

                        if (AM.CHECKATTRIBUTEVALUE(settings.RevBlockName.ToUpper(), "REV" + x) == "" || AM.CHECKATTRIBUTEVALUE(settings.RevBlockName.ToUpper(), "REV" + x) == drawingData.PropertyValueList[settings.StartRevlinje])
                        {
                            RevIndex = x;
                            break;
                        }
                    }

                    AM.UPDATEATTRIBUTESINDATABASE(
                        settings.RevBlockName.ToUpper(),
                        attbName + RevIndex,
                        attbValue
                        );
                }

                i++;
            }
        }

    }
}
