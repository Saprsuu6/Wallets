using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Classes
{
    internal class ConverterUAH_USD : Converter
    {
        public ConverterUAH_USD(string naming)
        {
            naming = "UAH_USD";
        }

        public override double Convert(double money)
        {
            return money /= 27.29;
        }
    }
}
