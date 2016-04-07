using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace Habanero.Persistence
{
    public class NHibernateSessionManager :INHibernateSessionManager
    {
         private readonly string _connectionString;

        private readonly Lazy<ISessionFactory> _sessionFactory;

        public NHibernateSessionManager(IDatabaseConfigurationManager databaseConfigurationManager)
        {
            _connectionString = databaseConfigurationManager.ApplicationConnectionString;
            _sessionFactory = new Lazy<ISessionFactory>(CreateSessionFactory);
        }

        public string ConnectionString { get { return _connectionString; } }

        public ISession OpenSession()
        {
            return _sessionFactory.Value.OpenSession();
        }

        public IStatelessSession OpenStatelessSession()
        {
            return _sessionFactory.Value.OpenStatelessSession();
        }

        private ISessionFactory CreateSessionFactory()
        {

            MsSqlConfiguration msSqlConfiguration = MsSqlConfiguration.MsSql2008.ConnectionString(_connectionString).AdoNetBatchSize(1000);
            return Fluently.Configure()
                     .Database(msSqlConfiguration)
                     .Mappings(Mappings())
                     .BuildSessionFactory();
        }

        private static Action<MappingConfiguration> Mappings()
        {
            return m => m.FluentMappings.AddFromAssemblyOf<NHibernateSessionManager>()
                .Conventions.AddFromAssemblyOf<NHibernateSessionManager>();
        }
    }
    
}
