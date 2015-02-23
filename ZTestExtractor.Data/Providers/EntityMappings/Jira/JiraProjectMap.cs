using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Core.Entities.Jira;

namespace ZTestExtractor.Data.EntityMappings.Jira
{
    public class JiraProjectMap : ClassMap<JiraProject>
    {
        public JiraProjectMap()
        {
            Table("project");

            Id(x => x.Id, "ID");

            Map(x => x.Key, "pkey");
            Map(x => x.Name, "pname");

            HasMany<JiraIssue>(x => x.Issues)
                .KeyColumn("ID")
                .Inverse()
                .Not.LazyLoad();
        }
    }
}
