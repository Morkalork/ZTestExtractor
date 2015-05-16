using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Data.Entities.Jira;

namespace ZTestExtractor.Data.EntityMappings.Jira
{
    public class JiraProjectVersionMap : ClassMap<JiraProjectVersion>
    {
        public JiraProjectVersionMap()
        {
            Table("projectversion");

            Id(x => x.Id, "ID");

            Map(x => x.Name, "vname");
            Map(x => x.Description, "DESCRIPTION");

            References<JiraProject>(x => x.Project)
                .Column("ID")
                .Not.Nullable();
        }
    }
}
