using XrefManager.Workers;

namespace XrefManager.Functions
{
    public class OpenConfigTool
    {
        public void openConfigTool()
        {
            var locateProjectFile = new LocateFileProject();
            var configFilePath = locateProjectFile.returnConfigFilePath();

            if (string.IsNullOrEmpty(configFilePath))
            {
                System.Windows.Forms.MessageBox.Show("Drawing is not connected to a project.");
            }

            var configTool = new LayerConfigEditor.MainWindow();
            configTool.MainViewModel.configFilePath = configFilePath;
            configTool.MainViewModel.ReloadConfig();
            configTool.ShowDialog();

            var configToolVM = configTool.MainViewModel;

            if (configToolVM.configSelected)
            {
                var writer = new WriteXml();
                writer.UpdateConfigPath(configToolVM.configFilePath);
            }
            return;
        }


    }
}
