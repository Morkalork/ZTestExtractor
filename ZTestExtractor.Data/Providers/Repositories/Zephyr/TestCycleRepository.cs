﻿using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Data.Entities.Zephyr;
using ZTestExtractor.Data.Repositories;

namespace ZTestExtractor.Data.Test.Repositories.Zephyr
{
    public class TestCycleRepository : RepositoryBase<TestCycle>
    {
        public TestCycleRepository(ISession session) : base(session)
        { }

        public IEnumerable<TestCycle> GetCyclesByProjectId(int projectId)
        {
            return Session
                .QueryOver<TestCycle>()
                .Where(x => x.Project.Id == projectId)
                .List();
        }
    }
}
