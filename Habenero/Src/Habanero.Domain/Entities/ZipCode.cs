using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habanero.Domain.Entities
{
    public class ZipCode : Entity
    {
        public virtual string City { get; set; }
        public virtual string Zip { get; set; }
        public virtual string County { get; set; }
        public virtual string AreaCode { get; set; }
        public virtual string Fips { get; set; }
        public virtual string TimeZone { get; set; }
        public virtual bool ObservesDST { get; set; }
        public virtual string Latitude { get; set; }
        public virtual string Longitude { get; set; }
        public virtual  State State { get; set; }
    }
}
