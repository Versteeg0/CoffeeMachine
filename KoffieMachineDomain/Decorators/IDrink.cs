using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Decorators
{
    public interface IDrink
    {
        string Name { get; set; }
        Strength DrinkStrength { get; set; }
        double GetPrice();
       
        void LogDrinkMaking(ICollection<string> log);
    }
}
