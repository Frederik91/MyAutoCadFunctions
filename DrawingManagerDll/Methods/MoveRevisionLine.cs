using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Runtime;
using DrawingManagerDll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingManagerDll.Methods
{
    class MoveRevisionLine
    {

        [CommandMethod("MOVEREVLINE")]
        public void MOVEREVLINE(Settings settings, DrawingData drawingData, string RevisionToMove, string Direction, bool MoveRemaining)
        {

            int RevIndex = 1;
            var AM = new AttributeManager();
            List<int> revIndexToMove = new List<int>();

            //Avgjør revisjonsindex i gjeldende tegning.
            for (int i = 1; i < 7; i++)
            {

                if (AM.CHECKATTRIBUTEVALUE(settings.RevBlockName.ToUpper(), "REV" + i) == RevisionToMove)
                {
                    RevIndex = i;
                    break;
                }
            }


            switch (Direction)
            {
                case ("Up"):
                    //Sjekker at det ikke er en revisjon rett over revisjonen som skal flyttes, samt at den ikke er øverst på listen.
                    if (AM.CHECKATTRIBUTEVALUE(settings.RevBlockName.ToUpper(), "REV" + (RevIndex + 1).ToString()) == "" && RevIndex < 7)
                    {
                        switch (MoveRemaining)
                        {
                            case true:
                                //Flytter gjeldende og alle revisjoner under opp.

                                foreach (var attrib in settings.PropertyNameList)
                                {

                                }

                                break;

                            case false:
                                //Flytter kun én revisjon opp
                                var i = 0;

                                foreach (var attribute in settings.PropertyNameList)
                                {
                                    if (i > 9)
                                    {
                                        AM.UPDATEATTRIBUTESINDATABASE(
                                            settings.RevBlockName.ToUpper(),
                                            attribute + (RevIndex + 1).ToString(),
                                            AM.CHECKATTRIBUTEVALUE(settings.RevBlockName.ToUpper(), attribute + RevIndex)
                                            );

                                        AM.UPDATEATTRIBUTESINDATABASE(
                                            settings.RevBlockName.ToUpper(),
                                            attribute + RevIndex,
                                            ""
                                            );
                                    }
                                    i++;
                                }
                                break;
                        }
                    }
                    else
                    {
                        Application.ShowAlertDialog("Unable to move revision up, either there is another revision above, or its already at the top");
                        return;
                    }
                    break;

                case ("Down"):

                    //Sjekker at det ikke er en revisjon rett under revisjonen som skal flyttes, samt at den ikke er neders på listen.
                    if (AM.CHECKATTRIBUTEVALUE(settings.RevBlockName.ToUpper(), "REV" + (RevIndex + -1).ToString()) == "" && RevIndex > 1)
                    {
                        switch (MoveRemaining)
                        {
                            case true:
                                //Flytter gjeldende og alle revisjoner over ned.


                                break;

                            case false:
                                //Flytter kun én revisjon ned

                                var i = 0;

                                foreach (var attribute in settings.PropertyNameList)
                                {
                                    if (i > 9)
                                    {
                                        AM.UPDATEATTRIBUTESINDATABASE(
                                            settings.RevBlockName.ToUpper(),
                                            attribute + RevIndex,
                                            AM.CHECKATTRIBUTEVALUE(settings.RevBlockName.ToUpper(), attribute + (RevIndex + 1).ToString())
                                            );

                                        AM.UPDATEATTRIBUTESINDATABASE(
                                            settings.RevBlockName.ToUpper(),
                                            attribute + (RevIndex + 1).ToString(),
                                            ""
                                            );
                                    }
                                    i++;
                                }
                                break;
                        }
                    }
                    else
                    {
                        Application.ShowAlertDialog("Unable to move revision down, either there is another revision bellow, or its already at the bottom");
                        return;
                    }

                    break;

            }

            //revIndexToMove = checkForOtherRevisions();

            //Flytter eventuelle overstående revisjoner ned.
            if (revIndexToMove.Count > 0)
            {
                foreach (var revIndex in revIndexToMove)
                {
                    foreach (var attributeName in settings.PropertyNameList)
                    {
                        AM.UPDATEATTRIBUTESINDATABASE(
                            settings.RevBlockName.ToUpper(),
                            attributeName + (revIndex - 1).ToString(),
                            AM.CHECKATTRIBUTEVALUE(settings.RevBlockName.ToUpper(), attributeName + revIndex)
                            );

                        AM.UPDATEATTRIBUTESINDATABASE(
                            settings.RevBlockName.ToUpper(),
                            attributeName + (revIndex).ToString(),
                            ""
                            );
                    }
                }
            }

        }

        //private List<int> checkForOtherRevisions(int x, Settings settings)
        //{
        //    var AM = new AttributeManager();
        //    List<int> revIndexToMove = new List<int>();

        //    for (int i = x; i < 7; i++)
        //    {
        //        if (AM.CHECKATTRIBUTEVALUE(settings.RevBlockName.ToUpper(), "REV" + i) != "")
        //        {
        //            revIndexToMove.Add(i);
        //        }
        //    }
        //    return revIndexToMove;
        //}
    }
}
