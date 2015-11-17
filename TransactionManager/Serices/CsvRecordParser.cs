using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TransactionManager.Serices
{
    public class CsvRecordParser : ICsvRecordParser
    {
        public IEnumerable<string> ParseRecords(string filename)
        {
            var lines =  new List<string>();
            using (StreamReader sr = new StreamReader(filename))
            {
                string currentLine;
                while ((currentLine = sr.ReadLine()) != null)
                {
                    lines.Add(currentLine);
                }
            }

         return lines.Skip(1);
        }
    }
}