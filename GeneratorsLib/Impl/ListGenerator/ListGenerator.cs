using System;
using System.Collections;
using System.Collections.Generic;

namespace GeneratorsLib.Impl.ListGenerator
{
    public class ListGenerator : AbstractListGenerator
    {
        private const string InvalidConstructorCallMsg = "Invalid constructor call!";

        public ListGenerator(Dictionary<Type, AbstractGenerator> generators)
        {
            TypeOfObj = typeof(List<>);
            Generators = generators;
        }


        public ListGenerator(Dictionary<Type, AbstractGenerator> generators, int targetSize) : this(generators)
        {
            TargetSize = targetSize;
        }

        public override object Generate(Type baseType)
        {
            var generatedList = (IList) Activator.CreateInstance(typeof(List<>).MakeGenericType(baseType));
            if (generatedList == null)
            {
                throw new GeneratorException(InvalidConstructorCallMsg + baseType);
            }

            for (var i = 0; i < TargetSize; i++)
            {
                generatedList.Add(Generators[baseType].Generate());
            }

            return generatedList;
        }
    }
}