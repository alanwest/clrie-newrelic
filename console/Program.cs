using System;
using System.Reflection;

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
    }
}
