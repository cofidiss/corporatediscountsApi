using corporatediscountsApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace corporatediscountsApi.Mappings
{
    public class CorporateDiscountsMap : IEntityTypeConfiguration<CorporateDiscountsEntity>
    {
        void IEntityTypeConfiguration<CorporateDiscountsEntity>.Configure(EntityTypeBuilder<CorporateDiscountsEntity> builder)
        {
            builder.ToTable("rks_ik_corporatediscounts");
            builder.HasKey(x => x.FirmName).HasName("firm_name");
            builder.Property(x=>x.FirmName).HasColumnName("firm_name");
            builder.Property(x => x.DiscountInfo).HasColumnName("discount_info");
            builder.Property(x => x.DiscountDetail).HasColumnName("discount_detail");
            builder.Property(x => x.DiscountScope).HasColumnName("discount_scope");
            builder.Property(x => x.FirmContact).HasColumnName("firm_contact");
        }
    }
}
