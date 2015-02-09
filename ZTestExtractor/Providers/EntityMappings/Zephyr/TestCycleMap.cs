using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Entities.Jira;
using ZTestExtractor.Entities.Zephyr;

namespace ZTestExtractor.EntityMappings.Zephyr
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
                .ForeignKey("PROJECT_ID")
                .Not.Nullable();

            HasMany<TestSchedule>(x => x.Schedules)
                .KeyColumn("CYCLE_ID")
                .Inverse()
                .Not.LazyLoad();
        }
    }
}
