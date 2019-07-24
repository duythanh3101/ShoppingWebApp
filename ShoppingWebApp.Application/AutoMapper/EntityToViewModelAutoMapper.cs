using AutoMapper;
using ShoppingWebApp.Application.ViewModels.Product;
using ShoppingWebApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingWebApp.Application.AutoMapper
{
    public class EntityToViewModelAutoMapper : Profile
    {
        public EntityToViewModelAutoMapper()
        {
            CreateMap<ProductCategory, ProductCategoryViewModel>();
        }
    }
}
