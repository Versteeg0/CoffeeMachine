using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Decorators
{
    public class EspressoDecorator : BaseDrinkDecorator
    {
        public static readonly double espressoprice = 0.5;

        public EspressoDecorator(IDrink drink) : base(drink)
        {
            Drink = drink;
        }
        public override double GetPrice()
        {
            return Drink.GetPrice() + espressoprice;
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            Drink.LogDrinkMaking(log);
            log.Add($"Setting coffee strength to {Strength.Strong}.");
            log.Add($"Setting coffee amount to {Amount.Few}.");
            log.Add("Filling with coffee...");
            log.Add("Creaming milk...");
            log.Add("Adding milk to coffee...");
            log.Add($"Finished making {Name}");
        }
    }
}
