using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Classes
{
    internal class ConverterUAH_GBR : Converter
    {
        public ConverterUAH_GBR()
        {
            naming = "UAH_GBR";
        }

        public override double Convert(double money)
        {
            return money /= 36.81;
        }
    }
}
