using AutoMapper;
using CategoryBackend.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryBackend.MyContext.Map
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<CategoryModel, CategoryDTO>();
            CreateMap<CategoryDTO, CategoryModel>();

        }

    }
}
