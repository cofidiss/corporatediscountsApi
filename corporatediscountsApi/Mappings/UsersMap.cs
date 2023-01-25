using corporatediscountsApi.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace corporatediscountsApi.Mappings
{
    public class UsersMap : IEntityTypeConfiguration<UsersEntity>
    {
        void IEntityTypeConfiguration<UsersEntity>.Configure(EntityTypeBuilder<UsersEntity> builder)
        {
            builder.ToTable("users");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.UserName).HasColumnName("user_name");
            builder.Property(x => x.Password).HasColumnName("password");

        }
    
    }
}
