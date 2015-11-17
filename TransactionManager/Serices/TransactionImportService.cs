using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Excel;
using TransactionManager.DAL;
using TransactionManager.Models;

namespace TransactionManager.Serices
{
    public class TransactionImportService : ITransactionImportService
    {
        private readonly IExcelRecordParser _excelRecordParser;
        private readonly ICsvRecordParser _csvRecordParser;
        private readonly IRecordProcessor _recordProcessor;


        public TransactionImportService(IExcelRecordParser excelRecordParser, ICsvRecordParser csvRecordParser, IRecordProcessor recordProcessor)
        {
            _excelRecordParser = excelRecordParser;
            _csvRecordParser = csvRecordParser;
            _recordProcessor = recordProcessor;
        }

        public ImportResult ImportExcelRecods(string filename)
        {
            var lines = _excelRecordParser.ParseRecords(filename);

            var result = _recordProcessor.ProcessRecords(lines);
            return result;
        }

        public ImportResult ImportCsvRecords(string filename)
        {
            var lines = _csvRecordParser.ParseRecords(filename);
            var result = _recordProcessor.ProcessRecords(lines);
            return result;
        }


    }
}