using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickKartCoreMVCApp.Models;
using QuickKartDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace QuickKartCoreMVCApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly QuickKartRepository _repObj;

        public HomeController(QuickKartRepository repoj)
        {
            _repObj = repoj;

        }


        public IActionResult CheckRole(IFormCollection frm)
        {

            string userId = frm["name"];
            string password = frm["pwd"];
            byte? roleId = _repObj.ValidateCredentials(userId, password);
            if (roleId == 1)
            {
                return RedirectToAction("AdminHome", "Admin");
            }
            else if (roleId == 2)
            {
                return RedirectToAction("CustomerHome", "Customer");
            }
            return View("Login");

        }


        public JsonResult GetCoupons()
        {
            Random random = new Random();
            Dictionary<string, string> data = new Dictionary<string, string>();
            string[] value = new String[5];
            string[] key = { "Arts", "Electronics", "Fashion", "Home", "Toys"
};
            for (int i = 0; i < 5; i++)
            {
                string number = "RUSH" + random.Next(1, 10).ToString() +
               random.Next(1, 10).ToString() + random.Next(1, 10).ToString();
                value[i] = number;
            }
            for (int i = 0; i < 5; i++)
            {
                data.Add(key[i], value[i]);
            }
            return Json(data);
        }

        public ViewResult Contact()
        {
            return View();
        }






        public IActionResult Login()
            {
                return View();
            }

        public IActionResult Index()
            {
                return View();
            }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

         public RedirectResult FAQ()
         {
             return Redirect("/Home/Contact");
         }


    public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
