using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cookizi.Controllers
{
    public class FoodsController : Controller
    {
        // GET: Foods
        public ActionResult Index()
        {
            return View();
        }
    }
}