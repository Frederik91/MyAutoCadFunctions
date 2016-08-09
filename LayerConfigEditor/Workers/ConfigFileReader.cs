using Autodesk.AutoCAD.Colors;
using LayerConfigEditor.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerConfigEditor.Workers
{
    public class ConfigFileReader
    {
        public List<LayerFilter> readConfigFile(string filePath)
        {
            var layerFilterList = new List<LayerFilter>();

            if (File.Exists(filePath))
            {
                var reader = new StreamReader(filePath);
                while (!reader.EndOfStream)
                {
                    var layerFilter = mapper(reader.ReadLine());
                    if (layerFilter != null)
                    {
                        layerFilterList.Add(layerFilter);
                    }
                }

                reader.Close();
            }

            return layerFilterList;
        }


        private LayerFilter mapper(string filterLine)
        {
            var lineArray = filterLine.Split('\t');
            var layerFilter = new LayerFilter();

            if (lineArray.Length >= 1)
            {
                if (string.IsNullOrEmpty(lineArray[0]))
                {
                    return null;
                }
                layerFilter.LayerName = lineArray[0];
            }

            if (lineArray.Length >= 2)
            {
                if (!string.IsNullOrEmpty(lineArray[1]))
                {
                    layerFilter.Freeze = true;
                }
                else
                {
                    layerFilter.Freeze = false;
                }
            }

            if (lineArray.Length >= 3)
            {
                if (!string.IsNullOrEmpty(lineArray[2]))
                {
                    layerFilter.Thaw = true;
                }
                else
                {
                    layerFilter.Thaw = false;
                }
            }

            if (lineArray.Length >= 4)
            {
                short s;

                if (short.TryParse(lineArray[3], out s))
                {
                    layerFilter.Color = Color.FromColorIndex(ColorMethod.ByAci, s);
                }
                else
                {
                    layerFilter.Color = null;
                }
            }

            if (lineArray.Length >= 5)
            {
                if (!string.IsNullOrEmpty(lineArray[4]))
                {
                    layerFilter.LayerOn = true;
                }
                else
                {
                    layerFilter.LayerOn = false;
                }
            }

            if (lineArray.Length >= 6)
            {
                if (!string.IsNullOrEmpty(lineArray[5]))
                {
                    layerFilter.LayerOff = true;
                }
                else
                {
                    layerFilter.LayerOff = false;
                }
            }

            if (lineArray.Length >= 7)
            {
                try
                {
                    layerFilter.Priority = Convert.ToInt32(lineArray[6]);
                }
                catch (Exception) { }                
            }

            return layerFilter;
        }
    }
}
