using corporatediscountsApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace corporatediscountsApi.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<FirmCategoryEntity>
    {
        void IEntityTypeConfiguration<FirmCategoryEntity>.Configure(EntityTypeBuilder<FirmCategoryEntity> builder)
        {
            builder.ToTable("firm_category");
            builder.HasKey(x => x.Id).HasName("id");
            builder.Property(x => x.Name).HasColumnName("name");


        }
    
    }
}
