using System;

namespace Bank
{
    class LoanAccount : Account
    {
        public LoanAccount(Customer customer, decimal interestRate, decimal balance = 0)
            : base(customer, interestRate, balance)
        {
        }

        public override decimal CalculateInterest(int months)
        {
            if (this.Customer.Type == CustomerType.Individual)
            {
                if (months > 6)
                {
                    return base.CalculateInterest(months - 6);
                }
                else
                {
                    return 0M;
                }
            }

            else if (this.Customer.Type == CustomerType.Company)
            {
                if (months > 12)
                {
                    return (base.CalculateInterest(12) / 2) + (base.CalculateInterest(months-12));

                }
                else
                {
                    return base.CalculateInterest(months) / 2;
                }
            }
            else
            {
                return base.CalculateInterest(months);
            }
        }
    }
}
