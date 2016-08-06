using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LayerConfigEditor.Models;
using LayerConfigEditor.Workers;
using System.Collections.Generic;
using XrefManager.Workers;

namespace LayerFilterFromSelectedObjectWindow.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public List<LayerFilter> NewLayerFilterList { get { return m_newLayerFilterList; } set { m_newLayerFilterList = value; RaisePropertyChanged(); } }
        public RelayCommand AddLayersCommand { get; private set; }
        public MainWindow mainWindow;

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
            var projectFileLocator = new LocateFileProject();
            var configFilePath = projectFileLocator.returnConfigFilePath();

            if (string.IsNullOrEmpty(configFilePath))
            {
                configFilePath = connectDrawingToConfigFile(configFilePath);
                if (string.IsNullOrEmpty(configFilePath))
                {
                    return;
                }
            }

            var reader = new ConfigFileReader();
            var writer = new ConfigFileWriter();

            var layerFilterList = reader.readConfigFile(configFilePath);

            foreach (var layerFilter in NewLayerFilterList)
            {
                layerFilterList.Add(layerFilter);
            }

            writer.writeConfig(configFilePath, layerFilterList);

            mainWindow.Close();
        }

        private string connectDrawingToConfigFile(string configPath)
        {
            var res = System.Windows.Forms.MessageBox.Show("Drawing is not connected to a project. Do you want to create a new project?", "Drawing not connected to project", System.Windows.Forms.MessageBoxButtons.YesNo);
            if (res == System.Windows.Forms.DialogResult.Yes)
            {
                using (var form = new XrefManager.Forms.UpdateLayerForm())
                {
                    form.ShowDialog();
                    if (string.IsNullOrEmpty(form.configPath))
                    {
                        return null;
                    }
                    configPath = form.configPath;
                }
            }
            return configPath;
        }
    }
}