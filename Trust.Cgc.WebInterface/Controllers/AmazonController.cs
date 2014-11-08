using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trust.Cgc.Core;

namespace Trust.Cgc.WebInterface.Controllers
{
    public class AmazonController : Controller
    {
        private readonly AmazonInterface amazonInterface;

        public AmazonController()
        {
            amazonInterface = new AmazonInterface();
        }

        public ActionResult Index()
        {
            var instances = amazonInterface.GetInstances();
            return View(instances);
        }

        public ActionResult Create()
        {
            amazonInterface.CreateInstance();
            return View();
        }

    }
}