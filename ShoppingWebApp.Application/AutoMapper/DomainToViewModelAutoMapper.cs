using AutoMapper;
using ShoppingWebApp.Application.ViewModels.Product;
using ShoppingWebApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingWebApp.Application.AutoMapper
{
    public class DomainToViewModelAutoMapper : Profile
    {
        public DomainToViewModelAutoMapper()
        {
            CreateMap<ProductCategory, ProductCategoryViewModel>();
        }
    }
}
