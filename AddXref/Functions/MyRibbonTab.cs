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
            Tab.Title = "Drawing manager";
            Tab.Id = "DRAWINGMANAGER_TAB_ID";

            ribbonControl.Tabs.Add(Tab);

            #region Panels

            /////////////////////////////////////
            // create Ribbon panel
            Autodesk.Windows.RibbonPanelSource xRefPanel = new RibbonPanelSource();
            xRefPanel.Title = "Xrefs";

            RibbonPanel xRefPane = new RibbonPanel();
            xRefPane.Source = xRefPanel;
            Tab.Panels.Add(xRefPane);

            Autodesk.Windows.RibbonPanelSource LayerUpdatePanel = new RibbonPanelSource();
            LayerUpdatePanel.Title = "Layer Update";

            RibbonPanel LayerUpdatePane = new RibbonPanel();
            LayerUpdatePane.Source = LayerUpdatePanel;
            Tab.Panels.Add(LayerUpdatePane);

            Autodesk.Windows.RibbonPanelSource DrawingMaintenancePanel = new RibbonPanelSource();
            DrawingMaintenancePanel.Title = "Drawing maintenance";

            RibbonPanel DrawingMaintenancePane = new RibbonPanel();
            DrawingMaintenancePane.Source = DrawingMaintenancePanel;
            Tab.Panels.Add(DrawingMaintenancePane);

            Autodesk.Windows.RibbonPanelSource ViewPanel = new RibbonPanelSource();
            ViewPanel.Title = "View";

            RibbonPanel ViewPane = new RibbonPanel();
            ViewPane.Source = ViewPanel;
            Tab.Panels.Add(ViewPane);

            //////////////////////////////////////////////////
            // create the buttons listed in the split button

            #endregion 

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

            #region Update Layers Buttons

            Autodesk.Windows.RibbonButton UpdateLayersThisDrawingButton = new RibbonButton();
            UpdateLayersThisDrawingButton.Text = "This drawing";
            UpdateLayersThisDrawingButton.ShowText = true;
            UpdateLayersThisDrawingButton.CommandHandler = new MyCmdHandler();

            Autodesk.Windows.RibbonButton UpdateLayersMultipleDrawingsButton = new RibbonButton();
            UpdateLayersMultipleDrawingsButton.Text = "Multiple drawings";
            UpdateLayersMultipleDrawingsButton.ShowText = true;
            UpdateLayersMultipleDrawingsButton.CommandHandler = new MyCmdHandler();

            Autodesk.Windows.RibbonButton addLayerFromThisDrawingButton = new RibbonButton();
            addLayerFromThisDrawingButton.Text = "Select layer this drawing";
            addLayerFromThisDrawingButton.ShowText = true;
            addLayerFromThisDrawingButton.CommandHandler = new MyCmdHandler();

            Autodesk.Windows.RibbonButton addLayerFromXrefButton = new RibbonButton();
            addLayerFromXrefButton.Text = "Select layer xref";
            addLayerFromXrefButton.ShowText = true;
            addLayerFromXrefButton.CommandHandler = new MyCmdHandler();

            Autodesk.Windows.RibbonButton editLayerConfigButton = new RibbonButton();
            editLayerConfigButton.Text = "Edit layer config";
            editLayerConfigButton.ShowText = true;
            editLayerConfigButton.CommandHandler = new MyCmdHandler();

            #endregion

            #region Drawing management buttons

            Autodesk.Windows.RibbonButton PurgeButton = new RibbonButton();
            PurgeButton.Text = "Purge multiple drawings";
            PurgeButton.ShowText = true;
            PurgeButton.CommandHandler = new MyCmdHandler();

            RibbonButton ChangeAttributeValueButton = new RibbonButton();
            ChangeAttributeValueButton.Text = "Change attribute value";
            ChangeAttributeValueButton.ShowText = true;
            ChangeAttributeValueButton.CommandHandler = new MyCmdHandler();

            #endregion

            #region View Buttons

            Autodesk.Windows.RibbonButton TopDownButton = new RibbonButton();
            TopDownButton.Text = "Top Down";
            TopDownButton.ShowText = true;
            TopDownButton.CommandHandler = new MyCmdHandler();

            #endregion 

            ////////////////////////
            // create split buttons
            RibbonSplitButton XrefSplitButton = new RibbonSplitButton();
            // Required to avoid upsetting AutoCAD when using cmd locator
            XrefSplitButton.Text = "Xref functions";
            XrefSplitButton.ShowText = true;

            RibbonSplitButton LayerUpdateSplitButton = new RibbonSplitButton();
            LayerUpdateSplitButton.Text = "Layer Update";
            LayerUpdateSplitButton.ShowText = true;

            RibbonLabel LayerUpdateLabel = new RibbonLabel();
            LayerUpdateLabel.Text = "Update layers in:";

            RibbonRowPanel DrawingMaintenanceRowPanel = new RibbonRowPanel();
            RibbonRowPanel LayerUpdateRowPanel = new RibbonRowPanel();

            DrawingMaintenanceRowPanel.Items.Add(PurgeButton);
            DrawingMaintenanceRowPanel.Items.Add(new RibbonRowBreak());
            DrawingMaintenanceRowPanel.Items.Add(ChangeAttributeValueButton);

            XrefSplitButton.Items.Add(xrefButton1);
            XrefSplitButton.Items.Add(xrefButton2);
            XrefSplitButton.Items.Add(xrefButton3);

            LayerUpdateSplitButton.Items.Add(UpdateLayersThisDrawingButton);
            LayerUpdateSplitButton.Items.Add(UpdateLayersMultipleDrawingsButton);

            LayerUpdateRowPanel.Items.Add(LayerUpdateLabel);
            LayerUpdateRowPanel.Items.Add(LayerUpdateSplitButton);
            LayerUpdateRowPanel.Items.Add(new RibbonRowBreak());
            LayerUpdateRowPanel.Items.Add(addLayerFromThisDrawingButton);
            LayerUpdateRowPanel.Items.Add(new RibbonRowBreak());
            LayerUpdateRowPanel.Items.Add(addLayerFromXrefButton);
            LayerUpdateRowPanel.Items.Add(new RibbonRowBreak());
            LayerUpdateRowPanel.Items.Add(editLayerConfigButton);

            ViewPanel.Items.Add(TopDownButton);

            xRefPanel.Items.Add(XrefSplitButton);
            LayerUpdatePanel.Items.Add(LayerUpdateRowPanel);
            DrawingMaintenancePanel.Items.Add(DrawingMaintenanceRowPanel);

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
                            MC.LayerUpdateThisDrawing();
                            break;
                        case ("Multiple drawings"):
                            MC.LayerUpdate();
                            break;
                        case ("Change attribute value"):
                            MC.ChangeAttribute_dialog();
                            break;
                        case ("Select layer this drawing"):
                            MC.AddLayerThisDrawing();
                            break;
                        case ("Select layer xref"):
                            MC.AddLayerXref();
                            break;
                        case ("Edit layer config"):
                            MC.EditLayerConfig();
                            break;
                        case ("Top Down"):
                            MC.OneVportTopDown();
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}