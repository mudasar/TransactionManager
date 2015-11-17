using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Web;
using Moq;
using TransactionManager.Models;
using TransactionManager.Serices;

namespace TransactionManager.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {
       
        [TestMethod()]
        public void IndexTest()
        {
            var transactionImportServic = new Moq.Mock<ITransactionImportService>();
            var home = new HomeController(transactionImportServic.Object);
            var viewResult = home.Index();
            Assert.IsNotNull(viewResult);
        }

        [TestMethod()]
        public void UploadTest()
        {
            var transactionImportServic = new Moq.Mock<ITransactionImportService>();
            var home = new HomeController(transactionImportServic.Object);
            var viewResult = home.Upload();
            Assert.IsNotNull(viewResult);
        }

        [TestMethod()]
        public void UploadTest1()
        {
            var transactionImportServic = new Moq.Mock<ITransactionImportService>();
            var fakeFile = new Moq.Mock<HttpPostedFileBase>();
            var home = new HomeController(transactionImportServic.Object);

            var viewResult = home.Upload(fakeFile.Object);
            Assert.IsNotNull(viewResult);
        }

        [TestMethod()]
        public void SyncFileTest()
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
            var home = new HomeController(importService);
            if (File.Exists(@"files/Test-case.xlsx"))
            {
                var result = home.SyncFile(@"files/Test-case.xlsx");
                Assert.IsNotNull(result);
            }
        }

        [TestMethod()]
        public void ContactTest()
        {
            var transactionImportServic = new Moq.Mock<ITransactionImportService>();
            var home = new HomeController(transactionImportServic.Object);
            var viewResult = home.Contact();
            Assert.IsNotNull(viewResult);
        }
    }
}