namespace AtmSystemTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using System.Data.Entity;

    using Lecture12TransactionInAdoNetAndEF;

    [TestClass]
    public class TestWithdraw
    {
        private AtmSystemDatabase db;

        [TestInitialize]
        public void Initialize()
        {
            db = new AtmSystemDatabase();
        }

        [TestCleanup]
        public void Cleenup()
        {
            db.Dispose();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TryWithdrawWithIncorrectAccountFormat()
        {
            db.WithdrawFromAccount("123", "123", 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TryWithdrawWithIncorrectPinFormat()
        {
            db.WithdrawFromAccount("1234567890", "123", 10); ;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TryWithdrawWithIncorrectAmount()
        {
            db.WithdrawFromAccount("1234567890", "1234", -100);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TryWithdrawFromNonExistingAccount()
        {
            db.WithdrawFromAccount("9999999999", "1234", 300);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TryWithdrawWithInncorrectPin()
        {
            db.WithdrawFromAccount("1234567890", "0000", 300);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TryWithdrawFromAccountWithInsufficientFunds()
        {
            db.WithdrawFromAccount("1234567890", "1234", 300000);
        }

        [TestMethod]
        public void TestCorrectWithdraw()
        {
            var record = db.GetRecords().SingleOrDefault(x => x.Id == 1);
            var startAmount = record.CardCash;

            var remainingAmount = db.WithdrawFromAccount(record.CardNumber, record.CardPin, 200);
            Assert.AreEqual(startAmount - 200, remainingAmount, "Incorrect withdraw");
        }

        [TestMethod]
        public void TestLogging()
        {
            var record = db.GetRecords().SingleOrDefault(x => x.Id == 1);
            var startAmount = record.CardCash;
            var transactionLogs = db.Context.TransactionHistoryRecords;
            var lastLogTime = transactionLogs.Max(x => x.TransactionDate);
            var logsCount = transactionLogs.Count();

            var remainingAmount = db.WithdrawFromAccount(record.CardNumber, record.CardPin, 200);

            Assert.AreEqual(logsCount+1, transactionLogs.Count(), "No log Added");
            var newLog = transactionLogs.Single(x => x.TransactionDate > lastLogTime);
            Assert.IsTrue(newLog.Amount == 200 && newLog.CardNumber == record.CardNumber);
        }
    }
}
