using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Classes
{
    internal abstract class Converter
    {
        protected string naming = "";
        public string Naming => naming;

        public abstract double Convert(double money);
    }
}
