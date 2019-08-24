using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingWebApp.Data.EF.Extensions;
using ShoppingWebApp.Data.Entities;

namespace ShoppingWebApp.Data.EF.Configurations
{
    public class PageConfiguration : DbEntityConfiguration<Page>
    {
        public override void Configure(EntityTypeBuilder<Page> entity)
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasMaxLength(255).IsRequired();
            // etc.
        }
    }
}
