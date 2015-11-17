using System.Threading.Tasks;
using TransactionManager.Models;

namespace TransactionManager.Serices
{
    public interface ITransactionImportService
    {
        ImportResult ImportExcelRecods(string filenme);
        ImportResult ImportCsvRecords(string filename);
    }
}