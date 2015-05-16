using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTestExtractor.Data.Entities.Jira
{
    public class JiraProjectVersion : Entity
    {
        public virtual JiraProject Project { get; set; }

        public virtual string Name { get; set; }

        public virtual string Description { get; set; }
    }
}
