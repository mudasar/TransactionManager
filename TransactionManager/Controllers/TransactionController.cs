using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransactionManager.DAL;
using TransactionManager.Models;

namespace TransactionManager.Controllers
{
    public class TransactionController : Controller
    {

        private readonly ITransactionRepository _transactionRepository;

        public TransactionController(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }


        // GET: Transactions paginated
        public ActionResult GetTransactionsPaginated(int startIndex, int pageSize)
        {
            var result = _transactionRepository.GetTransactionsPaginated(startIndex, pageSize).AsQueryable();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GET: Transaction/5
        public ActionResult GetTransactionById(long id)
        {
            return Json(_transactionRepository.GetTransactionById(id));
        }

        [HttpPost]
        // GET: Transaction/Create
        public ActionResult Insert(Transaction transaction)
        {
            try
            {
                _transactionRepository.InsertTransaction(transaction);
                _transactionRepository.Save();
                return Json(transaction);
            }
            catch
            {
                return Json(new { Error = "error occured while updaing" });
            }
        }

        // POST: Transaction/Update
        [HttpPut]
        public ActionResult Update(Transaction transaction)
        {
            try
            {
                _transactionRepository.UpdateTransaction(transaction);
                _transactionRepository.Save();
                return Json(transaction);
            }
            catch
            {
                return Json(new { Error = "error occured while updaing" });
            }
        }

        [HttpDelete]
        // GET: Transaction/Edit/5
        public ActionResult Delete(long id)
        {
            try
            {
                _transactionRepository.DeleteTransaction(id);
                _transactionRepository.Save();
                return Json(new {success = true});
            }
            catch
            {
                return Json(new { Error = "error occured while deleting" });
            }
        }

        
    }
}
