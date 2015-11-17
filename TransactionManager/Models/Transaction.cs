using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransactionManager.Models
{
    public class Transaction
    {
        public long Id { get; set; }
        public string Account { get; set; }
        public string Description { get; set; }
        public string CurrencyCode { get; set; }
        public decimal Amount { get; set; }

    }

    
}