using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using QuickKartDataAccessLayer.Models;
using QuickKartDataAccessLayer;

namespace QuickKartCoreMVCApp.Controllers
{
    public class ProductController : Controller
    {

        private readonly QuickKartRepository _repObj;
        private readonly IMapper _mapper;

        public ProductController(QuickKartRepository repObj,IMapper mapper)
        {
            _repObj = repObj;
            _mapper = mapper;
        }
        public IActionResult ViewProducts()
        {
            var lstEntityProducts = _repObj.GetProducts();
            List<Models.Products> lstModelProducts = new List<Models.Products>();

            foreach (var product in lstEntityProducts)
            {
                lstModelProducts.Add(_mapper.Map<Models.Products>(product));
            }

            return View(lstModelProducts);
        }

        public IActionResult AddProduct()
        {
            string productId = _repObj.GetNextProductId();
            ViewBag.NextProductId = productId;
            return View();
        }

        [HttpPost]
        public IActionResult SaveAddedProduct(Models.Products product)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                try
                {
                    status = _repObj.AddProduct(_mapper.Map<Products>(product));
                    if (status)
                        return RedirectToAction("ViewProducts");
                    else
                        return View("Error");
                }
                catch (Exception)
                {
                    return View("Error");
                }
            }

            return View("AddProduct", product);


        }


        public IActionResult UpdateProduct(Models.Products prodObj)
        {

            return View(prodObj);

        }

        public IActionResult SaveUpdatedProduct(Models.Products product)
        {
            bool status = false;
            if(ModelState.IsValid)
            {
                try
                {
                    status = _repObj.UpdateProduct(_mapper.Map < Products > (product));

                    if (status)
                    {
                        return RedirectToAction("ViewProducts");
                    }
                    else
                        return View("Error");

                }
                catch (Exception)
                {

                    return View("Error");

                }

            }

            return View("UpdateProduct", product);

        }
    }
}
