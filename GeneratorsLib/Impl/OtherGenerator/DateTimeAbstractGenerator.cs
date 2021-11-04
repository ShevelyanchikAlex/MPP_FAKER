using System;

namespace GeneratorsLib.Impl.OtherGenerator
{
    public class DateTimeAbstractGenerator : AbstractGenerator
    {
        public DateTimeAbstractGenerator()
        {
            TypeOfObj = typeof(DateTime);
        }


        public override object Generate()
        {
            return new DateTime(Random.Next(1990, 2100), Random.Next(1, 13), Random.Next(1, 30));
        }
    }
}