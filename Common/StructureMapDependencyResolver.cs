using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using StructureMap;

namespace Common
{
    // ref: http://blogs.msdn.com/b/elee/archive/2010/11/19/asp-net-mvc-3-idependencyresolver-and-structuremap.aspx
    public class StructureMapDependencyResolver : IDependencyResolver
    {
        readonly IContainer _container;

        public StructureMapDependencyResolver(IContainer container)
        {
            _container = container;

            // TODO: is this actually necessary?
            _container.Configure(x => x.Scan(y =>
            {
                y.AssembliesFromApplicationBaseDirectory();
                y.AddAllTypesOf<IController>()
                    .NameBy(z => z.Name.Replace("Controller", "").ToLower());
            }));
        }

        public object GetService(Type serviceType)
        {
            if (serviceType.IsClass)
            {
                return GetConcreteService(serviceType);
            }
            else
            {
                return GetInterfaceService(serviceType);
            }
        }

        private object GetConcreteService(Type serviceType)
        {
            try
            {
                // Can't use TryGetInstance here because it won’t create concrete types
                return _container.GetInstance(serviceType);
            }
            catch (StructureMapException)
            {
                return null;
            }
        }

        private object GetInterfaceService(Type serviceType)
        {
            return _container.TryGetInstance(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.GetAllInstances(serviceType).Cast<object>();
        }
    }
}