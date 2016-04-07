using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Habanero.Domain;
using Habanero.Persistence;
using NHibernate;
using StructureMap.Configuration.DSL;


namespace Habanero.Bootstrap.Registries
{
    public class PersistenceRegistry : Registry
    {
        public PersistenceRegistry()
        {
            ForSingletonOf<INHibernateSessionManager>().Use<NHibernateSessionManager>();
            For<IDatabaseConfigurationManager>().Use<DatabaseConfigurationManager>();
            For<IUnitOfWork>().HybridHttpOrThreadLocalScoped().Use<NHibernateUnitOfWork>();
            For<INHibernateUnitOfWork>().HybridHttpOrThreadLocalScoped().Use<NHibernateUnitOfWork>();
            For<ISession>().HybridHttpOrThreadLocalScoped().Use(c => ((INHibernateUnitOfWork)c.GetInstance<IUnitOfWork>()).OpenSession());
            For(typeof(IRepository<>)).Use(typeof(Repository<>));
        }
    }
}
