using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Data.Entities.Zephyr;

namespace ZTestExtractor.Data.Entities.Jira
{
    public class JiraIssue : Entity
    {
        public JiraIssue()
        {
            TestSteps = new List<TestStep>();
        }

        public virtual string CreatedBy { get; set; }

        public virtual string Description { get; set; }

        public virtual string Summary { get; set; }

        public virtual JiraProject Project { get; set; }

        public virtual IList<TestStep> TestSteps { get; set; }

        public override bool Equals(object obj)
        {
            var issue = obj as JiraIssue;

            if (issue == null)
            {
                return false;
            }

            return this.Id.Equals(issue.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
