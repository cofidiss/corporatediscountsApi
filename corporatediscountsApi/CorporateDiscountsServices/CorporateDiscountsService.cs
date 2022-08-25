using corporatediscountsApi.Repositories;
using corporatediscountsApi.Entities;
using corporatediscountsApi.DbContexts;
using System.Linq.Expressions;

namespace corporatediscountsApi.CorporateDiscountsServices
{
    public class CorporateDiscountsService
    {
        public IRepository<CorporateDiscountsEntity,PostgreDbContext> _repository { get; set; }
        public CorporateDiscountsService(IRepository<CorporateDiscountsEntity, PostgreDbContext> repository)
        {
            _repository = repository;


        }

        public IList<CorporateDiscountsEntity> GetAllDiscounts()
        {
           return _repository.GetAll();
        }


        public IList<CorporateDiscountsEntity> GetDiscountsByFilter(Expression<Func<CorporateDiscountsEntity,bool>> filter)
        {
            return _repository.GetByFilter(filter);
        }
    }
}
