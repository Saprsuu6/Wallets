using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Classes
{
    internal class ConverterUSD_UAH : Converter
    {
        public ConverterUSD_UAH()
        {
            naming = "USD_UAH";
        }

        public override double Convert(double money)
        {
            return money *= 27.29;
        }
    }
}
