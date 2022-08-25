using corporatediscountsApi.Mappings;
using Microsoft.EntityFrameworkCore;

namespace corporatediscountsApi.DbContexts
{
    public class PostgreDbContext:DbContext
    {
        public PostgreDbContext(DbContextOptions<PostgreDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CorporateDiscountsMap());


            base.OnModelCreating(modelBuilder);
        }

    }
}
