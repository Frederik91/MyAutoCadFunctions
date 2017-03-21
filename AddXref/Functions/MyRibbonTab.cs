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
        BitmapImage GetBitmap(string fileName)
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
            RibbonControl ribbonControl = ComponentManager.Ribbon;

            /////////////////////////////////////
            // create Ribbon tab
            RibbonTab Tab = new RibbonTab()
            {
                Title = "Drawing manager",
                Id = "DRAWINGMANAGER_TAB_ID"
            };
            ribbonControl.Tabs.Add(Tab);

            #region Panels

            /////////////////////////////////////
            // create Ribbon panel
            RibbonPanelSource xRefPanel = new RibbonPanelSource()
            {
                Title = "Xrefs"
            };
            RibbonPanel xRefPane = new RibbonPanel()
            {
                Source = xRefPanel
            };
            Tab.Panels.Add(xRefPane);

            RibbonPanelSource LayerUpdatePanel = new RibbonPanelSource()
            {
                Title = "Layer Update"
            };
            RibbonPanel LayerUpdatePane = new RibbonPanel()
            {
                Source = LayerUpdatePanel
            };
            Tab.Panels.Add(LayerUpdatePane);

            RibbonPanelSource DrawingMaintenancePanel = new RibbonPanelSource()
            {
                Title = "Drawing maintenance"
            };
            RibbonPanel DrawingMaintenancePane = new RibbonPanel()
            {
                Source = DrawingMaintenancePanel
            };
            Tab.Panels.Add(DrawingMaintenancePane);

            RibbonPanelSource ViewPanel = new RibbonPanelSource()
            {
                Title = "View"
            };
            RibbonPanel ViewPane = new RibbonPanel()
            {
                Source = ViewPanel
            };
            Tab.Panels.Add(ViewPane);

            RibbonPanelSource FunctionsPanel = new RibbonPanelSource()
            {
                Title = "Functions"
            };
            RibbonPanel FunctionsPane = new RibbonPanel()
            {
                Source = FunctionsPanel
            };
            Tab.Panels.Add(FunctionsPane);

            //////////////////////////////////////////////////
            // create the buttons listed in the split button

            #endregion 

            #region xRef Buttons

            RibbonButton xrefButton1 = new RibbonButton()
            {
                Text = "Add",
                ShowText = true,
                CommandHandler = new MyCmdHandler()
            };
            RibbonButton xrefButton2 = new RibbonButton()
            {
                Text = "Unload",
                ShowText = true,
                CommandHandler = new MyCmdHandler()
            };
            RibbonButton xrefButton3 = new RibbonButton()
            {
                Text = "Detach",
                ShowText = true,
                CommandHandler = new MyCmdHandler()
            };

            #endregion

            #region Update Layers Buttons

            RibbonButton UpdateLayersThisDrawingButton = new RibbonButton()
            {
                Text = "This drawing",
                ShowText = true,
                CommandHandler = new MyCmdHandler()
            };
            RibbonButton UpdateLayersMultipleDrawingsButton = new RibbonButton()
            {
                Text = "Multiple drawings",
                ShowText = true,
                CommandHandler = new MyCmdHandler()
            };
            RibbonButton addLayerFromThisDrawingButton = new RibbonButton()
            {
                Text = "Select layer this drawing",
                ShowText = true,
                CommandHandler = new MyCmdHandler()
            };
            RibbonButton addLayerFromXrefButton = new RibbonButton()
            {
                Text = "Select layer xref",
                ShowText = true,
                CommandHandler = new MyCmdHandler()
            };
            RibbonButton editLayerConfigButton = new RibbonButton()
            {
                Text = "Edit layer config",
                ShowText = true,
                CommandHandler = new MyCmdHandler()
            };

            #endregion

            #region Drawing management buttons

            RibbonButton PurgeButton = new RibbonButton()
            {
                Text = "Purge multiple drawings",
                ShowText = true,
                CommandHandler = new MyCmdHandler()
            };
            RibbonButton ChangeAttributeValueButton = new RibbonButton()
            {
                Text = "Change attribute value",
                ShowText = true,
                CommandHandler = new MyCmdHandler()
            };
            RibbonButton GenerateAttributeListButton = new RibbonButton()
            {
                Text = "Generate Attribute List",
                ShowText = true,
                CommandHandler = new MyCmdHandler()
            };

            #endregion

            #region View Buttons

            RibbonButton TopDownButton = new RibbonButton()
            {
                Text = "Top Down",
                ShowText = true,
                CommandHandler = new MyCmdHandler()
            };
            RibbonButton AdjustCableTraysButton = new RibbonButton()
            {
                Text = "Adjust Cable Trays",
                ShowText = true,
                CommandHandler = new MyCmdHandler()
            };

            #endregion

            ////////////////////////
            // create split buttons
            RibbonSplitButton XrefSplitButton = new RibbonSplitButton()
            {
                // Required to avoid upsetting AutoCAD when using cmd locator
                Text = "Xref functions",
                ShowText = true
            };
            RibbonSplitButton LayerUpdateSplitButton = new RibbonSplitButton()
            {
                Text = "Layer Update",
                ShowText = true
            };
            RibbonLabel LayerUpdateLabel = new RibbonLabel()
            {
                Text = "Update layers in:"
            };
            RibbonRowPanel DrawingMaintenanceRowPanel = new RibbonRowPanel();
            RibbonRowPanel LayerUpdateRowPanel = new RibbonRowPanel();

            DrawingMaintenanceRowPanel.Items.Add(PurgeButton);
            DrawingMaintenanceRowPanel.Items.Add(new RibbonRowBreak());
            DrawingMaintenanceRowPanel.Items.Add(ChangeAttributeValueButton);
            DrawingMaintenanceRowPanel.Items.Add(new RibbonRowBreak());
            DrawingMaintenanceRowPanel.Items.Add(GenerateAttributeListButton);

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
            FunctionsPanel.Items.Add(AdjustCableTraysButton);

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
                        case ("Generate Attribute List"):
                            MC.GetAllAttributes();
                            break;
                        case ("Adjust Cable Trays"):
                            MC.AdjustCableTrays();
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}