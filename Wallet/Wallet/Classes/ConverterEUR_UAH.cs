using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Classes
{
    internal class ConverterEUR_UAH : Converter
    {
        public ConverterEUR_UAH()
        {
            naming = "EUR_UAH";
        }

        public override double Convert(double money)
        {
            return money *= 30.98;
        }
    }
}
