using System.Web.Http;
using System.Web.Mvc;
using GoalTracker.BootStrap.DependencyResolution;
using Habanero.Domain.Entities;
using StructureMap;
using StructureMap.Graph;

namespace Habanero.Bootstrap.DependencyResolution
{
    public static class BootStrapper
    {
        public static void Bootstrap()
        {
            IContainer container = InitializeStructureMap();
            SetDependencyResolver(container);
        }

        public static IContainer InitializeStructureMap()
        {
            ObjectFactory.Initialize(x => x.Scan(scan =>
            {
                scan.AssemblyContainingType<Entity>();
                scan.LookForRegistries();
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
            }));
            return ObjectFactory.Container;

        }

        public static void SetDependencyResolver(IContainer container)
        {
            DependencyResolver.SetResolver(new StructureMapDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new StructureMapDependencyResolver(container);
        }

    }
}
