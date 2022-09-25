using corporatediscountsApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace corporatediscountsApi.Mappings
{
    public class CorporateDiscountMap : IEntityTypeConfiguration<CorporateDiscountEntity>
    {
        void IEntityTypeConfiguration<CorporateDiscountEntity>.Configure(EntityTypeBuilder<CorporateDiscountEntity> builder)
        {
            builder.ToTable("corporate_discount");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirmId).HasColumnName("firm_id");
            builder.Property(x=>x.Description).HasColumnName("description");
            builder.Property(x => x.ScopeId).HasColumnName("scope_id");
            builder.Property(x => x.CategoryId).HasColumnName("category_id");
            builder.Property(x => x.Id).HasColumnName("id");
        }
    }
}
