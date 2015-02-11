using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZTestExtractor.Business.Managers.Configurations;
using ZTestExtractor.Core.Models.Configurations;
using ZTestExtractor.MVC.Models;
using ZTestExtractor.MVC.Models.Configurations;

namespace ZTestExtractor.MVC.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var model = new BaseModel
            {
                IsDatabaseConfiguredCorrectly = IsDatabaseConfiguredCorrectly()
            };

            return View(model);
        }

        [HttpGet]
        public ViewResult Configure()
        {
            var configurationModel = new DatabaseConfigurationManager()
                .Load();

            var systems = Enum.GetValues(typeof(DatabaseSystems))
                .Cast<DatabaseSystems>()
                .Where(x => x != DatabaseSystems.Unknown);

            var model = new ConfigurationsViewModel
            {
                DatabaseConfigurationModel = configurationModel,
                DatabaseSystems = systems
            };

            return View(model);
        }

        [HttpPost]
        public JsonResult Configure(DatabaseConfigurationModel model)
        {
            var result = new DatabaseConfigurationManager()
                .Save(model);

            return Json(result);
        }
    }
}