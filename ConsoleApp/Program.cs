using System;
using System.Collections.Generic;
using System.IO;
using ConsoleApp.UsageClasses;
using FakerLib;
using FakerLib.Impl;

namespace ConsoleApp
{
    class Program
    {
        private static readonly string PluginPath =
            Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName +
            "\\PluginGenerator\\bin\\Debug\\net5.0\\PluginGenerator.dll";

        private const int SuccessCode = 0;

        static void Main(string[] args)
        {
            Dictionary<Type, string> plugins = new();
            plugins.Add(typeof(string), PluginPath);
            
            var f = new Faker(plugins);
            A a;
            B b;
            try
            {
                a = f.Create<A>();
                b = f.Create<B>();
            }
            catch (FakerCoreException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine(SuccessCode);
        }
    }
}