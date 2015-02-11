using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Core.Entities.Zephyr;

namespace ZTestExtractor.Data.Repositories.Zephyr
{
    public class TestScheduleRepository : RepositoryBase<TestSchedule>
    {
        public TestScheduleRepository(ISession session) : base(session)
        { }

        public IEnumerable<TestSchedule> GetSchedulesByCycleId(int cycleId)
        {
            return Session
                .QueryOver<TestSchedule>()
                .Where(x => x.Cycle.Id == cycleId)
                .List();
        }
    }
}
