using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Classes
{
    [Serializable]
    internal class WalletsBase : IEnumerable, IEnumerator, IDisposable
    {
        public List<Wallet> Wallets { get; }
        public List<Converter> Converters { get; private set; }

        [NonSerialized]
        private int position = -1;
        public object Current 
        { 
            get
            {
                if (position == -1 || position >= Wallets.Count)
                    throw new InvalidOperationException();

                return Wallets[position];
            }
        }

        public WalletsBase(List<Wallet> wallets)
        {
            Wallets = wallets;
            Converters = new List<Converter>()
            {
                new ConverterUAH_USD(),
                new ConverterUSD_UAH(),

                new ConverterUAH_EUR(),
                new ConverterEUR_UAH(),

                new ConverterUAH_GBR(),
                new ConverterGBR_UAH(),

                new ConverterUAH_RUB(),
                new ConverterRUB_UAH()
            };
        }

        public void Dispose()
        {
            SaveLoad.SaveWallets(Wallets);
        }

        public void AddWallet(Wallet wallet)
        {
            Wallets.Add(wallet);
            Wallets.Sort();
        }

        public void RemoveWallet(ulong number)
        {
            foreach (Wallet wallet in Wallets)
            {
                if (wallet.CardNumber == number)
                {
                    Wallets.Remove(wallet);
                    Wallets.Sort();
                    return;
                }
            }

            throw new ApplicationException("Wallet are not found");
        }

        public void TransferMoney(ulong numberSender, ulong numberRecipient, double money)
        {
            double convertedMoney = 0;
            Wallet? wallet1 = null;
            Wallet? wallet2 = null;

            foreach(Wallet wallet in Wallets)
            {
                if (wallet.CardNumber == numberSender)
                    wallet1 = wallet;

                else if (wallet.CardNumber == numberRecipient)
                    wallet2 = wallet;
            }

            if (wallet1?.Currency != wallet2?.Currency)
            {
                string naming = wallet1?.Currency + wallet2?.Currency;

                foreach (Converter converter in Converters)
                {
                    if (converter.Naming == naming)
                        convertedMoney = converter.Convert(money);
                }
            }

            wallet1?.GetMoney(money);
            wallet2?.AddMoney(convertedMoney);
        }

        public IEnumerator GetEnumerator()
        {
            return Wallets.GetEnumerator();
        }

        public bool MoveNext()
        {
            if (position < Wallets.Count - 1)
            {
                position++;
                return true;
            }
            else
                return false;
        }

        public void Reset()
        {
            position = -1;
        }

        public Wallet this[ulong number]
        {
            get
            {
                Wallet? currentWallet = null;

                foreach(Wallet wallet in Wallets)
                {
                    if (wallet.CardNumber == number)
                        currentWallet = wallet;
                }

                if (currentWallet == null)
                    throw new ApplicationException("Wallet was not found");

                return currentWallet;
            }
        }
    }
}
