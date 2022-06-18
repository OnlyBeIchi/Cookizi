using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cookizi.Models;

namespace Cookizi.Controllers
{
    public class AnnounceController : Controller
    {
        // GET: Announce
        public ActionResult Index()
        {
            FoodList strFood = new FoodList();
            List<QLFood> obj = strFood.GetFood(string.Empty);
            return View(obj);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Create(QLFood strFood)
        {
            if (ModelState.IsValid)
            {
                FoodList Luat = new FoodList();
                Luat.AddFood(strFood);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit(string id = "")
        {
            FoodList Luat = new FoodList();
            List<QLFood> obj = Luat.GetFood(id);
            return View(obj.FirstOrDefault());
        }

        [HttpPost]

        public ActionResult Edit(QLFood strFood)
        {
            FoodList Luat = new FoodList();
            Luat.EditFood(strFood);
            return RedirectToAction("Index");
        }

        public ActionResult Details(string id = "")
        {
            FoodList Luat = new FoodList();
            List<QLFood> obj = Luat.GetFood(id);
            return View(obj.FirstOrDefault());
        }
      
    }
}