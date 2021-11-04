using System;
using Generators.AbstractClasses;

namespace Generators.Impl
{
    public class BoolGenerator : GeneratorAbstract
    {
        private readonly Random _random;


        public BoolGenerator()
        {
            TypeOfObj = typeof(bool);
            _random = new Random();
        }


        public override object Generate()
        {
            return _random.Next(10) < 5;
        }
    }
}