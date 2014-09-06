namespace Lecture12TransactionInAdoNetAndEF
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Transactions;

    public class AtmTransactionApplication
    {

        const string SqlConnectionName = "AtmSystemModelSQLSERVER";
        const string SqlExpressConnectionName = "AtmSystemModelSQLEXPRESS";
        const string LocalDbConnectionName = "AtmSystemModel";
        private static AtmSystemDatabase db;

        // The tasks are in AtmSystemDatabase
        static void Main()
        {
            InitialazeDbMenu();

        }

        private static void TryCorrectWithdraw()
        {
            ConsoleUtilities.ProcessingMessage("Performing correct withdraw:");
            TryWithdraw("1234567890", "1234", 200m);
        }

        private static void TryIncorrecttWithdraw()
        {
            ConsoleUtilities.ProcessingMessage("Performing incorrect withdraw - wrong account number format");
            TryWithdraw("123", "123", 0);
            ConsoleUtilities.ProcessingMessage("Performing incorrect withdraw - wrong pin number format:");
            TryWithdraw("1234567890", "123", 10);
            ConsoleUtilities.ProcessingMessage("Performing incorrect withdraw - incorrect amount:");
            TryWithdraw("1234567890", "1234", -100);
            ConsoleUtilities.ProcessingMessage("Performing incorrect withdraw - non existing account:");
            TryWithdraw("9999999999", "1234", 300);
            ConsoleUtilities.ProcessingMessage("Performing incorrect withdraw - incorrect pin:");
            TryWithdraw("1234567890", "0000", 300);
            ConsoleUtilities.ProcessingMessage("Performing incorrect withdraw - insufficient funds:");
            TryWithdraw("1234567890", "1234", 300000);
        }

        private static void TryWithdraw(string cardNumber, string cardPin, decimal withdrawAmount)
        {
            try
            {
                var remainingFunds = db.WithdrawFromAccount(cardNumber, cardPin, withdrawAmount);
                ConsoleUtilities.SuccessMessage(string.Format("Successfully withdrawn {0} EUR from account {1}.\nRemaining funds {2:0.00} EUR", withdrawAmount, cardNumber, remainingFunds));
            }
            catch (Exception e)
            {
                ConsoleUtilities.ErrorMessage("Error while executing the withdraw - " + e.Message);
            }
        }

        private static void ReadRecords()
        {
            ConsoleUtilities.ProcessingMessage("Fetching all Card account records:");
            var accounts = db.GetRecords();
            foreach (var account in accounts)
            {
                Console.WriteLine("Card Number: {0} CardPin: {1} CardCash: {2: 0.00} EUR", account.CardNumber, account.CardPin, account.CardCash);
            }
        }


        public static void InitialazeDbMenu()
        {
            Func<string, AtmSystemDatabase> function = (x => { return new AtmSystemDatabase(x); });
            HashSet<InputActionWithParameters<string, AtmSystemDatabase>> inputActionsWithResult = new HashSet<InputActionWithParameters<string, AtmSystemDatabase>>()
            {
                new InputActionWithParameters<string,AtmSystemDatabase>(new HashSet<ConsoleKey>(){ConsoleKey.D1, ConsoleKey.NumPad1}, false, SqlConnectionName, function),
                new InputActionWithParameters<string,AtmSystemDatabase>(new HashSet<ConsoleKey>(){ConsoleKey.D2, ConsoleKey.NumPad2}, false, SqlExpressConnectionName, function),
                new InputActionWithParameters<string,AtmSystemDatabase>(new HashSet<ConsoleKey>(){ConsoleKey.D3, ConsoleKey.NumPad2}, false, LocalDbConnectionName, function)
            };
            var active = true;
            while (active)
            {
                ConsoleUtilities.MenuMessage("Chose Database to connect to:\nPress 1 for SQL Server\nPress 2 to SQL Express\nPress 3 for LocalDb\nPress ESC to exit");
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.Escape)
                {
                    return;
                }

                var action = inputActionsWithResult.SingleOrDefault(x => x.Keys.Contains(key));
                if (action == null)
                {
                    ConsoleUtilities.ErrorMessage("Wrong command. Please try again");
                    continue;
                }
                AtmTransactionApplication.db = action.ExecuteFunction();

                using (AtmTransactionApplication.db)
                {
                    MainMenu();
                }
                if (action.IsFinalAction)
                {
                    break;
                }
            }
        }

        private static void MainMenu()
        {
            HashSet<InputActionWithoutParameters> inputActionsWithResult = new HashSet<InputActionWithoutParameters>()
            {
                new InputActionWithoutParameters(new HashSet<ConsoleKey>(){ConsoleKey.D1, ConsoleKey.NumPad1}, false, ReadRecords),
                new InputActionWithoutParameters(new HashSet<ConsoleKey>(){ConsoleKey.D2, ConsoleKey.NumPad2}, false, TryCorrectWithdraw),
                new InputActionWithoutParameters(new HashSet<ConsoleKey>(){ConsoleKey.D3, ConsoleKey.NumPad2}, false, TryIncorrecttWithdraw)
            };

            var active = true;
            while (active)
            {
                ConsoleUtilities.MenuMessage("Press 1 to read records\nPress 2 to withdraw funds\nPress 3 to perform incorrect withdraw\nPress ESC to exit");

                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.Escape)
                {
                    return;
                }

                var action = inputActionsWithResult.SingleOrDefault(x => x.Keys.Contains(key));
                if (action == null)
                {
                    ConsoleUtilities.ErrorMessage("Wrong command. Please try again");
                    continue;
                }

                action.ExecuteFunction();
            }
        }

        // Alternative to using additional classes is just to make the menues with repitable code since they are not so many of them
        /*
            var active = true;
            while (active)
            {
                ConsoleUtilities.MenuMessage("Chose Database to connect to:\nPress 1 for SQL Server\nPress 2 to SQL Express\nPress 3 for LocalDb\nPress ESC to exit");

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:

                        db = new AtmSystemDatabase(SqlConnectionName);
                        active = false;
                        break;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        db = new AtmSystemDatabase(SqlExpressConnectionName);
                        active = false;
                        break;
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        db = new AtmSystemDatabase(LocalDbConnectionName);
                        active = false;
                        break;
                    case ConsoleKey.Escape:
                        active = false;
                        break;
                    default:
                        ConsoleUtilities.ErrorMessage("Wrong command. Please try again");
                        break;
                }
            }

            using (db)
            {
                MainMenu();
            }
       */
    }
}
