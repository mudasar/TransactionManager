using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionManager.Models;

namespace TransactionManager.Serices
{
   public interface ITransactionValidator
   {
       bool IsTransactionValid(Transaction transaction);
   }
}
