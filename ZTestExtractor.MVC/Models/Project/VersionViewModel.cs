using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZTestExtractor.Models.Jira;

namespace ZTestExtractor.MVC.Models.Project
{
    public class VersionViewModel : BaseModel
    {
        public IEnumerable<JiraProjectVersionDisplayModel> ProjectVersionDisplayModels { get; set; }
    }
}