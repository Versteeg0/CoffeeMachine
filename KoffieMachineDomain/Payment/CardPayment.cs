using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    public class CardPayment : IPayment
    {
        public Dictionary<string, double> CashOncards { get; set; }
        public string Username { get; set; }


        public CardPayment(string username)
        {
            CashOncards = new Dictionary<string, double>();
            Username = username;

            CashOncards["Arjen"] = 5.0;
            CashOncards["Bert"] = 3.5;
            CashOncards["Chris"] = 7.0;
            CashOncards["Daan"] = 6.0;
        }

        public double PayDrink(double insertedAmount)
        {
            if (insertedAmount <= CashOncards[Username])
            {
                CashOncards[Username] -= insertedAmount;
                insertedAmount = 0;
                
            }
            else // Pay what you can, fill up with coins later.
            {
                insertedAmount -= CashOncards[Username];
                CashOncards[Username] = 0;
            }
            return insertedAmount;
        }
    }
}
