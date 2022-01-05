using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Classes
{
    [Serializable]
    internal class Person : IDisposable
    {
        public Person(string name, string surname, string phone)
        {
            Name = name;
            Surname = surname;
            Phone = phone;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }

        public void Dispose()
        {
            SaveLoad.SavePerson(this);
        }
    }
}
