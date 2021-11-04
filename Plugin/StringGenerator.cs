using System;
using System.Linq;

namespace Plugin
{
    public class StringGenerator : Generator
    {
        public StringGenerator()
        {
            TypeOfObj = typeof(string);
        }

        public override object Generate()
        {
            const int length = 100;
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[Random.Next(s.Length)]).ToArray());
        }
    }
}