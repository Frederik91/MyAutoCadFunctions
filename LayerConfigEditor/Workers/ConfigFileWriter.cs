using LayerConfigEditor.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LayerConfigEditor.Workers
{
    public class ConfigFileWriter
    {
        public void writeConfig(string filePath, List<LayerFilter> layerFilterList)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    File.Delete(filePath);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Unable to overwrite file. \n Error: " + e.Message);
                    return;
                }
            }

            layerFilterList = layerFilterList.GroupBy(x => x.LayerName).Select(x => x.First()).ToList();

            using (var writer = new StreamWriter(File.Open(filePath, FileMode.CreateNew), Encoding.GetEncoding("iso-8859-1")))
            {
                var sortedLayerFilterList = layerFilterList.OrderByDescending(x => x.Priority).ToList();

                foreach (var row in sortedLayerFilterList)
                {
                    writer.WriteLine(mapper(row));
                }
                writer.Close();
            }
        }

        private string mapper(LayerFilter layerFilter)
        {
            var freeze = "";
            var thaw = "";
            var layerOn = "";
            var layerOff = "";

            if (layerFilter.Freeze)
            {
                freeze = "x";
            }

            if (layerFilter.Thaw)
            {
                thaw = "x";
            }

            if (layerFilter.LayerOn)
            {
                layerOn = "x";
            }

            if (layerFilter.LayerOff)
            {
                layerOff = "x";
            }

            try
            {
                return layerFilter.LayerName + "\t"
                     + freeze + "\t"
                     + thaw + "\t"
                     + layerFilter.Color.ColorIndex + "\t"
                     + layerOn + "\t"
                     + layerOff + "\t"
                     + layerFilter.Priority;
            }
            catch (Exception)
            {
                return layerFilter.LayerName + "\t"
                     + freeze + "\t"
                     + thaw + "\t"
                     + "" + "\t"
                     + layerOn + "\t"
                     + layerOff + "\t"
                     + layerFilter.Priority;
            }

        }
    }
}
