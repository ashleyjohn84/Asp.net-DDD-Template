using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Habanero.Services;
using StructureMap.Configuration.DSL;

namespace Habanero.Bootstrap.Registries
{
    public class ServicesRegistry : Registry
    {
        public ServicesRegistry()
        {
            For<IStateService>().Use<StateService>();
            For<IZipService>().Use<ZipService>();
        }
    }
}
