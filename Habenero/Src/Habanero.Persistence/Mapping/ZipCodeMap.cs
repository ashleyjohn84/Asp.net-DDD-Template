using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;
using Habanero.Domain.Entities;

namespace Habanero.Persistence.Mapping
{
    public class ZipCodeMap : ClassMap<ZipCode>
    {
        public ZipCodeMap()
        {
            Table("ZipCode");
            Id(x => x.Id, "ZipCodeId").GeneratedBy.Identity();
            Map(x => x.City);
            Map(x => x.Zip);
            Map(x => x.County);
            Map(x => x.AreaCode);
            Map(x => x.Fips);
            Map(x => x.TimeZone);
            Map(x => x.ObservesDST);
            Map(x => x.Latitude);
            Map(x => x.Longitude);
            References(x => x.State).Column("StateId").Not.LazyLoad();
        }
    }
}
