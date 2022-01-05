using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Wallet.Classes
{
    internal class Regular
    {
        private static Regex name = new Regex(@"^\S[^\/:*?""<>|]*$");
        private static Regex suraname = new Regex(@"^\S[^\/:*?""<>|]*$");
        private static Regex number = new Regex(@"^\s*\+?3?8?(0\d{2}\d{3}\d{2}\d{2})\s*$");

        public static bool CheckName(string name)
        {
            return Regular.name.IsMatch(name);
        }

        public static bool CheckSurname(string numeric)
        {
            return suraname.IsMatch(numeric);
        }

        public static bool CheckNumber(string numeric)
        {
            return number.IsMatch(numeric);
        }

        public static Regex HasName { get => name; }
        public static Regex HasNumericWithDotWithoutMass { get => suraname; }
        public static Regex NumericWithoutDot { get => number; }
    }
}
