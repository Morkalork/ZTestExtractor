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
    public class TestScheduleMap : ClassMap<TestSchedule>
    {
        public TestScheduleMap()
        {
            Table("ao_7deabf_schedule");

            Id(x => x.Id, "ID");

            Map(x => x.Assignee, "ASSIGNED_TO");
            Map(x => x.ExecutedBy, "EXECUTED_BY");
            Map(x => x.Comment, "COMMENT");
            Map(x => x.CreatedBy, "CREATED_BY");
            Map(x => x.CreatedDate, "DATE_CREATED");
            Map(x => x.Order, "ORDER_ID");
            Map(x => x.Status, "STATUS")
                .CustomType<TestStatus>();

            References<JiraIssue>(x => x.Issue)
                .ForeignKey("ISSUE_ID")
                .Not.Nullable();

            References<JiraProject>(x => x.Project)
                .ForeignKey("PROJECT_ID")
                .Not.Nullable();

            References<TestCycle>(x => x.Cycle)
                .ForeignKey("CYCLE_ID")
                .Not.Nullable();
        }
    }
}
