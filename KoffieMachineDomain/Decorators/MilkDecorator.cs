using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Decorators
{
    public class MilkDecorator : BaseDrinkDecorator
    {
        public static readonly double MilkPrice = 0.15;
        private Amount milkAmount;

        public MilkDecorator(IDrink drink, Amount milk) : base(drink)
        {
            Drink = drink;
            milkAmount = milk;
        }

        public override double GetPrice()
        {
            return Drink.GetPrice() + MilkPrice;
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            Drink.LogDrinkMaking(log);
            log.Add($"Setting milk amount to {milkAmount}.");
            log.Add("Adding milk...");
        }
    }
}
