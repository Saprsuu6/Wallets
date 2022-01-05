using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Classes
{
    [Serializable]
    internal class Consumption
    {
        private readonly string reason;
        private readonly double money;
        private readonly string currency;
        private readonly DateTime date;

        public Consumption(string reason, double money, string currency, DateTime date)
        {
            this.reason = reason;
            this.money = money;
            this.currency = currency;
            this.date = date;
        }

        public string Reason => reason;
        public double Money => money;
        public string Currency => currency;
        public DateTime Date => date;
    }
}
