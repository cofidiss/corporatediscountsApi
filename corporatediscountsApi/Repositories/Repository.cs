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

           return  _dbSet.AsEnumerable().ToList(); 



        }


        public IList<Tentity> GetByFilter(Expression<Func<Tentity,bool>> filter)
        {

            return _dbSet.Where(filter).ToList();

        }


    }
}
