namespace Lecture12TransactionInAdoNetAndEF
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Transactions;

    public class AtmSystemDatabase : IDisposable
    {
        private AtmSystemContext db;

        public AtmSystemDatabase()
        {
            this.db = new AtmSystemContext();
            this.db.Database.Initialize(true);
        }

        public AtmSystemDatabase(string connectionName)
        {
            this.db = new AtmSystemContext(connectionName);
            this.db.Database.Initialize(true);
        }
 
        public AtmSystemContext Context 
        {
            get { return this.db; }
        }

        public void Dispose()
        {
            this.db.Dispose();
        }

        /// <summary>
        /// Task 1. Suppose you are creating a simple engine for an ATM machine. Create a new database "ATM" in SQL Server to hold the accounts of the card holders and the balance (money) 
        /// for each account. Add a new table CardAccounts with the following fields: 
        ///     Id (int)
        ///     CardNumber (char(10))
        ///     CardPIN (char(4))
        ///     CardCash (money)
        /// Add a few sample records in the table.
        /// 
        /// This method reads all records in table and if the DB is not present creates and initializes it.
        /// </summary>
        public IEnumerable<CardAccount> GetRecords()
        {
            return db.CardAccounts.AsEnumerable();
        }

        /// <summary>
        /// Task 2. Using transactions write a method which retrieves some money (for example $200) from certain account. 
        /// The retrieval is successful when the following sequence of sub-operations is completed successfully:
        /// A query checks if the given CardPIN and CardNumber are valid.
        /// The amount on the account (CardCash) is evaluated to see whether it is bigger than the requested sum (more than $200).
        /// The ATM machine pays the required sum (e.g. $200) and stores in the table CardAccounts the new amount (CardCash = CardCash - 200).
        /// Why does the isolation level need to be set to “repeatable read”?
        /// </summary>
        public decimal WithdrawFromAccount(string cardNumber, string cardPin, decimal withdrawAmount)
        {
            if (cardNumber == null || cardNumber == string.Empty || cardNumber.Length != 10)
            {
                throw new ArgumentException("Card number must be non null, non empty string with length exactly 10 characters!");
            }
            if (cardPin == null || cardPin == string.Empty || cardPin.Length != 4)
            {
                throw new ArgumentException("Pin must be non null, non empty string with length exactly 4 characters!");
            }
            if (withdrawAmount <= 0)
            {
                throw new ArgumentException("Withdraw amount must be greater than zero!");
            }

            // We should use repeatable read since we want the information about the account to be readable, but unchanged until the transaction has completed successfully and fully
            var transactionOptins = new TransactionOptions
            {
                IsolationLevel = System.Transactions.IsolationLevel.RepeatableRead
            };

            using (var scope = new TransactionScope(TransactionScopeOption.Required, transactionOptins))
            {
                // Throws InvalidOperationException if card number not found or if more than one card with same number is found
                var cardAccount = db.CardAccounts.Single(x => x.CardNumber == cardNumber);

                if (cardAccount.CardPin != cardPin)
                {
                    throw new ArgumentException("Supplied PIN is not correct");
                }
                if (cardAccount.CardCash - withdrawAmount < 0)
                {
                    throw new InvalidOperationException(String.Format("Insufficient funds in account for withdraw. Account amount {0:0.00} EUR;" +
                        " Withdraw amount {1:0.00} EUR", cardAccount.CardCash, withdrawAmount));
                }

                // Pays the money and saves the translation in withdraw log
                cardAccount.CardCash -= withdrawAmount;

                // Depending on how critical is to have log for each action it may be better to have the log save within the same transaction
                SaveTransactionLog(cardNumber, withdrawAmount);
                db.SaveChanges();
                scope.Complete();

                return cardAccount.CardCash;
            }
        }

        /// <summary>
        /// Task 3. Extend the project from the previous exercise and add a new table TransactionsHistory with fields (Id, CardNumber, TransactionDate, Ammount) containing 
        /// information about all money retrievals on all accounts.
        /// Modify the program logic so that it saves historical information (logs) in the new table after each successful money withdrawal.
        /// What should the isolation level be for the transaction?
        /// </summary>
        public void SaveTransactionLog(string cardNumber, decimal ammount)
        {
            var transactionOptins = new TransactionOptions
            {
                IsolationLevel = System.Transactions.IsolationLevel.RepeatableRead
            };

            using (var scope = new TransactionScope(TransactionScopeOption.Required, transactionOptins))
            {
                var transactionRecord = new TransactionsHistory() { CardNumber = cardNumber, TransactionDate = DateTime.Now, Amount = ammount };
                db.TransactionHistoryRecords.Add(transactionRecord);

                db.SaveChanges();
                scope.Complete();
            }
        }
    }
}
