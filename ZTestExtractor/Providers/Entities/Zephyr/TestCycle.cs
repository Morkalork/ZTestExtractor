using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Entities.Jira;

namespace ZTestExtractor.Entities.Zephyr
{
    public class TestCycle : Entity
    {
        public virtual string Description { get; set; }

        public virtual string CreatedBy { get; set; }

        public virtual string Name { get; set; }

        public virtual JiraProject Project { get; set; }

        public override bool Equals(object obj)
        {
            var testCycle = obj as TestCycle;

            if (testCycle == null)
            {
                return false;
            }

            return this.Id.Equals(testCycle.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
