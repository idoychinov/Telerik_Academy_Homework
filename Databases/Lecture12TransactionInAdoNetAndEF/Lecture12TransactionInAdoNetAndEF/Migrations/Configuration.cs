namespace Lecture12TransactionInAdoNetAndEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AtmSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(AtmSystemContext context)
        {

            context.CardAccounts.AddOrUpdate(
              p => p.Id,
              new CardAccount { Id = 1, CardNumber = "1234567890", CardPin = "1234", CardCash = 1000m },
              new CardAccount { Id = 2, CardNumber = "4213412312", CardPin = "4241", CardCash = 500.2m },
              new CardAccount { Id = 3, CardNumber = "8252612342", CardPin = "2211", CardCash = 10043.0m },
              new CardAccount { Id = 4, CardNumber = "0000000000", CardPin = "5321", CardCash = 13.43m },
              new CardAccount { Id = 5, CardNumber = "1232543124", CardPin = "0000", CardCash = 200m }

            );
        }
    }
}
