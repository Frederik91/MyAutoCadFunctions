using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LayerConfigEditor.Models;

using System.Collections.Generic;

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