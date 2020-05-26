using KoffieMachineDomain.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Decorators
{
    public class SpecialCoffeeDecorator : BaseDrinkDecorator
    {
        private Deserializer deserializer;
        private SpecialCoffee specialCoffee;

        public SpecialCoffeeDecorator(IDrink drink, string special) : base(drink)
        {
            Drink = drink;
            deserializer = new Deserializer();
            specialCoffee = new SpecialCoffee();

            foreach (var item in deserializer.GetSpecialCoffees())
            {
                if(item.Naam == special)
                {
                    specialCoffee = item;
                    Name = specialCoffee.Naam;
                }
            }
        }

        public override double GetPrice()
        {
            return Drink.GetPrice() + specialCoffee.Prijs - 1;
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            Drink.LogDrinkMaking(log);

            foreach (string s in specialCoffee.Ingredienten)
            {
                log.Add($"Adding... {s} ");
                
            }
            log.Add($"Finished making {Name}");

        }
    }
}
