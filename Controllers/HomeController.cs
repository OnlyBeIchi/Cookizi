using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cookizi.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            FoodDBEntities dbe = new FoodDBEntities();
            return View(dbe.Foods.ToList());
        }
    }
}