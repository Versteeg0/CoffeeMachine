using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Decorators
{
    public class BaseDrinkDecorator : IDrink
    {
        public string Name { get { return Drink.Name; } set { Drink.Name = value; } }

        public Strength DrinkStrength { get { return Drink.DrinkStrength; } set { Drink.DrinkStrength = value; } }

        public IDrink Drink;

        public virtual double GetPrice()
        {
            return Drink.GetPrice();
        }

        public virtual void LogDrinkMaking(ICollection<string> log)
        {
            Drink.LogDrinkMaking(log);
        }

        public BaseDrinkDecorator(IDrink drink)
        {
            Drink = drink;
        }
    }
}
