using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TransactionManager.Models;
using TransactionManager.Utils;

namespace TransactionManager.Serices
{
    public class TransactionValidator : ITransactionValidator
    {
        public bool IsTransactionValid(Transaction transaction)
        {
            var result = false;
            if (transaction == null) return false;

            result = !string.IsNullOrWhiteSpace(transaction.Account) &&
                     !string.IsNullOrWhiteSpace(transaction.Description) &&
                     !string.IsNullOrWhiteSpace(transaction.CurrencyCode) &&
                     CurrencyModel.ValidateCurrencyCode(transaction.CurrencyCode) && transaction.Amount > 0;
            return result;
        }
    }
}