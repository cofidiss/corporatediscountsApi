using corporatediscountsApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace corporatediscountsApi.Mappings
{
    public class DiscountCategoryMap : IEntityTypeConfiguration<DiscountCategoryEntity>
    {
        void IEntityTypeConfiguration<DiscountCategoryEntity>.Configure(EntityTypeBuilder<DiscountCategoryEntity> builder)
        {
            builder.ToTable("discount_category");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.ParentId).HasColumnName("parent_id");

        }
    
    }
}
