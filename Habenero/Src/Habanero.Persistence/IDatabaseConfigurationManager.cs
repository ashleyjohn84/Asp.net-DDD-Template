using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habanero.Persistence
{
    public interface IDatabaseConfigurationManager
    {
        string ApplicationConnectionString { get; }
    }
}
