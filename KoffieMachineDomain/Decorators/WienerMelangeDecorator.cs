using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Decorators
{
    public class WienerMelangeDecorator : BaseDrinkDecorator
    {
        public static readonly double wienermelangeprice = 1;

        public WienerMelangeDecorator(IDrink drink) : base(drink)
        {
            Drink = drink;
        }

        public override double GetPrice()
        {
            return Drink.GetPrice() + wienermelangeprice;
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            Drink.LogDrinkMaking(log);
            log.Add($"Setting coffee strength to {DrinkStrength}.");
            log.Add("Filling with coffee...");
            log.Add("Creaming milk...");
            log.Add("Adding milk to coffee...");
            log.Add($"Finished making {Name}");
        }
    }
}
