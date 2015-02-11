using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Core.Entities.Jira;

namespace ZTestExtractor.Data.EntityMappings.Jira
{
    public class ProjectMap : ClassMap<JiraProject>
    {
        public ProjectMap()
        {
            Table("project");

            Id(x => x.Id, "ID");

            Map(x => x.Key, "pkey");
            Map(x => x.Name, "pname");

            HasMany<JiraIssue>(x => x.Issues)
                .KeyColumn("PROJECT_ID")
                .Inverse()
                .Not.LazyLoad();
        }
    }
}
