using KoffieMachineDomain.Decorators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    public class Drink : IDrink
    {
        protected const double BaseDrinkPrice = 1.0;
       
        public string Name { get; set; }
        public Strength DrinkStrength { get; set; }

        public Drink(string name, Strength strength)
        {
            Name = name;
            DrinkStrength = strength;
        }

        public double GetPrice() {
            return BaseDrinkPrice;
        }

        public virtual void LogDrinkMaking(ICollection<string> log)
        {
            log.Add($"Making {Name}...");
            log.Add($"Heating up...");
        }
    }
}
