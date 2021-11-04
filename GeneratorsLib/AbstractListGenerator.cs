using System;
using System.Collections.Generic;

namespace GeneratorsLib
{
    public abstract class AbstractListGenerator
    {
        protected int TargetSize = 16;
        protected Type TypeOfObj { get; set; }

        protected Dictionary<Type, AbstractGenerator> Generators;

        public abstract object Generate(Type baseType);
    }
}