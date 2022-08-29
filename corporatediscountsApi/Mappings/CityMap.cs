using corporatediscountsApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace corporatediscountsApi.Mappings
{
    public class CityMap : IEntityTypeConfiguration<CityEntity>
    {
        public void Configure(EntityTypeBuilder<CityEntity> builder)
        {
            builder.ToTable("city");
            builder.HasKey(x => x.Id).HasName("id");
            builder.Property(x => x.Name).HasColumnName("name");
         

        }

    }
}
