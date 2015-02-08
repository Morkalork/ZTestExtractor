using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Entities.Jira;
using ZTestExtractor.Entities.Zephyr;

namespace ZTestExtractor.EntityMappings.Jira
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
                .ForeignKey("PROJECT")
                .Not.Nullable();

            HasMany<TestStep>(x => x.TestSteps)
                .Inverse()
                .Cascade.AllDeleteOrphan()
                .AsSet(); //All isues are unique
        }
    }
}
