using System;
using System.Collections.Generic;
using System.Reflection;
using NewRelic.Api.Agent;

namespace console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"pid={System.Diagnostics.Process.GetCurrentProcess().Id}");
            while (true)
            {
                Console.Write("Press enter...");
                Console.ReadLine();

                var assemblyFilePath = AssemblyGenerator.GenerateAssembly();
                Console.WriteLine($"Generated assembly {assemblyFilePath}");
                
                var assembly = Assembly.LoadFile(assemblyFilePath);
                var type = assembly.GetType(AssemblyGenerator.GeneratedTypeName);
                var method = type.GetMethod(AssemblyGenerator.GeneratedMethodName);
                var obj = Activator.CreateInstance(type);

                var result = method.Invoke(obj, new string[] { "Some string" });
                //Console.WriteLine(result);
            }
        }

        static void AlanStuff()
        {
            var stuff = new Dictionary<string, object>() {
                { "alan", "west" },
                { "allan", "feldman" }
            };

            for (var i = 0; i < 10; ++i)
            {
                NewRelic.Api.Agent.NewRelic.NoticeError("Bummer.", stuff);
                NewRelic.Api.Agent.NewRelic.RecordCustomEvent("AlanCouncilEvent", stuff);
                BeepBoop();
            }
        }

        [Transaction]
        static void BeepBoop()
        {
            System.Threading.Thread.Sleep(10);
        }
    }
}
