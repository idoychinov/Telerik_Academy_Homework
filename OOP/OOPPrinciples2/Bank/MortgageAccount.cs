using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class MortgageAccount : Account
    {
        public MortgageAccount(Customer customer, decimal interestRate, decimal balance = 0)
            : base(customer, interestRate, balance)
        {
        }

        public override decimal CalculateInterest(int months)
        {
            int monthsWithNoInterest;

            if (this.Customer.Type == CustomerType.Individual)
            {
                monthsWithNoInterest = 3;
            }
            else if (this.Customer.Type == CustomerType.Company)
            {
                monthsWithNoInterest = 2;
            }
            else
            {
                monthsWithNoInterest = 0;
            }


            if (months > monthsWithNoInterest)
            {
                return base.CalculateInterest(months - monthsWithNoInterest);
            }
            else
            {
                return 0M;
            }
        }
    }
}
