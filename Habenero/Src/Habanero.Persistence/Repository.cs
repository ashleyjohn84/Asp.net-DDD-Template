using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Habanero.Domain;
using Habanero.Domain.Entities;
using NHibernate;
using NHibernate.Linq;

namespace Habanero.Persistence
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly INHibernateUnitOfWork _unitOfWork;
        private ISession _session;

        public Repository(INHibernateUnitOfWork uow, ISession session)
        {
            _unitOfWork = uow;
            _session = session;
        }

        protected INHibernateUnitOfWork CurrentSession { get { return _unitOfWork; } }

        public TEntity Get(int key)
        {
            var result = _session.Get<TEntity>(key);

            if (ReferenceEquals(result, null))
            {
                var exception = new ObjectNotFoundException(key, typeof(TEntity).Name);
                throw exception;
            }
            return result;
        }

        public IQueryable<TEntity> Get()
        {
            return _session.Query<TEntity>();
        }

        public void Save(TEntity obj)
        {
            _session.SaveOrUpdate(obj);
            _session.Flush();
        }

        public void Delete(TEntity obj)
        {
            _session.Delete(obj);
            _session.Flush();
        }
    }
}
