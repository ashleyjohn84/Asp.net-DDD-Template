using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Habanero.Domain.Entities;

namespace Habanero.Persistence.Mapping
{
    public class StateMap : ClassMap<State>
    {
        public StateMap()
        {
            Table("State");
            Id(x => x.Id, "StateId").GeneratedBy.Identity();
            Map(x => x.Name);
            Map(x => x.IsPrimaryState);
            Map(x => x.Abbreviation);
            HasMany(x => x.ZipCodes).Inverse().KeyColumn("StateId");
        }
    }
}
