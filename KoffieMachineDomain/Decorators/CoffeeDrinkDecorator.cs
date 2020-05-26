using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Decorators
{
    public class CoffeeDrinkDecorator : BaseDrinkDecorator
    {

        public CoffeeDrinkDecorator(IDrink drink) : base(drink)
        {
            drink.Name = "Coffee";
        }

        public override double GetPrice()
        {
            return Drink.GetPrice();
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            Drink.LogDrinkMaking(log);
            log.Add($"Setting coffee strength to {DrinkStrength}.");
            log.Add("Filling with coffee...");
            log.Add($"Finished making {Name}");
        }
    }
}
