using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZTestExtractor.Business.Managers.Jira;
using ZTestExtractor.Core.Logging;
using ZTestExtractor.MVC.Models.Tests;

namespace ZTestExtractor.MVC.Controllers
{
    public class TestController : BaseController
    {
        public ActionResult Index()
        {
            var projects = new JiraProjectManager()
                .GetAll();

            var model = new TestViewModel
            {
                IsDatabaseConfiguredCorrectly = IsDatabaseConfiguredCorrectly(),
                Projects = projects
            };

            return View(model);
        }
    }
}