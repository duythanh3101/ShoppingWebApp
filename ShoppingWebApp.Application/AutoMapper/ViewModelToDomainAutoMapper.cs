using AutoMapper;
using ShoppingWebApp.Application.ViewModels.Product;
using ShoppingWebApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingWebApp.Application.AutoMapper
{
    public class ViewModelToDomainAutoMapper: Profile
    {
        public ViewModelToDomainAutoMapper()
        {
            CreateMap<ProductCategoryViewModel, ProductCategory>()
                .ConstructUsing(e => new ProductCategory(e.Name, e.Description, e.ParentId, e.HomeOrder, e.Image, e.HomeFlag, e.SortOrder, e.Status, e.SeoPageTitle, e.SeoAlias, e.SeoKeywords, e.SeoDescription));
        }


    }
}
