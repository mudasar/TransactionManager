using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using Excel;

namespace TransactionManager.Serices
{
    public class ExcelRecordParser : IExcelRecordParser
    {
        /// <summary>
        /// This method could be further refactored to return chunks of lines
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public IEnumerable<string> ParseRecords(string filename)
        {
            var lines = new List<string>();

            using (var stream = File.Open(filename, FileMode.Open, FileAccess.Read))
            {
                using (var excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream))
                {
                    excelReader.IsFirstRowAsColumnNames = true;
                    DataSet dataset = excelReader.AsDataSet();
                    //5. Data Reader methods
                    while (excelReader.Read())
                    {
                        lines.Add(
                            $"{excelReader.GetString(0)}|{excelReader.GetString(1)}|{excelReader.GetString(2)}|{excelReader.GetString(3)}");

                    }
                }
            }
            //skip header row
            return lines.Skip(1);
        }
    }
}