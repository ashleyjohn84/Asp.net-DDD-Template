using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habanero.Persistence
{
    public class DatabaseConfigurationManager : IDatabaseConfigurationManager
    {
        public string ApplicationConnectionString { get { return ConfigurationManager.ConnectionStrings["ApplicationDatabase"].ConnectionString; } }
    }
}
