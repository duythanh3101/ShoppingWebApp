using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingWebApp.Data.EF.Extensions;
using ShoppingWebApp.Data.Entities;

namespace ShoppingWebApp.Data.EF.Configurations
{
    public class FooterConfiguration : DbEntityConfiguration<Footer>
    {
        public override void Configure(EntityTypeBuilder<Footer> entity)
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasMaxLength(255)
                .IsUnicode(false).HasMaxLength(255).IsRequired();
            // etc.
        }
    }
}
