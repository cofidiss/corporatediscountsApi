using corporatediscountsApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace corporatediscountsApi.Mappings
{
    public class FirmCategoryMap : IEntityTypeConfiguration<FirmCategoryEntity>
    {
        void IEntityTypeConfiguration<FirmCategoryEntity>.Configure(EntityTypeBuilder<FirmCategoryEntity> builder)
        {
            builder.ToTable("discount_scope");
            builder.HasKey(x => x.Id).HasName("id");
            builder.Property(x => x.Name).HasColumnName("name");


        }
    
    }
}
