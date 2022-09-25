
using corporatediscountsApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace corporatediscountsApi.Mappings
{
    public class FirmMap : IEntityTypeConfiguration<FirmEntity>
    {
        void IEntityTypeConfiguration<FirmEntity>.Configure(EntityTypeBuilder<FirmEntity> builder)
        {
            builder.ToTable("firm");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.ContactInfo).HasColumnName("contact_info");
 
            
        }
    
    }
}
