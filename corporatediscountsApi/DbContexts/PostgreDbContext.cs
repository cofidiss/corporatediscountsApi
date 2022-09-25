using corporatediscountsApi.Mappings;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace corporatediscountsApi.DbContexts
{
    public class PostgreDbContext:DbContext
    {
        public PostgreDbContext(DbContextOptions<PostgreDbContext> options):base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging().LogTo(message => Debug.WriteLine(message));


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CorporateDiscountMap());
            modelBuilder.ApplyConfiguration(new FirmMap());
            modelBuilder.ApplyConfiguration(new DiscountScopeMap());
            modelBuilder.ApplyConfiguration(new DiscountCategoryMap());
            base.OnModelCreating(modelBuilder);
        }

    }
}
