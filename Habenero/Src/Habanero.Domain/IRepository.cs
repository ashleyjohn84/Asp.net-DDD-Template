using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Habanero.Domain.Entities;

namespace Habanero.Domain
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        TEntity Get(int key);
        IQueryable<TEntity> Get();
        void Save(TEntity obj);
        void Delete(TEntity obj);
    }
}
