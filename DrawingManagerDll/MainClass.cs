using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.Windows;
using Autodesk.AutoCAD.DatabaseServices;
using DrawingManagerDll.MAGIIFC;

namespace DrawingManagerDll
{
    public class MainClass
    {
        #region Add ribbon

        string SelectedConfigFile = "";

        public MainClass()
        {
        }

        [CommandMethod("DrawingManagerRibbon", CommandFlags.Transparent)]
        public void EnableRibbon()
        {
            RibbonControl ribbon = ComponentManager.Ribbon;
            if (ribbon != null)
            {
                RibbonTab rtab = ribbon.FindTab("TESTME");
                if (rtab != null)
                {
                    ribbon.Tabs.Remove(rtab);
                }
                rtab = new RibbonTab();
                rtab.Title = "Drawing manager";
                rtab.Id = "Drawing manager";
                //Add the Tab
                ribbon.Tabs.Add(rtab);
                addContent(rtab);
            }
        }

        static void addContent(RibbonTab rtab)
        {
            rtab.Panels.Add(AddOnePanel());
        }

        static RibbonPanel AddOnePanel()
        {
            RibbonButton plotThisButton;
            RibbonButton AttChangeButton;
            RibbonButton RemRevLineButton;
            RibbonButton MoveRevLineButton;
            RibbonButton ChangeConfigFileButton;
            RibbonButton TestFunctionButton;
            RibbonPanelSource rps = new RibbonPanelSource();
            rps.Title = "Plotting";
            RibbonPanel rp = new RibbonPanel();
            rp.Source = rps;

            //Create a Command Item that the Dialog Launcher can use,
            // for this test it is just a place holder.
            RibbonButton rci = new RibbonButton();
            //rci.Name = "TestCommand";


            //assign the Command Item to the DialgLauncher which auto-enables
            // the little button at the lower right of a Panel
            rps.DialogLauncher = rci;

            //Add the Button to the Tab
            plotThisButton = new RibbonButton();
            plotThisButton.Name = "Plot";
            plotThisButton.ShowText = true;
            plotThisButton.Text = "Plot";
            plotThisButton.CommandHandler = new MyRibbonCommandHandlerPlot();
            plotThisButton.CommandParameter = "HelloWorld ";

            AttChangeButton = new RibbonButton();
            AttChangeButton.Name = "UpdateAttributes";
            AttChangeButton.ShowText = true;
            AttChangeButton.Text = "Update \n Attributes";
            AttChangeButton.Height = 250;
            AttChangeButton.Size = RibbonItemSize.Large;
            AttChangeButton.CommandHandler = new MyRibbonCommandHandlerAttChange();
            AttChangeButton.CommandParameter = "test";

            RemRevLineButton = new RibbonButton();
            RemRevLineButton.Name = "RemoveRevisionLine";
            RemRevLineButton.ShowText = true;
            RemRevLineButton.Text = "Remove rev. \n line";
            RemRevLineButton.Height = 250;
            RemRevLineButton.Size = RibbonItemSize.Large;
            RemRevLineButton.CommandHandler = new MyRibbonCommandHandlerRemRevLine();
            RemRevLineButton.CommandParameter = "test";

            MoveRevLineButton = new RibbonButton();
            MoveRevLineButton.Name = "MoveRevisionLine";
            MoveRevLineButton.ShowText = true;
            MoveRevLineButton.Text = "Move rev. \n line";
            MoveRevLineButton.Height = 250;
            MoveRevLineButton.Size = RibbonItemSize.Large;
            MoveRevLineButton.CommandHandler = new MyRibbonCommandHandlerMoveRevLine();
            MoveRevLineButton.CommandParameter = "test";

            ChangeConfigFileButton = new RibbonButton();
            ChangeConfigFileButton.Name = "ChangeConfigFile";
            ChangeConfigFileButton.ShowText = true;
            ChangeConfigFileButton.Text = "Change \n config file";
            ChangeConfigFileButton.Height = 250;
            ChangeConfigFileButton.Size = RibbonItemSize.Large;
            ChangeConfigFileButton.CommandHandler = new MyRibbonCommandHandlerMoveRevLine();
            ChangeConfigFileButton.CommandParameter = "test";
            
            TestFunctionButton = new RibbonButton();
            TestFunctionButton.Name = "IfcExport";
            TestFunctionButton.ShowText = true;
            TestFunctionButton.Text = "IfcExport";
            TestFunctionButton.CommandHandler = new MyRibbonCommandHandlerIFCExport();
            TestFunctionButton.CommandParameter = "HelloWorld ";

            rps.Items.Add(plotThisButton);
            rps.Items.Add(AttChangeButton);
            rps.Items.Add(RemRevLineButton);
            rps.Items.Add(MoveRevLineButton);
            rps.Items.Add(ChangeConfigFileButton);
            rps.Items.Add(TestFunctionButton);

            return rp;
        }
        #endregion

        [CommandMethod("MoveRevLineBtn", CommandFlags.Session)]
        public void MoveRevisionLine()
        {
            if (SelectedConfigFile == "")
            {
                SelectConfigFile();
            }
            MoveRevisionLineCommand RevMove = new MoveRevisionLineCommand(SelectedConfigFile);
            RevMove.MOVEREVISIONLINE();
        }

