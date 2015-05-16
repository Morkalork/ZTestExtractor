using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZTestExtractor.Models.Jira;

namespace ZTestExtractor.MVC.Models.Tests
{
    public class ShowTestViewModel : BaseModel
    {
        public string ProjectName { get; set; }
    }
}