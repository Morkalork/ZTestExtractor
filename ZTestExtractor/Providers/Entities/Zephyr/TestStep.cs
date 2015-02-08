using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Entities.Jira;

namespace ZTestExtractor.Entities.Zephyr
{
    public class TestStep : Entity
    {
        public virtual JiraIssue Issue { get; set; }

        public virtual TestSchedule Schedule { get; set; }

        public virtual int Order { get; set; }

        /// <summary>
        /// This is what to actually do
        /// </summary>
        public virtual string Step { get; set; }

        public virtual string ExpectedResult { get; set; }

        public virtual string Data { get; set; }

        public override bool Equals(object obj)
        {
            var testStep = obj as TestStep;

            if (testStep == null)
            {
                return false;
            }

            return this.Id.Equals(testStep.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
