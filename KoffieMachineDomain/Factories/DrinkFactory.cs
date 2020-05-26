using KoffieMachineDomain.Decorators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Factories
{
    public class DrinkFactory
    {

        public IEnumerable<string> DrinkNames { get { return drinkOptions.Keys; } }

        public const string CAFEAULAIT = "Café au Lait";
        public const string CAPPUCCINO = "Capuccino";
        public const string COFFEE = "Coffee";
        public const string ESPRESSO = "Espresso";
        public const string WIENERMELANGE = "Wiener Melange";
        public const string CHOCOLATE = "Chocolate";
        public const string DELUXE = "Chocolate Deluxe";
        public const string TEA = "Tea";
        public const string SPECIAL = "Special Coffee";
        public const string SUGAR = "Sugar";
        public const string MILK = "Milk";



        private Dictionary<string, string> drinkOptions;

        public DrinkFactory()
        {
            drinkOptions = new Dictionary<string, string>();
            drinkOptions[CAFEAULAIT] = "Café au Lait";
            drinkOptions[CAPPUCCINO] = "Capuccino";
            drinkOptions[COFFEE] = "Coffee";
            drinkOptions[ESPRESSO] = "Espresso";
            drinkOptions[WIENERMELANGE] = "Wiener Melange";
            drinkOptions[CHOCOLATE] = "Chocolate";
            drinkOptions[DELUXE] = "Chocolate Deluxe";
            drinkOptions[TEA] = "Tea";
            drinkOptions[SPECIAL] = "Special Coffee";
            drinkOptions[SUGAR] = "Sugar";
            drinkOptions[MILK] = "Milk";
        }

        public IDrink CreateDrink(string name, Strength strength, Amount sugarAmount, Amount milkAmount, bool hasSugar, bool hasMilk, string blendname, string special)
        {
            IDrink drink = new Drink(name, strength);

            if (hasSugar)
                drink = new SugarDecorator(drink, sugarAmount);

            if (hasMilk)
                drink = new MilkDecorator(drink, milkAmount);

            switch (drink.Name)
            {
                case CAFEAULAIT :
                    drink = new CafeAuLaitDecorator(drink);
                    break;

                case CAPPUCCINO :
                    drink = new CappuccinoDecorator(drink);
                    break;
                case COFFEE :
                    drink = new CoffeeDrinkDecorator(drink);
                    break;

                case ESPRESSO :
                    drink = new EspressoDecorator(drink);
                    break;

                case WIENERMELANGE:
                    drink = new WienerMelangeDecorator(drink);
                    break;

                case CHOCOLATE:
                    drink = new HotChocolateDecorator(drink, false);
                    break;

                case DELUXE:
                    drink = new HotChocolateDecorator(drink, true);
                    break;

                case TEA:
                    drink = new TeaDecorator(drink, blendname);
                    break;

                case SPECIAL:
                    drink = new SpecialCoffeeDecorator(drink, special);
                    break;
            }


            return drink;
        }
    }
}
