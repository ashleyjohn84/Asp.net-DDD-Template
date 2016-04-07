using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habanero.Domain.Entities
{
    public class Entity
    {
        public virtual int Id { get; private set; }

        public override bool Equals(object obj)
        {
            var other = (Entity)obj;
            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
