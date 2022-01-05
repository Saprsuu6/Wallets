using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Wallet.Classes
{
    internal class SaveLoad
    {
        public static void SaveWallets(List<Wallet> wallets)
        {
            Directory.CreateDirectory("DataBase");

            using (FileStream stream = new FileStream("DataBase/Wallets.json", FileMode.Create))
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Wallet>));
                jsonFormatter.WriteObject(stream, wallets);
            }
        }

        public static void SaveConsumptions(List<Consumption> consumptions)
        {
            Directory.CreateDirectory("DataBase");

            using (FileStream stream = new FileStream("DataBase/Wallets.json", FileMode.Create))
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Consumption>));
                jsonFormatter.WriteObject(stream, consumptions);
            }
        }

        public static void SavePerson(Person person)
        {
            Directory.CreateDirectory("DataBase");

            using (FileStream stream = new FileStream("DataBase/PersonInfo.json", FileMode.Create))
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Person));
                jsonFormatter.WriteObject(stream, person);
            }
        }

        public static List<Wallet> LoadWallets()
        {
            List<Wallet>? wallets = new List<Wallet>();
            FileStream? stream = null;

            try
            {
                stream = new FileStream("DataBase/Consumptions.json", FileMode.Open);
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Wallet>));
                wallets = jsonFormatter.ReadObject(stream) as List<Wallet>;
                stream.Close();
            }
            catch (Exception e)
            {
                stream?.Close();
                return wallets;
            }

            return wallets;
        }

        public static List<Consumption> LoadConsumptions()
        {
            List<Consumption>? consumptions = new List<Consumption>();
            FileStream? stream = null;

            try
            {
                stream = new FileStream("DataBase/Consumptions.json", FileMode.Open);
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Consumption>));
                consumptions = jsonFormatter.ReadObject(stream) as List<Consumption>;
                stream.Close();
            }
            catch (Exception e)
            {
                stream?.Close();
                return consumptions;
            }

            return consumptions;
        }

        public static Person LoadPerson()
        {
            Person? person = new Person();
            FileStream? stream = null;

            try
            {
                stream = new FileStream("DataBase/Consumptions.json", FileMode.Open);
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Person));
                person = jsonFormatter.ReadObject(stream) as Person;
                stream.Close();
            }
            catch (Exception e)
            {
                stream?.Close();
                return person;
            }

            return person;
        }
    }
}
