using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Reflection;
using System.Web.Razor;
using Microsoft.CSharp;
using System.Linq;

namespace RazorEmailerExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new RazorEngineHost(new CSharpRazorCodeLanguage());
            host.NamespaceImports.Add("System");
            host.DefaultBaseClass = typeof (EmailTemplateBase).FullName;

            var engine = new RazorTemplateEngine(host);

            var templateText = "Hi @Model.Name";

            var reader = new StringReader(templateText);

            var code = engine.GenerateCode(reader);

            var assembly = Compile(code.GeneratedCode);

            if (assembly != null)
            {
                var templateType = assembly.GetTypes().First();

                foreach (var person in Person.ListAll())
                {
                    var template = (EmailTemplateBase)Activator.CreateInstance(templateType);

                    template.Model = person;
                    template.Execute();

                    Console.WriteLine(template.Result);
                }
            }

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
