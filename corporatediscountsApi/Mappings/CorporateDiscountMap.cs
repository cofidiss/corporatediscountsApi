using corporatediscountsApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace corporatediscountsApi.Mappings
{
    public class CorporateDiscountMap : IEntityTypeConfiguration<CorporateDiscountEntity>
    {
        void IEntityTypeConfiguration<CorporateDiscountEntity>.Configure(EntityTypeBuilder<CorporateDiscountEntity> builder)
        {
            builder.ToTable("corporate_discounts");
            builder.HasKey(x => x.FirmId).HasName("firm_id");
            builder.Property(x=>x.Description).HasColumnName("description");
            builder.Property(x => x.ScopeId).HasColumnName("scope_id");
            builder.Property(x => x.ValidCities).HasColumnName("valid_cities");
       
        }
    }
}
