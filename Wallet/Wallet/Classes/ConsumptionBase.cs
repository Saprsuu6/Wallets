using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Classes
{
    [Serializable]
    internal class ConsumptionBase : IEnumerable, IEnumerator, IDisposable
    {
        public List<Consumption> Consumptions { get; }

        private int position = -1;

        public object Current
        {
            get
            {
                if (position == -1 || position >= Consumptions.Count)
                    throw new InvalidOperationException();

                return Consumptions[position];
            }
        }

        public ConsumptionBase(List<Consumption> consumptions)
        {
            Consumptions = consumptions;
        }

        public void Dispose()
        {
            SaveLoad.SaveConsumptions(Consumptions);
        }

        public void AddConsumption(Consumption consumption)
        {
            Consumptions.Add(consumption);
        }

        public IEnumerator GetEnumerator()
        {
            return Consumptions.GetEnumerator();
        }

        public bool MoveNext()
        {
            if (position < Consumptions.Count - 1)
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

        public List<Consumption> this[string reason]
        {
            get
            {
                List<Consumption> consumptions = new List<Consumption>();

                foreach (Consumption consumption in Consumptions)
                {
                    if (consumption.Reason.Contains(reason))
                        consumptions.Add(consumption);
                }

                if (consumptions.Count == 0)
                    throw new ApplicationException("Consumption(s) was not found");

                return consumptions;
            }
        }

        public List<Consumption> this[double money]
        {
            get
            {
                List<Consumption> consumptions = new List<Consumption>();

                foreach (Consumption consumption in Consumptions)
                {
                    if (consumption.Money == money)
                        consumptions.Add(consumption);
                }

                if (consumptions.Count == 0)
                    throw new ApplicationException("Consumption(s) was not found");

                return consumptions;
            }
        }

        public List<Consumption> this[DateTime date]
        {
            get
            {
                List<Consumption> consumptions = new List<Consumption>();

                foreach (Consumption consumption in Consumptions)
                {
                    if (consumption.Date == date)
                        consumptions.Add(consumption);
                }

                if (consumptions.Count == 0)
                    throw new ApplicationException("Consumption(s) was not found");

                return consumptions;
            }
        }
    }
}
