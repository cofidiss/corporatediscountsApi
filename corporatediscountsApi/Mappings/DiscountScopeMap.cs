
using corporatediscountsApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace corporatediscountsApi.Mappings
{
    public class DiscountScopeMap : IEntityTypeConfiguration<DiscountScopeEntity>
    {
        void IEntityTypeConfiguration<DiscountScopeEntity>.Configure(EntityTypeBuilder<DiscountScopeEntity> builder)
        {
            builder.ToTable("discount_scope");
            builder.HasKey(x => x.Id).HasName("id");
            builder.Property(x => x.Name).HasColumnName("name");
        

        }
    
    }
}
