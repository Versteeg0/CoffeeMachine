using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace KoffieMachineDomain.JSON
{
    public class Deserializer
    {
        private List<SpecialCoffee> specialCoffees;

        public Deserializer()
        {
            string fullJSON = File.ReadAllText("C:/Users/REEE/Desktop/DPINT_Wk456_Koffiemachine-master/KoffieMachineDomain/JSON/json1.json");

            JavaScriptSerializer deserializer = new JavaScriptSerializer();
            specialCoffees = new List<SpecialCoffee>();

            var lijstje = deserializer.Deserialize<KoffieConverter>(fullJSON);
            foreach (var item in lijstje.KoffieLijst)
            {
                specialCoffees.Add(item);
            }
        }

        public List<SpecialCoffee> GetSpecialCoffees()
        {
            return specialCoffees;
        }
    }
}
