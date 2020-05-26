using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.JSON
{
    public class SpecialCoffee
    {
        public string Naam { get; set; }
        public double Prijs { get; set; }
        public List<string> Ingredienten { get; set; }
    }
}
