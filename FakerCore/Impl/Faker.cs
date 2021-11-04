using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GeneratorsLib;
using GeneratorsLib.Impl.ListGenerator;
using GeneratorsLib.Impl.OtherGenerator;
using GeneratorsLib.Impl.PrimTypeGenerator;


namespace FakerLib.Impl
{
    public class Faker : IFaker
    {
        private const string ClassHasNoEmptyConstructorMsg =
            "Class hasn't empty constructor. Class must have empty constructor!";

        private const string RecursiveTypeMsg = "Recursive type!";
        private const string GenerationExceptionMsg = "Cannot generate value for property with type!";


        private readonly Dictionary<Type, AbstractGenerator> _primTypeGenerators = new();
        private readonly Dictionary<Type, AbstractListGenerator> _listGenerators = new();
        private readonly Dictionary<Type, AbstractGenerator> _dateTimeGenerators = new();
        private readonly Dictionary<Type, AbstractGenerator> _pluginGenerators = new();
        private readonly Stack<Type> _types = new();

        public Faker(Dictionary<Type, string> pluginPaths)
        {
            _primTypeGenerators.Add(typeof(bool), new BoolGenerator());
            _primTypeGenerators.Add(typeof(byte), new ByteGenerator());
            _primTypeGenerators.Add(typeof(double), new DoubleGenerator());
            _primTypeGenerators.Add(typeof(float), new FloatGenerator());
            _primTypeGenerators.Add(typeof(int), new IntGenerator());
            _primTypeGenerators.Add(typeof(long), new LongGenerator());
            _dateTimeGenerators.Add(typeof(DateTime), new DateTimeAbstractGenerator());

            LoadPlugins(pluginPaths);

            var allGenerators = new Dictionary<Type, AbstractGenerator>();
            _primTypeGenerators.ToList().ForEach(entry => allGenerators.Add(entry.Key, entry.Value));
            _listGenerators.Add(typeof(List<>), new ListGenerator(allGenerators));
            _pluginGenerators.ToList().ForEach(entry => allGenerators.Add(entry.Key, entry.Value));
        }

        private void LoadPlugins(Dictionary<Type, string> pluginPaths)
        {
            foreach (var (key, value) in pluginPaths)
            {
                _pluginGenerators.Add(key, LoadPlugin(value, key));
            }
        }

        private static AbstractGenerator LoadPlugin(string path, Type generatorType)
        {
            var assembly = Assembly.LoadFrom(path);
            var types = assembly.GetTypes();
            return types.Select(type => (AbstractGenerator) Activator.CreateInstance(type))
                .FirstOrDefault(instance => instance != null && instance.GetType() == generatorType);
        }

        public T Create<T>() where T : class
        {
            _types.Push(typeof(T));
            return GenerateInstance(typeof(T)) as T;
        }

        private object GenerateInstance(Type type)
        {
            var constructor = type.GetConstructor(Type.EmptyTypes);
            if (constructor == null)
            {
                throw new FakerCoreException(ClassHasNoEmptyConstructorMsg);
            }

            var instance = constructor.Invoke(Array.Empty<object>());
            GenerateProperties(ref instance);
            return instance;
        }

        private void GenerateProperties(ref dynamic instance)
        {
            var properties = instance.GetType().GetProperties();
            foreach (var property in properties)
            {
                if (!(property?.CanWrite ?? false) || (property?.SetMethod.IsPrivate ?? false))
                    continue;
                GenerateValue(ref instance, property);
            }
        }

        private void GenerateValue(ref dynamic instance, dynamic property)
        {
            if (TryGetPrimTypeGenerator(property.PropertyType, out AbstractGenerator baseGenerator))
            {
                property.SetValue(instance, baseGenerator.Generate());
            }
            else if (TryGetPluginGenerator(property.PropertyType, out AbstractGenerator pluginGenerator))
            {
                property.SetValue(instance, pluginGenerator.Generate());
            }
            else if (!IsRecursiveType(property.PropertyType))
            {
                _types.Push(property.PropertyType);
                property.SetValue(instance, GenerateInstance(property.PropertyType));
            }
            else if (TryGetListGenerator(property.PropertyType, out AbstractListGenerator listGenerator))
            {
                Type itemType = property.PropertyType.GetGenericArguments()[0];
                if (IsRecursiveType(itemType))
                {
                    throw new FakerCoreException(RecursiveTypeMsg +
                                                 property.PropertyType.ToString());
                }

                property.SetValue(instance, listGenerator.Generate(itemType));
            }
            else if (IsRecursiveType(property.PropertyType))
            {
                throw new FakerCoreException(RecursiveTypeMsg +
                                             property.PropertyType.ToString());
            }
            else
            {
                throw new FakerCoreException(GenerationExceptionMsg +
                                             property.PropertyType.ToString());
            }
        }

        private bool TryGetPrimTypeGenerator(Type type, out AbstractGenerator abstractGenerator)
        {
            return _primTypeGenerators.TryGetValue(type, out abstractGenerator);
        }

        private bool TryGetListGenerator(Type type, out AbstractListGenerator generator)
        {
            return _listGenerators.TryGetValue(type.GetGenericTypeDefinition(), out generator);
        }

        private bool TryGetPluginGenerator(Type type, out AbstractGenerator abstractGenerator)
        {
            return _pluginGenerators.TryGetValue(type, out abstractGenerator);
        }

        private bool IsRecursiveType(Type type)
        {
            return _types.Contains(type);
        }
    }
}