using System;

namespace Bank
{
    public abstract class Account :IDeposit,IIntrest
    {

        public Customer Customer { get; private set; }
        public decimal InterestRate { get; private set; }
        public decimal Balance { get; protected set; }


        public Account(Customer customer, decimal interestRate, decimal balance = 0)
        {
            this.Customer = customer;
            this.InterestRate = interestRate;
            this.Balance = balance;
        }

        public void Deposit(decimal amount)
        {
            this.Balance += amount;
        }

        public virtual decimal CalculateInterest(int months)
        {
            decimal interest = this.InterestRate * months;
            decimal interestAmount = interest * Balance;
            return interestAmount;
        }
    }
}
