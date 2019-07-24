using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingWebApp.Data.EF.Extensions;
using ShoppingWebApp.Data.Entities;

namespace ShoppingWebApp.Data.EF.Configurations
{
    public class BlogTagConfiguration : DbEntityConfiguration<BlogTag>
    {
        public override void Configure(EntityTypeBuilder<BlogTag> entity)
        {
            entity.Property(c => c.TagId).HasMaxLength(50).IsRequired()
            .IsUnicode(false).HasMaxLength(50);
            // etc.
        }
    }
}
