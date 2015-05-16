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
                .GetAllDisplayModels();

            var model = new TestViewModel
            {
                IsDatabaseConfiguredCorrectly = IsDatabaseConfiguredCorrectly(),
                Projects = projects
            };

            return View(model);
        }

        [HttpPost]
        public PartialViewResult Show(int projectId)
        {
            var model = new ShowTestViewModel();
            model.ProjectName = projectId.ToString();

            return PartialView(model);
        }
    }
}