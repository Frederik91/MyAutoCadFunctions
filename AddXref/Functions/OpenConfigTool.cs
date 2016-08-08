using LayerConfigEditor.Workers;
using XrefManager.Workers;

namespace XrefManager.Functions
{
    public class OpenConfigTool
    {
        public string configPath { get; set; }

        public void openConfigTool()
        {
            var locateProjectFile = new LocateFileProject();
            configPath = locateProjectFile.returnConfigFilePath();



            if (string.IsNullOrEmpty(configPath))
            {
                System.Windows.Forms.MessageBox.Show("Drawing is not connected to a project.");
            }

            var configTool = new LayerConfigEditor.MainWindow();
            configTool.MainViewModel.configFilePath = configPath;
            configTool.MainViewModel.ReloadConfig();
            configTool.ShowDialog();

            var configToolVM = configTool.MainViewModel;

            if (configToolVM.configSelected)
            {
                configPath = configToolVM.configFilePath;

                var writer = new WriteXml();
                writer.UpdateConfigPath(configPath);

                var configWriter = new ConfigFileWriter();

                configWriter.writeConfig(configPath, configToolVM.LayerFilterList);

            }
            
        }


    }
}
