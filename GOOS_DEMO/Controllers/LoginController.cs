using GOOS_DEMO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GOOS_DEMO.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(KULLANICI kullanici)
        {
            var sonuc = KULLANICI.Giris(kullanici);
            if (sonuc)
            {
                //giri basarili
                return Redirect("~/Home/Index");
            }
            return View(kullanici);
        }
    }
}