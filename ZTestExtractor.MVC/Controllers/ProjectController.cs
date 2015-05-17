using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZTestExtractor.MVC.Models.Project;

namespace ZTestExtractor.MVC.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult Tests(int projectId, int projectVersionId)
        {
            var model = new ShowTestViewModel();
            model.ProjectName = projectId.ToString();
            model.ProjectVersion = projectVersionId.ToString();

            return PartialView(model);
        }

        [HttpPost]
        public PartialViewResult Versions(int projectId)
        {
            throw new NotImplementedException();
        }
    }
}