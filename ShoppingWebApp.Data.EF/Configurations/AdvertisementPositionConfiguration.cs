using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingWebApp.Data.EF.Extensions;
using ShoppingWebApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingWebApp.Data.EF.Configurations
{
    public class AdvertisementPositionConfiguration : DbEntityConfiguration<AdvertisementPosition>
    {
        public override void Configure(EntityTypeBuilder<AdvertisementPosition> entity)
        {
            entity.Property(c => c.Id).HasMaxLength(20).IsRequired();
        }
    }
}
