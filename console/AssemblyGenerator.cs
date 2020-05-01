using System;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;

namespace console
{
    public class AssemblyGenerator
    {
        public const string GeneratedAssembliesDirectoryName = "GeneratedAssemblies";
        public const string GeneratedTypeName = "MyType";
        public const string GeneratedMethodName = "MyMethod";

        public static string GenerateAssembly()
        {
            var directoryInfo = new DirectoryInfo(GeneratedAssembliesDirectoryName);
            if (!directoryInfo.Exists) directoryInfo.Create();
            var assemblyName = $"assembly{Guid.NewGuid().ToString("N")}";
            var assemblyFilePath = Path.Combine(directoryInfo.FullName, assemblyName + ".dll");

            AssemblyName aName = new AssemblyName(assemblyName);
            AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly(aName, AssemblyBuilderAccess.Save, GeneratedAssembliesDirectoryName);
            ModuleBuilder mb = ab.DefineDynamicModule(aName.Name, aName.Name + ".dll");

            TypeToken tt = mb.GetTypeToken(typeof(String)); // not sure this is needed, it supposedly forces mscorlib to be injected

            TypeBuilder tb = mb.DefineType(GeneratedTypeName, TypeAttributes.Public);
            MethodBuilder meth = tb.DefineMethod(GeneratedMethodName, MethodAttributes.Public, typeof(string), new Type[] { typeof(string) });
            ConstructorInfo classCtorInfo = typeof(NewRelic.Api.Agent.TransactionAttribute).GetConstructor(new Type[]{});
            CustomAttributeBuilder myCABuilder2 = new CustomAttributeBuilder(classCtorInfo, new object[] { });
            meth.SetCustomAttribute(myCABuilder2);
            ILGenerator methIL = meth.GetILGenerator();
            methIL.Emit(OpCodes.Ldarg_1);
            methIL.Emit(OpCodes.Ret);
            Type t = tb.CreateType();
            ab.Save(aName.Name + ".dll");

            return assemblyFilePath;
        }
    }
}
