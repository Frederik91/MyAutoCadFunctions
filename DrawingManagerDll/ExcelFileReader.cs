using DrawingManagerDll.Models;
using Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DrawingManagerDll
{
    public class ExcelFileReader
    {
        private string filePath;
        private DataSet ExcelData;

        private Settings Settings = new Settings { DrawingData = new List<DrawingData>(), PropertyNameList = new List<string>(), };

        public ExcelFileReader(string FilePath)
        {
            filePath = FilePath;
        }


        public Settings ReadFile()
        {
            PrepareRead();

            var DrawingDataTableIndex = ExcelData.Tables.IndexOf("Tegninger");
            var SettingsDataTableIndex = ExcelData.Tables.IndexOf("Instillinger");
            var DrawingDataTable = ExcelData.Tables[DrawingDataTableIndex];
            var SettingsDataTable = ExcelData.Tables[SettingsDataTableIndex];

            for (int i = 1; i < DrawingDataTable.Rows.Count; i++)
            {
                // Lagrer rad 2 i en liste. Listen inneholder da Attributtnavn i samme rekkefølge som attributtverdiene lagres.
                if (i == 1)
                {
                    int j = 0;
                    foreach (var Attribute in DrawingDataTable.Rows[i].ItemArray)
                    {
                        if (j >= Settings.StartMerkeskilt)
                        {
                            Settings.PropertyNameList.Add(Attribute.ToString());
                        }
                        j++;
                    }
                }

                if (i > 1)
                {
                    if (!(DrawingDataTable.Rows[i].ItemArray[6].ToString() == "" || DrawingDataTable.Rows[i].ItemArray[7].ToString() == "" || DrawingDataTable.Rows[i].ItemArray[8].ToString() == ""))
                    {
                        List<string> _propertyValueList = new List<string>();
                        int j = 0;

                        // Lager liste med attributtverdier
                        foreach (var value in DrawingDataTable.Rows[i].ItemArray)
                        {
                            if (j >= Settings.StartMerkeskilt)
                            {
                                _propertyValueList.Add(value.ToString());
                            }
                            j++;
                        }

                        // Henter informasjon om tegningen skal opdpateres eller ikke.
                        var UpdateBool = false;
                        if (DrawingDataTable.Rows[i].ItemArray[9].ToString() != "")
                        {
                            UpdateBool = true;
                        }

                        // henter Informasjon om tegningen samt lagrer informasjon om tegningen skal oppdateres og listen med attributtverdier.
                        Settings.DrawingData.Add(new DrawingData
                        {
                            DrawingName = DrawingDataTable.Rows[i].ItemArray[6].ToString(),
                            Layout = DrawingDataTable.Rows[i].ItemArray[7].ToString(),
                            FolderPath = DrawingDataTable.Rows[i].ItemArray[8].ToString(),
                            ToBeUpdated = UpdateBool,
                            PropertyValueList = _propertyValueList

                        });
                    }
                }
            }

            Settings.TitleBlockName = SettingsDataTable.Rows[1].ItemArray[1].ToString();
            Settings.RevBlockName = SettingsDataTable.Rows[2].ItemArray[1].ToString();
            Settings.StartMerkeskilt = Convert.ToInt16(SettingsDataTable.Rows[3].ItemArray[1].ToString());
            Settings.StartRevlinje = Convert.ToInt16(SettingsDataTable.Rows[4].ItemArray[1].ToString());

            return Settings;
        }

        private void PrepareRead()
        {
            FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);

            var ext = Path.GetExtension(filePath);

            IExcelDataReader excelReader;

            switch (ext)
            {
                case (".xls"):
                    excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
                    break;
                case (".xlsx"):
                    excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    break;
                default:
                    return;
            }


            //3. DataSet - The result of each spreadsheet will be created in the result.Tables
            ExcelData = excelReader.AsDataSet();

            ////4. DataSet - Create column names from first row
            //excelReader.IsFirstRowAsColumnNames = true;
            //Headings = excelReader.AsDataSet();

            //5. Data Reader methods
            //while (excelReader.Read())
            //{
            //    //excelReader.GetInt32(0);
            //}

            //6. Free resources (IExcelDataReader is IDisposable)
            excelReader.Close();

            return;
        }

    }
}
