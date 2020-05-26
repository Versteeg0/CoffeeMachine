using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaAndChocoLibrary;

namespace KoffieMachineDomain.Decorators
{
    public class HotChocolateDecorator : BaseDrinkDecorator
    {
        private HotChocolate chocolatedrink;

        public HotChocolateDecorator(IDrink drink, bool deluxe) : base(drink)
        {
            Drink = drink;
            chocolatedrink = new HotChocolate();

            if (deluxe)
                chocolatedrink.MakeDeluxe();
        }

        public override double GetPrice()
        {
            return Drink.GetPrice() + chocolatedrink.Cost();
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            Drink.LogDrinkMaking(log);

            foreach (string s in chocolatedrink.GetBuildSteps())
                log.Add(s);
        }

    }
}
