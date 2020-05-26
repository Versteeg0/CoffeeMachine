using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    public interface IPayment
    {
        double PayDrink(double insertedAmount);
    }
}
