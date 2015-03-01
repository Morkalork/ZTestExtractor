using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Data.Entities.Jira;
using ZTestExtractor.Data.Entities.Zephyr;

namespace ZTestExtractor.Data.EntityMappings.Zephyr
{
    public class TestCycleMap : ClassMap<TestCycle>
    {
        public TestCycleMap()
        {
            Table("ao_7deabf_cycle");

            Id(x => x.Id, "ID");

            Map(x => x.CreatedBy, "CREATED_BY");
            Map(x => x.Description, "DESCRIPTION");
            Map(x => x.Name, "NAME");

            References<JiraProject>(x => x.Project)
                .Column("ID")
                .Not.Nullable();

            HasMany<TestSchedule>(x => x.Schedules)
                .KeyColumn("ID")
                .Inverse()
                .Not.LazyLoad();
        }
    }
}
