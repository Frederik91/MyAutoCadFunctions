using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LayerConfigEditor.Models;
using Autodesk.AutoCAD.Windows;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LayerFilterFromSelectedObjectWindow.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public List<LayerFilter> NewLayerFilterList { get { return m_newLayerFilterList; } set { m_newLayerFilterList = value; RaisePropertyChanged(); } }
        public RelayCommand AddLayersCommand { get; private set; }
        public MainWindow mainWindow;
        public bool addLayerFilter = false;

        private List<LayerFilter> m_newLayerFilterList = new List<LayerFilter>();

        public MainViewModel(MainWindow _mainWindow)
        {
            mainWindow = _mainWindow;
            AddLayersCommand = new RelayCommand(addLayerFiltersToConfigFile);
        }

        public void setColor(int index)
        {
            var cd = new Autodesk.AutoCAD.Windows.ColorDialog();
            DialogResult dr = cd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                NewLayerFilterList[index].Color = cd.Color;
            }
        }

        public void MapLayerStringToLayerFilter(string layerName)
        {
            NewLayerFilterList.Add(new LayerFilter { LayerName = layerName });
        }

        private void addLayerFiltersToConfigFile()
        {
            addLayerFilter = true;
            mainWindow.Close();
        }
    }
}