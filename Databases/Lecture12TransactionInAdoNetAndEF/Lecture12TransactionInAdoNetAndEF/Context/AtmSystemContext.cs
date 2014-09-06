namespace Lecture12TransactionInAdoNetAndEF
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Lecture12TransactionInAdoNetAndEF.Migrations;

    public class AtmSystemContext : DbContext
    {
        private static string connectionName;


        public AtmSystemContext()
            : base(AtmSystemContext.connectionName ?? "AtmSystemContext")
        {
           Database.SetInitializer(new MigrateDatabaseToLatestVersion<AtmSystemContext, Configuration>());
        }

        public AtmSystemContext(string connectionName)
            : base(connectionName)
        {
            AtmSystemContext.connectionName = connectionName;
           Database.SetInitializer(new MigrateDatabaseToLatestVersion<AtmSystemContext, Configuration>());
        }

        public virtual DbSet<CardAccount> CardAccounts { get; set; }

        public virtual DbSet<TransactionsHistory> TransactionHistoryRecords { get; set; }

    }

}