using Autodesk.AutoCAD.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LayerConfigEditor.Models;
using LayerConfigEditor.Workers;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LayerConfigEditor.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase m_currentViewModel;
        private List<LayerFilter> m_layerFilterList = new List<LayerFilter>();
        private MainWindow mainWindow;

        public string configFilePath = string.Empty;
        public ViewModelBase CurrentViewModel { get { return m_currentViewModel; } set { m_currentViewModel = value; RaisePropertyChanged(); } }
        public List<LayerFilter> LayerFilterList { get { return m_layerFilterList; } set { m_layerFilterList = value; RaisePropertyChanged(); } }
        public bool configSelected = false;

        public RelayCommand NewConfigCommand { get; private set; }
        public RelayCommand OpenConfigCommand { get; private set; }
        public RelayCommand SaveConfigCommand { get; private set; }
        public RelayCommand SaveAsConfigCommand { get; private set; }
        public RelayCommand ExitCommand { get; private set; }
        public RelayCommand ConfigFileSelectedCommand { get; private set; }

        public MainViewModel(MainWindow _mainWindow)
        {
            mainWindow = _mainWindow;

            if (File.Exists(configFilePath))
            {
                ReloadConfig();
            }

            NewConfigCommand = new RelayCommand(NewConfig);
            OpenConfigCommand = new RelayCommand(OpenConfig);
            SaveConfigCommand = new RelayCommand(SaveConfig);
            SaveAsConfigCommand = new RelayCommand(SaveAsConfig);
            ExitCommand = new RelayCommand(Exit);
            ConfigFileSelectedCommand = new RelayCommand(ConfigFileSelected);
        }

        public void setColor(int index)
        {
            ColorDialog cd = new ColorDialog();
            System.Windows.Forms.DialogResult dr = cd.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                LayerFilterList[index].Color = cd.Color;                
            }
        }

        private void ConfigFileSelected()
        {
            configSelected = true;
            SaveConfig();
            Exit();
        }

        private void NewConfig()
        {
            LayerFilterList = new List<LayerFilter>();
            configFilePath = string.Empty;
        }

        public void ReloadConfig()
        {
            var reader = new ConfigFileReader();
            LayerFilterList = reader.readConfigFile(configFilePath);
        }

        private void OpenConfig()
        {
            var dialog = new System.Windows.Forms.OpenFileDialog();
            dialog.DefaultExt = "Text files | *.txt";
            dialog.ShowDialog();

            if (File.Exists(dialog.FileName))
            {
                var reader = new ConfigFileReader();
                LayerFilterList = reader.readConfigFile(dialog.FileName);
                configFilePath = dialog.FileName;
            }
        }

        private void SaveConfig()
        {
            if (string.IsNullOrEmpty(configFilePath))
            {
                SaveAsConfig();
            }

            var configWriter = new ConfigFileWriter();

            LayerFilterList = LayerFilterList.GroupBy(x => x.LayerName).Select(x => x.First()).ToList();

            configWriter.writeConfig(configFilePath, LayerFilterList);
        }

        private void SaveAsConfig()
        {
            var dialog = new System.Windows.Forms.SaveFileDialog();
            dialog.AddExtension = true;
            dialog.Filter = "Text files | *.txt";
            dialog.OverwritePrompt = true;
            dialog.ShowDialog();

            if (!string.IsNullOrEmpty(dialog.FileName))
            {
                configFilePath = dialog.FileName;

                SaveConfig();
            }
        }

        private void Exit()
        {
            mainWindow.Close();
        }
    }
}