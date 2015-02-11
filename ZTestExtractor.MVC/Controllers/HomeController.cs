using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZTestExtractor.Business.Managers.Configurations;
using ZTestExtractor.Core.Models.Configurations;

namespace ZTestExtractor.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Configure()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Configure(DatabaseConfigurationModel model)
        {
            var result = new DatabaseConfigurationManager()
                .Save(model);

            return Json(model);
        }
    }
}