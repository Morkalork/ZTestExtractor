using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Core.Entities.Jira;
using ZTestExtractor.Core.Entities.Zephyr;

namespace ZTestExtractor.Data.EntityMappings.Zephyr
{
    public class TestStepMap : ClassMap<TestStep>
    {
        public TestStepMap()
        {
            Table("ao_7deabf_teststep");

            Id(x => x.Id, "ID");

            Map(x => x.Data, "DATA");
            Map(x => x.Order, "ORDER_ID");
            Map(x => x.Step, "STEP");
            Map(x => x.ExpectedResult, "RESULT");

            References<JiraIssue>(x => x.Issue)
                .Column("ID")
                .Not.Nullable();
        }
    }
}
