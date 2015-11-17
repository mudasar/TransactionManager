using Microsoft.VisualStudio.TestTools.UnitTesting;
using TransactionManager.Serices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Moq;
using TransactionManager.DAL;
using TransactionManager.Models;

namespace TransactionManager.Serices.Tests
{
    [TestClass()]
    public class TransactionImportServiceTests
    {

     
        [TestMethod()]
        public void ImportExcelRecodsTest()
        {
            var excelParserMock = new Moq.Mock<IExcelRecordParser>();
            var csvParserMock = new Moq.Mock<ICsvRecordParser>();
            var recordProcessorMock = new Mock<IRecordProcessor>();

            excelParserMock.Setup(m => m.ParseRecords(It.IsAny<string>()))
                .Returns((IEnumerable<string> result) => result);

            csvParserMock.Setup(m => m.ParseRecords(It.IsAny<string>()))
                .Returns((IEnumerable<string> result) => result);
            recordProcessorMock.Setup(m => m.ProcessRecords(It.IsAny<IEnumerable<string>>()))
                .Returns((ImportResult m) => m);

            

            var importService = new TransactionImportService(excelParserMock.Object, csvParserMock.Object, recordProcessorMock.Object);
            if (File.Exists(@"files/Test-case.xlsx"))
            {
                var result = importService.ImportExcelRecods(@"files/Test-case.xlsx");
                Assert.IsNotNull(result);
            }
            
        }

        [TestMethod()]
        public void ImportCsvRecordsAsyncTest()
        {
            var excelParserMock = new Moq.Mock<IExcelRecordParser>();
            var csvParserMock = new Moq.Mock<ICsvRecordParser>();
            var recordProcessorMock = new Mock<IRecordProcessor>();

            excelParserMock.Setup(m => m.ParseRecords(It.IsAny<string>()))
                .Returns((IEnumerable<string> result) => result);

            csvParserMock.Setup(m => m.ParseRecords(It.IsAny<string>()))
                .Returns((IEnumerable<string> result) => result);
            recordProcessorMock.Setup(m => m.ProcessRecords(It.IsAny<IEnumerable<string>>()))
                .Returns((ImportResult m) => m);



            var importService = new TransactionImportService(excelParserMock.Object, csvParserMock.Object, recordProcessorMock.Object);
            if (File.Exists(@"files/batch1.csv"))
            {
                var result = importService.ImportCsvRecords(@"files/batch1.csv");
                Assert.IsNotNull(result);
            }
        }
    }
}