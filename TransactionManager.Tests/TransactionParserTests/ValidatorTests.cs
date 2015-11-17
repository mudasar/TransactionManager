using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TransactionManager.Models;
using TransactionManager.Serices;

namespace TransactionManager.Tests.TransactionParserTests
{
    [TestClass]
    public class ValidatorTests
    {
        [TestMethod]
        public void Validate_valid_Transaction()
        {
            var transaction = new Transaction() {Description = "Test description", Account = "Test-Account", Amount = 4000m, CurrencyCode = "GBP"};
            var validator = new TransactionValidator();

            var validated = validator.IsTransactionValid(transaction);
            Assert.IsTrue(validated);
        }

        [TestMethod]
        public void Validate_Transaction_description_error()
        {
            var transaction = new Transaction() {  Account = "Test-Account", Amount = 4000m, CurrencyCode = "GBP" };
            var validator = new TransactionValidator();

            var validated = validator.IsTransactionValid(transaction);
            Assert.IsFalse(validated);
        }

        [TestMethod]
        public void Validate_Transaction_account_error()
        {
            var transaction = new Transaction() { Description = "Test description", Amount = 4000m, CurrencyCode = "GBP" };
            var validator = new TransactionValidator();

            var validated = validator.IsTransactionValid(transaction);
            Assert.IsFalse(validated);
        }

        [TestMethod]
        public void Validate_Transaction_amount_error()
        {
            var transaction = new Transaction() { Description = "Test description", Account = "Test-Account", Amount = -4000m, CurrencyCode = "GBP" };
            var validator = new TransactionValidator();

            var validated = validator.IsTransactionValid(transaction);
            Assert.IsFalse(validated);
        }

        [TestMethod]
        public void Validate_Transaction_currency_code_error()
        {
            var transaction = new Transaction() { Description = "Test description", Account = "Test-Account", Amount = 4000m, CurrencyCode = "GBP000" };
            var validator = new TransactionValidator();

            var validated = validator.IsTransactionValid(transaction);
            Assert.IsFalse(validated);
        }
    }
}
