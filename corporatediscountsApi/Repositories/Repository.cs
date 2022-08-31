using corporatediscountsApi.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace corporatediscountsApi.Repositories
{
    public class Repository<Tentity,TdbContext> :IRepository<Tentity, TdbContext> where TdbContext : DbContext where Tentity:class
    {
        public TdbContext DbContext { get; set; }
        private DbSet<Tentity> _dbSet { get; set; }
        public Repository(TdbContext dbContext)
        {
            DbContext = dbContext;

            _dbSet= DbContext.Set<Tentity>();
        }

         public IList<Tentity> GetAll()
        {
            var query = from corporateDiscountEntity in DbContext.Set<CorporateDiscountEntity>()
                        join firm in DbContext.Set<FirmEntity>() on true equals true
                        join discountScope in DbContext.Set<DiscountScopeEntity>() on true equals true
                        where true
                        select new { firmid= corporateDiscountEntity.FirmId, firmame= firm.Name,discountScope.Name };
            

            return  _dbSet.AsEnumerable().ToList(); 



        }


        public IList<Tentity> GetByFilter(Expression<Func<Tentity,bool>> filter)
        {

            return _dbSet.Where(filter).ToList();

        }


    }
}
