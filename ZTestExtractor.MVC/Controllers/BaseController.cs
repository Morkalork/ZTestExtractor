using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZTestExtractor.Business.Managers.Configurations;

namespace ZTestExtractor.MVC.Controllers
{
    public class BaseController : Controller
    {
        public bool IsDatabaseConfiguredCorrectly()
        {
            return new DatabaseConfigurationManager()
                .IsDatabaseConfiguredCorrectly();
        }
    }
}