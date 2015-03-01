using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZTestExtractor.Models.Jira;

namespace ZTestExtractor.MVC.Models.Tests
{
    public class TestViewModel : BaseModel
    {
        public IEnumerable<JiraProjectDisplayModel> Projects { get; set; }
    }
}