using System;

namespace Generators.AbstractClasses
{
    public abstract class GeneratorAbstract
    {
        public Type TypeOfObj { get; set; }

        public abstract object Generate();
    }
}