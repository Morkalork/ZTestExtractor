using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZTestExtractor.Data.Entities.Jira;

namespace ZTestExtractor.MVC.Models.Tests
{
    public class TestViewModel : BaseModel
    {
        public IEnumerable<JiraProject> Projects { get; set; }
    }
}