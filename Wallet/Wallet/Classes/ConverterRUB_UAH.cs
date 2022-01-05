using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Classes
{
    internal class ConverterRUB_UAH : Converter
    {
        public ConverterRUB_UAH()
        {
            naming = "RUB_UAH";
        }

        public override double Convert(double money)
        {
            return money *= 0.37;
        }
    }
}
