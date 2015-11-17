using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionManager.Models;

namespace TransactionManager.DAL
{
    public interface ITransactionRepository : IDisposable
    {
        IEnumerable<Transaction> GetTransactions();

        IQueryable<Transaction> GetRTransactionsQueryable();

        IEnumerable<Transaction> GetTransactionsPaginated(int startIndex, int pageSize);

        Transaction GetTransactionById(long transactionId);
        void InsertTransaction(Transaction transaction);

        void InsertTransactionBulk(List<Transaction> transactions);

        void DeleteTransaction(long transactionId);
        void UpdateTransaction(Transaction transaction);
        void Save();

        Task<bool> SaveAsync();
    }
}
