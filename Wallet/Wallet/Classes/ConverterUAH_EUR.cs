using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Classes
{
    internal class ConverterUAH_EUR : Converter
    {
        public ConverterUAH_EUR()
        {
            naming = "UAH_EUR";
        }

        public override double Convert(double money)
        {
            return money /= 30.98;
        }
    }
}
