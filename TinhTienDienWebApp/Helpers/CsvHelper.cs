using System.Collections.Generic;
using System.Data;
using System.IO;
using LumenWorks.Framework.IO.Csv;
using TinhTienDienWebApp.Models;

namespace TinhTienDienWebApp.Helpers
{
    public class CsvHelper
    {
        public List<PriceModel>GetPriceModels(string filePath)
        {
            return ConvertCsvToModels(filePath);
        }

        private DataTable ReadFile(string filePath)
        {
            var csvTable = new DataTable();
            using var csvReader = new CsvReader(new StreamReader(File.OpenRead(filePath)), true);
            csvTable.Load(csvReader);

            return csvTable;
        }
        
        private List<PriceModel> ConvertCsvToModels(string filePath)
        {
            var csvTable = ReadFile(filePath);
            List<PriceModel> priceModels = new List<PriceModel>();

            for (int i = 0; i < csvTable.Rows.Count; i++)
            {
                priceModels.Add(new PriceModel
                {
                    From = int.Parse(csvTable.Rows[i][0].ToString()),
                    To = int.Parse(csvTable.Rows[i][1].ToString()),
                    Price = float.Parse(csvTable.Rows[i][2].ToString())
                });
            }

            return priceModels;
        }
    }
}