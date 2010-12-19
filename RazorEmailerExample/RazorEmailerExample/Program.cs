using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Reflection;
using Microsoft.CSharp;

namespace RazorEmailerExample
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.ReadKey();
        }

        #region Compilation

        private static Assembly Compile(CodeCompileUnit codeCompileUnit)
        {   
            var compilerParameters = new CompilerParameters();

            compilerParameters.GenerateInMemory = true; 
            compilerParameters.ReferencedAssemblies.Add("System.dll");
            compilerParameters.ReferencedAssemblies.Add("System.Core.dll");
            compilerParameters.ReferencedAssemblies.Add("Microsoft.CSharp.dll");
            compilerParameters.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().CodeBase.Substring(8));

            var codeProvider = new CSharpCodeProvider();

            var result = codeProvider.CompileAssemblyFromDom(compilerParameters, codeCompileUnit);

            if (result.Errors.HasErrors)
            {
                foreach (var error in result.Errors)
                {
                    Console.WriteLine(error);
                }

                return null;
            }

            return result.CompiledAssembly;
        }

        #endregion
    }
}
