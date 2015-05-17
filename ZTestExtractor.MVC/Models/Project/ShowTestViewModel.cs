using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZTestExtractor.Models.Jira;

namespace ZTestExtractor.MVC.Models.Project
{
    public class ShowTestViewModel : BaseModel
    {
        public string ProjectName { get; set; }

        public string ProjectVersion { get; set; }
    }
}