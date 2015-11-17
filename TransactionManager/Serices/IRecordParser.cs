﻿using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransactionManager.Serices
{
    public interface IExcelRecordParser
    {
       IEnumerable<string> ParseRecords(string filename);
    }
}