using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransactionManager.Models
{
    public class ImportResult
    {
        public long RecordsProcessed { get; set; }
        public long ValidRecords { get; set; }
        public long InvalidRecords { get; set; }
    }
}