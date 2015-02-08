using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Entities.Jira;

namespace ZTestExtractor.Entities.Zephyr
{
    public class TestSchedule
    {
        public virtual int Id { get; set; }

        public virtual string Comment { get; set; }

        public virtual string CreatedBy { get; set; }

        public virtual DateTime CreatedDate { get; set; }

        public virtual TestStatus Status { get; set; }

        public virtual JiraProject Project { get; set; }

        public virtual JiraIssue Issue { get; set; }

        public virtual TestCycle Cycle { get; set; }

        public virtual string Assignee { get; set; }

        public virtual string ExecutedBy { get; set; }

        public virtual int Order { get; set; }

        public override bool Equals(object obj)
        {
            var testSchedule = obj as TestSchedule;

            if (testSchedule == null)
            {
                return false;
            }

            return this.Id.Equals(testSchedule.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
