using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Decorators
{
    public class CappuccinoDecorator : BaseDrinkDecorator
    {
        public static readonly double cappuccinoprice = 0.5;

        public CappuccinoDecorator(IDrink drink) : base(drink)
        {
            Drink = drink;
        }

        public override double GetPrice()
        {
            return Drink.GetPrice() + cappuccinoprice;
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            Drink.LogDrinkMaking(log);
            log.Add($"Setting Cappuccino strength to {DrinkStrength}.");
            log.Add("Filling with coffee...");
            log.Add("Creaming milk...");
            log.Add("Adding milk to coffee...");
            log.Add($"Finished making {Name}");
        }
    }
}
