using System.Collections.Generic;
using TransactionManager.DAL;
using TransactionManager.Models;

namespace TransactionManager.Serices
{
    public class RecordProcessor : IRecordProcessor
    {

        private readonly ITransactionRepository _transactionRepository;
        private readonly ITransactionValidator _transactionValidator;

        public RecordProcessor(ITransactionRepository transactionRepository, ITransactionValidator transactionValidator)
        {
            _transactionRepository = transactionRepository;
            _transactionValidator = transactionValidator;
        }

        public ImportResult ProcessRecords(IEnumerable<string> lines)
        {
            var transactionList = new List<Transaction>();
            var result = new ImportResult();

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var columns = line.Trim('\n').Trim('\r').Split('|');
                if (columns.Length > 3)
                {
                    var transaction = GetValidatedTransaction(columns);
                    var isValid = _transactionValidator.IsTransactionValid(transaction);
                    result.RecordsProcessed++;
                    result.ValidRecords = isValid ? result.ValidRecords + 1 : result.ValidRecords;
                    result.InvalidRecords = !isValid ? result.InvalidRecords + 1 : result.InvalidRecords;
                    if (isValid)
                    {
                        transactionList.Add(transaction);
                    }
                }
                else
                {
                    result.InvalidRecords++;
                    result.RecordsProcessed++;
                }
            }
            _transactionRepository.InsertTransactionBulk(transactionList);
            _transactionRepository.Save();
            return result;
        }

        private Transaction GetValidatedTransaction(string[] columns)
        {
            var transaction = new Transaction
            {
                Account = columns[0],
                Description = columns[1],
                CurrencyCode = columns[2],
                Amount = !string.IsNullOrWhiteSpace(columns[3]) ? decimal.Parse(columns[3]) : -1.0m
            };
            return transaction;
        }
    }
}