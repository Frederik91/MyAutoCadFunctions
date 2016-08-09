using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LayerConfigEditor.Workers;

namespace TestLayerConfigEditor
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void testLayerConfigEditBus2()
        {
            var configPath = @"O:\A005000\A009727\BUSP 2\3.7 Tegninger\Kladd\FRTE\BUS2.txt";

            var configTool = new LayerConfigEditor.MainWindow();
            configTool.MainViewModel.configFilePath = configPath;
            configTool.MainViewModel.ReloadConfig();
            configTool.ShowDialog();
        }

        [TestMethod]
        public void readWriteConfigFile()
        {
            var configPath = @"O:\A005000\A009727\BUSP 2\3.7 Tegninger\Kladd\FRTE\BUS2.txt";

            var reader = new ConfigFileReader();
            var LayerFilterList = reader.readConfigFile(configPath);

            var configWriter = new ConfigFileWriter();
            configWriter.writeConfig(configPath, LayerFilterList);
        }


        [TestMethod]
        public void readConfigFile()
        {
            var configPath = @"C:\Users\frte\Documents\Projects\Config\MH2 layer plot teknisk.txt";

            var reader = new ConfigFileReader();
            var LayerFilterList = reader.readConfigFile(configPath);

            var configWriter = new ConfigFileWriter();
            configWriter.writeConfig(configPath, LayerFilterList);
        }
    }
}
