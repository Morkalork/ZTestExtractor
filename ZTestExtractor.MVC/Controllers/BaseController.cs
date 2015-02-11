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
        private static bool _isDatabaseConfiguredCorrectlySet = false;

        public bool IsDatabaseConfiguredCorrectly(bool forceUpdate = false)
        {
            if (!_isDatabaseConfiguredCorrectlySet || forceUpdate)
            {
                _isDatabaseConfiguredCorrectlySet = new DatabaseConfigurationManager()
                    .IsDatabaseConfiguredCorrectly();
            }

            return _isDatabaseConfiguredCorrectlySet;
        }
    }
}