using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Classes
{
    internal class ConverterGBR_UAH : Converter
    {
        public ConverterGBR_UAH()
        {
            naming = "GBR_UAH";
        }

        public override double Convert(double money)
        {
            return money *= 36.81;
        }
    }
}
