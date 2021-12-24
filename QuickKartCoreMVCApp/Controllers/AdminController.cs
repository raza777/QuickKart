using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickKartCoreMVCApp.Controllers
{
    public class AdminController : Controller
    {
        

        public IActionResult AdminHome()
        {
            List<string> lstProducts = new List<string>();
            lstProducts.Add("See and Say");
            lstProducts.Add("Wall Stickers");
            lstProducts.Add("Curtains");
            ViewBag.TopProducts = lstProducts;
            return View();
        }
    }
}
