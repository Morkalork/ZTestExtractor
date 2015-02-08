using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTestExtractor.Entities.Jira;

namespace ZTestExtractor.Entities.Zephyr
{
    public class TestStepResult
    {
        public virtual int Id { get; set; }

        public virtual string Comment { get; set; }

        public virtual string CreatedBy { get; set; }

        public virtual string ModifiedBy { get; set; }

        public virtual string ExecutedBy { get; set; }

        /// <summary>
        /// The result status, based on TestStatus
        /// </summary>
        public virtual string Status { get; set; }

        public virtual JiraProject Project { get; set; }

        public virtual TestStep Step { get; set; }

        public virtual TestSchedule Schedule { get; set; }
    }
}
