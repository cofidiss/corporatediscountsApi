using corporatediscountsApi.Repositories;
using corporatediscountsApi.Entities;
using corporatediscountsApi.DbContexts;
using System.Linq.Expressions;

namespace corporatediscountsApi.CorporateDiscountsServices
{
    public class CorporateDiscountsService
    {
        public IRepository<CorporateDiscountEntity,PostgreDbContext> _repository { get; set; }
        public CorporateDiscountsService(IRepository<CorporateDiscountEntity, PostgreDbContext> repository)
        {
            _repository = repository;


        }

        public IList<CorporateDiscountEntity> GetAllDiscounts()
        {
           return _repository.GetAll();
        }


        public IList<CorporateDiscountEntity> GetDiscountsByFilter(Expression<Func<CorporateDiscountEntity,bool>> filter)
        {
            return _repository.GetByFilter(filter);
        }
    }
}
