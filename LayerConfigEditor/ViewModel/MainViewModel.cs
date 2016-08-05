using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LayerConfigEditor.Models;
using LayerConfigEditor.Workers;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace LayerConfigEditor.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase m_currentViewModel;
        private List<LayerFilter> m_layerFilterList;

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

        public MainViewModel()
        {
            NewConfigCommand = new RelayCommand(NewConfig);
            OpenConfigCommand = new RelayCommand(OpenConfig);
            SaveConfigCommand = new RelayCommand(SaveConfig);
            SaveAsConfigCommand = new RelayCommand(SaveAsConfig);
            ExitCommand = new RelayCommand(Exit);
            ConfigFileSelectedCommand = new RelayCommand(ConfigFileSelected);
        }

        private void ConfigFileSelected()
        {
            configSelected = true;
            Application.Current.MainWindow.Close();
        }

        private void NewConfig()
        {
            LayerFilterList = new List<LayerFilter>();
            configFilePath = string.Empty;
            CurrentViewModel = new LayerViewModel(this);
        }

        private void OpenConfig()
        {
            var dialog = new OpenFileDialog();
            dialog.DefaultExt = "Text files | *.txt";
            dialog.ShowDialog();

            var reader = new ConfigFileReader();
            LayerFilterList = reader.readConfigFile(dialog.FileName);
            configFilePath = dialog.FileName;
            CurrentViewModel = new LayerViewModel(this);
        }

        private void SaveConfig()
        {
            if (string.IsNullOrEmpty(configFilePath))
            {
                SaveAsConfig();
            }

            var configWriter = new ConfigFileWriter();
            configWriter.writeConfig(configFilePath, LayerFilterList);
        }

        private void SaveAsConfig()
        {
            var dialog = new SaveFileDialog();
            dialog.AddExtension = true;
            dialog.Filter = "Text files | *.txt";
            dialog.OverwritePrompt = true;
            dialog.ShowDialog();

            if (!string.IsNullOrEmpty(dialog.FileName))
            {
                configFilePath = dialog.FileName;

                var configWriter = new ConfigFileWriter();
                configWriter.writeConfig(configFilePath, LayerFilterList);
            }
        }

        private void Exit()
        {
            Application.Current.MainWindow.Close(); ;
        }
    }
}