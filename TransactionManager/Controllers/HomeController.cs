using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Excel.Log;
using TransactionManager.DAL;
using TransactionManager.Models;
using TransactionManager.Serices;

namespace TransactionManager.Controllers
{


    public class HomeController : Controller
    {
        private readonly ITransactionImportService _transactionImportService;

        private NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();


        public HomeController(ITransactionImportService transactionImportService)
        {
            _transactionImportService = transactionImportService;
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Upload()
        {

            return View();
        }

        [ValidateAntiForgeryToken()]
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            var extention = "";
            var fileName = "";
            if (file != null && file.ContentLength > 0)
            {
                extention = Path.GetExtension(file.FileName);
                fileName = Guid.NewGuid() + extention;
                var path = Path.Combine(Server.MapPath("~/uploads"), fileName);
                file.SaveAs(path);
            }
            return Json(new { Data = "Successfully Uploaded", file = fileName });
        }

        [HttpPost]
        public async Task<ActionResult> SyncFile(string fileName)
        {
            try
            {
                var ext = Path.GetExtension(fileName).ToLower();
                ImportResult result = null;
                fileName = Path.Combine(Server.MapPath("~/Uploads"), fileName);
                if (ext.Equals(".csv"))
                {
                    var excelTask = Task.Factory.StartNew((() => _transactionImportService.ImportCsvRecords(fileName)));
                    result =  excelTask.Result;
                    //   _transactionImportService.ImportCsvRecordsAsync(Path.Combine(Server.MapPath("~/Uploads"), fileName));
                }
                else if (ext.Equals(".xlsx"))
                {
                    var csvTask = Task.Factory.StartNew((() => _transactionImportService.ImportExcelRecods(fileName)));
                    result = csvTask.Result;
                }
                return Json(new { isSuccess = true, message = "sync completed", result });
            }
            catch (Exception ex)
            {
               _logger.Error(ex.Message);
                return Json(new { isSuccess = false, message = "Sync failed"});
            }
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}