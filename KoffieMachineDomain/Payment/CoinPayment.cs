using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    public class CoinPayment : IPayment
    {
        private double amount;

        public CoinPayment(double insertedAmount)
        {
            amount = insertedAmount;
        }

        public double PayDrink(double insertedAmount)
        {
            insertedAmount = Math.Max(Math.Round(insertedAmount - amount, 2), 0);
            return insertedAmount;
        }
    }
}
