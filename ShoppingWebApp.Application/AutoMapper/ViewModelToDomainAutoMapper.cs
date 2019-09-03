using AutoMapper;
using ShoppingWebApp.Application.ViewModels.Product;
using ShoppingWebApp.Application.ViewModels.System;
using ShoppingWebApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingWebApp.Application.AutoMapper
{
    public class ViewModelToDomainAutoMapper : Profile
    {
        public ViewModelToDomainAutoMapper()
        {
            CreateMap<ProductCategoryViewModel, ProductCategory>()
                .ConstructUsing(e => new ProductCategory(e.Name, e.Description, e.ParentId, e.HomeOrder, e.Image, e.HomeFlag, e.SortOrder, e.Status, e.SeoPageTitle, e.SeoAlias, e.SeoKeywords, e.SeoDescription));

            CreateMap<ProductViewModel, Product>()
          .ConstructUsing(c => new Product(c.Name, c.CategoryId, c.Image, c.Price, c.OriginalPrice,
          c.PromotionPrice, c.Description, c.Content, c.HomeFlag, c.HotFlag, c.Tags, c.Unit, c.Status,
          c.SeoPageTitle, c.SeoAlias, c.SeoKeywords, c.SeoDescription));

            CreateMap<AppUserViewModel, AppUser>()
            .ConstructUsing(c => new AppUser(c.Id.GetValueOrDefault(Guid.Empty), c.FullName, c.UserName,
            c.Email, c.PhoneNumber, c.Avatar, c.Status));

            CreateMap<PermissionViewModel, Permission>()
            .ConstructUsing(c => new Permission(c.RoleId, c.FunctionId, c.CanCreate, c.CanRead, c.CanUpdate, c.CanDelete));



            CreateMap<AnnouncementViewModel, Announcement>()
                .ConstructUsing(c => new Announcement(c.Title, c.Content, c.UserId, c.Status));

            CreateMap<AnnouncementUserViewModel, AnnouncementUser>()
                .ConstructUsing(c => new AnnouncementUser(c.AnnouncementId, c.UserId, c.HasRead));
        }


    }
}
