using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZTestExtractor.MVC.Models.Tests;

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
        public PartialViewResult Tests(int projectId)
        {
            var model = new ShowTestViewModel();
            model.ProjectName = projectId.ToString();

            return PartialView(model);
        }

        [HttpPost]
        public JsonResult Versions(int projectId)
        {
            throw new NotImplementedException();
        }
    }
}