using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Decorators
{
    public class CafeAuLaitDecorator : BaseDrinkDecorator
    {
        public static readonly double cafelaitprice = 0.5;

        public CafeAuLaitDecorator(IDrink drink) : base(drink)
        {
            Name = "Café au Lait";
        }

        public override double GetPrice()
        {
            return Drink.GetPrice() + cafelaitprice;
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            Drink.LogDrinkMaking(log);
            log.Add("Filling half with coffee...");
            log.Add("Filling other half with milk...");
            log.Add($"Finished making {Name}");
        }
    }
}
