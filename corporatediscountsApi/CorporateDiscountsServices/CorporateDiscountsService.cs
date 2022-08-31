using corporatediscountsApi.Repositories;
using corporatediscountsApi.Entities;
using corporatediscountsApi.DbContexts;
using System.Linq.Expressions;
using corporatediscountsApi.Models;

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


        public IList<CorporateDiscountEntity> GetDiscountsByFilter(DiscountSearchRequest filter)
        {
            var query = from corporateDiscount in _repository.DbContext.Set<CorporateDiscountEntity>()
                        join firm in _repository.DbContext.Set<FirmEntity>() on corporateDiscount.FirmId  equals firm.Id
                        join discountScope in _repository.DbContext.Set<DiscountScopeEntity>() on corporateDiscount.ScopeId equals discountScope.Id
                        where (corporateDiscount.ScopeId == filter.DiscountScopeId && firm.Name ==  filter.FirmName)
                        select new { FirmName= firm.Name, discountInfo= corporateDiscount.Description, DiscountScope= discountScope.Name };
            var a = query.ToList();
            return new List<CorporateDiscountEntity>();
        }
    }
}
