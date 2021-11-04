using System;
using System.Linq;

namespace Plugin
{
    public class StringGenerator : Generator
    {
        private const string Symbols = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz123456789";
        private const int MaxLength = 50;
        public StringGenerator()
        {
            TypeOfObj = typeof(string);
        }

        public override object Generate()
        {
            return new string(Enumerable.Repeat(Symbols, MaxLength)
                .Select(s => s[Random.Next(s.Length)]).ToArray());
        }
    }
}