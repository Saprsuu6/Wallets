using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Classes
{
    internal class ConverterUAH_RUB : Converter
    {
        public ConverterUAH_RUB()
        {
            naming = "UAH_RUB";
        }

        public override double Convert(double money)
        {
            return money /= 0.37;
        }
    }
}
