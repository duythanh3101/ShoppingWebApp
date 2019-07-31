using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingWebApp.Application.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToViewModelAutoMapper());
                cfg.AddProfile(new ViewModelToDomainAutoMapper());
            });
        }
    }
}
