using System.Collections.Generic;

namespace TransactionManager.Serices
{
    public interface ICsvRecordParser
    {
        IEnumerable<string> ParseRecords(string filename);
    }
}