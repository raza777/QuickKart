using AutoMapper;
using QuickKartDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickKartCoreMVCApp.Repository
{
    public class QuickKartMapper : Profile
    {
        public QuickKartMapper()
        {
            CreateMap<Products, Models.Products>();
            CreateMap<Categories, Models.Categories>();
            CreateMap<Models.Products, Products>();

        }
    }
}
