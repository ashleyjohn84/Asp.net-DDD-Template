using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habanero.Domain.Entities
{
    public class State : Entity
    {
        public virtual string Abbreviation { get; set; }
        public virtual string Name { get; set; }
        public virtual bool IsPrimaryState { get; set; }
        public virtual IEnumerable<ZipCode> ZipCodes { get; set; }
    }
}
