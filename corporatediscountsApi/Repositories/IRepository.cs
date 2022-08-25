using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace corporatediscountsApi.Repositories
{
    public interface IRepository<Tentity, TdbContext> where TdbContext : DbContext where Tentity : class
    {
        IList<Tentity> GetAll();



        public IList<Tentity> GetByFilter(Expression<Func<Tentity, bool>> filter);
      

    }
}
