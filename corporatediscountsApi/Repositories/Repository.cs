using corporatediscountsApi.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace corporatediscountsApi.Repositories
{
    public class Repository<Tentity,TdbContext> :IRepository<Tentity, TdbContext> where TdbContext : DbContext where Tentity:class
    {
        private TdbContext _dbContext { get; set; }
        private DbSet<Tentity> _dbSet { get; set; }
        public Repository(TdbContext dbContext)
        {
            _dbContext = dbContext;

            _dbSet= _dbContext.Set<Tentity>();
        }

         public IList<Tentity> GetAll()
        {
            var query = from corporateDiscountEntity in _dbContext.Set<CorporateDiscountEntity>()
                        join firm in _dbContext.Set<FirmEntity>() on corporateDiscountEntity.FirmId equals firm.Id
                        join discountScope in _dbContext.Set<DiscountScopeEntity>() on corporateDiscountEntity.ScopeId equals discountScope.Id
                           
                        select new { firmid= corporateDiscountEntity.FirmId, firmame= firm.Name,discountScope.Name };
            

            return  _dbSet.AsEnumerable().ToList(); 



        }


        public IList<Tentity> GetByFilter(Expression<Func<Tentity,bool>> filter)
        {

            return _dbSet.Where(filter).ToList();

        }


    }
}
