using System;

namespace Bank
{
    class DepositAccount : Account, IWithdraw
    {
        public DepositAccount(Customer customer, decimal interestRate, decimal balance = 0)
            : base(customer, interestRate, balance)
        {
        }

        public void Withdraw(decimal amount)
        {
            this.Balance -= amount;
        }

        public override decimal CalculateInterest(int months)
        {            

            if (this.Balance > 1000)
            {
                return base.CalculateInterest(months);
            }
            else
            {
                return 0M;
            }
        }
    }
}
