using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Factories
{
    public class PaymentFactory
    {
        public IEnumerable<string> payments { get { return paymentOptions.Keys; } }

        public const string COIN = "Coin";
        public const string CARD = "Card";

        private Dictionary<string, string> paymentOptions;

        public PaymentFactory()
        {
            paymentOptions = new Dictionary<string, string>();

            paymentOptions[COIN] = "Coin";
            paymentOptions[CARD] = "Card";
        }

        public IPayment CreatePayment(string name, double insertedcoin, string gebruiker)
        {
            IPayment payment = null;

            switch(name)
            {
                case COIN:
                    payment = new CoinPayment(insertedcoin);
                    break;

                case CARD:
                    payment = new CardPayment(gebruiker);
                    break;
            }
            return payment;
        }
    }
}
