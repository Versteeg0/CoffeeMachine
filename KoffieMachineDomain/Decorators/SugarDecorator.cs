using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Decorators
{
    public class SugarDecorator : BaseDrinkDecorator
    {
        public static readonly double SugarPrice = 0.1;
        private Amount sugarAmount;

        public SugarDecorator(IDrink drink, Amount sugar) : base(drink)
        {
            Drink = drink;
            sugarAmount = sugar;
        }

        public override double GetPrice()
        {
            return Drink.GetPrice() + SugarPrice;
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            Drink.LogDrinkMaking(log);
            log.Add($"Setting sugar amount to {sugarAmount}.");
            log.Add("Adding sugar...");
        }
    }
}
