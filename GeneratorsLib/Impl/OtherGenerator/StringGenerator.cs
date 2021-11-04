using System;
using System.Linq;

namespace GeneratorsLib.Impl.OtherGenerator
{
    public class StringGenerator : AbstractGenerator
    {
        private const string Symbols = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz123456789";
        private const int MaxLength = 50;

        public override object Generate()
        {
            return new string(Enumerable.Repeat(Symbols, MaxLength)
                .Select(s => s[Random.Next(s.Length)]).ToArray());
        }
    }
}