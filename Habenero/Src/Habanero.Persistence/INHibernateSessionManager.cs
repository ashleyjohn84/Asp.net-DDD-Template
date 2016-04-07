using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace Habanero.Persistence
{
    public interface INHibernateSessionManager
    {
        string ConnectionString { get; }

        ISession OpenSession();

        IStatelessSession OpenStatelessSession();
    }
}
