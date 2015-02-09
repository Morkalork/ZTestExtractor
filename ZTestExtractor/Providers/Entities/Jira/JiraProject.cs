using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTestExtractor.Entities.Jira
{
    public class JiraProject : Entity
    {
        public JiraProject()
        {
            Issues = new List<JiraIssue>();
        }

        public virtual string Name { get; set; }

        public virtual string Key { get; set; }

        public virtual IList<JiraIssue> Issues { get; set; }

        public override bool Equals(object obj)
        {
            var project = obj as JiraProject;

            if (project == null)
            {
                return false;
            }

            return this.Key.Equals(project.Key);
        }

        public override int GetHashCode()
        {
            return this.Key.GetHashCode();
        }
    }
}