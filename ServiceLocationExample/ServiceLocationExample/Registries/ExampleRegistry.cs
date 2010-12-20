using System.Web.Mvc;
using ServiceLocationExample.Models;
using StructureMap.Configuration.DSL;

namespace ServiceLocationExample.Registries
{
    public class ExampleRegistry : Registry
    {
        public ExampleRegistry()
        {
            RegisterControllers();
        }

        private void RegisterControllers()
        {
            Scan(x =>
                {
                    x.TheCallingAssembly();

                    x.AddAllTypesOf<Controller>().NameBy(t => t.Name);
                });
        }
    }
}