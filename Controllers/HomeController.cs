using Cookizi.Models;
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
            return View();
        }

        public ActionResult AccessDenied()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public JsonResult CheckLogin(string username, string password)

        {

            FoodDBEntities db = new FoodDBEntities();

            var dataItem = db.Users.Where(x => x.TenDangNhap == username && x.MatKhau == password).SingleOrDefault();

            bool isLogged = true;

            if (dataItem != null)

            {

                Session["TenDangNhap"] = dataItem.TenDangNhap;
                Session["Role"] = dataItem.Role;
                isLogged = true;

            }

            else

            {

                isLogged = false;

            }

            return Json(isLogged, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Logout()
        {
            Session["TenDangNhap"] = null;
            return RedirectToAction("Login");
        }
    }
}