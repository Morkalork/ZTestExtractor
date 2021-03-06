﻿using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Data.Entities.Jira;
using ZTestExtractor.Data.Entities.Zephyr;

namespace ZTestExtractor.Data.EntityMappings.Zephyr
{
    public class TestStepResultMap : ClassMap<TestStepResult>
    {
        public TestStepResultMap()
        {
            Table("ao_7deabf_step_result");

            Id(x => x.Id, "ID");

            Map(x => x.Comment, "COMMENT");
            Map(x => x.CreatedBy, "CREATED_BY");
            Map(x => x.ModifiedBy, "MODIFIED_BY");
            Map(x => x.ExecutedBy, "EXECUTED_BY");
            Map(x => x.Status, "STATUS");

            References<JiraProject>(x => x.Project)
                .Column("ID")
                .Not.Nullable();

            References<TestStep>(x => x.Step)
                .Column("ID")
                .Not.Nullable();

            References<TestSchedule>(x => x.Schedule)
                .Column("ID")
                .Not.Nullable();
        }
    }
}
