using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Classes
{
    [Serializable]
    internal class Wallet : IComparable
    {
        private static ulong number = 1000000000000000;
        private readonly string currency;

        public ulong CardNumber { get; private set; }
        public string Currency => currency;
        public Person Owner { get; set; }
        public double Money { get; set; }

        public Wallet(Person owner, string currency) 
        {
            if (number >= 9999999999999999)
                throw new ApplicationException("Number of card are not allowed");

            number++;
            CardNumber = number;

            this.currency = currency;
            Owner = owner;
        }

        public void AddMoney(double money)
        {
            Money += money;
        }

        public double GetMoney(double money)
        {
            if (Money < money)
                throw new ApplicationException("Not anought money");

            Money -= money;
            return money;
        }

        public int CompareTo(object? other)
        {
            return CardNumber.CompareTo((other as Wallet)?.CardNumber);
        }
    }
}
