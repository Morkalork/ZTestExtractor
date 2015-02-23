using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Core.Entities.Jira;
using ZTestExtractor.Core.Entities.Zephyr;

namespace ZTestExtractor.Data.EntityMappings.Jira
{
    public class JiraIssueMap : ClassMap<JiraIssue>
    {
        public JiraIssueMap()
        {
            Table("jiraissue");

            Id(x => x.Id, "ID");

            Map(x => x.CreatedBy, "CREATOR");
            Map(x => x.Description, "DESCRIPTION");
            Map(x => x.Summary, "SUMMARY");

            References<JiraProject>(x => x.Project)
                .Column("ID")
                .Not.Nullable();

            HasMany<TestStep>(x => x.TestSteps)
                .KeyColumn("ID")
                .Inverse()
                .Cascade.AllDeleteOrphan()
                .AsSet(); //All isues are unique
        }
    }
}
