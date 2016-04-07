using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Habanero.Domain;
using NHibernate;

namespace Habanero.Persistence
{
    public interface INHibernateUnitOfWork : IUnitOfWork
    {
        ISession Session { get; }
        ISession OpenSession();
    }
}
