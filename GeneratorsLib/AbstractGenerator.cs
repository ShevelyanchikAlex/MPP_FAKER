using System;

namespace GeneratorsLib
{
    public abstract class AbstractGenerator
    {
        protected readonly Random Random = new();
        protected Type TypeOfObj { get; set; }

        public abstract object Generate();
    }
}