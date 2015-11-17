using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TransactionManager.Models;

namespace TransactionManager.DAL
{
    public class TransactionRepository : ITransactionRepository, IDisposable
    {

        private readonly TransactionDbContext _dbContext;

        public TransactionRepository(TransactionDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public IEnumerable<Transaction> GetTransactions()
        {
            return _dbContext.Transactions.ToList();
        }

        public IEnumerable<Transaction> GetTransactionsPaginated(int startIndex, int pageSize)
        {
            return _dbContext.Transactions.OrderBy(x=> x.Id).Skip(startIndex * pageSize).Take(pageSize).ToList();
        }

        public IQueryable<Transaction> GetRTransactionsQueryable()
        {
            return _dbContext.Transactions.AsQueryable();
        }

        public Transaction GetTransactionById(long transactionId)
        {
            return _dbContext.Transactions.Find(transactionId);
        }

        public void InsertTransaction(Transaction transaction)
        {
            _dbContext.Transactions.Add(transaction);
        }

        public void InsertTransactionBulk(List<Transaction> transactions)
        {
            _dbContext.Transactions.AddRange(transactions);
        }

        public void DeleteTransaction(long transactionId)
        {
            Transaction transaction = _dbContext.Transactions.Find(transactionId);
            _dbContext.Transactions.Remove(transaction);
        }

        public void UpdateTransaction(Transaction transaction)
        {
            var originalTransaction = _dbContext.Transactions.Find(transaction.Id);
            originalTransaction.CurrencyCode = transaction.CurrencyCode;
            originalTransaction.Account = transaction.Account;
            originalTransaction.Amount = transaction.Amount;
            originalTransaction.Description = transaction.Description;
            _dbContext.Entry(originalTransaction).State = EntityState.Modified;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public async Task<bool> SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
            return true;
        }

     

        #region IDisposible 

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}