using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaAndChocoLibrary;

namespace KoffieMachineDomain.Decorators
{
    public class TeaDecorator : BaseDrinkDecorator
    {
        private Tea teadrink;
        private TeaBlendRepository teaBlendRepository;

        public TeaDecorator(IDrink drink, string blendname) : base(drink)
        {
            Drink = drink;
            teadrink = new Tea();
            teaBlendRepository = new TeaBlendRepository();

            if (blendname != null)
                teadrink.Blend = teaBlendRepository.GetTeaBlend(blendname);
        }

        public override double GetPrice()
        {
            return Drink.GetPrice() + Tea.Price - 1;
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            Drink.LogDrinkMaking(log);
            log.Add($"Setting Tea strength to {DrinkStrength}.");
            log.Add($"Filling with Hot water and {teadrink.Blend.Name}...");
            log.Add($"Finished making {Name}");
        }
    }
}