        [CommandMethod("RemRevLine", CommandFlags.Session)]
        public void RemoveRevisionLine()
        {
            if (SelectedConfigFile == "")
            {
                SelectConfigFile();
            }
            RemoveRevisionLineCommand RevChange = new RemoveRevisionLineCommand(SelectedConfigFile);
            RevChange.REMOVEREVISIONLINE();
        }

        [CommandMethod("ChangeAttributeValue", CommandFlags.Session)]
        public void ChangeAttributeValue()
        {
            if (SelectedConfigFile == "")
            {
                SelectConfigFile();
            }
            ChangeAttributesCommands AttChange = new ChangeAttributesCommands(SelectedConfigFile);
            AttChange.UPDATEATTRIBUTE();
        }
        

        [CommandMethod("PlotThisPage", CommandFlags.Session)]
        public void plotThisPage()
        {
            PlottingCommands plot = new PlottingCommands();
            plot.PlotToPDF("E:\\Plottefil\\PDF\\" + "test" + ".pdf");
        }

        [CommandMethod("SelectConfigFile")]
        public string SelectConfigFile()
        {
            System.Windows.Forms.OpenFileDialog FD = new System.Windows.Forms.OpenFileDialog();

            FD.Filter = "XLSX files (*.xlsx)|*.xlsx|XLS files (*.xls)|*.xls";

            if (FD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SelectedConfigFile = FD.FileName;
            }
            else
            {
                FD.FileName = "";
            }

            return FD.FileName;
        }

        [CommandMethod("IFCEXPORTALL", CommandFlags.Session)]
        public void IFCExportButton()
        {
            //Application.SetSystemVariable("QAFLAGS", 4);
            MagiCadIFCExport IfcExport = new MagiCadIFCExport();
            IfcExport.IFCEXPORT();
        }


        public class MyRibbonCommandHandlerPlot : System.Windows.Input.ICommand
        {
            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                RibbonCommandItem PlotBtn = new RibbonCommandItem();
                if (PlotBtn != null)
                {
                    //execute an AutoCAD command, or your custom command defined by [CommandMethod]
                    Document dwg = Application.DocumentManager.MdiActiveDocument;
                    dwg.SendStringToExecute((string)PlotBtn.CommandParameter + "PlotThisPage" + " ", true, false, true);
                }

            }
        }


        public class MyRibbonCommandHandlerAttChange : System.Windows.Input.ICommand
        {
            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {

                RibbonCommandItem AttBtn = new RibbonCommandItem();
                if (AttBtn != null)
                {
                    //execute an AutoCAD command, or your custom command defined by [CommandMethod]
                    Document dwg = Application.DocumentManager.MdiActiveDocument;
                    dwg.SendStringToExecute((string)AttBtn.CommandParameter + "ChangeAttributeValue" + " ", true, false, true);
                }
            }
        }

        public class MyRibbonCommandHandlerRemRevLine : System.Windows.Input.ICommand
        {
            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {

                RibbonCommandItem RemRevLineBtn = new RibbonCommandItem();
                if (RemRevLineBtn != null)
                {
                    //execute an AutoCAD command, or your custom command defined by [CommandMethod]
                    Document dwg = Application.DocumentManager.MdiActiveDocument;
                    dwg.SendStringToExecute((string)RemRevLineBtn.CommandParameter + "RemRevLine" + " ", true, false, true);
                }
            }
        }

        public class MyRibbonCommandHandlerMoveRevLine : System.Windows.Input.ICommand
        {
            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {

                RibbonCommandItem MoveRevLineBtn = new RibbonCommandItem();
                if (MoveRevLineBtn != null)
                {
                    //execute an AutoCAD command, or your custom command defined by [CommandMethod]
                    Document dwg = Application.DocumentManager.MdiActiveDocument;
                    dwg.SendStringToExecute((string)MoveRevLineBtn.CommandParameter + "MoveRevLineBtn" + " ", true, false, true);
                }
            }
        }

        public class MyRibbonCommandHandlerChangeConfigFile : System.Windows.Input.ICommand
        {
            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {

                RibbonCommandItem ChangeConfigFileButton = new RibbonCommandItem();
                if (ChangeConfigFileButton != null)
                {
                    //execute an AutoCAD command, or your custom command defined by [CommandMethod]
                    Document dwg = Application.DocumentManager.MdiActiveDocument;
                    dwg.SendStringToExecute((string)ChangeConfigFileButton.CommandParameter + "SelectConfigFile" + " ", true, false, true);
                }
            }
        }

        public class MyRibbonCommandHandlerIFCExport : System.Windows.Input.ICommand
        {
            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {

                RibbonCommandItem IfcExportButton = new RibbonCommandItem();
                if (IfcExportButton != null)
                {
                    //execute an AutoCAD command, or your custom command defined by [CommandMethod]
                    Document dwg = Application.DocumentManager.MdiActiveDocument;
                    dwg.SendStringToExecute((string)IfcExportButton.CommandParameter + "IFCEXPORTALL" + " ", true, false, true);
                }
            }
        }

    }
}
