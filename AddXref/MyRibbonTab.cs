using System;
using System.Windows.Media.Imaging;
using System.Reflection;

using Autodesk.Windows;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using acApp = Autodesk.AutoCAD.ApplicationServices.Application;
using XrefManager;

namespace MyRibbonTab
{
    public class Commands
    {
        BitmapImage getBitmap(string fileName)
        {
            BitmapImage bmp = new BitmapImage();
            // BitmapImage.UriSource must be in a BeginInit/EndInit block.             
            bmp.BeginInit();
            bmp.UriSource = new Uri(string.Format(
              "pack://application:,,,/{0};component/{1}",
              Assembly.GetExecutingAssembly().GetName().Name,
              fileName));
            bmp.EndInit();

            return bmp;
        }

        [CommandMethod("RibbonSplitButton")]
        public void RibbonSplitButton()
        {
            Autodesk.Windows.RibbonControl ribbonControl =
              Autodesk.Windows.ComponentManager.Ribbon;

            /////////////////////////////////////
            // create Ribbon tab
            RibbonTab Tab = new RibbonTab();
            Tab.Title = "Test Ribbon";
            Tab.Id = "TESTRIBBON_TAB_ID";

            ribbonControl.Tabs.Add(Tab);

            /////////////////////////////////////
            // create Ribbon panel
            Autodesk.Windows.RibbonPanelSource xRefPanel = new RibbonPanelSource();
            xRefPanel.Title = "Xrefs";

            RibbonPanel xRefPane = new RibbonPanel();
            xRefPane.Source = xRefPanel;
            Tab.Panels.Add(xRefPane);

            Autodesk.Windows.RibbonPanelSource DrawingManagementPanel = new RibbonPanelSource();
            DrawingManagementPanel.Title = "Drawing Management";

            RibbonPanel DrawingManagementPane = new RibbonPanel();
            DrawingManagementPane.Source = DrawingManagementPanel;
            Tab.Panels.Add(DrawingManagementPane);

            //////////////////////////////////////////////////
            // create the buttons listed in the split button

            #region xRef Buttons

            Autodesk.Windows.RibbonButton xrefButton1 = new RibbonButton();
            xrefButton1.Text = "Add";
            xrefButton1.ShowText = true;
            xrefButton1.CommandHandler = new MyCmdHandler();

            Autodesk.Windows.RibbonButton xrefButton2 = new RibbonButton();
            xrefButton2.Text = "Unload";
            xrefButton2.ShowText = true;
            xrefButton2.CommandHandler = new MyCmdHandler();

            Autodesk.Windows.RibbonButton xrefButton3 = new RibbonButton();
            xrefButton3.Text = "Detach";
            xrefButton3.ShowText = true;
            xrefButton3.CommandHandler = new MyCmdHandler();

            #endregion


            #region Drawing management buttons

            Autodesk.Windows.RibbonButton PurgeButton = new RibbonButton();
            PurgeButton.Text = "Purge multiple drawings";
            PurgeButton.ShowText = true;
            PurgeButton.CommandHandler = new MyCmdHandler();

            Autodesk.Windows.RibbonButton UpdateLayersMultipleDrawingsButton = new RibbonButton();
            UpdateLayersMultipleDrawingsButton.Text = "This drawing";
            UpdateLayersMultipleDrawingsButton.ShowText = true;
            UpdateLayersMultipleDrawingsButton.CommandHandler = new MyCmdHandler();

            Autodesk.Windows.RibbonButton UpdateLayersThisDrawingButton = new RibbonButton();
            UpdateLayersThisDrawingButton.Text = "Multiple drawings";
            UpdateLayersThisDrawingButton.ShowText = true;
            UpdateLayersThisDrawingButton.CommandHandler = new MyCmdHandler();

            #endregion

            ////////////////////////
            // create split buttons
            RibbonSplitButton XrefSplitButton = new RibbonSplitButton();
            // Required to avoid upsetting AutoCAD when using cmd locator
            XrefSplitButton.Text = "Xref functions";
            XrefSplitButton.ShowText = true;

            RibbonSplitButton LayerUpdateSplitButton = new RibbonSplitButton();
            // Required to avoid upsetting AutoCAD when using cmd locator
            LayerUpdateSplitButton.Text = "Layer Update";
            LayerUpdateSplitButton.ShowText = true;

            RibbonLabel LayerUpdateLabel = new RibbonLabel();
            LayerUpdateLabel.Text = "Update layers in:";

            RibbonRowPanel itemsRow = new RibbonRowPanel();
            itemsRow.Items.Add(LayerUpdateLabel);
            itemsRow.Items.Add(new RibbonRowBreak());
            itemsRow.Items.Add(LayerUpdateSplitButton);
            itemsRow.Items.Add(PurgeButton);

            itemsRow.MinWidth = 50;

            XrefSplitButton.Items.Add(xrefButton1);
            XrefSplitButton.Items.Add(xrefButton2);
            XrefSplitButton.Items.Add(xrefButton3);

            LayerUpdateSplitButton.Items.Add(UpdateLayersMultipleDrawingsButton);
            LayerUpdateSplitButton.Items.Add(UpdateLayersThisDrawingButton);

            xRefPanel.Items.Add(XrefSplitButton);
            DrawingManagementPanel.Items.Add(itemsRow);

            Tab.IsActive = true;
        }

        public class MyCmdHandler : System.Windows.Input.ICommand
        {
            public MainClass MC = new MainClass();

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                Document doc = acApp.DocumentManager.MdiActiveDocument;

                if (parameter is RibbonButton)
                {
                    RibbonButton button = parameter as RibbonButton;
                    var AX = new AddXref();
                    var UX = new UnloadXref();

                    switch (button.Text)
                    {
                        case ("Add"):
                            MC.AddXref();
                            break;
                        case ("Unload"):
                            MC.UnloadXRef();
                            break;
                        case ("Detach"):
                            MC.DetachXRef();
                            break;
                        case ("Purge multiple drawings"):
                            MC.PurgeDrawings();
                            break;
                        case ("This drawing"):
                            MC.LayerUpdateWithArgs();
                            break;
                        case ("Multiple drawings"):
                            MC.LayerUpdate();
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}