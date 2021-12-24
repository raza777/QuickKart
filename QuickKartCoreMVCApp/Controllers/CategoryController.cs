using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuickKartDataAccessLayer;

namespace QuickKartCoreMVCApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly QuickKartRepository _repoj;
        private readonly IMapper _mapper;

        public CategoryController(QuickKartRepository repoj,IMapper mapper)
        {
            _repoj = repoj;
            _mapper = mapper;
        }
        public IActionResult ViewCategories()
        {
            var catListEnt = _repoj.GetCategories();
            List<Models.Categories> catList = new List<Models.Categories>();

            foreach (var item in catListEnt)
            {
                catList.Add(_mapper.Map<Models.Categories>(item));
            }
            return View(catList);
        }
    }
}
